using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class zombieattaack : MonoBehaviour
{
    public Animator ani;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col != null)
            if (col.gameObject.tag == "player")
            {
                Debug.Log("hiii");

                ani.SetBool("attack", true);
                ani.SetBool("running", false);
                ani.SetBool("idle", false);

            }
    }
}
