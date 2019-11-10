using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabbable : MonoBehaviour
{
    public float throwSpeed = 22.0f;
    public Vector2 vel;
    public GameObject myPrefab;
    float reboundModifier = 0.4f;
    public bool takeWallDamage;
    Animator animator;

    public CollisionRay[] collisionRays;
    public bool[] rayStay;

    private void Start()
    {
        rayStay = new bool[collisionRays.Length];
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Simulate collision rays
        for (int i = 0; i < collisionRays.Length; i++)
        {
            
            LayerMask layerMask = 1 << 8; // Wall layer
            Vector2 PosXY = new Vector2(transform.position.x, transform.position.y);
            Debug.DrawRay(PosXY + collisionRays[i].rayOffset, collisionRays[i].rayDir, Color.green);

            RaycastHit2D rcHit = Physics2D.Raycast(PosXY + collisionRays[i].rayOffset, collisionRays[i].rayDir, collisionRays[i].rayDir.magnitude, layerMask);

            if (rcHit.collider != null)
            {
                Debug.Log(i + " hit", rcHit.collider.gameObject);
                if (rayStay[i] == false)
                {
                    // Choose which dir to send it in
                    switch (collisionRays[i].reboundDir)
                    {
                        case ReboundDir.PosX:
                            //vel.x = Mathf.Max(0, vel.x);
                            vel.x = Mathf.Abs(vel.x * reboundModifier);
                            break;
                        case ReboundDir.NegX:
                            //vel.x = Mathf.Min(0, vel.x);
                            vel.x = -Mathf.Abs(vel.x * reboundModifier);
                            break;
                        case ReboundDir.PosY:
                            vel.y = Mathf.Abs(vel.y * reboundModifier);
                            break;
                        case ReboundDir.NegY:
                            vel.y = -Mathf.Abs(vel.y * reboundModifier);
                            break;
                        default:
                            break;
                    }
                    
                    takeWallDamage = true;
                }
                rayStay[i] = true;
            }
            else
            {
                rayStay[i] = false;
            }
        }

        if (takeWallDamage)
        {
            PhoneHealth.TakeDamage(3);
            takeWallDamage = false;
        }
    }

    private void FixedUpdate()
    {
        transform.Translate(vel.x * Time.deltaTime * throwSpeed, vel.y * Time.deltaTime * throwSpeed, 0);
        vel -= vel * 0.05f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log(collision.tag);
        if (collision.gameObject.CompareTag("Wall"))
        {
            //vel = Vector2.zero;
        }

        if (collision.gameObject.CompareTag("Oven"))
        {
            animator.SetBool("fire", true);
        }
    }
}

public enum ReboundDir
{
    PosX = 0,
    NegX = 1,
    PosY = 2,
    NegY = 3
}

[System.Serializable]
public class CollisionRay
{
    public Vector2 rayOffset;
    public Vector2 rayDir;
    public ReboundDir reboundDir;
}