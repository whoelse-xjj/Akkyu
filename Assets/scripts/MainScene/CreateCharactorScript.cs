using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateCharactorScript : MonoBehaviour
{
    public Transform Door;
    public GameObject OldCharacter;

    [Header("Character Parameter")]
    public List<Transform> TargetTransformList;

    public void CreateNewCharactor()
    {
        GameObject newCharactor = Instantiate(OldCharacter);
        CharacterScript script = newCharactor.GetComponent<CharacterScript>();
        //移动终点
        script.TargetObjectList = TargetTransformList;
        script.Door = Door;
        //出生点
        newCharactor.transform.position = Door.position;

    }
}
