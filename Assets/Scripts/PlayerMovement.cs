using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float speed = 3.0f;
    float verticalVelocity;
    float horizontalVelocity;

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        verticalVelocity = Input.GetAxis("Vertical") * speed;
        horizontalVelocity = Input.GetAxis("Horizontal") * speed;

        transform.Translate(horizontalVelocity * Time.deltaTime, verticalVelocity * Time.deltaTime, 0);
        //rb.AddForce(new Vector2(horizontalVelocity * Time.deltaTime, verticalVelocity * Time.deltaTime));
    }
}
