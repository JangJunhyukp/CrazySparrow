using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroController : MonoBehaviour
{

    public GameObject targetPosition;
    public AudioClip openSound;

    // Start is called before the first frame update
    void Start()
    {
        targetPosition.transform.position = new Vector3(0f, 0f, -5f);
        Invoke("opensound", 4.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (targetPosition != null)
        {
            transform.position = 
                Vector3.MoveTowards(gameObject.transform.position, targetPosition.transform.position, 1f * Time.deltaTime);
            GetComponent<Animator>().SetTrigger("bOpen");
            
        }
        
    }
    private void opensound()
    {
        GetComponent<AudioSource>().PlayOneShot(openSound);
    }
}
