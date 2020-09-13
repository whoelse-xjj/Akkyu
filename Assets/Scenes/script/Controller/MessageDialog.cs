using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//[CreateAssetMenu(fileName = "New Field", menuName = "Field")]
public class MessageDialog// : ScriptableObject
{
    //[Header("Description")]
    public GameObject MessageBox { get; set; }
    public Text MessageName { get; set; }
    public Image MessageDisplay { get; set; }
    public Text MessageDescription { get; set; }

    private Button confrim;
    public Button MessageConfrim
    {
        get { return confrim; }
        set 
        {
            value.onClick.RemoveAllListeners();
            confrim = value; 
        }
    }



}
