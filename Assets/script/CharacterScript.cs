using Assets.Scenes.script.Project;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterScript : MonoBehaviour
{
    private Animator ar;
    private Rigidbody2D rb;

    //public float MoveTime;
    private float MoveClock;

    public MessageDialog MessageDialog;

    // Start is called before the first frame update
    void Start()
    {
        ar = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
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
        MessageDialog.MessageBox.SetActive(true);
        MessageDialog.MessageDisplay.sprite = GetComponent<SpriteRenderer>().sprite;
        MessageDialog.MessageName.text = name;
        //ar.SetBool("Move", true);
        //MoveClock = MoveTime;

        //Vector2 dr = Random.insideUnitCircle;
        //transform.localScale = new Vector3(dr.x < 0 ? 1 : -1, 1, 1);
        //rb.velocity = dr.normalized * Consts.MoveSpeed;
    }
}
