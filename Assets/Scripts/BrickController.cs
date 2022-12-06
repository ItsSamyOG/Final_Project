using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BrickController : MonoBehaviour
{
    // We create this variable to decide how many points this brick will have
    public int point;

    // We create this variable to decide how many lives this brick will have
    public int impactslifes;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            // Subtract a life from the brick
            impactslifes--;

            // If brick is less than or equal to zero
            if (impactslifes <= 0)
            {
                // Communicate with the GameManager scripts for the counter and the bricks
                GameManager gamemanager = FindObjectOfType<GameManager>();
                gamemanager.Updatescore(point);
                gamemanager.Totalbrick--;

                FindObjectOfType<GameManager>().Ween();

               //Destroy objet
                Destroy(gameObject);
            }

           
        }
    }

}
