﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenSoulScript : MonoBehaviour
{
    private GameObject battleController;

    void Start()
    {
        battleController = GameObject.Find("BattleController");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag.Equals("Ring"))
        {
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
