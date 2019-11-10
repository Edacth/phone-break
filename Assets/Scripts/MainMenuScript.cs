using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public string scene;

    public void StartGame()
    {
        SceneManager.LoadScene(scene);
    }
}
