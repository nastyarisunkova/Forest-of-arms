using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FinalScreen : MonoBehaviour
{
    public Text moneyText;
    GameData gameData;
    private void Start()
    {
        gameData = DataLoad.LoadGame();
        moneyText.text = gameData.money.ToString();
    }
    public void LoadNextLevel()
    {
        string path = "Assets/Levels/number.txt";
        int number = Convert.ToInt32(DataLoad.ReadFile(path)) + 1;

        DataLoad.WriteFile(path, number.ToString());

        SceneManager.LoadScene(1); 
    }
}
