using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Linq;
using System;

public class Interface : MonoBehaviour
{
    Data data;
    Words words;
    public Text[] letters;
    public Text hintOL;
    public Text hintRL;

    string text = "";
    private void Start()
    {
        data = DataLoad.ReadFromJson("level" + DataLoad.ReadFile("Assets/Levels/number.txt"));
        words = FindObjectOfType<Words>();
    }

    public void LettersToText()
    {
        foreach (Text letter in letters)
        {
            text += letter.text;
        }
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void OpenRepeatLetters()
    {
        if(Convert.ToInt32(words.moneyText.text) > Convert.ToInt32(hintRL.text))
        {
            int count = 0;
            char l = ' ';
            foreach (char letter in text)
            {
                var temp = text.Count(chr => chr == letter);
                if (count < temp)
                {
                    count = temp;
                    l = letter;
                }
            }

            for (int i = 0; i < letters.Length; i++)
            {
                if (letters[i].text == l.ToString())
                {
                    letters[i].gameObject.SetActive(true);
                    text = text.Replace(l.ToString(), "");
                }
            }
            words.moneyText.text = (Convert.ToInt32(words.moneyText.text) - Convert.ToInt32(hintRL.text)).ToString();
            words.LoadFinalScreen();
        }
    }

    public void OpenOneLetter()
    {
        if (Convert.ToInt32(words.moneyText.text) > Convert.ToInt32(hintOL.text))
        {
            Text hint;
            bool flag = true;
            while (flag)
            {
                hint = letters[UnityEngine.Random.Range(0, letters.Length)];
                if (!hint.gameObject.activeSelf)
                {
                    hint.gameObject.SetActive(true);
                    flag = false;
                    words.LoadFinalScreen();
                }
            }
            words.moneyText.text = (Convert.ToInt32(words.moneyText.text) - Convert.ToInt32(hintOL.text)).ToString();
        }
    }
}
