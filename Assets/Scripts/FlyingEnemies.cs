using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemies : MonoBehaviour
{
    public float speed;
    public bool up = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (up)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + speed);
        }

        else
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - speed);
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Wall" && up == true)
        {
            up = false;

        }

        else if (other.tag == "Wall" && up == false)
        {
            up = true;
        }
    }
}