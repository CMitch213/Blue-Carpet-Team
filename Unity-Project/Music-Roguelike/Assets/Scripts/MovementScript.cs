using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;

    private bool facingRight = true;
    private bool facingUp = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //Move the bitch
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        //Change speed of character
        rb.velocity = new Vector2(moveX * moveSpeed, moveY * moveSpeed);

        // Flip the character horizontally
        if (moveX > 0 && !facingRight)
        {
            Flip();
        }
        else if (moveX < 0 && facingRight)
        {
            Flip();
        }
        //Flip the character vertically
        if (moveY > 0 && !facingUp)
        {
            FlipVertical();
        }
        else if (moveY < 0 && facingUp)
        {
            FlipVertical();
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    void FlipVertical()
    {
        facingUp = !facingUp;
        Vector3 scale = transform.localScale;
        scale.y *= -1;
        transform.localScale = scale;
    }
}
