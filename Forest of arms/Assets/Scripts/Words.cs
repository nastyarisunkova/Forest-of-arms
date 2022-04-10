using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class Words : MonoBehaviour
{
    Paint paint;
    public string numberOfLevel = "1"; // номер будет равен уровню из файла прогресса
    public Data data;
    public List<GameObject> LetterList;
    public GameObject panel;
    string[] answers;
    string word = "";
    Text[] texts;
    char[,] textAnsw;
    char[] letters;
    void Start()
    {
        numberOfLevel = Json.ReadFile("Assets/Levels/number.txt");
        paint = FindObjectOfType<Paint>();
        paint.Show();
        data = Json.ReadFromJson("level" + numberOfLevel);
        answers = data.answers;
        texts = panel.GetComponentsInChildren<Text>();
        textAnsw = new char[answers.Length, answers[answers.Length - 1].Length];
        for (int i = 0, n = 0; i < answers.Length; i++)
        {
            letters = answers[i].ToCharArray();
            for (int j = 0; j < answers[i].Length; j++, n++)
            {
                textAnsw[i, j] = letters[j];
                texts[n].text = textAnsw[i, j].ToString();
                texts[n].gameObject.SetActive(false);
            }
        }
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            var touchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Collider2D col = Physics2D.Raycast(touchPosition, transform.position).collider;
            AddLetter(col);
        }
        else if (LetterList.Count != 0)
        {
            int temp = 0;
            foreach (GameObject myLett in LetterList)
            {
                Letter lt = myLett.GetComponent<Letter>();
                word += lt.letter.text;
            }
            print(word);
            for (int i = 0; i < answers.Length; i++)
            {
                if (answers[i] == word)
                {
                    for (int n = 0; n < answers[i].Length; n++)
                    {
                        texts[temp].gameObject.SetActive(true);
                        temp++;
                    }
                    LoadFinalScreen();
                }
                temp += answers[i].Length;
            }
            ClearList();
        }

    }
    void LoadFinalScreen()
    {
        bool load = true;
        foreach(Text text in texts)
        {
            if(text.gameObject.activeSelf == false)
            {
                load = false;
                break;
            }
        }
        if(load)
        {

            SceneManager.LoadScene(2);
        }
    }
    void ClearList()
    {
        for (int i = 0; i < LetterList.Count - 1; i++)
        {
            LineRenderer lr = LetterList[i].GetComponent<LineRenderer>();
            lr.SetPosition(1, LetterList[i].transform.position);
        }
        LetterList.Clear();
        word = null;
    }
    void AddLetter(Collider2D col)
    {
        if (col != null)
        {
            var obj = col.gameObject;
            var bs = obj.GetComponent<Letter>();
            if (bs != null)
            {
                if (!LetterList.Contains(obj))
                {
                    LetterList.Add(obj);
                }

                for (int i = 0; i < LetterList.Count - 1; i++)
                {
                    LineRenderer lr = LetterList[i].GetComponent<LineRenderer>();
                    lr.SetPosition(0, LetterList[i].transform.position);
                    lr.SetPosition(1, LetterList[i + 1].transform.position);
                }
            }
        }
    }
}

[System.Serializable]
public class Data
{
    public string[] answers;
}