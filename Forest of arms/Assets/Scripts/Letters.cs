using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Letters : MonoBehaviour
{
    Data data;
    public GameObject circle;
    public Text[] letters;
    public GameObject letterPrefab;
    char[] lettersArray;

    float r;
    float angle;

    private void Start()
    {
        data = DataLoad.ReadFromJson("level" + DataLoad.ReadFile("Assets/Levels/number.txt"));
        DrawLetterrs();
        lettersArray = data.answers[data.answers.Length - 1].ToCharArray();
        letters = circle.GetComponentsInChildren<Text>();
        InitializeLetters();
    }

    void InitializeLetters()
    {
        for (int i = 0; i < lettersArray.Length; i++)
        {
            letters[i].text = lettersArray[i].ToString().ToUpper();
        }
    }

    void DrawLetterrs()
    {
        r = circle.GetComponent<RectTransform>().rect.width / 2 - 23.35f / 2;
        angle = 360 / data.answers[data.answers.Length - 1].Length;
        float startAngle = 90;
        for (int i = 0; i < data.answers[data.answers.Length - 1].Length; i++)
        {
            var x = r * Mathf.Cos(startAngle * Mathf.PI / 180);
            var y = r * Mathf.Sin(startAngle * Mathf.PI / 180);
            GameObject obj = Instantiate(letterPrefab);
            obj.transform.SetParent(circle.transform, false);
            obj.transform.localPosition = new Vector3(x, y, 0);
            startAngle += angle;
        }
    }
}
