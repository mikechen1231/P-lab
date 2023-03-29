using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Datamannager : MonoBehaviour
{
    public static Datamannager manager;
    [Header("Storage Confg")]
    [SerializeField] private string fileName;
    [SerializeField] private bool useEncryption;

    private FileHanadler dataHandler;
    private GameData gameData;
    private List<IDataPersistance> dataObjectes;

    private void Awake()
    {
        if (manager == null)
        {
            manager = this;
        }
        else
        {
            Debug.Log("more then one in the scene");
        }
    
        this.dataHandler = new FileHanadler(Application.persistentDataPath,fileName,useEncryption);
        this.dataObjectes = FindAllData();
        LoadGame();
    }
    public void NewGame()
    {
        this.gameData = new GameData();
    }
    public void LoadGame()
    {
        this.gameData=dataHandler.Load();
        if(this.gameData==null)
        {
            Debug.Log("error no data found, creating new data");
            NewGame();
        }
        foreach(IDataPersistance dataObjectes in dataObjectes)
        {
            dataObjectes.LoadDaat(gameData);
        }
    }
    public void SaveGame()
    {
        foreach(IDataPersistance dataObjectes in dataObjectes   )
        {
            dataObjectes.SaveData(ref gameData);
        }
        dataHandler.Save(gameData);
    }
    private void OnApplictationExit(){
        SaveGame();
    }
    private List<IDataPersistance>FindAllData()
    {
        IEnumerable<IDataPersistance>dataObjectes=FindObjectsOfType<MonoBehaviour>().OfType<IDataPersistance>();

        return new List<IDataPersistance>(dataObjectes);
    }

}
