﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldConversationScript : MonoBehaviour
{
    //The dialogue
    public Dialogue dialogue;


    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            other.transform.GetComponent<WorldPlayerMovementScript>().StartDialogue(dialogue);
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Player")
        {
            collision.transform.GetComponent<WorldPlayerMovementScript>().SetCanSpeak(true);
            collision.transform.GetComponent<WorldPlayerMovementScript>().SetNextDialogue(dialogue);
            gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.tag == "Player")
        {
            collision.transform.GetComponent<WorldPlayerMovementScript>().SetCanSpeak(false);
        }
    }

}
