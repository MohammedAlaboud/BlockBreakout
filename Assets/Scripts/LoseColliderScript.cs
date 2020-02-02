using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //Imported to access methods to move between scenes

public class LoseColliderScript : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision) //when the ball enters the loseCollider area, trigger a game over
    {
        SceneManager.LoadScene("GameOver"); //String reference, kinda hard coded, I know...
    }

}
