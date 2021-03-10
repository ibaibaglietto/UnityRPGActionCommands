using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenSoulScript : MonoBehaviour
{
    //The battle controller
    private GameObject battleController;

    void Start()
    {
        battleController = GameObject.Find("BattleController");
    }

    //Function to save the rings when the green soul crosses them
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag.Equals("Ring"))
        {
            //We check the color of the ring to know if it is a health or a light ring
            if (other.GetComponent<RingScript>().GetColor() && !other.GetComponent<RingScript>().IsCrossed())
            {
                transform.GetChild(0).GetComponent<AudioSource>().Play();
                other.GetComponent<RingScript>().Cross();
                battleController.GetComponent<BattleController>().IncreaseRegenerationHeal();
            }
            if (!other.GetComponent<RingScript>().GetColor() && !other.GetComponent<RingScript>().IsCrossed())
            {
                transform.GetChild(0).GetComponent<AudioSource>().Play();
                other.GetComponent<RingScript>().Cross();
                battleController.GetComponent<BattleController>().IncreaseRegenerationLight();
            }
        }        
    }

}
