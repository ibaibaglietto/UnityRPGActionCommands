using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleController : MonoBehaviour
{
    [SerializeField] private Transform playerBattle;
    [SerializeField] private Transform banditBattle;

    private Transform player;
    private Transform enemy1;
    private int enemyNumber;
    private bool playerChoosingAction;
    private bool selectingEnemy;
    private bool attackingEnemy;
    private bool movingToEnemy;
    public bool finalAttack;
    public bool returnStartPos;
    private int swordAttack;
    private int shurikenAttack;
    private int selectedEnemy;
    private float movePos;
    private float startPos;
    //The action the player is selecting. 0-> Sword, 1-> Shuriken, 2-> Items, 3-> Special, 4-> Other
    public int selectingAction; 

    private void Start()
    {
        SpawnCharacter(0);
        SpawnCharacter(2);
        enemyNumber = 1;
        playerChoosingAction = true;
        selectingEnemy = false;
        attackingEnemy = false;
        movingToEnemy = false;
        finalAttack = false;
    }

    private void Update()
    {
        //The fase when the player chooses what action to do
        if (playerChoosingAction)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                player.GetChild(0).transform.GetChild(0).GetComponent<Animator>().SetTrigger("Left");
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                player.GetChild(0).transform.GetChild(0).GetComponent<Animator>().SetTrigger("Right");
            }
            if (selectingAction == 0 && Input.GetKeyDown(KeyCode.Space))
            {
                playerChoosingAction = false;
                //if nothing is unlocked
                if (true)
                {
                    player.GetChild(0).transform.GetChild(0).GetComponent<Animator>().SetBool("Active", false);
                    swordAttack = 1;
                    shurikenAttack = 0;
                    selectingEnemy = true;
                }
            }
            if (selectingAction == 1 && Input.GetKeyDown(KeyCode.Space))
            {
                playerChoosingAction = false;
                //if nothing is unlocked
                if (true)
                {
                    player.GetChild(0).transform.GetChild(0).GetComponent<Animator>().SetBool("Active", false);
                    swordAttack = 0;
                    shurikenAttack = 1;
                    selectingEnemy = true;
                }
            }            
        }
        else if (selectingEnemy)
        {
            enemy1.GetChild(0).transform.GetChild(0).gameObject.SetActive(true);
            if (enemyNumber > 1)
            {

            }
            else if (Input.GetKeyDown(KeyCode.Space))
            {
                enemy1.GetChild(0).transform.GetChild(0).gameObject.SetActive(false);
                selectedEnemy = 1;
                selectingEnemy = false;
                attackingEnemy = true;
            }
        }
        else if (attackingEnemy)
        {
            if (swordAttack == 1)
            { 
                if(selectedEnemy == 1)
                {
                    startPos = player.transform.position.x;
                    movePos = enemy1.transform.position.x - 1.1f;
                    attackingEnemy = false;
                    movingToEnemy = true;
                }
            }
            else if (shurikenAttack == 1)
            {
                player.GetComponent<Animator>().SetBool("isSpinning", true);
            }
        }
        else if (finalAttack)
        {
            player.GetComponent<Animator>().SetBool("isAttacking", true);
        }
        
        if (Input.GetKeyDown(KeyCode.X))
        {
            player.GetComponent<Animator>().SetBool("isAttacking", false);
            player.GetComponent<Animator>().SetBool("isSpinning", false);
            player.transform.position = new Vector3(-5, -1, -2);
            playerChoosingAction = true;
            selectingEnemy = false;
            attackingEnemy = false;
            finalAttack = false;
            player.GetChild(0).transform.GetChild(0).GetComponent<Animator>().SetBool("Active", true);
            enemy1.GetChild(0).transform.GetChild(0).gameObject.SetActive(false);
        }


    }

    private void FixedUpdate()
    {
        if (movingToEnemy)
        {
            if(player.transform.position.x < movePos)
            {
                player.transform.position = new Vector3(player.transform.position.x + 0.10f, player.transform.position.y, player.transform.position.z);
                player.GetComponent<Animator>().SetFloat("Speed", 0.5f);
            }
            else
            {
                player.GetComponent<Animator>().SetFloat("Speed", 0.0f);
                movingToEnemy = false;
                finalAttack = true;
            }
        }
        else if (returnStartPos)
        {
            if(player.transform.position.x > startPos)
            {
                player.transform.position = new Vector3(player.transform.position.x - 0.15f, player.transform.position.y, player.transform.position.z);
                player.GetComponent<Animator>().SetFloat("Speed", 0.5f);
            }
            else
            {

                Vector3 scale = player.transform.localScale;
                scale.x *= -1;
                player.transform.localScale = scale;
                player.GetComponent<Animator>().SetFloat("Speed", 0.0f);
                returnStartPos = false;
                playerChoosingAction = true;
                player.GetChild(0).transform.GetChild(0).GetComponent<Animator>().SetBool("Active", true);
            }
        }
    }

    //Function to spawn the characters. 0 -> Player, 1-> companion, 2-> Enemy1, 3-> Enemy2, 4-> Enemy3, 5-> Enemy4
    private void SpawnCharacter(int battlePos)
    {
        if (battlePos == 0)
        {
            player = Instantiate(playerBattle, new Vector3(-5, -1, -2), Quaternion.identity);
        }
        else
        {
            enemy1 = Instantiate(banditBattle, new Vector3(4.5f, -0.64f, -2.0f), Quaternion.identity);
        }
        


    }

}
