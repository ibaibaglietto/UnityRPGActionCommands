using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTeamScript : MonoBehaviour
{
    public int enemyType; //0-> Bandit
    private Transform attackObjective;
    private float startPos;
    private float movePos;
    private bool movingToEnemy;
    private bool returnStartPos;
    private int defended;
    private GameObject battleController;
    private int enemyNumber;
    private bool alive;
    private bool attacking;

    // Start is called before the first frame update
    void Start()
    {
        battleController = GameObject.Find("BattleController");
        movingToEnemy = false;
        returnStartPos = false;
        alive = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(enemyType == 0)
        {
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

    public void StartDefenseZone()
    {
        battleController.GetComponent<BattleController>().StartDefenseZone();
    }

    public void EndDefenseZone()
    {
        battleController.GetComponent<BattleController>().EndDefenseZone();
    }

    public void Attack(Transform objective)
    {
        attackObjective = objective;
        transform.GetChild(0).transform.GetChild(2).gameObject.SetActive(false);
        if(enemyType == 0)
        {
            startPos = transform.position.x;
            movePos = attackObjective.position.x + 1.1f;
            movingToEnemy = true;
        }
    }

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

    public void endMeleeAttack()
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

    public void SetNumber(int number)
    {
        enemyNumber = number;
    }
    public void EnemyDied()
    {
        alive = false;
    }

    public bool isAlive()
    {
        return alive;
    }

    public bool isAttacking()
    {
        return attacking;
    }

}
