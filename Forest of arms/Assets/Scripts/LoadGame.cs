using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class LoadGame : MonoBehaviour
{
    GameData gameData;
    void Start()
    {
        if (!File.Exists(Application.persistentDataPath + "/GameData.dat"))
        {
            gameData = new GameData();
            DataLoad.SaveData(gameData);
        }
    }
     public void LoadMenu()
    {
        SceneManager.LoadScene(1);
    }
}
