using System.Collections;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using UnityEngine;
using UnityEngine.UI;

public class WorldControllor : MonoBehaviour
{

    [Header("Base Function")]
    public List<GameObject> SortingObjects;
    public Transform BottomObject;

    [Header("Assistant")]
    public Inventory Medium;
    public long RunTime;

    [Header("Display Memeber")]
    public Text MoneyDisplay;
    public Text HeartDisplay;

    [Header("Message Field")]
    [TextArea]
    public string Message;
    public long CharactorAmount;

    public static int BottomOrder { private set; get; }

    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject obj in SortingObjects)
        {
            SpriteRenderer sr = obj.GetComponent<SpriteRenderer>();
            sr.sortingOrder = GetSortingOrder(obj.transform.position);
        }

        BottomOrder = GetSortingOrder(BottomObject.position);
    }

    // Update is called once per frame
    void Update()
    {
        Message = $"Create {MoneyScript.CreateAmount} Money\r\n{MoneyScript.LostAmount} Lost" ;
        CharactorAmount = CharacterScript.Amount;

        MoneyDisplay.text = (Medium.Money + MoneyScript.PickUpAmount).ToString();
        RunTime += (long)(Time.deltaTime * 1000);

    }

    public static int GetSortingOrder(Vector2 position)
    {
        return (int)(position.y * -100F);
    }

}
