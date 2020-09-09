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
    private bool hasDefended;
    private GameObject battleController;
    private GameObject playerLife;

    // Start is called before the first frame update
    void Start()
    {
        battleController = GameObject.Find("BattleController");
        playerLife = GameObject.Find("PlayerLifeBckImage");
        movingToEnemy = false;
        returnStartPos = false;
        hasDefended = false;
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
                    battleController.GetComponent<BattleController>().EndEnemyTurn();
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
        if (!hasDefended)
        {
            if (defense)
            {
                hasDefended = true;
                defended = 1;
                attackObjective.GetComponent<Animator>().SetBool("isDefending", true);
            }
            else
            {
                hasDefended = true;
                defended = 0;
            }
        }        
    }

    public void endMeleeAttack()
    {
        hasDefended = false;
        playerLife.GetComponent<PlayerLifeScript>().DealDamage(2-defended);
        if(defended == 0) attackObjective.GetComponent<Animator>().SetTrigger("takeDamage");    
        else attackObjective.GetComponent<Animator>().SetBool("isDefending", false);
        gameObject.GetComponent<Animator>().SetBool("IsAttacking", false);
        movingToEnemy = false;
        returnStartPos = true;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

}
