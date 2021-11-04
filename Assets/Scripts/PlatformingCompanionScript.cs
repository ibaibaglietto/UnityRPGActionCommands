using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformingCompanionScript : MonoBehaviour
{
    //The player
    private GameObject player;
    //The canvas
    private GameObject canvas;
    //The camera
    private Camera mainCamera;
    //The dialogue after the cutscene
    public Dialogue cutsceneDialogue;

    // Start is called before the first frame update
    void Start()
    {
        //We find the player, the canvas and the camera
        player = GameObject.Find("PlayerWorld");
        canvas = GameObject.Find("Canvas");
        mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            mainCamera.GetComponent<WorldCameraScript>().StartAnimation();
            mainCamera.GetComponent<WorldCameraScript>().SetDialogue(cutsceneDialogue);
            player.GetComponent<WorldPlayerMovementScript>().CutsceneState(true);
            canvas.SetActive(false);
            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
