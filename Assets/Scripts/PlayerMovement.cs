using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody2D rb;
    public float jump;
    public float speed;
    private float Move;

    private Animator animator;

    public AudioSource source;
    public AudioClip clip;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        var velocity = new Vector2(Move * speed, rb.velocity.y);

        animator.SetFloat("Speed", velocity.magnitude);

        Move = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
        {
          source.PlayOneShot(clip);
        }
        
        rb.velocity = velocity;

         if (Input.GetKeyDown("space"))
         {
            rb.AddForce(new Vector2(rb.velocity.x, jump));
         }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Death1")
        {
            transform.position = new Vector2(-1, 6.5f);
        }
        if (other.tag == "NextLvl")
        {
            SceneManager.LoadScene(1);
        }
        if (other.tag == "Death2")
        {
            transform.position = new Vector2(2.44f, -3.52f);
        }
        if (other.tag == "Win")
        {
            SceneManager.LoadScene(2);
        }
    }
}
