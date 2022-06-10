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
        gameData = DataLoad.LoadGame();
        packIcons = packIconPrefab.GetComponentsInChildren<Image>();
        for (int i = 1; i < packIcons.Length; i++)
        {
            if (i == gameData.packIcon)
            {
                continue;
            }
            packIcons[i].gameObject.SetActive(false);
        }
        moneyText.text = gameData.money.ToString();
        progressText.text = gameData.progressPercent.ToString() + "%";
    }

    public void LoadGame()
    {
        SceneManager.LoadScene(2);
    }
}
