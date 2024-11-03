using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public TMP_Text time;
    public AudioSource audioSource;
    public AudioClip[] musicClips; // Массив аудиофайлов
    private void Start()
    {
        Time.timeScale = 1.0f;
    }
    public void Play()
    {
        PlayMusic(0);
        SceneManager.LoadScene("Level");
        audioSource = GetComponent<AudioSource>();
        time.text = "8:45";
    }
    public void Exit()
    {
        PlayMusic(0);
        time.text = "14:13";
        Application.Quit();
    }
    private void PlayMusic(int clipIndex)
    {
        if (clipIndex < musicClips.Length)
        {
            audioSource.clip = musicClips[clipIndex];
            audioSource.Play();
        }
    }

}
