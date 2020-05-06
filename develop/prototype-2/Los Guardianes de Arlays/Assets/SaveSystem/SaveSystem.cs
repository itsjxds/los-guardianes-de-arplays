using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem 
{
    private static string pathGameData = Application.persistentDataPath + "/game1.data";

    //saving the game
    public static void saveGameData()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(pathGameData, FileMode.Create);
        GameData data = new GameData();
        formatter.Serialize(stream, data);
        stream.Close();
    }
    
    
    public static void loadGameData()
    {
        if (File.Exists(pathGameData))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(pathGameData, FileMode.Open);
            GameData data = (GameData)formatter.Deserialize(stream);
            stream.Close();

            PlayerPrefs.money = data.money;
            PlayerPrefs.activeCharacter = data.currentCharacter;
            PlayerPrefs.unlockedCharacters = data.unlockedCharacters;
            MenuManager.levelAt = data.levelAt;
            MenuManager.audioVolume = data.volume;
        }
    }


    public static void deleteGameData()
    {
        if (File.Exists(pathGameData))
        {
            File.Delete(pathGameData);
        }
    }

    public static bool existsGameData()
    {
        return File.Exists(pathGameData);
    }
}
