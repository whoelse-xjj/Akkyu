using Assets.Scenes.script.Project;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterScript : MonoBehaviour
{
    public Inventory inventory;

    private Animator ar;
    private Rigidbody2D rb;

    //public float MoveTime;
    private float MoveClock;
    private float CreatMoneyClock = 3F;

    public MessageDialog dialog;

    // Start is called before the first frame update
    void Start()
    {
        ar = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (CreatMoneyClock > 0F)
        {
            CreatMoneyClock -= Time.deltaTime;
        }
        else
        {
            inventory.Heart += 1;
            inventory.Money += 10;
            CreatMoneyClock = 3F;
        }

        //if (MoveClock > 0F) 
        //    MoveClock -= Time.deltaTime;
        //else
        //{
        //    ar.SetBool("Move", false);
        //    rb.velocity = Vector2.zero;
        //}
    }

    private void OnMouseUpAsButton()
    {
        //if (MessageBox is null) return;
        dialog.MessageBox.SetActive(true);
        dialog.MessageDisplay.sprite = GetComponent<SpriteRenderer>().sprite;
        dialog.MessageName.text = name;
        dialog.MessageConfrim.onClick.RemoveAllListeners();
        //ar.SetBool("Move", true);
        //MoveClock = MoveTime;

        //Vector2 dr = Random.insideUnitCircle;
        //transform.localScale = new Vector3(dr.x < 0 ? 1 : -1, 1, 1);
        //rb.velocity = dr.normalized * Consts.MoveSpeed;
    }
}
