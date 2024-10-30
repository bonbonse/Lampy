using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    private void Start()
    {
        Time.timeScale = 1.0f;
    }
    public void Play()
    {
        SceneManager.LoadScene("Level");
    }
    public void Exit()
    {
        Application.Quit();
    }
}
