﻿using Assets.Scenes.script.Project;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class CharacterScript : MonoBehaviour
{
    #region Variable
    //public Inventory inventory;

    private Animator ar;
    private Rigidbody2D rb;
    private SpriteRenderer sr;

    private float MoveClock;
    public List<Transform> TargetObjectList;
    public Transform Door;
    private Transform TargetTransform;

    private int Favorability = 20;
    public GameObject Money;

    private const float MoveTime = 3F;
    private const float DistanceDelta = 0.02F;
    //private float CreatMoneyClock = 3F;

    [Header("Debug")]
    [TextArea]
    public string MessageBox = string.Empty;
    private long Count1 = 0L;
    private long Count2 = 0L;
    private static long Count0 = 0L;

    #endregion

    // Start is called before the first frame update
    void Start()    
    {
        //随机移动
        ar = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();

        TargetTransform = TargetObjectList[Random.Range(0, TargetObjectList.Count)];
    }

    // Update is called once per frame
    void Update()
    {
        //产生钱币
        //if (CreatMoneyClock > 0F)
        //{
        //    CreatMoneyClock -= Time.deltaTime;
        //}
        //else
        //{
        //    inventory.Heart += 1;
        //    inventory.Money += 10;
        //    CreatMoneyClock = 3F;
        //}

        //随机移动
        //移动中
        if (ar.GetBool("Move"))
        {
            transform.position = Vector2.MoveTowards(transform.position, TargetTransform.position, DistanceDelta);
        }
        //站立中
        else if (MoveClock > 0F)
        {
            MoveClock -= Time.deltaTime;
            MessageBox = $" Loop {Count1++} creat {Count2} sum {Count0}";
            if (Random.Range(0F, 100F) < 0.5F)
            {
                GameObject money = Instantiate(Money);
                money.transform.position = transform.position;
                Count2++;
                Count0++;
            }
        }
        //选择离开
        else if (Favorability > 0)
        {
            Transform newObject  = TargetObjectList[Random.Range(0, TargetObjectList.Count)];
            if (newObject != TargetTransform)
            {
                ar.SetBool("Move", true);
                TargetTransform = newObject;
            }
            else
            {
                MoveClock = MoveTime;
            }

            //好感度降低
            Favorability--;

        }
        //选择出门
        else
        {
            ar.SetBool("Move", true);
            TargetTransform = Door;
        }

        //遮挡
        sr.sortingOrder = WorldControllor.GetSortingOrder(transform.position);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //移动中 -> 站立
        if (TargetTransform == collision.transform)
        {
            if (TargetTransform == Door)
            {
                Destroy(transform.gameObject);
            }
            else
            {
                ar.SetBool("Move", false);
                MoveClock = MoveTime;
            }
        }
    }

    //点击移动
    private void OnMouseUpAsButton()
    {
        //if (MessageBox is null) return;

        //提示信息
        //dialog.MessageBox.SetActive(true);
        //dialog.MessageDisplay.sprite = GetComponent<SpriteRenderer>().sprite;
        //dialog.MessageName.text = name;
        //dialog.MessageConfrim.onClick.RemoveAllListeners();

        //ar.SetBool("Move", true);
        //MoveClock = MoveTime;

        //Vector2 dr = Random.insideUnitCircle;
        //transform.localScale = new Vector3(dr.x < 0 ? 1 : -1, 1, 1);
        //rb.velocity = dr.normalized * Consts.MoveSpeed;
    }
}
