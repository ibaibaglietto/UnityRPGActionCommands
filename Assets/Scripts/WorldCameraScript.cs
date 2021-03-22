using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldCameraScript : MonoBehaviour
{
    //The player
    private GameObject player;

    void Start()
    {
        //We find the player
        player = GameObject.Find("PlayerWorld");
        gameObject.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 3.0f, player.transform.position.z - 8.0f);
    }
    private void Update()
    {
        if ((player.GetComponent<WorldPlayerMovementScript>().IsGrounded() && Mathf.Abs((player.transform.position.y + 3.0f) - gameObject.transform.position.y) > 0.15f) || ((player.transform.position.y + 3.0f) < gameObject.transform.position.y - 0.15f))
        {
            gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, new Vector3(player.transform.position.x, player.transform.position.y + 3.0f, player.transform.position.z - 8.0f), Time.deltaTime * 10);
        }
        else gameObject.transform.position = new Vector3(player.transform.position.x, gameObject.transform.position.y, player.transform.position.z - 8.0f);
    }

    void FixedUpdate()
    {
        
    }

}
