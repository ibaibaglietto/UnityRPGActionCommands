using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleController : MonoBehaviour
{
    [SerializeField] private Transform playerBattle;
    [SerializeField] private Transform banditBattle;

    private Transform player;
    private Transform enemy1;
    private Transform enemy2;
    private int enemyNumber;
    private bool playerTeamTurn;
    private bool enemyTeamTurn;
    private bool enemy1Turn;
    private bool enemy1Attack;
    private bool enemy2Turn;
    private bool enemy2Attack;
    private bool playerChoosingAction;
    private bool selectingEnemy;
    public bool finalAttack;
    public bool returnStartPos;
    public bool attackAction;
    public bool goodAttack;
    public bool badAttack;
    private int attackType;
    private Transform selectedEnemy;
    private bool defenseZone;
    public bool shurikenHit;
    //The action the player is selecting. 0-> Sword, 1-> Shuriken, 2-> Items, 3-> Special, 4-> Other
    public int selectingAction; 

    private void Start()
    {
        enemyNumber = 0;
        SpawnCharacter(0);
        SpawnCharacter(2);
        SpawnCharacter(3);
        playerTeamTurn = true;
        enemyTeamTurn = false;
        enemy1Turn = false;
        playerChoosingAction = true;
        selectingEnemy = false;
        finalAttack = false;
        attackAction = false;
        goodAttack = false;
        badAttack = false;
        shurikenHit = false;
        defenseZone = false;
    }

    private void Update()
    {
        if (playerTeamTurn)
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
                        attackType = 0;
                        selectingEnemy = true;
                        SelectFirstEnemy();
                    }
                }
                if (selectingAction == 1 && Input.GetKeyDown(KeyCode.Space))
                {
                    playerChoosingAction = false;
                    //if nothing is unlocked
                    if (true)
                    {
                        player.GetChild(0).transform.GetChild(0).GetComponent<Animator>().SetBool("Active", false);
                        attackType = 1;
                        selectingEnemy = true;
                        SelectFirstEnemy();
                    }
                }
            }
            else if (selectingEnemy)
            {
                if (enemyNumber == 2)
                {
                    if (enemy1.GetChild(0).transform.GetChild(0).gameObject.activeSelf)
                    {
                        if (Input.GetKeyDown(KeyCode.RightArrow) && enemy2.GetComponent<EnemyTeamScript>().isAlive())
                        {
                            enemy1.GetChild(0).transform.GetChild(0).gameObject.SetActive(false);
                            enemy2.GetChild(0).transform.GetChild(0).gameObject.SetActive(true);
                            Debug.Log(enemy1.GetChild(0).transform.GetChild(0).gameObject.activeSelf);
                            Debug.Log(enemy2.GetChild(0).transform.GetChild(0).gameObject.activeSelf);
                        }
                        if (Input.GetKeyDown(KeyCode.Space))
                        {
                            enemy1.GetChild(0).transform.GetChild(0).gameObject.SetActive(false);
                            selectedEnemy = enemy1;
                            selectingEnemy = false;
                            player.GetComponent<PlayerTeamScript>().Attack(attackType, 0, enemy1);
                        }
                    }
                    else if (enemy2.GetChild(0).transform.GetChild(0).gameObject.activeSelf)
                    {
                        if (Input.GetKeyDown(KeyCode.LeftArrow) && enemy1.GetComponent<EnemyTeamScript>().isAlive())
                        {
                            enemy1.GetChild(0).transform.GetChild(0).gameObject.SetActive(true);
                            enemy2.GetChild(0).transform.GetChild(0).gameObject.SetActive(false);
                        }
                        if (Input.GetKeyDown(KeyCode.Space))
                        {
                            enemy2.GetChild(0).transform.GetChild(0).gameObject.SetActive(false);
                            selectedEnemy = enemy2;
                            selectingEnemy = false;
                            player.GetComponent<PlayerTeamScript>().Attack(attackType, 0, enemy2);
                        }
                    }
                }
                else if (Input.GetKeyDown(KeyCode.Space))
                {
                    enemy1.GetChild(0).transform.GetChild(0).gameObject.SetActive(false);
                    selectedEnemy = enemy1;
                    selectingEnemy = false;
                    player.GetComponent<PlayerTeamScript>().Attack(attackType, 0, enemy1);
                }
            }
            else if (finalAttack)
            {
                if (attackType == 0)
                {
                    if (!attackAction && Input.GetKeyDown(KeyCode.X)) badAttack = true;
                    if (attackAction)
                    {
                        selectedEnemy.GetChild(0).transform.GetChild(1).gameObject.GetComponent<Animator>().SetBool("Pressed", true);
                        if (Input.GetKeyDown(KeyCode.X) && !badAttack)
                        {
                            goodAttack = true;
                        }
                    }
                    else
                    {
                        selectedEnemy.GetChild(0).transform.GetChild(1).gameObject.GetComponent<Animator>().SetBool("Pressed", false);
                    }
                    player.GetComponent<Animator>().SetBool("isAttacking", true);
                }
                else if (attackType == 1)
                {
                    if (Input.GetKeyDown(KeyCode.X))
                    {
                        player.GetChild(0).transform.GetChild(1).GetComponent<Animator>().SetBool("Active", false);
                        player.GetComponent<Animator>().SetBool("isSpinning", false);
                        if (attackAction)
                        {
                            player.GetComponent<PlayerTeamScript>().SetShurikenDamage(2);
                        }
                        else
                        {
                            player.GetComponent<PlayerTeamScript>().SetShurikenDamage(1);
                        }
                        finalAttack = false;
                    }
                }
            }
            else if (shurikenHit)
            {
                shurikenHit = false;
                EndPlayerTurn();
            }      
        }
        else if (enemyTeamTurn)
        {
            if (enemy1Turn)
            {
                if (enemy1.GetComponent<EnemyTeamScript>().isAlive())
                {
                    enemy1.GetComponent<EnemyTeamScript>().Attack(player);
                    enemy1Turn = false;
                    enemy1Attack = true;
                }
                else
                {
                    enemy1Turn = false;
                    if (enemyNumber > 1) NextEnemy(1);
                    else EndEnemyTurn();
                }
            }
            else if (enemy1.GetComponent<EnemyTeamScript>().isAttacking())
            {
                if (Input.GetKeyDown(KeyCode.X))
                {
                    if (defenseZone)
                    {
                        enemy1.GetComponent<EnemyTeamScript>().IsDefended(true);
                    }
                    else enemy1.GetComponent<EnemyTeamScript>().IsDefended(false);
                }
            }
            
            if (enemy2Turn)
            {
                if (enemy2.GetComponent<EnemyTeamScript>().isAlive())
                {
                    enemy2.GetComponent<EnemyTeamScript>().Attack(player);
                    enemy2Turn = false;
                    enemy2Attack = true;
                }
                else
                {
                    enemy2Turn = false;
                    if (enemyNumber > 2) NextEnemy(2);
                    else EndEnemyTurn();
                }
                    
            }
            else if (enemy2Attack)
            {
                if (Input.GetKeyDown(KeyCode.X))
                {
                    if (defenseZone)
                    {
                        enemy2.GetComponent<EnemyTeamScript>().IsDefended(true);
                    }
                    else enemy2.GetComponent<EnemyTeamScript>().IsDefended(false);
                }
            }
            
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            player.GetChild(0).transform.GetChild(1).GetComponent<Animator>().SetBool("Active", false);
            player.GetComponent<Animator>().SetBool("isAttacking", false);
            player.GetComponent<Animator>().SetBool("isSpinning", false);
            player.transform.position = new Vector3(-5, -1, -2);
            playerChoosingAction = true;
            playerTeamTurn = true;
            selectingEnemy = false;
            finalAttack = false;
            player.GetChild(0).transform.GetChild(0).GetComponent<Animator>().SetBool("Active", true);
            enemy1.GetChild(0).transform.GetChild(0).gameObject.SetActive(false);
        }
    }

    private void FixedUpdate()
    {
                
    }

    //Function to spawn the characters. 0 -> Player, 1-> companion, 2-> Enemy1, 3-> Enemy2, 4-> Enemy3, 5-> Enemy4
    private void SpawnCharacter(int battlePos)
    {
        if (battlePos == 0)
        {
            player = Instantiate(playerBattle, new Vector3(-5, -1, -2.0f), Quaternion.identity);
        }
        else if (battlePos == 2)
        {
            enemyNumber += 1;
            enemy1 = Instantiate(banditBattle, new Vector3(3.0f, -0.64f, -2.0f), Quaternion.identity);
            enemy1.GetComponent<EnemyTeamScript>().SetNumber(enemyNumber);
        }
        else if (battlePos == 3)
        {
            enemyNumber += 1;
            enemy2 = Instantiate(banditBattle, new Vector3(4.5f, -0.64f, -2.0f), Quaternion.identity);
            enemy2.GetComponent<EnemyTeamScript>().SetNumber(enemyNumber);
        }
    }

    public Transform getSelectedEnemy()
    {
        return selectedEnemy;
    }

    public void DealDamage(Transform objective, int damage)
    {
        objective.transform.GetChild(0).transform.GetChild(3).transform.GetChild(0).GetComponent<Animator>().SetTrigger("Damaged");
        objective.transform.GetChild(0).transform.GetChild(3).transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = damage.ToString();
        objective.transform.GetChild(0).transform.GetChild(2).GetComponent<EnemyLifeControllerScript>().DealDamage(damage);
        if (objective.transform.GetChild(0).transform.GetChild(2).GetComponent<EnemyLifeControllerScript>().getHealth() > 0)
        {
            objective.GetComponent<Animator>().SetTrigger("TakeDamage");
        }
        else
        {
            objective.GetComponent<EnemyTeamScript>().EnemyDied();
            objective.GetComponent<Animator>().SetBool("IsDead", true);
            objective.GetChild(0).transform.GetChild(2).gameObject.SetActive(false);
        }
    }

    public void EndPlayerTurn()
    {
        playerChoosingAction = true;
        playerTeamTurn = false;
        enemyTeamTurn = true;
        enemy1Turn = true;
    }

    public void EndEnemyTurn()
    {
        player.GetChild(0).transform.GetChild(0).GetComponent<Animator>().SetBool("Active", true);
        playerTeamTurn = true;
        enemyTeamTurn = false;
    }

    public void NextEnemy(int numb)
    {
        if(numb == 1)
        {
            enemy1Attack = false;
            enemy2Turn = true;
        }
    }

    public void StartDefenseZone()
    {
        defenseZone = true;
    }

    public void EndDefenseZone()
    {
        defenseZone = false;
    }

    public int GetNumberOfEnemies()
    {
        return enemyNumber;
    }

    private void SelectFirstEnemy()
    {
        if (enemy1.GetComponent<EnemyTeamScript>().isAlive())
        {
            enemy1.GetChild(0).transform.GetChild(0).gameObject.SetActive(true);
        }
        else if(enemyNumber > 1 && enemy2.GetComponent<EnemyTeamScript>().isAlive())
        {
            enemy2.GetChild(0).transform.GetChild(0).gameObject.SetActive(true);
        }
    }
}
