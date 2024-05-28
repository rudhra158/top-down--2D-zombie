using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class zombie : MonoBehaviour
{
    public Transform trans;
    public float speed = 5f;
    public Animator ani;
    public float zombiehealth = 100;
    public GameObject zomb;
    public GameObject bull;
    public float attack=10f;
    public Vector3 target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (zombiehealth<= 0)
        {
            zomb.SetActive(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col != null)
            if (col.gameObject.tag == "player")
            {
                Vector3 rotaion = trans.position - transform.position;
                transform.position = Vector2.MoveTowards(transform.localPosition, trans.transform.position, speed * Time.deltaTime);
                float rotationZ = MathF.Atan2(rotaion.y, rotaion.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
                ani.SetBool("idle", false);
                ani.SetBool("attack", false);
                ani.SetBool("running", true);
            }
        


    }
    private void OnTriggerStay2D(Collider2D col)
    {
        if (col != null)
            if (col.gameObject.tag == "player")
            {
                Vector3 rotaion = trans.position - transform.position;
                float rotationZ = MathF.Atan2(rotaion.y, rotaion.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
                
                ani.SetBool("attack", true);
                ani.SetBool("running", false );
            }


    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col != null)
            if (col.gameObject.tag == "player")
            {
                ani.SetBool("running", false);
                
                ani.SetBool("attack", false);
                
                ani.SetBool("idle", true);

            }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("bullet"))
            
            {
                zombiehealth -= 10;
                Destroy(collision.gameObject);

            if (collision.gameObject.CompareTag("player"))
            {
                collision.gameObject.GetComponent<playerscript>().updatehealth(-attack);
                Debug.Log("attack");
            }
        }
    }

}
    
