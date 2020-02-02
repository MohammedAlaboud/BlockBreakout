using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelScript : MonoBehaviour
{

    [SerializeField] int levelBlocks; //not meant to be changed, just for testing //Blocks that we can destory

    SceneLoader sceneLoader;  //referenced so we don't need to find the object of this type every time

    private void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>(); //so we know SceneLoader is a reference to the class 
    }

    public void CountLevelBlocks() //count the number of blocks we need to break in the scene to progress
    {
        levelBlocks++;
    }

    public void LevelBlockDestroyed()
    {
        levelBlocks--;  //so when a block is hit, decrease the number of level/breakable blocks

        if (levelBlocks <= 0) //if we destroy all blocks (that are possible to destroy in case I add ones that cannot be destroyed)
        {
            sceneLoader.LoadNextScene(); //then load the next scene
        }
    }
}
