using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorldEvent2 : MonoBehaviour
{
    public GameObject CharactorOriginal;
    public RuntimeAnimatorController[] AnimationController;
    public int Index;

    [Header("Description")]
    public GameObject MessageBox;
    public Text MessageName;
    public Image MessageDisplay;
    public Text MessageDescription;
    public Button MessageConfrim;


    public void CreateNewCharactor(GameObject parent)
    {
        GameObject Charactor = Instantiate(CharactorOriginal, parent.transform);
        Charactor.transform.position += Random.insideUnitSphere * 0.1F;

        CharacterScript script = Charactor.GetComponent<CharacterScript>();
        script.MessageDialog = new MessageDialog
        {
            MessageBox = MessageBox,
            MessageName = MessageName,
            MessageDisplay = MessageDisplay,
            MessageDescription = MessageDescription,
            MessageConfrim = MessageConfrim
        };

        Animator ar = Charactor.GetComponent<Animator>();
        ar.runtimeAnimatorController = AnimationController[Index];
    }
}
