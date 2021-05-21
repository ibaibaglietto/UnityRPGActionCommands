using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignScript : MonoBehaviour
{
    //The dialogue
    public Dialogue dialogue;

    void Start()
     {

     }


     void Update()
     {

     }
     private void OnTriggerEnter(Collider other)
     {
         if (other.transform.tag == "Player")
         {
            other.GetComponent<WorldPlayerMovementScript>().SetCanSpeak(true);
            other.GetComponent<WorldPlayerMovementScript>().SetNextDialogue(dialogue);
         }
     }

     private void OnTriggerExit(Collider other)
     {
         if (other.transform.tag == "Player")
         {
            other.GetComponent<WorldPlayerMovementScript>().SetCanSpeak(false);
         }
     }

}
