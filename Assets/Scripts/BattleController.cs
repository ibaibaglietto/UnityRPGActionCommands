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
    //The prefabs of the damage UI, heart and light
    [SerializeField] private Transform damageUI;
    //The icons of every action of the menu
    [SerializeField] private Sprite normalSword;
    [SerializeField] private Sprite lightSword;
    [SerializeField] private Sprite multiStrikeSword;
    [SerializeField] private Sprite normalShuriken;
    [SerializeField] private Sprite lightShuriken;
    [SerializeField] private Sprite fireShuriken;
    [SerializeField] private Sprite apple;
    [SerializeField] private Sprite lightPotion;
    [SerializeField] private Sprite partnerChange;
    [SerializeField] private Sprite defend;
    [SerializeField] private Sprite run;
    //The images of the shuriken light action fill bar
    [SerializeField] private Sprite emptyIcon;
    [SerializeField] private Sprite fillIcon;
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
    //The items the player has. 0-> no item, 1-> apple
    private int[] items = {2,1,1,2,2,1,1,2,1,2,0,0,0,0,0,0,0,0,0,0};
    //The number of times the player has scrolled down (item menu)
    private int scroll;
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
    //A boolean to see if the player is choosing which partner give the object
    private bool selectingPlayer;
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
    //A boolean to check if the last button pressed was the left arrow. Used on the fire shuriken
    private bool lastLeft;
    //A boolean to save the attack type
    private int attackType;
    //A boolean to know is we can select the enemy
    private bool canSelect;
    //The selected enemy
    private Transform selectedEnemy;
    //A boolean to see if the player is in the defense zone
    private bool defenseZone;
    //A boolean to save if the shuriken hits the enemy
    public bool shurikenHit;
    //A float to know the time we have spent spinning
    public float shurikenTime;
    //A bool to know if the player is trying to flee
    private bool fleeing;
    //A float to know the time the player started fleeing
    private float fleeTime;
    //Boolean to know if the flee bar is moving right or left
    private bool fleeRight;
    //The action the player is selecting. 0-> Sword, 1-> Shuriken, 2-> Items, 3-> Special, 4-> Other
    public int selectingAction; 


    private void Awake()
    {
        PlayerPrefs.SetInt("Light Sword", 1);
        PlayerPrefs.SetInt("Multistrike Sword", 1);
        PlayerPrefs.SetInt("Sword Styles", PlayerPrefs.GetInt("Light Sword") + PlayerPrefs.GetInt("Multistrike Sword"));
        PlayerPrefs.SetInt("Light Shuriken", 1);
        PlayerPrefs.SetInt("Fire Shuriken", 1);
        PlayerPrefs.SetInt("Shuriken Styles", PlayerPrefs.GetInt("Light Shuriken") + PlayerPrefs.GetInt("Fire Shuriken"));
        //Find the gameobjects
        lightPointsUI = GameObject.Find("LightBckImage");
        actionInstructions = GameObject.Find("ActionInstructions");
        enemyName = GameObject.Find("EnemyNames");
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
        selectingPlayer = false;
        finalAttack = false;
        attackAction = false;
        attackFinished = false;
        goodAttack = false;
        badAttack = false;
        lastLeft = false;
        shurikenHit = false;
        defenseZone = false;
        canSelect = false;
        fleeing = false;
        swordStyles = new int[6];
        shurikenStyles = new int[6];
        scroll = 0;
        menuCanUse = new bool[6];
        actionInstructions.SetActive(false);
        enemyName.SetActive(false);
        player.GetChild(0).transform.GetChild(3).gameObject.SetActive(false);
        player.GetChild(0).transform.GetChild(4).gameObject.SetActive(false);
        player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(7).GetComponent<Image>().color = new Vector4(player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(7).GetComponent<Image>().color.r, player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(7).GetComponent<Image>().color.g, player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(7).GetComponent<Image>().color.b, 0.0f);
        player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(8).GetComponent<Image>().color = new Vector4(player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(7).GetComponent<Image>().color.r, player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(7).GetComponent<Image>().color.g, player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(7).GetComponent<Image>().color.b, 0.0f);
        player.GetChild(0).transform.GetChild(6).gameObject.SetActive(false);
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
                            actionInstructions.SetActive(true);
                            actionInstructions.GetComponent<Image>().color = new Vector4(actionInstructions.GetComponent<Image>().color.r, actionInstructions.GetComponent<Image>().color.g, actionInstructions.GetComponent<Image>().color.b, 0.5f);
                            actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = new Vector4(actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color.r, actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color.g, actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color.b, 0.5f);
                            actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Press <sprite=336> just before hitting an enemy.";
                            player.GetChild(0).transform.GetChild(0).GetComponent<Animator>().SetBool("Active", false);
                            attackType = 0;
                            selectingEnemy = true;
                            enemyName.SetActive(true);
                            SelectFirstEnemy();
                        }
                        else
                        {
                            CreateMenu();
                            actionInstructions.SetActive(true);
                            player.GetChild(0).transform.GetChild(0).GetComponent<Animator>().SetBool("MenuOpened", true);
                        }
                    }
                    else if (selectingAction == 1 && Input.GetKeyDown(KeyCode.Space))
                    {
                        //if nothing is unlocked
                        if (PlayerPrefs.GetInt("Shuriken Styles") == 0)
                        {
                            playerChoosingAction = false;
                            actionInstructions.SetActive(true);
                            actionInstructions.GetComponent<Image>().color = new Vector4(actionInstructions.GetComponent<Image>().color.r, actionInstructions.GetComponent<Image>().color.g, actionInstructions.GetComponent<Image>().color.b, 0.5f);
                            actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = new Vector4(actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color.r, actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color.g, actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color.b, 0.5f);
                            actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Press <sprite=336> when <sprite=360> lights up.";
                            player.GetChild(0).transform.GetChild(0).GetComponent<Animator>().SetBool("Active", false);
                            attackType = 1;
                            selectingEnemy = true;
                            enemyName.SetActive(true);
                            SelectFirstEnemy();
                        }
                        else
                        {
                            CreateMenu();
                            actionInstructions.SetActive(true);
                            player.GetChild(0).transform.GetChild(0).GetComponent<Animator>().SetBool("MenuOpened", true);
                        }
                    }
                    else if (selectingAction == 2 && Input.GetKeyDown(KeyCode.Space))
                    {
                        CreateMenu();
                        actionInstructions.SetActive(true);
                        player.GetChild(0).transform.GetChild(0).GetComponent<Animator>().SetBool("MenuOpened", true);
                    }
                    else if (selectingAction == 3 && Input.GetKeyDown(KeyCode.Space))
                    {
                        player.GetChild(0).transform.GetChild(0).GetComponent<Animator>().SetBool("MenuOpened", true);
                    }
                    else if (selectingAction == 4 && Input.GetKeyDown(KeyCode.Space))
                    {
                        CreateMenu();
                        actionInstructions.SetActive(true);
                        player.GetChild(0).transform.GetChild(0).GetComponent<Animator>().SetBool("MenuOpened", true);
                    }
                }
                else
                {
                    if (selectingAction == 0)
                    {
                        if (menuSelectionPos == 0) usingStyle = 0;
                        else if (menuSelectionPos == 1) usingStyle = swordStyles[0];
                        else if (menuSelectionPos == 2) usingStyle = swordStyles[1];
                        if (usingStyle == 0) actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Use your sword to hit an enemy twice.";
                        else if (usingStyle == 1) actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Use your light power to hit an enemy with your light sword.";
                        else if (usingStyle == 2) actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Hit an enemy as many times as you can with your sword.";
                        if ((menuSelectionPos < PlayerPrefs.GetInt("Sword Styles")) && Input.GetKeyDown(KeyCode.DownArrow))
                        {
                            player.GetChild(0).transform.GetChild(0).GetComponent<Animator>().SetTrigger("Down");
                        }
                        else if (menuSelectionPos > 0 && Input.GetKeyDown(KeyCode.UpArrow))
                        {
                            player.GetChild(0).transform.GetChild(0).GetComponent<Animator>().SetTrigger("Up");
                        }
                        if (Input.GetKeyDown(KeyCode.Space) && menuCanUse[menuSelectionPos])
                        {
                            player.GetChild(0).transform.GetChild(0).GetComponent<Animator>().SetBool("MenuHide", true);
                            playerChoosingAction = false;
                            actionInstructions.GetComponent<Image>().color = new Vector4(actionInstructions.GetComponent<Image>().color.r, actionInstructions.GetComponent<Image>().color.g, actionInstructions.GetComponent<Image>().color.b, 0.5f);
                            actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = new Vector4(actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color.r, actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color.g, actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color.b, 0.5f);
                            if (usingStyle == 0) actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Press <sprite=336> just before hitting an enemy.";
                            else if (usingStyle == 1) actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Press and hold <sprite=336> until <sprite=360> fills completely.";
                            else if (usingStyle == 2) actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Press <sprite=336> just before hitting an enemy until you fail to press it in time.";
                            attackType = 0;
                            selectingEnemy = true;
                            enemyName.SetActive(true);
                            SelectFirstEnemy();
                        }
                    }
                    else if (selectingAction == 1)
                    {
                        if (menuSelectionPos == 0) usingStyle = 0;
                        else if (menuSelectionPos == 1) usingStyle = shurikenStyles[0];
                        else if (menuSelectionPos == 2) usingStyle = shurikenStyles[1];
                        if (usingStyle == 0) actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Throw your shuriken to an enemy.";
                        else if (usingStyle == 1) actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Use your light power to throw a light shuriken to an enemy.";
                        else if (usingStyle == 2) actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Throw a fire shuriken to all the grounded enemies.";
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
                            player.GetChild(0).transform.GetChild(0).GetComponent<Animator>().SetBool("MenuHide", true);
                            playerChoosingAction = false;
                            actionInstructions.GetComponent<Image>().color = new Vector4(actionInstructions.GetComponent<Image>().color.r, actionInstructions.GetComponent<Image>().color.g, actionInstructions.GetComponent<Image>().color.b, 0.5f);
                            actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = new Vector4(actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color.r, actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color.g, actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color.b, 0.5f);
                            if (usingStyle == 0) actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Press <sprite=336> when <sprite=360> lights up.";
                            else if (usingStyle == 1) actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Press <sprite=336> repeatedly until <sprite=360> lights up.";
                            else if (usingStyle == 2) actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Press <sprite=214> and <sprite=246> repeatedly until <sprite=360> lights up.";
                            attackType = 1;
                            selectingEnemy = true;
                            enemyName.SetActive(true);
                            if (usingStyle != 2) SelectFirstEnemy();
                            else SelectGroundEnemies();
                        }
                    }
                    else if (selectingAction == 2)
                    {
                        if (items[menuSelectionPos + scroll] == 1) actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Eat this apple to restore 5 HP";
                        else if (items[menuSelectionPos + scroll] == 2) actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Drink this potion to restore 5 LP";
                        if (((menuSelectionPos + scroll) < (itemSize() - 1)) && Input.GetKeyDown(KeyCode.DownArrow))
                        {
                            if (menuSelectionPos < 5) player.GetChild(0).transform.GetChild(0).GetComponent<Animator>().SetTrigger("Down");
                            if (menuSelectionPos == 5)
                            {
                                scroll += 1;
                                CreateMenu();
                            }
                        }
                        else if (menuSelectionPos >= 0 && Input.GetKeyDown(KeyCode.UpArrow))
                        {
                            if (menuSelectionPos > 0) player.GetChild(0).transform.GetChild(0).GetComponent<Animator>().SetTrigger("Up");
                            if (menuSelectionPos == 0 && scroll > 0)
                            {
                                scroll -= 1;
                                CreateMenu();
                            }
                        }
                        if (Input.GetKeyDown(KeyCode.Space) && menuCanUse[menuSelectionPos])
                        {
                            player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(7).GetComponent<Image>().color = new Vector4(player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(7).GetComponent<Image>().color.r, player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(7).GetComponent<Image>().color.g, player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(7).GetComponent<Image>().color.b, 0.0f);
                            player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(8).GetComponent<Image>().color = new Vector4(player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(7).GetComponent<Image>().color.r, player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(7).GetComponent<Image>().color.g, player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(7).GetComponent<Image>().color.b, 0.0f);
                            enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = "Player";
                            enemyName.transform.GetChild(1).gameObject.SetActive(false);
                            enemyName.transform.GetChild(2).gameObject.SetActive(false);
                            enemyName.transform.GetChild(3).gameObject.SetActive(false);
                            enemyName.transform.GetChild(4).gameObject.SetActive(false);
                            player.GetChild(0).transform.GetChild(5).gameObject.SetActive(true);
                            player.GetChild(0).transform.GetChild(0).GetComponent<Animator>().SetBool("MenuHide", true);
                            playerChoosingAction = false;
                            if (items[menuSelectionPos] == 1) actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Select who you want to eat the apple";
                            else if (items[menuSelectionPos] == 2) actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Select who you want to drink the potion";
                            selectingPlayer = true;
                            enemyName.SetActive(true);
                        }
                    }
                    else if (selectingAction == 3)
                    {

                    }
                    else if (selectingAction == 4)
                    {
                        if (menuSelectionPos == 0) actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Change your partner with another from your party.";
                        else if (menuSelectionPos == 1) actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Gain +1 of defense on the next enemy turn.";
                        else if (menuSelectionPos == 2) actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Try to flee the battle."; 
                        if ((menuSelectionPos < 2) && Input.GetKeyDown(KeyCode.DownArrow))
                        {
                            player.GetChild(0).transform.GetChild(0).GetComponent<Animator>().SetTrigger("Down");
                        }
                        else if (menuSelectionPos > 0 && Input.GetKeyDown(KeyCode.UpArrow))
                        {
                            player.GetChild(0).transform.GetChild(0).GetComponent<Animator>().SetTrigger("Up");
                        }
                        if (Input.GetKeyDown(KeyCode.Space) && menuCanUse[menuSelectionPos])
                        {
                            if (menuSelectionPos == 2) 
                            {                                
                                player.GetChild(0).transform.GetChild(6).transform.GetChild(2).transform.position = new Vector3( (player.GetChild(0).transform.GetChild(6).transform.position.x - 1.930875f) + Random.Range(0.0f, 100.0f) * 0.0386175f, player.GetChild(0).transform.GetChild(6).transform.GetChild(2).transform.position.y, player.GetChild(0).transform.GetChild(6).transform.GetChild(2).transform.position.z);
                                fleeRight = Random.Range(0.0f, 100.0f) > 50.0f;
                                Debug.Log(player.GetChild(0).transform.GetChild(6).transform.GetChild(2).transform.position.x - player.GetChild(0).transform.GetChild(6).transform.position.x);
                                Debug.Log(fleeRight);
                                fleeTime = Time.fixedTime;
                                playerChoosingAction = false;
                                Vector3 scale = player.transform.localScale;
                                scale.x *= -1;
                                player.transform.localScale = scale;
                                player.GetChild(0).transform.GetChild(6).gameObject.SetActive(true);
                                fleeing = true;
                            }
                        }
                    }
                    if (Input.GetKeyDown(KeyCode.Q))
                    {
                        actionInstructions.SetActive(false);
                        player.GetChild(0).transform.GetChild(0).GetComponent<Animator>().SetBool("MenuOpened", false);
                        player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(7).GetComponent<Image>().color = new Vector4(player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(7).GetComponent<Image>().color.r, player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(7).GetComponent<Image>().color.g, player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(7).GetComponent<Image>().color.b, 0.0f);
                        player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(8).GetComponent<Image>().color = new Vector4(player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(7).GetComponent<Image>().color.r, player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(7).GetComponent<Image>().color.g, player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(7).GetComponent<Image>().color.b, 0.0f);
                    }
                }
            } 
            //When we select a frindly object we give it to a partner
            else if (selectingPlayer)
            {
                if (Input.GetKeyDown(KeyCode.Q))
                {
                    CreateMenu();
                    enemyName.SetActive(false);
                    playerChoosingAction = true;
                    selectingPlayer = false;
                    player.GetChild(0).transform.GetChild(0).GetComponent<Animator>().SetBool("MenuHide", false);
                    player.GetChild(0).transform.GetChild(5).gameObject.SetActive(false);
                }
                else if (Input.GetKeyDown(KeyCode.Space))
                {
                    player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(7).gameObject.SetActive(false);
                    player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(8).gameObject.SetActive(false);                    
                    if (items[menuSelectionPos + scroll] == 1)
                    {
                        player.GetComponent<PlayerTeamScript>().Heal(5);
                    }
                    else if (items[menuSelectionPos + scroll] == 2) player.GetComponent<PlayerTeamScript>().IncreaseLight(5);
                    DeleteItem(menuSelectionPos + scroll);
                    scroll = 0;
                    actionInstructions.SetActive(false);
                    player.GetChild(0).transform.GetChild(0).GetComponent<Animator>().SetBool("Active", false);
                    player.GetChild(0).transform.GetChild(0).GetComponent<Animator>().SetBool("MenuHide", false);
                    player.GetChild(0).transform.GetChild(0).GetComponent<Animator>().SetBool("MenuOpened", false);
                    player.GetChild(0).transform.GetChild(0).GetComponent<Animator>().SetBool("MenuHide", false);
                    enemyName.SetActive(false);
                    player.GetChild(0).transform.GetChild(5).gameObject.SetActive(false);
                    selectingPlayer = false;
                    EndPlayerTurn();
                }
            }
            //When we attack we enter the selcting enemy fase
            else if (selectingEnemy)
            {
                //Press Q to return to start fase
                if (Input.GetKeyDown(KeyCode.Q))
                {
                    enemyName.SetActive(false);
                    playerChoosingAction = true;
                    selectingEnemy = false;
                    actionInstructions.GetComponent<Image>().color = new Vector4(actionInstructions.GetComponent<Image>().color.r, actionInstructions.GetComponent<Image>().color.g, actionInstructions.GetComponent<Image>().color.b, 1.0f);
                    actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = new Vector4(actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color.r, actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color.g, actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color.b, 1.0f);
                    player.GetChild(0).transform.GetChild(0).GetComponent<Animator>().SetBool("MenuHide", false);
                    if (enemyNumber < 2) enemy1.GetChild(0).transform.GetChild(0).gameObject.SetActive(false);
                    else if (enemyNumber < 3)
                    {
                        enemy1.GetChild(0).transform.GetChild(0).gameObject.SetActive(false);
                        enemy2.GetChild(0).transform.GetChild(0).gameObject.SetActive(false);
                    }
                }
                //When we can select a enemy
                if (canSelect)
                {
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
                                    enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = "Bandit";
                                }
                            }
                            if (Input.GetKeyDown(KeyCode.Space))
                            {
                                player.GetChild(0).transform.GetChild(0).GetComponent<Animator>().SetBool("Active", false);
                                player.GetChild(0).transform.GetChild(0).GetComponent<Animator>().SetBool("MenuHide", false);
                                enemy1.GetChild(0).transform.GetChild(0).gameObject.SetActive(false);
                                player.GetChild(0).transform.GetChild(0).GetComponent<Animator>().SetBool("MenuOpened", false);
                                selectedEnemy = enemy1;
                                selectingEnemy = false;
                                enemyName.SetActive(false);
                                actionInstructions.GetComponent<Image>().color = new Vector4(actionInstructions.GetComponent<Image>().color.r, actionInstructions.GetComponent<Image>().color.g, actionInstructions.GetComponent<Image>().color.b, 1.0f);
                                actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = new Vector4(actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color.r, actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color.g, actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color.b, 1.0f);
                                player.GetComponent<PlayerTeamScript>().Attack(attackType, usingStyle, selectedEnemy);
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
                                    enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = "Bandit";
                                }
                            }
                            if (Input.GetKeyDown(KeyCode.Space))
                            {
                                player.GetChild(0).transform.GetChild(0).GetComponent<Animator>().SetBool("Active", false);
                                player.GetChild(0).transform.GetChild(0).GetComponent<Animator>().SetBool("MenuHide", false);
                                enemy2.GetChild(0).transform.GetChild(0).gameObject.SetActive(false);
                                player.GetChild(0).transform.GetChild(0).GetComponent<Animator>().SetBool("MenuOpened", false);
                                selectedEnemy = enemy2;
                                selectingEnemy = false;
                                enemyName.SetActive(false);
                                actionInstructions.GetComponent<Image>().color = new Vector4(actionInstructions.GetComponent<Image>().color.r, actionInstructions.GetComponent<Image>().color.g, actionInstructions.GetComponent<Image>().color.b, 1.0f);
                                actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = new Vector4(actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color.r, actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color.g, actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color.b, 1.0f);
                                player.GetComponent<PlayerTeamScript>().Attack(attackType, usingStyle, selectedEnemy);
                            }
                        }
                    }
                    //If there is only one enemy we select it using space and the attack starts
                    else if (Input.GetKeyDown(KeyCode.Space))
                    {
                        player.GetChild(0).transform.GetChild(0).GetComponent<Animator>().SetBool("Active", false);
                        player.GetChild(0).transform.GetChild(0).GetComponent<Animator>().SetBool("MenuHide", false);
                        player.GetChild(0).transform.GetChild(0).GetComponent<Animator>().SetBool("MenuOpened", false);
                        enemy1.GetChild(0).transform.GetChild(0).gameObject.SetActive(false);
                        selectedEnemy = enemy1;
                        selectingEnemy = false;
                        enemyName.SetActive(false);
                        actionInstructions.SetActive(false);
                        player.GetComponent<PlayerTeamScript>().Attack(attackType, usingStyle, selectedEnemy);
                    }
                }
                else if (Input.GetKeyDown(KeyCode.Space))
                {
                    Transform[] groundEnemies = GetGroundEnemies();
                    for (int i = 0; i < groundEnemies.Length; i++)
                    {
                        if (groundEnemies[i].GetComponent<EnemyTeamScript>().enemyType == 0)
                        {
                            groundEnemies[i].GetChild(0).transform.GetChild(0).gameObject.SetActive(false);
                            enemyName.transform.GetChild(i).gameObject.SetActive(false);
                        }
                    }
                    player.GetChild(0).transform.GetChild(0).GetComponent<Animator>().SetBool("Active", false);
                    player.GetChild(0).transform.GetChild(0).GetComponent<Animator>().SetBool("MenuHide", false);
                    player.GetChild(0).transform.GetChild(0).GetComponent<Animator>().SetBool("MenuOpened", false);
                    selectedEnemy = enemy1;
                    selectingEnemy = false;
                    enemyName.SetActive(false);
                    actionInstructions.GetComponent<Image>().color = new Vector4(actionInstructions.GetComponent<Image>().color.r, actionInstructions.GetComponent<Image>().color.g, actionInstructions.GetComponent<Image>().color.b, 1.0f);
                    actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = new Vector4(actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color.r, actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color.g, actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color.b, 1.0f);
                    player.GetComponent<PlayerTeamScript>().Attack(attackType, usingStyle, selectedEnemy);
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
                        if (Input.GetKey(KeyCode.X) && !player.transform.GetChild(0).transform.GetChild(2).GetComponent<Animator>().GetBool("charging"))
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
                    else if(usingStyle == 2)
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
                        if (Time.fixedTime - shurikenTime < 2.5f && player.transform.GetChild(0).transform.GetChild(3).transform.GetChild(1).GetComponent<Image>().fillAmount < 1.0f && Input.GetKeyDown(KeyCode.X))
                        {
                            player.transform.GetChild(0).transform.GetChild(3).transform.GetChild(1).GetComponent<Image>().fillAmount += 0.12f;
                            if (player.transform.GetChild(0).transform.GetChild(3).transform.GetChild(1).GetComponent<Image>().fillAmount >= 1.0f)
                            {
                                player.transform.GetChild(0).transform.GetChild(3).transform.GetChild(2).GetComponent<Image>().sprite = fillIcon;
                                player.transform.GetChild(2).GetComponent<Light>().intensity = 4.0f;
                            }
                        }
                    }
                    else if(usingStyle == 2)
                    {
                        if (Time.fixedTime - shurikenTime < 2.5f && player.transform.GetChild(0).transform.GetChild(4).transform.GetChild(1).GetComponent<Image>().fillAmount < 1.0f)
                        {
                            if(Input.GetKeyDown(KeyCode.LeftArrow) && !lastLeft)
                            {
                                lastLeft = true;
                                player.transform.GetChild(0).transform.GetChild(4).transform.GetChild(1).GetComponent<Image>().fillAmount += 0.06f;
                                if (player.transform.GetChild(0).transform.GetChild(4).transform.GetChild(1).GetComponent<Image>().fillAmount >= 1.0f)
                                {
                                    player.transform.GetChild(0).transform.GetChild(4).transform.GetChild(2).GetComponent<Image>().sprite = fillIcon;
                                    player.transform.GetChild(2).GetComponent<Light>().intensity = 4.0f;
                                }
                            }
                            else if(Input.GetKeyDown(KeyCode.RightArrow) && lastLeft)
                            {
                                lastLeft = false;
                                player.transform.GetChild(0).transform.GetChild(4).transform.GetChild(1).GetComponent<Image>().fillAmount += 0.06f;
                                if (player.transform.GetChild(0).transform.GetChild(4).transform.GetChild(1).GetComponent<Image>().fillAmount >= 1.0f)
                                {
                                    player.transform.GetChild(0).transform.GetChild(4).transform.GetChild(2).GetComponent<Image>().sprite = fillIcon;
                                    player.transform.GetChild(2).GetComponent<Light>().intensity = 4.0f;
                                }
                            }
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
            else if (fleeing && (Time.fixedTime - fleeTime) < 10.0f)
            {
                if (Input.GetKeyDown(KeyCode.X))
                {
                    player.GetChild(0).transform.GetChild(6).transform.GetChild(1).GetComponent<Image>().fillAmount += 0.02f;
                }
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
            if (Time.fixedTime - shurikenTime < 2.5f )
            {
                if(player.transform.GetChild(0).transform.GetChild(3).transform.GetChild(1).GetComponent<Image>().fillAmount < 1.0f)
                {
                    player.transform.GetChild(0).transform.GetChild(3).transform.GetChild(1).GetComponent<Image>().fillAmount -= 0.002f;
                    player.transform.GetChild(2).GetComponent<Light>().intensity = player.transform.GetChild(0).transform.GetChild(3).transform.GetChild(1).GetComponent<Image>().fillAmount * 4.0f;
                }
            }
            else if(player.transform.GetChild(0).transform.GetChild(3).transform.GetChild(1).GetComponent<Image>().fillAmount < 1.0f)
            {
                finalAttack = false;
                player.transform.GetChild(0).transform.GetChild(3).transform.GetChild(2).GetComponent<Image>().sprite = emptyIcon;
                player.GetChild(0).transform.GetChild(3).gameObject.SetActive(false);
                player.transform.GetChild(0).transform.GetChild(3).transform.GetChild(1).GetComponent<Image>().fillAmount = 0.0f;
                player.GetComponent<Animator>().SetBool("isSpinning", false);
                player.GetComponent<PlayerTeamScript>().SetShurikenDamage(1);
            }
            else if(player.transform.GetChild(0).transform.GetChild(3).transform.GetChild(1).GetComponent<Image>().fillAmount >= 1.0f)
            {
                finalAttack = false;
                player.transform.GetChild(0).transform.GetChild(3).transform.GetChild(2).GetComponent<Image>().sprite = emptyIcon;
                player.GetChild(0).transform.GetChild(3).gameObject.SetActive(false);
                player.transform.GetChild(0).transform.GetChild(3).transform.GetChild(1).GetComponent<Image>().fillAmount = 0.0f;
                player.GetComponent<Animator>().SetBool("isSpinning", false);
                player.GetComponent<PlayerTeamScript>().SetShurikenDamage(4);
            }
        }
        if (finalAttack && attackType == 1 && usingStyle == 2)
        {
            if (Time.fixedTime - shurikenTime < 2.5f)
            {
                if (player.transform.GetChild(0).transform.GetChild(4).transform.GetChild(1).GetComponent<Image>().fillAmount < 1.0f)
                {
                    player.transform.GetChild(0).transform.GetChild(4).transform.GetChild(1).GetComponent<Image>().fillAmount -= 0.002f;
                    player.GetComponent<Animator>().SetFloat("attackSpeed", player.transform.GetChild(0).transform.GetChild(4).transform.GetChild(1).GetComponent<Image>().fillAmount * 2.0f + 0.5f);
                    player.transform.GetChild(2).GetComponent<Light>().intensity = player.transform.GetChild(0).transform.GetChild(4).transform.GetChild(1).GetComponent<Image>().fillAmount * 4.0f;
                }
            }
            else if (player.transform.GetChild(0).transform.GetChild(4).transform.GetChild(1).GetComponent<Image>().fillAmount < 1.0f)
            {
                finalAttack = false;
                player.GetComponent<Animator>().SetFloat("attackSpeed", 1.0f);
                player.transform.GetChild(0).transform.GetChild(4).transform.GetChild(2).GetComponent<Image>().sprite = emptyIcon;
                player.GetChild(0).transform.GetChild(4).gameObject.SetActive(false);
                player.transform.GetChild(0).transform.GetChild(4).transform.GetChild(1).GetComponent<Image>().fillAmount = 0.0f;
                player.GetComponent<Animator>().SetBool("isSpinning", false);
                player.GetComponent<PlayerTeamScript>().SetShurikenDamage(1);
            }
            else if (player.transform.GetChild(0).transform.GetChild(4).transform.GetChild(1).GetComponent<Image>().fillAmount >= 1.0f)
            {
                finalAttack = false;
                player.GetComponent<Animator>().SetFloat("attackSpeed", 1.0f);
                player.transform.GetChild(0).transform.GetChild(4).transform.GetChild(2).GetComponent<Image>().sprite = emptyIcon;
                player.GetChild(0).transform.GetChild(4).gameObject.SetActive(false);
                player.transform.GetChild(0).transform.GetChild(4).transform.GetChild(1).GetComponent<Image>().fillAmount = 0.0f;
                player.GetComponent<Animator>().SetBool("isSpinning", false);
                player.GetComponent<PlayerTeamScript>().SetShurikenDamage(2);
            }
        }
        if (fleeing)
        {
            if ((Time.fixedTime - fleeTime) < 10.0f)
            {
                player.GetChild(0).transform.GetChild(6).transform.GetChild(1).GetComponent<Image>().fillAmount -= 0.001f;                
                if (fleeRight)
                {
                    if ((player.GetChild(0).transform.GetChild(6).transform.GetChild(2).transform.position.x - player.GetChild(0).transform.GetChild(6).transform.position.x) < 1.930f)
                    {
                        player.GetChild(0).transform.GetChild(6).transform.GetChild(2).transform.position = new Vector3(player.GetChild(0).transform.GetChild(6).transform.GetChild(2).transform.position.x + 0.077235f, player.GetChild(0).transform.GetChild(6).transform.GetChild(2).transform.position.y, player.GetChild(0).transform.GetChild(6).transform.GetChild(2).transform.position.z);
                    }
                    else fleeRight = false;
                }
                else
                {
                    if ((player.GetChild(0).transform.GetChild(6).transform.GetChild(2).transform.position.x - player.GetChild(0).transform.GetChild(6).transform.position.x) > -1.930f)
                    {
                        player.GetChild(0).transform.GetChild(6).transform.GetChild(2).transform.position = new Vector3(player.GetChild(0).transform.GetChild(6).transform.GetChild(2).transform.position.x - 0.077235f, player.GetChild(0).transform.GetChild(6).transform.GetChild(2).transform.position.y, player.GetChild(0).transform.GetChild(6).transform.GetChild(2).transform.position.z);
                    }
                    else fleeRight = true;
                }
            }
            else
            {
                Debug.Log((player.GetChild(0).transform.GetChild(6).transform.GetChild(2).transform.position.x - (player.GetChild(0).transform.GetChild(6).transform.position.x - 1.930875f))/3.86175f);
                Debug.Log(player.GetChild(0).transform.GetChild(6).transform.GetChild(1).GetComponent<Image>().fillAmount);
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
    //Function to get the ground enemies
    public Transform[] GetGroundEnemies()
    {
        Transform[] grounded;
        grounded = null;
        if (enemyNumber == 1 && enemy1.GetComponent<EnemyTeamScript>().IsGrounded() && enemy1.GetComponent<EnemyTeamScript>().IsAlive())
        {
            grounded = new Transform[1];
            grounded[0] = enemy1;
        }
        else if (enemyNumber == 2)
        {
            if (enemy1.GetComponent<EnemyTeamScript>().IsGrounded() && enemy1.GetComponent<EnemyTeamScript>().IsAlive())
            {
                if (enemy2.GetComponent<EnemyTeamScript>().IsGrounded() && enemy2.GetComponent<EnemyTeamScript>().IsAlive())
                {
                    grounded = new Transform[2];
                    grounded[0] = enemy1;
                    grounded[1] = enemy2;
                }
                else
                {
                    grounded = new Transform[1];
                    grounded[0] = enemy1;
                }
            }
            else if (enemy2.GetComponent<EnemyTeamScript>().IsGrounded() && enemy2.GetComponent<EnemyTeamScript>().IsAlive())
            {
                grounded = new Transform[1];
                grounded[0] = enemy2;
            }
        }
        return grounded;
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
        enemyName.transform.GetChild(1).gameObject.SetActive(false);
        enemyName.transform.GetChild(2).gameObject.SetActive(false);
        enemyName.transform.GetChild(3).gameObject.SetActive(false);
        enemyName.transform.GetChild(4).gameObject.SetActive(false);
        if (enemy1.GetComponent<EnemyTeamScript>().IsAlive())
        {
            enemy1.GetChild(0).transform.GetChild(0).gameObject.SetActive(true);
            if(enemy1.GetComponent<EnemyTeamScript>().enemyType == 0)
            {
                enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = "Bandit";
            }
        }
        else if(enemyNumber > 1 && enemy2.GetComponent<EnemyTeamScript>().IsAlive())
        {
            enemy2.GetChild(0).transform.GetChild(0).gameObject.SetActive(true);
            if (enemy2.GetComponent<EnemyTeamScript>().enemyType == 0)
            {
                enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = "Bandit";
            }
        }
        canSelect = true;
    }
    //A function to select all the ground enemies
    private void SelectGroundEnemies()
    {
        int lastI = -1;
        Transform[] groundEnemies = GetGroundEnemies();
        for (int i = 0; i < groundEnemies.Length; i++) 
        { 
            if(groundEnemies[i].GetComponent<EnemyTeamScript>().enemyType == 0)
            {
                groundEnemies[i].GetChild(0).transform.GetChild(0).gameObject.SetActive(true);
                enemyName.transform.GetChild(i).gameObject.SetActive(true);
                enemyName.transform.GetChild(i).transform.GetChild(0).GetComponent<Text>().text = "Bandit";
                lastI = i;
            }
        }
        for (int i = lastI+1; i < 5; i++)
        {
            enemyName.transform.GetChild(i).gameObject.SetActive(false);
        }

        //if(enemyNumber == 1)
        //{
        //    if (enemy1.GetComponent<EnemyTeamScript>().IsGrounded())
        //    {
        //        enemy1.GetChild(0).transform.GetChild(0).gameObject.SetActive(true);
        //        if (enemy1.GetComponent<EnemyTeamScript>().enemyType == 0)
        //        {
        //            enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = "Bandit";
        //        }
        //    }
        //}
        //else if(enemyNumber == 2)
        //{
        //    if (enemy1.GetComponent<EnemyTeamScript>().IsAlive() && enemy1.GetComponent<EnemyTeamScript>().IsGrounded())
        //    {
        //        enemy1.GetChild(0).transform.GetChild(0).gameObject.SetActive(true);
        //        if (enemy1.GetComponent<EnemyTeamScript>().enemyType == 0)
        //        {
        //            enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = "Bandit";
        //        }
        //        if (enemy2.GetComponent<EnemyTeamScript>().IsAlive() && enemy2.GetComponent<EnemyTeamScript>().IsGrounded())
        //        {
        //            enemy2.GetChild(0).transform.GetChild(0).gameObject.SetActive(true);
        //            if (enemy2.GetComponent<EnemyTeamScript>().enemyType == 0)
        //            {
        //                enemyName.transform.GetChild(1).transform.GetChild(0).GetComponent<Text>().text = "Bandit";
        //            }
        //        }
        //    }
        //    else if (enemy2.GetComponent<EnemyTeamScript>().IsAlive() && enemy2.GetComponent<EnemyTeamScript>().IsGrounded())
        //    {
        //        enemy2.GetChild(0).transform.GetChild(0).gameObject.SetActive(true);
        //        if (enemy2.GetComponent<EnemyTeamScript>().enemyType == 0)
        //        {
        //            enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = "Bandit";
        //        }
        //    }
        //}
        canSelect = false;
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

    //Function to know the number of items the player has
    private int itemSize()
    {
        int i = 0;
        while(items[i] != 0 && i < 19)
        {
            i++;
        }
        return i;
    }

    //Function to delete an item
    private void DeleteItem(int pos)
    {
        for(int i = pos; i < itemSize(); i++)
        {
            if (i < 19) items[i] = items[i + 1];
            else items[i] = 0;
        }
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
                else if (PlayerPrefs.GetInt("Multistrike Sword") == 1)
                {
                    swordStyles[0] = 2;
                    player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(2).transform.GetChild(0).GetComponent<Image>().sprite = multiStrikeSword;
                    player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(2).transform.GetChild(1).GetComponent<Text>().text = "Multistrike sword";
                    player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(2).transform.GetChild(2).GetComponent<Text>().text = "3 LP";
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
                player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(1).transform.GetChild(0).GetComponent<Image>().sprite = normalSword;
                player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(1).transform.GetChild(1).GetComponent<Text>().text = "Normal sword";
                player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(1).transform.GetChild(2).GetComponent<Text>().text = "";
                menuCanUse[0] = true;
                if (PlayerPrefs.GetInt("Light Sword") == 1)
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
                if (PlayerPrefs.GetInt("Multistrike Sword") == 1)
                {
                    swordStyles[1] = 2;
                    player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(3).transform.GetChild(0).GetComponent<Image>().sprite = multiStrikeSword;
                    player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(3).transform.GetChild(1).GetComponent<Text>().text = "Multistrike sword";
                    player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(3).transform.GetChild(2).GetComponent<Text>().text = "3 LP";
                    if (!lightPointsUI.GetComponent<LightPointsScript>().CanUseHability(3))
                    {
                        player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(3).GetComponent<Image>().color = new Vector4(0.55f, 0.55f, 0.55f, 1.0f);
                        player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(3).transform.GetChild(0).GetComponent<Image>().color = new Vector4(0.55f, 0.55f, 0.55f, 1.0f);
                        menuCanUse[2] = false;
                    }
                    else
                    {
                        player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(3).GetComponent<Image>().color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
                        player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(3).transform.GetChild(0).GetComponent<Image>().color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
                        menuCanUse[2] = true;
                    }
                }
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
                else if (PlayerPrefs.GetInt("Fire Shuriken") == 1)
                {
                    shurikenStyles[0] = 2;
                    player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(2).transform.GetChild(0).GetComponent<Image>().sprite = lightShuriken;
                    player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(2).transform.GetChild(1).GetComponent<Text>().text = "Light shuriken";
                    player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(2).transform.GetChild(2).GetComponent<Text>().text = "3 LP";
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
                if (PlayerPrefs.GetInt("Fire Shuriken") == 1)
                {
                    shurikenStyles[1] = 2;
                    player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(3).transform.GetChild(0).GetComponent<Image>().sprite = fireShuriken;
                    player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(3).transform.GetChild(1).GetComponent<Text>().text = "Fire shuriken";
                    player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(3).transform.GetChild(2).GetComponent<Text>().text = "3 LP";
                    if (!lightPointsUI.GetComponent<LightPointsScript>().CanUseHability(3))
                    {
                        player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(3).GetComponent<Image>().color = new Vector4(0.55f, 0.55f, 0.55f, 1.0f);
                        player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(3).transform.GetChild(0).GetComponent<Image>().color = new Vector4(0.55f, 0.55f, 0.55f, 1.0f);
                        menuCanUse[2] = false;
                    }
                    else
                    {
                        player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(3).GetComponent<Image>().color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
                        player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(3).transform.GetChild(0).GetComponent<Image>().color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
                        menuCanUse[2] = true;
                    }
                }
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
        else if (selectingAction == 2)
        {
            if (scroll > 0) player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(7).GetComponent<Image>().color = new Vector4(player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(7).GetComponent<Image>().color.r, player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(7).GetComponent<Image>().color.g, player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(7).GetComponent<Image>().color.b, 1.0f);
            else player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(7).GetComponent<Image>().color = new Vector4(player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(7).GetComponent<Image>().color.r, player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(7).GetComponent<Image>().color.g, player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(7).GetComponent<Image>().color.b, 0.0f);
            if ((scroll + 6) == itemSize()) player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(8).GetComponent<Image>().color = new Vector4(player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(7).GetComponent<Image>().color.r, player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(7).GetComponent<Image>().color.g, player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(7).GetComponent<Image>().color.b, 0.0f);
            else player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(8).GetComponent<Image>().color = new Vector4(player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(7).GetComponent<Image>().color.r, player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(7).GetComponent<Image>().color.g, player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(7).GetComponent<Image>().color.b, 1.0f);
            if (itemSize() > 5)
            {
                for(int i = 1; i < 7; i++)
                {
                    menuCanUse[i-1] = true;
                    if (items[i + scroll - 1] == 1)
                    {
                        player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(i).gameObject.SetActive(true);
                        player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(i).transform.GetChild(0).GetComponent<Image>().sprite = apple;
                        player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(i).transform.GetChild(1).GetComponent<Text>().text = "Apple";
                        player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(i).transform.GetChild(2).GetComponent<Text>().text = "";
                    }
                    else if (items[i + scroll - 1] == 2)
                    {
                        player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(i).gameObject.SetActive(true);
                        player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(i).transform.GetChild(0).GetComponent<Image>().sprite = lightPotion;
                        player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(i).transform.GetChild(1).GetComponent<Text>().text = "Light potion";
                        player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(i).transform.GetChild(2).GetComponent<Text>().text = "";
                    }
                }                
            }
            else
            {
                for (int i = 1; i < 7; i++)
                {
                    if (i < itemSize()+1)
                    {
                        menuCanUse[i-1] = true;
                        if (items[i-1] == 1)
                        {
                            player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(i).gameObject.SetActive(true);
                            player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(i).transform.GetChild(0).GetComponent<Image>().sprite = apple;
                            player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(i).transform.GetChild(1).GetComponent<Text>().text = "Apple";
                            player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(i).transform.GetChild(2).GetComponent<Text>().text = "";
                        }
                        else if (items[i-1] == 2)
                        {
                            player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(i).gameObject.SetActive(true);
                            player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(i).transform.GetChild(0).GetComponent<Image>().sprite = lightPotion;
                            player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(i).transform.GetChild(1).GetComponent<Text>().text = "Light potion";
                            player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(i).transform.GetChild(2).GetComponent<Text>().text = "";
                        }
                    }
                    else
                    {
                        player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(i).gameObject.SetActive(false);
                    }
                }
            }
        }
        else if (selectingAction == 3)
        {

        }
        else if(selectingAction == 4)
        {
            player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(1).transform.GetChild(0).GetComponent<Image>().sprite = partnerChange;
            player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(1).transform.GetChild(1).GetComponent<Text>().text = "Change partner";
            player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(1).transform.GetChild(2).GetComponent<Text>().text = "";
            menuCanUse[0] = true;
            player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(2).transform.GetChild(0).GetComponent<Image>().sprite = defend;
            player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(2).transform.GetChild(1).GetComponent<Text>().text = "Defend";
            player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(2).transform.GetChild(2).GetComponent<Text>().text = "";
            menuCanUse[1] = true;
            player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(3).transform.GetChild(0).GetComponent<Image>().sprite = run;
            player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(3).transform.GetChild(1).GetComponent<Text>().text = "Flee";
            player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(3).transform.GetChild(2).GetComponent<Text>().text = "";
            menuCanUse[2] = true;
            player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(4).gameObject.SetActive(false);
            player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(5).gameObject.SetActive(false);
            player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(6).gameObject.SetActive(false);
        }
    }
}
