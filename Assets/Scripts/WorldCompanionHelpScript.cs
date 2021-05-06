using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldCompanionHelpScript : MonoBehaviour
{
    
    //Function to end the change animation
    public void EndChange()
    {
        GetComponent<Animator>().SetBool("changing", false);
    }
}
