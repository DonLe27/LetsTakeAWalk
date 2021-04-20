using UnityEngine;
using System.IO;
public class DataManager : MonoBehaviour
{
    public string file = "player.txt";
    public PlayerData playerData;

    public void Start()
    {
        Load();
    }
    public void Save()
    {
        string json = JsonUtility.ToJson(playerData);
        WriteToFile(file, json);
    }
    public void Load()
    {
        playerData = new PlayerData();
        string json = ReadFromFile(file);
        JsonUtility.FromJsonOverwrite(json, playerData);
    }
    private void WriteToFile(string fileName, string json)
    {
        string path = GetFilePath(fileName);
        FileStream fileStream = new FileStream(path, FileMode.Create);
        using (StreamWriter writer = new StreamWriter(fileStream))
        {
            writer.Write(json);
        }

    }

    private string ReadFromFile(string fileName)
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
    private string GetFilePath(string fileName)
    {
        return Application.persistentDataPath + "/" + fileName;
    }
}
