using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveAndLoad
{
    public static void SavePlayer(PlayerHandler player)
    {
        BinaryFormatter binaryFormatter = new BinaryFormatter();

        string path = Application.persistentDataPath + "/player.data";

        FileStream fileStream = new FileStream(path, FileMode.Create);

        PlayerData playerData = new PlayerData(player);

        binaryFormatter.Serialize(fileStream, playerData);
        fileStream.Close();
    }

    public static PlayerData LoadPlayer()
    {
        string path = Application.persistentDataPath + "/player.data";

        if (File.Exists(path))
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            FileStream fileStream = new FileStream(path, FileMode.Open);

            PlayerData data = binaryFormatter.Deserialize(fileStream) as PlayerData;
            fileStream.Close();
            return data;
        }
        else
        {
            Debug.LogError("Fail to load data");
            return null;
        }
    }
}
