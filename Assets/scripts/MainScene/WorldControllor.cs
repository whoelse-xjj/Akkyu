using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldControllor : MonoBehaviour
{

    //public const float CharactorCreacteTime = 3F;
    //public float CharactorCreacteClock = CharactorCreacteTime;

    public List<GameObject> GameObjects;

    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject obj in GameObjects)
        {
            SpriteRenderer sr = obj.GetComponent<SpriteRenderer>();
            sr.sortingOrder = GetSortingOrder(obj.transform.position);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //if (CharactorCreacteClock > 0F)
        //{
        //    CharactorCreacteClock -= Time.deltaTime;
        //}
        //else if (Random.value < 0.1F)
        //{

        //}
    }

    public static int GetSortingOrder(Vector2 position)
    {
        return (int)(position.y * -100F);
    }

}
