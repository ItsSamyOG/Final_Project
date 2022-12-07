using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SM_Volume : MonoBehaviour
{

    // To be able to deactivate the music with the google
    public void tooglemusic(bool ison)
    {
        SM_AudioManager.sharedInstance.enablemusic(ison);
    }

    // To be able to control the music with the slider
    public void slidervolume(float v)
    {
        SM_AudioManager.sharedInstance.setvolume(v);
    }
}
