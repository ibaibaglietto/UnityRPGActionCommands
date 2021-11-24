using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFleeScript : MonoBehaviour
{
    //The player 
    private GameObject player;
    //The dialogue that will play after the miniboss flees
    public Dialogue dialogue;
    //The camera
    private Camera mainCamera;
    //The canvas
    private Canvas canvas;
    //The change scene screen 
    private GameObject changeSceneScreen;
    //The current data
    private GameObject currentData;

    void Start()
    {
        //We find the player the camera, the canvas and the change scene screen
        player = GameObject.Find("PlayerWorld");
        mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
        canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        currentData = GameObject.Find("CurrentData");
        changeSceneScreen = GameObject.Find("EndBattleImage");
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

    //Function to make the enemies run left
    public void RunLeft()
    {
        transform.GetChild(0).GetComponent<NPCScript>().RunLeft();
        transform.GetChild(1).GetComponent<NPCScript>().RunLeft();
    }

    //Function to make the enemies stop running
    public void StopRunning()
    {
        transform.GetChild(0).GetComponent<NPCScript>().StopRunning();
        transform.GetChild(1).GetComponent<NPCScript>().StopRunning();
    }

    //Function to make the enemies run right
    public void RunRight()
    {
        transform.GetChild(0).GetComponent<NPCScript>().RunRight();
        transform.GetChild(1).GetComponent<NPCScript>().RunRight();
    }

    //Function to make the camera move
    public void MoveCamera()
    {
        mainCamera.GetComponent<Animator>().enabled = true;
    }

    //Function to make the title appear
    public void AppearTitle()
    {
        canvas.transform.Find("Title").GetComponent<Animator>().SetBool("Show", true);
    }

    //Function to TP the player to the jail
    public void TPJail()
    {
        changeSceneScreen.GetComponent<Animator>().SetTrigger("toOther");
        changeSceneScreen.GetComponent<EnterBattleScript>().SetSceneName("1-1");
        currentData.GetComponent<CurrentDataScript>().spawnX = 8.14f;
        currentData.GetComponent<CurrentDataScript>().spawnY = 139.507f;
        currentData.GetComponent<CurrentDataScript>().spawnZ = -1.609f;
    }

    //Function to make the knights roll right
    public void RollRight()
    {
        transform.GetChild(0).GetComponent<NPCScript>().RollRight();
        transform.GetChild(1).GetComponent<NPCScript>().RollRight();
        transform.GetChild(2).GetComponent<WorldEnemy>().SetRolling(true);
    }

    //Function to make the knights roll left
    public void RollLeft()
    {
        transform.GetChild(0).GetComponent<NPCScript>().RollLeft();
        transform.GetChild(1).GetComponent<NPCScript>().RollLeft();
        transform.GetChild(2).GetComponent<WorldEnemy>().SetRolling(false);
    }

}
