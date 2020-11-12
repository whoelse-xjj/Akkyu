using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using UnityEngine;
using UnityEngine.UI;

public class WorldControllor : MonoBehaviour
{

    [Header("Base Function")]
    public List<GameObject> SortingObjects;
    public Transform BottomObject;

    public List<Sprite> AllFurnitureForm;
    public List<GameObject> AllFurniture;

    [Header("Assistant")]
    public DataRecorder Record;
    public long RunTime;

    [Header("Display Memeber")]
    public Text MoneyDisplay;
    public Text HeartDisplay;

    [Header("Message Field")]
    [TextArea]
    public string Message;
    public long CharactorAmount;

    public static int BottomSorting { private set; get; }

    // Start is called before the first frame update
    void Start()
    {
        //Game object vision sorting
        foreach (GameObject obj in SortingObjects)
        {
            SpriteRenderer sr = obj.GetComponent<SpriteRenderer>();
            sr.sortingOrder = GetSortingOrder(obj.transform.position);
        }
        BottomSorting = GetSortingOrder(BottomObject.position);

        //Game Data Record Load
        DataRecorder.DataLoad(Record);

        if (AllFurniture.Count > Record.FurnitureForm.Count)
        {
            Record.FurnitureForm.AddRange(new int[AllFurniture.Count - Record.FurnitureForm.Count]);
        }

        for (int i = 0; i < AllFurniture.Count; i++)
        {
            SpriteRenderer sr = AllFurniture[i].GetComponent<SpriteRenderer>();
            if (Record.FurnitureForm[i] < 0)
            {
                Record.FurnitureForm[i] = 0;
            }
            else if (Record.FurnitureForm[i] >= AllFurnitureForm.Count)
            {
                Record.FurnitureForm[i] = AllFurnitureForm.Count - 1;
            }
            sr.sprite = AllFurnitureForm[Record.FurnitureForm[i]];
        }

    }

    // Update is called once per frame
    void Update()
    {
        //show message
        Message = $"Create {MoneyScript.CreateAmount} Money\r\n{MoneyScript.LostAmount} Lost" ;
        CharactorAmount = CharacterScript.Amount;

        MoneyDisplay.text = (Record.Money + MoneyScript.PickUpAmount).ToString();
        HeartDisplay.text = Record.Heart.ToString();
        RunTime += (long)(Time.deltaTime * 1000);

    }

    /// <summary>
    /// 游戏数据保存
    /// </summary>
    private void OnDestroy()
    {
        Record.Money += MoneyScript.PickUpAmount;
        DataRecorder.DataSave(Record);
    }

    /// <summary>
    /// 获取sprite排列顺序
    /// </summary>
    /// <param name="position"></param>
    /// <returns></returns>
    public static int GetSortingOrder(Vector2 position)
    {
        return (int)(position.y * -100F);
    }

}
