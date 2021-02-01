using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerScript : MonoBehaviour
{
    Rigidbody2D rb;

    [SerializeField]
    Transform groundCheck;

    bool isGrounded;

    public AudioSource Losebgm;
    public AudioSource winbgm;

    public float timer = -2;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();


    }

    // Update is called once per frame

    void FixedUpdate()
    {

        if (Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground")))
        {
            isGrounded = true;

            if (isGrounded = true)
            {
                if (Input.GetKey(KeyCode.Space))
                {
                    rb.AddForce(new Vector2(0, 25), ForceMode2D.Impulse);
                }
            }
        }
        else
        {
            isGrounded = false;
        }
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }

        if (Time.timeScale == 0)
        {

            if (Input.GetKey(KeyCode.R))
            {
                Time.timeScale = 1;
                SceneManager.LoadScene(0);
                SceneManager.LoadScene("SampleScene");

            }

            if (Input.GetKey(KeyCode.Escape))
            {
                Application.Quit();
            }
        }

        if (timer > 10)
        {

            winbgm.Play();

        }

        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Car")
        {
            Time.timeScale = 0;
            Losebgm.Play();

        }
    }
}

