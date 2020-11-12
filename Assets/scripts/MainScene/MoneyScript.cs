using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

public class MoneyScript : MonoBehaviour
{

    private float stayTime = 30F;
    public static long CreateAmount = 0;
    public static long LostAmount = 0;
    public static long PickUpAmount = 0;

    // Start is called before the first frame update
    void Start()
    {
        CreateAmount++;
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        sr.sortingOrder = WorldControllor.BottomSorting;
    }

    // Update is called once per frame
    void Update()
    {
        if (stayTime > 0F)
        {
            stayTime -= Time.deltaTime;
        }
        else
        {
            LostAmount++;
            Destroy(transform.gameObject);
        } 
    }

    private void OnMouseDown()
    {
        PickUpAmount++;
        Destroy(transform.gameObject);
    }

    //private void OnMouseExit()
    //{
    //    if (Input.GetMouseButtonDown(0))
    //    {
    //        PickUpAmount++;
    //        Destroy(transform.gameObject);
    //    }
    //}
}
