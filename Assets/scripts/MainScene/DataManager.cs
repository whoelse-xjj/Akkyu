using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Net;

public class DataManager : MonoBehaviour
{
    public Inventory Inventory;

    private void Start() =>
        DataLoad();

    private void OnDestroy()
    {
        Inventory.Money += MoneyScript.PickUpAmount;
        DataSave();
    }

    private void DataLoad()
    {
        //C:/ Users / xjj12 / AppData / LocalLow / DefaultCompany / Fairy Ranch of Akyuu
        //           var path1 = Application.persistentDataPath;
        //C:/ Users / xjj12 / Desktop / Unity2007 / Akyuu / Assets
        //    var path2 = Application.dataPath;
        //C: \Users\xjj12\Desktop\Unity2007\Akyuu\
        //    var path3 = new FileInfo("./").FullName;
        //    Debug.Log($"{path1}, {path2}, {path3}");

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
