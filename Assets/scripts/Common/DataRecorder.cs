using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

[CreateAssetMenu(fileName = "New Data Record", menuName = "Data Record")]
public class DataRecorder : ScriptableObject
{
    public long Money;

    public long Heart;

    public List<int> FurnitureForm;

    /// <summary>
    /// Game Data Record Load
    /// </summary>
    /// <param name="recorder">Initial Data Recorder</param>
    /// <returns>Is First Load</returns>
    public static bool DataLoad(DataRecorder recorder)
    {
        string path = Application.persistentDataPath + "/GameData/Inventory.txt";
        BinaryFormatter formatter = new BinaryFormatter();
        if (File.Exists(path))
        {
            FileStream stream = File.Open(path, FileMode.Open);
            string json = formatter.Deserialize(stream).ToString();
            JsonUtility.FromJsonOverwrite(json, recorder);
            stream.Close();
            return false;
        }
        else
        {
            return true;
        }
    }

    public static void DataSave(DataRecorder recorder)
    {
        string path = Application.persistentDataPath + "/GameData";

        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }

        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = File.Create(path + "/Inventory.txt");
        string json = JsonUtility.ToJson(recorder);
        //string json = formatter.Deserialize(stream).ToString();

        formatter.Serialize(stream, json);
        stream.Close();
    }
}
