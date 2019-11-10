using TMPro;
using UnityEngine;

public class RouterTime : MonoBehaviour
{
    // Gets a object from the UITimer
    public UITimer uiTimer;
    // Used for the tag
    public string phoneTag = "Grabbable";
    // Used to get how much it increases the time
    public float timeIncrease = 0.0f;
    // warning text
    public TextMeshProUGUI RouterText;
    // Text opacity when
    float warningOpacity = 0.0f;
    Camera cam;
    bool active = true;
    private void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        if (warningOpacity > 0)
        {
            warningOpacity -= 1f * Time.deltaTime * 0.5f;
            RouterText.alpha = warningOpacity;
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag(phoneTag) || active)
        {
            RouterText.transform.position = cam.WorldToScreenPoint(transform.position);
            uiTimer.time += timeIncrease;
            warningOpacity = 1;
            RouterText.text = $"{timeIncrease}s added to clock.";
            active = false;
        }
    }
}
