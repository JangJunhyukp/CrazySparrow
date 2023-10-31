using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutroController : MonoBehaviour
{
    public GameObject targetPosition;
    public AudioClip exitSound;

    void Start()
    {
        targetPosition.transform.position = new Vector3(0f, 0f, -4f);
        Invoke("exitsound", 4.5f);
    }

    
    void Update()
    {
        if (targetPosition != null)
        {
            transform.position =
                Vector3.MoveTowards(gameObject.transform.position, targetPosition.transform.position, 1f * Time.deltaTime);
            GetComponent<Animator>().SetTrigger("bEnd");
        }
    }
    private void exitsound()
    {
        GetComponent<AudioSource>().PlayOneShot(exitSound);
    }
}
