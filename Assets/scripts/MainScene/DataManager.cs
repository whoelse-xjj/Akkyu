using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Net;

public class DataManager : MonoBehaviour
{
    public DataRecorder Inventory;

    private void Start() =>
        DataLoad();

    private void OnDestroy()
    {
        Inventory.Money += MoneyScript.PickUpAmount;
        DataSave();
    }

    private void DataLoad()
    {
        string path = Application.persistentDataPath + "/GameData/Inventory.txt";
        BinaryFormatter formatter = new BinaryFormatter();
        if (File.Exists(path))
        {
            FileStream stream = File.Open(path, FileMode.Open);
            string json = formatter.Deserialize(stream).ToString();
            JsonUtility.FromJsonOverwrite(json, Inventory);
            stream.Close();
        }
    }

    private void DataSave()
    {
        string path = Application.persistentDataPath + "/GameData";

        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }

        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = File.Create(path + "/Inventory.txt");
        string json = JsonUtility.ToJson(Inventory);
        //string json = formatter.Deserialize(stream).ToString();

        formatter.Serialize(stream, json);
        stream.Close();
    }
}
