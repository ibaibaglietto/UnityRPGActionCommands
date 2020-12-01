using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyTeamScript : MonoBehaviour
{
    //The enemy type. 0-> Bandit, 1-> EvilWizard
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
    //An int to see for how much rounds is the enemy asleep
    private int asleep;
    //The gameobject of the asleep UI
    private GameObject buffDebuffUI;
    //An int to see the number of buffs or debuffs
    private int buffDebuffNumb;
    //The position of the slep debuff
    private int sleepPos;
    //The sprite of the sleepUI
    [SerializeField] private Sprite sleepSprite;
    //The dust 
    [SerializeField] private Transform dustObject;
    private Transform dust;
    //The dialogue of the glance action
    public Dialogue dialogue;

    void Start()
    {
        //We find the battle controller and initialize the variables
        battleController = GameObject.Find("BattleController");
        buffDebuffUI = transform.GetChild(0).Find("BuffsDebuffs").gameObject;
        buffDebuffUI.transform.GetChild(0).gameObject.SetActive(false);
        buffDebuffUI.transform.GetChild(1).gameObject.SetActive(false);
        buffDebuffUI.transform.GetChild(2).gameObject.SetActive(false);
        buffDebuffUI.transform.GetChild(3).gameObject.SetActive(false);
        movingToEnemy = false;
        returnStartPos = false;
        alive = true;
        idle = true;
        asleep = 0;
        if (enemyType == 0)
        {
            grounded = true;
            if (PlayerPrefs.GetInt("bandit") == 1) 
            {
                for(int i = 0; i<3; i++)
                {
                    transform.GetChild(0).GetChild(2).GetChild(i).GetComponent<Image>().color = new Color(transform.GetChild(0).GetChild(2).GetChild(i).GetComponent<Image>().color.r, transform.GetChild(0).GetChild(2).GetChild(i).GetComponent<Image>().color.g, transform.GetChild(0).GetChild(2).GetChild(i).GetComponent<Image>().color.b, 1.0f);
                }
                transform.GetChild(0).GetChild(2).GetChild(3).GetComponent<Text>().color = new Color(transform.GetChild(0).GetChild(2).GetChild(3).GetComponent<Text>().color.r, transform.GetChild(0).GetChild(2).GetChild(3).GetComponent<Text>().color.g, transform.GetChild(0).GetChild(2).GetChild(3).GetComponent<Text>().color.b, 1.0f);
            }
            else
            {
                for (int i = 0; i < 3; i++)
                {
                    transform.GetChild(0).GetChild(2).GetChild(i).GetComponent<Image>().color = new Color(transform.GetChild(0).GetChild(2).GetChild(i).GetComponent<Image>().color.r, transform.GetChild(0).GetChild(2).GetChild(i).GetComponent<Image>().color.g, transform.GetChild(0).GetChild(2).GetChild(i).GetComponent<Image>().color.b, 0.0f);
                }
                transform.GetChild(0).GetChild(2).GetChild(3).GetComponent<Text>().color = new Color(transform.GetChild(0).GetChild(2).GetChild(3).GetComponent<Text>().color.r, transform.GetChild(0).GetChild(2).GetChild(3).GetComponent<Text>().color.g, transform.GetChild(0).GetChild(2).GetChild(3).GetComponent<Text>().color.b, 0.0f);
            }
        }
        else if (enemyType == 1)
        {
            grounded = false;
            if (PlayerPrefs.GetInt("wizard") == 1)
            {
                for (int i = 0; i < 3; i++)
                {
                    transform.GetChild(0).GetChild(2).GetChild(i).GetComponent<Image>().color = new Color(transform.GetChild(0).GetChild(2).GetChild(i).GetComponent<Image>().color.r, transform.GetChild(0).GetChild(2).GetChild(i).GetComponent<Image>().color.g, transform.GetChild(0).GetChild(2).GetChild(i).GetComponent<Image>().color.b, 1.0f);
                }
                transform.GetChild(0).GetChild(2).GetChild(3).GetComponent<Text>().color = new Color(transform.GetChild(0).GetChild(2).GetChild(3).GetComponent<Text>().color.r, transform.GetChild(0).GetChild(2).GetChild(3).GetComponent<Text>().color.g, transform.GetChild(0).GetChild(2).GetChild(3).GetComponent<Text>().color.b, 1.0f);
            }
            else
            {
                for (int i = 0; i < 3; i++)
                {
                    transform.GetChild(0).GetChild(2).GetChild(i).GetComponent<Image>().color = new Color(transform.GetChild(0).GetChild(2).GetChild(i).GetComponent<Image>().color.r, transform.GetChild(0).GetChild(2).GetChild(i).GetComponent<Image>().color.g, transform.GetChild(0).GetChild(2).GetChild(i).GetComponent<Image>().color.b, 0.0f);
                }
                transform.GetChild(0).GetChild(2).GetChild(3).GetComponent<Text>().color = new Color(transform.GetChild(0).GetChild(2).GetChild(3).GetComponent<Text>().color.r, transform.GetChild(0).GetChild(2).GetChild(3).GetComponent<Text>().color.g, transform.GetChild(0).GetChild(2).GetChild(3).GetComponent<Text>().color.b, 0.0f);
            }
        }
    }


    void FixedUpdate()
    {
        //If the enemy is a bandit or a wizard
        if(enemyType == 0 || enemyType == 1)
        {
            //We move the enemy to the move position if it has to move towards it
            if (movingToEnemy)
            {
                if (transform.position.x > movePos)
                {
                    transform.position = new Vector3(transform.position.x - 0.10f, transform.position.y, transform.position.z);
                    if(enemyType == 1 && transform.position.y> -0.6f) transform.position = new Vector3(transform.position.x, transform.position.y - 0.0334f, transform.position.z);
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
                    if (enemyType == 1 && transform.position.y < 1.0f) transform.position = new Vector3(transform.position.x, transform.position.y + 0.0334f, transform.position.z);
                    GetComponent<Animator>().SetFloat("Speed", -0.5f);
                }
                else
                {                    
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
        if (enemyType == 1 && !alive && transform.position.y > -0.66f)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - 0.0665f, transform.position.z);
            if (transform.position.y <= -0.66f)
            {
                grounded = true;
                dust = Instantiate(dustObject, new Vector3(transform.position.x + 0.5f, -1.57f, -0.3f), Quaternion.identity);
            }
        }
        if (!alive && grounded)
        {
            if (enemyType == 0)
            {
                if (transform.eulerAngles.x == 0.0f) dust = Instantiate(dustObject, new Vector3(transform.position.x + 0.5f, -1.57f, -0.3f), Quaternion.identity);
                if (transform.eulerAngles.x < 90.0f)
                {
                    transform.rotation = Quaternion.Euler(transform.eulerAngles.x + 1.8f, transform.eulerAngles.y, transform.eulerAngles.z);
                    transform.position = new Vector3(transform.position.x, transform.position.y - 0.04f, transform.position.z);
                    if (transform.eulerAngles.x >= 90.0f) Destroy(dust.gameObject);
                }
            }
            if(enemyType == 1) 
            {
                if (transform.eulerAngles.x < 90.0f)
                {
                    transform.rotation = Quaternion.Euler(transform.eulerAngles.x +1.8f, transform.eulerAngles.y, transform.eulerAngles.z);
                    transform.position = new Vector3(transform.position.x, transform.position.y-0.03f, transform.position.z);
                    if (transform.eulerAngles.x >= 90.0f) Destroy(dust.gameObject);
                }
            }
        }
    }
    //Function to check if the player knows the health of the enemy
    public void KnowHealth()
    {
        if(enemyType == 0)
        {
            if (PlayerPrefs.GetInt("bandit") == 1)
            {
                for (int i = 0; i < 3; i++)
                {
                    transform.GetChild(0).GetChild(2).GetChild(i).GetComponent<Image>().color = new Color(transform.GetChild(0).GetChild(2).GetChild(i).GetComponent<Image>().color.r, transform.GetChild(0).GetChild(2).GetChild(i).GetComponent<Image>().color.g, transform.GetChild(0).GetChild(2).GetChild(i).GetComponent<Image>().color.b, 1.0f);
                }
                transform.GetChild(0).GetChild(2).GetChild(3).GetComponent<Text>().color = new Color(transform.GetChild(0).GetChild(2).GetChild(3).GetComponent<Text>().color.r, transform.GetChild(0).GetChild(2).GetChild(3).GetComponent<Text>().color.g, transform.GetChild(0).GetChild(2).GetChild(3).GetComponent<Text>().color.b, 1.0f);
            }
            else
            {
                for (int i = 0; i < 3; i++)
                {
                    transform.GetChild(0).GetChild(2).GetChild(i).GetComponent<Image>().color = new Color(transform.GetChild(0).GetChild(2).GetChild(i).GetComponent<Image>().color.r, transform.GetChild(0).GetChild(2).GetChild(i).GetComponent<Image>().color.g, transform.GetChild(0).GetChild(2).GetChild(i).GetComponent<Image>().color.b, 0.0f);
                }
                transform.GetChild(0).GetChild(2).GetChild(3).GetComponent<Text>().color = new Color(transform.GetChild(0).GetChild(2).GetChild(3).GetComponent<Text>().color.r, transform.GetChild(0).GetChild(2).GetChild(3).GetComponent<Text>().color.g, transform.GetChild(0).GetChild(2).GetChild(3).GetComponent<Text>().color.b, 0.0f);
            }
        }
        if(enemyType == 1)
        {
            if (PlayerPrefs.GetInt("wizard") == 1)
            {
                for (int i = 0; i < 3; i++)
                {
                    transform.GetChild(0).GetChild(2).GetChild(i).GetComponent<Image>().color = new Color(transform.GetChild(0).GetChild(2).GetChild(i).GetComponent<Image>().color.r, transform.GetChild(0).GetChild(2).GetChild(i).GetComponent<Image>().color.g, transform.GetChild(0).GetChild(2).GetChild(i).GetComponent<Image>().color.b, 1.0f);
                }
                transform.GetChild(0).GetChild(2).GetChild(3).GetComponent<Text>().color = new Color(transform.GetChild(0).GetChild(2).GetChild(3).GetComponent<Text>().color.r, transform.GetChild(0).GetChild(2).GetChild(3).GetComponent<Text>().color.g, transform.GetChild(0).GetChild(2).GetChild(3).GetComponent<Text>().color.b, 1.0f);
            }
            else
            {
                for (int i = 0; i < 3; i++)
                {
                    transform.GetChild(0).GetChild(2).GetChild(i).GetComponent<Image>().color = new Color(transform.GetChild(0).GetChild(2).GetChild(i).GetComponent<Image>().color.r, transform.GetChild(0).GetChild(2).GetChild(i).GetComponent<Image>().color.g, transform.GetChild(0).GetChild(2).GetChild(i).GetComponent<Image>().color.b, 0.0f);
                }
                transform.GetChild(0).GetChild(2).GetChild(3).GetComponent<Text>().color = new Color(transform.GetChild(0).GetChild(2).GetChild(3).GetComponent<Text>().color.r, transform.GetChild(0).GetChild(2).GetChild(3).GetComponent<Text>().color.g, transform.GetChild(0).GetChild(2).GetChild(3).GetComponent<Text>().color.b, 0.0f);
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

    //Function to set the amount of time the enemie will be asleep
    public void SetAsleepTime(int lvl)
    {
        int duration = 0;
        float rand;
        if(enemyType == 0 || enemyType == 1)
        {
            duration = Mathf.FloorToInt((lvl-1) / 2.0f);
            rand = ((lvl-1) / 2.0f) - Mathf.FloorToInt((lvl - 1) / 2.0f);
            if (rand >= Random.Range(0.0f, 1.0f)) duration += 1;
        }
        if(duration > 0) SetBuffDebuff(0, duration);
    }

    //A function to put a buff or a debuff in the UI. buffDeb = 0 -> Sleep
    public void SetBuffDebuff(int buffDeb, int duration)
    {
        if(buffDeb == 0)
        {
            if(asleep == 0)
            {
                GetComponent<Animator>().SetBool("IsAsleep", true);
                sleepPos = 3 - buffDebuffNumb;
                asleep = duration;
                buffDebuffUI.transform.GetChild(sleepPos).gameObject.SetActive(true);
                buffDebuffUI.transform.GetChild(sleepPos).GetChild(0).GetComponent<Image>().sprite = sleepSprite;
                buffDebuffUI.transform.GetChild(sleepPos).GetChild(1).GetComponent<Text>().text = asleep.ToString();
                buffDebuffNumb += 1;
            }
            else
            {
                asleep += duration;
                buffDebuffUI.transform.GetChild(sleepPos).GetChild(1).GetComponent<Text>().text = asleep.ToString();
            }
        }
    }

    private void EndBuffDebuff(int pos)
    {
        if(pos == 0)
        {
            buffDebuffUI.transform.GetChild(0).gameObject.SetActive(false);
            buffDebuffNumb -= 1;
        }
        else if(pos == 1)
        {
            if(buffDebuffNumb > 3)
            {
                buffDebuffUI.transform.GetChild(1).GetChild(0).GetComponent<Image>().sprite = buffDebuffUI.transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite;
                buffDebuffUI.transform.GetChild(1).GetChild(1).GetComponent<Text>().text = buffDebuffUI.transform.GetChild(0).GetChild(1).GetComponent<Text>().text;
                buffDebuffUI.transform.GetChild(0).gameObject.SetActive(false);
                //Change the number of the debuff!!!!!!!!!!!!!!!!!!!
            }
            else buffDebuffUI.transform.GetChild(1).gameObject.SetActive(false);
            buffDebuffNumb -= 1;
        }
        else if (pos == 2)
        {
            if (buffDebuffNumb > 3)
            {
                buffDebuffUI.transform.GetChild(2).GetChild(0).GetComponent<Image>().sprite = buffDebuffUI.transform.GetChild(1).GetChild(0).GetComponent<Image>().sprite;
                buffDebuffUI.transform.GetChild(2).GetChild(1).GetComponent<Text>().text = buffDebuffUI.transform.GetChild(1).GetChild(1).GetComponent<Text>().text;
                buffDebuffUI.transform.GetChild(1).GetChild(0).GetComponent<Image>().sprite = buffDebuffUI.transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite;
                buffDebuffUI.transform.GetChild(1).GetChild(1).GetComponent<Text>().text = buffDebuffUI.transform.GetChild(0).GetChild(1).GetComponent<Text>().text;
                buffDebuffUI.transform.GetChild(0).gameObject.SetActive(false);
                //Change the number of the debuff!!!!!!!!!!!!!!!!!!!
            }
            else if(buffDebuffNumb > 2)
            {
                buffDebuffUI.transform.GetChild(2).GetChild(0).GetComponent<Image>().sprite = buffDebuffUI.transform.GetChild(1).GetChild(0).GetComponent<Image>().sprite;
                buffDebuffUI.transform.GetChild(2).GetChild(1).GetComponent<Text>().text = buffDebuffUI.transform.GetChild(1).GetChild(1).GetComponent<Text>().text;
                buffDebuffUI.transform.GetChild(1).gameObject.SetActive(false);
                //Change the number of the debuff!!!!!!!!!!!!!!!!!!!
            }
            else buffDebuffUI.transform.GetChild(2).gameObject.SetActive(false);
            buffDebuffNumb -= 1;
        }
        else if (pos == 3)
        {
            if (buffDebuffNumb > 3)
            {
                buffDebuffUI.transform.GetChild(3).GetChild(0).GetComponent<Image>().sprite = buffDebuffUI.transform.GetChild(2).GetChild(0).GetComponent<Image>().sprite;
                buffDebuffUI.transform.GetChild(3).GetChild(1).GetComponent<Text>().text = buffDebuffUI.transform.GetChild(2).GetChild(1).GetComponent<Text>().text;
                buffDebuffUI.transform.GetChild(2).GetChild(0).GetComponent<Image>().sprite = buffDebuffUI.transform.GetChild(1).GetChild(0).GetComponent<Image>().sprite;
                buffDebuffUI.transform.GetChild(2).GetChild(1).GetComponent<Text>().text = buffDebuffUI.transform.GetChild(1).GetChild(1).GetComponent<Text>().text;
                buffDebuffUI.transform.GetChild(1).GetChild(0).GetComponent<Image>().sprite = buffDebuffUI.transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite;
                buffDebuffUI.transform.GetChild(1).GetChild(1).GetComponent<Text>().text = buffDebuffUI.transform.GetChild(0).GetChild(1).GetComponent<Text>().text;
                buffDebuffUI.transform.GetChild(0).gameObject.SetActive(false);
                //Change the number of the debuff!!!!!!!!!!!!!!!!!!!
            }
            else if (buffDebuffNumb > 2)
            {
                buffDebuffUI.transform.GetChild(3).GetChild(0).GetComponent<Image>().sprite = buffDebuffUI.transform.GetChild(2).GetChild(0).GetComponent<Image>().sprite;
                buffDebuffUI.transform.GetChild(3).GetChild(1).GetComponent<Text>().text = buffDebuffUI.transform.GetChild(2).GetChild(1).GetComponent<Text>().text;
                buffDebuffUI.transform.GetChild(2).GetChild(0).GetComponent<Image>().sprite = buffDebuffUI.transform.GetChild(1).GetChild(0).GetComponent<Image>().sprite;
                buffDebuffUI.transform.GetChild(2).GetChild(1).GetComponent<Text>().text = buffDebuffUI.transform.GetChild(1).GetChild(1).GetComponent<Text>().text;
                buffDebuffUI.transform.GetChild(1).gameObject.SetActive(false);
                //Change the number of the debuff!!!!!!!!!!!!!!!!!!!
            }
            else if (buffDebuffNumb > 1)
            {
                buffDebuffUI.transform.GetChild(3).GetChild(0).GetComponent<Image>().sprite = buffDebuffUI.transform.GetChild(2).GetChild(0).GetComponent<Image>().sprite;
                buffDebuffUI.transform.GetChild(3).GetChild(1).GetComponent<Text>().text = buffDebuffUI.transform.GetChild(2).GetChild(1).GetComponent<Text>().text;
                buffDebuffUI.transform.GetChild(2).gameObject.SetActive(false);
                //Change the number of the debuff!!!!!!!!!!!!!!!!!!!
            }
            else buffDebuffUI.transform.GetChild(3).gameObject.SetActive(false);
            buffDebuffNumb -= 1;
        }
    }

    //Function to attack an objective
    public void Attack(Transform objective)
    {
        if (asleep == 0)
        {
            attackObjective = objective;
            transform.GetChild(0).transform.GetChild(2).gameObject.SetActive(false);
            //If the enemy is a bandit we make it move towards the player
            if (enemyType == 0 || enemyType == 1)
            {
                startPos = transform.position.x;
                movePos = attackObjective.position.x + 1.1f;
                movingToEnemy = true;
            }
        }
        else
        {            
            asleep -= 1;
            if (asleep == 0)
            {
                EndBuffDebuff(sleepPos);
                GetComponent<Animator>().SetBool("IsAsleep", false);
            }
            else
            {
                buffDebuffUI.transform.GetChild(sleepPos).GetChild(1).GetComponent<Text>().text = asleep.ToString();
            }
            if (enemyNumber < battleController.GetComponent<BattleController>().GetNumberOfEnemies())
            {
                battleController.GetComponent<BattleController>().NextEnemy(enemyNumber);
            }
            else battleController.GetComponent<BattleController>().EndEnemyTurn();
        }
    }

    //A function to save if the player has defended or not
    public void IsDefended(bool defense)
    {
        attacking = false;
        if (defense)
        {
            defended = 1;
            if (!attackObjective.GetComponent<PlayerTeamScript>().IsInvisible()) attackObjective.GetComponent<Animator>().SetBool("isDefending", true);
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
        if (!attackObjective.GetComponent<PlayerTeamScript>().IsInvisible())
        {
            if (defended == 0) attackObjective.GetComponent<Animator>().SetTrigger("takeDamage"); 
            else attackObjective.GetComponent<Animator>().SetBool("isDefending", false);
        }        
        defended = 0;
        gameObject.GetComponent<Animator>().SetBool("IsAttacking", false);
        movingToEnemy = false;
        returnStartPos = true;
    }

    //A function to put the idle boolean false
    public void ReceiveDamage()
    {
        idle = false;
        if (asleep > 0)
        {
            GetComponent<Animator>().SetBool("IsAsleep", false);
            asleep = 0;
            EndBuffDebuff(sleepPos);
        }
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
        GiveXP();
    }

    //A function to give XP
    public void GiveXP()
    {
        if(enemyType == 0)
        {
            if (PlayerPrefs.GetInt("PlayerLvl") == 1)
            {
                battleController.GetComponent<BattleController>().AddXPToCurrent(14);
            }
        }
        else if(enemyType == 1)
        {
            if (PlayerPrefs.GetInt("PlayerLvl") == 1)
            {
                battleController.GetComponent<BattleController>().AddXPToCurrent(15);
            }
        }
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
