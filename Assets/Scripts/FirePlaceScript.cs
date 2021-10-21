using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePlaceScript : MonoBehaviour
{
    private GameObject companion;
    //The dialogue
    public Dialogue dialogue;

    void Start()
    {
        companion = GameObject.Find("CompanionWorld");
    }


    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {            
            other.GetComponent<WorldPlayerMovementScript>().SetCanRest(true);
            other.GetComponent<WorldPlayerMovementScript>().SetRestPosition(transform.position.x - 1.531f, transform.position.z + 0.65f);
            other.GetComponent<WorldPlayerMovementScript>().SetFireXPos(transform.position.x);
            other.GetComponent<WorldPlayerMovementScript>().SetFirePlace(gameObject);
            companion.GetComponent<WorldCompanionMovementScript>().SetRestPosition(transform.position.x + 1.531f, transform.position.z + 0.65f);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            other.GetComponent<WorldPlayerMovementScript>().SetCanRest(false);
        }
    }
}
