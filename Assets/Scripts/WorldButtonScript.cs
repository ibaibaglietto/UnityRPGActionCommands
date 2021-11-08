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
    //The flag
    public string flag;
    //The current data
    private GameObject currentData;

    void Start()
    {
        //We find the player and the current data
        player = GameObject.Find("PlayerWorld");
        currentData = GameObject.Find("CurrentData");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "shuriken")
        {
            gate.GetComponent<Animator>().SetTrigger("Open");
            GetComponent<MeshRenderer>().material = pressed;
            other.GetComponent<WorldShurikenScript>().SelfDestroy();
            player.GetComponent<WorldPlayerMovementScript>().StartDialogue(dialogue);
            if(flag != "") currentData.GetComponent<CurrentDataScript>().SetFlag(flag);
        }
    }
}
