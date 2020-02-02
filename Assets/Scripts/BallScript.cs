using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    //variables
    [SerializeField] PaddleScript paddle; //Serialized so I can assign the paddle to the ball through the inspector 
    [SerializeField] float xInitialVelocity = 2f; //initial velocity when the ball it launched. It does not go straight up so we need some push in the x direction
    [SerializeField] float yInitialVelocty = 15f; //also I want to edit these in the inspector
    [SerializeField] AudioClip[] ballHitSounds; //Array of audio sources to use from when ball collides with another object

    [SerializeField] float factor = 0.2f; //will be using this value to prevent ball from move horizontally and adding a little velocity in the x or y direction so the ball never gets stuck 

    
    Vector2 gapBetweenPaddleAndBall;
    bool hasStarted = false; //to check that the game has started or not so we can stop locking the ball to the paddle

    AudioSource audioSource; //component reference for audio
    Rigidbody2D ballRigidbody2D; //component reference for ball's rigid body component 

    // Start is called before the first frame update
    void Start()
    {
        gapBetweenPaddleAndBall = transform.position - paddle.transform.position; //we are refering to game object this script is assigned to
        audioSource = GetComponent<AudioSource>(); //assign the audio source component of this object to audioSource variable
        ballRigidbody2D = GetComponent<Rigidbody2D>(); //assign component to variable here too
    }

    // Update is called once per frame
    void Update()
    {

        if (!hasStarted) //if we didn't start the game
        {
            StartBallOnPaddle();
            LaunchBall(); // Launch ball on mouse click event
        }
        
    }

    private void StartBallOnPaddle()
    {
        Vector2 paddlePostion = new Vector2(paddle.transform.position.x, paddle.transform.position.y); //get the current position of the paddle
        transform.position = paddlePostion + gapBetweenPaddleAndBall; //Make the ball stick to the paddle's top
    }

    public void LaunchBall()
    {
        if (Input.GetMouseButtonDown(0)) //when left click on mouse occurs
        {
            hasStarted = true; //to stop locking ball after starting, so we set this to true
            ballRigidbody2D.velocity = new Vector2(xInitialVelocity, yInitialVelocty); //access the ball's rigidbody component and give it a velocity
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) //when ball collides...
    {
        //velocity influece to ensure ball never gets stuck so we move it slightly in the y or x directtion 
        Vector2 velocityInfluence = new Vector2((Random.Range(0f, factor)), (Random.Range(0f, factor))); //getting error sometimes between Unity name space and System namespace and not sure what its about...

        if (hasStarted) //only if game started, play the sound when ball collides
        {
            AudioClip audioClip = ballHitSounds[UnityEngine.Random.Range(0,ballHitSounds.Length)]; //randomly assign the audioClip variable one of the audioClips within the array of audioClips of ballHitSounds
            audioSource.PlayOneShot(audioClip); //look at the ball's audio source component and play the given audio clip //PlayOneShot allows the playing audio to complete without interruption even if another one started to play
            ballRigidbody2D.velocity += velocityInfluence; //adding the influece mentioned to the ball's velocity
        }
        
    }
}
