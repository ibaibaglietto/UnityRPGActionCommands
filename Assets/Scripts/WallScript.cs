﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallScript : MonoBehaviour
{
    private Transform previousWall;
    private GameObject battleController;

    private void Start()
    {
        battleController = GameObject.Find("BattleController");
    }

    void Update()
    {
        //If the wall exits the screen we put it after the previous wall
        if(GetComponent<RectTransform>().anchoredPosition.x < -6.5f)
        {
            GetComponent<RectTransform>().anchoredPosition = new Vector2(previousWall.GetComponent<RectTransform>().anchoredPosition.x + 3.0f, Random.Range(-1.5f, 1.5f));
        }
    }
    //Function to set the previous wall
    public void SetPreviousWall(Transform wall)
    {
        previousWall = wall;
    }
    //Function to know if the blue soul hits a wall
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag.Equals("blueSoul"))
        {
            battleController.GetComponent<BattleController>().BadCommand();
            battleController.GetComponent<BattleController>().EndDisappearAttack();
        }
    }
}
