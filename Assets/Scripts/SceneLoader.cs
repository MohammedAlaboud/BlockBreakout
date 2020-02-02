using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    
    public void LoadNextScene() //we make it public to call it from button
    {
        //first we add and order scene in build settings in Scenes In Build area
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex; //declared int var where we use SceneManager class to get build index of active scene.
        SceneManager.LoadScene(currentSceneIndex + 1); //load the next scene
    }

    public void LoadStartScene()
    {
        SceneManager.LoadScene(0); //go to first main menu
        FindObjectOfType<GameStatsScript>().ResetGame(); //reset the game (needed to rest game stats like score) 
    }

    public void QuitGame()//According to unity docs, this will work on game build and not in the editor.
    {
        Application.Quit();
    }
}
