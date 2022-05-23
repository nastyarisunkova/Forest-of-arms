using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Menu : MonoBehaviour
{
    public Text moneyText;
    public TextMeshProUGUI progressText;
    public GameObject packIconPrefab;
    Image[] packIcons;
    GameData gameData;

    void Start()
    {
        if (DataLoad.LoadGame() != null)
        {
            gameData = DataLoad.LoadGame();
        }
        else
        {
            gameData = new GameData();
            DataLoad.SaveData(gameData);
        }
        /*        gameData = new GameData();
                DataLoad.SaveData(gameData);*/

        packIcons = packIconPrefab.GetComponentsInChildren<Image>();
        for (int i = 1; i < packIcons.Length; i++)
        {
            if (i == gameData.packIcon)
            {
                continue;
            }
            packIcons[i].gameObject.SetActive(false);
        }
        gameData.packIcon = 1;
        moneyText.text = gameData.money.ToString();
        progressText.text = gameData.progressPercent.ToString() + "%";
    }

    public void LoadGame()
    {
        SceneManager.LoadScene(1);
    }
}
