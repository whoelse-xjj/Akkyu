using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShoppingScript : MonoBehaviour
{
    public DataRecorder inventory;

    public MessageDialog dialog;

    public void Buy(Button sender)
    {
        dialog.MessageName.text = sender.GetComponentInChildren<Text>().text;
        dialog.MessageDescription.text = $"Would you want to buy {dialog.MessageName.text}";
        dialog.MessageConfrim.onClick.RemoveAllListeners();
        dialog.MessageConfrim.onClick.AddListener(
            () =>
            {
                //if (inventory.Money < 10) ERR
                inventory.Money -= 10;
            });
        dialog.MessageBox.SetActive(true);
    }
}
