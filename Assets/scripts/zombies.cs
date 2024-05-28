using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombies : MonoBehaviour
{

   public GameObject player;
    public Transform trans;
    public float speed = 5f;
    public Animator ani;
    public float tragetrange = 10f;
    public float attackrange = 5f;
    public float closerange = 2f;
    public float zombiehealth = 100;
    public GameObject zomb;
    public float attack = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (zombiehealth <= 0)
        {
            zomb.SetActive(false);
        }
        Debug.Log(Vector3.Distance(transform.position, player.transform.position));
        
        if((closerange <  Vector3.Distance(transform.position,player.transform.position)) && (Vector3.Distance(transform.position, player.transform.position) < tragetrange))
        {
            transform.position = Vector2.MoveTowards(transform.localPosition, trans.transform.position, speed * Time.deltaTime);
            ani.SetBool("idle", false);
            ani.SetBool("attack", false);
            ani.SetBool("running", true);
            Vector3 rotaion = trans.position - transform.position;
            float rotationZ = MathF.Atan2(rotaion.y, rotaion.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);


        }

        
        if (Vector3.Distance(transform.position, player.transform.position) < attackrange)
        {
            ani.SetBool("attack", true);
            ani.SetBool("running", false);
            
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("bullet"))

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
