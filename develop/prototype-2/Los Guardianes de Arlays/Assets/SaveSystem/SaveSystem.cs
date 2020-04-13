using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem 
{
    private static string pathPlayer = Application.persistentDataPath + "/player.data";
    private static string pathGameData = Application.persistentDataPath + "/game1.data";


    public static void savePlayer(PlayerController player)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        
        FileStream stream = new FileStream(pathPlayer, FileMode.Create);

        PlayerData data = new PlayerData(player);

        formatter.Serialize(stream, data);
        stream.Close();
    }


    public static PlayerData loadPlayer ()
    {
        if(File.Exists(pathPlayer))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(pathPlayer, FileMode.Open);

            PlayerData data = (PlayerData)formatter.Deserialize(stream);
            
            stream.Close();

            return data;

        } else
        {
            Debug.LogError("save file not found in "+pathPlayer);
            return null;
        }
    }


    public static void deletePlayerSave ()
    {
        if(File.Exists(pathPlayer))
        {
            File.Delete(pathPlayer);
        }
    }




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

            PlayerPrefs.activeCharacter = data.currentCharacter;
            MenuManager.levelAt = data.levelAt;
            MenuManager.audioVolume = data.volume;
        }
        else
        {
            Debug.LogError("save file not found in " + pathPlayer);
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
