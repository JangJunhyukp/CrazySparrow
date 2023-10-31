using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BossGameManager : MonoBehaviour
{
    public GameObject gameclearText;
    public GameObject gameoverText;
    public GameObject gamestartText;
    public Text scoreText;
    public static int Feedscore;

    private bool isGameover;

    void Start()
    {
        Feedscore = 3;
        isGameover = false;
        StartGame();
        Invoke("Reopen", 1f);
    }

    void Update()
    {
        if (!isGameover)
        {
            scoreText.text = ": X" + Feedscore;

        }

    }
    public void EndGame()
    {
        isGameover = true;
        gameoverText.SetActive(true);

        BossBulletSpawner bossBulletSpawner = FindObjectOfType<BossBulletSpawner>();
        bossBulletSpawner.enabled = false;

        FeedSpanwer feedSpanwer = FindObjectOfType<FeedSpanwer>();
        feedSpanwer.enabled = false;
        

        Bullet[] bullet = FindObjectsOfType<Bullet>();
        for (int i = 0; i < bullet.Length; i++)
        {
            bullet[i].gameObject.SetActive(false);
        }

        Feed[] feeds = FindObjectsOfType<Feed>();
        for (int i = 0; i < feeds.Length; i++)
        {
            feeds[i].gameObject.SetActive(false);
        }
    }
    public void ClearGame()
    {
        isGameover = true;

        scoreText.text = ": X" + 0;

        gameclearText.SetActive(true);

        BossBulletSpawner bossBulletSpawner = FindObjectOfType<BossBulletSpawner>();
        bossBulletSpawner.enabled = false;

        FeedSpanwer feedSpanwer = FindObjectOfType<FeedSpanwer>();
        feedSpanwer.enabled = false;

        Bullet[] bullet = FindObjectsOfType<Bullet>();
        for (int i = 0; i < bullet.Length; i++)
        {
            bullet[i].gameObject.SetActive(false);
        }

        Feed[] feeds = FindObjectsOfType<Feed>();
        for (int i = 0; i < feeds.Length; i++)
        {
            feeds[i].gameObject.SetActive(false);
        }
    }
    public void StartGame()
    {
        gamestartText.SetActive(true);
    }
    public void Reopen()
    {
        gamestartText.SetActive(false);
    }
}
