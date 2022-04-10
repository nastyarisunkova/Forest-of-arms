using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using System;

public class FinalScreen : MonoBehaviour
{
    public void LoadNextLevel()
    {
        string path = "Assets/Levels/number.txt";
        int number = Convert.ToInt32(Json.ReadFile(path)) + 1;

        Json.WriteFile(path, number.ToString());

        SceneManager.LoadScene(1); 
    }
}
