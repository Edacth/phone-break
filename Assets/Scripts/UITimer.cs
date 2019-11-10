using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class UITimer : MonoBehaviour
{
    // pauses the timer
    public static bool pause = false;
    // Text that displays the time
    public TextMeshProUGUI displayText;
    // Used for the time
    public float time;
    // Load Scene
    public string level;
    private void Start()
    {
        pause = true;
        displayText.text = time.ToString("F") + "s";
    }
    private void Update()
    {
        StartT();

        if (Input.anyKeyDown)
        {
            pause = false;
        }
    }
    // Just starts a timer and return that it 
    public bool StartT()
    {
        if (!pause)
        {
            time -= Time.deltaTime;  
            if (time <= 0)
            {
                time = 0;
                SceneManager.LoadScene(level);
            }
            displayText.text = time.ToString("F") + "s";
            return true;
        }
        else
            return false;
    }
    public void BClick()
    {
        pause = false;
    }

    public static void SetPause(bool state)
    {
        pause = state;
    }
}
