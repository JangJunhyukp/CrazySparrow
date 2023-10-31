using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public static bool isPaused;
    public GameObject pausemenubtn;
    public GameObject soundoffbtn;
    public GameObject soundonbtn;
    public AudioClip btnsound;

    void Start()
    {
        isPaused = false;
    }

    
    void Update()
    {
        
    }
    public void pausebtn()
    {
        if (isPaused)
        {
            Time.timeScale = 1.0f;
            isPaused = false;
            pausemenubtn.SetActive(false);
            GetComponent<AudioSource>().PlayOneShot(btnsound);
        }
        else
        {
            Time.timeScale = 0f;
            isPaused = true;
            pausemenubtn.SetActive(true);
            GetComponent<AudioSource>().PlayOneShot(btnsound);
        }
    }
    public void homebtn()
    {
        SceneManager.LoadScene("Intro");
        Time.timeScale = 1.0f;
        isPaused = true;
        GetComponent<AudioSource>().PlayOneShot(btnsound);
    }

    public void startbtn()
    {
        Time.timeScale = 1.0f;
        isPaused = false;
        pausemenubtn.SetActive(false);
        GetComponent<AudioSource>().PlayOneShot(btnsound);
    }
    public void soundOffbtn()
    {
        soundoffbtn.SetActive(true);
        Audio.source.Stop();
        soundonbtn.SetActive(false);
        GetComponent<AudioSource>().PlayOneShot(btnsound);
    }

    public void soundOnbtn()
    {
        soundonbtn.SetActive(true);
        Audio.source.Play();
        soundoffbtn.SetActive(false);
        GetComponent<AudioSource>().PlayOneShot(btnsound);
    }
}
