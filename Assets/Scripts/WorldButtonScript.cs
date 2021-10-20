using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldButtonScript : MonoBehaviour
{
    [SerializeField] private GameObject gate;
    public Material pressed;
    //The player
    private GameObject player;
    //The dialogue
    public Dialogue dialogue;

    void Start()
    {
        //We find the player
        player = GameObject.Find("PlayerWorld");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "shuriken")
        {
            gate.GetComponent<Animator>().SetTrigger("Open");
            GetComponent<MeshRenderer>().material = pressed;
            other.GetComponent<WorldShurikenScript>().SelfDestroy();
            player.GetComponent<WorldPlayerMovementScript>().StartDialogue(dialogue);
        }
    }
}
