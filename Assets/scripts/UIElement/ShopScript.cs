using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopScript : MonoBehaviour
{
    public List<Text> Commodity;

    /// <summary>
    /// 杂货
    /// </summary>
    public void Groceries()
    {
        string[] names = { "皮球", "风筝", "冻青蛙", "废弃灯管", "象棋", "书", "自行车", "计算机" };
        for (int i = 0; i < Commodity.Count; i++)
        {
            Commodity[i].text = names[i];
        }
    }

    /// <summary>
    /// 家具
    /// </summary>
    public void Furniture()
    {
        string[] names = { "石桌", "石椅", "千秋", "稻草人", "简约信箱", "藤桌", "藤椅", "石子路" };
        for (int i = 0; i < Commodity.Count; i++)
        {
            Commodity[i].text = names[i];
        }
    }

    /// <summary>
    /// 装饰
    /// </summary>
    public void Decorate()
    {
        string[] names = { "万圣节挂饰", "樱花挂饰", "七夕挂饰", "绘马", "千纸鹤", "霓虹灯", "圣诞节装饰", "魔法帽" };
        for (int i = 0; i < Commodity.Count; i++) 
        {
            Commodity[i].text = names[i];
        }
    }

    /// <summary>
    /// 喂食
    /// </summary>
    public void Feed()
    {
        string[] names = { "长条面包", "红豆羊羹", "仙贝", "绿豆羊羹", "弹珠汽水", "生啤酒", "三文鱼寿司", "豆腐手卷" };
        for (int i = 0; i < Commodity.Count; i++)
        {
            Commodity[i].text = names[i];
        }
    }

    /// <summary>
    /// 种子
    /// </summary>
    public void Seed()
    {
        string[] names = { "菊花种子", "向日葵种子", "向日葵种子", "菊花种子", "菊花种子", "向日葵种子", "向日葵种子", "菊花种子" };
        for (int i = 0; i < Commodity.Count; i++)
        {
            Commodity[i].text = names[i];
        }
    }

    /// <summary>
    /// 鱼饵
    /// </summary>
    public void Bait()
    {
        string[] names = { "鱼饵", "鱼饵", "鱼饵", "鱼饵", "鱼饵", "鱼饵", "鱼饵", "鱼饵" };
        for (int i = 0; i < Commodity.Count; i++)
        {
            Commodity[i].text = names[i];
        }
    }
}
