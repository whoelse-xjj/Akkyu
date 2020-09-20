using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.UI;

public class WarehouseScript : MonoBehaviour
{
    [Header(header:"Message Box")]
    public GameObject MessageBox;
    public Text MessageBox_Name;
    public Image MessageBox_Display;
    public Text MessageBox_Information;

    [Header(header: "Food Illustrate")]
    public Sprite[] FoodImageList;
    public Button FoodIllustrate;

    // Start is called before the first frame update
    void Start()
    {
        //生成图鉴
        foreach (Sprite image in FoodImageList)
        {
			Button button = Instantiate<Button>(FoodIllustrate, transform);
            //设置贴图信息
            button.GetComponentsInChildren<Image>()[1].sprite = image;
            button.GetComponentsInChildren<Text>()[0].text = image.name;
            //增加按钮事件
            button.onClick.AddListener(() =>
            {
                MessageBox.SetActive(true);
                MessageBox_Display.sprite = image;
                MessageBox_Name.text = image.name;
            });
        }

        //更改容器长度
        GridLayoutGroup group = GetComponent<GridLayoutGroup>();
        RectTransform trans = GetComponent<RectTransform>();
        float rows = math.ceil(transform.childCount / 4F);
        float height = group.padding.top + (group.cellSize.y + group.spacing.y) * rows;

        trans.sizeDelta = new Vector2(trans.sizeDelta.x, height);
        trans = transform.parent.GetComponent<RectTransform>();
        trans.sizeDelta = new Vector2(trans.sizeDelta.x, height);
        //transform.position = new Vector3(transform.position.x, -height / 2F, transform.position.z);
    }
}