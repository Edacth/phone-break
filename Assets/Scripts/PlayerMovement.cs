using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float speed = 3.0f;
    float verticalVelocity;
    float horizontalVelocity;
    Animator animator;
    SpriteRenderer sr;

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        verticalVelocity = Input.GetAxis("Vertical") * speed;
        horizontalVelocity = Input.GetAxis("Horizontal") * speed;

        transform.Translate(horizontalVelocity * Time.deltaTime, verticalVelocity * Time.deltaTime, 0);
        //rb.AddForce(new Vector2(horizontalVelocity * Time.deltaTime, verticalVelocity * Time.deltaTime));

        if (Mathf.Abs(horizontalVelocity) > 0 || Mathf.Abs(verticalVelocity) > 0)
        {
            animator.SetBool("moving", true);
            sr.flipX = horizontalVelocity > 0 ? true : false;
        }
        else
        {
            animator.SetBool("moving", false);
        }

        
    }
}
