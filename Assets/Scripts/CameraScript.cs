using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    //Camera states
    private bool idle;
    private bool victory;
    private bool idleToVictory;
    private bool victoryToIdle;


    void Start()
    {
        idle = true;
        victory = false;
        idleToVictory = false;
        victoryToIdle = false;
    }

    // Idle -> transform.position = new Vector3(0.0f, 0.25f, -10.0f);
    // Victory ->  transform.position = new Vector3(-5.4f, 0.0f, -6.5f);
    void FixedUpdate()
    {
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

    //Function to change the camera state. 0-> Idle, 1-> Victory
    public void ChangeCameraState(int state)
    {
        if(state == 0)
        {
            if (victory)
            {
                victory = false;
                victoryToIdle = true;
            }
        }
        else if(state == 1)
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
