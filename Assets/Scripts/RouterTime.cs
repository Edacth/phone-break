using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RouterTime : MonoBehaviour
{
    // Gets a object from the UITimer
    public UITimer uiTimer;
    // Used for the tag
    public string phoneTag = "Grabbable";
    // Used to get how much it increases the time
    public float timeIncrease = 0.0f;
    // warning text
    public TextMeshProUGUI warningText;
    // Text opacity when
    float warningOpacity = 0.0f;
    void Update()
    {
        if (warningOpacity > 0)
        {
            warningOpacity -= 1f * Time.deltaTime * 0.5f;
            warningText.alpha = warningOpacity;
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag(phoneTag))
        {
            uiTimer.time += timeIncrease;
            warningOpacity = 1;
            warningText.text = $"{timeIncrease}s added to clock.";
        }
    }
}
