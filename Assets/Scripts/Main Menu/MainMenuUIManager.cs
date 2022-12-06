using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUIManager : MonoBehaviour
{
    public void GoToScene(string sceneName)
    {
        // Load the scene that has the name sceneName
        SceneManager.LoadScene(sceneName);
    }

    public void Quit()
    {
        // If we are testing in the editor
#if UNITY_EDITOR
        // Salimos del editor
        UnityEditor.EditorApplication.isPlaying = false;
#endif

        // We exit the application (it will only work in the Build)
        Application.Quit();
    }
}
