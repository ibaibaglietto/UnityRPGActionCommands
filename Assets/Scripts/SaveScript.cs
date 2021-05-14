using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveScript
{
    //Function to save the game
    public static void SaveGame(CurrentDataScript current)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "game.ola";
        Debug.Log(path);
        FileStream stream = new FileStream(path, FileMode.Create);
        GameDataScript data = new GameDataScript(current);
        formatter.Serialize(stream, data);
        stream.Close();
    }

    //Function to load the game
    public static GameDataScript LoadGame()
    {
        string path = Application.persistentDataPath + "game.ola";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            GameDataScript data = formatter.Deserialize(stream) as GameDataScript;
            stream.Close();
            return data;
        }
        else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }

}
