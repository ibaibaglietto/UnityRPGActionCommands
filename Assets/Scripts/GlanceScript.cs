using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlanceScript : MonoBehaviour
{
    //The adventurer
    private Transform adventurer;

    void Start()
    {
        adventurer = GameObject.Find("Adventurer(Clone)").transform;
    }
    //Function to start the attack action
    public void StartAttackAction()
    {
        adventurer.GetComponent<PlayerTeamScript>().StartAttackAction();
    }

    //Function to end the glance
    public void EndGlance()
    {
        adventurer.GetComponent<PlayerTeamScript>().EndGlance();
    }
}
