using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDamage : MonoBehaviour
{
    // Used for the tag
    public string phoneTag = "Grabbable";
    // Time per seconds you want it to reset the time at
    public float damagePS = 0.0f;
    // This will be used for how much damage you want the object to take
    public float damage = 0.0f;
    // This is just the timer for the damage
    float damageTimer = 0.0f;
    // Boolean to check if it entered and exited the phone
    bool isColliding = false;
    public bool EnablepersistentDamage = false;
    bool theresFire = false;
    void Update()
    {
        // Changing the phone damage if its still on the phone with a delay
        if(isColliding || theresFire)
        {
            damageTimer += Time.deltaTime;
            if(damageTimer >= damagePS)
            {
                damageTimer = 0.0f;
                PhoneHealth.TakeDamage(damage);
                //Debug.Log(PhoneHealth.phoneHealth);
            }
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag(phoneTag))
        {
            Debug.Log("A");
            isColliding = true;
            if (EnablepersistentDamage)
            {
                theresFire = true;
            }
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag(phoneTag))
        {
            isColliding = false;
        }
    }
}
