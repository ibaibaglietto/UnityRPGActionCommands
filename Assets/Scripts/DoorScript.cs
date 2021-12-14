using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{

    //The current data
    private GameObject currentData;
    //The door 
    private GameObject door;



    void Start()
    {
        //We find the door and the current data
        door = GameObject.Find("Door");
        currentData = GameObject.Find("CurrentData");
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            door.GetComponent<Animator>().SetTrigger("Open");
            currentData.GetComponent<CurrentDataScript>().cityDoorOpen = 1;
        }
    }

}
