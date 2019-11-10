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
    void Start()
    {
        
    }

    void Update()
    {
        delay -= Time.deltaTime;
        if(delay <= 0)
        {
            this.transform.Translate(carDir * Time.deltaTime * carSpeed);
        }
    }
}
