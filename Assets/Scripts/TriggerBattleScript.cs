using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBattleScript : MonoBehaviour
{
    //The player
    private GameObject player;
    //The dialogue
    public Dialogue dialogue;
    //The other trigger
    public GameObject otherTrigger;

    void Start()
    {
        //We find the player
        player = GameObject.Find("PlayerWorld");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (player.transform.position.x>dialogue.speakers[0].position.x) dialogue.speakers[0].GetComponent<Animator>().SetBool("FacingRight", true);
            else dialogue.speakers[0].GetComponent<Animator>().SetBool("FacingRight", false);
            player.GetComponent<WorldPlayerMovementScript>().StartDialogue(dialogue);
            Destroy(gameObject);
            if (otherTrigger != null) Destroy(otherTrigger);
        }
    }
}
