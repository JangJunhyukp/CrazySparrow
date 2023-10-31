using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OutroGameManager : MonoBehaviour
{
    public GameObject gamestartText;
    public GameObject explainText;
    float time;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("StartGame", 4.5f);
        GetComponent<AudioSource>().Play();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time > 3.1f)
        {
            GetComponent<AudioSource>().Stop();
        }
    }
    public void StartGame()
    {
        gamestartText.SetActive(true);
        explainText.SetActive(true);
    }

    public void ExitGame()
    {
         #if UNITY_EDITOR
             UnityEditor.EditorApplication.isPlaying = false;
         #else
              Application.Quit();
         #endif
    }
}
