using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Words : MonoBehaviour
{
    public Data data;
    public List<GameObject> LetterList;
    string[] answers = { "кот", "ток" };
    string word ="";
    void Start()
    {
        data = new Data('a', answers);
        Letters[] lett = FindObjectsOfType<Letters>();
        foreach(Letters myLett in lett)
        {
            myLett.data = data;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            var touchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Collider2D col = Physics2D.Raycast(touchPosition, transform.position).collider;
            AddLetter(col);
        }
        else if(LetterList.Count !=0)
        {
            foreach(GameObject myLett in LetterList)
            {
                Letters lt = myLett.GetComponent<Letters>();
                word += lt.letter;
            }
            print(word);
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