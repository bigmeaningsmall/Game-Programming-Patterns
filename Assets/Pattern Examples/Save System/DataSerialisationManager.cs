using System.IO; // For file operations
using UnityEngine;

public class DataSerialisationManager : MonoBehaviour
{
    [Header("File Settings")]
    public string fileName = "saveData.json";

    [Header("Data To Save")]
    public DataObject currentData = new DataObject();
    

    // this filepath may be hidden on a machine under : C Drive / Users / Name / appData / LocalLow (Persistant data  is a standard save path on any OS)
    private string FilePath => Path.Combine(Application.persistentDataPath, fileName);
    
    // use this one if you want to save to your D drive and not the hidden persistent data path
    //private string FilePath => Path.Combine("D:\\SaveLog", fileName);


    public void Save()
    {
        string json = JsonUtility.ToJson(currentData, true);
        File.WriteAllText(FilePath, json);

        Debug.Log($"[Save] Data saved to: {FilePath}");
        Debug.Log(json);
    }

    public void Load()
    {
        if (!File.Exists(FilePath))
        {
            Debug.LogWarning("[Load] No save file found.");
            return;
        }

        string json = File.ReadAllText(FilePath);
        currentData = JsonUtility.FromJson<DataObject>(json);

        Debug.Log($"[Load] Data loaded from: {FilePath}");
        Debug.Log(json);
    }

    public void DeleteSave()
    {
        if (File.Exists(FilePath))
        {
            File.Delete(FilePath);
            Debug.Log($"[Delete] Save file deleted: {FilePath}");
        }
        else
        {
            Debug.LogWarning("[Delete] No save file to delete.");
        }
    }
}