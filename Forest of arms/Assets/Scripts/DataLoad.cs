using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.UI;

public class DataLoad
{
    public static Data ReadFromJson(string fileName)
    {
        using (StreamReader fs = new StreamReader($"Assets/Levels/{fileName}.json"))
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
          + "/GameData.dat");
        bf.Serialize(file, data);
        file.Close();
    }

    public static GameData LoadGame()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(Application.persistentDataPath + "/GameData.dat", FileMode.Open);
        GameData gdata = bf.Deserialize(file) as GameData;
        file.Close();
        return gdata;
    }
}

[System.Serializable]
public class GameData
{
    public int money;
    public bool[] answers;
    public int progressPercent;
    public int packIcon;

    public GameData()
    {
        money = 500;
        progressPercent = 0;
        packIcon = 1;
    }
    public GameData(int money, bool[] answers, int progressPercent, int packIcon)
    {
        this.money = money;
        this.answers = answers;
        this.progressPercent = progressPercent;
        this.packIcon = packIcon;
    }
}