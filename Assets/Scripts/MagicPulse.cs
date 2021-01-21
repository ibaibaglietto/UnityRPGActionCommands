using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicPulse : MonoBehaviour
{
    //The number of pulses the magic ball will do
    private int pulseNumb;
    //The user of the magic pulse
    private Transform wizard;

    public void Create(int numb, Transform companion)
    {
        pulseNumb = numb;
        wizard = companion;
    }

    public void DealDamage()
    {
        wizard.GetComponent<PlayerTeamScript>().MagicSound();
        pulseNumb -= 1;
        if (pulseNumb != 0)
        {
            wizard.GetComponent<PlayerTeamScript>().PulseDamage(false);
        }
        else
        {
            wizard.GetComponent<PlayerTeamScript>().PulseDamage(true);
            wizard.GetComponent<Animator>().SetBool("magicBall", false);
            wizard.GetComponent<PlayerTeamScript>().ReturnStartPos();
            Destroy(gameObject);
        }
    }
}
