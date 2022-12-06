using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataPersistence : MonoBehaviour
{
    // Instancia compartida
    public static DataPersistence sharedInstance;

    public int lives = 3;
    public int score = 0;

    public bool music;


    // Make sure the instance is unique
    private void Awake()
    {
        // If the instance does not exist
        if (sharedInstance == null)
        {
            // We configure the instance
            sharedInstance = this;
            // Make sure it's not destroyed with the scene change
            DontDestroyOnLoad(sharedInstance);
        }
        else
        {
            // Since an instance already exists, we destroy the copy
            Destroy(this);
        }
    }
}
