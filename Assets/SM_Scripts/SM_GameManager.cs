using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class SM_GameManager : MonoBehaviour
{
    public int lifes = 3;
    public GameObject[] hearts;

    public int Totalbrick;

    public int timetostart = 5;


    // For the score
    public TextMeshProUGUI pointText;
    public int score = 0;

    // save settings
    public bool settings;
    public GameObject settingsPanel;
    public GameObject settingexitButton;

    // Save GameOver
    public bool gameOver;
    public GameObject gameOverPanel;
    public GameObject exitButton;

    // Next Level
    public bool win;
    public GameObject winPanel;
    public GameObject winText;
    public GameObject winresetButton;
    public GameObject winexitButton;
    public GameObject nextlevelButton;

  

    //For the music
    private AudioSource playerAudioSource;
    public AudioClip crashAudio;
    public AudioClip playerAudio;
    public AudioClip gameoverAudio;
    public AudioClip luselifeAudio;

    //For the particle system
    public ParticleSystem winparticlesystem;
    public ParticleSystem gameoverparticlesystem;


    public void Start()
    {
        Time.timeScale = 1;

        //StartCoroutine("waittostart");

        Totalbrick = FindObjectsOfType<SM_BrickController>().Length;

        // For the GameOver
        gameOverPanel.SetActive(false);
        exitButton.SetActive(false);

        //For settings
        settingsPanel.SetActive(false);
        settingexitButton.SetActive(false);

        //For Nextlevel
         winPanel.SetActive(false);
         winText.SetActive(false);
         winresetButton.SetActive(false);
         winexitButton.SetActive(false);
         nextlevelButton.SetActive(false);

        // para la musica
        playerAudioSource = GetComponent<AudioSource>();

        //Data persistence
        // Life
        lifes = 3;
        UpdateLife(0);
        //Score
        score = 0;
        pointText.text = $" {score}";
        
    }

    //It is in charge of resetting both the ball and the player
    public void ResetLevel()
    {
        // communicate with the BallController script and get the ResetBall function for the lives system and reset
        FindObjectOfType<SM_BallController>().ResetBall();
        // communicate with the Player Controller script and get the ResetPlayer function for the lives system and reset
        FindObjectOfType<SM_PlayerController>().ResetPlayer();
    }




    //Score 

    public void Updatescore( int value)
    {
        score += value;
        //DataPersistence.sharedInstance.score = score;
        pointText.text = $" {score}";

        playerAudioSource.PlayOneShot(crashAudio);
    }

    // For the player's audio
    public void Playeraudio()
    {
        playerAudioSource.PlayOneShot(playerAudio);
    }


    // For the lives system
    public void UpdateLife(int value)
    {
        lifes += value;
       // DataPersistence.sharedInstance.lives = lifes;
        Debug.Log(lifes);
        if (lifes <= 0)
        {
            hearts[0].gameObject.SetActive(false);
            hearts[1].gameObject.SetActive(false);
            hearts[2].gameObject.SetActive(false);

            playerAudioSource.PlayOneShot(gameoverAudio);

            GameOver();
            Debug.Log("Game Over");
        }
        else if (lifes == 1)
        {
            hearts[0].gameObject.SetActive(true);
            hearts[1].gameObject.SetActive(false);
            hearts[2].gameObject.SetActive(false);

            playerAudioSource.PlayOneShot(luselifeAudio);

            ResetLevel();
        }
        else if (lifes == 2)
        {
            hearts[0].gameObject.SetActive(true);
            hearts[1].gameObject.SetActive(true);
            hearts[2].gameObject.SetActive(false);

            playerAudioSource.PlayOneShot(luselifeAudio);

            ResetLevel();
        }
        else if (lifes == 3)
        {
            hearts[0].gameObject.SetActive(true);
            hearts[1].gameObject.SetActive(true);
            hearts[2].gameObject.SetActive(true);

            playerAudioSource.PlayOneShot(luselifeAudio);

            ResetLevel();
        }
    }

    
    public void Settings()
    {
        Time.timeScale = 0f;

        settings = true;
        settingsPanel.SetActive(true);

        settingexitButton.SetActive(true);


       

    }

    //For the off settings panel
    public void OffSettings()
    {
        

        settings = false;
        settingsPanel.SetActive(false);
        settingexitButton.SetActive(false);

        Time.timeScale = 1f;


    }

    //For the gameover
    private void GameOver()
    {

        // Indicates that the game is over
        gameOver = true;

        //Instantiate particlesystem
        ParticleSystem explosionEscena = Instantiate(gameoverparticlesystem, transform.position,
        gameoverparticlesystem.transform.rotation);
         explosionEscena.Play();

        gameOverPanel.SetActive(true); 
        exitButton.SetActive(true);

        Time.timeScale = 0f;

        
    }

    //For the winning
    public void Ween()
    {


        //If totalbick is less than or equal to zero
        if (Totalbrick <=0)
        {

            win = true;

            //Instantiate particlesystem
            ParticleSystem explosionEscena = Instantiate(winparticlesystem, transform.position,
            winparticlesystem.transform.rotation);
            explosionEscena.Play();

            winPanel.SetActive(true);
            winText.SetActive(true);
            winresetButton.SetActive(true);
            winexitButton.SetActive(true);
            nextlevelButton.SetActive(true);

            Time.timeScale = 0f;
        }

       
    }

    //Wait time
    public IEnumerator waittostart()
    {
        yield return new WaitForSeconds(timetostart);
        
    }


}
