using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class DataManager : MonoBehaviour
{
    public Inventory Inventory;

    private void Start() =>
        DataSave();

    private void OnDestroy() =>
        DataLoad();

    private void DataSave()
    {
        //C:/ Users / xjj12 / AppData / LocalLow / DefaultCompany / Fairy Ranch of Akyuu
        //           var path1 = Application.persistentDataPath;
        //C:/ Users / xjj12 / Desktop / Unity2007 / Akyuu / Assets
        //    var path2 = Application.dataPath;
        //C: \Users\xjj12\Desktop\Unity2007\Akyuu\
        //    var path3 = new FileInfo("./").FullName;
        //    Debug.Log($"{path1}, {path2}, {path3}");

    }

    private void DataLoad()
    {
        string path = Application.persistentDataPath + "/GameData";

        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }

        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = File.Create(path + "/Inventory.txt");
        string json = JsonUtility.ToJson(Inventory);

        formatter.Serialize(stream, json);
    }
}
