﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagentaSoulScript : MonoBehaviour
{
    //The battle controller
    private GameObject battleController;
    void Start()
    {
        battleController = GameObject.Find("BattleController");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "magentaShard") Debug.Log("JAJ te mamaste wei");
    }
}
