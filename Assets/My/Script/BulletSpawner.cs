using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float spawnRateMin = 0.5f;
    public float spawnRateMax = 3f;

    private Transform target;
    private float spawnRate;
    private float timeAfterSpawn;
    //private float totaltime;

    // Start is called before the first frame update
    void Start()
    {
        timeAfterSpawn = 0f;

        //totaltime = 0f;

        spawnRate = Random.Range(spawnRateMin, spawnRateMax);

        target = FindObjectOfType<PlayerController>().transform;

    }

    // Update is called once per frame
    void Update()
    {
        timeAfterSpawn += Time.deltaTime;
        //totaltime += Time.deltaTime;

        gameObject.transform.LookAt(target);

        /*if (totaltime > 30f)
        {
            spawnRateMax = 2f;
        }*/

        if (timeAfterSpawn > spawnRate)
        {
            timeAfterSpawn = 0;

            GameObject bullet
                = Instantiate(bulletPrefab, transform.position, transform.rotation);

            bullet.transform.LookAt(target);

            spawnRate = Random.Range(spawnRateMin, spawnRateMax);
            
        }
    }
}
