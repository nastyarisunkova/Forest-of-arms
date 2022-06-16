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
        SceneManager.LoadScene(2); 
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
