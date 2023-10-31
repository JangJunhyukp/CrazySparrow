using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IntroGameManager : MonoBehaviour
{
    public GameObject gamestartText;
    public GameObject explainText;
    float time;

    void Start()
    {
        Invoke("StartGame", 4.5f);
        GetComponent<AudioSource>().Play();
    }


    void Update()
    {
        time += Time.deltaTime;
        if (time > 2.9f)
        {
            GetComponent<AudioSource>().Stop();
        }
    }
    public void StartGame()
    {
        gamestartText.SetActive(true);
        explainText.SetActive(true);
    }

}
