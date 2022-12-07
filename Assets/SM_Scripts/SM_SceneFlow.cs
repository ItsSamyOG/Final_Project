using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SM_SceneFlow : MonoBehaviour
{
    // Function to be able to change scenes, through a button.
    public void GoToScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        Debug.Log("Load");
    }
}


