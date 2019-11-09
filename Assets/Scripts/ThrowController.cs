using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowController : MonoBehaviour
{
    Camera cam;
    Vector3 mouseWorldPoint;
    Vector2 mousePos;
    Vector2 aimVector;
    public GameObject heldObject;
    public GameObject nearbyObject;
    
    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        mousePos = Input.mousePosition;

        mouseWorldPoint = cam.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, cam.nearClipPlane));
        aimVector = mouseWorldPoint - transform.position;

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (nearbyObject == null) { return; }
            heldObject = nearbyObject.GetComponent<Grabbable>().myPrefab;
            GameObject.Destroy(nearbyObject);
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (heldObject == null) { return; }
            GameObject phoneObj = Instantiate(heldObject, transform.position, Quaternion.identity);
            Grabbable phone = phoneObj.GetComponent<Grabbable>();
            phone.vel = aimVector.normalized;
            heldObject = null;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        Debug.DrawLine(transform.position, mouseWorldPoint, Color.red);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Grabbable"))
        {
            nearbyObject = collision.gameObject;
            Debug.Log(collision.gameObject + " is nearby");
        }
    }

    private void OnGUI()
    {
        GUILayout.BeginArea(new Rect(20, 20, 250, 120));
        GUILayout.Label("Screen pixels: " + cam.pixelWidth + ":" + cam.pixelHeight);
        //GUILayout.Label("Mouse position: " + mousePos);
        GUILayout.Label("World position: " + mouseWorldPoint.ToString("F3"));
        GUILayout.Label("aim Vector: " + aimVector.ToString("F3"));
        GUILayout.EndArea();
    }
}
