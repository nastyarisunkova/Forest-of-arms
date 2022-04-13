using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Linq;

public class Interface : MonoBehaviour
{
    Data data;
    public Text[] letters;

    private void Start()
    {
        data = Json.ReadFromJson("level" + Json.ReadFile("Assets/Levels/number.txt"));
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void OpenRepeatLetters()
    {
        int count = 0;
        Text l = letters[0];
        foreach(Text letter in letters)
        {
            var temp = letters.Count(chr => chr == letter);
            if (count < temp)
            {
                count = temp;
                l = letter;
            }
        }
        print(count);

        foreach(Text letter in letters)
        {
            if(letter.text == l.text)
            {
                l.gameObject.SetActive(true);
            }
        }
    }

    public void OpenOneLetter()
    {
        Text hint;
        bool flag = true;
        while(flag)
        {
            hint = letters[Random.Range(0,letters.Length)];
            if(!hint.gameObject.activeSelf)
            {
                hint.gameObject.SetActive(true);
                flag = false;
            }
        }
    }
}
