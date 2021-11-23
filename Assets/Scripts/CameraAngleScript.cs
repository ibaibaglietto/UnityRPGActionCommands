using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAngleScript : MonoBehaviour
{
    //The Camera
    private GameObject cam;


    void Start()
    {
        cam = GameObject.Find("Main Camera");
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag.Equals("Player"))
        {
            cam.GetComponent<WorldCameraScript>().SetPlatforming(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            cam.GetComponent<WorldCameraScript>().SetPlatforming(false);
        }
    }

}
