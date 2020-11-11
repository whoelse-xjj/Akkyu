using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Field", menuName = "Field")]
public class Inventory : ScriptableObject
{
    public long Money;

    public long Heart;

    public void Awake()
    {
        Debug.Log( DateTime.Now.ToString() + " Inventory Initial");
    }
}
