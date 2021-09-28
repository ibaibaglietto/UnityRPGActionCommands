using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAngleScript : MonoBehaviour
{
    //The player
    private GameObject cam;


    void Start()
    {
        cam = GameObject.Find("Main Camera");
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            cam.GetComponent<WorldCameraScript>().SetPlatforming(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            cam.GetComponent<WorldCameraScript>().SetPlatforming(false);
        }
    }

}
