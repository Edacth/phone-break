using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarLogic : MonoBehaviour
{
    // Delay for the car when it will pass by
    public float delay = 0.0f;
    // Direction the car should go in
    public Vector3 carDir;
    // Speed for the car
    public float carSpeed = 0.0f;
    bool started;
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.anyKeyDown)
        {
            started = true;
        }

        if (started)
        {
            delay -= Time.deltaTime;
            if (delay <= 0)
            {
                this.transform.Translate(carDir * Time.deltaTime * carSpeed);
            }
        }
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Grabbable"))
        {
            Debug.Log("A");
            //PhoneHealth.TakeDamage(100);
        }
    }
}
