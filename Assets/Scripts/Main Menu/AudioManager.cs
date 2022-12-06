using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager sharedInstance;
    private AudioSource music;
   

    // Start is called before the first frame update
    void Start()
    {
        music = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void Awake()
    {
        // If the instance does not exist
        if (sharedInstance == null)
        {
            // We configure the instance
            sharedInstance = this;
            // We make sure that it is not destroyed with the change of scene
            DontDestroyOnLoad(sharedInstance);
        }
        else
        {
            // Since an instance already exists, we destroy the copy
            Destroy(this.gameObject);
        }
    }

    // To mute
    public void enablemusic(bool ison)
    {
        music.mute = !ison;
    }

    //To regulate volume
    public void setvolume(float v)
    {
        music.volume = v;
    }

}
