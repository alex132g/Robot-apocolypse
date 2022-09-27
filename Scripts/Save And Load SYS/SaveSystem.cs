using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static void SaveData(Movement player)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/saveFiles.bin";
        FileStream stream = new FileStream(path, FileMode.Create);

        Data data = new Data(player);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static Data LoadData()
    {
        string path = Application.persistentDataPath + "/saveFiles.bin";
        if(File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            Data data = formatter.Deserialize(stream) as Data;
            stream.Close();

            return data;
        }else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }
}
