using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
    //The speakers
    public Transform[] speakers;
    //The dialogue number where the speaker changes
    public int[] dialogueChanges;

    //A boolean to know if the dialogue is previous a rest or not
    public bool prevRest;
    //A boolean to know if the dialogue is in a shop
    public bool shop;
    //A boolean to know if the dialogue is previous a battle
    public bool prevBattle;

    public string[] sentences;
     
    public Dialogue(Transform[] sp, string[] se)
    {
        speakers = sp;
        prevRest = false;
        shop = false;
        prevBattle = false;
        dialogueChanges = null;
        sentences = se;
    }
}
