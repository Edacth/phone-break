using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PhoneHealth : MonoBehaviour
{
    public float startingHealth;
    public static float phoneHealth;
    public TextMeshProUGUI healthText;
    public GameObject winPanel;
    bool won;
    float winWaitDelay = 0;
    public string nextLevel;

    void Start()
    {
        phoneHealth = startingHealth;
    }

    void Update()
    {
        if (phoneHealth <= 0)
        {
            won = true;
            UITimer.SetPause(true);
            winPanel.gameObject.SetActive(true);
        }

        if (won)
        {
            winWaitDelay += Time.deltaTime;
        }

        if (winWaitDelay >= 3)
        {
            SceneManager.LoadScene(nextLevel);
        }

        healthText.text = phoneHealth + "%";
    }

    public static void TakeDamage(float damage)
    {
        phoneHealth -= damage;
    }
}
