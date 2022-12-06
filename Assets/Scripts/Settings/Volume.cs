using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Volume : MonoBehaviour
{

    // To be able to deactivate the music with the google
    public void tooglemusic(bool ison)
    {
        AudioManager.sharedInstance.enablemusic(ison);
    }

    // To be able to control the music with the slider
    public void slidervolume(float v)
    {
        AudioManager.sharedInstance.setvolume(v);
    }
}
