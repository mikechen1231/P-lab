using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;


public class FileHanadler 
{
    private string dataDirPath="";
    private string DataaFIleName="";
    private bool useEncryption = false;
    private readonly string encryptionCode = "word";

    public FileHanadler(string dataDirPath,string DataaFIleName,bool useEncryption)
    {
        this.dataDirPath=dataDirPath;
        this.DataaFIleName = DataaFIleName;
        this.useEncryption=useEncryption;
    }

    public GameData Load()
    {
        string fullPath=Path.Combine(dataDirPath,DataaFIleName);
        GameData loadedData = null;
    

    if(File.Exists(fullPath))
    {
        try
        {
            string dataToLoad="";
            using(FileStream stream = new FileStream(fullPath,FileMode.Open))
            {
                using(StreamReader reader = new StreamReader(stream))
                {
                    dataToLoad = reader.ReadToEnd();
                }
                
            }
            if(useEncryption)
            {
                dataToLoad = EncryptDecrypt(dataToLoad);

            }
            loadedData = JsonUtility.FromJson<GameData>(dataToLoad);

        }
        catch(Exception e)
        {
            Debug.Log("ERROR");
        }
    }
    return loadedData;
    }
    public void Save(GameData data)
    {
       string fullPath = Path.Combine(dataDirPath,DataaFIleName);
       try{
        Directory.CreateDirectory(Path.GetDirectoryName(fullPath));
        string dataToStore=JsonUtility.ToJson(data,true);

        if(useEncryption)
        {
            dataToStore=EncryptDecrypt(dataToStore);
        }
        using(FileStream stream = new FileStream(fullPath,FileMode.Create))
        {
            using (StreamWriter writer= new StreamWriter(stream))
            {
                writer.Write(dataToStore);
            }
        }
       }
    catch(Exception e)
    {
        Debug.Log("Error");

    }

    }

    private string EncryptDecrypt(string data)
    {
        string modifiedData ="";
        for(int i=0;i<data.Length;i++)
        {
            
                modifiedData+=(char)(data[i]^encryptionCode[i%encryptionCode.Length]);
        }
            
            return modifiedData;
        
    }


}
