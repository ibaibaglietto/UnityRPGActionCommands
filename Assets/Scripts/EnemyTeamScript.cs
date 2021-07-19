using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyTeamScript : MonoBehaviour
{
    //The enemy type. 0-> Bandit, 1-> EvilWizard
    public int enemyType; 
    //The objective of the attack when it hits all the team
    private Transform[] attackTeam;
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
    //An int to know for how much rounds is the enemy stunned
    private int stunned;
    //An int to see for how much rounds is the enemy asleep
    private int asleep;
    //The gameobject of the asleep UI
    private GameObject buffDebuffUI;
    //An int to see the number of buffs or debuffs
    private int buffDebuffNumb;
    //The position of the slep debuff
    private int sleepPos;
    //A boolean to know if the enemy is returning to the normal height
    private bool returnHeight;
    //The sprite of the sleepUI
    [SerializeField] private Sprite sleepSprite;
    //The dust 
    [SerializeField] private Transform dustObject;
    private Transform dust;
    //The dialogue of the glance action
    public Dialogue dialogue;
    //A float to save the x of the teleportation
    private float teleportPos;
    //A bool to know that the next attack is a ground attack
    private bool groundAttack;
    //A bool to know that if the knight has the shield up
    private bool shield = false;
    //The audio source of the enemy
    private AudioSource enemySource;
    //A boolean to know if the die animation has finished
    private bool dieAnimationFinished;
    //The main audios
    [SerializeField] private AudioClip attackAudio;
    [SerializeField] private AudioClip hitAudio;
    [SerializeField] private AudioClip dieAudio;
    [SerializeField] private AudioClip bossSecondAttackAudio;
    [SerializeField] private AudioClip bossChargeGroundAttackAudio;
    [SerializeField] private AudioClip bossGroundAttackAudio;
    [SerializeField] private AudioClip bossTeleportAudio;
    [SerializeField] private AudioClip bossPowerUpAudio;
    //The current data
    private GameObject currentData;

    void Start()
    {
        currentData = GameObject.Find("CurrentData");
        //We find the battle controller and initialize the variables
        battleController = GameObject.Find("BattleController");
        buffDebuffUI = transform.GetChild(0).Find("BuffsDebuffs").gameObject;
        enemySource = transform.Find("EnemySource").GetComponent<AudioSource>();
        buffDebuffUI.transform.GetChild(0).gameObject.SetActive(false);
        buffDebuffUI.transform.GetChild(1).gameObject.SetActive(false);
        buffDebuffUI.transform.GetChild(2).gameObject.SetActive(false);
        buffDebuffUI.transform.GetChild(3).gameObject.SetActive(false);
        movingToEnemy = false;
        returnStartPos = false;
        alive = true;
        idle = true;
        asleep = 0;
        dieAnimationFinished = false;
        groundAttack = false;
        returnHeight = false;
        attackTeam = new Transform[1];
        //Bandit
        if (enemyType == 0)
        {
            grounded = true;
            //We check if the player already knows the health points of this enemy
            if (currentData.GetComponent<CurrentDataScript>().bandit == 1) 
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
        //Evil wizard
        else if (enemyType == 1)
        {
            grounded = false;
            //We check if the player already knows the health points of this enemy
            if (currentData.GetComponent<CurrentDataScript>().wizard == 1)
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
        //King
        if (enemyType == 2)
        {
            grounded = true;
            //We check if the player already knows the health points of this enemy
            if (currentData.GetComponent<CurrentDataScript>().king == 1)
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
        //Knight
        if (enemyType == 3)
        {
            grounded = true;
            //We check if the player already knows the health points of this enemy
            if (currentData.GetComponent<CurrentDataScript>().knight == 1)
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
        if (enemyType == 0 || enemyType == 1 || enemyType == 2 || enemyType == 3)
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
                    if(enemyType != 2)
                    {
                        enemySource.clip = attackAudio;
                        enemySource.Play();
                    }
                    attacking = true;
                    GetComponent<Animator>().SetFloat("Speed", 0.0f);
                    movingToEnemy = false;
                    if (enemyType == 3 && Random.Range(0.0f, 1.0f) < 0.4f) GetComponent<Animator>().SetBool("IsTripleAttack",true);
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
                    //When the enemy returns to the starting pos we ensure that they are in the correct position
                    transform.position = new Vector3(startPos, transform.position.y, transform.position.z);
                    GetComponent<Animator>().SetFloat("Speed", 0.0f);
                    returnStartPos = false;
                    transform.GetChild(0).transform.GetChild(2).gameObject.SetActive(true);
                    if (enemyNumber == 1) transform.position = new Vector3(transform.position.x, transform.position.y, -2.03f);
                    else if (enemyNumber == 2) transform.position = new Vector3(transform.position.x, transform.position.y, -2.02f);
                    else if (enemyNumber == 3) transform.position = new Vector3(transform.position.x, transform.position.y, -2.01f);
                    else if (enemyNumber == 4) transform.position = new Vector3(transform.position.x, transform.position.y, -2.00f);
                    //When the knight returns he defends himself
                    if (enemyType == 3) SetShielded(true); 
                    //When the king returns to the starting pos there is a chance that they will charge the teleportation attack
                    if (enemyType == 2 && Random.Range(0.0f,1.0f)<0.4f)
                    {
                        enemySource.clip = bossPowerUpAudio;
                        enemySource.Play();
                        GetComponent<Animator>().SetBool("EnterFase2", true);
                    }
                    else
                    {
                        //We let the next enemy attack or end the enemy turn
                        if (enemyNumber < battleController.GetComponent<BattleController>().GetNumberOfEnemies())
                        {
                            battleController.GetComponent<BattleController>().NextEnemy(enemyNumber);
                        }
                        else battleController.GetComponent<BattleController>().EndEnemyTurn();
                    }
                }
            }
        }
        if(enemyType == 1 && returnHeight)
        {
            if (transform.position.y < 1.0f)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y + 0.0334f, transform.position.z);
            }
            else returnHeight = false;
        }
        //The death animation of the evil wizard
        if (enemyType == 1 && !alive && transform.position.y > -0.66f)
        {
            //They fall to the ground and when they arrive the normal death animation starts
            transform.position = new Vector3(transform.position.x, transform.position.y - 0.0665f, transform.position.z);
            if (transform.position.y <= -0.66f)
            {
                grounded = true;
                dust = Instantiate(dustObject, new Vector3(transform.position.x + 0.5f, -1.57f, -0.3f), Quaternion.identity);
            }
        }
        //The normal die animation 
        if (!alive && grounded && dieAnimationFinished)
        {
            //Bandit
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
            //Wizard
            if(enemyType == 1) 
            {
                if (transform.eulerAngles.x < 90.0f)
                {
                    transform.rotation = Quaternion.Euler(transform.eulerAngles.x +1.8f, transform.eulerAngles.y, transform.eulerAngles.z);
                    transform.position = new Vector3(transform.position.x, transform.position.y-0.03f, transform.position.z);
                    if (transform.eulerAngles.x >= 90.0f) Destroy(dust.gameObject);
                }
            }//Knight
            if (enemyType == 3)
            {
                if (transform.eulerAngles.x == 0.0f) dust = Instantiate(dustObject, new Vector3(transform.position.x + 0.5f, -1.57f, -0.3f), Quaternion.identity);
                if (transform.eulerAngles.x < 90.0f)
                {
                    transform.rotation = Quaternion.Euler(transform.eulerAngles.x + 1.8f, transform.eulerAngles.y, transform.eulerAngles.z);
                    transform.position = new Vector3(transform.position.x, transform.position.y - 0.04f, transform.position.z);
                    if (transform.eulerAngles.x >= 90.0f) Destroy(dust.gameObject);
                }
            }
        }
    }

    //Function to make the enemy return to the normal height
    public void ReturnNormalHeight()
    {
        returnHeight = true;
    }
    //Function to check if the player knows the health of the enemy
    public void KnowHealth()
    {
        //Bandit
        if(enemyType == 0)
        {
            //We check if the player already knows the health of the enemy
            if (currentData.GetComponent<CurrentDataScript>().bandit == 1)
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
        //Evil wizard
        else if(enemyType == 1)
        {
            //We check if the player already knows the health of the enemy
            if (currentData.GetComponent<CurrentDataScript>().wizard == 1)
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
        //King
        else if (enemyType == 2)
        {
            //We check if the player already knows the health of the enemy
            if (currentData.GetComponent<CurrentDataScript>().king == 1)
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
        //Knight
        else if (enemyType == 3)
        {
            //We check if the player already knows the health of the enemy
            if (currentData.GetComponent<CurrentDataScript>().knight == 1)
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
        //The bandit and the wizard are affected the same way by the sleep effect
        if(enemyType == 0 || enemyType == 1)
        {
            duration = Mathf.FloorToInt((lvl-1) / 2.0f);
            rand = ((lvl-1) / 2.0f) - Mathf.FloorToInt((lvl - 1) / 2.0f);
            if (rand >= Random.Range(0.0f, 1.0f)) duration += 1;
        }
        //The knight is less affected
        else if (enemyType == 3)
        {
            duration = Mathf.FloorToInt((lvl - 1) / 2.5f);
            rand = ((lvl - 1) / 2.5f) - Mathf.FloorToInt((lvl - 1) / 2.5f);
            if (rand >= Random.Range(0.0f, 1.0f)) duration += 1;
        }
        //The king is less affected
        else if(enemyType == 2)
        {
            duration = Mathf.FloorToInt((lvl - 1) / 3.0f);
            rand = ((lvl - 1) / 3.0f) - Mathf.FloorToInt((lvl - 1) / 3.0f);
            if (rand >= Random.Range(0.0f, 1.0f)) duration += 1;
        }
        if(duration > 0) SetBuffDebuff(0, duration);
    }

    //A function to put a buff or a debuff in the UI. buffDeb = 0 -> Sleep
    public void SetBuffDebuff(int buffDeb, int duration)
    {
        //If the enemy is asleep already we add the numbers, if not we put the debuff
        if(buffDeb == 0)
        {
            if(asleep == 0)
            {
                if(enemyType == 3)
                {
                    if (shield) SetShielded(false);  
                    if (stunned > 0)
                    {
                        stunned = 0;
                        GetComponent<Animator>().SetInteger("StunTurns", 0);
                    }
                }
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

    //Function to end the buffs an the debuffs. Enemies can only be affected by the sleep debuff. If other buff or debuff is added a number change needs to be added.
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
    public void Attack(Transform[] objective)
    {
        if (asleep == 0 && stunned == 0)
        {
            //We put the enemy in the attack position
            transform.position = new Vector3(transform.position.x, transform.position.y, -2.06f);
            attackTeam = new Transform[1];
            attackTeam[0] = objective[0];
            transform.GetChild(0).transform.GetChild(2).gameObject.SetActive(false);
            //If the enemy is a bandit or a wizard or a knight we make it move towards the player
            if (enemyType == 0 || enemyType == 1 || enemyType == 3)
            {
                //When the knight attacks he lowers his shield 
                if (enemyType == 3) SetShielded(false); 
                startPos = transform.position.x;
                movePos = attackTeam[0].position.x + 1.1f;
                movingToEnemy = true;
            }
            //If it is the king
            else if(enemyType == 2)
            {
                //If it is not the teleportation attack them move to the enemy
                if (!groundAttack)
                {
                    startPos = transform.position.x;
                    movePos = attackTeam[0].position.x + 2.05f;
                    movingToEnemy = true;
                }
                //Else them save both player active team mates and start the teleportation attack
                else
                {
                    attackTeam = new Transform[2];
                    attackTeam = objective;
                    if (attackTeam.Length > 1)
                    {
                        attackTeam[0].GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
                        attackTeam[1].GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
                    }
                    StartTeleportAttack();
                }
            }
        }
        //If the enemy is asleep we reduce the asleep timer 
        else 
        {
            if (asleep > 0)
            {
                asleep -= 1;
                if (asleep == 0)
                {
                    EndBuffDebuff(sleepPos);
                    GetComponent<Animator>().SetBool("IsAsleep", false);
                    if(enemyType == 3) SetShielded(true); 
                }
                else
                {
                    buffDebuffUI.transform.GetChild(sleepPos).GetChild(1).GetComponent<Text>().text = asleep.ToString();
                }
            }         
            if (stunned > 0)
            {
                stunned -= 1;
                GetComponent<Animator>().SetInteger("StunTurns", stunned);
                GetComponent<Animator>().SetTrigger("TryRecover");
                if(stunned == 0 && enemyType == 3) SetShielded(true);
            }
            else
            {
                if (enemyNumber < battleController.GetComponent<BattleController>().GetNumberOfEnemies())
                {
                    battleController.GetComponent<BattleController>().NextEnemy(enemyNumber);
                }
                else battleController.GetComponent<BattleController>().EndEnemyTurn();
            }
        }
    }

    //A function to save if the player has defended or not
    public void IsDefended(bool defense)
    {
        attacking = false;
        if (defense)
        {
            defended = 1;
            if (attackTeam.Length > 1)
            {
                if (!attackTeam[0].GetComponent<PlayerTeamScript>().IsInvisible()) attackTeam[0].GetComponent<Animator>().SetBool("isDefending", true);
                if (!attackTeam[1].GetComponent<PlayerTeamScript>().IsInvisible()) attackTeam[1].GetComponent<Animator>().SetBool("isDefending", true);
            }
            else if (!attackTeam[0].GetComponent<PlayerTeamScript>().IsInvisible()) attackTeam[0].GetComponent<Animator>().SetBool("isDefending", true);
        }
        else
        {
            defended = 0;
        }
    }

    //A function to know if the knight is shielded
    public bool IsShielded()
    {
        return shield;
    }

    //A function to change the shielded state of the knight
    public void SetShielded(bool s)
    {
        if(!s) shield = s;
        GetComponent<Animator>().SetBool("Shield", s);
    }

    //A function to make the shield boolean true
    public void ShieldUp()
    {
        shield = true;
    }


    //A function to set the stun turns
    public void SetStun(int s)
    {
        stunned = s;
        GetComponent<Animator>().SetInteger("StunTurns", s);
    }

    //A function to end the turn of the actual enemy
    public void EndActualEnemyTurn()
    {
        if (enemyNumber < battleController.GetComponent<BattleController>().GetNumberOfEnemies())
        {
            battleController.GetComponent<BattleController>().NextEnemy(enemyNumber);
        }
        else battleController.GetComponent<BattleController>().EndEnemyTurn();
    }

    //Function to prepare a second defense
    public void SecondAttack()
    {
        attacking = true;
    }

    //Function to set the boss die animation boolean to true
    public void SetBossDieAnimationEnded()
    {
        battleController.GetComponent<BattleController>().SetBossDieAnimationEnded(true);
    }

    //A function for a not final attack
    public void MidMeleeAttack()
    {
        //If the player defends correctly while using the barrier there is no damage
        if (battleController.GetComponent<BattleController>().IsTaunting() && battleController.GetComponent<BattleController>().GetDefense(1) == 1.0f && defended == 1.0f)
        {
            attackTeam[0].GetComponent<PlayerTeamScript>().DealDamage(0);
        }
        else
        {
            if(enemyType == 2) attackTeam[0].GetComponent<PlayerTeamScript>().DealDamage(3 - defended);
            else if (enemyType == 3) attackTeam[0].GetComponent<PlayerTeamScript>().DealDamage(1 - defended);
        }
        //If the player doesnt defend correctly the damage animation is plaied
        if (!attackTeam[0].GetComponent<PlayerTeamScript>().IsInvisible() && !attackTeam[0].GetComponent<PlayerTeamScript>().IsDead())
        {
            if (!battleController.GetComponent<BattleController>().IsTaunting())
            {
                if (defended == 0) attackTeam[0].GetComponent<Animator>().SetTrigger("takeDamage");
                else attackTeam[0].GetComponent<Animator>().SetBool("isDefending", false);
            }
        }
        defended = 0;
    }
    //Function to make the sound of the first attack
    public void FirstAttackSound()
    {
        enemySource.clip = attackAudio;
        enemySource.Play();
    }
    //Function to make the sound of the second attack
    public void SecondAttackSound()
    {
        enemySource.clip = bossSecondAttackAudio;
        enemySource.Play();
    }
    //Function to make the sound of the charging of the ground attack
    public void ChargeGroundAttackSound()
    {
        enemySource.clip = bossChargeGroundAttackAudio;
        enemySource.Play();
    }
    //Function to make the sound of the ground attack
    public void GroundAttackSound()
    {
        enemySource.clip = bossGroundAttackAudio;
        enemySource.Play();
    }

    //Funtion to return to the start pos
    public void ReturnStartPos()
    {
        if(enemyType == 3) GetComponent<Animator>().SetBool("IsTripleAttack", false);
        attacking = false;
        gameObject.GetComponent<Animator>().SetBool("IsAttacking", false);
        movingToEnemy = false;
        returnStartPos = true;
        //We check if the player or the companion died. In case of the player if there is no resurrect potion the game ends. If the companion dies while using the barrier them return to the starting position
        if (attackTeam.Length > 1)
        {
            if (attackTeam[0].GetComponent<PlayerTeamScript>().playerTeamType == 0 && attackTeam[0].GetComponent<PlayerTeamScript>().IsDead()) attackTeam[0].GetComponent<PlayerTeamScript>().UseRecoverPotion();
            else if (attackTeam[1].GetComponent<PlayerTeamScript>().playerTeamType == 0 && attackTeam[1].GetComponent<PlayerTeamScript>().IsDead()) attackTeam[1].GetComponent<PlayerTeamScript>().UseRecoverPotion();
            if (attackTeam[0].GetComponent<PlayerTeamScript>().playerTeamType != 0 && attackTeam[0].GetComponent<PlayerTeamScript>().IsDead())
            {
                if (battleController.GetComponent<BattleController>().IsTaunting())
                {
                    if (!battleController.GetComponent<BattleController>().IsPlayerFirst())
                    {
                        battleController.GetComponent<BattleController>().StartChangePosition(2);
                        attackTeam[0].GetChild(1).GetComponent<SpriteRenderer>().color = new Color(attackTeam[0].GetChild(1).GetComponent<SpriteRenderer>().color.r, attackTeam[0].GetChild(1).GetComponent<SpriteRenderer>().color.g, attackTeam[0].GetChild(1).GetComponent<SpriteRenderer>().color.b, 0.0f);
                    }
                    else if (battleController.GetComponent<BattleController>().IsTaunting())
                    {
                        attackTeam[0].GetChild(1).GetComponent<SpriteRenderer>().color = new Color(attackTeam[0].GetChild(1).GetComponent<SpriteRenderer>().color.r, attackTeam[0].GetChild(1).GetComponent<SpriteRenderer>().color.g, attackTeam[0].GetChild(1).GetComponent<SpriteRenderer>().color.b, 0.0f);
                        attackTeam[0].GetComponent<PlayerTeamScript>().ReturnStartPosWizard();
                    }
                    battleController.GetComponent<BattleController>().SetTaunt(false);
                    attackTeam[0].GetComponent<Animator>().SetBool("isDefending", false);
                }
                else if (!battleController.GetComponent<BattleController>().IsPlayerFirst()) battleController.GetComponent<BattleController>().StartChangePosition(2);
            }
            else if (attackTeam[1].GetComponent<PlayerTeamScript>().playerTeamType != 0 && attackTeam[1].GetComponent<PlayerTeamScript>().IsDead())
            {
                if (battleController.GetComponent<BattleController>().IsTaunting())
                {
                    if (!battleController.GetComponent<BattleController>().IsPlayerFirst())
                    {
                        battleController.GetComponent<BattleController>().StartChangePosition(2);
                        attackTeam[1].GetChild(1).GetComponent<SpriteRenderer>().color = new Color(attackTeam[1].GetChild(1).GetComponent<SpriteRenderer>().color.r, attackTeam[1].GetChild(1).GetComponent<SpriteRenderer>().color.g, attackTeam[1].GetChild(1).GetComponent<SpriteRenderer>().color.b, 0.0f);
                    }
                    else if (battleController.GetComponent<BattleController>().IsTaunting())
                    {
                        attackTeam[1].GetChild(1).GetComponent<SpriteRenderer>().color = new Color(attackTeam[1].GetChild(1).GetComponent<SpriteRenderer>().color.r, attackTeam[1].GetChild(1).GetComponent<SpriteRenderer>().color.g, attackTeam[1].GetChild(1).GetComponent<SpriteRenderer>().color.b, 0.0f);
                        attackTeam[1].GetComponent<PlayerTeamScript>().ReturnStartPosWizard();
                    }
                    battleController.GetComponent<BattleController>().SetTaunt(false);
                    attackTeam[0].GetComponent<Animator>().SetBool("isDefending", false);
                }
                else if (!battleController.GetComponent<BattleController>().IsPlayerFirst()) battleController.GetComponent<BattleController>().StartChangePosition(2);
            }
        }
        else if (attackTeam[0].GetComponent<PlayerTeamScript>().IsDead())
        {
            if (attackTeam[0].GetComponent<PlayerTeamScript>().playerTeamType == 0) attackTeam[0].GetComponent<PlayerTeamScript>().UseRecoverPotion();
            if (attackTeam[0].GetComponent<PlayerTeamScript>().playerTeamType != 0)
            {
                if (battleController.GetComponent<BattleController>().IsTaunting())
                {
                    if (!battleController.GetComponent<BattleController>().IsPlayerFirst())
                    {
                        battleController.GetComponent<BattleController>().StartChangePosition(2);
                        attackTeam[0].GetChild(1).GetComponent<SpriteRenderer>().color = new Color(attackTeam[0].GetChild(1).GetComponent<SpriteRenderer>().color.r, attackTeam[0].GetChild(1).GetComponent<SpriteRenderer>().color.g, attackTeam[0].GetChild(1).GetComponent<SpriteRenderer>().color.b, 0.0f);
                    }
                    else if (battleController.GetComponent<BattleController>().IsTaunting())
                    {
                        attackTeam[0].GetChild(1).GetComponent<SpriteRenderer>().color = new Color(attackTeam[0].GetChild(1).GetComponent<SpriteRenderer>().color.r, attackTeam[0].GetChild(1).GetComponent<SpriteRenderer>().color.g, attackTeam[0].GetChild(1).GetComponent<SpriteRenderer>().color.b, 0.0f);
                        attackTeam[0].GetComponent<PlayerTeamScript>().ReturnStartPosWizard();
                    }
                    battleController.GetComponent<BattleController>().SetTaunt(false);
                    attackTeam[0].GetComponent<Animator>().SetBool("isDefending", false);
                }
                else if (!battleController.GetComponent<BattleController>().IsPlayerFirst()) battleController.GetComponent<BattleController>().StartChangePosition(2);
            }
        }
    }

    //A function to do the teleport attack
    public void StartTeleportAttack()
    {
        enemySource.clip = bossTeleportAudio;
        enemySource.Play();
        GetComponent<Animator>().SetBool("StartTeleport", true);
        startPos = transform.position.x;
        teleportPos = -5.7f;
    }

    //A function to do the teleport return
    public void StartTeleportReturn()
    {
        enemySource.clip = bossTeleportAudio;
        enemySource.Play();
        GetComponent<Animator>().SetBool("IsGroundAttacking", false);
        GetComponent<Animator>().SetBool("StartTeleport", true);
        teleportPos = startPos;
        //We check if the player or the companion died. In case of the player if there is no resurrect potion the game ends. If the companion dies while using the barrier them return to the starting position
        if (attackTeam.Length > 1)
        {
            if (attackTeam[0].GetComponent<PlayerTeamScript>().playerTeamType == 0 && attackTeam[0].GetComponent<PlayerTeamScript>().IsDead()) attackTeam[0].GetComponent<PlayerTeamScript>().UseRecoverPotion();
            else if (attackTeam[1].GetComponent<PlayerTeamScript>().playerTeamType == 0 && attackTeam[1].GetComponent<PlayerTeamScript>().IsDead()) attackTeam[1].GetComponent<PlayerTeamScript>().UseRecoverPotion();
            if (attackTeam[0].GetComponent<PlayerTeamScript>().playerTeamType != 0 && attackTeam[0].GetComponent<PlayerTeamScript>().IsDead())
            {
                if (battleController.GetComponent<BattleController>().IsTaunting())
                {
                    if (!battleController.GetComponent<BattleController>().IsPlayerFirst())
                    {
                        battleController.GetComponent<BattleController>().StartChangePosition(2);
                        attackTeam[0].GetChild(1).GetComponent<SpriteRenderer>().color = new Color(attackTeam[0].GetChild(1).GetComponent<SpriteRenderer>().color.r, attackTeam[0].GetChild(1).GetComponent<SpriteRenderer>().color.g, attackTeam[0].GetChild(1).GetComponent<SpriteRenderer>().color.b, 0.0f);
                    }
                    else if (battleController.GetComponent<BattleController>().IsTaunting())
                    {
                        attackTeam[0].GetChild(1).GetComponent<SpriteRenderer>().color = new Color(attackTeam[0].GetChild(1).GetComponent<SpriteRenderer>().color.r, attackTeam[0].GetChild(1).GetComponent<SpriteRenderer>().color.g, attackTeam[0].GetChild(1).GetComponent<SpriteRenderer>().color.b, 0.0f);
                        attackTeam[0].GetComponent<PlayerTeamScript>().ReturnStartPosWizard();
                    }
                    battleController.GetComponent<BattleController>().SetTaunt(false);
                    attackTeam[0].GetComponent<Animator>().SetBool("isDefending", false);
                }
                else if (!battleController.GetComponent<BattleController>().IsPlayerFirst()) battleController.GetComponent<BattleController>().StartChangePosition(2);
            }
            else if (attackTeam[1].GetComponent<PlayerTeamScript>().playerTeamType != 0 && attackTeam[1].GetComponent<PlayerTeamScript>().IsDead())
            {
                if (battleController.GetComponent<BattleController>().IsTaunting())
                {
                    if (!battleController.GetComponent<BattleController>().IsPlayerFirst())
                    {
                        battleController.GetComponent<BattleController>().StartChangePosition(2);
                        attackTeam[1].GetChild(1).GetComponent<SpriteRenderer>().color = new Color(attackTeam[1].GetChild(1).GetComponent<SpriteRenderer>().color.r, attackTeam[1].GetChild(1).GetComponent<SpriteRenderer>().color.g, attackTeam[1].GetChild(1).GetComponent<SpriteRenderer>().color.b, 0.0f);
                    }
                    else if (battleController.GetComponent<BattleController>().IsTaunting())
                    {
                        attackTeam[1].GetChild(1).GetComponent<SpriteRenderer>().color = new Color(attackTeam[1].GetChild(1).GetComponent<SpriteRenderer>().color.r, attackTeam[1].GetChild(1).GetComponent<SpriteRenderer>().color.g, attackTeam[1].GetChild(1).GetComponent<SpriteRenderer>().color.b, 0.0f);
                        attackTeam[1].GetComponent<PlayerTeamScript>().ReturnStartPosWizard();
                    }
                    battleController.GetComponent<BattleController>().SetTaunt(false);
                    attackTeam[0].GetComponent<Animator>().SetBool("isDefending", false);
                }
                else if (!battleController.GetComponent<BattleController>().IsPlayerFirst()) battleController.GetComponent<BattleController>().StartChangePosition(2);
            }
        }
        else if (attackTeam[0].GetComponent<PlayerTeamScript>().IsDead())
        {
            if (attackTeam[0].GetComponent<PlayerTeamScript>().playerTeamType == 0) attackTeam[0].GetComponent<PlayerTeamScript>().UseRecoverPotion();
            if (attackTeam[0].GetComponent<PlayerTeamScript>().playerTeamType != 0)
            {
                if (battleController.GetComponent<BattleController>().IsTaunting())
                {
                    if (!battleController.GetComponent<BattleController>().IsPlayerFirst())
                    {
                        battleController.GetComponent<BattleController>().StartChangePosition(2);
                        attackTeam[0].GetChild(1).GetComponent<SpriteRenderer>().color = new Color(attackTeam[0].GetChild(1).GetComponent<SpriteRenderer>().color.r, attackTeam[0].GetChild(1).GetComponent<SpriteRenderer>().color.g, attackTeam[0].GetChild(1).GetComponent<SpriteRenderer>().color.b, 0.0f);
                    }
                    else if (battleController.GetComponent<BattleController>().IsTaunting())
                    {
                        attackTeam[0].GetChild(1).GetComponent<SpriteRenderer>().color = new Color(attackTeam[0].GetChild(1).GetComponent<SpriteRenderer>().color.r, attackTeam[0].GetChild(1).GetComponent<SpriteRenderer>().color.g, attackTeam[0].GetChild(1).GetComponent<SpriteRenderer>().color.b, 0.0f);
                        attackTeam[0].GetComponent<PlayerTeamScript>().ReturnStartPosWizard();
                    }
                    battleController.GetComponent<BattleController>().SetTaunt(false);
                    attackTeam[0].GetComponent<Animator>().SetBool("isDefending", false);
                }
                else if (!battleController.GetComponent<BattleController>().IsPlayerFirst()) battleController.GetComponent<BattleController>().StartChangePosition(2);
            }
        }
    }

    //A function to teleport to the attack position
    public void Teleport()
    {
        GetComponent<Animator>().SetBool("StartTeleport", false);
        GetComponent<Animator>().SetTrigger("EndTeleport");
        transform.position = new Vector3(teleportPos, transform.position.y, transform.position.z);
    }
    //A function to start the ground attack or end turn
    public void EndTeleport()
    {
        //If the king teleported to the player team position them do the teleport attack
        if(transform.position.x != startPos)
        {
            attacking = true;
            GetComponent<Animator>().SetBool("IsGroundAttacking", true);
        }
        //If them teleport to the starting position the turn is ended
        else
        {            
            if (enemyNumber == 1) transform.position = new Vector3(transform.position.x, transform.position.y, -2.03f);
            else if (enemyNumber == 2) transform.position = new Vector3(transform.position.x, transform.position.y, -2.02f);
            else if (enemyNumber == 3) transform.position = new Vector3(transform.position.x, transform.position.y, -2.01f);
            else if (enemyNumber == 4) transform.position = new Vector3(transform.position.x, transform.position.y, -2.00f);
            transform.GetChild(0).transform.GetChild(2).gameObject.SetActive(true);
            if (enemyNumber < battleController.GetComponent<BattleController>().GetNumberOfEnemies())
            {
                battleController.GetComponent<BattleController>().NextEnemy(enemyNumber);
            }
            else battleController.GetComponent<BattleController>().EndEnemyTurn();
        }
    }
    //Function to end the power up
    public void EndPowerUp()
    {
        GetComponent<Animator>().SetBool("EnterFase2", false);
        groundAttack = true;
        if (enemyNumber < battleController.GetComponent<BattleController>().GetNumberOfEnemies())
        {
            battleController.GetComponent<BattleController>().NextEnemy(enemyNumber);
        }
        else battleController.GetComponent<BattleController>().EndEnemyTurn();
    }
    
    //A function to attack all the player team
    public void TeamAttack()
    {
        attacking = false;
        groundAttack = false;
        //We check if the wizard is using the barrier, is so we only attack the wizard. 
        if (attackTeam.Length > 1)
        {
            if (battleController.GetComponent<BattleController>().IsTaunting() && battleController.GetComponent<BattleController>().GetDefense(1) == 1.0f && defended == 1.0f)
            {
                attackTeam[0].GetComponent<PlayerTeamScript>().DealDamage(0);
            }
            else attackTeam[0].GetComponent<PlayerTeamScript>().DealDamage(10 - defended);
            if (battleController.GetComponent<BattleController>().IsTaunting() && battleController.GetComponent<BattleController>().GetDefense(1) == 1.0f && defended == 1.0f)
            {
                attackTeam[1].GetComponent<PlayerTeamScript>().DealDamage(0);
            }
            else attackTeam[1].GetComponent<PlayerTeamScript>().DealDamage(10 - defended);
            if (!attackTeam[0].GetComponent<PlayerTeamScript>().IsInvisible() && !attackTeam[0].GetComponent<PlayerTeamScript>().IsDead())
            {
                if (!battleController.GetComponent<BattleController>().IsTaunting())
                {
                    if (defended == 0) attackTeam[0].GetComponent<Animator>().SetTrigger("takeDamage");
                    else attackTeam[0].GetComponent<Animator>().SetBool("isDefending", false);
                }
            }
            if (!attackTeam[1].GetComponent<PlayerTeamScript>().IsInvisible() && !attackTeam[1].GetComponent<PlayerTeamScript>().IsDead())
            {
                if (!battleController.GetComponent<BattleController>().IsTaunting())
                {
                    if (defended == 0) attackTeam[1].GetComponent<Animator>().SetTrigger("takeDamage");
                    else attackTeam[1].GetComponent<Animator>().SetBool("isDefending", false);
                }
            }
        }
        else
        {
            if (battleController.GetComponent<BattleController>().IsTaunting() && battleController.GetComponent<BattleController>().GetDefense(1) == 1.0f && defended == 1.0f)
            {
                attackTeam[0].GetComponent<PlayerTeamScript>().DealDamage(0);
            }
            else attackTeam[0].GetComponent<PlayerTeamScript>().DealDamage(10 - defended);
            if (!attackTeam[0].GetComponent<PlayerTeamScript>().IsInvisible() && !attackTeam[0].GetComponent<PlayerTeamScript>().IsDead())
            {
                if (!battleController.GetComponent<BattleController>().IsTaunting())
                {
                    if (defended == 0) attackTeam[0].GetComponent<Animator>().SetTrigger("takeDamage");
                    else attackTeam[0].GetComponent<Animator>().SetBool("isDefending", false);
                }
            }
        }        
        defended = 0;
    }


    //A function to end the melee attack and start moving back to the start position
    public void EndMeleeAttack()
    {
        attacking = false;
        if (battleController.GetComponent<BattleController>().IsTaunting() && battleController.GetComponent<BattleController>().GetDefense(1) == 1.0f && defended == 1.0f)
        {
            attackTeam[0].GetComponent<PlayerTeamScript>().DealDamage(0);
        }
        else attackTeam[0].GetComponent<PlayerTeamScript>().DealDamage(2 - defended);
        if (!attackTeam[0].GetComponent<PlayerTeamScript>().IsInvisible() && !attackTeam[0].GetComponent<PlayerTeamScript>().IsDead())
        {
            if (!battleController.GetComponent<BattleController>().IsTaunting())
            {
                if (defended == 0) attackTeam[0].GetComponent<Animator>().SetTrigger("takeDamage");
                else attackTeam[0].GetComponent<Animator>().SetBool("isDefending", false);
            }            
        }        
        defended = 0;
        gameObject.GetComponent<Animator>().SetBool("IsAttacking", false);
        movingToEnemy = false;
        returnStartPos = true;
        //We check if the player or the companion died. In case of the player if there is no resurrect potion the game ends. If the companion dies while using the barrier them return to the starting position
        if (attackTeam.Length > 1)
        {
            if (attackTeam[0].GetComponent<PlayerTeamScript>().playerTeamType == 0 && attackTeam[0].GetComponent<PlayerTeamScript>().IsDead()) attackTeam[0].GetComponent<PlayerTeamScript>().UseRecoverPotion();
            else if (attackTeam[1].GetComponent<PlayerTeamScript>().playerTeamType == 0 && attackTeam[1].GetComponent<PlayerTeamScript>().IsDead()) attackTeam[1].GetComponent<PlayerTeamScript>().UseRecoverPotion();
            if (attackTeam[0].GetComponent<PlayerTeamScript>().playerTeamType != 0 && attackTeam[0].GetComponent<PlayerTeamScript>().IsDead())
            {
                if (battleController.GetComponent<BattleController>().IsTaunting())
                {
                    if (!battleController.GetComponent<BattleController>().IsPlayerFirst())
                    {
                        battleController.GetComponent<BattleController>().StartChangePosition(2);
                        attackTeam[0].GetChild(1).GetComponent<SpriteRenderer>().color = new Color(attackTeam[0].GetChild(1).GetComponent<SpriteRenderer>().color.r, attackTeam[0].GetChild(1).GetComponent<SpriteRenderer>().color.g, attackTeam[0].GetChild(1).GetComponent<SpriteRenderer>().color.b, 0.0f);
                    }
                    else if (battleController.GetComponent<BattleController>().IsTaunting())
                    {
                        attackTeam[0].GetChild(1).GetComponent<SpriteRenderer>().color = new Color(attackTeam[0].GetChild(1).GetComponent<SpriteRenderer>().color.r, attackTeam[0].GetChild(1).GetComponent<SpriteRenderer>().color.g, attackTeam[0].GetChild(1).GetComponent<SpriteRenderer>().color.b, 0.0f);
                        attackTeam[0].GetComponent<PlayerTeamScript>().ReturnStartPosWizard();
                    }
                    battleController.GetComponent<BattleController>().SetTaunt(false);
                    attackTeam[0].GetComponent<Animator>().SetBool("isDefending", false);
                }
                else if (!battleController.GetComponent<BattleController>().IsPlayerFirst()) battleController.GetComponent<BattleController>().StartChangePosition(2);
            }
            else if (attackTeam[1].GetComponent<PlayerTeamScript>().playerTeamType != 0 && attackTeam[1].GetComponent<PlayerTeamScript>().IsDead())
            {
                if (battleController.GetComponent<BattleController>().IsTaunting())
                {
                    if (!battleController.GetComponent<BattleController>().IsPlayerFirst())
                    {
                        battleController.GetComponent<BattleController>().StartChangePosition(2);
                        attackTeam[1].GetChild(1).GetComponent<SpriteRenderer>().color = new Color(attackTeam[1].GetChild(1).GetComponent<SpriteRenderer>().color.r, attackTeam[1].GetChild(1).GetComponent<SpriteRenderer>().color.g, attackTeam[1].GetChild(1).GetComponent<SpriteRenderer>().color.b, 0.0f);
                    }
                    else if (battleController.GetComponent<BattleController>().IsTaunting())
                    {
                        attackTeam[1].GetChild(1).GetComponent<SpriteRenderer>().color = new Color(attackTeam[1].GetChild(1).GetComponent<SpriteRenderer>().color.r, attackTeam[1].GetChild(1).GetComponent<SpriteRenderer>().color.g, attackTeam[1].GetChild(1).GetComponent<SpriteRenderer>().color.b, 0.0f);
                        attackTeam[1].GetComponent<PlayerTeamScript>().ReturnStartPosWizard();
                    }
                    battleController.GetComponent<BattleController>().SetTaunt(false);
                    attackTeam[0].GetComponent<Animator>().SetBool("isDefending", false);
                }
                else if (!battleController.GetComponent<BattleController>().IsPlayerFirst()) battleController.GetComponent<BattleController>().StartChangePosition(2);
            }
        }
        else if (attackTeam[0].GetComponent<PlayerTeamScript>().IsDead())
        {
            if (attackTeam[0].GetComponent<PlayerTeamScript>().playerTeamType == 0) attackTeam[0].GetComponent<PlayerTeamScript>().UseRecoverPotion();
            if (attackTeam[0].GetComponent<PlayerTeamScript>().playerTeamType != 0)
            {
                if (battleController.GetComponent<BattleController>().IsTaunting())
                {
                    if (!battleController.GetComponent<BattleController>().IsPlayerFirst())
                    {
                        battleController.GetComponent<BattleController>().StartChangePosition(2);
                        attackTeam[0].GetChild(1).GetComponent<SpriteRenderer>().color = new Color(attackTeam[0].GetChild(1).GetComponent<SpriteRenderer>().color.r, attackTeam[0].GetChild(1).GetComponent<SpriteRenderer>().color.g, attackTeam[0].GetChild(1).GetComponent<SpriteRenderer>().color.b, 0.0f);
                    }
                    else if (battleController.GetComponent<BattleController>().IsTaunting())
                    {
                        attackTeam[0].GetChild(1).GetComponent<SpriteRenderer>().color = new Color(attackTeam[0].GetChild(1).GetComponent<SpriteRenderer>().color.r, attackTeam[0].GetChild(1).GetComponent<SpriteRenderer>().color.g, attackTeam[0].GetChild(1).GetComponent<SpriteRenderer>().color.b, 0.0f);
                        attackTeam[0].GetComponent<PlayerTeamScript>().ReturnStartPosWizard();
                    }
                    battleController.GetComponent<BattleController>().SetTaunt(false);
                    attackTeam[0].GetComponent<Animator>().SetBool("isDefending", false);
                }
                else if (!battleController.GetComponent<BattleController>().IsPlayerFirst()) battleController.GetComponent<BattleController>().StartChangePosition(2);
            }
        }
    }

    //A function to put the idle boolean false
    public void ReceiveDamage()
    {
        enemySource.clip = hitAudio;
        enemySource.Play();
        idle = false; 
        if (asleep > 0)
        {
            GetComponent<Animator>().SetBool("IsAsleep", false);
            asleep = 0;
            EndBuffDebuff(sleepPos);
            if (enemyType == 3) SetShielded(true);
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
        enemySource.clip = dieAudio;
        enemySource.Play();
        idle = true;
        alive = false;
        GiveXP();
    }

    //A function to save that the die animation has finished
    public void EnemyDieAnimationFinished()
    {
        dieAnimationFinished = true;
    }

    //A function to give XP depending on the enemy and the player level
    public void GiveXP()
    {
        if(enemyType == 0)
        {
            if (currentData.GetComponent<CurrentDataScript>().playerLvl == 1)
            {
                battleController.GetComponent<BattleController>().AddXPToCurrent(4);
            }
            else if (currentData.GetComponent<CurrentDataScript>().playerLvl == 2)
            {
                battleController.GetComponent<BattleController>().AddXPToCurrent(2);
            }
            else if (currentData.GetComponent<CurrentDataScript>().playerLvl == 3)
            {
                battleController.GetComponent<BattleController>().AddXPToCurrent(1);
            }
        }
        else if(enemyType == 1)
        {
            if (currentData.GetComponent<CurrentDataScript>().playerLvl == 1)
            {
                battleController.GetComponent<BattleController>().AddXPToCurrent(5);
            }
            else if (currentData.GetComponent<CurrentDataScript>().playerLvl == 2)
            {
                battleController.GetComponent<BattleController>().AddXPToCurrent(3);
            }
            else if (currentData.GetComponent<CurrentDataScript>().playerLvl == 3)
            {
                battleController.GetComponent<BattleController>().AddXPToCurrent(1);
            }
        }
        else if (enemyType == 2)
        {
            if (currentData.GetComponent<CurrentDataScript>().playerLvl == 1)
            {
                battleController.GetComponent<BattleController>().AddXPToCurrent(50);
            }
            else if (currentData.GetComponent<CurrentDataScript>().playerLvl == 2)
            {
                battleController.GetComponent<BattleController>().AddXPToCurrent(40);
            }
            else if (currentData.GetComponent<CurrentDataScript>().playerLvl == 3)
            {
                battleController.GetComponent<BattleController>().AddXPToCurrent(30);
            }
            else if (currentData.GetComponent<CurrentDataScript>().playerLvl == 4)
            {
                battleController.GetComponent<BattleController>().AddXPToCurrent(23);
            }
            else if (currentData.GetComponent<CurrentDataScript>().playerLvl == 5)
            {
                battleController.GetComponent<BattleController>().AddXPToCurrent(16);
            }
            else if (currentData.GetComponent<CurrentDataScript>().playerLvl == 6)
            {
                battleController.GetComponent<BattleController>().AddXPToCurrent(8);
            }
            else if (currentData.GetComponent<CurrentDataScript>().playerLvl == 7)
            {
                battleController.GetComponent<BattleController>().AddXPToCurrent(4);
            }
            else if (currentData.GetComponent<CurrentDataScript>().playerLvl == 8)
            {
                battleController.GetComponent<BattleController>().AddXPToCurrent(1);
            }
            else
            {
                battleController.GetComponent<BattleController>().AddXPToCurrent(10);
            }
        }
        else if (enemyType == 3)
        {
            if (currentData.GetComponent<CurrentDataScript>().playerLvl == 1)
            {
                battleController.GetComponent<BattleController>().AddXPToCurrent(10);
            }
            else if (currentData.GetComponent<CurrentDataScript>().playerLvl == 2)
            {
                battleController.GetComponent<BattleController>().AddXPToCurrent(5);
            }
            else if (currentData.GetComponent<CurrentDataScript>().playerLvl == 3)
            {
                battleController.GetComponent<BattleController>().AddXPToCurrent(3);
            }
            else if (currentData.GetComponent<CurrentDataScript>().playerLvl == 4)
            {
                battleController.GetComponent<BattleController>().AddXPToCurrent(1);
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
