using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TpCheckScript : MonoBehaviour
{
    //An int to save the number of colliders in the area
    private int free;
    //A string to know the side of the trigger
    [SerializeField] string side;

    private void Awake()
    {
        free = 0;
    }
    private void FixedUpdate()
    {
        //Debug.Log(side + " " + free);
    }

    //We check the number of colliders inside of the trigger area
    private void OnTriggerEnter(Collider other)
    {
        free += 1;
    }
    private void OnTriggerExit(Collider other)
    {
        free -= 1;
    }
    //If there are not colliders in the area we send that the area is free
    public bool IsFree()
    {
        return free<1;
    }

}
