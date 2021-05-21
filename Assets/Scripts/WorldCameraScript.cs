using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldCameraScript : MonoBehaviour
{
    //The player
    private GameObject player;
    //The new position of the camera
    private float posY;

    //Camera states in battle
    private bool idle;
    private bool victory;
    private bool idleToVictory;
    private bool victoryToIdle;

    //A bool to know if the camera is in battle or in open world state
    private bool isInBattle;

    void Start()
    {
        //We find the player
        player = GameObject.Find("PlayerWorld");
        gameObject.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 3.0f, player.transform.position.z - 7.0f);
        //The starting variables in battle
        idle = true;
        victory = false;
        idleToVictory = false;
        victoryToIdle = false;
        isInBattle = false;
    }
    private void Update()
    {
        if (!isInBattle)
        {
            if (!player.GetComponent<WorldPlayerMovementScript>().GetMovingToRest() && !player.GetComponent<WorldPlayerMovementScript>().GetResting())
            {
                if (Mathf.Abs(player.GetComponent<Rigidbody>().velocity.y) < 0.1f && player.GetComponent<WorldPlayerMovementScript>().IsGrounded() && ((player.transform.position.y + 3.0f) > (gameObject.transform.position.y + 0.20f))) posY = Vector3.Lerp(gameObject.transform.position, new Vector3(player.transform.position.x, player.transform.position.y + 3.0f, player.transform.position.z - 7.0f), Time.deltaTime * 20).y;
                else if ((player.transform.position.y + 3.0f) < gameObject.transform.position.y - 0.1f) posY = player.transform.position.y + 3.0f;
                else posY = gameObject.transform.position.y;
                gameObject.transform.position = new Vector3(player.transform.position.x, posY, player.transform.position.z - 8.0f);
            }
            else if (player.GetComponent<WorldPlayerMovementScript>().GetMovingToRest()) gameObject.transform.position = new Vector3(player.GetComponent<WorldPlayerMovementScript>().GetFireXPos(), posY, player.transform.position.z - 7.0f);
            else if (player.GetComponent<WorldPlayerMovementScript>().GetResting())
            {
                transform.position = Vector3.Lerp(transform.position, new Vector3(player.GetComponent<WorldPlayerMovementScript>().GetFireXPos(), posY, player.transform.position.z - 5.0f), Time.deltaTime);
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(20, 0, 0), Time.deltaTime);
            }
        }

    }
    private void FixedUpdate()
    {
        if (isInBattle)
        {
            //We can move the camera into two different positions in battle. We move it slowly to the new position.
            if (idleToVictory)
            {
                if (transform.position.x > -5.35f) transform.position = new Vector3(transform.position.x - 0.108f, transform.position.y - 0.005f, transform.position.z + 0.07f);
                else
                {
                    transform.position = new Vector3(-5.4f, 0.0f, -6.5f);
                    victory = true;
                    idleToVictory = false;
                }
            }
            else if (victoryToIdle)
            {
                if (transform.position.x < 0.0f) transform.position = new Vector3(transform.position.x + 0.108f, transform.position.y + 0.005f, transform.position.z - 0.07f);
                else
                {
                    transform.position = new Vector3(0.0f, 0.25f, -10.0f);
                    idle = true;
                    victoryToIdle = false;
                }
            }
        }        
    }

    //Function to change the camera from battle to open world or vice versa
    public void ChangeBattleCamera(bool toBattle)
    {
        isInBattle = toBattle;
        if (isInBattle)
        {
            transform.position = new Vector3(0.0f, 0.25f, -10.0f);
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            transform.position = new Vector3(player.transform.position.x, posY, player.transform.position.z - 8.0f);
            transform.rotation = Quaternion.Euler(5, 0, 0);
        }
    }

    //Function to change the camera state. 0-> Idle, 1-> Victory
    public void ChangeCameraState(int state)
    {
        if (state == 0)
        {
            if (victory)
            {
                victory = false;
                victoryToIdle = true;
            }
        }
        else if (state == 1)
        {
            if (idle)
            {
                idle = false;
                idleToVictory = true;
            }
        }
    }

    //Function to get the camera state
    public int GetCameraState()
    {
        if (idle) return 0;
        else if (victory) return 1;
        else return -1;
    }

}
