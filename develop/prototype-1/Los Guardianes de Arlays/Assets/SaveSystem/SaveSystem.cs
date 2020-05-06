using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem 
{
    private static string pathPlayer = Application.persistentDataPath + "/player.data";


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


}
