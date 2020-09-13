﻿using System.Collections;
using Unity.Mathematics;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System;

public class WorldEvent : MonoBehaviour
{
    [Header("Object Illustration")]
    public GameObject InstalParent;
    public GameObject ObjectOriginal;

    [Header("Food Illustration")]
    public Button IllustrationOriginal;
    public Sprite[] IllustrationImageList;

    [Header("Description")]
    public GameObject MessageBox;
    public Text MessageName;
    public Image MessageDisplay;
    public Text MessageDescription;
    public Button MessageConfrim;

    [Header("Debug")]
    public float x;
    public float y;

    public void GardClick(GameObject view)
    {
        foreach (Sprite food in IllustrationImageList)
        {
            if (Array.Exists(view.GetComponentsInChildren<Text>(), textBox => textBox.text == food.name))
                continue;
            Button button = Instantiate(IllustrationOriginal, view.transform);
            //设置贴图信息
            button.GetComponentsInChildren<Image>()[1].sprite = food;
            button.GetComponentsInChildren<Text>()[0].text = food.name;
            //增加按钮事件
            button.onClick.AddListener(() =>
            {
                MessageBox.SetActive(true);
                MessageName.text = food.name;
                MessageDisplay.sprite = food;
                MessageDescription.text = food.name;
                MessageConfrim.onClick.RemoveAllListeners();
                MessageConfrim.onClick.AddListener(() => AddFoodOnTable(food));
            });
        }

        //更改容器长度
        GridLayoutGroup group = view.GetComponent<GridLayoutGroup>();
        RectTransform trans = view.GetComponent<RectTransform>();
        float rows = math.ceil(view.transform.childCount / 4F);
        float height = group.padding.top + (group.cellSize.y + group.spacing.y) * rows;

        trans.sizeDelta = new Vector2(trans.sizeDelta.x, height);
        trans = view.transform.parent.GetComponent<RectTransform>();
        trans.sizeDelta = new Vector2(trans.sizeDelta.x, height);
        //SpriteRenderer renderer = new SpriteRenderer { sprite = sprite };
        //GameObject item = new GameObject(sprite.name, renderer.GetType());
        //Instantiate(item, transform);
    }

    public void AddFoodOnTable(Sprite sprite)
    {
        GameObject[] foods = GameObject.FindGameObjectsWithTag("Food");

        if (foods.Length > 6)
        {
            return;
        }

        GameObject food = Instantiate(ObjectOriginal, InstalParent.transform);
        SpriteRenderer renderer = food.GetComponent<SpriteRenderer>();
        renderer.sprite = sprite;

        float R = 0F;
        switch (foods.Length)
        {
            case 0:
                return;
            case 1:
                R = 0.4F;
                break;
            case 2:
                R = 0.55F;
                break;
            case 3:
                R = 0.65F;
                break;
            case 4:
                R = 0.72F;
                break;
            case 5:
                R = 0.8F;
                break;
            case 6:
                return;
            default:
                break;
        }
        food.transform.localPosition = new Vector3(R, 0F);
        float depart = math.PI * 2F / (foods.Length + 1F);
        for (int i = 0; i < foods.Length; i++)
        {
            foods[i].transform.localPosition = new Vector3(R * math.cos(depart * (i + 1)), R * math.sin(depart * (i + 1)));
        }

    }

    public void BuildingInstiant(Button sender)
    {
        Vector3 position = Camera.main.ScreenToWorldPoint(sender.transform.position);
        GameObject build = Instantiate(ObjectOriginal, new Vector3(position.x, position.y, -0.1F), InstalParent.transform.rotation, InstalParent.transform);
    }
}
