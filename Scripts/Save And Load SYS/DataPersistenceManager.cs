using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DataPersistenceManager : MonoBehaviour
{

    [Header("File Storage Config")]
    [SerializeField] private string fileName;
    [SerializeField] private bool useEncryption;

    private GameData gameData;

    private List<IDataPersistence> dataPersistenceObjects;
    private FileDataHandler dataHandler;

    public static DataPersistenceManager instance { get; private set; }

    private void Awake()
    {
        // checks if the game all ready has an Data Persistence Manager

        if(instance != null)
        {
            Debug.LogError("Found ore than one Data Persistence Manager in the scene");
        }
        instance = this;
    }

    private void Start()
    {
        this.dataHandler = new FileDataHandler(Application.persistentDataPath, fileName, useEncryption);
        this.dataPersistenceObjects = FindAllDataPersistenceObjects();
        LoadGame();
    }

    public void NewGame()
    {
        this.gameData = new GameData();
    }

    public void LoadGame()
    {
       // Load any saved data form a file using the data handler
       this.gameData = dataHandler.Load();

       // if no data can be loaded, initialize to a new game

       if(this.gameData == null)
       {
          Debug.Log("No data was found. Initializing data to defaults.");
          NewGame();
       }

       // push the loaded data in to all the scripts that need it
       
       foreach(IDataPersistence dataPersistenceObj in dataPersistenceObjects)
       {
          dataPersistenceObj.LoadData(gameData);
       }
        
        Debug.Log("Loading current data" + gameData);
    }

    public void SaveGame()
    {
       // pass the data to other scripts so they can update it
       
       foreach(IDataPersistence dataPersistenceObj in dataPersistenceObjects)
       {
          dataPersistenceObj.SaveData(gameData);
       }

       // save that data to a file using the data handler
       dataHandler.Save(gameData);

        Debug.Log("Saving current data" + gameData);
    }

    
    private void OnApplicationQuit()
    {
        // save all data when the player quits

        SaveGame();
    }

    private List<IDataPersistence> FindAllDataPersistenceObjects()
    {
        IEnumerable<IDataPersistence> dataPersistenceObjects = FindObjectsOfType<MonoBehaviour>().OfType<IDataPersistence>();

        return new List<IDataPersistence>(dataPersistenceObjects);
    }
}
