using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadGame : MonoBehaviour
{
    public Scrollbar scrollbar;
    public Text progressText;
    GameData gameData;

    void Start()
    {
        if (!File.Exists(Application.persistentDataPath + "/GameData.dat"))
        {
            gameData = new GameData();
            DataLoad.SaveData(gameData);
        }
        StartCoroutine(AsyncLoad());
    }

    IEnumerator AsyncLoad()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(1);
        while (!operation.isDone)
        {
            float progress = operation.progress / 0.9f;
            scrollbar.size = progress;
            progressText.text = string.Format("{0:0}%", progress * 100);
            yield return null;
        }
    }
}
