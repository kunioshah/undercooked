using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement2 : MonoBehaviour
{
    public float turnSpeed;
    public float moveSpeed;
    public Rigidbody2D rb;
    Vector2 direction; 
    Vector2 movementVector; 
    float angle;


    void Start()
    {

    }

    void Update()
    {
        float rightInput = (Input.GetAxis("Horizontal"))*(moveSpeed)*UnityEngine.Time.deltaTime;
        float upInput = (Input.GetAxis("Vertical"))*(moveSpeed)*UnityEngine.Time.deltaTime;
        movementVector = new Vector2(rightInput, upInput).normalized;
         
    }

    void FixedUpdate() {
        float mouseX = Input.GetAxis("Horizontal");
        float mouseY = Input.GetAxis("Vertical");
        direction = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 angleDirection = direction - rb.position;
        angle = Mathf.Atan2(angleDirection.y, angleDirection.x) * Mathf.Rad2Deg - 90f;

        // this worked but it slowed down rotation massively idk why?? ill revisit it later its fine for now
        // if ((mouseX!=0) || (mouseY!=0)) { 
            rb.rotation = angle;
        // }

        rb.velocity = new Vector2(movementVector.x * moveSpeed, movementVector.y * moveSpeed);
    }

}
