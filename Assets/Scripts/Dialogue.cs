using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
    //Name of the speaker
    public Transform speaker;

    //A boolean to know if the dialogue is previous a rest or not
    public bool prevRest;
    //A boolean to know if the dialogue is in a shop
    public bool shop;

    public string[] sentences;
     
    public Dialogue(Transform sp, string[] se)
    {
        speaker = sp;
        prevRest = false;
        shop = false;
        sentences = se;
    }
}
