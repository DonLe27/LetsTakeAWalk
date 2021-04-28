using UnityEngine;
using System.IO;
public static class DataManager
{
    private static string file = "player.txt";

    public static void Start()
    {
        Load();
    }
    public static void Save(PlayerData playerData)
    {
        string json = JsonUtility.ToJson(playerData);
        WriteToFile(file, json);
    }
    public static PlayerData Load()
    {
        PlayerData playerData = new PlayerData();
        string json = ReadFromFile(file);
        JsonUtility.FromJsonOverwrite(json, playerData);
        return playerData;
    }
    private static void WriteToFile(string fileName, string json)
    {
        string path = GetFilePath(fileName);
        FileStream fileStream = new FileStream(path, FileMode.Create);
        using (StreamWriter writer = new StreamWriter(fileStream))
        {
            writer.Write(json);
        }

    }

    private static string ReadFromFile(string fileName)
    {
        string path = GetFilePath(fileName);
        if (File.Exists(path))
        {
            using (StreamReader reader = new StreamReader(path))
            {
                string json = reader.ReadToEnd();
                return json;
            }
        }
        else
            return "";
    }
    private static string GetFilePath(string fileName)
    {
        return Application.persistentDataPath + "/" + fileName;
    }
}
