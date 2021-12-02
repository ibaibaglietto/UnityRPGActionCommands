using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevivePlayerScript : MonoBehaviour
{
    //The player 
    private GameObject player;
    //The dialogue that will play after the player is revived
    public Dialogue reviveDialogue;
    //The dialogue that will play after the player and the adventurer go to the button
    public Dialogue buttonDialogue;
    //The camera
    private Camera mainCamera;
    //The current data
    private GameObject currentData;

    void Start()
    {
        //We find the player the camera, the canvas and the change scene screen
        player = GameObject.Find("PlayerWorld");
        mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
        currentData = GameObject.Find("CurrentData");
    }

    //A function to put the player in cutscene mode
    public void StartCutscene()
    {
        mainCamera.GetComponent<Animator>().enabled = true;
        player.GetComponent<WorldPlayerMovementScript>().CutsceneState(true);
    }

    //A function to end the cutscene mode
    public void EndCutscene()
    {
        currentData.GetComponent<CurrentDataScript>().tutorialState += 1;
        mainCamera.GetComponent<Animator>().enabled = false;
        player.GetComponent<WorldPlayerMovementScript>().CutsceneState(false);
        player.GetComponent<WorldPlayerMovementScript>().StartDialogue(buttonDialogue);
    }

    //A function to revive the player
    public void RevivePlayer()
    {
        player.GetComponent<WorldPlayerMovementScript>().RevivePlayer();
        player.GetComponent<WorldPlayerMovementScript>().SetNextDialogue(reviveDialogue);
    }

    public void SelfDestroy()
    {
        Destroy(gameObject);
    }

    //Function to make the adventurer look left
    public void LookLeft()
    {
        transform.GetChild(0).GetComponent<NPCScript>().LookLeft();
    }

    //Function to make the adventurer look right
    public void LookRight()
    {
        transform.GetChild(0).GetComponent<NPCScript>().LookRight();
    }

    //Function to make the adventurer run left
    public void RunLeft()
    {
        transform.GetChild(0).GetComponent<NPCScript>().RunLeft();
    }

    //Function to make the adventurer stop running
    public void StopRunning()
    {
        transform.GetChild(0).GetComponent<NPCScript>().StopRunning();
    }

    //Function to make the adventurer run right
    public void RunRight()
    {
        transform.GetChild(0).GetComponent<NPCScript>().RunRight();
    }
}
