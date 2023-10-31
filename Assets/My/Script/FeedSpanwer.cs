using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeedSpanwer : MonoBehaviour
{
    public GameObject FeedPrefab;
    public float spawnRateMin = 0.5f;
    public float spawnRateMax = 3f;

    private float spawnRate;
    private float timeAfterSpawn;

    public Transform randomT;

    // Start is called before the first frame update
    void Start()
    {
        timeAfterSpawn = 0f;

        spawnRate = Random.Range(spawnRateMin, spawnRateMax);

    }
 
    // Update is called once per frame
    void Update()
    {
        timeAfterSpawn += Time.deltaTime;

        if (timeAfterSpawn > spawnRate)
        {
            timeAfterSpawn = 0;

            randomT.position = new Vector3(Random.Range(-9f, 9f), Random.Range(0f, 0f), Random.Range(-9f, 9f));

            Instantiate(FeedPrefab, randomT.position, transform.rotation);

            spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        }
    }
}
