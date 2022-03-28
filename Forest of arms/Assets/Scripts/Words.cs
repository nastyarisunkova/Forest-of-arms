using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Words : MonoBehaviour
{
    public Data data;
    public List<GameObject> LetterList;
    public GameObject panel;
    string[] answers = { "���", "���","���" };
    string word = "";
    Text[] texts;
    char[,] textAnsw;
    char[] letters;
    void Start()
    {
        data = new Data('a', answers);
        Letters[] lett = FindObjectsOfType<Letters>();
        texts = panel.GetComponentsInChildren<Text>();
        textAnsw = new char[answers.Length, answers[answers.Length - 1].Length];
        for (int i = 0, n =0; i < answers.Length; i++)
        {
            letters = answers[i].ToCharArray();
            for (int j = 0; j < answers[i].Length; j++, n++)
            {
                textAnsw[i, j] = letters[j];
                texts[n].text = textAnsw[i, j].ToString();
                texts[n].gameObject.SetActive(false);
            }
        }
        foreach (Letters myLett in lett)
        {
            myLett.data = data;
        }
    }

    // Update is called once per frame
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
                Letters lt = myLett.GetComponent<Letters>();
                word += lt.letter;
            }
            for (int i = 0; i < answers.Length; i++)
            {
                if (answers[i] == word)
                {
                    for (int n = 0; n < answers[i].Length; n++)
                    {
                        texts[temp].gameObject.SetActive(true);
                        temp++;
                    }
                }
                temp += answers[i].Length;
            }
            ClearList();
        }

    }
    void ClearList()
    {
        /*foreach (GameObject myBase in LetterList)
        {
            LineRenderer lr = myBase.GetComponent<LineRenderer>();
            lr.SetPosition(1, myBase.transform.position);
        }*/
        LetterList.Clear();
        word = null;
    }
    void AddLetter(Collider2D col)
    {
        if (col != null)
        {
            var obj = col.gameObject;
            var bs = obj.GetComponent<Letters>();
            if (bs != null)
            {
                if ((bs.data == data) && (!LetterList.Contains(obj)))
                {
                    LetterList.Add(obj);
                }

                /*                foreach (GameObject myBase in LetterList)
                                {
                                    LineRenderer lr = myBase.GetComponent<LineRenderer>();
                                    if (bs.data == data)
                                    {
                                        lr.SetPosition(0, myBase.transform.position);
                                        lr.SetPosition(1, EndPoint.transform.position);
                                    }
                                    else
                                    {
                                        lr.SetPosition(1, myBase.transform.position);
                                    }
                                }*/
            }
        }
    }
}
[System.Serializable]
public class Data
{
    public char word;
    string[] answers;
    public Data(char word, string[] answers)
    {
        this.word = word;
        this.answers = answers;
    }

}