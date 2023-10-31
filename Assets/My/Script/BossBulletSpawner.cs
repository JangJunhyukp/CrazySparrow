using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBulletSpawner : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float spawnRateMin = 0.3f;
    public float spawnRateMax = 0.8f;

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

        target = FindObjectOfType<BossPlayerController>().transform;


    }

    // Update is called once per frame
    void Update()
    {
        timeAfterSpawn += Time.deltaTime;
        //totaltime += Time.deltaTime;

        //gameObject.transform.LookAt(target);

        Vector3 to = target.position;
        to.y = 0f;
        transform.rotation = Quaternion.LookRotation(to);

        Vector3 my = transform.position;
        my.x = 1.0f;
        my.z = -2.5f;


        /*if (totaltime > 30f)
        {
            spawnRateMax = 2f;
        }*/

        if (timeAfterSpawn > spawnRate)
        {
            timeAfterSpawn = 0;

            GameObject bullet
                = Instantiate(bulletPrefab, my, transform.rotation);

            bullet.transform.rotation = Quaternion.LookRotation(to);
            //bullet.transform.LookAt(target);

            spawnRate = Random.Range(spawnRateMin, spawnRateMax);

        }
    }
}
