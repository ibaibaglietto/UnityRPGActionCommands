using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerTeamScript : MonoBehaviour
{
    //The prefab of the shuriken
    [SerializeField] private Transform shurikenPrefab;
    //The prefab of the damage UI
    [SerializeField] private Transform damageUI;

    //The shuriken
    private Transform shuriken;
    //The damage image
    private Transform damageImage;
    //The objective of the shuriken
    public Vector3 shurikenObjective;
    //The battle controller
    private GameObject battleController;
    //The player life
    private GameObject playerLife;
    //The damage the shuriken will do
    private int shurikenDamage;
    //A boolean to check if it is the las attack
    private bool lastAttack;
    //The type of the player team user. 0-> Player
    public int playerTeamType; 
    //The start position
    private float startPos;
    //The move position
    private float movePos;
    //A bool to check if the player is moving towards the enemy
    private bool movingToEnemy;
    //A bool to check if the player is returning to the start position
    private bool returnStartPos;
    //The objective of the attack
    private Transform attackObjective;

    void Awake()
    {
        //We find the gameobjects and initialize some booleans
        battleController = GameObject.Find("BattleController");
        playerLife = GameObject.Find("PlayerLifeBckImage");
        lastAttack = false;
        movingToEnemy = false;
        returnStartPos = false;
    }


    void FixedUpdate()
    {
        //The player moves to the enemy to attack it
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
        //The player returns to the start position after attacking
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

    //A function to attack the enemy.type: 0-> melee, 1-> ranged. style: style of melee or ranged attack
    public void Attack(int type, int style, Transform objective)
    {
        //If the one attacking is the player
        if(playerTeamType == 0)
        {
            //We save the objective
            attackObjective = objective;
            //If it is the melee attack
            if (type == 0)
            {
                //To do the normal attack the player needs to move towards the enemy
                if(style == 0)
                {
                    attackObjective.GetChild(0).transform.GetChild(1).gameObject.SetActive(true);
                    startPos = transform.position.x;
                    movePos = attackObjective.position.x - 1.1f;
                    movingToEnemy = true;
                }
            }
            //The shuriken attack
            if(type == 1)
            {
                //To do the normal attack we save the objective and the player starts spinning
                if(style == 0)
                {
                    GetComponent<PlayerTeamScript>().shurikenObjective = attackObjective.position;
                    GetComponent<Animator>().SetBool("isSpinning", true);
                }
            }
        }
    }

    //A function to start the attack action
    public void StartAttackAction()
    {
        battleController.GetComponent<BattleController>().attackAction = true;
    }

    //A function to end the melee attack
    public void EndMeleeAttack()
    {
        //If it was the first attack and the player has done correctly the action command the player attacks again
        if(battleController.GetComponent<BattleController>().goodAttack == true && lastAttack == false)
        {
            lastAttack = true;
            battleController.GetComponent<BattleController>().attackAction = false;
            battleController.GetComponent<BattleController>().DealDamage(battleController.GetComponent<BattleController>().GetSelectedEnemy(), 1, false);
        }
        //else we end the attack and the player goes to the starting position
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
            battleController.GetComponent<BattleController>().DealDamage(battleController.GetComponent<BattleController>().GetSelectedEnemy(), 1, true);
        }        
    }

    //A function to throw a shuriken
    public void ThrowShuriken()
    {
        shuriken = Instantiate(shurikenPrefab, gameObject.transform.position, Quaternion.identity);
        shuriken.GetComponent<ShurikenScript>().SetObjective(shurikenObjective);
        shuriken.GetComponent<ShurikenScript>().SetShurikenDamage(shurikenDamage);
    }
    
    //A function to activate the shuriken action
    public void ShurikenActionActivate()
    {
        gameObject.transform.GetChild(0).transform.GetChild(1).GetComponent<Animator>().SetBool("Active", true);
        battleController.GetComponent<BattleController>().finalAttack = true;
    }

    //A function to end the shuriken throw
    public void EndShurikenThrow()
    {
        battleController.GetComponent<BattleController>().shurikenHit = true;
    }

    //A function to set the shuriken damage
    public void SetShurikenDamage(int damage)
    {
        shurikenDamage = damage;
    }

    //A function to deal damage
    public void DealDamage(int Damage)
    {
        damageImage = Instantiate(damageUI, new Vector3(transform.position.x + 0.25f, transform.position.y + 1.25f, 0), Quaternion.identity, transform.GetChild(0));
        damageImage.GetChild(0).GetComponent<Text>().text = Damage.ToString();
        playerLife.GetComponent<PlayerLifeScript>().DealDamage(Damage);
    }

}
