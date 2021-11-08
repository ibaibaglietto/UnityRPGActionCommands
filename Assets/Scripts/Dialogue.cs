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
    //A boolean to know if the player must move after the conversation
    public bool move;
    //An int to know the direction of the movement. 0-> left, 1-> right, 2-> up, 3-> down
    public int moveDir;

    public string[] sentences;
     
    public Dialogue(Transform[] sp, string[] se)
    {
        speakers = sp;
        prevRest = false;
        shop = false;
        prevBattle = false;
        move = false;
        moveDir = 0;
        dialogueChanges = null;
        sentences = se;
    }
}
