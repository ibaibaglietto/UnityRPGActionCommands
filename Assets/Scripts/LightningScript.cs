﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningScript : MonoBehaviour
{
    private GameObject battleController;

    void Start()
    {
        battleController = GameObject.Find("BattleController");
    }

    //Function to deal damage to the enemies that are touched by the lightning
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("enemy") && collision.GetComponent<EnemyTeamScript>().IsAlive()) battleController.GetComponent<BattleController>().DealDamage(collision.transform, 1, true); 
    }

    //Function to self destroy the lightning
    public void SelfDestroy()
    {
        Destroy(gameObject);
    }
}
