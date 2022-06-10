using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class Words : MonoBehaviour
{
    Paint paint;
    Interface Interface;
    public string numberOfLevel;
    public Data data;
    public List<GameObject> LetterList;
    public GameObject panel;
    public GameObject circle;
    public Text moneyText;
    string[] answers;
    string word = "";
    Text[] texts;
    char[,] textAnsw;
    char[] letters;
    GameData gameData;
    LineRenderer lr;
    Vector3 touchPosition;
    int percent = 20;

    void Start()
    {
        lr = circle.GetComponent<LineRenderer>();
        numberOfLevel = DataLoad.ReadFile("Assets/Levels/number.txt");

        paint = FindObjectOfType<Paint>();
        paint.Show();

        Interface = FindObjectOfType<Interface>();

        data = DataLoad.ReadFromJson("level" + numberOfLevel);

        gameData = DataLoad.LoadGame();
        moneyText.text = gameData.money.ToString();

        /*LoadLetters();*/
        answers = data.answers;

        texts = panel.GetComponentsInChildren<Text>();
        bool wasSaved = false;
        if (gameData.answers != null)
        {
            for (int i = 0; i < gameData.answers.Length; i++)
            {
                texts[i].gameObject.SetActive(gameData.answers[i]);
            }
            wasSaved = true;
        }

        textAnsw = new char[answers.Length, answers[answers.Length - 1].Length];
        for (int i = 0, n = 0; i < answers.Length; i++, n++)
        {
            letters = answers[i].ToCharArray();
            for (int j = 0; j < answers[i].Length; j++)
            {
                textAnsw[i, j] = letters[j];
                texts[n].text = textAnsw[i, j].ToString().ToUpper();
                if (wasSaved)
                {
                    Debug.Log(n);
                    texts[n].gameObject.SetActive(gameData.answers[n]);
                }
                else
                    texts[n].gameObject.SetActive(false);
            }
        }

        Interface.letters = texts;
        Interface.LettersToText();
    }
    void Update()
    {
        if (Input.touchCount > 0)
        {
            touchPosition = Camera.main.ScreenToWorldPoint(Input.touches[0].position);
            /*        if (Input.GetMouseButton(0))
                    {
                        touchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);*/
            Collider2D col = Physics2D.Raycast(touchPosition, transform.position).collider;
            AddLetter(col);

            lr.positionCount = LetterList.Count + 1;
            for (int i = 0; i < LetterList.Count; i++)
            {
                Vector3 Pos = new Vector3(LetterList[i].GetComponent<RectTransform>().position.x, LetterList[i].GetComponent<RectTransform>().position.y, 0);
                lr.SetPosition(i, Pos);
                touchPosition.z = 0;
                lr.SetPosition(i + 1, touchPosition);
            }
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
                if (answers[i] == word.ToLower())
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

/*    void LoadLetters()
    {
        answers = data.answers;

        texts = panel.GetComponentsInChildren<Text>();
        bool wasSaved = false;
        if (gameData.answers != null)
        {
            for (int i = 0; i < gameData.answers.Length; i++)
            {
                texts[i].gameObject.SetActive(gameData.answers[i]);
            }
            wasSaved = true;
        }

        textAnsw = new char[answers.Length, answers[answers.Length - 1].Length];
        for (int i = 0, n = 0; i < answers.Length; i++)
        {
            letters = answers[i].ToCharArray();
            for (int j = 0; j < answers[i].Length; j++, n++)
            {
                textAnsw[i, j] = letters[j];
                texts[n].text = textAnsw[i, j].ToString().ToUpper();
                if (wasSaved)
                    texts[n].gameObject.SetActive(gameData.answers[n]);
                else
                    texts[n].gameObject.SetActive(false);
            }
        }
    }*/

    public void LoadFinalScreen()
    {
        bool load = true;

        gameData.answers = new bool[texts.Length];
        for (int i = 0; i < gameData.answers.Length; i++)
        {
            gameData.answers[i] = texts[i].gameObject.activeSelf;
        }

        DataLoad.SaveData(gameData);

        foreach (Text text in texts)
        {
            if (text.gameObject.activeSelf == false)
            {
                load = false;
                break;
            }
        }
        if (load)
        {
            moneyText.text = (gameData.money + 10).ToString();
            gameData.progressPercent += percent;
            if (gameData.progressPercent >= 100)
            {
                gameData.packIcon++;
                gameData.progressPercent = 0;
            }
            gameData.money += 10;

            DataLoad.WriteFile("Assets/Levels/number.txt", (Convert.ToInt32(numberOfLevel) + 1).ToString());

            DataLoad.SaveData(gameData);
            SceneManager.LoadScene(3);
        }
    }
    void ClearList()
    {
        for (int i = 0; i <= LetterList.Count; i++)
        {

            if (i != LetterList.Count)
                lr.SetPosition(i, LetterList[i].GetComponent<RectTransform>().position);
            else
            {
                lr.SetPosition(i, LetterList[i - 1].GetComponent<RectTransform>().position);
            }
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
            }
        }
    }
}

[System.Serializable]
public class Data
{
    public string[] answers;
}