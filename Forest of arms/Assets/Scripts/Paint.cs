using UnityEngine;
using UnityEngine.UI;

public class Paint : MonoBehaviour
{
    Data data;
    public GameObject panel;
    public GameObject prefab;
    float space = 10;
    int qSpace = 1;
    float x;
    float y;

    bool painted = false;
    public void Show()
    {
        data = DataLoad.ReadFromJson("level" + DataLoad.ReadFile("Assets/Levels/number.txt"));
        if (!painted)
        {
            int col;
            if (data.answers.Length <= 5)
                col = data.answers.Length;
            else if (data.answers.Length > 5 && data.answers.Length <= 10)
            {
                col = data.answers[4].Length + data.answers[data.answers.Length - 1].Length;
                qSpace = 2;
            }
            else
            {
                col = data.answers[4].Length + data.answers[9].Length + data.answers[data.answers.Length - 1].Length;
                qSpace = 3;
            }

            float size = (panel.GetComponent<RectTransform>().rect.width - ((qSpace + col) * space)) / col;
            if (size * 5 + space * (5 + 1) > panel.GetComponent<RectTransform>().rect.height)
            {
                size = (panel.GetComponent<RectTransform>().rect.height - ((qSpace + col) * space)) / col;
            }
            prefab.GetComponentInChildren<Text>().fontSize = (int)(size * 70 / 100);

            float temp = 0;
            y = panel.GetComponent<RectTransform>().rect.height / 2 - space;
            for (int i = 0; i < data.answers.Length; i++)
            {
                if (i < 5)
                    x = -panel.GetComponent<RectTransform>().rect.width / 2 + space;
                else
                {
                    if (i == 5 || i==10)
                    {
                        temp = x;
                        y = panel.GetComponent<RectTransform>().rect.height / 2 - space;
                    }
                    x = temp + space;

                }

                for (int j = 0; j < data.answers[i].Length; j++)
                {
                    prefab.GetComponent<RectTransform>().sizeDelta = new Vector2(size, size);
                    GameObject obj = Instantiate(prefab);
                    obj.transform.SetParent(panel.transform, false);
                    obj.transform.localPosition = new Vector3(x, y, 0);
                    x += space + size;
                }
                y -= space + 10 + size;
            }
            painted = true;
        }
    }
}
