using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WorldEnemy : MonoBehaviour
{
    //The movement speed of the enemy
    private float speedX;
    private float speedZ;
    //The starting point of the enemy
    private float startX;
    private float startZ;
    //The animator
    Animator animator;
    //The player and the companion
    private GameObject player;
    private GameObject companion;
    //The attack area prefab and the area itself
    [SerializeField] private Transform areaPrefab;
    private Transform area;
    //The position of the attack objective
    private Vector3 objectivePos;
    //A boolean to know if this enemy is in battle
    private bool inBattle;
    //A boolean to know if the enemy has seen the player
    private bool seeingPlayer;
    //The prefab of the coin
    [SerializeField] private Transform coinPrefab;
    //The number of coins the enemy will spawn
    [SerializeField] private int coinNumb;

    //The enemies of the battle. 1-> bandit, 2-> evil wizard, 3-> king
    [SerializeField] private int enemy1;
    [SerializeField] private int enemy2;
    [SerializeField] private int enemy3;
    [SerializeField] private int enemy4;
    //The start battle screen
    private GameObject startBattleScreen;
    //The current data
    private GameObject currentData;

    void Start()
    {
        currentData = GameObject.Find("CurrentData");
        startBattleScreen = GameObject.Find("EndBattleImage");
        //We initialize the variables
        speedX = 0.0f;
        speedZ = 0.0f;
        inBattle = false;
        seeingPlayer = false;
        startX = transform.position.x;
        startZ = transform.position.z;
        //We find the animator
        animator = GetComponent<Animator>();
        //We find the player
        player = GameObject.Find("PlayerWorld");
        //We find the companion
        companion = GameObject.Find("CompanionWorld");
    }

    private void Update()
    {
        if(currentData.GetComponent<CurrentDataScript>().battle == 0)
        {
            if (!inBattle && (Mathf.Abs(player.transform.position.x - gameObject.transform.position.x) + Mathf.Abs(player.transform.position.z - gameObject.transform.position.z))<5.0f && (((Mathf.Abs(startX - gameObject.transform.position.x) + Mathf.Abs(startZ - gameObject.transform.position.z)) < 10.0f && seeingPlayer) || ((Mathf.Abs(startX - gameObject.transform.position.x) + Mathf.Abs(startZ - gameObject.transform.position.z)) < 5.0f && !seeingPlayer)))
            {
                animator.SetFloat("RunSpeed", 1.0f);
                if (!seeingPlayer)
                {
                    transform.GetChild(2).GetChild(0).GetComponent<Animator>().SetTrigger("Alert");
                    seeingPlayer = true;
                }
                if ((Mathf.Abs(player.transform.position.x - gameObject.transform.position.x) + Mathf.Abs(player.transform.position.z - gameObject.transform.position.z)) <= (Mathf.Abs(companion.transform.position.x - gameObject.transform.position.x) + Mathf.Abs(companion.transform.position.z - gameObject.transform.position.z)))
                {
                    if (Mathf.Abs(player.transform.position.x - gameObject.transform.position.x) + Mathf.Abs(player.transform.position.z - gameObject.transform.position.z) > 1.5f)
                    {
                        //Detect where the player is and move the enemy towards them
                        speedX = (player.transform.position.x - gameObject.transform.position.x) / (Mathf.Abs(player.transform.position.x - gameObject.transform.position.x) + Mathf.Abs(player.transform.position.z - gameObject.transform.position.z));
                        speedZ = (player.transform.position.z - gameObject.transform.position.z) / (Mathf.Abs(player.transform.position.x - gameObject.transform.position.x) + Mathf.Abs(player.transform.position.z - gameObject.transform.position.z));
                    }
                    else if (!animator.GetBool("Attack"))
                    {
                        objectivePos = player.transform.position;
                        animator.SetBool("Attack", true);
                        speedX = 0.0f;
                        speedZ = 0.0f;
                    }
                }
                else
                {
                    if (Mathf.Abs(companion.transform.position.x - gameObject.transform.position.x) + Mathf.Abs(companion.transform.position.z - gameObject.transform.position.z) > 1.5f)
                    {
                        //Detect where the companion is and move the enemy towards them
                        speedX = (companion.transform.position.x - gameObject.transform.position.x) / (Mathf.Abs(companion.transform.position.x - gameObject.transform.position.x) + Mathf.Abs(companion.transform.position.z - gameObject.transform.position.z));
                        speedZ = (companion.transform.position.z - gameObject.transform.position.z) / (Mathf.Abs(companion.transform.position.x - gameObject.transform.position.x) + Mathf.Abs(companion.transform.position.z - gameObject.transform.position.z));
                    }
                    else if (!animator.GetBool("Attack"))
                    {
                        objectivePos = companion.transform.position;
                        animator.SetBool("Attack", true);
                        speedX = 0.0f;
                        speedZ = 0.0f;
                    }
                }

                //We put the correct values on the animator variables
                animator.SetFloat("SpeedX", speedX);
                if (speedX != 0 || speedZ != 0) animator.SetBool("Moving", true);
                else animator.SetBool("Moving", false);
                if ((player.transform.position.x - gameObject.transform.position.x) >= 0.0f) animator.SetBool("FacingRight", true);
                else animator.SetBool("FacingRight", false);
            }
            else if (!inBattle)
            {
                animator.SetFloat("RunSpeed", 0.5f);
                seeingPlayer = false;
                //Detect where the starting point is and move the enemy towards it
                if (Mathf.Abs(startX- gameObject.transform.position.x) > 0.2f) speedX = (startX - gameObject.transform.position.x) / (Mathf.Abs(startX - gameObject.transform.position.x) + Mathf.Abs(startZ - gameObject.transform.position.z)) * 0.5f;
                else speedX = 0.0f;
                if (Mathf.Abs(startZ - gameObject.transform.position.z) > 0.2f) speedZ = (startZ - gameObject.transform.position.z) / (Mathf.Abs(startX - gameObject.transform.position.x) + Mathf.Abs(startZ - gameObject.transform.position.z)) * 0.5f;
                else speedZ = 0.0f;
                //We put the correct values on the animator variables
                animator.SetFloat("SpeedX", speedX);
                if (speedX != 0 || speedZ != 0) animator.SetBool("Moving", true);
                else animator.SetBool("Moving", false);
                if ((startX - gameObject.transform.position.x) >= 0.0f) animator.SetBool("FacingRight", true);
                else animator.SetBool("FacingRight", false);
            }
            else
            {
                if (currentData.GetComponent<CurrentDataScript>().enemyDied == 1)
                {
                    animator.SetTrigger("Die");
                    inBattle = false;
                    currentData.GetComponent<CurrentDataScript>().enemyDied = 0;
                }
                else
                {
                    inBattle = false;
                }
            }
        } 
        
    }


    void FixedUpdate()
    {
        //move the enemy on the direction we saved previously
        if(animator.GetBool("Attack") || currentData.GetComponent<CurrentDataScript>().battle == 1) gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0.0f, gameObject.GetComponent<Rigidbody>().velocity.y, 0.0f);
        else gameObject.GetComponent<Rigidbody>().velocity = new Vector3(speedX * 4, gameObject.GetComponent<Rigidbody>().velocity.y, speedZ * 4);

    }

    private void OnCollisionEnter(Collision collision)
    {
        if ((collision.transform.tag == "Player" && !collision.transform.GetComponent<WorldPlayerMovementScript>().IsFleeing()) || (collision.transform.tag == "Companion" && !collision.transform.GetComponent<WorldCompanionMovementScript>().IsFleeing()))
        {
            StartBattle(0, 0);
            inBattle = true;
        }
    }

    private void SelfDestroy()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Attack")
        {
            animator.SetTrigger("Hurt");
            StartBattle(1, 0);
            inBattle = true;
        }
    }
    //Function to spawn the attack area
    private void SpawnAttack()
    {
        area = Instantiate(areaPrefab, objectivePos, Quaternion.identity);
        area.GetComponent<WorldBattleTrigger>().SetUser(gameObject.transform);
    }

    //Function to set the enemy in battle
    public void SetInBattle(bool battle)
    {
        inBattle = battle;
    }

    //Function to end the attack animation
    private void EndAttack()
    {
        animator.SetBool("Attack", false);
        Destroy(area.gameObject);
    }

    //Function to spawn the coins when the enemy dies
    private void SpawnCoins()
    {
        for(int i = 0; i<coinNumb; i++) Instantiate(coinPrefab, gameObject.transform.position, Quaternion.identity).GetComponent<Rigidbody>().velocity = new Vector3(Random.Range(-5.0f,5.0f),Random.Range(5.0f,10.0f), Random.Range(-5.0f, 5.0f)); 
    }

    //A function to start the battle. User: 0-> no first attack, 1-> player first attack, 2-> companion first attack, 3 -> enemy first attack. objective in case of enemy attack: 1-> player, 2-> companion
    public void StartBattle(int user, int objective)
    {
        if (SceneManager.sceneCount < 2)
        {
            currentData.GetComponent<CurrentDataScript>().battle = 1;
            currentData.GetComponent<CurrentDataScript>().enemy1 = enemy1;
            currentData.GetComponent<CurrentDataScript>().enemy2 = enemy2;
            currentData.GetComponent<CurrentDataScript>().enemy3 = enemy3;
            currentData.GetComponent<CurrentDataScript>().enemy4 = enemy4;
            if (user == 0)
            {
                currentData.GetComponent<CurrentDataScript>().enemyStart = 0;
                currentData.GetComponent<CurrentDataScript>().firstAttackObjective = 0;
                currentData.GetComponent<CurrentDataScript>().playerFirstAttack = 0;
                currentData.GetComponent<CurrentDataScript>().playerAttack = 0;
                currentData.GetComponent<CurrentDataScript>().playerStyle = 0;
                currentData.GetComponent<CurrentDataScript>().companionFirstAttack = 0;
                currentData.GetComponent<CurrentDataScript>().companionAttack = 0;
                currentData.GetComponent<CurrentDataScript>().companionStyle = 0;
            }
            else if (user == 1)
            {
                currentData.GetComponent<CurrentDataScript>().enemyStart = 0;
                currentData.GetComponent<CurrentDataScript>().firstAttackObjective = 0;
                currentData.GetComponent<CurrentDataScript>().playerFirstAttack = 1;
                currentData.GetComponent<CurrentDataScript>().playerAttack = 0;
                currentData.GetComponent<CurrentDataScript>().playerStyle = 0;
                currentData.GetComponent<CurrentDataScript>().companionFirstAttack = 0;
                currentData.GetComponent<CurrentDataScript>().companionAttack = 0;
                currentData.GetComponent<CurrentDataScript>().companionStyle = 0;
            }
            else if (user == 2)
            {
                currentData.GetComponent<CurrentDataScript>().enemyStart = 0;
                currentData.GetComponent<CurrentDataScript>().firstAttackObjective = 0;
                currentData.GetComponent<CurrentDataScript>().playerFirstAttack = 0;
                currentData.GetComponent<CurrentDataScript>().playerAttack = 0;
                currentData.GetComponent<CurrentDataScript>().playerStyle = 0;
                currentData.GetComponent<CurrentDataScript>().companionFirstAttack = 1;
                currentData.GetComponent<CurrentDataScript>().companionAttack = 0;
                currentData.GetComponent<CurrentDataScript>().companionStyle = 0;
            }
            else if (user == 3)
            {
                currentData.GetComponent<CurrentDataScript>().enemyStart = 1;
                currentData.GetComponent<CurrentDataScript>().firstAttackObjective = objective;
                currentData.GetComponent<CurrentDataScript>().playerFirstAttack = 0;
                currentData.GetComponent<CurrentDataScript>().playerAttack = 0;
                currentData.GetComponent<CurrentDataScript>().playerStyle = 0;
                currentData.GetComponent<CurrentDataScript>().companionFirstAttack = 0;
                currentData.GetComponent<CurrentDataScript>().companionAttack = 0;
                currentData.GetComponent<CurrentDataScript>().companionStyle = 0;
            }
            startBattleScreen.GetComponent<Animator>().SetTrigger("Start");
            Time.timeScale = 0.1f;
        }            
    }
}
