using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTeamScript : MonoBehaviour
{
    [SerializeField] private Transform shurikenPrefab;

    private Transform shuriken;
    public Vector3 shurikenObjective;
    private GameObject battleController;
    private int shurikenDamage;
    private bool lastAttack;
    public int playerTeamType; //0-> Player
    private float startPos;
    private float movePos;
    private bool movingToEnemy;
    private bool returnStartPos;
    private Transform attackObjective;
    // Start is called before the first frame update
    void Awake()
    {
        battleController = GameObject.Find("BattleController");
        lastAttack = false;
        movingToEnemy = false;
        returnStartPos = false;
    }



    // Update is called once per frame
    void FixedUpdate()
    {
        if (movingToEnemy)
        {
            if (transform.position.x < movePos)
            {
                transform.position = new Vector3(transform.position.x + 0.10f, transform.position.y, transform.position.z);
                GetComponent<Animator>().SetFloat("Speed", 0.5f);
            }
            else
            {
                GetComponent<Animator>().SetFloat("Speed", 0.0f);
                movingToEnemy = false;
                battleController.GetComponent<BattleController>().finalAttack = true;
            }
        }
        else if (returnStartPos)
        {
            if (transform.position.x > startPos)
            {
                attackObjective.GetChild(0).transform.GetChild(1).gameObject.GetComponent<Animator>().SetBool("Pressed", false);
                attackObjective.GetChild(0).transform.GetChild(1).gameObject.SetActive(false);
                transform.position = new Vector3(transform.position.x - 0.15f, transform.position.y, transform.position.z);
                GetComponent<Animator>().SetFloat("Speed", 0.5f);
            }
            else
            {

                Vector3 scale = transform.localScale;
                scale.x *= -1;
                transform.localScale = scale;
                GetComponent<Animator>().SetFloat("Speed", 0.0f);
                returnStartPos = false;
                battleController.GetComponent<BattleController>().EndPlayerTurn();
            }
        }
    }

    //type: 0-> melee, 1-> ranged. style: style of melee or ranged attack
    public void Attack(int type, int style, Transform objective)
    {
        if(playerTeamType == 0)
        {
            attackObjective = objective;
            if (type == 0)
            {
                if(style == 0)
                {
                    attackObjective.GetChild(0).transform.GetChild(1).gameObject.SetActive(true);
                    startPos = transform.position.x;
                    movePos = attackObjective.position.x - 1.1f;
                    movingToEnemy = true;
                }
            }
            if(type == 1)
            {
                if(style == 0)
                {
                    GetComponent<PlayerTeamScript>().shurikenObjective = attackObjective.position;
                    GetComponent<Animator>().SetBool("isSpinning", true);
                    battleController.GetComponent<BattleController>().finalAttack = true;
                }
            }
        }
    }

    public void startAttackAction()
    {
        battleController.GetComponent<BattleController>().attackAction = true;
    }

    public void endMeleeAttack()
    {
        if(battleController.GetComponent<BattleController>().goodAttack == true && lastAttack == false)
        {
            lastAttack = true;
            battleController.GetComponent<BattleController>().attackAction = false;
        }
        else
        {
            lastAttack = false;
            battleController.GetComponent<BattleController>().badAttack = false;
            battleController.GetComponent<BattleController>().goodAttack = false;
            battleController.GetComponent<BattleController>().attackAction = false;
            gameObject.GetComponent<Animator>().SetBool("isAttacking", false);
            battleController.GetComponent<BattleController>().finalAttack = false;
            returnStartPos = true;
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }
        battleController.GetComponent<BattleController>().DealDamage(battleController.GetComponent<BattleController>().getSelectedEnemy(), 1);
    }

    
    public void throwShuriken()
    {
        shuriken = Instantiate(shurikenPrefab, gameObject.transform.position, Quaternion.identity);
        shuriken.GetComponent<ShurikenScript>().SetObjective(shurikenObjective);
        shuriken.GetComponent<ShurikenScript>().SetShurikenDamage(shurikenDamage);
    }
    
    public void shurikenActionActivate()
    {
        gameObject.transform.GetChild(0).transform.GetChild(1).GetComponent<Animator>().SetBool("Active", true);
    }
    public void endShurikenThrow()
    {
        battleController.GetComponent<BattleController>().shurikenHit = true;
    }

    public void SetShurikenDamage(int damage)
    {
        shurikenDamage = damage;
    }

}
