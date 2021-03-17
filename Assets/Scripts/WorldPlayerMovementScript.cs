using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldPlayerMovementScript : MonoBehaviour
{
    //The direction the player is moving. 0-> not moving, 1-> right, 2-> left, 3 -> up, 4 -> down
    private float speedX;
    private float speedZ;
    void Start()
    {
        //We initialize the variables
        speedX = 0.0f;
        speedZ = 0.0f;
    }


    void Update()
    {
        //Detect the direction we want the player to move and save it
        if (Input.GetKey(KeyCode.UpArrow)) speedZ = 1.0f;
        else if (Input.GetKey(KeyCode.DownArrow)) speedZ = -1.0f;
        else speedZ = 0.0f;
        if (Input.GetKey(KeyCode.RightArrow)) speedX = 1.0f;
        else if (Input.GetKey(KeyCode.LeftArrow)) speedX = -1.0f;
        else speedX = 0.0f;
        if(speedX!=0 || speedZ!=0) gameObject.GetComponent<Animator>().SetBool("Moving", true);
        else gameObject.GetComponent<Animator>().SetBool("Moving", false);
        gameObject.GetComponent<Animator>().SetFloat("SpeedZ", speedZ);
        gameObject.GetComponent<Animator>().SetFloat("SpeedX", speedX);
        //Make the player jump when space is pressed
        if (Input.GetKeyDown(KeyCode.Space)) gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0.0f,300.0f,0.0f));
    }

    private void FixedUpdate()
    {
        //move the player on the direction we saved previously
        gameObject.GetComponent<Rigidbody>().velocity = new Vector3(speedX * 3, gameObject.GetComponent<Rigidbody>().velocity.y, speedZ * 3);
    }
}
