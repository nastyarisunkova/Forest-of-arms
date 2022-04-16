using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class DataLoad
{
    public static void SaveToJson(string content)
    {
        FileStream fileStream = new FileStream("C:/Unity/Forest-of-arms/Forest of arms/Assets/Levels/level1.json", FileMode.Create);

        using (StreamWriter writer = new StreamWriter(fileStream))
        {
            writer.Write(content);
        }
    }
    public static Data ReadFromJson(string fileName)
    {
        using (StreamReader fs = new StreamReader($"C:/Unity/Forest-of-arms/Forest of arms/Assets/Levels/{fileName}.json"))
        {
            return JsonUtility.FromJson<Data>(fs.ReadToEnd());
        }
    }
    public static string ReadFile(string path)
    {
        using (StreamReader fs = new StreamReader(path))
        {
            return fs.ReadToEnd();
        }
    }
    public static void WriteFile(string path, string content)
    {
        FileStream fileStream = new FileStream(path, FileMode.Open);
        using (StreamWriter writer = new StreamWriter(fileStream))
        {
            writer.Write(content);
        }
    }

    public static void SaveData(GameData data)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath
          + "/SaveData.dat");
        GameData gdata = new GameData(data.money);
        bf.Serialize(file, gdata);
        file.Close();
        Debug.Log("Game data saved!");
    }

    public static GameData LoadGame()
    {
        if (!File.Exists(Application.persistentDataPath
          + "/SaveData.dat"))
            return null;
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(Application.persistentDataPath + "/SaveData.dat", FileMode.Open);
        GameData gdata = bf.Deserialize(file) as GameData;
        file.Close();
        Debug.Log("Game data loaded!");
        return gdata;
    }
}

[System.Serializable]
public class GameData
{
    public int money;
/*    public int progress;
    public string[] answers;*/

    public GameData(int money)
    {
        this.money = money;
    }
}