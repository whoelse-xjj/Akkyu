using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateCharactorScript : MonoBehaviour
{
    public Transform Door;
    public GameObject OldCharacter;
    public RuntimeAnimatorController AnimationController;

    [Header("Character Parameter")]
    public List<Transform> TargetTransformList;
    //public MessageDialog dialog;

    public void CreateNewCharactor()
    {

        //CharacterScript oldCharactorScript = OldCharacter.GetComponent<CharacterScript>();

        GameObject newCharactor = Instantiate(OldCharacter);
        Animator animator = newCharactor.GetComponent<Animator>();
        CharacterScript script = newCharactor.GetComponent<CharacterScript>();
        animator.runtimeAnimatorController = AnimationController;
        //移动终点
        script.TargetObjectList = TargetTransformList;
        script.Door = Door;
        //出生点
        newCharactor.transform.position = Door.position;

        //newCharactor.transform.position += Random.insideUnitSphere * 0.1F;

        //CharacterScript script = Charactor.GetComponent<CharacterScript>();
        //script.dialog = dialog;

    }
}
