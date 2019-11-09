using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabbable : MonoBehaviour
{
    public float throwSpeed = 22.0f;
    public Vector2 vel;
    public GameObject myPrefab;

    void Update()
    {
        transform.Translate(vel.x * Time.deltaTime * throwSpeed, vel.y * Time.deltaTime * throwSpeed, 0);


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log(collision.tag);
        if (collision.gameObject.CompareTag("Wall"))
        {
            vel = Vector2.zero;
            Debug.Log("WALL");
        }
    }
}
