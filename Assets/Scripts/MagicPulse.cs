using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicPulse : MonoBehaviour
{
    //The number of pulses the magic ball will do
    private int pulseNumb;
    //The user of the magic pulse
    private Transform wizard;

    //Function to create the magic pulse
    public void Create(int numb, Transform companion)
    {
        pulseNumb = numb;
        wizard = companion;
    }

    //Function to deal damage to the enemies
    public void DealDamage()
    {
        wizard.GetComponent<PlayerTeamScript>().MagicSound();
        pulseNumb -= 1;
        //We check if it is the last pulse or not
        if (pulseNumb != 0)
        {
            wizard.GetComponent<PlayerTeamScript>().PulseDamage(false);
        }
        //If it is the last one we destroy the gameobject
        else
        {
            wizard.GetComponent<PlayerTeamScript>().PulseDamage(true);
            wizard.GetComponent<Animator>().SetBool("magicBall", false);
            wizard.GetComponent<PlayerTeamScript>().ReturnStartPos();
            Destroy(gameObject);
        }
    }
}
