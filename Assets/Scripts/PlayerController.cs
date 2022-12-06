using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Rigidbody2D rigidBody2D;

    private BoxCollider2D boxcollider2D;

    private float sideX;

    private float inputValue;

    public float moveSpeed = 25;

    private Vector2 direction;

    Vector2 startPosition;

    
 



    private void Start()
    {
        startPosition = transform.position;
        boxcollider2D = GetComponent<BoxCollider2D>();
        sideX = boxcollider2D.size.x/3;
    }
 
    void Update()
    {
        //For the movement, which is only horizontal
        inputValue = Input.GetAxisRaw("Horizontal");

        if (inputValue == 1)

        {
            direction = Vector2.right;
        }
        else if (inputValue == -1)
        {
            direction = Vector2.left;
        }
        else
        {
            direction = Vector2.zero;
        }

        rigidBody2D.AddForce(direction* moveSpeed * Time.deltaTime * 100);

    }

    //Collision between the player and the ball
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            // communicate with the Game Manager script and get the Playeraudio function for music
            FindObjectOfType<GameManager>().Playeraudio();

            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-1, 1), ForceMode2D.Impulse);
            if (collision.contacts[0].point.x <sideX)
            {
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-1,1));
            }

        }
    }

    // Reset the player when it's time to lose a life.
    public void ResetPlayer()
    {
        transform.position = startPosition;
        rigidBody2D.velocity = Vector2.zero;
    }


}
