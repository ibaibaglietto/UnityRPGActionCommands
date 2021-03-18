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
        
    }


    void Update()
    {
        gameObject.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 3.0f, player.transform.position.z - 8.0f);
    }
}
