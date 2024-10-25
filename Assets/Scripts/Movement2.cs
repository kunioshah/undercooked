using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement2 : MonoBehaviour
{
   private Rigidbody2D rb;
    public float MovementSpeed;
    public float rotateSpeed;
    private Vector2 MovementInput;
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
       
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    private void Movement()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector2 movementDirection = new Vector2(horizontal, vertical);

        if (horizontal == 0 && vertical == 0) {
            rb.velocity = new Vector2(0, 0);
            return;
        }

        MovementInput = new Vector2(horizontal, vertical);
        rb.velocity = MovementInput * MovementSpeed * Time.deltaTime;

        if (movementDirection != Vector2.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(Vector3.forward, movementDirection);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotateSpeed * Time.deltaTime);
        }

    }

}
