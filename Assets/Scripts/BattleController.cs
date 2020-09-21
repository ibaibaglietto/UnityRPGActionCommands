using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class BattleController : MonoBehaviour
{
    //The prefabs of the player, companions and enemies
    [SerializeField] private Transform playerBattle;
    [SerializeField] private Transform banditBattle;
    //The prefabs of the damage UI
    [SerializeField] private Transform damageUI;
    //The icons of every action of the menu
    [SerializeField] private Sprite normalSword;
    [SerializeField] private Sprite lightSword;
    [SerializeField] private Sprite normalShuriken;
    [SerializeField] private Sprite lightShuriken;
    //The life points UI
    private GameObject lightPointsUI;
    //The actions instructions
    private GameObject actionInstructions;
    //The enemy name
    private GameObject enemyName;
    //The player, companions and enemies
    private Transform player;
    private Transform enemy1;
    private Transform enemy2;
    //The menu options that can be used
    private bool[] menuCanUse;
    //The sword styles that are active
    private int[] swordStyles;
    //The shuriken styles that are active
    private int[] shurikenStyles;
    //The style we are using at the moment
    private int usingStyle;
    //The damage Image
    private Transform damageImage;
    //Number of enemies the player is facing
    private int enemyNumber;
    //A boolean to check if it is player teams turn
    private bool playerTeamTurn;
    //A boolean to check if it is enemy teams turn
    private bool enemyTeamTurn;
    //A boolean to check if it is first enemys turn
    private bool enemy1Turn;
    //A boolean to check if it is second enemys turn
    private bool enemy2Turn;
    //A boolean to check if the player is choosing the action
    private bool playerChoosingAction;
    //A int to see which position of the menu is being selected
    private int menuSelectionPos;
    //A boolean to see if the player is choosing which enemy to attack
    private bool selectingEnemy;
    //A boolean to see if the player is attacking
    public bool finalAttack;
    //A boolean to check if the player is in his attack action
    public bool attackAction;
    //A boolean to check if the attack has been finished
    public bool attackFinished;
    //A boolean to check if the player has done a good attack
    public bool goodAttack;
    //A boolean to check if the player has done a bad attack
    public bool badAttack;
    //A boolean to save the attack type
    private int attackType;
    //The selected enemy
    private Transform selectedEnemy;
    //A boolean to see if the player is in the defense zone
    private bool defenseZone;
    //A boolean to save if the shuriken hits the enemy
    public bool shurikenHit;
    //A float to know the time we have spent spinning
    public float shurikenTime;
    //The action the player is selecting. 0-> Sword, 1-> Shuriken, 2-> Items, 3-> Special, 4-> Other
    public int selectingAction; 


    private void Awake()
    {
        PlayerPrefs.SetInt("Light Sword", 1);
        PlayerPrefs.SetInt("Sword Styles", PlayerPrefs.GetInt("Light Sword"));
        PlayerPrefs.SetInt("Light Shuriken", 1);
        PlayerPrefs.SetInt("Shuriken Styles", PlayerPrefs.GetInt("Light Shuriken"));
        //Find the gameobjects
        lightPointsUI = GameObject.Find("LightBckImage");
        actionInstructions = GameObject.Find("ActionInstructions");
        enemyName = GameObject.Find("EnemyName");
        //Initialize variables
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
        attackFinished = false;
        goodAttack = false;
        badAttack = false;
        shurikenHit = false;
        defenseZone = false;
        swordStyles = new int[6];
        shurikenStyles = new int[6];
        menuCanUse = new bool[6];
        actionInstructions.SetActive(false);
        enemyName.SetActive(false);
    }

    private void Update()
    {
        //When its players turn
        if (playerTeamTurn)
        {
            //The fase when the player chooses what action to do
            if (playerChoosingAction)
            {
                if (!player.GetChild(0).transform.GetChild(0).GetComponent<Animator>().GetBool("MenuOpened"))
                {
                    //We use left and right arrows to move in the action menu
                    if (Input.GetKeyDown(KeyCode.LeftArrow))
                    {
                        player.GetChild(0).transform.GetChild(0).GetComponent<Animator>().SetTrigger("Left");
                    }
                    else if (Input.GetKeyDown(KeyCode.RightArrow))
                    {
                        player.GetChild(0).transform.GetChild(0).GetComponent<Animator>().SetTrigger("Right");
                    }
                    //We press space to select the action we want to perform
                    if (selectingAction == 0 && Input.GetKeyDown(KeyCode.Space))
                    {
                        //if nothing is unlocked
                        if (PlayerPrefs.GetInt("Sword Styles") == 0)
                        {
                            playerChoosingAction = false;
                            enemyName.SetActive(true);
                            actionInstructions.SetActive(true);
                            actionInstructions.GetComponent<Image>().color = new Vector4(actionInstructions.GetComponent<Image>().color.r, actionInstructions.GetComponent<Image>().color.g, actionInstructions.GetComponent<Image>().color.b, 0.5f);
                            actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = new Vector4(actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color.r, actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color.g, actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color.b, 0.5f);
                            actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Press <sprite=336> just before hitting an enemy.";
                            player.GetChild(0).transform.GetChild(0).GetComponent<Animator>().SetBool("Active", false);
                            attackType = 0;
                            selectingEnemy = true;
                            SelectFirstEnemy();
                        }
                        else
                        {
                            CreateMenu();
                            player.GetChild(0).transform.GetChild(0).GetComponent<Animator>().SetBool("MenuOpened", true);
                        }
                    }
                    else if (selectingAction == 1 && Input.GetKeyDown(KeyCode.Space))
                    {
                        //if nothing is unlocked
                        if (PlayerPrefs.GetInt("Shuriken Styles") == 0)
                        {
                            playerChoosingAction = false;
                            enemyName.SetActive(true);
                            actionInstructions.SetActive(true);
                            actionInstructions.GetComponent<Image>().color = new Vector4(actionInstructions.GetComponent<Image>().color.r, actionInstructions.GetComponent<Image>().color.g, actionInstructions.GetComponent<Image>().color.b, 0.5f);
                            actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = new Vector4(actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color.r, actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color.g, actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color.b, 0.5f);
                            actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Press <sprite=336> when <sprite=360> lights up.";
                            player.GetChild(0).transform.GetChild(0).GetComponent<Animator>().SetBool("Active", false);
                            attackType = 1;
                            selectingEnemy = true;
                            SelectFirstEnemy();
                        }
                        else
                        {
                            CreateMenu();
                            player.GetChild(0).transform.GetChild(0).GetComponent<Animator>().SetBool("MenuOpened", true);
                        }
                    }
                    else if (selectingAction == 2 && Input.GetKeyDown(KeyCode.Space))
                    {
                        player.GetChild(0).transform.GetChild(0).GetComponent<Animator>().SetBool("MenuOpened", true);
                    }
                    else if (selectingAction == 3 && Input.GetKeyDown(KeyCode.Space))
                    {
                        player.GetChild(0).transform.GetChild(0).GetComponent<Animator>().SetBool("MenuOpened", true);
                    }
                    else if (selectingAction == 4 && Input.GetKeyDown(KeyCode.Space))
                    {
                        player.GetChild(0).transform.GetChild(0).GetComponent<Animator>().SetBool("MenuOpened", true);
                    }
                }
                else
                {
                    if (selectingAction == 0)
                    {
                        if((menuSelectionPos < PlayerPrefs.GetInt("Sword Styles")) && Input.GetKeyDown(KeyCode.DownArrow))
                        {
                            player.GetChild(0).transform.GetChild(0).GetComponent<Animator>().SetTrigger("Down");
                        }
                        else if(menuSelectionPos > 0 && Input.GetKeyDown(KeyCode.UpArrow))
                        {
                            player.GetChild(0).transform.GetChild(0).GetComponent<Animator>().SetTrigger("Up");
                        }
                        if (Input.GetKeyDown(KeyCode.Space) && menuCanUse[menuSelectionPos])
                        {
                            if (menuSelectionPos == 0) usingStyle = 0;
                            else if (menuSelectionPos == 1) usingStyle = swordStyles[0];
                            player.GetChild(0).transform.GetChild(0).GetComponent<Animator>().SetBool("MenuOpened", false);
                            playerChoosingAction = false;
                            enemyName.SetActive(true);
                            actionInstructions.SetActive(true);
                            actionInstructions.GetComponent<Image>().color = new Vector4(actionInstructions.GetComponent<Image>().color.r, actionInstructions.GetComponent<Image>().color.g, actionInstructions.GetComponent<Image>().color.b, 0.5f);
                            actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = new Vector4(actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color.r, actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color.g, actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color.b, 0.5f);
                            if(usingStyle == 0) actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Press <sprite=336> just before hitting an enemy.";
                            else if(usingStyle == 1) actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Press and hold <sprite=336> until <sprite=360> fills completely.";
                            player.GetChild(0).transform.GetChild(0).GetComponent<Animator>().SetBool("Active", false);
                            attackType = 0;
                            selectingEnemy = true;
                            SelectFirstEnemy();
                        }
                    }
                    else if(selectingAction == 1)
                    {
                        if ((menuSelectionPos < PlayerPrefs.GetInt("Shuriken Styles")) && Input.GetKeyDown(KeyCode.DownArrow))
                        {
                            player.GetChild(0).transform.GetChild(0).GetComponent<Animator>().SetTrigger("Down");
                        }
                        else if (menuSelectionPos > 0 && Input.GetKeyDown(KeyCode.UpArrow))
                        {
                            player.GetChild(0).transform.GetChild(0).GetComponent<Animator>().SetTrigger("Up");
                        }
                        if (Input.GetKeyDown(KeyCode.Space) && menuCanUse[menuSelectionPos])
                        {
                            if (menuSelectionPos == 0) usingStyle = 0;
                            else if (menuSelectionPos == 1) usingStyle = shurikenStyles[0];
                            player.GetChild(0).transform.GetChild(0).GetComponent<Animator>().SetBool("MenuOpened", false);
                            playerChoosingAction = false;
                            enemyName.SetActive(true);
                            actionInstructions.SetActive(true);
                            actionInstructions.GetComponent<Image>().color = new Vector4(actionInstructions.GetComponent<Image>().color.r, actionInstructions.GetComponent<Image>().color.g, actionInstructions.GetComponent<Image>().color.b, 0.5f);
                            actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = new Vector4(actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color.r, actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color.g, actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color.b, 0.5f);
                            actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Press <sprite=336> when <sprite=360> lights up.";
                            player.GetChild(0).transform.GetChild(0).GetComponent<Animator>().SetBool("Active", false);
                            attackType = 1;
                            selectingEnemy = true;
                            SelectFirstEnemy();
                        }
                    }
                    else if (selectingAction == 2)
                    {

                    }
                    else if (selectingAction == 3)
                    {

                    }
                    else if (selectingAction == 4)
                    {

                    }
                    if (Input.GetKeyDown(KeyCode.Q))
                    {
                        player.GetChild(0).transform.GetChild(0).GetComponent<Animator>().SetBool("MenuOpened", false);
                    }
                }
            } 
            //When we attack we enter the selcting enemy fase
            else if (selectingEnemy)
            {
                //Press Q to return to start fase
                if (Input.GetKeyDown(KeyCode.Q))
                {
                    enemyName.SetActive(false);
                    actionInstructions.SetActive(false);
                    playerChoosingAction = true;
                    selectingEnemy = false;
                    player.GetChild(0).transform.GetChild(0).GetComponent<Animator>().SetBool("Active", true);
                    enemy1.GetChild(0).transform.GetChild(0).gameObject.SetActive(false);
                    enemy2.GetChild(0).transform.GetChild(0).gameObject.SetActive(false);
                }
                //When we have 2 enemies we decide which enemy to attack using the arrows and we select it using space and the attack starts
                if (enemyNumber == 2)
                {
                    if (enemy1.GetChild(0).transform.GetChild(0).gameObject.activeSelf)
                    {
                        if (Input.GetKeyDown(KeyCode.RightArrow) && enemy2.GetComponent<EnemyTeamScript>().IsAlive())
                        {
                            enemy1.GetChild(0).transform.GetChild(0).gameObject.SetActive(false);
                            enemy2.GetChild(0).transform.GetChild(0).gameObject.SetActive(true);
                            if (enemy2.GetComponent<EnemyTeamScript>().enemyType == 0)
                            {
                                enemyName.transform.GetChild(0).GetComponent<Text>().text = "Bandit";
                            }
                        }
                        if (Input.GetKeyDown(KeyCode.Space))
                        {
                            enemy1.GetChild(0).transform.GetChild(0).gameObject.SetActive(false);
                            selectedEnemy = enemy1;
                            selectingEnemy = false;
                            enemyName.SetActive(false);
                            actionInstructions.GetComponent<Image>().color = new Vector4(actionInstructions.GetComponent<Image>().color.r, actionInstructions.GetComponent<Image>().color.g, actionInstructions.GetComponent<Image>().color.b, 1.0f);
                            actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = new Vector4(actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color.r, actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color.g, actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color.b, 1.0f);
                            player.GetComponent<PlayerTeamScript>().Attack(attackType, usingStyle, enemy1);
                        }
                    }
                    else if (enemy2.GetChild(0).transform.GetChild(0).gameObject.activeSelf)
                    {
                        if (Input.GetKeyDown(KeyCode.LeftArrow) && enemy1.GetComponent<EnemyTeamScript>().IsAlive())
                        {
                            enemy1.GetChild(0).transform.GetChild(0).gameObject.SetActive(true);
                            enemy2.GetChild(0).transform.GetChild(0).gameObject.SetActive(false);
                            if (enemy1.GetComponent<EnemyTeamScript>().enemyType == 0)
                            {
                                enemyName.transform.GetChild(0).GetComponent<Text>().text = "Bandit";
                            }
                        }
                        if (Input.GetKeyDown(KeyCode.Space))
                        {
                            enemy2.GetChild(0).transform.GetChild(0).gameObject.SetActive(false);
                            selectedEnemy = enemy2;
                            selectingEnemy = false;
                            enemyName.SetActive(false);
                            actionInstructions.GetComponent<Image>().color = new Vector4(actionInstructions.GetComponent<Image>().color.r, actionInstructions.GetComponent<Image>().color.g, actionInstructions.GetComponent<Image>().color.b, 1.0f);
                            actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = new Vector4(actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color.r, actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color.g, actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color.b, 1.0f);
                            player.GetComponent<PlayerTeamScript>().Attack(attackType, usingStyle, enemy2);
                        }
                    }
                }
                //If there is only one enemy we select it using space and the attack starts
                else if (Input.GetKeyDown(KeyCode.Space))
                {
                    enemy1.GetChild(0).transform.GetChild(0).gameObject.SetActive(false);
                    selectedEnemy = enemy1;
                    selectingEnemy = false;
                    enemyName.SetActive(false);
                    actionInstructions.SetActive(false);
                    player.GetComponent<PlayerTeamScript>().Attack(attackType, usingStyle, enemy1);
                }
            }
            //The fase where the player deals the attack
            else if (finalAttack)
            {
                //If it is a melee attack
                if (attackType == 0)
                {
                    if (usingStyle == 0)
                    {
                        //We check if the player presses the button when it is asked to be pressed
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
                    else if (usingStyle == 1)
                    {
                        if (Input.GetKeyDown(KeyCode.X))
                        {
                            DeactivateActionInstructions();
                            player.GetComponent<Animator>().SetTrigger("chargeLightMelee");
                            player.transform.GetChild(0).transform.GetChild(2).GetComponent<Animator>().SetBool("charging", true);
                        }
                        if(Input.GetKeyUp(KeyCode.X) && attackAction) 
                        {
                            player.GetComponent<Animator>().SetTrigger("goodChargeMelee");
                            player.transform.GetChild(0).transform.GetChild(2).GetComponent<Animator>().SetBool("charging", false);
                            player.transform.GetChild(0).transform.GetChild(2).GetComponent<Animator>().SetBool("active", false);
                            attackAction = false;
                            finalAttack = false;
                        }
                        else if (Input.GetKeyUp(KeyCode.X) && !attackAction && !attackFinished)
                        {
                            player.GetComponent<Animator>().SetTrigger("badChargeMelee");
                            player.transform.GetChild(0).transform.GetChild(2).GetComponent<Animator>().SetBool("charging", false);
                            player.transform.GetChild(0).transform.GetChild(2).GetComponent<Animator>().SetBool("active", false);
                            finalAttack = false;
                        }
                        else if (attackFinished)
                        {
                            player.GetComponent<Animator>().SetTrigger("badChargeMelee");
                            player.transform.GetChild(0).transform.GetChild(2).GetComponent<Animator>().SetBool("charging", false);
                            player.transform.GetChild(0).transform.GetChild(2).GetComponent<Animator>().SetBool("active", false);
                            finalAttack = false;
                        }
                    }
                }
                //If it is a shuriken attack
                else if (attackType == 1)
                {
                    if(usingStyle == 0)
                    {
                        //We check if the button is pressed correctly and we wait the shuriken to hit
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
                    else if(usingStyle == 1)
                    {
                        if (Time.fixedTime - shurikenTime < 5.0f && player.transform.GetChild(0).transform.GetChild(3).transform.GetChild(1).GetComponent<Image>().fillAmount < 1.0f && Input.GetKeyDown(KeyCode.X))
                        {
                            Debug.Log(player.transform.GetChild(0).transform.GetChild(3).transform.GetChild(1).GetComponent<Image>().fillAmount);
                            player.transform.GetChild(0).transform.GetChild(3).transform.GetChild(1).GetComponent<Image>().fillAmount = 1.0f; 
                            if (player.transform.GetChild(0).transform.GetChild(3).transform.GetChild(1).GetComponent<Image>().fillAmount >= 1.0f)
                            {
                                player.transform.GetChild(0).transform.GetChild(3).GetComponent<Animator>().SetTrigger("Filled");
                            }
                            Debug.Log(player.transform.GetChild(0).transform.GetChild(3).transform.GetChild(1).GetComponent<Image>().fillAmount);
                        }
                    }
                }
            }
            //We end the players turn when the player ends the shuriken animation
            else if (shurikenHit)
            {
                shurikenHit = false;
                EndPlayerTurn();
            }      
        }
        //The enemy turn
        else if (enemyTeamTurn)
        {
            //When it is first enemys turn and its alive it attacks
            if (enemy1Turn && enemy1.GetComponent<EnemyTeamScript>().IsIdle())
            {
                if (enemy1.GetComponent<EnemyTeamScript>().IsAlive())
                {
                    enemy1.GetComponent<EnemyTeamScript>().Attack(player);
                    enemy1Turn = false;
                }
                else
                {
                    enemy1Turn = false;
                    if (enemyNumber > 1) NextEnemy(1);
                    else EndEnemyTurn();
                }
            }
            //We check that the enemy is attacking and that it is in the defense zone. If the player presses X correctly they will defend, receiveing 1 less damage
            else if (enemy1.GetComponent<EnemyTeamScript>().IsAttacking())
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
            //The same with the rest of the enemies
            if (enemy2Turn && enemy2.GetComponent<EnemyTeamScript>().IsIdle())
            {
                if (enemy2.GetComponent<EnemyTeamScript>().IsAlive())
                {
                    enemy2.GetComponent<EnemyTeamScript>().Attack(player);
                    enemy2Turn = false;
                }
                else
                {
                    enemy2Turn = false;
                    if (enemyNumber > 2) NextEnemy(2);
                    else EndEnemyTurn();
                }                    
            }
            else if (enemy2.GetComponent<EnemyTeamScript>().IsAttacking())
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
    }

    private void FixedUpdate()
    {
        if(finalAttack && attackType == 1 && usingStyle == 1)
        {
            if (Time.fixedTime - shurikenTime < 5.0f )
            {
                if(player.transform.GetChild(0).transform.GetChild(3).transform.GetChild(1).GetComponent<Image>().fillAmount < 1.0f)
                {
                    Debug.Log("buenas");
                    //player.transform.GetChild(0).transform.GetChild(3).transform.GetChild(1).GetComponent<Image>().fillAmount -= 0.002f;                    
                }                
            }
            else if(player.transform.GetChild(0).transform.GetChild(3).transform.GetChild(1).GetComponent<Image>().fillAmount < 1.0f)
            {
                player.GetChild(0).transform.GetChild(3).GetComponent<Animator>().SetBool("Active", false);
                player.GetComponent<Animator>().SetBool("isSpinning", false);
                player.GetComponent<PlayerTeamScript>().SetShurikenDamage(1);
            }
            else if(player.transform.GetChild(0).transform.GetChild(3).transform.GetChild(1).GetComponent<Image>().fillAmount >= 1.0f)
            {
                player.GetChild(0).transform.GetChild(3).GetComponent<Animator>().SetBool("Active", false);
                player.GetComponent<Animator>().SetBool("isSpinning", false);
                player.GetComponent<PlayerTeamScript>().SetShurikenDamage(4);
            }
        }
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
    //Function that returns the selected enemy
    public Transform GetSelectedEnemy()
    {
        return selectedEnemy;
    }
    //Function to deal damage to an enemy, giving the enemy, the amount of damage and a boolean that says if it is the last attack
    public void DealDamage(Transform objective, int damage, bool last)
    {
        //We instantiate the damage UI and save the damage amount
        damageImage = Instantiate(damageUI, new Vector3(objective.transform.position.x -0.25f, objective.transform.position.y + 1.0f, 0), Quaternion.identity, objective.transform.GetChild(0));
        damageImage.GetChild(0).GetComponent<Text>().text = damage.ToString();
        //We deal damage to the objective
        objective.transform.GetChild(0).transform.GetChild(2).GetComponent<EnemyLifeControllerScript>().DealDamage(damage);
        //if the enemy is dead and it is the last attack we play the die animation, else we play the damage animation
        if(objective.transform.GetChild(0).transform.GetChild(2).GetComponent<EnemyLifeControllerScript>().GetHealth() <= 0 && last)
        {
            objective.GetComponent<EnemyTeamScript>().EnemyDied();
            objective.GetComponent<Animator>().SetBool("IsDead", true);
            objective.GetChild(0).transform.GetChild(2).gameObject.SetActive(false);
        }
        else
        {
            objective.GetComponent<Animator>().SetTrigger("TakeDamage");
        }
    }

    //A function to end players turn
    public void EndPlayerTurn()
    {
        playerChoosingAction = true;
        playerTeamTurn = false;
        enemyTeamTurn = true;
        enemy1Turn = true;
    }

    //A function to end enemy turn
    public void EndEnemyTurn()
    {
        player.GetChild(0).transform.GetChild(0).GetComponent<Animator>().SetBool("Active", true);
        playerTeamTurn = true;
        enemyTeamTurn = false;
    }

    //A function to pass the turn to the next enemy
    public void NextEnemy(int numb)
    {
        if(numb == 1)
        {
            enemy2Turn = true;
        }
    }

    //A function to start the defense zone
    public void StartDefenseZone()
    {
        defenseZone = true;
    }

    //A function to end the defense zone
    public void EndDefenseZone()
    {
        defenseZone = false;
    }

    //A function to get the number of enemies
    public int GetNumberOfEnemies()
    {
        return enemyNumber;
    }

    //A function to select the first available enemy
    private void SelectFirstEnemy()
    {
        if (enemy1.GetComponent<EnemyTeamScript>().IsAlive())
        {
            enemy1.GetChild(0).transform.GetChild(0).gameObject.SetActive(true);
            if(enemy1.GetComponent<EnemyTeamScript>().enemyType == 0)
            {
                enemyName.transform.GetChild(0).GetComponent<Text>().text = "Bandit";
            }
        }
        else if(enemyNumber > 1 && enemy2.GetComponent<EnemyTeamScript>().IsAlive())
        {
            enemy2.GetChild(0).transform.GetChild(0).gameObject.SetActive(true);
            if (enemy2.GetComponent<EnemyTeamScript>().enemyType == 0)
            {
                enemyName.transform.GetChild(0).GetComponent<Text>().text = "Bandit";
            }
        }
    }

    //Function to deactivate the action command instructions
    public void DeactivateActionInstructions()
    {
        actionInstructions.SetActive(false);
    }

    //Function to set the menu selection pos
    public void SetMenuSelectionPos(int pos)
    {
        menuSelectionPos = pos;
    }


    //Function to create the menu
    private void CreateMenu()
    {
        int number;
        if(selectingAction == 0)
        {
            number = PlayerPrefs.GetInt("Sword Styles");
            if (number == 1)
            {
                player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(1).transform.GetChild(0).GetComponent<Image>().sprite = normalSword;
                player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(1).transform.GetChild(1).GetComponent<Text>().text = "Normal sword";
                player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(1).transform.GetChild(2).GetComponent<Text>().text = "";
                menuCanUse[0] = true;
                if(PlayerPrefs.GetInt("Light Sword") == 1)
                {
                    swordStyles[0] = 1;
                    player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(2).transform.GetChild(0).GetComponent<Image>().sprite = lightSword;
                    player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(2).transform.GetChild(1).GetComponent<Text>().text = "Light sword";
                    player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(2).transform.GetChild(2).GetComponent<Text>().text = "2 LP";
                    if (!lightPointsUI.GetComponent<LightPointsScript>().CanUseHability(2))
                    {
                        player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(2).GetComponent<Image>().color = new Vector4(0.55f, 0.55f, 0.55f, 1.0f);
                        player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(2).transform.GetChild(0).GetComponent<Image>().color = new Vector4(0.55f, 0.55f, 0.55f, 1.0f);
                        menuCanUse[1] = false;
                    }
                    else
                    {
                        player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(2).GetComponent<Image>().color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
                        player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(2).transform.GetChild(0).GetComponent<Image>().color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
                        menuCanUse[1] = true;
                    }
                }                    
                player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(3).gameObject.SetActive(false);
                player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(4).gameObject.SetActive(false);
                player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(5).gameObject.SetActive(false);
                player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(6).gameObject.SetActive(false);
            }
            else if (number == 2)
            {
                player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(3).gameObject.SetActive(true);
                player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(4).gameObject.SetActive(false);
                player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(5).gameObject.SetActive(false);
                player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(6).gameObject.SetActive(false);
            }
            else if (number == 3)
            {
                player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(3).gameObject.SetActive(true);
                player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(4).gameObject.SetActive(true);
                player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(5).gameObject.SetActive(false);
                player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(6).gameObject.SetActive(false);
            }
            else if (number == 4)
            {
                player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(3).gameObject.SetActive(true);
                player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(4).gameObject.SetActive(true);
                player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(5).gameObject.SetActive(true);
                player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(6).gameObject.SetActive(false);
            }
            else if (number == 5)
            {
                player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(3).gameObject.SetActive(true);
                player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(4).gameObject.SetActive(true);
                player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(5).gameObject.SetActive(true);
                player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(6).gameObject.SetActive(true);
            }
        }
        else if (selectingAction == 1)
        {
            number = PlayerPrefs.GetInt("Shuriken Styles");
            if (number == 1)
            {
                player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(1).transform.GetChild(0).GetComponent<Image>().sprite = normalShuriken;
                player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(1).transform.GetChild(1).GetComponent<Text>().text = "Normal shuriken";
                player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(1).transform.GetChild(2).GetComponent<Text>().text = "";
                menuCanUse[0] = true;
                if (PlayerPrefs.GetInt("Light Shuriken") == 1)
                {
                    shurikenStyles[0] = 1;
                    player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(2).transform.GetChild(0).GetComponent<Image>().sprite = lightShuriken;
                    player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(2).transform.GetChild(1).GetComponent<Text>().text = "Light shuriken";
                    player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(2).transform.GetChild(2).GetComponent<Text>().text = "2 LP";
                    if (!lightPointsUI.GetComponent<LightPointsScript>().CanUseHability(2))
                    {
                        player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(2).GetComponent<Image>().color = new Vector4(0.55f,0.55f,0.55f,1.0f);
                        player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(2).transform.GetChild(0).GetComponent<Image>().color = new Vector4(0.55f, 0.55f, 0.55f, 1.0f);
                        menuCanUse[1] = false;
                    }
                    else
                    {
                        player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(2).GetComponent<Image>().color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
                        player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(2).transform.GetChild(0).GetComponent<Image>().color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
                        menuCanUse[1] = true;
                    }
                }
                player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(3).gameObject.SetActive(false);
                player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(4).gameObject.SetActive(false);
                player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(5).gameObject.SetActive(false);
                player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(6).gameObject.SetActive(false);
            }
            else if (number == 2)
            {
                player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(3).gameObject.SetActive(true);
                player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(4).gameObject.SetActive(false);
                player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(5).gameObject.SetActive(false);
                player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(6).gameObject.SetActive(false);
            }
            else if (number == 3)
            {
                player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(3).gameObject.SetActive(true);
                player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(4).gameObject.SetActive(true);
                player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(5).gameObject.SetActive(false);
                player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(6).gameObject.SetActive(false);
            }
            else if (number == 4)
            {
                player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(3).gameObject.SetActive(true);
                player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(4).gameObject.SetActive(true);
                player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(5).gameObject.SetActive(true);
                player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(6).gameObject.SetActive(false);
            }
            else if (number == 5)
            {
                player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(3).gameObject.SetActive(true);
                player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(4).gameObject.SetActive(true);
                player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(5).gameObject.SetActive(true);
                player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(6).gameObject.SetActive(true);
            }
        }
    }
}
