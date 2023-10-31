using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb; // 이동에 사용할 리지드바디 컴포넌트
    public float speed = 8f; // 이동 속력
    public AudioClip Eatsound;
    public AudioClip Diesound;
    public AudioClip Winsound;
    public GameObject Eateffect;
    public GameObject Dieeffect;
    public FloatingJoystick joystick;

    private void Hide()
    {
        gameObject.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //float xInput = Input.GetAxis("Horizontal");
        //float zInput = Input.GetAxis("Vertical");
        float xInput = joystick.Horizontal;
        float zInput = joystick.Vertical;

        float xSpeed = xInput * speed;
        float zSpeed = zInput * speed;

        Vector3 newVelocity = new Vector3(xSpeed, 0f, zSpeed);

        rb.velocity = newVelocity;
        rb.rotation = Quaternion.LookRotation(newVelocity);

        if (xInput != 0f || zInput != 0f)
        {
            GetComponent<Animator>().SetBool("bMove", true);
        }

        else
        {
            GetComponent<Animator>().SetBool("bMove", false);
        }

        if (GameManager.Feedscore == 0)
        {
            GetComponent<Animator>().SetTrigger("bWin");

            rb.velocity = Vector3.zero;

            enabled = false;

            GameManager gameManager = FindObjectOfType<GameManager>();

            gameManager.ClearGame();

            GetComponent<AudioSource>().PlayOneShot(Winsound);

            Audio.source.Stop();

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Feed"))
        {
            GetComponent<Animator>().SetTrigger("bEat");
            GameManager.Feedscore -= 1;
            GetComponent<AudioSource>().PlayOneShot(Eatsound);

            Vector3 vector3 = transform.position;
            vector3.y = 2f;

            Instantiate(Eateffect, vector3, Quaternion.identity);
            
        } 
        else if (other.CompareTag("fork"))
        {
            GetComponent<Animator>().SetTrigger("bDie");
        }
    }

    public void Die()
    {
        Invoke("Hide", 1.5f);
        
        enabled = false;

        rb.velocity = Vector3.zero;

        GameManager gameManager = FindObjectOfType<GameManager>();

        gameManager.EndGame();

        GetComponent<AudioSource>().PlayOneShot(Diesound);

        Vector3 vector3 = transform.position;

        vector3.y = 2f;
        
        Instantiate(Dieeffect, vector3, Quaternion.identity);

        Audio.source.Stop();

    } 
}
