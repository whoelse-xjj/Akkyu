using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateCharactorScript : MonoBehaviour
{
    public GameObject CharactorOriginal;
    public RuntimeAnimatorController AnimationController;

    public MessageDialog dialog;

    public void CreateNewCharactor(GameObject parent)
    {
        GameObject Charactor = Instantiate(CharactorOriginal, parent.transform);
        Charactor.transform.position += Random.insideUnitSphere * 0.1F;

        CharacterScript script = Charactor.GetComponent<CharacterScript>();
        script.dialog = dialog;

        Animator ar = Charactor.GetComponent<Animator>();
        ar.runtimeAnimatorController = AnimationController;
    }
}
