using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{

    public void Play()
    {
        Debug.Log("Play pressed");
    }

    public void Quit()
    {
        Debug.Log("Quit pressed");
        Application.Quit();
    }
}
