using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paint : MonoBehaviour
{
    Data data;
    public GameObject panel;
    public GameObject prefab;
    float space = 50;
    float x;
    float y;

    bool painted = false;
    public void Show()
    {
        print(panel.GetComponent<RectTransform>().rect.width);
        data = new Data();
        if (!painted)
        {
            float size = (panel.GetComponent<RectTransform>().rect.width - ((1+data.answers.Length) * space)) / data.answers.Length;
            print("size " + size);
            print("height + " + panel.GetComponent<RectTransform>().rect.height);
            if(size * data.answers.Length+space* (data.answers.Length + 1)> panel.GetComponent<RectTransform>().rect.height)
            {
                size = (panel.GetComponent<RectTransform>().rect.height - ((1 + data.answers.Length) * space)) / data.answers.Length;
                print("size " + size);
            }
            print(x);
            y = panel.GetComponent<RectTransform>().rect.height / 2 - space;
            print(y);
            for (int i = 0; i < data.answers.Length; i++)
            {
                x = -panel.GetComponent<RectTransform>().rect.width / 2 +space;
                
                for (int j = 0; j < data.answers[i].Length; j++)
                {
                    prefab.GetComponent<RectTransform>().sizeDelta = new Vector2(size, size);/*
            prefab.GetComponent<RectTransform>().anchorMin = new Vector2(0, 0);
            prefab.GetComponent<RectTransform>().anchorMin = new Vector2(size, size);*/
                    GameObject obj = Instantiate(prefab);
                    obj.transform.SetParent(panel.transform, false);
                    obj.transform.localPosition = new Vector3(x, y, 0);
                    x += space + size;
                }
                y -= space + size;
            }
            painted = true;
        }
    }
}
