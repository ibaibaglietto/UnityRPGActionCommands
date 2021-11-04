using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldCameraScript : MonoBehaviour
{
    //The player
    private GameObject player;
    //The canvas
    private GameObject canvas;
    //The new position of the camera
    private float posY;
    private float posZ;
    //A bool to know if the camera is in platforming state
    private bool platforming;
    //A bool to know if the cutscene has ended
    private bool endCutscene;
    //The dialogue after the cutscene
    private Dialogue cutsceneDialogue;

    //Camera states in battle
    private bool idle;
    private bool victory;
    private bool idleToVictory;
    private bool victoryToIdle;

    //A bool to know if the camera is in battle or in open world state
    private bool isInBattle;

    void Start()
    {
        //We find the player and the canvas
        player = GameObject.Find("PlayerWorld");
        canvas = GameObject.Find("Canvas");
        //We initialize the camera position
        gameObject.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 3.0f, player.transform.position.z - 8.0f);
        //We initialize the variables
        idle = true;
        victory = false;
        idleToVictory = false;
        victoryToIdle = false;
        isInBattle = false;
        platforming = false;
        endCutscene = false;
    }
    private void Update()
    {
        if (!isInBattle)
        {
            if (!player.GetComponent<WorldPlayerMovementScript>().GetMovingToRest() && !player.GetComponent<WorldPlayerMovementScript>().GetResting() && !endCutscene)
            {
                
                if (!platforming)
                {
                    if (Mathf.Abs(player.GetComponent<Rigidbody>().velocity.y) < 0.1f && player.GetComponent<WorldPlayerMovementScript>().IsGrounded() && ((player.transform.position.y + 3.0f) > (gameObject.transform.position.y + 0.20f))) posY = Vector3.Lerp(gameObject.transform.position, new Vector3(player.transform.position.x, player.transform.position.y + 3.0f, player.transform.position.z - 8.0f), Time.deltaTime * 20).y;
                    else if ((player.transform.position.y + 3.1f) < gameObject.transform.position.y - 0.1f) posY = Vector3.Lerp(gameObject.transform.position, new Vector3(player.transform.position.x, player.transform.position.y + 3.0f, player.transform.position.z - 8.0f), Time.deltaTime * 20).y; 
                    else if ((player.transform.position.y + 3.0f) < gameObject.transform.position.y - 0.1f) posY = player.transform.position.y + 3.0f;
                    else posY = gameObject.transform.position.y;
                    if (player.transform.position.z - 8.0f < gameObject.transform.position.z + 0.1f && player.transform.position.z - 8.0f > gameObject.transform.position.z - 0.1f) posZ = player.transform.position.z - 8.0f;
                    else posZ = Vector3.Lerp(transform.position, new Vector3(player.transform.position.x, posY, player.transform.position.z - 8.0f), Time.deltaTime*3).z;
                    transform.position = new Vector3(player.transform.position.x, posY, posZ);
                    transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(5, 0, 0), Time.deltaTime*2);
                }
                else
                {
                    if (Mathf.Abs(player.GetComponent<Rigidbody>().velocity.y) < 0.1f && player.GetComponent<WorldPlayerMovementScript>().IsGrounded() && ((player.transform.position.y + 5.0f) > (gameObject.transform.position.y + 0.20f))) posY = Vector3.Lerp(gameObject.transform.position, new Vector3(player.transform.position.x, player.transform.position.y + 5.0f, player.transform.position.z - 8.0f), Time.deltaTime * 20).y;
                    else if ((player.transform.position.y + 5.0f) < gameObject.transform.position.y - 0.1f) posY = player.transform.position.y + 5.0f;
                    else posY = gameObject.transform.position.y;
                    if(player.transform.position.z - 7.0f < gameObject.transform.position.z + 0.1f && player.transform.position.z - 7.0f > gameObject.transform.position.z - 0.1f) posZ = player.transform.position.z - 7.0f;
                    else posZ = Vector3.Lerp(transform.position, new Vector3(player.transform.position.x, posY, player.transform.position.z - 7.0f), Time.deltaTime*3).z;

                    transform.position = new Vector3(player.transform.position.x, posY, posZ);
                    transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(35, 0, 0), Time.deltaTime*2);
                }
            }
            else if (player.GetComponent<WorldPlayerMovementScript>().GetMovingToRest()) gameObject.transform.position = new Vector3(player.GetComponent<WorldPlayerMovementScript>().GetFireXPos(), posY, player.transform.position.z - 8.0f);
            else if (player.GetComponent<WorldPlayerMovementScript>().GetResting())
            {
                transform.position = Vector3.Lerp(transform.position, new Vector3(player.GetComponent<WorldPlayerMovementScript>().GetFireXPos(), posY, player.transform.position.z - 5.0f), Time.deltaTime);
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(20, 0, 0), Time.deltaTime);
            }
            else if (endCutscene)
            {
                posY = player.transform.position.y + 3.0f;
                posZ = player.transform.position.z - 8.0f;
                transform.position = new Vector3(player.transform.position.x, posY, posZ);
                transform.rotation = Quaternion.Euler(5, 0, 0);
                endCutscene = false;
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
    //Function to start the animation
    public void StartAnimation()
    {
        gameObject.GetComponent<Animator>().enabled = true;
    }

    //Function to end the animation and return to the normal state
    public void EndAnimation()
    {
        gameObject.GetComponent<Animator>().enabled = false;
        player.GetComponent<WorldPlayerMovementScript>().CutsceneState(false);
        canvas.SetActive(true);
        endCutscene = true;
        player.GetComponent<WorldPlayerMovementScript>().StartDialogue(cutsceneDialogue);
    }

    //Function to set the cutscene dialogue
    public void SetDialogue(Dialogue d)
    {
        cutsceneDialogue = d;
    }

    //Function to set the camera to platforming or back to normal
    public void SetPlatforming(bool plat)
    {
        platforming = plat;
    }

    //Function to get the camera state
    public int GetCameraState()
    {
        if (idle) return 0;
        else if (victory) return 1;
        else return -1;
    }

}
