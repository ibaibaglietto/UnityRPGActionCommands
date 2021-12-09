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
    //A vector2(x,z) to know the position the player must move (optional)
    public Vector2 movePos;

    public string[] sentences;
     
    public Dialogue(Transform[] sp, string[] se)
    {
        speakers = sp;
        prevRest = false;
        shop = false;
        prevBattle = false;
        move = false;
        moveDir = 0;
        movePos = new Vector2(0, 0);
        dialogueChanges = null;
        sentences = se;
    }

    public Dialogue(Transform[] sp, string[] se, bool m, int md, Vector2 p)
    {
        speakers = sp;
        prevRest = false;
        shop = false;
        prevBattle = false;
        move = m;
        moveDir = md;
        movePos = p;
        dialogueChanges = null;
        sentences = se;
    }
}
