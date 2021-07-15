﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class ShurikenScript : MonoBehaviour
{
    //The objective of the shuriken
    private Transform objective;
    //The objectives of the fire shuriken
    private Transform[] fireObjectives;
    //The battle controller
    private GameObject battleController;
    //The damage of the shuriken
    private int shurikenDamage;
    //A boolean to know if the shuriken is a fire shuriken
    private bool fire;
    //An int to know the number of enemies hit
    private int hit;
    //A boolean to know if the bullet is thrown by the BK47
    private bool BK47;
    //A float to save the rotation of the bk47 arrow
    private float rotation;
    //A boolean to know if the bullet is a magic ball
    private bool magic;
    //A boolean to know if the magic ball has exploded
    private bool exploded;

    private void Awake()
    {
        //We find the battle controller
        battleController = GameObject.Find("BattleController");
        //We initialize the hit int
        hit = 0;
        BK47 = false;
        magic = false;
        exploded = false;
        rotation = 0.0f;
    }

    void FixedUpdate()
    {
        if (!BK47)
        {
            //if the shuriken hasn't arrived to the objective it keeps moving
            if ((gameObject.transform.position.x < objective.position.x && !fire) || (gameObject.transform.position.x < 12.0f && fire)) gameObject.transform.position = new Vector3(gameObject.transform.position.x + 0.39f * Mathf.Cos(rotation), gameObject.transform.position.y + 0.39f * Mathf.Sin(rotation), gameObject.transform.position.z);
            //When the shuriken arrives it deals damage and self destroys
            else
            {
                //We deal the damage
                if (!fire && !exploded)
                {
                    if (objective.GetComponent<EnemyTeamScript>().enemyType == 3 && objective.GetComponent<EnemyTeamScript>().IsShielded())
                    {
                        if (shurikenDamage == 1) battleController.GetComponent<BattleController>().FillSouls(0.05f);
                        else if (shurikenDamage == 2) battleController.GetComponent<BattleController>().FillSouls(0.15f);
                        else battleController.GetComponent<BattleController>().FillSouls(0.2f);
                    }
                    else
                    {
                        if (shurikenDamage == 1) battleController.GetComponent<BattleController>().FillSouls(0.1f);
                        else if (shurikenDamage == 2) battleController.GetComponent<BattleController>().FillSouls(0.3f);
                        else battleController.GetComponent<BattleController>().FillSouls(0.4f);
                    }
                    battleController.GetComponent<BattleController>().DealDamage(battleController.GetComponent<BattleController>().GetSelectedEnemy(), shurikenDamage, true);
                }
                //We destroy the projectile
                if (!magic) Destroy(gameObject);
                //Else we explode it
                else
                {
                    exploded = true;
                    GetComponent<Animator>().SetTrigger("explode");
                }
            }
            //If the projectile will hit more than one enemy we count the hit and continue moving it
            if (fire && fireObjectives.Length > hit && gameObject.transform.position.x > (fireObjectives[hit].transform.position.x - 0.2f) && gameObject.transform.position.x <= (fireObjectives[hit].transform.position.x + 0.2f))
            {
                battleController.GetComponent<BattleController>().DealDamage(fireObjectives[hit], shurikenDamage, true);
                if (fireObjectives[hit].GetComponent<EnemyTeamScript>().enemyType == 3 && fireObjectives[hit].GetComponent<EnemyTeamScript>().IsShielded())
                {
                    if (shurikenDamage == 1) battleController.GetComponent<BattleController>().FillSouls(0.037f);
                    else battleController.GetComponent<BattleController>().FillSouls(0.075f);
                    Destroy(gameObject);
                }
                else
                {
                    if (shurikenDamage == 1) battleController.GetComponent<BattleController>().FillSouls(0.075f);
                    else battleController.GetComponent<BattleController>().FillSouls(0.15f);
                    hit += 1;
                }
            }
        }
        //If it is a bk-47 projectile 
        else
        {
            //We move it depending on the rotation
            if(gameObject.transform.position.x < 10.0f) gameObject.transform.position = new Vector3(gameObject.transform.position.x + 0.39f * Mathf.Cos(rotation), gameObject.transform.position.y + 0.39f * Mathf.Sin(rotation), gameObject.transform.position.z);
            //we destroy it if it gets too far away
            else Destroy(gameObject);
        }      
        
    }
    //Function to know when a BK-47 arrow hits an enemy
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(BK47 && collision.tag.Equals("enemy") && collision.GetComponent<EnemyTeamScript>().IsAlive())
        {
            battleController.GetComponent<BattleController>().DealDamage(collision.transform, shurikenDamage, true);
            if (collision.GetComponent<EnemyTeamScript>().enemyType == 3 && collision.GetComponent<EnemyTeamScript>().IsShielded()) battleController.GetComponent<BattleController>().FillSouls(0.05f); 
            else battleController.GetComponent<BattleController>().FillSouls(0.1f); 
            Destroy(gameObject);
        }
    }

    //A function to set the objective
    public void SetObjective(Transform obj)
    {
        if (!BK47 && !fire)
        {
            objective = obj;
            rotation = Mathf.Atan2(objective.position.y - transform.position.y, objective.position.x - transform.position.x);
            transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotation * Mathf.Rad2Deg);
        } 
        else if (fire)
        {
            objective = obj;
        }
    }
    //A function to set the objectives of the fire shuriken
    public void SetFireObjectives(Transform[] objs)
    {
        fireObjectives = objs;
    }

    //A function to set the shuriken damage
    public void SetShurikenDamage(int damage)
    {
        shurikenDamage = damage;
    }

    //Function to set the shuriken on fire
    public void OnFireShuriken(bool onFire)
    {
        fire = onFire;
    }

    //Function to set the magic ball
    public void SetMagic()
    {
        magic = true;
    }

    //Function to set the bk47 mode
    public void SetBK47(float rot)
    {
        rotation = rot;
        BK47 = true;
    }
    //Function to self destroy
    public void SelfDestroy()
    {
        Destroy(gameObject);
    }

}
