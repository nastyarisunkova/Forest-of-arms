using UnityEngine;
using System.IO;
public static class Json
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
}
