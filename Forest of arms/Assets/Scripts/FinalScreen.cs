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
        int number = Convert.ToInt32(DataLoad.ReadFile(path)) + 1;

        DataLoad.WriteFile(path, number.ToString());

        SceneManager.LoadScene(1); 
    }
}
