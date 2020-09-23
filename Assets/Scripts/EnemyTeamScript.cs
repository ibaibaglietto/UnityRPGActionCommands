using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTeamScript : MonoBehaviour
{
    //The enemy type. 0-> Bandit
    public int enemyType; 
    //The objective of the attack
    private Transform attackObjective;
    //The starting position
    private float startPos;
    //The movement position
    private float movePos;
    //A boolean to check if the player is moving to the enemy
    private bool movingToEnemy;
    //A boolean to check if the player is returning to the start position
    private bool returnStartPos;
    //An int to check if the player has defended
    private int defended;
    //The battle controller
    private GameObject battleController;
    //The number of the enemy
    private int enemyNumber;
    //A bool to check if the player is alive
    private bool alive;
    //A bool to check if the player is attacking
    private bool attacking;
    //A bool to check if the player is idle
    private bool idle;
    //A bool to know if the enemy is on the ground
    private bool grounded;

    void Start()
    {
        //We find the battle controller and initialize the variables
        battleController = GameObject.Find("BattleController");
        movingToEnemy = false;
        returnStartPos = false;
        alive = true;
        idle = true;
        if (enemyType == 0) grounded = true;
    }


    void FixedUpdate()
    {
        //If the enemy is a bandit
        if(enemyType == 0)
        {
            //We move the enemy to the move position if it has to move towards it
            if (movingToEnemy)
            {
                if (transform.position.x > movePos)
                {
                    transform.position = new Vector3(transform.position.x - 0.10f, transform.position.y, transform.position.z);
                    GetComponent<Animator>().SetFloat("Speed", 0.5f);
                }
                else
                {
                    attacking = true;
                    GetComponent<Animator>().SetFloat("Speed", 0.0f);
                    movingToEnemy = false;
                    GetComponent<Animator>().SetBool("IsAttacking", true);
                }
            }
            //We move the enemy to the start position after it attacks
            else if (returnStartPos)
            {
                if (transform.position.x < startPos)
                {
                    transform.position = new Vector3(transform.position.x + 0.15f, transform.position.y, transform.position.z);
                    GetComponent<Animator>().SetFloat("Speed", 0.5f);
                }
                else
                {
                    Vector3 scale = transform.localScale;
                    scale.x *= -1;
                    transform.localScale = scale;
                    GetComponent<Animator>().SetFloat("Speed", 0.0f);
                    returnStartPos = false;
                    transform.GetChild(0).transform.GetChild(2).gameObject.SetActive(true);
                    if (enemyNumber < battleController.GetComponent<BattleController>().GetNumberOfEnemies())
                    {
                        battleController.GetComponent<BattleController>().NextEnemy(enemyNumber);
                    }
                    else battleController.GetComponent<BattleController>().EndEnemyTurn();
                }
            }
        }        
    }
    //Function to know if the enemy is on the ground
    public bool IsGrounded()
    {
        return grounded;
    }

    //Function to start the defense zone
    public void StartDefenseZone()
    {
        battleController.GetComponent<BattleController>().StartDefenseZone();
    }

    //Function to end the defense zone
    public void EndDefenseZone()
    {
        battleController.GetComponent<BattleController>().EndDefenseZone();
    }

    //Function to attack an objective
    public void Attack(Transform objective)
    {
        attackObjective = objective;
        transform.GetChild(0).transform.GetChild(2).gameObject.SetActive(false);
        //If the enemy is a bandit we make it move towards the player
        if(enemyType == 0)
        {
            startPos = transform.position.x;
            movePos = attackObjective.position.x + 1.1f;
            movingToEnemy = true;
        }
    }

    //A function to save if the player has defended or not
    public void IsDefended(bool defense)
    {
        attacking = false;
        if (defense)
        {
            defended = 1;
            attackObjective.GetComponent<Animator>().SetBool("isDefending", true);
        }
        else
        {
            defended = 0;
        }  
    }

    //A function to end the melee attack and start moving back to the start position
    public void EndMeleeAttack()
    {
        attacking = false;
        attackObjective.GetComponent<PlayerTeamScript>().DealDamage(2-defended);
        if(defended == 0) attackObjective.GetComponent<Animator>().SetTrigger("takeDamage");    
        else attackObjective.GetComponent<Animator>().SetBool("isDefending", false);
        defended = 0;
        gameObject.GetComponent<Animator>().SetBool("IsAttacking", false);
        movingToEnemy = false;
        returnStartPos = true;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    //A function to put the idle boolean false
    public void ReceiveDamage()
    {
        idle = false;
    }

    //A function to put the idle boolean true
    public void BeIdle()
    {
        idle = true;
    }

    //A function to check if the enemy is idle
    public bool IsIdle()
    {
        return idle;
    }

    //A function to set the enemy number
    public void SetNumber(int number)
    {
        enemyNumber = number;
    }

    //A function to save that an enemy is dead
    public void EnemyDied()
    {
        idle = true;
        alive = false;
    }

    //A function to check if the enemy is alive
    public bool IsAlive()
    {
        return alive;
    }

    //A function to check if the enemy is attacking
    public bool IsAttacking()
    {
        return attacking;
    }

}
