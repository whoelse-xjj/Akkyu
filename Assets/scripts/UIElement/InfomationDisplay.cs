using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfomationDisplay : MonoBehaviour
{
    public DataRecorder inventory;

    public Text Heart;
    public Text Money;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Heart.text = inventory.Heart.ToString();
        Money.text = inventory.Money.ToString();
    }
}
