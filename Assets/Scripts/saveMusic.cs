using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class saveMusic
{
    public static void SaveMusic(musicManager mm)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.music";
        FileStream stream = new FileStream(path, FileMode.Create);

        musicData data = new musicData(mm);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static musicData loadMusic()
    {
        string path = Application.persistentDataPath + "/player.music";

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            musicData data = formatter.Deserialize(stream) as musicData;
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
