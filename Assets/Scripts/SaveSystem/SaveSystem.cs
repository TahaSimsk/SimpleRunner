using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static void Save(GameData data)
    {
        string path = GetPath();
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream fileStream = new FileStream(path, FileMode.Create);
        formatter.Serialize(fileStream, data);
        fileStream.Close();
    }


    public static GameData Load(GameData defaultGameData)
    {
        if (!File.Exists(GetPath()))
        {
            Save(defaultGameData);
            return defaultGameData;
        }

        BinaryFormatter formatter = new BinaryFormatter();
        FileStream fileStream = new FileStream(GetPath(), FileMode.Open);
        GameData data = formatter.Deserialize(fileStream) as GameData;
        fileStream.Close();

        return data;
    }


    private static string GetPath()
    {
        return Application.persistentDataPath + "/data.qnd";
    }
}
