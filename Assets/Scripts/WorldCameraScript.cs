using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldCameraScript : MonoBehaviour
{
    //The player
    private GameObject player;
    //The new position of the camera
    private float posY;

    void Start()
    {
        //We find the player
        player = GameObject.Find("PlayerWorld");
        gameObject.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 3.0f, player.transform.position.z - 8.0f);
    }
    private void Update()
    {
        if (Mathf.Abs(player.GetComponent<Rigidbody>().velocity.y)<0.1f && player.GetComponent<WorldPlayerMovementScript>().IsGrounded() && ((player.transform.position.y + 3.0f) > (gameObject.transform.position.y + 0.20f))) posY = Vector3.Lerp(gameObject.transform.position, new Vector3(player.transform.position.x, player.transform.position.y + 3.0f, player.transform.position.z - 8.0f), Time.deltaTime * 20).y; 
        else if ((player.transform.position.y + 3.0f) < gameObject.transform.position.y - 0.1f) posY = player.transform.position.y + 3.0f; 
        else posY = gameObject.transform.position.y;
        gameObject.transform.position = new Vector3(player.transform.position.x, posY, player.transform.position.z - 8.0f);
    }

    void FixedUpdate()
    {
        
    }

}
