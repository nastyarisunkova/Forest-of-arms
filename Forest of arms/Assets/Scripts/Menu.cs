using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public Text moneyText;
    GameData gameData;
    void Start()
    {
        if (DataLoad.LoadGame() != null)
        {
            gameData = DataLoad.LoadGame();
        }
        else
        {
            gameData = new GameData(0);
            DataLoad.SaveData(gameData);
        }
        
        moneyText.text = gameData.money.ToString();
    }

    

    public void LoadGame()
    {
        SceneManager.LoadScene(1);
    }
}
