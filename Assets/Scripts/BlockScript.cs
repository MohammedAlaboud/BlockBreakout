using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockScript : MonoBehaviour
{
    [SerializeField] AudioClip blockHitAudio; //audio variable for block when hit

    LevelScript level; //instantiate Level type and as a reference

    private void Start() 
    {
        level = FindObjectOfType<LevelScript>(); //assign level to be a level type

        if (tag == "Breakable") //only count blocks we can break
        {
            level.CountLevelBlocks(); //+1 to the number of breakable blocks //every block instance has this script so it should correctly count the number of blocks we can break in a level
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) //when something collides with the block... trigger!
    {
        if(tag == "Breakable") //if we can break the block
        {
            FindObjectOfType<GameStatsScript>().addUpScore(); //when block is desroyed, add points to score using method in gamestats
            AudioSource.PlayClipAtPoint(blockHitAudio, Camera.main.transform.position); //making sure we play the audio independently of the object (created and destroyed independently) as the audio will not play when it is destoryed
                                                                                        //play audio by camera listener by referening the camera's position

            Destroy(gameObject); //removes the object (and it refers to THIS object)
            level.LevelBlockDestroyed(); //access level class and decrease number of blocks by 1
        }


        
    }

}
