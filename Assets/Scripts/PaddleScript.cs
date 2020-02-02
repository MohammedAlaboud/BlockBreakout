using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleScript : MonoBehaviour
{
    [SerializeField] float screenWidthUnityUnits = 16f; //width of the screen with the aspect ration I use. Serializable so I can change it from the inspector on the go
    [SerializeField] float minX = 1f; //left bound for the paddle so that no part of it moves out of the screen. not 0 and 16 as paddle has a length of 2
    [SerializeField] float maxX = 15f; //right bound...

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float mousePosition = Input.mousePosition.x / Screen.width * screenWidthUnityUnits; //Find the position of the mouse with respect to the aspect ration defined in the scene
        Vector2 paddlePosition = new Vector2(transform.position.x, transform.position.y); //define the position of the padddle
        paddlePosition.x = Mathf.Clamp(mousePosition, minX, maxX);//limit the movement of the paddle so that it does not go out of bounds
        transform.position = paddlePosition; //move the paddle to paddlePosition
    }
}
