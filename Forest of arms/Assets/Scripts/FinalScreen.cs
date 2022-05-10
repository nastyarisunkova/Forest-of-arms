using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class FinalScreen : MonoBehaviour
{
    public Text moneyText;
    public TextMeshProUGUI progressText;
    GameData gameData;
    public GameObject packIconPrefab;
    Image[] packIcons;
    private void Start()
    {
        gameData = DataLoad.LoadGame();
        moneyText.text = gameData.money.ToString();
        progressText.text = gameData.progressPercent.ToString() + "%";

        packIcons = packIconPrefab.GetComponentsInChildren<Image>();
        for (int i = 1; i < packIcons.Length; i++)
        {
            if (i != gameData.packIcon)
            {
                packIcons[i].gameObject.SetActive(false);
            }
            
        }
    }
    public void LoadNextLevel()
    {
        string path = "Assets/Levels/number.txt";
        int number = Convert.ToInt32(DataLoad.ReadFile(path)) + 1;

        DataLoad.WriteFile(path, number.ToString());

        SceneManager.LoadScene(1); 
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
