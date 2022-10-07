using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class FileDataHandler
{
    private string dataDirPath = "";
    private string dataFileName = "";

    private bool useEncryption = false;
    private readonly string encryptionCodeWord = "systemserialized";

    public FileDataHandler(string dataDirPath, string dataFileName, bool useEncryption)
    {
        this.dataDirPath = dataDirPath;
        this.dataFileName = dataFileName;
        this.useEncryption = useEncryption;
    }

    public GameData Load()
    {
        // sets so you can use the save system for every os
        string fullPath = Path.Combine(dataDirPath, dataFileName);
        GameData loadedData = null;
        if(File.Exists(fullPath))
        {
           try
           {
              // Load the serialized data form the file
              string dataToLoad = "";

              using(FileStream stream = new FileStream(fullPath, FileMode.Open))
              {
                 using (StreamReader reader = new StreamReader(stream))
                 {
                    dataToLoad = reader.ReadToEnd();
                 }
              }

              // optionally decrypt the data
               if(useEncryption)
               {
                    dataToLoad = EncryptDecrypt(dataToLoad);
               }

              // deserialize the data from Json back into the C# object
              loadedData = JsonUtility.FromJson<GameData>(dataToLoad);
           }
           catch (Exception e)
           {
              Debug.LogError("An error occured when trying to load data from file: " + fullPath + "\n" + e);
           }
        }
        return loadedData;
    }

    public void Save(GameData data)
    {
        // sets so you can use the save system for every os
        string fullPath = Path.Combine(dataDirPath, dataFileName);
        try
        {
            // create the directory the file will be written to if it donsn't already exist
            Directory.CreateDirectory(Path.GetDirectoryName(fullPath));

            // serialize the C# game data object into Json
            string dataToStore = JsonUtility.ToJson(data, true);

            // optionally encrypt the data
            if(useEncryption)
            {
                dataToStore = EncryptDecrypt(dataToStore);
            }

            // write the serialized data to the file
            using(FileStream stream = new FileStream(fullPath, FileMode.Create))
            {
                using(StreamWriter writer = new StreamWriter(stream))
                {
                    writer.Write(dataToStore);
                }
            }
        }
        catch (Exception e)
        {
            Debug.LogError("An Error occured when trying to save data to file: " + fullPath + "\n" + e);
        }
    }
    
    // this is used to encrypt or decrypt the data form the save file
    private string EncryptDecrypt(string data)
    {
        string modifiedData = "";
        for(int i = 0; i < data.Length; i++)
        {
            modifiedData += (char) (data[i] ^ encryptionCodeWord[i % encryptionCodeWord.Length]);
        }
        return modifiedData;
    }
}
