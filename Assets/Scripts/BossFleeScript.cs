using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFleeScript : MonoBehaviour
{
    //The player 
    private GameObject player;
    //The dialogue that will play after the miniboss flees
    public Dialogue dialogue;

    void Start()
    {
        //We find the player
        player = GameObject.Find("PlayerWorld");

    }

    //A function to put the player in cutscene mode
    public void StartCutscene()
    {
        player.GetComponent<WorldPlayerMovementScript>().CutsceneState(true);
    }

    //A function to end the cutscene mode
    public void EndCutscene()
    {
        player.GetComponent<WorldPlayerMovementScript>().CutsceneState(false);
        player.GetComponent<WorldPlayerMovementScript>().StartDialogue(dialogue);
    }


    public void SelfDestroy()
    {
        Destroy(gameObject);
    }

    //Function to make the bandits run left
    public void RunLeft()
    {
        transform.GetChild(0).GetComponent<NPCScript>().RunLeft();
        transform.GetChild(1).GetComponent<NPCScript>().RunLeft();
    }

    //Function to make the bandits stop running
    public void StopRunning()
    {
        transform.GetChild(0).GetComponent<NPCScript>().StopRunning();
        transform.GetChild(1).GetComponent<NPCScript>().StopRunning();
    }

    //Function to make the bandits run right
    public void RunRight()
    {
        transform.GetChild(0).GetComponent<NPCScript>().RunRight();
        transform.GetChild(1).GetComponent<NPCScript>().RunRight();
    }
}
