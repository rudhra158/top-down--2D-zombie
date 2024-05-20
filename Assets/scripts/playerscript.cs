using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;

public class playerscript : MonoBehaviour
{
    public float speed = 2f;
    public float attack = 10f;
    public float health = 0f;
    public float maxHealth = 100f;
    Vector3 pointingTarget;
    public Vector2 mouseposition;
    public Rigidbody2D rb;
    Vector2 direction;
    public float rotation = 90f;
    

    
    

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
       
        float moveX = Input.GetAxisRaw("Horizontal");
       float moveY = Input.GetAxisRaw("Vertical");
        
       
        direction = new Vector2(moveX, moveY).normalized;
        mouseposition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
      
       

    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(direction.x * speed, direction.y * speed);

        Vector2 aimdirection = mouseposition - rb.position;
        float aimangle = Mathf.Atan2(aimdirection.y, aimdirection.x) * Mathf.Rad2Deg-rotation;
        rb.rotation = aimangle;
        
    }
    public void updatehealth (float kit)
    {
        if(health > maxHealth) 
        { health = maxHealth; }

    }
  

}
