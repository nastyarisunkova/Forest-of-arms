using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Letters : MonoBehaviour
{
    Data data;
    public GameObject lettersBttns;
    public Text[] letters;
    char[] lettersArray;

    private void Start()
    {
        data = new Data();
        lettersArray = data.answers[data.answers.Length - 1].ToCharArray();
        letters = lettersBttns.GetComponentsInChildren<Text>();
        InitializeLetters();
    }

    void InitializeLetters()
    {
        for(int i = 0; i<lettersArray.Length;i++)
        {
            letters[i].text = lettersArray[i].ToString();
        }
    }
}
