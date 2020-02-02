using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; //I use TextMesh Pro for my font

public class GameStatsScript : MonoBehaviour //this is more like a Game Session...
{

    [Range(0.1f, 3f)][SerializeField] float gameSpeed = 1f;  //Game speed. Serialized to edit from inspector. We also limit the range that the game speed can be so we don't have negative or big values
    [SerializeField] int pointsPerBlockDestroyed = 10;
    [SerializeField] int playerScore = 0; //Serialized so the score is visible as more implementation is done. The score starts at 0
    [SerializeField] TextMeshProUGUI scoreText; //for displaying score on the screen

    private void Awake() //used to help with process of displaying score across levels instead of resetting every scene
    {
        int gameStatusCount = FindObjectsOfType<GameStatsScript>().Length; //stores all game stats objects
        if(gameStatusCount > 1) //if one already exits
        {
            gameObject.SetActive(false); //to fix the bug where there are two instances before it is destroyed. I still don't get it honestly, but it fixed the bug :)
            Destroy(gameObject); //destroy self
        }
        else
        {
            DontDestroyOnLoad(gameObject); //don't destroy self when level load in the future to keep score (to keep stats)
        }
    }

    private void Start()
    {
        scoreText.text = playerScore.ToString(); //update the displayed score value
    }


    // Update is called once per frame
    void Update()
    {
        Time.timeScale = gameSpeed; 
    }

    public void addUpScore() //increase score
    {
        playerScore = playerScore + pointsPerBlockDestroyed; //add the points to player score
        scoreText.text = playerScore.ToString(); //update the display value
    }

    public void ResetGame() //to ensure game is reset at the end
    {
        Destroy(gameObject); //object of class destorys self
    }
}
