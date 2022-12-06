using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BallController : MonoBehaviour
{

    public Rigidbody2D rigidBody2D;

    public float speed = 300;

    private Vector2 velocity;

    Vector2 startPosition;

  


    void Start()
    {
        //Inicial position
        startPosition = transform.position;
        ResetBall();



    }

    //To reset the ball when we lose a life
    public void ResetBall()
    {
        transform.position = startPosition;
        rigidBody2D.velocity = Vector2.zero;

        velocity.x = Random.Range(-1, 1);

        velocity.y = 1;

        rigidBody2D.AddForce(velocity * speed);

    }


    //For the collision with the "DeadZone" zone of loss of life and death.
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("DeadZone"))
        {
            // Communicate with the Game Manager script and get the Update Life function for life
            FindObjectOfType<GameManager>().UpdateLife(-1);
     
        }
    }

   

}
