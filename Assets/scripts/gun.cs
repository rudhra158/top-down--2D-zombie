using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class gun : MonoBehaviour
{
    public GameObject bulletprefab;
    public playerscript ps;
    public Transform firepoint;
    public float fireforce = 10f;
    public int roataionvar = 90;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Fire();

            Debug.Log("iamshooting");

        }

    }
    public void Fire()
    {
        GameObject bullet = Instantiate(bulletprefab, firepoint.position, firepoint.rotation);
        bullet.GetComponent<Rigidbody2D>().AddForce(firepoint.up * fireforce, ForceMode2D.Impulse);
    }
    

}
