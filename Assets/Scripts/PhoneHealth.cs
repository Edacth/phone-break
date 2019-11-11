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
    public static bool broke = false;
    static Animator animator;
    AudioSource audioSource;
    void Start()
    {
        phoneHealth = startingHealth;
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if(GameObject.FindGameObjectsWithTag("Grabbable").Length > 0)
        {
            animator = GameObject.FindGameObjectWithTag("Grabbable").GetComponent<Animator>();
            if (phoneHealth <= 0)
            {
                animator.SetBool("fire",false);
                animator.SetBool("broke",true);
            }else
            {
                animator.SetBool("broke",false); 
            }
        }
        if (phoneHealth <= 0 && !won)
        {
            won = true;
            audioSource.Play();
            UITimer.SetPause(true);
            winPanel.SetActive(true);
            broke = true;
        }else
        {
            broke = false;
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
        if(phoneHealth - damage <= 0)
        {
            phoneHealth = 0;
        }
        else
        {
            phoneHealth -= damage;
        }
    }
}
