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
    [SerializeField] private Transform adventurerBattle;
    [SerializeField] private Transform banditBattle;
    [SerializeField] private Transform wizardBattle;
    //The prefabs of the damage UI, heart and light
    [SerializeField] private Transform damageUI;
    //The main camera
    private GameObject mainCamera;
    //The canvas
    private GameObject canvas;
    //The icons of every action of the menu
    [SerializeField] private Sprite normalSword;
    [SerializeField] private Sprite lightSword;
    [SerializeField] private Sprite multiStrikeSword;
    [SerializeField] private Sprite normalShuriken;
    [SerializeField] private Sprite lightShuriken;
    [SerializeField] private Sprite fireShuriken;
    [SerializeField] private Sprite apple;
    [SerializeField] private Sprite lightPotion;
    [SerializeField] private Sprite music;
    [SerializeField] private Sprite regeneration;
    [SerializeField] private Sprite thunder;
    [SerializeField] private Sprite lifesteal;
    [SerializeField] private Sprite ghost;
    [SerializeField] private Sprite lightUp;
    [SerializeField] private Sprite partnerChange;
    [SerializeField] private Sprite defend;
    [SerializeField] private Sprite run;
    [SerializeField] private Sprite firstSkill;
    [SerializeField] private Sprite secondSkill;
    [SerializeField] private Sprite thirdSkill;
    [SerializeField] private Sprite fourthSkill;
    [SerializeField] private Sprite fifthSkill;
    //The images of the shuriken light action fill bar
    [SerializeField] private Sprite emptyIcon;
    [SerializeField] private Sprite fillIcon;
    //The prefab of the key
    [SerializeField] private Transform keyPrefab;
    //The sprites of the direction arrows
    [SerializeField] private Sprite upArrowSprite;
    [SerializeField] private Sprite leftArrowSprite;
    [SerializeField] private Sprite rightArrowSprite;
    [SerializeField] private Sprite downArrowSprite;
    //The keys
    private Transform key1;
    private Transform key1Cover;
    private Transform key2;
    private Transform key2Cover;
    private Transform key3;
    private Transform key3Cover;
    private Transform key4;
    private Transform key4Cover;
    private Transform key5;
    private Transform key5Cover;
    private Transform key6;
    private Transform key6Cover;
    private Transform key7;
    private Transform key7Cover;
    //The key inputs. 0-> up, 1-> left, 2-> right, 3-> down
    private int key1Input;
    private int key2Input;
    private int key3Input;
    private int key4Input;
    private int key5Input;
    private int key6Input;
    private int key7Input;
    //The life points UI
    private GameObject lightPointsUI;
    //The actions instructions
    private GameObject actionInstructions;
    //The enemy name
    private GameObject enemyName;
    //The player, companions and enemies
    private Transform player;
    private Transform companion;
    private Transform enemy1;
    private Transform enemy2;
    private Transform enemy3;
    private Transform enemy4;
    //The souls
    private GameObject soul1;
    private GameObject soul2;
    private GameObject soul3;
    private GameObject soul4;
    private GameObject soul5;
    private GameObject soul6;
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
    //A boolean to check if its players turn
    private bool playerTurn;
    //A boolean to check if the player has completed their turn
    private bool playerTurnCompleted;
    //A boolean to check if its companions turn
    private bool companionTurn;
    //A boolean to check if the companion has completed their turn
    private bool companionTurnCompleted;
    //A boolean to check if it is enemy teams turn
    private bool enemyTeamTurn;
    //A boolean to check if it is first enemys turn
    private bool enemy1Turn;
    //A boolean to check if it is second enemys turn
    private bool enemy2Turn;
    //A boolean to check if it is third enemys turn
    private bool enemy3Turn;
    //A boolean to check if it is fourth enemys turn
    private bool enemy4Turn;
    //A boolean to check if the player is choosing the action
    private bool playerChoosingAction;
    //A boolean to check if the companion is choosing the action
    private bool companionChoosingAction;
    //A int to see which position of the menu is being selected
    private int menuSelectionPos;
    //A boolean to see if the player is choosing which enemy to attack
    private bool selectingEnemy;
    //A boolean to see if the companion is choosing which enemy to attack
    private bool selectingEnemyCompanion;
    //A boolean to know if the player is changing position with the companion
    private bool changePos;
    //A boolean to see if the player is choosing which partner give the object
    private bool selectingPlayer;
    //A boolean to see if the companion is choosing which partner give the object
    private bool selectingCompanion;
    //A boolean to see if the player is attacking
    public bool finalAttack;
    //A boolean to check if the player is in his attack action
    public bool attackAction;
    //A boolean to check if the attack has been finished
    public bool attackFinished;
    //A boolean to check if the player is in the first position
    private bool firstPosPlayer;
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
    //int to check if the player is in the soul music state. 0-> not active, 1-> first round, 2-> second round ...
    private int soulMusic;
    //A boolean to know if the soul music is filling or not
    private bool soulMusicFilling;
    //A boolean to know if the player is doing que soul regen action
    private bool soulRegen;
    //The actual speed of the soul regen rings
    private float soulRegenRingSpeed;
    //The actual speed of the soul regen soul
    private float soulRegenGreenSpeed;
    //The regeneration heal and light increase 
    private int soulRegenHeal;
    private int soulRegenLight;
    //Booleans to know where the green flame is moving
    private bool soulRegenMovUp;
    private bool soulRegenMovLeft;
    private bool soulRegenMovRight;
    private bool soulRegenMovDown;
    //A boolean to know if the player is in the lightning action
    private bool soulLightning;
    //A boolean to know if the yellow soul si moving right
    private bool yellowSoulRight;
    //A boolean to check if the player has failed the music action
    private bool failMusic;
    //The rings
    [SerializeField] private Transform redRingBck;
    [SerializeField] private Transform yellowRingBck;
    [SerializeField] private Transform RingFront;
    //The transform arrays where we are going to save the rings
    private Transform[] ring1;
    private Transform[] ring2;
    private Transform[] ring3;
    private Transform[] ring4;
    private Transform[] ring5;
    private Transform[] ring6;
    private Transform[] ring7;
    private Transform[] ring8;
    //The green soul
    [SerializeField] private Transform greenSoulPrefab;
    private Transform greenSoul;
    //The yellow soul
    [SerializeField] private Transform yellowSoulPrefab;
    private Transform yellowSoul;
    //A boolean to know if the player is doing the lifesteal action
    private bool soulLifesteal;
    //The number of red souls gathered
    private int soulLifestealNumb;
    //The red soul
    [SerializeField] private Transform redSoulPrefab;
    private Transform redSoul1;
    private Transform redSoul2;
    private Transform redSoul3;
    private Transform redSoul4;
    private Transform redSoul5;
    private Transform redSoul6;
    private Transform redSoul7;
    private Transform redSoul8;
    private Transform redSoul9;
    private Transform redSoul10;
    //The jar of the lifesteal action
    [SerializeField] private Transform jarPrefab;
    private Transform jar;
    //Booleans to know where the jar is moving
    private bool jarMovUp;
    private bool jarMovLeft;
    private bool jarMovRight;
    private bool jarMovDown;
    //A boolean to know if the player is doing the disappear action
    private bool soulDisappear;
    //The blue soul
    [SerializeField] private Transform blueSoulPrefab;
    private Transform blueSoul;
    //Booleans to know where the blue soul is moving
    private bool blueSoulMovUp;
    private bool blueSoulMovLeft;
    private bool blueSoulMovRight;
    private bool blueSoulMovDown;
    //The walls of the disappear action
    [SerializeField] private Transform wallPrefab;
    private Transform wall1;
    private Transform wall2;
    private Transform wall3;
    private Transform wall4;
    private Transform wall5;
    //A boolean to know if the player is doing the light up attack
    private bool soulLightUp;
    //A boolean to know if the fog has been scaled
    private bool fogScaled;
    //A float to know the minumum size of the fog
    private float minFogScale;
    //The magenta soul and shard
    [SerializeField] private Transform magentaSoulPrefab;
    private Transform magentaSoul;
    [SerializeField] private Transform magentaShardPrefab;
    private Transform magentaShard;
    //Booleans to know where the magenta soul is moving
    private bool magentaSoulMovUp;
    private bool magentaSoulMovLeft;
    private bool magentaSoulMovRight;
    private bool magentaSoulMovDown;
    //The fog of the light up action
    [SerializeField] private Transform fogPrefab;
    private Transform fog;
    //The time the light up action started
    private float lightUpTime;
    //The lightning
    [SerializeField] private Transform lightningPrefab;
    //The regeneration action UI
    private GameObject regenerationAction;
    //The lightning action UI
    private GameObject lightningAction;
    //The lifesteal action UI
    private GameObject lifestealAction;
    //The disappear action UI
    private GameObject disappearAction;
    //The light up action UI
    private GameObject lightUpAction;
    //A boolean to save if the shuriken hits the enemy
    public bool shurikenHit;
    //A float to know the time we have spent spinning
    public float shurikenTime;
    //A bool to know if the player is trying to flee
    private bool fleeing;
    //A bool to know if the player has fled
    private bool fled;
    //A float to know the time the player started fleeing
    private float fleeTime;
    //Boolean to know if the flee bar is moving right or left
    private bool fleeRight;
    //Integer to know the defense of the player
    private int defensePlayer;
    //Integer to know the defense of the companion
    private int defenseCompanion;
    //The action the player is selecting. 0-> Sword, 1-> Shuriken, 2-> Items, 3-> Special, 4-> Other
    public int selectingAction;
    //The gameobject of the flee action
    private GameObject fleeAction;
    //The gameobject of the Change position object
    private GameObject changePosAction;
    //A bool to know if the adventurer is talking
    private bool talking;
    //A floar to know the rotation of the aim action
    private float aimRotation;
    //A bool to know if the aim rotation is going up or down
    private bool aimUp;
    //A bool to know if the adventurer is ready to shoot
    private bool readyShoot;
    //A bool to save the xp gained in the current fight
    private int currentFightXP;
    //The gameobject where the xp is shown
    private GameObject xpObject;
    //The number of the current lvl xp
    private Text xpText;
    //The victory xp gameobject
    private GameObject victoryXP;
    //The victory state
    private bool victory;

    private void Awake()
    {
        PlayerPrefs.SetInt("Light Sword", 1);
        PlayerPrefs.SetInt("Multistrike Sword", 1);
        PlayerPrefs.SetInt("Sword Styles", PlayerPrefs.GetInt("Light Sword") + PlayerPrefs.GetInt("Multistrike Sword"));
        PlayerPrefs.SetInt("Light Shuriken", 1);
        PlayerPrefs.SetInt("Fire Shuriken", 1);
        PlayerPrefs.SetInt("Shuriken Styles", PlayerPrefs.GetInt("Light Shuriken") + PlayerPrefs.GetInt("Fire Shuriken"));
        PlayerPrefs.SetInt("Souls", 6);
        PlayerPrefs.SetInt("PlayerHeartLvl", 0);
        PlayerPrefs.SetInt("PlayerLightLvl", 0);
        PlayerPrefs.SetInt("PlayerBadgeLvl", 0);
        PlayerPrefs.SetInt("PlayerLvl", 1 + PlayerPrefs.GetInt("PlayerHeartLvl") + PlayerPrefs.GetInt("PlayerLightLvl") + PlayerPrefs.GetInt("PlayerBadgeLvl"));
        PlayerPrefs.SetInt("AdventurerLvl",3);
        PlayerPrefs.SetInt("language", 0);
        PlayerPrefs.SetInt("bandit", 0);
        PlayerPrefs.SetInt("wizard", 0);
        PlayerPrefs.SetInt("lvlXP", 0);
        //Find the gameobjects
        victoryXP = GameObject.Find("VictoryEXP");
        mainCamera = GameObject.Find("Main Camera");
        lightPointsUI = GameObject.Find("LightBckImage");
        actionInstructions = GameObject.Find("ActionInstructions");
        enemyName = GameObject.Find("EnemyNames");
        fleeAction = GameObject.Find("FleeAction");
        changePosAction = GameObject.Find("ChangeOrder");
        soul1 = GameObject.Find("Soul1Fill");
        soul2 = GameObject.Find("Soul2Fill");
        soul3 = GameObject.Find("Soul3Fill");
        soul4 = GameObject.Find("Soul4Fill");
        soul5 = GameObject.Find("Soul5Fill");
        soul6 = GameObject.Find("Soul6Fill");
        canvas = GameObject.Find("Canvas");
        xpText = canvas.transform.GetChild(3).GetChild(1).GetComponent<Text>();
        xpText.text = 0.ToString();
        xpObject = GameObject.Find("EXP");
        //Initialize variables
        if (PlayerPrefs.GetInt("Souls") == 1)
        {
            soul1.transform.parent.gameObject.SetActive(true);
            soul2.transform.parent.gameObject.SetActive(false);
            soul3.transform.parent.gameObject.SetActive(false);
            soul4.transform.parent.gameObject.SetActive(false);
            soul5.transform.parent.gameObject.SetActive(false);
            soul6.transform.parent.gameObject.SetActive(false);
        }
        else if (PlayerPrefs.GetInt("Souls") == 2)
        {
            soul1.transform.parent.gameObject.SetActive(true);
            soul2.transform.parent.gameObject.SetActive(true);
            soul3.transform.parent.gameObject.SetActive(false);
            soul4.transform.parent.gameObject.SetActive(false);
            soul5.transform.parent.gameObject.SetActive(false);
            soul6.transform.parent.gameObject.SetActive(false);
        }
        else if (PlayerPrefs.GetInt("Souls") == 3)
        {
            soul1.transform.parent.gameObject.SetActive(true);
            soul2.transform.parent.gameObject.SetActive(true);
            soul3.transform.parent.gameObject.SetActive(true);
            soul4.transform.parent.gameObject.SetActive(false);
            soul5.transform.parent.gameObject.SetActive(false);
            soul6.transform.parent.gameObject.SetActive(false);
        }
        else if (PlayerPrefs.GetInt("Souls") == 4)
        {
            soul1.transform.parent.gameObject.SetActive(true);
            soul2.transform.parent.gameObject.SetActive(true);
            soul3.transform.parent.gameObject.SetActive(true);
            soul4.transform.parent.gameObject.SetActive(true);
            soul5.transform.parent.gameObject.SetActive(false);
            soul6.transform.parent.gameObject.SetActive(false);
        }
        else if (PlayerPrefs.GetInt("Souls") == 5)
        {
            soul1.transform.parent.gameObject.SetActive(true);
            soul2.transform.parent.gameObject.SetActive(true);
            soul3.transform.parent.gameObject.SetActive(true);
            soul4.transform.parent.gameObject.SetActive(true);
            soul5.transform.parent.gameObject.SetActive(true);
            soul6.transform.parent.gameObject.SetActive(false);
        }
        else if (PlayerPrefs.GetInt("Souls") == 6)
        {
            soul1.transform.parent.gameObject.SetActive(true);
            soul2.transform.parent.gameObject.SetActive(true);
            soul3.transform.parent.gameObject.SetActive(true);
            soul4.transform.parent.gameObject.SetActive(true);
            soul5.transform.parent.gameObject.SetActive(true);
            soul6.transform.parent.gameObject.SetActive(true);
        }
        ring1 = new Transform[2];
        ring2 = new Transform[2];
        ring3 = new Transform[2];
        ring4 = new Transform[2];
        ring5 = new Transform[2];
        ring6 = new Transform[2];
        ring7 = new Transform[2];
        ring8 = new Transform[2];
        enemyNumber = 0;
        SpawnCharacter(0,0);
        player.GetChild(0).GetChild(0).GetChild(0).GetComponent<RawImage>().color = new Color(0.4f, 0.4f, 0.4f, player.GetChild(0).GetChild(0).GetChild(0).GetComponent<RawImage>().color.a);
        player.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<RawImage>().color = new Color(0.4f, 0.4f, 0.4f, player.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<RawImage>().color.a);
        player.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<Text>().color = new Color(0.4f, 0.4f, 0.4f, player.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<Text>().color.a);
        SpawnCharacter(1,0);
        SpawnCharacter(2,1);
        SpawnCharacter(3,0);
        //SpawnCharacter(4,1);
        //SpawnCharacter(5,0);
        playerTeamTurn = true;
        playerTurn = true;
        playerTurnCompleted = false;
        companionTurn = false;
        companionTurnCompleted = false;
        enemyTeamTurn = false;
        enemy1Turn = false;
        changePos = false;
        playerChoosingAction = true;
        companionChoosingAction = false;
        selectingEnemy = false;
        selectingEnemyCompanion = false;
        selectingPlayer = false;
        selectingCompanion = false;
        finalAttack = false;
        attackAction = false;
        attackFinished = false;
        firstPosPlayer = true;
        goodAttack = false;
        badAttack = false;
        lastLeft = false;
        shurikenHit = false;
        defenseZone = false;
        canSelect = false;
        fleeing = false;
        fled = false;
        swordStyles = new int[6];
        shurikenStyles = new int[6];
        defensePlayer = 0;
        defenseCompanion = 0;
        scroll = 0;
        soulMusic = 0;
        soulMusicFilling = true;
        failMusic = false;
        soulRegen = false;
        soulRegenMovUp = false;
        soulRegenMovLeft = false;
        soulRegenMovRight = false;
        soulRegenMovDown = false;
        soulLifesteal = false;
        soulLifestealNumb = 0;
        jarMovUp = false;
        jarMovLeft = false;
        jarMovRight = false;
        jarMovDown = false;
        soulDisappear = false;
        blueSoulMovUp = false;
        blueSoulMovLeft = false;
        blueSoulMovRight = false;
        blueSoulMovDown = false;
        soulLightUp = false;
        fogScaled = false;
        minFogScale = 1.0f;
        magentaSoulMovUp = false;
        magentaSoulMovLeft = false;
        magentaSoulMovRight = false;
        magentaSoulMovDown = false;
        talking = false;
        enemy1Turn = true;
        enemy2Turn = false;
        enemy3Turn = false;
        enemy4Turn = false;
        soulRegenRingSpeed = 0.03f;
        soulRegenGreenSpeed = 0.075f;
        soulRegenHeal = 0;
        soulRegenLight = 0;
        soulLightning = false;
        yellowSoulRight = true;
        menuCanUse = new bool[6];
        actionInstructions.SetActive(false);
        enemyName.SetActive(false);
        player.GetChild(0).transform.GetChild(3).gameObject.SetActive(false);
        player.GetChild(0).transform.GetChild(4).gameObject.SetActive(false);
        player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(7).GetComponent<Image>().color = new Vector4(player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(7).GetComponent<Image>().color.r, player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(7).GetComponent<Image>().color.g, player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(7).GetComponent<Image>().color.b, 0.0f);
        player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(8).GetComponent<Image>().color = new Vector4(player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(8).GetComponent<Image>().color.r, player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(8).GetComponent<Image>().color.g, player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(8).GetComponent<Image>().color.b, 0.0f);
        companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(7).GetComponent<Image>().color = new Vector4(companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(7).GetComponent<Image>().color.r, companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(7).GetComponent<Image>().color.g, companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(7).GetComponent<Image>().color.b, 0.0f);
        companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(8).GetComponent<Image>().color = new Vector4(companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(8).GetComponent<Image>().color.r, companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(8).GetComponent<Image>().color.g, companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(8).GetComponent<Image>().color.b, 0.0f);
        player.GetChild(0).transform.GetChild(6).gameObject.SetActive(false);
        fleeAction.SetActive(false);
        aimRotation = 0.0f;
        aimUp = true;
        readyShoot = false;
        currentFightXP = 0;
        
    }

    private void Update()
    {
        //When its player teams turn
        if (playerTeamTurn)
        {
            if (playerTurn)
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
                        if (selectingAction == 0 && Input.GetKeyDown(KeyCode.Space) && GetGroundEnemies() != null)
                        {
                            //if nothing is unlocked
                            if (PlayerPrefs.GetInt("Sword Styles") == 0)
                            {
                                changePosAction.SetActive(false);
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
                                changePosAction.SetActive(false);
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
                                changePosAction.SetActive(false);
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
                                changePosAction.SetActive(false);
                                CreateMenu();
                                actionInstructions.SetActive(true);
                                player.GetChild(0).transform.GetChild(0).GetComponent<Animator>().SetBool("MenuOpened", true);
                            }
                        }
                        else if (selectingAction == 2 && Input.GetKeyDown(KeyCode.Space))
                        {
                            changePosAction.SetActive(false);
                            CreateMenu();
                            actionInstructions.SetActive(true);
                            player.GetChild(0).transform.GetChild(0).GetComponent<Animator>().SetBool("MenuOpened", true);
                        }
                        else if (selectingAction == 3 && Input.GetKeyDown(KeyCode.Space))
                        {
                            changePosAction.SetActive(false);
                            CreateMenu();
                            actionInstructions.SetActive(true);
                            player.GetChild(0).transform.GetChild(0).GetComponent<Animator>().SetBool("MenuOpened", true);
                        }
                        else if (selectingAction == 4 && Input.GetKeyDown(KeyCode.Space))
                        {
                            changePosAction.SetActive(false);
                            CreateMenu();
                            actionInstructions.SetActive(true);
                            player.GetChild(0).transform.GetChild(0).GetComponent<Animator>().SetBool("MenuOpened", true);
                        }
                        if (!companionTurnCompleted && Input.GetKeyDown(KeyCode.Z)) StartChangePosition(1);
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
                                canSelect = true;
                                enemyName.SetActive(true);
                            }
                        }
                        else if (selectingAction == 3)
                        {
                            usingStyle = menuSelectionPos;
                            if (menuSelectionPos == 0) actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Play some soul music to sleep the enemies. That was a silly joke, sorry.";
                            else if (menuSelectionPos == 1) actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Regenerate some of your HP and LP.";
                            else if (menuSelectionPos == 2) actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Throw a thunder to the enemies.";
                            else if (menuSelectionPos == 3) actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Gain lifesteal, healing yourself damaging the enemy.";
                            else if (menuSelectionPos == 4) actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Dodge every attack for one or more enemy phases.";
                            else if (menuSelectionPos == 5) actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Power up for one attack. Stackable.";
                            if ((menuSelectionPos < (PlayerPrefs.GetInt("Souls") - 1)) && Input.GetKeyDown(KeyCode.DownArrow))
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
                                if (menuSelectionPos == 0) actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Press <sprite=198>, <sprite=214>, <sprite=246> or <sprite=230> when they appear.";
                                else if (menuSelectionPos == 1) actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Pass through the circles using <sprite=198>, <sprite=214>, <sprite=246> and <sprite=230> to gain LP and FP.";
                                else if (menuSelectionPos == 2) actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Press <sprite=336> when the yellow soul is over the enemy to deal damage. You have until the soul returns to deal damage.";
                                else if (menuSelectionPos == 3) actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Gather as many red souls as you can using <sprite=198>, <sprite=214>, <sprite=246> and <sprite=230> to move.";
                                else if (menuSelectionPos == 4) actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Use <sprite=198>, <sprite=214>, <sprite=246> and <sprite=230> to dodge the walls while the soul fades out.";
                                else if (menuSelectionPos == 5) actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Use <sprite=198>, <sprite=214>, <sprite=246> and <sprite=230> to move the soul and collect the soul shards. You can increase the visible area pressing <sprite=336> repeatedly.";
                                attackType = 2;
                                enemyName.SetActive(true);
                                if (menuSelectionPos == 0 || menuSelectionPos == 2)
                                {
                                    selectingEnemy = true;
                                    SelectAllEnemies();
                                }
                                else if (menuSelectionPos == 1 || menuSelectionPos == 3 || menuSelectionPos == 4 || menuSelectionPos == 5)
                                {
                                    player.transform.GetChild(0).transform.GetChild(5).gameObject.SetActive(true);
                                    enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = "Player";
                                    enemyName.transform.GetChild(1).gameObject.SetActive(false);
                                    enemyName.transform.GetChild(2).gameObject.SetActive(false);
                                    enemyName.transform.GetChild(3).gameObject.SetActive(false);
                                    enemyName.transform.GetChild(4).gameObject.SetActive(false);
                                    selectingPlayer = true;
                                    if (menuSelectionPos == 1)
                                    {
                                        companion.GetChild(0).transform.GetChild(1).gameObject.SetActive(true);
                                        enemyName.transform.GetChild(1).gameObject.SetActive(true);
                                        enemyName.transform.GetChild(1).transform.GetChild(0).GetComponent<Text>().text = "Adventurer";
                                        canSelect = false;
                                    }
                                    else canSelect = true;
                                }
                            }
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
                                if (menuSelectionPos == 1)
                                {
                                    defensePlayer = 1;
                                    player.GetChild(0).transform.GetChild(0).GetComponent<Animator>().SetBool("Active", false);
                                    player.GetChild(0).transform.GetChild(0).GetComponent<Animator>().SetBool("MenuHide", false);
                                    player.GetChild(0).transform.GetChild(0).GetComponent<Animator>().SetBool("MenuOpened", false);
                                    actionInstructions.SetActive(false);
                                    EndPlayerTurn(1);
                                }
                                else if (menuSelectionPos == 2)
                                {
                                    fleeAction.transform.GetChild(2).transform.position = new Vector3((fleeAction.transform.position.x - 1.930875f) + Random.Range(0.0f, 100.0f) * 0.0386175f, fleeAction.transform.GetChild(2).transform.position.y, fleeAction.transform.GetChild(2).transform.position.z);
                                    fleeRight = Random.Range(0.0f, 100.0f) > 50.0f;
                                    player.GetChild(0).transform.GetChild(0).GetComponent<Animator>().SetBool("Active", false);
                                    player.GetChild(0).transform.GetChild(0).GetComponent<Animator>().SetBool("MenuOpened", false);
                                    actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Press <sprite=336> repeatedly to fill the bar.";
                                    fleeTime = Time.fixedTime;
                                    playerChoosingAction = false;
                                    player.GetComponent<Animator>().SetFloat("Speed", -0.5f);
                                    player.GetComponent<Animator>().SetFloat("attackSpeed", 2.0f);
                                    companion.GetComponent<Animator>().SetFloat("RunSpeed", -0.5f);
                                    companion.GetComponent<Animator>().SetFloat("Speed", 1.5f);
                                    fleeTime = Time.fixedTime;
                                    companionChoosingAction = false;
                                    fleeAction.SetActive(true);
                                    fleeing = true;
                                }
                            }
                        }
                        if (Input.GetKeyDown(KeyCode.Q))
                        {
                            changePosAction.SetActive(!companionTurnCompleted);
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
                        companion.GetChild(0).transform.GetChild(1).gameObject.SetActive(false);
                    }
                    if (canSelect)
                    {
                        if (player.GetChild(0).transform.GetChild(5).gameObject.activeSelf)
                        {
                            if (firstPosPlayer)
                            {
                                if (Input.GetKeyDown(KeyCode.LeftArrow))
                                {
                                    player.GetChild(0).transform.GetChild(5).gameObject.SetActive(false);
                                    companion.GetChild(0).transform.GetChild(1).gameObject.SetActive(true);
                                    enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = "Adventurer";
                                }
                            }
                            else
                            {
                                if (Input.GetKeyDown(KeyCode.RightArrow))
                                {
                                    player.GetChild(0).transform.GetChild(5).gameObject.SetActive(false);
                                    companion.GetChild(0).transform.GetChild(1).gameObject.SetActive(true);
                                    enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = "Adventurer";
                                }
                            }
                            if (Input.GetKeyDown(KeyCode.Space))
                            {
                                player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(7).gameObject.SetActive(false);
                                player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(8).gameObject.SetActive(false);
                                player.GetChild(0).transform.GetChild(5).gameObject.SetActive(false);
                                player.GetChild(0).transform.GetChild(0).GetComponent<Animator>().SetBool("Active", false);
                                player.GetChild(0).transform.GetChild(0).GetComponent<Animator>().SetBool("MenuHide", false);
                                player.GetChild(0).transform.GetChild(0).GetComponent<Animator>().SetBool("MenuOpened", false);
                                enemyName.SetActive(false);
                                selectingPlayer = false;
                                if (selectingAction == 2)
                                {
                                    if (items[menuSelectionPos + scroll] == 1) player.GetComponent<PlayerTeamScript>().Heal(5, false, true, true, false);
                                    else if (items[menuSelectionPos + scroll] == 2) player.GetComponent<PlayerTeamScript>().IncreaseLight(5, false, true, false);
                                    DeleteItem(menuSelectionPos + scroll);
                                    scroll = 0;
                                    actionInstructions.SetActive(false);
                                }
                                else if (selectingAction == 3)
                                {
                                    if (!firstPosPlayer) player.GetChild(0).transform.position = new Vector3(player.GetChild(0).transform.position.x + 1.4f, player.GetChild(0).transform.position.y, player.GetChild(0).transform.position.z);
                                    selectedEnemy = player;
                                    actionInstructions.GetComponent<Image>().color = new Vector4(actionInstructions.GetComponent<Image>().color.r, actionInstructions.GetComponent<Image>().color.g, actionInstructions.GetComponent<Image>().color.b, 1.0f);
                                    actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = new Vector4(actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color.r, actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color.g, actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color.b, 1.0f);
                                    player.GetComponent<PlayerTeamScript>().Attack(attackType, usingStyle, selectedEnemy);
                                }
                            }
                        }
                        else if (companion.GetChild(0).transform.GetChild(1).gameObject.activeSelf)
                        {
                            if (firstPosPlayer)
                            {
                                if (Input.GetKeyDown(KeyCode.RightArrow))
                                {
                                    player.GetChild(0).transform.GetChild(5).gameObject.SetActive(true);
                                    companion.GetChild(0).transform.GetChild(1).gameObject.SetActive(false);
                                    enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = "Player";
                                }
                            }
                            else
                            {
                                if (Input.GetKeyDown(KeyCode.LeftArrow))
                                {
                                    player.GetChild(0).transform.GetChild(5).gameObject.SetActive(true);
                                    companion.GetChild(0).transform.GetChild(1).gameObject.SetActive(false);
                                    enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = "Player";
                                }
                            }
                            if (Input.GetKeyDown(KeyCode.Space))
                            {
                                player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(7).gameObject.SetActive(false);
                                player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(8).gameObject.SetActive(false);
                                companion.GetChild(0).transform.GetChild(1).gameObject.SetActive(false);
                                player.GetChild(0).transform.GetChild(0).GetComponent<Animator>().SetBool("Active", false);
                                player.GetChild(0).transform.GetChild(0).GetComponent<Animator>().SetBool("MenuHide", false);
                                player.GetChild(0).transform.GetChild(0).GetComponent<Animator>().SetBool("MenuOpened", false);
                                selectingPlayer = false;
                                enemyName.SetActive(false);
                                if (selectingAction == 2)
                                {
                                    if (items[menuSelectionPos + scroll] == 1) companion.GetComponent<PlayerTeamScript>().Heal(5, false, true, true, false);
                                    else if (items[menuSelectionPos + scroll] == 2) player.GetComponent<PlayerTeamScript>().IncreaseLight(5, false, true, false);
                                    DeleteItem(menuSelectionPos + scroll);
                                    scroll = 0;
                                    actionInstructions.SetActive(false);
                                }
                                else if (selectingAction == 3)
                                {
                                    if (!firstPosPlayer) player.GetChild(0).transform.position = new Vector3(player.GetChild(0).transform.position.x + 1.4f, player.GetChild(0).transform.position.y, player.GetChild(0).transform.position.z);
                                    selectedEnemy = companion;
                                    actionInstructions.GetComponent<Image>().color = new Vector4(actionInstructions.GetComponent<Image>().color.r, actionInstructions.GetComponent<Image>().color.g, actionInstructions.GetComponent<Image>().color.b, 1.0f);
                                    actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = new Vector4(actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color.r, actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color.g, actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color.b, 1.0f);
                                    player.GetComponent<PlayerTeamScript>().Attack(attackType, usingStyle, selectedEnemy);
                                }
                            }
                        }
                    }
                    else
                    {
                        if (Input.GetKeyDown(KeyCode.Space))
                        {
                            player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(7).gameObject.SetActive(false);
                            player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(8).gameObject.SetActive(false);
                            player.GetChild(0).transform.GetChild(5).gameObject.SetActive(false);
                            companion.GetChild(0).transform.GetChild(1).gameObject.SetActive(false);
                            player.GetChild(0).transform.GetChild(0).GetComponent<Animator>().SetBool("Active", false);
                            player.GetChild(0).transform.GetChild(0).GetComponent<Animator>().SetBool("MenuHide", false);
                            player.GetChild(0).transform.GetChild(0).GetComponent<Animator>().SetBool("MenuOpened", false);
                            enemyName.SetActive(false);
                            selectingPlayer = false;
                            if (!firstPosPlayer) player.GetChild(0).transform.position = new Vector3(player.GetChild(0).transform.position.x + 1.4f, player.GetChild(0).transform.position.y, player.GetChild(0).transform.position.z);
                            selectedEnemy = companion;
                            actionInstructions.GetComponent<Image>().color = new Vector4(actionInstructions.GetComponent<Image>().color.r, actionInstructions.GetComponent<Image>().color.g, actionInstructions.GetComponent<Image>().color.b, 1.0f);
                            actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = new Vector4(actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color.r, actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color.g, actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color.b, 1.0f);
                            player.GetComponent<PlayerTeamScript>().Attack(attackType, usingStyle, selectedEnemy);
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
                        else if(enemyNumber < 4)
                        {
                            enemy1.GetChild(0).transform.GetChild(0).gameObject.SetActive(false);
                            enemy2.GetChild(0).transform.GetChild(0).gameObject.SetActive(false);
                            enemy3.GetChild(0).transform.GetChild(0).gameObject.SetActive(false);
                        }
                        else if (enemyNumber < 5)
                        {
                            enemy1.GetChild(0).transform.GetChild(0).gameObject.SetActive(false);
                            enemy2.GetChild(0).transform.GetChild(0).gameObject.SetActive(false);
                            enemy3.GetChild(0).transform.GetChild(0).gameObject.SetActive(false);
                            enemy4.GetChild(0).transform.GetChild(0).gameObject.SetActive(false);
                        }
                    }
                    //When we can select an enemy
                    if (canSelect)
                    {
                        //When we have 2 or more enemies we decide which enemy to attack using the arrows and we select it using space and the attack starts
                        if (enemyNumber > 1)
                        {
                            if (enemy1.GetChild(0).transform.GetChild(0).gameObject.activeSelf)
                            {
                                if (Input.GetKeyDown(KeyCode.RightArrow))
                                {
                                    if(selectingAction == 0)
                                    {
                                        if (enemy2.GetComponent<EnemyTeamScript>().IsAlive() && ((selectingAction == 0 && enemy2.GetComponent<EnemyTeamScript>().IsGrounded()) || selectingAction == 1))
                                        {
                                            enemy1.GetChild(0).transform.GetChild(0).gameObject.SetActive(false);
                                            enemy2.GetChild(0).transform.GetChild(0).gameObject.SetActive(true);
                                            if (enemy2.GetComponent<EnemyTeamScript>().enemyType == 0)
                                            {
                                                enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = "Bandit";
                                            }
                                            else if (enemy2.GetComponent<EnemyTeamScript>().enemyType == 1)
                                            {
                                                enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = "Wizard";
                                            }
                                        }
                                        else if (enemyNumber > 2 && enemy3.GetComponent<EnemyTeamScript>().IsAlive() && ((selectingAction == 0 && enemy3.GetComponent<EnemyTeamScript>().IsGrounded()) || selectingAction == 1))
                                        {
                                            enemy1.GetChild(0).transform.GetChild(0).gameObject.SetActive(false);
                                            enemy3.GetChild(0).transform.GetChild(0).gameObject.SetActive(true);
                                            if (enemy3.GetComponent<EnemyTeamScript>().enemyType == 0)
                                            {
                                                enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = "Bandit";
                                            }
                                            else if (enemy3.GetComponent<EnemyTeamScript>().enemyType == 1)
                                            {
                                                enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = "Wizard";
                                            }
                                        }
                                        else if (enemyNumber > 3 && enemy4.GetComponent<EnemyTeamScript>().IsAlive() && ((selectingAction == 0 && enemy4.GetComponent<EnemyTeamScript>().IsGrounded()) || selectingAction == 1))
                                        {
                                            enemy1.GetChild(0).transform.GetChild(0).gameObject.SetActive(false);
                                            enemy4.GetChild(0).transform.GetChild(0).gameObject.SetActive(true);
                                            if (enemy4.GetComponent<EnemyTeamScript>().enemyType == 0)
                                            {
                                                enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = "Bandit";
                                            }
                                            else if (enemy4.GetComponent<EnemyTeamScript>().enemyType == 1)
                                            {
                                                enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = "Wizard";
                                            }
                                        }
                                    }
                                    else
                                    {
                                        Transform enemy = SelectNextShuriken(enemy1.GetComponent<EnemyTeamScript>().IsGrounded());
                                        enemy1.GetChild(0).transform.GetChild(0).gameObject.SetActive(false);
                                        if(enemy!= null)
                                        {
                                            enemy.GetChild(0).transform.GetChild(0).gameObject.SetActive(true);
                                            if (enemy.GetComponent<EnemyTeamScript>().enemyType == 0)
                                            {
                                                enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = "Bandit";
                                            }
                                            else if (enemy.GetComponent<EnemyTeamScript>().enemyType == 1)
                                            {
                                                enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = "Wizard";
                                            }
                                        }
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
                                if (Input.GetKeyDown(KeyCode.LeftArrow) && enemy1.GetComponent<EnemyTeamScript>().IsAlive() && ((selectingAction == 0 && enemy1.GetComponent<EnemyTeamScript>().IsGrounded()) || selectingAction == 1))
                                {
                                    enemy1.GetChild(0).transform.GetChild(0).gameObject.SetActive(true);
                                    enemy2.GetChild(0).transform.GetChild(0).gameObject.SetActive(false);
                                    if (enemy1.GetComponent<EnemyTeamScript>().enemyType == 0)
                                    {
                                        enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = "Bandit";
                                    }
                                    else if (enemy1.GetComponent<EnemyTeamScript>().enemyType == 1)
                                    {
                                        enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = "Wizard";
                                    }
                                }
                                if (Input.GetKeyDown(KeyCode.RightArrow))
                                {
                                    if(selectingAction == 0)
                                    {
                                        if (enemyNumber > 2 && enemy3.GetComponent<EnemyTeamScript>().IsAlive() && ((selectingAction == 0 && enemy3.GetComponent<EnemyTeamScript>().IsGrounded()) || selectingAction == 1))
                                        {
                                            enemy2.GetChild(0).transform.GetChild(0).gameObject.SetActive(false);
                                            enemy3.GetChild(0).transform.GetChild(0).gameObject.SetActive(true);
                                            if (enemy3.GetComponent<EnemyTeamScript>().enemyType == 0)
                                            {
                                                enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = "Bandit";
                                            }
                                            else if (enemy3.GetComponent<EnemyTeamScript>().enemyType == 1)
                                            {
                                                enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = "Wizard";
                                            }
                                        }
                                        else if (enemyNumber > 3 && enemy4.GetComponent<EnemyTeamScript>().IsAlive() && ((selectingAction == 0 && enemy4.GetComponent<EnemyTeamScript>().IsGrounded()) || selectingAction == 1))
                                        {
                                            enemy2.GetChild(0).transform.GetChild(0).gameObject.SetActive(false);
                                            enemy4.GetChild(0).transform.GetChild(0).gameObject.SetActive(true);
                                            if (enemy4.GetComponent<EnemyTeamScript>().enemyType == 0)
                                            {
                                                enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = "Bandit";
                                            }
                                            else if (enemy4.GetComponent<EnemyTeamScript>().enemyType == 1)
                                            {
                                                enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = "Wizard";
                                            }
                                        }
                                    }
                                    else if(!enemy1.GetComponent<EnemyTeamScript>().IsAlive())
                                    {
                                        Transform enemy = SelectNextShuriken(enemy2.GetComponent<EnemyTeamScript>().IsGrounded());
                                        enemy2.GetChild(0).transform.GetChild(0).gameObject.SetActive(false);
                                        if(enemy != null)
                                        {
                                            enemy.GetChild(0).transform.GetChild(0).gameObject.SetActive(true);
                                            if (enemy.GetComponent<EnemyTeamScript>().enemyType == 0)
                                            {
                                                enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = "Bandit";
                                            }
                                            else if (enemy.GetComponent<EnemyTeamScript>().enemyType == 1)
                                            {
                                                enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = "Wizard";
                                            }
                                        }
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
                            else if (enemy3.GetChild(0).transform.GetChild(0).gameObject.activeSelf)
                            {
                                if (Input.GetKeyDown(KeyCode.LeftArrow))
                                {
                                    if(selectingAction == 0)
                                    {
                                        if (enemy2.GetComponent<EnemyTeamScript>().IsAlive() && ((selectingAction == 0 && enemy2.GetComponent<EnemyTeamScript>().IsGrounded()) || selectingAction == 1))
                                        {
                                            enemy2.GetChild(0).transform.GetChild(0).gameObject.SetActive(true);
                                            enemy3.GetChild(0).transform.GetChild(0).gameObject.SetActive(false);
                                            if (enemy2.GetComponent<EnemyTeamScript>().enemyType == 0)
                                            {
                                                enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = "Bandit";
                                            }
                                            else if (enemy2.GetComponent<EnemyTeamScript>().enemyType == 1)
                                            {
                                                enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = "Wizard";
                                            }
                                        }
                                        else if (enemy1.GetComponent<EnemyTeamScript>().IsAlive() && ((selectingAction == 0 && enemy1.GetComponent<EnemyTeamScript>().IsGrounded()) || selectingAction == 1))
                                        {
                                            enemy1.GetChild(0).transform.GetChild(0).gameObject.SetActive(true);
                                            enemy3.GetChild(0).transform.GetChild(0).gameObject.SetActive(false);
                                            if (enemy1.GetComponent<EnemyTeamScript>().enemyType == 0)
                                            {
                                                enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = "Bandit";
                                            }
                                            else if (enemy1.GetComponent<EnemyTeamScript>().enemyType == 1)
                                            {
                                                enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = "Wizard";
                                            }
                                        }
                                    }
                                    else if(enemy1.GetComponent<EnemyTeamScript>().IsAlive() || enemy2.GetComponent<EnemyTeamScript>().IsAlive())
                                    {
                                        Transform enemy = SelectNextShuriken(enemy3.GetComponent<EnemyTeamScript>().IsGrounded());
                                        enemy3.GetChild(0).transform.GetChild(0).gameObject.SetActive(false);
                                        if (enemy != null)
                                        {
                                            enemy.GetChild(0).transform.GetChild(0).gameObject.SetActive(true);
                                            if (enemy.GetComponent<EnemyTeamScript>().enemyType == 0)
                                            {
                                                enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = "Bandit";
                                            }
                                            else if (enemy.GetComponent<EnemyTeamScript>().enemyType == 1)
                                            {
                                                enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = "Wizard";
                                            }
                                        }
                                    }
                                }
                                if (Input.GetKeyDown(KeyCode.RightArrow))
                                {
                                    if(selectingAction == 0)
                                    {
                                        if (enemyNumber > 3 && enemy4.GetComponent<EnemyTeamScript>().IsAlive() && ((selectingAction == 0 && enemy4.GetComponent<EnemyTeamScript>().IsGrounded()) || selectingAction == 1))
                                        {
                                            enemy3.GetChild(0).transform.GetChild(0).gameObject.SetActive(false);
                                            enemy4.GetChild(0).transform.GetChild(0).gameObject.SetActive(true);
                                            if (enemy4.GetComponent<EnemyTeamScript>().enemyType == 0)
                                            {
                                                enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = "Bandit";
                                            }
                                            else if (enemy4.GetComponent<EnemyTeamScript>().enemyType == 1)
                                            {
                                                enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = "Wizard";
                                            }
                                        }
                                    }
                                    else if (!enemy1.GetComponent<EnemyTeamScript>().IsAlive() && !enemy2.GetComponent<EnemyTeamScript>().IsAlive())
                                    {
                                        Transform enemy = SelectNextShuriken(enemy3.GetComponent<EnemyTeamScript>().IsGrounded());
                                        enemy3.GetChild(0).transform.GetChild(0).gameObject.SetActive(false);
                                        if (enemy != null)
                                        {
                                            enemy.GetChild(0).transform.GetChild(0).gameObject.SetActive(true);
                                            if (enemy.GetComponent<EnemyTeamScript>().enemyType == 0)
                                            {
                                                enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = "Bandit";
                                            }
                                            else if (enemy.GetComponent<EnemyTeamScript>().enemyType == 1)
                                            {
                                                enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = "Wizard";
                                            }
                                        }
                                    }
                                }
                                if (Input.GetKeyDown(KeyCode.Space))
                                {
                                    player.GetChild(0).transform.GetChild(0).GetComponent<Animator>().SetBool("Active", false);
                                    player.GetChild(0).transform.GetChild(0).GetComponent<Animator>().SetBool("MenuHide", false);
                                    enemy3.GetChild(0).transform.GetChild(0).gameObject.SetActive(false);
                                    player.GetChild(0).transform.GetChild(0).GetComponent<Animator>().SetBool("MenuOpened", false);
                                    selectedEnemy = enemy3;
                                    selectingEnemy = false;
                                    enemyName.SetActive(false);
                                    actionInstructions.GetComponent<Image>().color = new Vector4(actionInstructions.GetComponent<Image>().color.r, actionInstructions.GetComponent<Image>().color.g, actionInstructions.GetComponent<Image>().color.b, 1.0f);
                                    actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = new Vector4(actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color.r, actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color.g, actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color.b, 1.0f);
                                    player.GetComponent<PlayerTeamScript>().Attack(attackType, usingStyle, selectedEnemy);
                                }
                            }
                            else if (enemy4.GetChild(0).transform.GetChild(0).gameObject.activeSelf)
                            {
                                if (Input.GetKeyDown(KeyCode.LeftArrow))
                                {
                                    if(selectingAction == 0)
                                    {
                                        if (enemy3.GetComponent<EnemyTeamScript>().IsAlive() && ((selectingAction == 0 && enemy3.GetComponent<EnemyTeamScript>().IsGrounded()) || selectingAction == 1))
                                        {
                                            enemy3.GetChild(0).transform.GetChild(0).gameObject.SetActive(true);
                                            enemy4.GetChild(0).transform.GetChild(0).gameObject.SetActive(false);
                                            if (enemy3.GetComponent<EnemyTeamScript>().enemyType == 0)
                                            {
                                                enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = "Bandit";
                                            }
                                            else if (enemy3.GetComponent<EnemyTeamScript>().enemyType == 1)
                                            {
                                                enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = "Wizard";
                                            }
                                        }
                                        else if (enemy2.GetComponent<EnemyTeamScript>().IsAlive() && ((selectingAction == 0 && enemy2.GetComponent<EnemyTeamScript>().IsGrounded()) || selectingAction == 1))
                                        {
                                            enemy2.GetChild(0).transform.GetChild(0).gameObject.SetActive(true);
                                            enemy4.GetChild(0).transform.GetChild(0).gameObject.SetActive(false);
                                            if (enemy2.GetComponent<EnemyTeamScript>().enemyType == 0)
                                            {
                                                enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = "Bandit";
                                            }
                                            if (enemy2.GetComponent<EnemyTeamScript>().enemyType == 1)
                                            {
                                                enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = "Wizard";
                                            }
                                        }
                                        else if (enemy1.GetComponent<EnemyTeamScript>().IsAlive() && ((selectingAction == 0 && enemy1.GetComponent<EnemyTeamScript>().IsGrounded()) || selectingAction == 1))
                                        {
                                            enemy1.GetChild(0).transform.GetChild(0).gameObject.SetActive(true);
                                            enemy4.GetChild(0).transform.GetChild(0).gameObject.SetActive(false);
                                            if (enemy1.GetComponent<EnemyTeamScript>().enemyType == 0)
                                            {
                                                enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = "Bandit";
                                            }
                                            if (enemy1.GetComponent<EnemyTeamScript>().enemyType == 1)
                                            {
                                                enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = "Wizard";
                                            }
                                        }
                                    }
                                    else
                                    {
                                        Transform enemy = SelectNextShuriken(enemy4.GetComponent<EnemyTeamScript>().IsGrounded());
                                        enemy4.GetChild(0).transform.GetChild(0).gameObject.SetActive(false);
                                        if (enemy != null)
                                        {
                                            enemy.GetChild(0).transform.GetChild(0).gameObject.SetActive(true);
                                            if (enemy.GetComponent<EnemyTeamScript>().enemyType == 0)
                                            {
                                                enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = "Bandit";
                                            }
                                            else if (enemy.GetComponent<EnemyTeamScript>().enemyType == 1)
                                            {
                                                enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = "Wizard";
                                            }
                                        }
                                    }
                                }
                                if (Input.GetKeyDown(KeyCode.Space))
                                {
                                    player.GetChild(0).transform.GetChild(0).GetComponent<Animator>().SetBool("Active", false);
                                    player.GetChild(0).transform.GetChild(0).GetComponent<Animator>().SetBool("MenuHide", false);
                                    enemy4.GetChild(0).transform.GetChild(0).gameObject.SetActive(false);
                                    player.GetChild(0).transform.GetChild(0).GetComponent<Animator>().SetBool("MenuOpened", false);
                                    selectedEnemy = enemy4;
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
                        Transform[] allEnemies = GetAllEnemies();
                        for (int i = 0; i < allEnemies.Length; i++)
                        {
                            allEnemies[i].GetChild(0).transform.GetChild(0).gameObject.SetActive(false);
                            enemyName.transform.GetChild(i).gameObject.SetActive(false);
                        }
                        if (!firstPosPlayer && attackType == 2) player.GetChild(0).transform.position = new Vector3(player.GetChild(0).transform.position.x + 1.4f, player.GetChild(0).transform.position.y, player.GetChild(0).transform.position.z);
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
                            if (Input.GetKeyUp(KeyCode.X) && attackAction)
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
                        else if (usingStyle == 2)
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
                        if (usingStyle == 0)
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
                        else if (usingStyle == 1)
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
                        else if (usingStyle == 2)
                        {
                            if (Time.fixedTime - shurikenTime < 2.5f && player.transform.GetChild(0).transform.GetChild(4).transform.GetChild(1).GetComponent<Image>().fillAmount < 1.0f)
                            {
                                if (Input.GetKeyDown(KeyCode.LeftArrow) && !lastLeft)
                                {
                                    lastLeft = true;
                                    player.transform.GetChild(0).transform.GetChild(4).transform.GetChild(1).GetComponent<Image>().fillAmount += 0.06f;
                                    if (player.transform.GetChild(0).transform.GetChild(4).transform.GetChild(1).GetComponent<Image>().fillAmount >= 1.0f)
                                    {
                                        player.transform.GetChild(0).transform.GetChild(4).transform.GetChild(2).GetComponent<Image>().sprite = fillIcon;
                                        player.transform.GetChild(2).GetComponent<Light>().intensity = 4.0f;
                                    }
                                }
                                else if (Input.GetKeyDown(KeyCode.RightArrow) && lastLeft)
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
                    else if (soulMusic > 0 && !failMusic)
                    {
                        player.GetChild(0).transform.GetChild(7).transform.GetChild(2).GetComponent<RectTransform>().anchoredPosition = new Vector3(player.GetChild(0).transform.GetChild(7).transform.GetChild(1).GetComponent<Image>().fillAmount * 10.9f - 5.45f, player.GetChild(0).transform.GetChild(7).transform.GetChild(2).GetComponent<RectTransform>().anchoredPosition.y, 0.0f);
                        if (soulMusicFilling)
                        {
                            if (player.GetChild(0).transform.GetChild(7).transform.GetChild(1).GetComponent<Image>().fillAmount < (((key1.gameObject.GetComponent<RectTransform>().anchoredPosition.x + 5.45f) * 0.5f / 5.45f) - 0.023f))
                            {
                                if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow)) failMusic = true;
                            }
                            if (player.GetChild(0).transform.GetChild(7).transform.GetChild(1).GetComponent<Image>().fillAmount > (((key1.gameObject.GetComponent<RectTransform>().anchoredPosition.x + 5.45f) * 0.5 / 5.45) - 0.073f) && key1Cover.gameObject.activeSelf)
                            {
                                key1Cover.GetComponent<Image>().color = new Vector4(key1Cover.GetComponent<Image>().color.r, key1Cover.GetComponent<Image>().color.g, key1Cover.GetComponent<Image>().color.b, 1.0f - 20.0f * (player.GetChild(0).transform.GetChild(7).transform.GetChild(1).GetComponent<Image>().fillAmount - (((key1.gameObject.GetComponent<RectTransform>().anchoredPosition.x + 5.45f) * 0.5f / 5.45f) - 0.073f)));
                                if (player.GetChild(0).transform.GetChild(7).transform.GetChild(1).GetComponent<Image>().fillAmount > (((key1.gameObject.GetComponent<RectTransform>().anchoredPosition.x + 5.45f) * 0.5 / 5.45) - 0.023f))
                                {
                                    key1Cover.gameObject.SetActive(false);
                                    key1.GetComponent<Image>().color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
                                }
                            }
                            else if (player.GetChild(0).transform.GetChild(7).transform.GetChild(1).GetComponent<Image>().fillAmount > (((key1.gameObject.GetComponent<RectTransform>().anchoredPosition.x + 5.45f) * 0.5 / 5.45) - 0.023f) && player.GetChild(0).transform.GetChild(7).transform.GetChild(1).GetComponent<Image>().fillAmount < (((key1.gameObject.GetComponent<RectTransform>().anchoredPosition.x + 5.45f) * 0.5 / 5.45) + 0.023f))
                            {
                                if (key1Input == 0)
                                {
                                    if (Input.GetKeyDown(KeyCode.UpArrow))
                                    {
                                        key1.GetComponent<Image>().color = new Vector4(0.0f, 0.7924528f, 0.1492666f, 1.0f);
                                        key1Input = 4;
                                    }
                                    else if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.DownArrow)) failMusic = true;
                                }
                                else if (key1Input == 1)
                                {
                                    if (Input.GetKeyDown(KeyCode.LeftArrow))
                                    {
                                        key1.GetComponent<Image>().color = new Vector4(0.0f, 0.7924528f, 0.1492666f, 1.0f);
                                        key1Input = 4;
                                    }
                                    else if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.DownArrow)) failMusic = true;
                                }
                                else if (key1Input == 2)
                                {
                                    if (Input.GetKeyDown(KeyCode.RightArrow))
                                    {
                                        key1.GetComponent<Image>().color = new Vector4(0.0f, 0.7924528f, 0.1492666f, 1.0f);
                                        key1Input = 4;
                                    }
                                    else if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow)) failMusic = true;
                                }
                                else if (key1Input == 3)
                                {
                                    if (Input.GetKeyDown(KeyCode.DownArrow))
                                    {
                                        key1.GetComponent<Image>().color = new Vector4(0.0f, 0.7924528f, 0.1492666f, 1.0f);
                                        key1Input = 4;
                                    }
                                    else if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.UpArrow)) failMusic = true;
                                }
                                else if (key1Input == 4)
                                {
                                    if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow)) failMusic = true;
                                }
                            }
                            else if (player.GetChild(0).transform.GetChild(7).transform.GetChild(1).GetComponent<Image>().fillAmount > (((key1.gameObject.GetComponent<RectTransform>().anchoredPosition.x + 5.45f) * 0.5 / 5.45) + 0.023f) && key1Input != 4)
                            {
                                failMusic = true;
                            }
                            else if (player.GetChild(0).transform.GetChild(7).transform.GetChild(1).GetComponent<Image>().fillAmount > (((key1.gameObject.GetComponent<RectTransform>().anchoredPosition.x + 5.45f) * 0.5 / 5.45) + 0.023f) && player.GetChild(0).transform.GetChild(7).transform.GetChild(1).GetComponent<Image>().fillAmount < (((key2.gameObject.GetComponent<RectTransform>().anchoredPosition.x + 5.45f) * 0.5 / 5.45) - 0.023f))
                            {
                                if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow)) failMusic = true;
                            }
                            if (player.GetChild(0).transform.GetChild(7).transform.GetChild(1).GetComponent<Image>().fillAmount > (((key2.gameObject.GetComponent<RectTransform>().anchoredPosition.x + 5.45f) * 0.5 / 5.45) - 0.073f) && key2Cover.gameObject.activeSelf)
                            {
                                key2Cover.GetComponent<Image>().color = new Vector4(key2Cover.GetComponent<Image>().color.r, key2Cover.GetComponent<Image>().color.g, key2Cover.GetComponent<Image>().color.b, 1.0f - 20.0f * (player.GetChild(0).transform.GetChild(7).transform.GetChild(1).GetComponent<Image>().fillAmount - (((key2.gameObject.GetComponent<RectTransform>().anchoredPosition.x + 5.45f) * 0.5f / 5.45f) - 0.073f)));
                                if (player.GetChild(0).transform.GetChild(7).transform.GetChild(1).GetComponent<Image>().fillAmount > (((key2.gameObject.GetComponent<RectTransform>().anchoredPosition.x + 5.45f) * 0.5 / 5.45) - 0.023f))
                                {
                                    key2Cover.gameObject.SetActive(false);
                                    key2.GetComponent<Image>().color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
                                }
                            }
                            else if (player.GetChild(0).transform.GetChild(7).transform.GetChild(1).GetComponent<Image>().fillAmount > (((key2.gameObject.GetComponent<RectTransform>().anchoredPosition.x + 5.45f) * 0.5 / 5.45) - 0.023f) && player.GetChild(0).transform.GetChild(7).transform.GetChild(1).GetComponent<Image>().fillAmount < (((key2.gameObject.GetComponent<RectTransform>().anchoredPosition.x + 5.45f) * 0.5 / 5.45) + 0.023f))
                            {
                                if (key2Input == 0)
                                {
                                    if (Input.GetKeyDown(KeyCode.UpArrow))
                                    {
                                        key2.GetComponent<Image>().color = new Vector4(0.0f, 0.7924528f, 0.1492666f, 1.0f);
                                        key2Input = 4;
                                    }
                                    else if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.DownArrow)) failMusic = true;
                                }
                                else if (key2Input == 1)
                                {
                                    if (Input.GetKeyDown(KeyCode.LeftArrow))
                                    {
                                        key2.GetComponent<Image>().color = new Vector4(0.0f, 0.7924528f, 0.1492666f, 1.0f);
                                        key2Input = 4;
                                    }
                                    else if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.DownArrow)) failMusic = true;
                                }
                                else if (key2Input == 2)
                                {
                                    if (Input.GetKeyDown(KeyCode.RightArrow))
                                    {
                                        key2.GetComponent<Image>().color = new Vector4(0.0f, 0.7924528f, 0.1492666f, 1.0f);
                                        key2Input = 4;
                                    }
                                    else if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow)) failMusic = true;
                                }
                                else if (key2Input == 3)
                                {
                                    if (Input.GetKeyDown(KeyCode.DownArrow))
                                    {
                                        key2.GetComponent<Image>().color = new Vector4(0.0f, 0.7924528f, 0.1492666f, 1.0f);
                                        key2Input = 4;
                                    }
                                    else if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.UpArrow)) failMusic = true;
                                }
                                else if (key2Input == 4)
                                {
                                    if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow)) failMusic = true;
                                }
                            }
                            else if (player.GetChild(0).transform.GetChild(7).transform.GetChild(1).GetComponent<Image>().fillAmount > (((key2.gameObject.GetComponent<RectTransform>().anchoredPosition.x + 5.45f) * 0.5 / 5.45) + 0.023f) && key2Input != 4)
                            {
                                failMusic = true;
                            }
                            else if (player.GetChild(0).transform.GetChild(7).transform.GetChild(1).GetComponent<Image>().fillAmount > (((key2.gameObject.GetComponent<RectTransform>().anchoredPosition.x + 5.45f) * 0.5 / 5.45) + 0.023f) && player.GetChild(0).transform.GetChild(7).transform.GetChild(1).GetComponent<Image>().fillAmount < (((key3.gameObject.GetComponent<RectTransform>().anchoredPosition.x + 5.45f) * 0.5 / 5.45) - 0.023f))
                            {
                                if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow)) failMusic = true;
                            }
                            if (player.GetChild(0).transform.GetChild(7).transform.GetChild(1).GetComponent<Image>().fillAmount > (((key3.gameObject.GetComponent<RectTransform>().anchoredPosition.x + 5.45f) * 0.5 / 5.45) - 0.073f) && key3Cover.gameObject.activeSelf)
                            {
                                key3Cover.GetComponent<Image>().color = new Vector4(key3Cover.GetComponent<Image>().color.r, key3Cover.GetComponent<Image>().color.g, key3Cover.GetComponent<Image>().color.b, 1.0f - 20.0f * (player.GetChild(0).transform.GetChild(7).transform.GetChild(1).GetComponent<Image>().fillAmount - (((key3.gameObject.GetComponent<RectTransform>().anchoredPosition.x + 5.45f) * 0.5f / 5.45f) - 0.073f)));
                                if (player.GetChild(0).transform.GetChild(7).transform.GetChild(1).GetComponent<Image>().fillAmount > (((key3.gameObject.GetComponent<RectTransform>().anchoredPosition.x + 5.45f) * 0.5 / 5.45) - 0.023f))
                                {
                                    key3Cover.gameObject.SetActive(false);
                                    key3.GetComponent<Image>().color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
                                }
                            }
                            else if (player.GetChild(0).transform.GetChild(7).transform.GetChild(1).GetComponent<Image>().fillAmount > (((key3.gameObject.GetComponent<RectTransform>().anchoredPosition.x + 5.45f) * 0.5 / 5.45) - 0.023f) && player.GetChild(0).transform.GetChild(7).transform.GetChild(1).GetComponent<Image>().fillAmount < (((key3.gameObject.GetComponent<RectTransform>().anchoredPosition.x + 5.45f) * 0.5 / 5.45) + 0.023f))
                            {
                                if (key3Input == 0)
                                {
                                    if (Input.GetKeyDown(KeyCode.UpArrow))
                                    {
                                        key3.GetComponent<Image>().color = new Vector4(0.0f, 0.7924528f, 0.1492666f, 1.0f);
                                        key3Input = 4;
                                    }
                                    else if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.DownArrow)) failMusic = true;
                                }
                                else if (key3Input == 1)
                                {
                                    if (Input.GetKeyDown(KeyCode.LeftArrow))
                                    {
                                        key3.GetComponent<Image>().color = new Vector4(0.0f, 0.7924528f, 0.1492666f, 1.0f);
                                        key3Input = 4;
                                    }
                                    else if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.DownArrow)) failMusic = true;
                                }
                                else if (key3Input == 2)
                                {
                                    if (Input.GetKeyDown(KeyCode.RightArrow))
                                    {
                                        key3.GetComponent<Image>().color = new Vector4(0.0f, 0.7924528f, 0.1492666f, 1.0f);
                                        key3Input = 4;
                                    }
                                    else if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow)) failMusic = true;
                                }
                                else if (key3Input == 3)
                                {
                                    if (Input.GetKeyDown(KeyCode.DownArrow))
                                    {
                                        key3.GetComponent<Image>().color = new Vector4(0.0f, 0.7924528f, 0.1492666f, 1.0f);
                                        key3Input = 4;
                                    }
                                    else if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.UpArrow)) failMusic = true;
                                }
                                else if (key3Input == 4)
                                {
                                    if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow)) failMusic = true;
                                }
                            }
                            else if (player.GetChild(0).transform.GetChild(7).transform.GetChild(1).GetComponent<Image>().fillAmount > (((key3.gameObject.GetComponent<RectTransform>().anchoredPosition.x + 5.45f) * 0.5 / 5.45) + 0.023f) && key3Input != 4)
                            {
                                failMusic = true;
                            }
                            else if (player.GetChild(0).transform.GetChild(7).transform.GetChild(1).GetComponent<Image>().fillAmount > (((key3.gameObject.GetComponent<RectTransform>().anchoredPosition.x + 5.45f) * 0.5 / 5.45) + 0.023f) && player.GetChild(0).transform.GetChild(7).transform.GetChild(1).GetComponent<Image>().fillAmount < (((key4.gameObject.GetComponent<RectTransform>().anchoredPosition.x + 5.45f) * 0.5 / 5.45) - 0.023f))
                            {
                                if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow)) failMusic = true;
                            }
                            if (player.GetChild(0).transform.GetChild(7).transform.GetChild(1).GetComponent<Image>().fillAmount > (((key4.gameObject.GetComponent<RectTransform>().anchoredPosition.x + 5.45f) * 0.5 / 5.45) - 0.073f) && key4Cover.gameObject.activeSelf)
                            {
                                key4Cover.GetComponent<Image>().color = new Vector4(key4Cover.GetComponent<Image>().color.r, key4Cover.GetComponent<Image>().color.g, key4Cover.GetComponent<Image>().color.b, 1.0f - 20.0f * (player.GetChild(0).transform.GetChild(7).transform.GetChild(1).GetComponent<Image>().fillAmount - (((key4.gameObject.GetComponent<RectTransform>().anchoredPosition.x + 5.45f) * 0.5f / 5.45f) - 0.073f)));
                                if (player.GetChild(0).transform.GetChild(7).transform.GetChild(1).GetComponent<Image>().fillAmount > (((key4.gameObject.GetComponent<RectTransform>().anchoredPosition.x + 5.45f) * 0.5 / 5.45) - 0.023f))
                                {
                                    key4Cover.gameObject.SetActive(false);
                                    key4.GetComponent<Image>().color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
                                }
                            }
                            else if (player.GetChild(0).transform.GetChild(7).transform.GetChild(1).GetComponent<Image>().fillAmount > (((key4.gameObject.GetComponent<RectTransform>().anchoredPosition.x + 5.45f) * 0.5 / 5.45) - 0.023f) && player.GetChild(0).transform.GetChild(7).transform.GetChild(1).GetComponent<Image>().fillAmount < (((key4.gameObject.GetComponent<RectTransform>().anchoredPosition.x + 5.45f) * 0.5 / 5.45) + 0.023f))
                            {
                                if (key4Input == 0)
                                {
                                    if (Input.GetKeyDown(KeyCode.UpArrow))
                                    {
                                        key4.GetComponent<Image>().color = new Vector4(0.0f, 0.7924528f, 0.1492666f, 1.0f);
                                        key4Input = 4;
                                    }
                                    else if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.DownArrow)) failMusic = true;
                                }
                                else if (key4Input == 1)
                                {
                                    if (Input.GetKeyDown(KeyCode.LeftArrow))
                                    {
                                        key4.GetComponent<Image>().color = new Vector4(0.0f, 0.7924528f, 0.1492666f, 1.0f);
                                        key4Input = 4;
                                    }
                                    else if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.DownArrow)) failMusic = true;
                                }
                                else if (key4Input == 2)
                                {
                                    if (Input.GetKeyDown(KeyCode.RightArrow))
                                    {
                                        key4.GetComponent<Image>().color = new Vector4(0.0f, 0.7924528f, 0.1492666f, 1.0f);
                                        key4Input = 4;
                                    }
                                    else if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow)) failMusic = true;
                                }
                                else if (key4Input == 3)
                                {
                                    if (Input.GetKeyDown(KeyCode.DownArrow))
                                    {
                                        key4.GetComponent<Image>().color = new Vector4(0.0f, 0.7924528f, 0.1492666f, 1.0f);
                                        key4Input = 4;
                                    }
                                    else if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.UpArrow)) failMusic = true;
                                }
                                else if (key4Input == 4)
                                {
                                    if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow)) failMusic = true;
                                }
                            }
                            if (soulMusic > 1)
                            {
                                if (player.GetChild(0).transform.GetChild(7).transform.GetChild(1).GetComponent<Image>().fillAmount > (((key4.gameObject.GetComponent<RectTransform>().anchoredPosition.x + 5.45f) * 0.5 / 5.45) + 0.023f) && player.GetChild(0).transform.GetChild(7).transform.GetChild(1).GetComponent<Image>().fillAmount < (((key5.gameObject.GetComponent<RectTransform>().anchoredPosition.x + 5.45f) * 0.5 / 5.45) - 0.023f))
                                {
                                    if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow)) failMusic = true;
                                }
                                if (player.GetChild(0).transform.GetChild(7).transform.GetChild(1).GetComponent<Image>().fillAmount > (((key5.gameObject.GetComponent<RectTransform>().anchoredPosition.x + 5.45f) * 0.5 / 5.45) - 0.073f) && key5Cover.gameObject.activeSelf)
                                {
                                    key5Cover.GetComponent<Image>().color = new Vector4(key5Cover.GetComponent<Image>().color.r, key5Cover.GetComponent<Image>().color.g, key5Cover.GetComponent<Image>().color.b, 1.0f - 20.0f * (player.GetChild(0).transform.GetChild(7).transform.GetChild(1).GetComponent<Image>().fillAmount - (((key5.gameObject.GetComponent<RectTransform>().anchoredPosition.x + 5.45f) * 0.5f / 5.45f) - 0.073f)));
                                    if (player.GetChild(0).transform.GetChild(7).transform.GetChild(1).GetComponent<Image>().fillAmount > (((key5.gameObject.GetComponent<RectTransform>().anchoredPosition.x + 5.45f) * 0.5 / 5.45) - 0.023f))
                                    {
                                        key5Cover.gameObject.SetActive(false);
                                        key5.GetComponent<Image>().color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
                                    }
                                }
                                else if (player.GetChild(0).transform.GetChild(7).transform.GetChild(1).GetComponent<Image>().fillAmount > (((key5.gameObject.GetComponent<RectTransform>().anchoredPosition.x + 5.45f) * 0.5 / 5.45) - 0.023f) && player.GetChild(0).transform.GetChild(7).transform.GetChild(1).GetComponent<Image>().fillAmount < (((key5.gameObject.GetComponent<RectTransform>().anchoredPosition.x + 5.45f) * 0.5 / 5.45) + 0.023f))
                                {
                                    if (key5Input == 0)
                                    {
                                        if (Input.GetKeyDown(KeyCode.UpArrow))
                                        {
                                            key5.GetComponent<Image>().color = new Vector4(0.0f, 0.7924528f, 0.1492666f, 1.0f);
                                            key5Input = 4;
                                        }
                                        else if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.DownArrow)) failMusic = true;
                                    }
                                    else if (key5Input == 1)
                                    {
                                        if (Input.GetKeyDown(KeyCode.LeftArrow))
                                        {
                                            key5.GetComponent<Image>().color = new Vector4(0.0f, 0.7924528f, 0.1492666f, 1.0f);
                                            key5Input = 4;
                                        }
                                        else if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.DownArrow)) failMusic = true;
                                    }
                                    else if (key5Input == 2)
                                    {
                                        if (Input.GetKeyDown(KeyCode.RightArrow))
                                        {
                                            key5.GetComponent<Image>().color = new Vector4(0.0f, 0.7924528f, 0.1492666f, 1.0f);
                                            key5Input = 4;
                                        }
                                        else if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow)) failMusic = true;
                                    }
                                    else if (key5Input == 3)
                                    {
                                        if (Input.GetKeyDown(KeyCode.DownArrow))
                                        {
                                            key5.GetComponent<Image>().color = new Vector4(0.0f, 0.7924528f, 0.1492666f, 1.0f);
                                            key5Input = 4;
                                        }
                                        else if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.UpArrow)) failMusic = true;
                                    }
                                    else if (key5Input == 4)
                                    {
                                        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow)) failMusic = true;
                                    }
                                }
                                if (soulMusic > 2)
                                {
                                    if (player.GetChild(0).transform.GetChild(7).transform.GetChild(1).GetComponent<Image>().fillAmount > (((key5.gameObject.GetComponent<RectTransform>().anchoredPosition.x + 5.45f) * 0.5 / 5.45) + 0.023f) && player.GetChild(0).transform.GetChild(7).transform.GetChild(1).GetComponent<Image>().fillAmount < (((key6.gameObject.GetComponent<RectTransform>().anchoredPosition.x + 5.45f) * 0.5 / 5.45) - 0.023f))
                                    {
                                        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow)) failMusic = true;
                                    }
                                    if (player.GetChild(0).transform.GetChild(7).transform.GetChild(1).GetComponent<Image>().fillAmount > (((key6.gameObject.GetComponent<RectTransform>().anchoredPosition.x + 5.45f) * 0.5 / 5.45) - 0.073f) && key6Cover.gameObject.activeSelf)
                                    {
                                        key6Cover.GetComponent<Image>().color = new Vector4(key6Cover.GetComponent<Image>().color.r, key6Cover.GetComponent<Image>().color.g, key6Cover.GetComponent<Image>().color.b, 1.0f - 20.0f * (player.GetChild(0).transform.GetChild(7).transform.GetChild(1).GetComponent<Image>().fillAmount - (((key6.gameObject.GetComponent<RectTransform>().anchoredPosition.x + 5.45f) * 0.5f / 5.45f) - 0.073f)));
                                        if (player.GetChild(0).transform.GetChild(7).transform.GetChild(1).GetComponent<Image>().fillAmount > (((key6.gameObject.GetComponent<RectTransform>().anchoredPosition.x + 5.45f) * 0.5 / 5.45) - 0.023f))
                                        {
                                            key6Cover.gameObject.SetActive(false);
                                            key6.GetComponent<Image>().color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
                                        }
                                    }
                                    else if (player.GetChild(0).transform.GetChild(7).transform.GetChild(1).GetComponent<Image>().fillAmount > (((key6.gameObject.GetComponent<RectTransform>().anchoredPosition.x + 5.45f) * 0.5 / 5.45) - 0.023f) && player.GetChild(0).transform.GetChild(7).transform.GetChild(1).GetComponent<Image>().fillAmount < (((key6.gameObject.GetComponent<RectTransform>().anchoredPosition.x + 5.45f) * 0.5 / 5.45) + 0.023f))
                                    {
                                        if (key6Input == 0)
                                        {
                                            if (Input.GetKeyDown(KeyCode.UpArrow))
                                            {
                                                key6.GetComponent<Image>().color = new Vector4(0.0f, 0.7924528f, 0.1492666f, 1.0f);
                                                key6Input = 4;
                                            }
                                            else if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.DownArrow)) failMusic = true;
                                        }
                                        else if (key6Input == 1)
                                        {
                                            if (Input.GetKeyDown(KeyCode.LeftArrow))
                                            {
                                                key6.GetComponent<Image>().color = new Vector4(0.0f, 0.7924528f, 0.1492666f, 1.0f);
                                                key6Input = 4;
                                            }
                                            else if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.DownArrow)) failMusic = true;
                                        }
                                        else if (key6Input == 2)
                                        {
                                            if (Input.GetKeyDown(KeyCode.RightArrow))
                                            {
                                                key6.GetComponent<Image>().color = new Vector4(0.0f, 0.7924528f, 0.1492666f, 1.0f);
                                                key6Input = 4;
                                            }
                                            else if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow)) failMusic = true;
                                        }
                                        else if (key6Input == 3)
                                        {
                                            if (Input.GetKeyDown(KeyCode.DownArrow))
                                            {
                                                key6.GetComponent<Image>().color = new Vector4(0.0f, 0.7924528f, 0.1492666f, 1.0f);
                                                key6Input = 4;
                                            }
                                            else if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.UpArrow)) failMusic = true;
                                        }
                                        else if (key6Input == 4)
                                        {
                                            if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow)) failMusic = true;
                                        }
                                    }
                                    if (soulMusic > 3)
                                    {
                                        if (player.GetChild(0).transform.GetChild(7).transform.GetChild(1).GetComponent<Image>().fillAmount > (((key6.gameObject.GetComponent<RectTransform>().anchoredPosition.x + 5.45f) * 0.5 / 5.45) + 0.023f) && player.GetChild(0).transform.GetChild(7).transform.GetChild(1).GetComponent<Image>().fillAmount < (((key7.gameObject.GetComponent<RectTransform>().anchoredPosition.x + 5.45f) * 0.5 / 5.45) - 0.023f))
                                        {
                                            if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow)) failMusic = true;
                                        }
                                        if (player.GetChild(0).transform.GetChild(7).transform.GetChild(1).GetComponent<Image>().fillAmount > (((key7.gameObject.GetComponent<RectTransform>().anchoredPosition.x + 5.45f) * 0.5 / 5.45) - 0.073f) && key7Cover.gameObject.activeSelf)
                                        {
                                            key7Cover.GetComponent<Image>().color = new Vector4(key7Cover.GetComponent<Image>().color.r, key7Cover.GetComponent<Image>().color.g, key7Cover.GetComponent<Image>().color.b, 1.0f - 20.0f * (player.GetChild(0).transform.GetChild(7).transform.GetChild(1).GetComponent<Image>().fillAmount - (((key7.gameObject.GetComponent<RectTransform>().anchoredPosition.x + 5.45f) * 0.5f / 5.45f) - 0.073f)));
                                            if (player.GetChild(0).transform.GetChild(7).transform.GetChild(1).GetComponent<Image>().fillAmount > (((key7.gameObject.GetComponent<RectTransform>().anchoredPosition.x + 5.45f) * 0.5 / 5.45) - 0.023f))
                                            {
                                                key7Cover.gameObject.SetActive(false);
                                                key7.GetComponent<Image>().color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
                                            }
                                        }
                                        else if (player.GetChild(0).transform.GetChild(7).transform.GetChild(1).GetComponent<Image>().fillAmount > (((key7.gameObject.GetComponent<RectTransform>().anchoredPosition.x + 5.45f) * 0.5 / 5.45) - 0.023f) && player.GetChild(0).transform.GetChild(7).transform.GetChild(1).GetComponent<Image>().fillAmount < (((key7.gameObject.GetComponent<RectTransform>().anchoredPosition.x + 5.45f) * 0.5 / 5.45) + 0.023f))
                                        {
                                            if (key7Input == 0)
                                            {
                                                if (Input.GetKeyDown(KeyCode.UpArrow))
                                                {
                                                    key7.GetComponent<Image>().color = new Vector4(0.0f, 0.7924528f, 0.1492666f, 1.0f);
                                                    key7Input = 4;
                                                }
                                                else if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.DownArrow)) failMusic = true;
                                            }
                                            else if (key7Input == 1)
                                            {
                                                if (Input.GetKeyDown(KeyCode.LeftArrow))
                                                {
                                                    key7.GetComponent<Image>().color = new Vector4(0.0f, 0.7924528f, 0.1492666f, 1.0f);
                                                    key7Input = 4;
                                                }
                                                else if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.DownArrow)) failMusic = true;
                                            }
                                            else if (key7Input == 2)
                                            {
                                                if (Input.GetKeyDown(KeyCode.RightArrow))
                                                {
                                                    key7.GetComponent<Image>().color = new Vector4(0.0f, 0.7924528f, 0.1492666f, 1.0f);
                                                    key7Input = 4;
                                                }
                                                else if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow)) failMusic = true;
                                            }
                                            else if (key7Input == 3)
                                            {
                                                if (Input.GetKeyDown(KeyCode.DownArrow))
                                                {
                                                    key7.GetComponent<Image>().color = new Vector4(0.0f, 0.7924528f, 0.1492666f, 1.0f);
                                                    key7Input = 4;
                                                }
                                                else if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.UpArrow)) failMusic = true;
                                            }
                                            else if (key7Input == 4)
                                            {
                                                if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow)) failMusic = true;
                                            }
                                        }
                                        else if (player.GetChild(0).transform.GetChild(7).transform.GetChild(1).GetComponent<Image>().fillAmount > (((key7.gameObject.GetComponent<RectTransform>().anchoredPosition.x + 5.45f) * 0.5 / 5.45) + 0.023f) && player.GetChild(0).transform.GetChild(7).transform.GetChild(1).GetComponent<Image>().fillAmount != 1.0f)
                                        {
                                            if (key7Input != 4) failMusic = true;
                                            if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow)) failMusic = true;
                                        }
                                        else if (player.GetChild(0).transform.GetChild(7).transform.GetChild(1).GetComponent<Image>().fillAmount == 1.0f)
                                        {
                                            Destroy(key1.gameObject);
                                            Destroy(key2.gameObject);
                                            Destroy(key3.gameObject);
                                            Destroy(key4.gameObject);
                                            Destroy(key5.gameObject);
                                            Destroy(key6.gameObject);
                                            Destroy(key7.gameObject);
                                            Destroy(key1Cover.gameObject);
                                            Destroy(key2Cover.gameObject);
                                            Destroy(key3Cover.gameObject);
                                            Destroy(key4Cover.gameObject);
                                            Destroy(key5Cover.gameObject);
                                            Destroy(key6Cover.gameObject);
                                            Destroy(key7Cover.gameObject);
                                            soulMusicFilling = false;
                                        }
                                    }
                                    else if (player.GetChild(0).transform.GetChild(7).transform.GetChild(1).GetComponent<Image>().fillAmount > (((key6.gameObject.GetComponent<RectTransform>().anchoredPosition.x + 5.45f) * 0.5 / 5.45) + 0.023f) && player.GetChild(0).transform.GetChild(7).transform.GetChild(1).GetComponent<Image>().fillAmount != 1.0f)
                                    {
                                        if (key6Input != 4) failMusic = true;
                                        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow)) failMusic = true;
                                    }
                                    else if (player.GetChild(0).transform.GetChild(7).transform.GetChild(1).GetComponent<Image>().fillAmount == 1.0f)
                                    {
                                        Destroy(key1.gameObject);
                                        Destroy(key2.gameObject);
                                        Destroy(key3.gameObject);
                                        Destroy(key4.gameObject);
                                        Destroy(key5.gameObject);
                                        Destroy(key6.gameObject);
                                        Destroy(key1Cover.gameObject);
                                        Destroy(key2Cover.gameObject);
                                        Destroy(key3Cover.gameObject);
                                        Destroy(key4Cover.gameObject);
                                        Destroy(key5Cover.gameObject);
                                        Destroy(key6Cover.gameObject);
                                        soulMusicFilling = false;
                                    }
                                }
                                else if (player.GetChild(0).transform.GetChild(7).transform.GetChild(1).GetComponent<Image>().fillAmount > (((key5.gameObject.GetComponent<RectTransform>().anchoredPosition.x + 5.45f) * 0.5 / 5.45) + 0.023f) && player.GetChild(0).transform.GetChild(7).transform.GetChild(1).GetComponent<Image>().fillAmount != 1.0f)
                                {
                                    if (key5Input != 4) failMusic = true;
                                    if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow)) failMusic = true;
                                }
                                else if (player.GetChild(0).transform.GetChild(7).transform.GetChild(1).GetComponent<Image>().fillAmount == 1.0f)
                                {
                                    Destroy(key1.gameObject);
                                    Destroy(key2.gameObject);
                                    Destroy(key3.gameObject);
                                    Destroy(key4.gameObject);
                                    Destroy(key5.gameObject);
                                    Destroy(key1Cover.gameObject);
                                    Destroy(key2Cover.gameObject);
                                    Destroy(key3Cover.gameObject);
                                    Destroy(key4Cover.gameObject);
                                    Destroy(key5Cover.gameObject);
                                    soulMusicFilling = false;
                                }
                            }
                            else if (player.GetChild(0).transform.GetChild(7).transform.GetChild(1).GetComponent<Image>().fillAmount > (((key4.gameObject.GetComponent<RectTransform>().anchoredPosition.x + 5.45f) * 0.5 / 5.45) + 0.023f) && player.GetChild(0).transform.GetChild(7).transform.GetChild(1).GetComponent<Image>().fillAmount != 1.0f)
                            {
                                if (key4Input != 4) failMusic = true;
                                if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow)) failMusic = true;
                            }
                            else if (player.GetChild(0).transform.GetChild(7).transform.GetChild(1).GetComponent<Image>().fillAmount == 1.0f)
                            {
                                Destroy(key1.gameObject);
                                Destroy(key2.gameObject);
                                Destroy(key3.gameObject);
                                Destroy(key4.gameObject);
                                Destroy(key1Cover.gameObject);
                                Destroy(key2Cover.gameObject);
                                Destroy(key3Cover.gameObject);
                                Destroy(key4Cover.gameObject);
                                soulMusicFilling = false;
                            }
                        }
                        else if (player.GetChild(0).transform.GetChild(7).transform.GetChild(1).GetComponent<Image>().fillAmount == 0.0f)
                        {
                            soulMusic += 1;
                            StartSoulMusicAttack(soulMusic);
                            soulMusicFilling = true;
                        }
                    }
                    else if (failMusic)
                    {
                        actionInstructions.SetActive(false);
                        failMusic = false;
                        if (soulMusic >= 1)
                        {
                            Destroy(key1.gameObject);
                            Destroy(key2.gameObject);
                            Destroy(key3.gameObject);
                            Destroy(key4.gameObject);
                            Destroy(key1Cover.gameObject);
                            Destroy(key2Cover.gameObject);
                            Destroy(key3Cover.gameObject);
                            Destroy(key4Cover.gameObject);
                        }
                        if (soulMusic >= 2)
                        {
                            Destroy(key5.gameObject);
                            Destroy(key5Cover.gameObject);
                        }
                        if (soulMusic >= 3)
                        {
                            Destroy(key6.gameObject);
                            Destroy(key6Cover.gameObject);
                        }
                        if (soulMusic >= 4)
                        {
                            Destroy(key7.gameObject);
                            Destroy(key7Cover.gameObject);
                        }
                        player.GetChild(0).transform.GetChild(7).transform.GetChild(1).GetComponent<Image>().fillAmount = 0.0f;
                        player.GetComponent<PlayerTeamScript>().EndSoulAttack(soulMusic);
                        soulMusic = 0;
                    }
                    else if (soulRegen)
                    {
                        if (Input.GetKey(KeyCode.UpArrow)) soulRegenMovUp = true;
                        if (Input.GetKey(KeyCode.LeftArrow)) soulRegenMovLeft = true;
                        if (Input.GetKey(KeyCode.RightArrow)) soulRegenMovRight = true;
                        if (Input.GetKey(KeyCode.DownArrow)) soulRegenMovDown = true;
                        if (Input.GetKeyUp(KeyCode.UpArrow)) soulRegenMovUp = false;
                        if (Input.GetKeyUp(KeyCode.LeftArrow)) soulRegenMovLeft = false;
                        if (Input.GetKeyUp(KeyCode.RightArrow)) soulRegenMovRight = false;
                        if (Input.GetKeyUp(KeyCode.DownArrow)) soulRegenMovDown = false;
                    }
                    else if (soulLightning)
                    {
                        if (Input.GetKeyDown(KeyCode.X)) Instantiate(lightningPrefab, new Vector3(yellowSoul.position.x, 1.5f, enemy1.position.z), Quaternion.identity);
                    }
                    else if (soulLifesteal)
                    {
                        if (Input.GetKey(KeyCode.UpArrow)) jarMovUp = true;
                        if (Input.GetKey(KeyCode.LeftArrow)) jarMovLeft = true;
                        if (Input.GetKey(KeyCode.RightArrow)) jarMovRight = true;
                        if (Input.GetKey(KeyCode.DownArrow)) jarMovDown = true;
                        if (Input.GetKeyUp(KeyCode.UpArrow)) jarMovUp = false;
                        if (Input.GetKeyUp(KeyCode.LeftArrow)) jarMovLeft = false;
                        if (Input.GetKeyUp(KeyCode.RightArrow)) jarMovRight = false;
                        if (Input.GetKeyUp(KeyCode.DownArrow)) jarMovDown = false;
                    }
                    else if (soulDisappear)
                    {
                        if (Input.GetKey(KeyCode.UpArrow)) blueSoulMovUp = true;
                        if (Input.GetKey(KeyCode.LeftArrow)) blueSoulMovLeft = true;
                        if (Input.GetKey(KeyCode.RightArrow)) blueSoulMovRight = true;
                        if (Input.GetKey(KeyCode.DownArrow)) blueSoulMovDown = true;
                        if (Input.GetKeyUp(KeyCode.UpArrow)) blueSoulMovUp = false;
                        if (Input.GetKeyUp(KeyCode.LeftArrow)) blueSoulMovLeft = false;
                        if (Input.GetKeyUp(KeyCode.RightArrow)) blueSoulMovRight = false;
                        if (Input.GetKeyUp(KeyCode.DownArrow)) blueSoulMovDown = false;
                    }
                    else if (soulLightUp)
                    {
                        if (fogScaled)
                        {
                            if (Input.GetKeyDown(KeyCode.X)) fog.GetComponent<RectTransform>().localScale = new Vector3(fog.GetComponent<RectTransform>().localScale.x + 0.075f, fog.GetComponent<RectTransform>().localScale.y + 0.075f, fog.GetComponent<RectTransform>().localScale.z);
                            if (Input.GetKey(KeyCode.UpArrow)) magentaSoulMovUp = true;
                            if (Input.GetKey(KeyCode.LeftArrow)) magentaSoulMovLeft = true;
                            if (Input.GetKey(KeyCode.RightArrow)) magentaSoulMovRight = true;
                            if (Input.GetKey(KeyCode.DownArrow)) magentaSoulMovDown = true;
                            if (Input.GetKeyUp(KeyCode.UpArrow)) magentaSoulMovUp = false;
                            if (Input.GetKeyUp(KeyCode.LeftArrow)) magentaSoulMovLeft = false;
                            if (Input.GetKeyUp(KeyCode.RightArrow)) magentaSoulMovRight = false;
                            if (Input.GetKeyUp(KeyCode.DownArrow)) magentaSoulMovDown = false;
                        }
                    }
                }
                //We end the players turn when the player ends the shuriken animation
                else if (shurikenHit)
                {
                    shurikenHit = false;
                    EndPlayerTurn(1);
                }
                else if (fleeing && (Time.fixedTime - fleeTime) < 10.0f)
                {
                    if (Input.GetKeyDown(KeyCode.X))
                    {
                        if (fleeAction.transform.GetChild(1).GetComponent<Image>().fillAmount != 1.0f) fleeAction.transform.GetChild(1).GetComponent<Image>().fillAmount += 0.02f;
                    }
                }
            }
            else if (companionTurn)
            {
                if (companionChoosingAction)
                {
                    if (!companion.GetChild(0).transform.GetChild(0).GetComponent<Animator>().GetBool("MenuOpened"))
                    {
                        //We use left and right arrows to move in the action menu
                        if (Input.GetKeyDown(KeyCode.LeftArrow))
                        {
                            companion.GetChild(0).transform.GetChild(0).GetComponent<Animator>().SetTrigger("Left");
                        }
                        else if (Input.GetKeyDown(KeyCode.RightArrow))
                        {
                            companion.GetChild(0).transform.GetChild(0).GetComponent<Animator>().SetTrigger("Right");
                        }
                        //We press space to select the action we want to perform
                        if (selectingAction == 0 && Input.GetKeyDown(KeyCode.Space))
                        {
                            changePosAction.SetActive(false);
                            CreateMenu();
                            actionInstructions.SetActive(true);
                            companion.GetChild(0).transform.GetChild(0).GetComponent<Animator>().SetBool("MenuOpened", true);
                        }
                        else if (selectingAction == 1 && Input.GetKeyDown(KeyCode.Space))
                        {
                            changePosAction.SetActive(false);
                            CreateMenu();
                            actionInstructions.SetActive(true);
                            companion.GetChild(0).transform.GetChild(0).GetComponent<Animator>().SetBool("MenuOpened", true);
                        }
                        else if (selectingAction == 2 && Input.GetKeyDown(KeyCode.Space))
                        {
                            changePosAction.SetActive(false);
                            CreateMenu();
                            actionInstructions.SetActive(true);
                            companion.GetChild(0).transform.GetChild(0).GetComponent<Animator>().SetBool("MenuOpened", true);
                        }

                        if (!playerTurnCompleted && Input.GetKeyDown(KeyCode.Z)) StartChangePosition(2);
                    }
                    else
                    {
                        if (selectingAction == 0)
                        {
                            usingStyle = menuSelectionPos;
                            if (usingStyle == 0) actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Use your sword to hit an enemy twice.";
                            else if (usingStyle == 1) actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Look at the enemy to see their weak points.";
                            else if (usingStyle == 2) actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Hit an enemy as many times as you can with your sword.";
                            else if (usingStyle == 3) actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Use your dragon slayer bow to shoot an arrow to all the grounded enemies.";
                            else if (usingStyle == 4) actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Shoot five arrows that will hit the first enemy they find in their way.";
                            if ((menuSelectionPos < PlayerPrefs.GetInt("AdventurerLvl") + 1) && Input.GetKeyDown(KeyCode.DownArrow))
                            {
                                companion.GetChild(0).transform.GetChild(0).GetComponent<Animator>().SetTrigger("Down");
                            }
                            else if (menuSelectionPos > 0 && Input.GetKeyDown(KeyCode.UpArrow))
                            {
                                companion.GetChild(0).transform.GetChild(0).GetComponent<Animator>().SetTrigger("Up");
                            }
                            if (Input.GetKeyDown(KeyCode.Space) && menuCanUse[menuSelectionPos])
                            {
                                companion.GetChild(0).transform.GetChild(0).GetComponent<Animator>().SetBool("MenuHide", true);
                                companionChoosingAction = false;
                                actionInstructions.GetComponent<Image>().color = new Vector4(actionInstructions.GetComponent<Image>().color.r, actionInstructions.GetComponent<Image>().color.g, actionInstructions.GetComponent<Image>().color.b, 0.5f);
                                actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = new Vector4(actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color.r, actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color.g, actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color.b, 0.5f);
                                if (usingStyle == 0) actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Press <sprite=336> just before hitting an enemy.";
                                else if (usingStyle == 1) actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Press <sprite=336> when the <sprite=361> arrives to the <sprite=362>.";
                                else if (usingStyle == 2) actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Press <sprite=336> just before hitting an enemy until you fail to press it in time.";
                                else if (usingStyle == 3) actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Press <sprite=336> until <sprite=360> lights up.";
                                else if (usingStyle == 4) actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Press <sprite=336> when the adventurer aims to an objective.";
                                attackType = 0;
                                selectingEnemyCompanion = true;
                                enemyName.SetActive(true);
                                if (usingStyle < 3) SelectFirstEnemy();
                                else if (usingStyle == 3) SelectGroundEnemies();
                                else SelectAllEnemies();
                            }
                        }
                        else if (selectingAction == 1)
                        {
                            if (items[menuSelectionPos + scroll] == 1) actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Eat this apple to restore 5 HP";
                            else if (items[menuSelectionPos + scroll] == 2) actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Drink this potion to restore 5 LP";
                            if (((menuSelectionPos + scroll) < (itemSize() - 1)) && Input.GetKeyDown(KeyCode.DownArrow))
                            {
                                if (menuSelectionPos < 5) companion.GetChild(0).transform.GetChild(0).GetComponent<Animator>().SetTrigger("Down");
                                if (menuSelectionPos == 5)
                                {
                                    scroll += 1;
                                    CreateMenu();
                                }
                            }
                            else if (menuSelectionPos >= 0 && Input.GetKeyDown(KeyCode.UpArrow))
                            {
                                if (menuSelectionPos > 0) companion.GetChild(0).transform.GetChild(0).GetComponent<Animator>().SetTrigger("Up");
                                if (menuSelectionPos == 0 && scroll > 0)
                                {
                                    scroll -= 1;
                                    CreateMenu();
                                }
                            }
                            if (Input.GetKeyDown(KeyCode.Space) && menuCanUse[menuSelectionPos])
                            {
                                companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(7).GetComponent<Image>().color = new Vector4(companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(7).GetComponent<Image>().color.r, companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(7).GetComponent<Image>().color.g, companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(7).GetComponent<Image>().color.b, 0.0f);
                                companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(8).GetComponent<Image>().color = new Vector4(companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(8).GetComponent<Image>().color.r, companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(8).GetComponent<Image>().color.g, companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(8).GetComponent<Image>().color.b, 0.0f);
                                enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = "Adventurer";
                                enemyName.transform.GetChild(1).gameObject.SetActive(false);
                                enemyName.transform.GetChild(2).gameObject.SetActive(false);
                                enemyName.transform.GetChild(3).gameObject.SetActive(false);
                                enemyName.transform.GetChild(4).gameObject.SetActive(false);
                                companion.GetChild(0).transform.GetChild(1).gameObject.SetActive(true);
                                companion.GetChild(0).transform.GetChild(0).GetComponent<Animator>().SetBool("MenuHide", true);
                                companionChoosingAction = false;
                                if (items[menuSelectionPos] == 1) actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Select who you want to eat the apple";
                                else if (items[menuSelectionPos] == 2) actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Select who you want to drink the potion";
                                selectingCompanion = true;
                                enemyName.SetActive(true);
                            }
                        }
                        else if (selectingAction == 2)
                        {
                            if (menuSelectionPos == 0) actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Change your partner with another from your party.";
                            else if (menuSelectionPos == 1) actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Gain +1 of defense on the next enemy turn.";
                            else if (menuSelectionPos == 2) actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Try to flee the battle.";
                            if ((menuSelectionPos < 2) && Input.GetKeyDown(KeyCode.DownArrow))
                            {
                                companion.GetChild(0).transform.GetChild(0).GetComponent<Animator>().SetTrigger("Down");
                            }
                            else if (menuSelectionPos > 0 && Input.GetKeyDown(KeyCode.UpArrow))
                            {
                                companion.GetChild(0).transform.GetChild(0).GetComponent<Animator>().SetTrigger("Up");
                            }
                            if (Input.GetKeyDown(KeyCode.Space) && menuCanUse[menuSelectionPos])
                            {
                                if (menuSelectionPos == 1)
                                {
                                    defenseCompanion = 1;
                                    companion.GetChild(0).transform.GetChild(0).GetComponent<Animator>().SetBool("Active", false);
                                    companion.GetChild(0).transform.GetChild(0).GetComponent<Animator>().SetBool("MenuHide", false);
                                    companion.GetChild(0).transform.GetChild(0).GetComponent<Animator>().SetBool("MenuOpened", false);
                                    actionInstructions.SetActive(false);
                                    EndPlayerTurn(2);
                                }
                                else if (menuSelectionPos == 2)
                                {
                                    fleeAction.transform.GetChild(2).GetComponent<RectTransform>().anchoredPosition = new Vector2(Random.Range(-1.425f, 1.425f), fleeAction.transform.GetChild(2).GetComponent<RectTransform>().anchoredPosition.y);
                                    fleeRight = Random.Range(0.0f, 100.0f) > 50.0f;
                                    companion.GetChild(0).transform.GetChild(0).GetComponent<Animator>().SetBool("Active", false);
                                    companion.GetChild(0).transform.GetChild(0).GetComponent<Animator>().SetBool("MenuOpened", false);
                                    actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Press <sprite=336> repeatedly to fill the bar.";
                                    companion.GetComponent<Animator>().SetFloat("RunSpeed", -0.5f);
                                    companion.GetComponent<Animator>().SetFloat("Speed", 1.5f);
                                    fleeTime = Time.fixedTime;
                                    player.GetComponent<Animator>().SetFloat("Speed", -0.5f);
                                    player.GetComponent<Animator>().SetFloat("attackSpeed", 2.0f);
                                    fleeAction.SetActive(true);
                                    companionChoosingAction = false;
                                    fleeing = true;
                                }
                            }
                        }
                        if (Input.GetKeyDown(KeyCode.Q))
                        {
                            changePosAction.SetActive(!playerTurnCompleted);
                            actionInstructions.SetActive(false);
                            companion.GetChild(0).transform.GetChild(0).GetComponent<Animator>().SetBool("MenuOpened", false);
                            companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(7).GetComponent<Image>().color = new Vector4(companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(7).GetComponent<Image>().color.r, companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(7).GetComponent<Image>().color.g, companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(7).GetComponent<Image>().color.b, 0.0f);
                            companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(8).GetComponent<Image>().color = new Vector4(companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(8).GetComponent<Image>().color.r, companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(8).GetComponent<Image>().color.g, companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(8).GetComponent<Image>().color.b, 0.0f);
                        }
                    }
                }
                else if (selectingCompanion)
                {
                    if (Input.GetKeyDown(KeyCode.Q))
                    {
                        CreateMenu();
                        enemyName.SetActive(false);
                        companionChoosingAction = true;
                        selectingCompanion = false;
                        companion.GetChild(0).transform.GetChild(0).GetComponent<Animator>().SetBool("MenuHide", false);
                        companion.GetChild(0).transform.GetChild(1).gameObject.SetActive(false);
                        player.GetChild(0).transform.GetChild(5).gameObject.SetActive(false);
                    }
                    if (player.GetChild(0).transform.GetChild(5).gameObject.activeSelf)
                    {
                        if (firstPosPlayer)
                        {
                            if (Input.GetKeyDown(KeyCode.LeftArrow))
                            {
                                player.GetChild(0).transform.GetChild(5).gameObject.SetActive(false);
                                companion.GetChild(0).transform.GetChild(1).gameObject.SetActive(true);
                                enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = "Adventurer";
                            }
                        }
                        else
                        {
                            if (Input.GetKeyDown(KeyCode.RightArrow))
                            {
                                player.GetChild(0).transform.GetChild(5).gameObject.SetActive(false);
                                companion.GetChild(0).transform.GetChild(1).gameObject.SetActive(true);
                                enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = "Adventurer";
                            }
                        }
                        if (Input.GetKeyDown(KeyCode.Space))
                        {
                            companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(7).gameObject.SetActive(false);
                            companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(8).gameObject.SetActive(false);
                            player.GetChild(0).transform.GetChild(5).gameObject.SetActive(false);
                            if (items[menuSelectionPos + scroll] == 1) player.GetComponent<PlayerTeamScript>().Heal(5, false, true, false, false);
                            else if (items[menuSelectionPos + scroll] == 2) player.GetComponent<PlayerTeamScript>().IncreaseLight(5, false, false, false);
                            DeleteItem(menuSelectionPos + scroll);
                            scroll = 0;
                            actionInstructions.SetActive(false);
                            companion.GetChild(0).transform.GetChild(0).GetComponent<Animator>().SetBool("Active", false);
                            companion.GetChild(0).transform.GetChild(0).GetComponent<Animator>().SetBool("MenuHide", false);
                            companion.GetChild(0).transform.GetChild(0).GetComponent<Animator>().SetBool("MenuOpened", false);
                            enemyName.SetActive(false);
                            selectingCompanion = false;
                        }
                    }
                    else if (companion.GetChild(0).transform.GetChild(1).gameObject.activeSelf)
                    {
                        if (firstPosPlayer)
                        {
                            if (Input.GetKeyDown(KeyCode.RightArrow))
                            {
                                player.GetChild(0).transform.GetChild(5).gameObject.SetActive(true);
                                companion.GetChild(0).transform.GetChild(1).gameObject.SetActive(false);
                                enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = "Player";
                            }
                        }
                        else
                        {
                            if (Input.GetKeyDown(KeyCode.LeftArrow))
                            {
                                player.GetChild(0).transform.GetChild(5).gameObject.SetActive(true);
                                companion.GetChild(0).transform.GetChild(1).gameObject.SetActive(false);
                                enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = "Player";
                            }
                        }
                        if (Input.GetKeyDown(KeyCode.Space))
                        {
                            companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(7).gameObject.SetActive(false);
                            companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(8).gameObject.SetActive(false);
                            companion.GetChild(0).transform.GetChild(1).gameObject.SetActive(false);
                            if (items[menuSelectionPos + scroll] == 1) companion.GetComponent<PlayerTeamScript>().Heal(5, false, true, false, false);
                            else if (items[menuSelectionPos + scroll] == 2) player.GetComponent<PlayerTeamScript>().IncreaseLight(5, false, false, false);
                            DeleteItem(menuSelectionPos + scroll);
                            scroll = 0;
                            actionInstructions.SetActive(false);
                            companion.GetChild(0).transform.GetChild(0).GetComponent<Animator>().SetBool("Active", false);
                            companion.GetChild(0).transform.GetChild(0).GetComponent<Animator>().SetBool("MenuHide", false);
                            companion.GetChild(0).transform.GetChild(0).GetComponent<Animator>().SetBool("MenuOpened", false);
                            enemyName.SetActive(false);
                            selectingCompanion = false;
                        }
                    }

                }
                else if (selectingEnemyCompanion)
                {
                    //Press Q to return to start fase
                    if (Input.GetKeyDown(KeyCode.Q))
                    {
                        enemyName.SetActive(false);
                        companionChoosingAction = true;
                        selectingEnemyCompanion = false;
                        actionInstructions.GetComponent<Image>().color = new Vector4(actionInstructions.GetComponent<Image>().color.r, actionInstructions.GetComponent<Image>().color.g, actionInstructions.GetComponent<Image>().color.b, 1.0f);
                        actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = new Vector4(actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color.r, actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color.g, actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color.b, 1.0f);
                        companion.GetChild(0).transform.GetChild(0).GetComponent<Animator>().SetBool("MenuHide", false);
                        if (enemyNumber < 2) enemy1.GetChild(0).transform.GetChild(0).gameObject.SetActive(false);
                        else if (enemyNumber < 3)
                        {
                            enemy1.GetChild(0).transform.GetChild(0).gameObject.SetActive(false);
                            enemy2.GetChild(0).transform.GetChild(0).gameObject.SetActive(false);
                        }
                        else if (enemyNumber < 4)
                        {
                            enemy1.GetChild(0).transform.GetChild(0).gameObject.SetActive(false);
                            enemy2.GetChild(0).transform.GetChild(0).gameObject.SetActive(false);
                            enemy3.GetChild(0).transform.GetChild(0).gameObject.SetActive(false);
                        }
                        else if (enemyNumber < 5)
                        {
                            enemy1.GetChild(0).transform.GetChild(0).gameObject.SetActive(false);
                            enemy2.GetChild(0).transform.GetChild(0).gameObject.SetActive(false);
                            enemy3.GetChild(0).transform.GetChild(0).gameObject.SetActive(false);
                            enemy4.GetChild(0).transform.GetChild(0).gameObject.SetActive(false);
                        }
                    }
                    //When we can select an enemy
                    if (canSelect)
                    {
                        //When we have 2 or more enemies we decide which enemy to attack using the arrows and we select it using space and the attack starts
                        if (enemyNumber > 1)
                        {
                            if (enemy1.GetChild(0).transform.GetChild(0).gameObject.activeSelf)
                            {
                                if (Input.GetKeyDown(KeyCode.RightArrow))
                                {
                                    if (enemy2.GetComponent<EnemyTeamScript>().IsAlive() && ((usingStyle != 1 && companion.GetComponent<PlayerTeamScript>().GetPlayerType()==1 && enemy2.GetComponent<EnemyTeamScript>().IsGrounded()) || (usingStyle == 1 && companion.GetComponent<PlayerTeamScript>().GetPlayerType() == 1) || companion.GetComponent<PlayerTeamScript>().GetPlayerType() != 1))
                                    {
                                        enemy1.GetChild(0).transform.GetChild(0).gameObject.SetActive(false);
                                        enemy2.GetChild(0).transform.GetChild(0).gameObject.SetActive(true);
                                        if (enemy2.GetComponent<EnemyTeamScript>().enemyType == 0)
                                        {
                                            enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = "Bandit";
                                        }
                                        else if (enemy2.GetComponent<EnemyTeamScript>().enemyType == 1)
                                        {
                                            enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = "Wizard";
                                        }
                                    }
                                    else if (enemyNumber > 2 && enemy3.GetComponent<EnemyTeamScript>().IsAlive() && ((usingStyle != 1 && companion.GetComponent<PlayerTeamScript>().GetPlayerType() == 1 && enemy3.GetComponent<EnemyTeamScript>().IsGrounded()) || (usingStyle == 1 && companion.GetComponent<PlayerTeamScript>().GetPlayerType() == 1) || companion.GetComponent<PlayerTeamScript>().GetPlayerType() != 1))
                                    {
                                        enemy1.GetChild(0).transform.GetChild(0).gameObject.SetActive(false);
                                        enemy3.GetChild(0).transform.GetChild(0).gameObject.SetActive(true);
                                        if (enemy3.GetComponent<EnemyTeamScript>().enemyType == 0)
                                        {
                                            enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = "Bandit";
                                        }
                                        else if (enemy3.GetComponent<EnemyTeamScript>().enemyType == 1)
                                        {
                                            enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = "Wizard";
                                        }
                                    }
                                    else if (enemyNumber > 3 && enemy4.GetComponent<EnemyTeamScript>().IsAlive() && ((usingStyle != 1 && companion.GetComponent<PlayerTeamScript>().GetPlayerType() == 1 && enemy4.GetComponent<EnemyTeamScript>().IsGrounded()) || (usingStyle == 1 && companion.GetComponent<PlayerTeamScript>().GetPlayerType() == 1) || companion.GetComponent<PlayerTeamScript>().GetPlayerType() != 1))
                                    {
                                        enemy1.GetChild(0).transform.GetChild(0).gameObject.SetActive(false);
                                        enemy4.GetChild(0).transform.GetChild(0).gameObject.SetActive(true);
                                        if (enemy4.GetComponent<EnemyTeamScript>().enemyType == 0)
                                        {
                                            enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = "Bandit";
                                        }
                                        else if (enemy4.GetComponent<EnemyTeamScript>().enemyType == 1)
                                        {
                                            enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = "Wizard";
                                        }
                                    }
                                }
                                if (Input.GetKeyDown(KeyCode.Space))
                                {
                                    companion.GetChild(0).transform.GetChild(0).GetComponent<Animator>().SetBool("Active", false);
                                    companion.GetChild(0).transform.GetChild(0).GetComponent<Animator>().SetBool("MenuHide", false);
                                    enemy1.GetChild(0).transform.GetChild(0).gameObject.SetActive(false);
                                    companion.GetChild(0).transform.GetChild(0).GetComponent<Animator>().SetBool("MenuOpened", false);
                                    selectedEnemy = enemy1;
                                    selectingEnemyCompanion = false;
                                    enemyName.SetActive(false);
                                    actionInstructions.GetComponent<Image>().color = new Vector4(actionInstructions.GetComponent<Image>().color.r, actionInstructions.GetComponent<Image>().color.g, actionInstructions.GetComponent<Image>().color.b, 1.0f);
                                    actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = new Vector4(actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color.r, actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color.g, actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color.b, 1.0f);
                                    companion.GetComponent<PlayerTeamScript>().Attack(attackType, usingStyle, selectedEnemy);
                                }
                            }
                            else if (enemy2.GetChild(0).transform.GetChild(0).gameObject.activeSelf)
                            {
                                if (Input.GetKeyDown(KeyCode.LeftArrow) && enemy1.GetComponent<EnemyTeamScript>().IsAlive() && ((usingStyle != 1 && companion.GetComponent<PlayerTeamScript>().GetPlayerType() == 1 && enemy1.GetComponent<EnemyTeamScript>().IsGrounded()) || (usingStyle == 1 && companion.GetComponent<PlayerTeamScript>().GetPlayerType() == 1) || companion.GetComponent<PlayerTeamScript>().GetPlayerType() != 1))
                                {
                                    enemy1.GetChild(0).transform.GetChild(0).gameObject.SetActive(true);
                                    enemy2.GetChild(0).transform.GetChild(0).gameObject.SetActive(false);
                                    if (enemy1.GetComponent<EnemyTeamScript>().enemyType == 0)
                                    {
                                        enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = "Bandit";
                                    }
                                    else if (enemy1.GetComponent<EnemyTeamScript>().enemyType == 1)
                                    {
                                        enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = "Wizard";
                                    }
                                }
                                if (Input.GetKeyDown(KeyCode.RightArrow))
                                {
                                    if (enemyNumber > 2 && enemy3.GetComponent<EnemyTeamScript>().IsAlive() && ((usingStyle != 1 && companion.GetComponent<PlayerTeamScript>().GetPlayerType() == 1 && enemy3.GetComponent<EnemyTeamScript>().IsGrounded()) || (usingStyle == 1 && companion.GetComponent<PlayerTeamScript>().GetPlayerType() == 1) || companion.GetComponent<PlayerTeamScript>().GetPlayerType() != 1))
                                    {
                                        enemy2.GetChild(0).transform.GetChild(0).gameObject.SetActive(false);
                                        enemy3.GetChild(0).transform.GetChild(0).gameObject.SetActive(true);
                                        if (enemy3.GetComponent<EnemyTeamScript>().enemyType == 0)
                                        {
                                            enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = "Bandit";
                                        }
                                        else if (enemy3.GetComponent<EnemyTeamScript>().enemyType == 1)
                                        {
                                            enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = "Wizard";
                                        }
                                    }
                                    else if (enemyNumber > 3 && enemy4.GetComponent<EnemyTeamScript>().IsAlive() && ((usingStyle != 1 && companion.GetComponent<PlayerTeamScript>().GetPlayerType() == 1 && enemy4.GetComponent<EnemyTeamScript>().IsGrounded()) || (usingStyle == 1 && companion.GetComponent<PlayerTeamScript>().GetPlayerType() == 1) || companion.GetComponent<PlayerTeamScript>().GetPlayerType() != 1))
                                    {
                                        enemy2.GetChild(0).transform.GetChild(0).gameObject.SetActive(false);
                                        enemy4.GetChild(0).transform.GetChild(0).gameObject.SetActive(true);
                                        if (enemy4.GetComponent<EnemyTeamScript>().enemyType == 0)
                                        {
                                            enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = "Bandit";
                                        }
                                        else if (enemy4.GetComponent<EnemyTeamScript>().enemyType == 1)
                                        {
                                            enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = "Wizard";
                                        }
                                    }
                                }
                                if (Input.GetKeyDown(KeyCode.Space))
                                {
                                    companion.GetChild(0).transform.GetChild(0).GetComponent<Animator>().SetBool("Active", false);
                                    companion.GetChild(0).transform.GetChild(0).GetComponent<Animator>().SetBool("MenuHide", false);
                                    enemy2.GetChild(0).transform.GetChild(0).gameObject.SetActive(false);
                                    companion.GetChild(0).transform.GetChild(0).GetComponent<Animator>().SetBool("MenuOpened", false);
                                    selectedEnemy = enemy2;
                                    selectingEnemyCompanion = false;
                                    enemyName.SetActive(false);
                                    actionInstructions.GetComponent<Image>().color = new Vector4(actionInstructions.GetComponent<Image>().color.r, actionInstructions.GetComponent<Image>().color.g, actionInstructions.GetComponent<Image>().color.b, 1.0f);
                                    actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = new Vector4(actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color.r, actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color.g, actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color.b, 1.0f);
                                    companion.GetComponent<PlayerTeamScript>().Attack(attackType, usingStyle, selectedEnemy);
                                }
                            }
                            else if (enemy3.GetChild(0).transform.GetChild(0).gameObject.activeSelf)
                            {
                                if (Input.GetKeyDown(KeyCode.LeftArrow))
                                {
                                    if (enemy2.GetComponent<EnemyTeamScript>().IsAlive() && ((usingStyle != 1 && companion.GetComponent<PlayerTeamScript>().GetPlayerType() == 1 && enemy2.GetComponent<EnemyTeamScript>().IsGrounded()) || (usingStyle == 1 && companion.GetComponent<PlayerTeamScript>().GetPlayerType() == 1) || companion.GetComponent<PlayerTeamScript>().GetPlayerType() != 1))
                                    {
                                        enemy2.GetChild(0).transform.GetChild(0).gameObject.SetActive(true);
                                        enemy3.GetChild(0).transform.GetChild(0).gameObject.SetActive(false);
                                        if (enemy2.GetComponent<EnemyTeamScript>().enemyType == 0)
                                        {
                                            enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = "Bandit";
                                        }
                                        else if (enemy2.GetComponent<EnemyTeamScript>().enemyType == 1)
                                        {
                                            enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = "Wizard";
                                        }
                                    }
                                    else if (enemy1.GetComponent<EnemyTeamScript>().IsAlive() && ((usingStyle != 1 && companion.GetComponent<PlayerTeamScript>().GetPlayerType() == 1 && enemy1.GetComponent<EnemyTeamScript>().IsGrounded()) || (usingStyle == 1 && companion.GetComponent<PlayerTeamScript>().GetPlayerType() == 1) || companion.GetComponent<PlayerTeamScript>().GetPlayerType() != 1))
                                    {
                                        enemy1.GetChild(0).transform.GetChild(0).gameObject.SetActive(true);
                                        enemy3.GetChild(0).transform.GetChild(0).gameObject.SetActive(false);
                                        if (enemy1.GetComponent<EnemyTeamScript>().enemyType == 0)
                                        {
                                            enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = "Bandit";
                                        }
                                        else if (enemy1.GetComponent<EnemyTeamScript>().enemyType == 1)
                                        {
                                            enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = "Wizard";
                                        }
                                    }
                                }
                                if (Input.GetKeyDown(KeyCode.RightArrow))
                                {
                                    if (enemyNumber > 3 && enemy4.GetComponent<EnemyTeamScript>().IsAlive() && ((usingStyle != 1 && companion.GetComponent<PlayerTeamScript>().GetPlayerType() == 1 && enemy4.GetComponent<EnemyTeamScript>().IsGrounded()) || (usingStyle == 1 && companion.GetComponent<PlayerTeamScript>().GetPlayerType() == 1) || companion.GetComponent<PlayerTeamScript>().GetPlayerType() != 1))
                                    {
                                        enemy3.GetChild(0).transform.GetChild(0).gameObject.SetActive(false);
                                        enemy4.GetChild(0).transform.GetChild(0).gameObject.SetActive(true);
                                        if (enemy4.GetComponent<EnemyTeamScript>().enemyType == 0)
                                        {
                                            enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = "Bandit";
                                        }
                                        else if (enemy4.GetComponent<EnemyTeamScript>().enemyType == 1)
                                        {
                                            enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = "Wizard";
                                        }
                                    }
                                }
                                if (Input.GetKeyDown(KeyCode.Space))
                                {
                                    companion.GetChild(0).transform.GetChild(0).GetComponent<Animator>().SetBool("Active", false);
                                    companion.GetChild(0).transform.GetChild(0).GetComponent<Animator>().SetBool("MenuHide", false);
                                    enemy3.GetChild(0).transform.GetChild(0).gameObject.SetActive(false);
                                    companion.GetChild(0).transform.GetChild(0).GetComponent<Animator>().SetBool("MenuOpened", false);
                                    selectedEnemy = enemy3;
                                    selectingEnemyCompanion = false;
                                    enemyName.SetActive(false);
                                    actionInstructions.GetComponent<Image>().color = new Vector4(actionInstructions.GetComponent<Image>().color.r, actionInstructions.GetComponent<Image>().color.g, actionInstructions.GetComponent<Image>().color.b, 1.0f);
                                    actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = new Vector4(actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color.r, actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color.g, actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color.b, 1.0f);
                                    companion.GetComponent<PlayerTeamScript>().Attack(attackType, usingStyle, selectedEnemy);
                                }
                            }
                            else if (enemy4.GetChild(0).transform.GetChild(0).gameObject.activeSelf)
                            {
                                if (Input.GetKeyDown(KeyCode.LeftArrow))
                                {
                                    if (enemy3.GetComponent<EnemyTeamScript>().IsAlive() && ((usingStyle != 1 && companion.GetComponent<PlayerTeamScript>().GetPlayerType() == 1 && enemy3.GetComponent<EnemyTeamScript>().IsGrounded()) || (usingStyle == 1 && companion.GetComponent<PlayerTeamScript>().GetPlayerType() == 1) || companion.GetComponent<PlayerTeamScript>().GetPlayerType() != 1))
                                    {
                                        enemy3.GetChild(0).transform.GetChild(0).gameObject.SetActive(true);
                                        enemy4.GetChild(0).transform.GetChild(0).gameObject.SetActive(false);
                                        if (enemy3.GetComponent<EnemyTeamScript>().enemyType == 0)
                                        {
                                            enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = "Bandit";
                                        }
                                        else if (enemy3.GetComponent<EnemyTeamScript>().enemyType == 1)
                                        {
                                            enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = "Wizard";
                                        }
                                    }
                                    else if (enemy2.GetComponent<EnemyTeamScript>().IsAlive() && ((usingStyle != 1 && companion.GetComponent<PlayerTeamScript>().GetPlayerType() == 1 && enemy2.GetComponent<EnemyTeamScript>().IsGrounded()) || (usingStyle == 1 && companion.GetComponent<PlayerTeamScript>().GetPlayerType() == 1) || companion.GetComponent<PlayerTeamScript>().GetPlayerType() != 1))
                                    {
                                        enemy2.GetChild(0).transform.GetChild(0).gameObject.SetActive(true);
                                        enemy4.GetChild(0).transform.GetChild(0).gameObject.SetActive(false);
                                        if (enemy2.GetComponent<EnemyTeamScript>().enemyType == 0)
                                        {
                                            enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = "Bandit";
                                        }
                                        else if (enemy2.GetComponent<EnemyTeamScript>().enemyType == 1)
                                        {
                                            enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = "Wizard";
                                        }
                                    }
                                    else if (enemy1.GetComponent<EnemyTeamScript>().IsAlive() && ((usingStyle != 1 && companion.GetComponent<PlayerTeamScript>().GetPlayerType() == 1 && enemy1.GetComponent<EnemyTeamScript>().IsGrounded()) || (usingStyle == 1 && companion.GetComponent<PlayerTeamScript>().GetPlayerType() == 1) || companion.GetComponent<PlayerTeamScript>().GetPlayerType() != 1))
                                    {
                                        enemy1.GetChild(0).transform.GetChild(0).gameObject.SetActive(true);
                                        enemy4.GetChild(0).transform.GetChild(0).gameObject.SetActive(false);
                                        if (enemy1.GetComponent<EnemyTeamScript>().enemyType == 0)
                                        {
                                            enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = "Bandit";
                                        }
                                        else if (enemy1.GetComponent<EnemyTeamScript>().enemyType == 1)
                                        {
                                            enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = "Wizard";
                                        }
                                    }
                                }
                                if (Input.GetKeyDown(KeyCode.Space))
                                {
                                    companion.GetChild(0).transform.GetChild(0).GetComponent<Animator>().SetBool("Active", false);
                                    companion.GetChild(0).transform.GetChild(0).GetComponent<Animator>().SetBool("MenuHide", false);
                                    enemy4.GetChild(0).transform.GetChild(0).gameObject.SetActive(false);
                                    companion.GetChild(0).transform.GetChild(0).GetComponent<Animator>().SetBool("MenuOpened", false);
                                    selectedEnemy = enemy4;
                                    selectingEnemyCompanion = false;
                                    enemyName.SetActive(false);
                                    actionInstructions.GetComponent<Image>().color = new Vector4(actionInstructions.GetComponent<Image>().color.r, actionInstructions.GetComponent<Image>().color.g, actionInstructions.GetComponent<Image>().color.b, 1.0f);
                                    actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = new Vector4(actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color.r, actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color.g, actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color.b, 1.0f);
                                    companion.GetComponent<PlayerTeamScript>().Attack(attackType, usingStyle, selectedEnemy);
                                }
                            }
                        }
                        //If there is only one enemy we select it using space and the attack starts
                        else if (Input.GetKeyDown(KeyCode.Space))
                        {
                            companion.GetChild(0).transform.GetChild(0).GetComponent<Animator>().SetBool("Active", false);
                            companion.GetChild(0).transform.GetChild(0).GetComponent<Animator>().SetBool("MenuHide", false);
                            companion.GetChild(0).transform.GetChild(0).GetComponent<Animator>().SetBool("MenuOpened", false);
                            enemy1.GetChild(0).transform.GetChild(0).gameObject.SetActive(false);
                            selectedEnemy = enemy1;
                            selectingEnemyCompanion = false;
                            enemyName.SetActive(false);
                            actionInstructions.SetActive(false);
                            companion.GetComponent<PlayerTeamScript>().Attack(attackType, usingStyle, selectedEnemy);
                        }
                    }
                    else if (Input.GetKeyDown(KeyCode.Space))
                    {
                        Transform[] allEnemies = GetAllEnemies();
                        for (int i = 0; i < allEnemies.Length; i++)
                        {
                            allEnemies[i].GetChild(0).transform.GetChild(0).gameObject.SetActive(false);
                            enemyName.transform.GetChild(i).gameObject.SetActive(false);
                        }
                        companion.GetChild(0).transform.GetChild(0).GetComponent<Animator>().SetBool("Active", false);
                        companion.GetChild(0).transform.GetChild(0).GetComponent<Animator>().SetBool("MenuHide", false);
                        companion.GetChild(0).transform.GetChild(0).GetComponent<Animator>().SetBool("MenuOpened", false);
                        selectedEnemy = enemy1;
                        selectingEnemyCompanion = false;
                        enemyName.SetActive(false);
                        actionInstructions.GetComponent<Image>().color = new Vector4(actionInstructions.GetComponent<Image>().color.r, actionInstructions.GetComponent<Image>().color.g, actionInstructions.GetComponent<Image>().color.b, 1.0f);
                        actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = new Vector4(actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color.r, actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color.g, actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color.b, 1.0f);
                        companion.GetComponent<PlayerTeamScript>().Attack(attackType, usingStyle, selectedEnemy);
                    }
                }
                else if (finalAttack)
                {
                    //If it is a melee attack
                    if (attackType == 0)
                    {
                        if (usingStyle == 0 || usingStyle == 2)
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
                        }
                        else if(usingStyle == 1)
                        {
                            if (!attackAction && Input.GetKeyDown(KeyCode.X)) badAttack = true;
                            if (attackAction)
                            {                                
                                if (Input.GetKeyDown(KeyCode.X) && !badAttack)
                                {
                                    goodAttack = true;
                                    companion.GetComponent<PlayerTeamScript>().EndGlance();
                                }
                            }
                        }
                        else if(usingStyle == 3)
                        {
                            if (Input.GetKey(KeyCode.X) && !companion.transform.GetChild(0).transform.GetChild(3).GetComponent<Animator>().GetBool("charging"))
                            {
                                DeactivateActionInstructions();
                                companion.transform.GetChild(0).transform.GetChild(3).GetComponent<Animator>().SetBool("charging", true);
                            }
                            if (Input.GetKeyUp(KeyCode.X) && attackAction)
                            {
                                companion.GetComponent<PlayerTeamScript>().SetShurikenDamage(3);
                                companion.GetComponent<Animator>().SetTrigger("ShootArrow");
                                companion.transform.GetChild(0).transform.GetChild(3).GetComponent<Animator>().SetBool("charging", false);
                                companion.transform.GetChild(0).transform.GetChild(3).GetComponent<Animator>().SetBool("active", false);
                                attackAction = false;
                                finalAttack = false;
                            }
                            else if (Input.GetKeyUp(KeyCode.X) && !attackAction && !attackFinished)
                            {
                                companion.GetComponent<PlayerTeamScript>().SetShurikenDamage(1);
                                companion.GetComponent<Animator>().SetTrigger("ShootArrow");
                                companion.transform.GetChild(0).transform.GetChild(3).GetComponent<Animator>().SetBool("charging", false);
                                companion.transform.GetChild(0).transform.GetChild(3).GetComponent<Animator>().SetBool("active", false);
                                finalAttack = false;
                            }
                            else if (attackFinished)
                            {
                                companion.GetComponent<PlayerTeamScript>().SetShurikenDamage(1);
                                companion.GetComponent<Animator>().SetTrigger("ShootArrow");
                                companion.transform.GetChild(0).transform.GetChild(3).GetComponent<Animator>().SetBool("charging", false);
                                companion.transform.GetChild(0).transform.GetChild(3).GetComponent<Animator>().SetBool("active", false);
                                finalAttack = false;
                            }
                        }
                        else if(usingStyle == 4)
                        {
                            if (GetAllEnemies() != null)
                            {
                                if (readyShoot && Input.GetKeyDown(KeyCode.X))
                                {
                                    GetComponent<BattleController>().DeactivateActionInstructions();
                                    companion.GetComponent<PlayerTeamScript>().SetShurikenDamage(2);
                                    companion.GetComponent<Animator>().SetTrigger("ShootArrow");
                                }
                            }
                            else companion.GetComponent<PlayerTeamScript>().EndShurikenThrow();
                        }
                    }
                }
                else if (talking)
                {
                    if (Input.GetKeyDown(KeyCode.X)) GetComponent<DialogueManager>().DisplayNextSentence();
                }
                else if (fleeing && (Time.fixedTime - fleeTime) < 10.0f)
                {
                    if (Input.GetKeyDown(KeyCode.X))
                    {
                        if (fleeAction.transform.GetChild(1).GetComponent<Image>().fillAmount != 1.0f) fleeAction.transform.GetChild(1).GetComponent<Image>().fillAmount += 0.02f;
                    }
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
                    if (Random.Range(0.0f, 1.0f) < 0.75f)
                    {
                        if(firstPosPlayer) enemy1.GetComponent<EnemyTeamScript>().Attack(player);
                        else enemy1.GetComponent<EnemyTeamScript>().Attack(companion);
                    }
                    else
                    {
                        if (firstPosPlayer) enemy1.GetComponent<EnemyTeamScript>().Attack(companion);
                        else enemy1.GetComponent<EnemyTeamScript>().Attack(player);
                    }
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
            if(enemyNumber > 1)
            {
                if (enemy2Turn && enemy2.GetComponent<EnemyTeamScript>().IsIdle())
                {
                    if (enemy2.GetComponent<EnemyTeamScript>().IsAlive())
                    {
                        if (Random.Range(0.0f, 1.0f) < 0.75f)
                        {
                            if (firstPosPlayer) enemy2.GetComponent<EnemyTeamScript>().Attack(player);
                            else enemy2.GetComponent<EnemyTeamScript>().Attack(companion);
                        }
                        else
                        {
                            if (firstPosPlayer) enemy2.GetComponent<EnemyTeamScript>().Attack(companion);
                            else enemy2.GetComponent<EnemyTeamScript>().Attack(player);
                        }
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
            if (enemyNumber > 2)
            {
                if (enemy3Turn && enemy3.GetComponent<EnemyTeamScript>().IsIdle())
                {
                    if (enemy3.GetComponent<EnemyTeamScript>().IsAlive())
                    {
                        if (Random.Range(0.0f, 1.0f) < 0.75f)
                        {
                            if (firstPosPlayer) enemy3.GetComponent<EnemyTeamScript>().Attack(player);
                            else enemy3.GetComponent<EnemyTeamScript>().Attack(companion);
                        }
                        else
                        {
                            if (firstPosPlayer) enemy3.GetComponent<EnemyTeamScript>().Attack(companion);
                            else enemy3.GetComponent<EnemyTeamScript>().Attack(player);
                        }
                        enemy3Turn = false;
                    }
                    else
                    {
                        enemy3Turn = false;
                        if (enemyNumber > 3) NextEnemy(3);
                        else EndEnemyTurn();
                    }
                }
                else if (enemy3.GetComponent<EnemyTeamScript>().IsAttacking())
                {
                    if (Input.GetKeyDown(KeyCode.X))
                    {
                        if (defenseZone)
                        {
                            enemy3.GetComponent<EnemyTeamScript>().IsDefended(true);
                        }
                        else enemy3.GetComponent<EnemyTeamScript>().IsDefended(false);
                    }
                }
            }
            if (enemyNumber > 3)
            {
                if (enemy4Turn && enemy4.GetComponent<EnemyTeamScript>().IsIdle())
                {
                    if (enemy4.GetComponent<EnemyTeamScript>().IsAlive())
                    {
                        if (Random.Range(0.0f, 1.0f) < 0.75f)
                        {
                            if (firstPosPlayer) enemy4.GetComponent<EnemyTeamScript>().Attack(player);
                            else enemy4.GetComponent<EnemyTeamScript>().Attack(companion);
                        }
                        else
                        {
                            if (firstPosPlayer) enemy4.GetComponent<EnemyTeamScript>().Attack(companion);
                            else enemy4.GetComponent<EnemyTeamScript>().Attack(player);
                        }
                        enemy4Turn = false;
                    }
                    else
                    {
                        enemy4Turn = false;
                        EndEnemyTurn();
                    }
                }
                else if (enemy4.GetComponent<EnemyTeamScript>().IsAttacking())
                {
                    if (Input.GetKeyDown(KeyCode.X))
                    {
                        if (defenseZone)
                        {
                            enemy4.GetComponent<EnemyTeamScript>().IsDefended(true);
                        }
                        else enemy4.GetComponent<EnemyTeamScript>().IsDefended(false);
                    }
                }
            }                
        }
    }

    private void FixedUpdate()
    {
        if(playerTurn && finalAttack && attackType == 1 && usingStyle == 1)
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
        if (playerTurn && finalAttack && attackType == 1 && usingStyle == 2)
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
        if (changePos)
        {
            if (playerTurn)
            {
                if (player.position.x > -5.7f)
                {
                    player.position = new Vector3(player.position.x - 0.056f, player.position.y, player.position.z + 0.02f);
                    companion.position = new Vector3(companion.position.x + 0.056f, companion.position.y, companion.position.z - 0.02f);
                }
                else if (player.position.x > -6.4f)
                {
                    player.position = new Vector3(player.position.x - 0.056f, player.position.y, player.position.z - 0.02f);
                    companion.position = new Vector3(companion.position.x + 0.056f, companion.position.y, companion.position.z + 0.02f);
                }
                else EndChangePosition(1);
            }
            else if (companionTurn)
            {
                if (companion.position.x > -5.7f)
                {
                    companion.position = new Vector3(companion.position.x - 0.056f, companion.position.y, companion.position.z + 0.02f);
                    player.position = new Vector3(player.position.x + 0.056f, player.position.y, player.position.z - 0.02f);
                }
                else if (companion.position.x > -6.4f)
                {
                    companion.position = new Vector3(companion.position.x - 0.056f, companion.position.y, companion.position.z - 0.02f);
                    player.position = new Vector3(player.position.x + 0.056f, player.position.y, player.position.z + 0.02f);
                }
                else EndChangePosition(2);
            }
        }
        if (playerTurn && finalAttack)
        {
            if (soulMusic > 0 && !failMusic)
            {
                if(soulMusicFilling)player.GetChild(0).transform.GetChild(7).transform.GetChild(1).GetComponent<Image>().fillAmount += 0.0005f + 0.0005f *soulMusic;
                else player.GetChild(0).transform.GetChild(7).transform.GetChild(1).GetComponent<Image>().fillAmount -= 0.015f;
            }
            if (soulRegen)
            {
                soulRegenRingSpeed += 0.00005f;
                soulRegenGreenSpeed += 0.00005f;
                if (soulRegenMovUp && greenSoul.GetComponent<RectTransform>().anchoredPosition.y < 2.0f) greenSoul.GetComponent<RectTransform>().anchoredPosition = new Vector2(greenSoul.GetComponent<RectTransform>().anchoredPosition.x, greenSoul.GetComponent<RectTransform>().anchoredPosition.y + soulRegenGreenSpeed);
                if (soulRegenMovLeft && greenSoul.GetComponent<RectTransform>().anchoredPosition.x > -5.45f) greenSoul.GetComponent<RectTransform>().anchoredPosition = new Vector2(greenSoul.GetComponent<RectTransform>().anchoredPosition.x - soulRegenGreenSpeed, greenSoul.GetComponent<RectTransform>().anchoredPosition.y);
                if (soulRegenMovRight && greenSoul.GetComponent<RectTransform>().anchoredPosition.x < 5.45f) greenSoul.GetComponent<RectTransform>().anchoredPosition = new Vector2(greenSoul.GetComponent<RectTransform>().anchoredPosition.x + soulRegenGreenSpeed, greenSoul.GetComponent<RectTransform>().anchoredPosition.y);
                if (soulRegenMovDown && greenSoul.GetComponent<RectTransform>().anchoredPosition.y > -2.3f) greenSoul.GetComponent<RectTransform>().anchoredPosition = new Vector2(greenSoul.GetComponent<RectTransform>().anchoredPosition.x, greenSoul.GetComponent<RectTransform>().anchoredPosition.y - soulRegenGreenSpeed);
                ring1[0].GetComponent<RectTransform>().anchoredPosition = new Vector2(ring1[0].GetComponent<RectTransform>().anchoredPosition.x, ring1[0].GetComponent<RectTransform>().anchoredPosition.y + soulRegenRingSpeed);
                ring1[1].GetComponent<RectTransform>().anchoredPosition = new Vector2(ring1[1].GetComponent<RectTransform>().anchoredPosition.x, ring1[1].GetComponent<RectTransform>().anchoredPosition.y + soulRegenRingSpeed);
                ring2[0].GetComponent<RectTransform>().anchoredPosition = new Vector2(ring2[0].GetComponent<RectTransform>().anchoredPosition.x, ring2[0].GetComponent<RectTransform>().anchoredPosition.y + soulRegenRingSpeed);
                ring2[1].GetComponent<RectTransform>().anchoredPosition = new Vector2(ring2[1].GetComponent<RectTransform>().anchoredPosition.x, ring2[1].GetComponent<RectTransform>().anchoredPosition.y + soulRegenRingSpeed);
                ring3[0].GetComponent<RectTransform>().anchoredPosition = new Vector2(ring3[0].GetComponent<RectTransform>().anchoredPosition.x, ring3[0].GetComponent<RectTransform>().anchoredPosition.y + soulRegenRingSpeed);
                ring3[1].GetComponent<RectTransform>().anchoredPosition = new Vector2(ring3[1].GetComponent<RectTransform>().anchoredPosition.x, ring3[1].GetComponent<RectTransform>().anchoredPosition.y + soulRegenRingSpeed);
                ring4[0].GetComponent<RectTransform>().anchoredPosition = new Vector2(ring4[0].GetComponent<RectTransform>().anchoredPosition.x, ring4[0].GetComponent<RectTransform>().anchoredPosition.y + soulRegenRingSpeed);
                ring4[1].GetComponent<RectTransform>().anchoredPosition = new Vector2(ring4[1].GetComponent<RectTransform>().anchoredPosition.x, ring4[1].GetComponent<RectTransform>().anchoredPosition.y + soulRegenRingSpeed);
                ring5[0].GetComponent<RectTransform>().anchoredPosition = new Vector2(ring5[0].GetComponent<RectTransform>().anchoredPosition.x, ring5[0].GetComponent<RectTransform>().anchoredPosition.y + soulRegenRingSpeed);
                ring5[1].GetComponent<RectTransform>().anchoredPosition = new Vector2(ring5[1].GetComponent<RectTransform>().anchoredPosition.x, ring5[1].GetComponent<RectTransform>().anchoredPosition.y + soulRegenRingSpeed);
                ring6[0].GetComponent<RectTransform>().anchoredPosition = new Vector2(ring6[0].GetComponent<RectTransform>().anchoredPosition.x, ring6[0].GetComponent<RectTransform>().anchoredPosition.y + soulRegenRingSpeed);
                ring6[1].GetComponent<RectTransform>().anchoredPosition = new Vector2(ring6[1].GetComponent<RectTransform>().anchoredPosition.x, ring6[1].GetComponent<RectTransform>().anchoredPosition.y + soulRegenRingSpeed);
                ring7[0].GetComponent<RectTransform>().anchoredPosition = new Vector2(ring7[0].GetComponent<RectTransform>().anchoredPosition.x, ring7[0].GetComponent<RectTransform>().anchoredPosition.y + soulRegenRingSpeed);
                ring7[1].GetComponent<RectTransform>().anchoredPosition = new Vector2(ring7[1].GetComponent<RectTransform>().anchoredPosition.x, ring7[1].GetComponent<RectTransform>().anchoredPosition.y + soulRegenRingSpeed);
                ring8[0].GetComponent<RectTransform>().anchoredPosition = new Vector2(ring8[0].GetComponent<RectTransform>().anchoredPosition.x, ring8[0].GetComponent<RectTransform>().anchoredPosition.y + soulRegenRingSpeed);
                ring8[1].GetComponent<RectTransform>().anchoredPosition = new Vector2(ring8[1].GetComponent<RectTransform>().anchoredPosition.x, ring8[1].GetComponent<RectTransform>().anchoredPosition.y + soulRegenRingSpeed);
            }
            if (soulLightning)
            {
                if (yellowSoul.position.x < 7.0f && yellowSoulRight) yellowSoul.position = new Vector3(yellowSoul.position.x + 0.05f, yellowSoul.position.y, yellowSoul.position.z);
                else if (yellowSoul.position.x >= 7.0f && yellowSoulRight) yellowSoulRight = false;
                else if (yellowSoul.position.x > player.position.x && !yellowSoulRight) yellowSoul.position = new Vector3(yellowSoul.position.x - 0.05f, yellowSoul.position.y, yellowSoul.position.z);
                else EndLightningAttack();
            }
            if (soulLifesteal)
            {
                if (jarMovUp && jar.GetComponent<RectTransform>().anchoredPosition.y < 2.0f) jar.GetComponent<RectTransform>().anchoredPosition = new Vector2(jar.GetComponent<RectTransform>().anchoredPosition.x, jar.GetComponent<RectTransform>().anchoredPosition.y + 0.09f);
                if (jarMovLeft && jar.GetComponent<RectTransform>().anchoredPosition.x > -5.45f) jar.GetComponent<RectTransform>().anchoredPosition = new Vector2(jar.GetComponent<RectTransform>().anchoredPosition.x - 0.09f, jar.GetComponent<RectTransform>().anchoredPosition.y);
                if (jarMovRight && jar.GetComponent<RectTransform>().anchoredPosition.x < 5.45f) jar.GetComponent<RectTransform>().anchoredPosition = new Vector2(jar.GetComponent<RectTransform>().anchoredPosition.x + 0.09f, jar.GetComponent<RectTransform>().anchoredPosition.y);
                if (jarMovDown && jar.GetComponent<RectTransform>().anchoredPosition.y > -2.15f) jar.GetComponent<RectTransform>().anchoredPosition = new Vector2(jar.GetComponent<RectTransform>().anchoredPosition.x, jar.GetComponent<RectTransform>().anchoredPosition.y - 0.09f);
                if(redSoul1 != null) redSoul1.GetComponent<RectTransform>().anchoredPosition = new Vector2(redSoul1.GetComponent<RectTransform>().anchoredPosition.x, redSoul1.GetComponent<RectTransform>().anchoredPosition.y - 0.045f);
                if(redSoul2 != null) redSoul2.GetComponent<RectTransform>().anchoredPosition = new Vector2(redSoul2.GetComponent<RectTransform>().anchoredPosition.x, redSoul2.GetComponent<RectTransform>().anchoredPosition.y - 0.045f);
                if(redSoul3 != null) redSoul3.GetComponent<RectTransform>().anchoredPosition = new Vector2(redSoul3.GetComponent<RectTransform>().anchoredPosition.x, redSoul3.GetComponent<RectTransform>().anchoredPosition.y - 0.045f);
                if(redSoul4 != null) redSoul4.GetComponent<RectTransform>().anchoredPosition = new Vector2(redSoul4.GetComponent<RectTransform>().anchoredPosition.x, redSoul4.GetComponent<RectTransform>().anchoredPosition.y - 0.045f);
                if(redSoul5 != null) redSoul5.GetComponent<RectTransform>().anchoredPosition = new Vector2(redSoul5.GetComponent<RectTransform>().anchoredPosition.x, redSoul5.GetComponent<RectTransform>().anchoredPosition.y - 0.045f);
                if(redSoul6 != null) redSoul6.GetComponent<RectTransform>().anchoredPosition = new Vector2(redSoul6.GetComponent<RectTransform>().anchoredPosition.x, redSoul6.GetComponent<RectTransform>().anchoredPosition.y - 0.045f);
                if(redSoul7 != null) redSoul7.GetComponent<RectTransform>().anchoredPosition = new Vector2(redSoul7.GetComponent<RectTransform>().anchoredPosition.x, redSoul7.GetComponent<RectTransform>().anchoredPosition.y - 0.045f);
                if(redSoul8 != null) redSoul8.GetComponent<RectTransform>().anchoredPosition = new Vector2(redSoul8.GetComponent<RectTransform>().anchoredPosition.x, redSoul8.GetComponent<RectTransform>().anchoredPosition.y - 0.045f);
                if(redSoul9 != null) redSoul9.GetComponent<RectTransform>().anchoredPosition = new Vector2(redSoul9.GetComponent<RectTransform>().anchoredPosition.x, redSoul9.GetComponent<RectTransform>().anchoredPosition.y - 0.045f);
                if(redSoul10 != null) redSoul10.GetComponent<RectTransform>().anchoredPosition = new Vector2(redSoul10.GetComponent<RectTransform>().anchoredPosition.x, redSoul10.GetComponent<RectTransform>().anchoredPosition.y - 0.045f);
                if (redSoul1 == null && redSoul2 == null && redSoul2 == null && redSoul3 == null && redSoul4 == null && redSoul5 == null && redSoul6 == null && redSoul7 == null && redSoul8 == null && redSoul9 == null && redSoul10 == null) EndLifestealAttack();
            }
            if (soulDisappear)
            {                
                if (blueSoulMovUp && blueSoul.GetComponent<RectTransform>().anchoredPosition.y < 2.0f) blueSoul.GetComponent<RectTransform>().anchoredPosition = new Vector2(blueSoul.GetComponent<RectTransform>().anchoredPosition.x, blueSoul.GetComponent<RectTransform>().anchoredPosition.y + 0.075f);
                if (blueSoulMovLeft && blueSoul.GetComponent<RectTransform>().anchoredPosition.x > -5.45f) blueSoul.GetComponent<RectTransform>().anchoredPosition = new Vector2(blueSoul.GetComponent<RectTransform>().anchoredPosition.x - 0.075f, blueSoul.GetComponent<RectTransform>().anchoredPosition.y);
                if (blueSoulMovRight && blueSoul.GetComponent<RectTransform>().anchoredPosition.x < 5.45f) blueSoul.GetComponent<RectTransform>().anchoredPosition = new Vector2(blueSoul.GetComponent<RectTransform>().anchoredPosition.x + 0.075f, blueSoul.GetComponent<RectTransform>().anchoredPosition.y);
                if (blueSoulMovDown && blueSoul.GetComponent<RectTransform>().anchoredPosition.y > -2.3f) blueSoul.GetComponent<RectTransform>().anchoredPosition = new Vector2(blueSoul.GetComponent<RectTransform>().anchoredPosition.x, blueSoul.GetComponent<RectTransform>().anchoredPosition.y - 0.075f);
                wall1.GetComponent<RectTransform>().anchoredPosition = new Vector2(wall1.GetComponent<RectTransform>().anchoredPosition.x - 0.045f, wall1.GetComponent<RectTransform>().anchoredPosition.y);
                wall2.GetComponent<RectTransform>().anchoredPosition = new Vector2(wall2.GetComponent<RectTransform>().anchoredPosition.x - 0.045f, wall2.GetComponent<RectTransform>().anchoredPosition.y);
                wall3.GetComponent<RectTransform>().anchoredPosition = new Vector2(wall3.GetComponent<RectTransform>().anchoredPosition.x - 0.045f, wall3.GetComponent<RectTransform>().anchoredPosition.y);
                wall4.GetComponent<RectTransform>().anchoredPosition = new Vector2(wall4.GetComponent<RectTransform>().anchoredPosition.x - 0.045f, wall4.GetComponent<RectTransform>().anchoredPosition.y);
                wall5.GetComponent<RectTransform>().anchoredPosition = new Vector2(wall5.GetComponent<RectTransform>().anchoredPosition.x - 0.045f, wall5.GetComponent<RectTransform>().anchoredPosition.y);
                if (blueSoul.GetComponent<Image>().color.a > 0.05) blueSoul.GetComponent<Image>().color = new Color(blueSoul.GetComponent<Image>().color.r, blueSoul.GetComponent<Image>().color.g, blueSoul.GetComponent<Image>().color.b, blueSoul.GetComponent<Image>().color.a - 0.0006f);
                else EndDisappearAttack();
            }
            if (soulLightUp)
            {
                if (!fogScaled)
                {
                    if (fog.GetComponent<RectTransform>().localScale.x > 1.0f) fog.GetComponent<RectTransform>().localScale = new Vector3(fog.GetComponent<RectTransform>().localScale.x - 0.1f, fog.GetComponent<RectTransform>().localScale.y - 0.1f, fog.GetComponent<RectTransform>().localScale.z);
                    else
                    {
                        fogScaled = true;
                        lightUpTime = Time.fixedTime;
                    }
                }
                else
                {
                    if ((Time.fixedTime - lightUpTime) > 10.0f) EndLightUpAttack();
                    if (fog.GetComponent<RectTransform>().localScale.x >= minFogScale) fog.GetComponent<RectTransform>().localScale = new Vector3(fog.GetComponent<RectTransform>().localScale.x - 0.004f, fog.GetComponent<RectTransform>().localScale.y - 0.004f, fog.GetComponent<RectTransform>().localScale.z);
                    else fog.GetComponent<RectTransform>().localScale = new Vector3(fog.GetComponent<RectTransform>().localScale.x + 0.004f, fog.GetComponent<RectTransform>().localScale.y + 0.004f, fog.GetComponent<RectTransform>().localScale.z);
                    if (magentaSoulMovUp && magentaSoul.GetComponent<RectTransform>().anchoredPosition.y < 2.0f)
                    {
                        magentaSoul.GetComponent<RectTransform>().anchoredPosition = new Vector2(magentaSoul.GetComponent<RectTransform>().anchoredPosition.x, magentaSoul.GetComponent<RectTransform>().anchoredPosition.y + 0.05f);
                        fog.GetComponent<RectTransform>().anchoredPosition = new Vector2(fog.GetComponent<RectTransform>().anchoredPosition.x, fog.GetComponent<RectTransform>().anchoredPosition.y + 0.05f);
                    }
                    if (magentaSoulMovLeft && magentaSoul.GetComponent<RectTransform>().anchoredPosition.x > -5.45f)
                    {
                        magentaSoul.GetComponent<RectTransform>().anchoredPosition = new Vector2(magentaSoul.GetComponent<RectTransform>().anchoredPosition.x - 0.05f, magentaSoul.GetComponent<RectTransform>().anchoredPosition.y);
                        fog.GetComponent<RectTransform>().anchoredPosition = new Vector2(fog.GetComponent<RectTransform>().anchoredPosition.x - 0.05f, fog.GetComponent<RectTransform>().anchoredPosition.y);
                    }
                    if (magentaSoulMovRight && magentaSoul.GetComponent<RectTransform>().anchoredPosition.x < 5.45f)
                    {
                        magentaSoul.GetComponent<RectTransform>().anchoredPosition = new Vector2(magentaSoul.GetComponent<RectTransform>().anchoredPosition.x + 0.05f, magentaSoul.GetComponent<RectTransform>().anchoredPosition.y);
                        fog.GetComponent<RectTransform>().anchoredPosition = new Vector2(fog.GetComponent<RectTransform>().anchoredPosition.x + 0.05f, fog.GetComponent<RectTransform>().anchoredPosition.y);
                    }
                    if (magentaSoulMovDown && magentaSoul.GetComponent<RectTransform>().anchoredPosition.y > -2.3f)
                    {
                        magentaSoul.GetComponent<RectTransform>().anchoredPosition = new Vector2(magentaSoul.GetComponent<RectTransform>().anchoredPosition.x, magentaSoul.GetComponent<RectTransform>().anchoredPosition.y - 0.05f);
                        fog.GetComponent<RectTransform>().anchoredPosition = new Vector2(fog.GetComponent<RectTransform>().anchoredPosition.x, fog.GetComponent<RectTransform>().anchoredPosition.y - 0.05f);
                    }
                }                
            }
        }
        if(companionTurn && finalAttack && usingStyle == 4)
        {
            if(aimRotation<40.0f && aimUp)
            {
                aimRotation += 0.5f;
                companion.GetChild(0).GetChild(4).GetChild(0).GetComponent<RectTransform>().rotation = Quaternion.Euler(0.0f,0.0f,aimRotation);
            }
            else if(aimRotation>= 40.0f && aimUp)
            {
                aimUp = false;
            }
            else if(aimRotation > -10.0f && !aimUp)
            {
                aimRotation -= 0.5f;
                companion.GetChild(0).GetChild(4).GetChild(0).GetComponent<RectTransform>().rotation = Quaternion.Euler(0.0f, 0.0f, aimRotation);
            }
            else if (aimRotation <= -10.0f && !aimUp)
            {
                aimUp = true;
            }

        }

        if (fleeing)
        {
            if ((Time.fixedTime - fleeTime) < 10.0f)
            {
                if (fleeAction.transform.GetChild(1).GetComponent<Image>().fillAmount != 1.0f) fleeAction.transform.GetChild(1).GetComponent<Image>().fillAmount -= 0.001f;
                if (fleeRight)
                {
                    if (fleeAction.transform.GetChild(2).GetComponent<RectTransform>().anchoredPosition.x < 1.425f)
                    {
                        fleeAction.transform.GetChild(2).GetComponent<RectTransform>().anchoredPosition = new Vector2(fleeAction.transform.GetChild(2).GetComponent<RectTransform>().anchoredPosition.x + 0.057f, fleeAction.transform.GetChild(2).GetComponent<RectTransform>().anchoredPosition.y);
                    }
                    else fleeRight = false;
                }
                else
                {
                    if (fleeAction.transform.GetChild(2).GetComponent<RectTransform>().anchoredPosition.x > -1.425f)
                    {
                        fleeAction.transform.GetChild(2).GetComponent<RectTransform>().anchoredPosition = new Vector2(fleeAction.transform.GetChild(2).GetComponent<RectTransform>().anchoredPosition.x - 0.057f, fleeAction.transform.GetChild(2).GetComponent<RectTransform>().anchoredPosition.y);
                    }
                    else fleeRight = true;
                }
            }
            else
            {
                actionInstructions.SetActive(false);
                fleeAction.gameObject.SetActive(false);
                if (fleeAction.transform.GetChild(1).GetComponent<Image>().fillAmount > ((fleeAction.transform.GetChild(2).GetComponent<RectTransform>().anchoredPosition.x + 1.425f) / 3.86f))
                {
                    fleeing = false;
                    fled = true;
                }
                else
                {
                    fleeAction.transform.GetChild(1).GetComponent<Image>().fillAmount = 0.0f;
                    player.GetComponent<Animator>().SetFloat("Speed", 0.0f);
                    player.GetComponent<Animator>().SetFloat("attackSpeed", 1.0f);
                    fleeing = false; 
                    companion.GetComponent<Animator>().SetFloat("RunSpeed", 0.0f);
                    companion.GetComponent<Animator>().SetFloat("Speed", 1.0f);
                    if(playerTurn) EndPlayerTurn(1);
                    else if(companionTurn) EndPlayerTurn(2);
                }
            }
            
        }
        else if (fled)
        {
            if(player.transform.position.x > -10.0f) player.transform.position = new Vector3(player.transform.position.x - 0.2f, player.transform.position.y, player.transform.position.z);
            if(companion.transform.position.x > -10.0f) companion.transform.position = new Vector3(companion.transform.position.x - 0.2f, companion.transform.position.y, companion.transform.position.z);
            //else EndBattle();
        }
        if (victory)
        {
            Debug.Log("victorieado");
            if (Input.GetKeyDown(KeyCode.X)) SaveXP();
        }
    }

    //Function to spawn the characters. 0 -> Player, 1-> companion, 2-> Enemy1, 3-> Enemy2, 4-> Enemy3, 5-> Enemy4. type-> 0 adventurer and bandit, 1-> wizard
    private void SpawnCharacter(int battlePos, int type)
    {
        if (battlePos == 0)
        {
            player = Instantiate(playerBattle, new Vector3(-5, -1, -2.05f), Quaternion.identity);
            regenerationAction = player.GetChild(0).GetChild(8).gameObject;
            lightningAction = player.GetChild(0).GetChild(9).gameObject;
            lifestealAction = player.GetChild(0).GetChild(10).gameObject;
            disappearAction = player.GetChild(0).GetChild(11).gameObject;
            lightUpAction = player.GetChild(0).GetChild(12).gameObject;
        }
        else if (battlePos == 1)
        {
            if(type == 0) companion = Instantiate(adventurerBattle, new Vector3(-6.4f, -0.713f, -2.04f), Quaternion.identity);
        }
        else if (battlePos == 2)
        {
            if (type == 0)
            {
                enemy1 = Instantiate(banditBattle, new Vector3(2.5f, -0.64f, -2.03f), Quaternion.identity);
                player.GetChild(0).GetChild(0).GetChild(0).GetComponent<RawImage>().color = new Color(1.0f, 1.0f, 1.0f, player.GetChild(0).GetChild(0).GetChild(0).GetComponent<RawImage>().color.a);
                player.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<RawImage>().color = new Color(1.0f, 1.0f, 1.0f, player.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<RawImage>().color.a);
                player.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<Text>().color = new Color(1.0f, 1.0f, 1.0f, player.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<Text>().color.a);
            }
            else if (type == 1) enemy1 = Instantiate(wizardBattle, new Vector3(2.5f, 1.0f, -2.03f), Quaternion.identity);
            enemyNumber += 1;
            enemy1.GetComponent<EnemyTeamScript>().SetNumber(enemyNumber);
        }
        else if (battlePos == 3)
        {
            if (type == 0)
            {
                enemy2 = Instantiate(banditBattle, new Vector3(4.0f, -0.64f, -2.02f), Quaternion.identity); 
                player.GetChild(0).GetChild(0).GetChild(0).GetComponent<RawImage>().color = new Color(1.0f, 1.0f, 1.0f, player.GetChild(0).GetChild(0).GetChild(0).GetComponent<RawImage>().color.a);
                player.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<RawImage>().color = new Color(1.0f, 1.0f, 1.0f, player.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<RawImage>().color.a);
                player.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<Text>().color = new Color(1.0f, 1.0f, 1.0f, player.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<Text>().color.a);
            }
            else if (type == 1) enemy2 = Instantiate(wizardBattle, new Vector3(4.0f, 1.0f, -2.02f), Quaternion.identity);
            enemyNumber += 1;
            enemy2.GetComponent<EnemyTeamScript>().SetNumber(enemyNumber);
        }
        else if (battlePos == 4)
        {
            if (type == 0)
            {
                enemy3 = Instantiate(banditBattle, new Vector3(5.5f, -0.64f, -2.01f), Quaternion.identity);
                player.GetChild(0).GetChild(0).GetChild(0).GetComponent<RawImage>().color = new Color(1.0f, 1.0f, 1.0f, player.GetChild(0).GetChild(0).GetChild(0).GetComponent<RawImage>().color.a);
                player.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<RawImage>().color = new Color(1.0f, 1.0f, 1.0f, player.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<RawImage>().color.a);
                player.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<Text>().color = new Color(1.0f, 1.0f, 1.0f, player.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<Text>().color.a);
            }
            else if (type == 1) enemy3 = Instantiate(wizardBattle, new Vector3(5.5f, 1.0f, -2.01f), Quaternion.identity);
            enemyNumber += 1;
            enemy3.GetComponent<EnemyTeamScript>().SetNumber(enemyNumber);
        }
        else if (battlePos == 5)
        {
            if (type == 0)
            {
                enemy4 = Instantiate(banditBattle, new Vector3(7.0f, -0.64f, -2.0f), Quaternion.identity);
                player.GetChild(0).GetChild(0).GetChild(0).GetComponent<RawImage>().color = new Color(1.0f, 1.0f, 1.0f, player.GetChild(0).GetChild(0).GetChild(0).GetComponent<RawImage>().color.a);
                player.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<RawImage>().color = new Color(1.0f, 1.0f, 1.0f, player.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<RawImage>().color.a);
                player.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<Text>().color = new Color(1.0f, 1.0f, 1.0f, player.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<Text>().color.a);
            }
            else if (type == 1) enemy4 = Instantiate(wizardBattle, new Vector3(7.0f, 1.0f, -2.0f), Quaternion.identity);
            enemyNumber += 1;
            enemy4.GetComponent<EnemyTeamScript>().SetNumber(enemyNumber);
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
        else if (enemyNumber == 3)
        {
            if (enemy1.GetComponent<EnemyTeamScript>().IsGrounded() && enemy1.GetComponent<EnemyTeamScript>().IsAlive())
            {
                if (enemy2.GetComponent<EnemyTeamScript>().IsGrounded() && enemy2.GetComponent<EnemyTeamScript>().IsAlive())
                {
                    if (enemy3.GetComponent<EnemyTeamScript>().IsGrounded() && enemy3.GetComponent<EnemyTeamScript>().IsAlive())
                    {
                        grounded = new Transform[3];
                        grounded[0] = enemy1;
                        grounded[1] = enemy2;
                        grounded[2] = enemy3;
                    }
                    else
                    {
                        grounded = new Transform[2];
                        grounded[0] = enemy1;
                        grounded[1] = enemy2;
                    }
                }
                else
                {
                    if (enemy3.GetComponent<EnemyTeamScript>().IsGrounded() && enemy3.GetComponent<EnemyTeamScript>().IsAlive())
                    {
                        grounded = new Transform[2];
                        grounded[0] = enemy1;
                        grounded[1] = enemy3;
                    }
                    else
                    {
                        grounded = new Transform[1];
                        grounded[0] = enemy1;
                    }                        
                }
            }
            else if (enemy2.GetComponent<EnemyTeamScript>().IsGrounded() && enemy2.GetComponent<EnemyTeamScript>().IsAlive())
            {
                if (enemy3.GetComponent<EnemyTeamScript>().IsGrounded() && enemy3.GetComponent<EnemyTeamScript>().IsAlive())
                {
                    grounded = new Transform[2];
                    grounded[0] = enemy2;
                    grounded[1] = enemy3;
                }
                else
                {
                    grounded = new Transform[1];
                    grounded[0] = enemy2;
                }                    
            }
            else if (enemy3.GetComponent<EnemyTeamScript>().IsGrounded() && enemy3.GetComponent<EnemyTeamScript>().IsAlive())
            {
                grounded = new Transform[1];
                grounded[0] = enemy3;
            }
        }
        else if(enemyNumber == 4)
        {
            if (enemy1.GetComponent<EnemyTeamScript>().IsGrounded() && enemy1.GetComponent<EnemyTeamScript>().IsAlive())
            {
                if (enemy2.GetComponent<EnemyTeamScript>().IsGrounded() && enemy2.GetComponent<EnemyTeamScript>().IsAlive())
                {
                    if (enemy3.GetComponent<EnemyTeamScript>().IsGrounded() && enemy3.GetComponent<EnemyTeamScript>().IsAlive())
                    {
                        if (enemy4.GetComponent<EnemyTeamScript>().IsGrounded() && enemy4.GetComponent<EnemyTeamScript>().IsAlive())
                        {
                            grounded = new Transform[4];
                            grounded[0] = enemy1;
                            grounded[1] = enemy2;
                            grounded[2] = enemy3;
                            grounded[3] = enemy4;
                        }
                        else
                        {
                            grounded = new Transform[3];
                            grounded[0] = enemy1;
                            grounded[1] = enemy2;
                            grounded[2] = enemy3;
                        }                            
                    }
                    else
                    {
                        if (enemy4.GetComponent<EnemyTeamScript>().IsGrounded() && enemy4.GetComponent<EnemyTeamScript>().IsAlive())
                        {
                            grounded = new Transform[3];
                            grounded[0] = enemy1;
                            grounded[1] = enemy2;
                            grounded[2] = enemy4;
                        }
                        else
                        {
                            grounded = new Transform[2];
                            grounded[0] = enemy1;
                            grounded[1] = enemy2;
                        }                            
                    }
                }
                else
                {
                    if (enemy3.GetComponent<EnemyTeamScript>().IsGrounded() && enemy3.GetComponent<EnemyTeamScript>().IsAlive())
                    {
                        if (enemy4.GetComponent<EnemyTeamScript>().IsGrounded() && enemy4.GetComponent<EnemyTeamScript>().IsAlive())
                        {
                            grounded = new Transform[3];
                            grounded[0] = enemy1;
                            grounded[1] = enemy3;
                            grounded[2] = enemy4;
                        }
                        else
                        {
                            grounded = new Transform[2];
                            grounded[0] = enemy1;
                            grounded[1] = enemy3;
                        }                            
                    }
                    else
                    {
                        if (enemy4.GetComponent<EnemyTeamScript>().IsGrounded() && enemy4.GetComponent<EnemyTeamScript>().IsAlive())
                        {
                            grounded = new Transform[2];
                            grounded[0] = enemy1;
                            grounded[1] = enemy4;
                        }
                        else
                        {
                            grounded = new Transform[1];
                            grounded[0] = enemy1;
                        }                            
                    }
                }
            }
            else if (enemy2.GetComponent<EnemyTeamScript>().IsGrounded() && enemy2.GetComponent<EnemyTeamScript>().IsAlive())
            {
                if (enemy3.GetComponent<EnemyTeamScript>().IsGrounded() && enemy3.GetComponent<EnemyTeamScript>().IsAlive())
                {
                    if (enemy4.GetComponent<EnemyTeamScript>().IsGrounded() && enemy4.GetComponent<EnemyTeamScript>().IsAlive())
                    {
                        grounded = new Transform[3];
                        grounded[0] = enemy2;
                        grounded[1] = enemy3;
                        grounded[2] = enemy4;
                    }
                    else
                    {
                        grounded = new Transform[2];
                        grounded[0] = enemy2;
                        grounded[1] = enemy3;
                    }                        
                }
                else
                {
                    if (enemy4.GetComponent<EnemyTeamScript>().IsGrounded() && enemy4.GetComponent<EnemyTeamScript>().IsAlive())
                    {
                        grounded = new Transform[2];
                        grounded[0] = enemy2;
                        grounded[1] = enemy4;
                    }
                    else
                    {
                        grounded = new Transform[1];
                        grounded[0] = enemy2;
                    }
                        
                }
            }
            else if (enemy3.GetComponent<EnemyTeamScript>().IsGrounded() && enemy3.GetComponent<EnemyTeamScript>().IsAlive())
            {
                if (enemy4.GetComponent<EnemyTeamScript>().IsGrounded() && enemy4.GetComponent<EnemyTeamScript>().IsAlive())
                {
                    grounded = new Transform[2];
                    grounded[0] = enemy3;
                    grounded[1] = enemy4;
                }
                else
                {
                    grounded = new Transform[1];
                    grounded[0] = enemy3;
                }                    
            }
            else if (enemy4.GetComponent<EnemyTeamScript>().IsGrounded() && enemy4.GetComponent<EnemyTeamScript>().IsAlive())
            {
                grounded = new Transform[1];
                grounded[0] = enemy4;
            }
        }
        return grounded;
    }

    //Function to get all enemies
    public Transform[] GetAllEnemies()
    {
        Transform[] enemies = null;
        if (enemyNumber == 1 && enemy1.GetComponent<EnemyTeamScript>().IsAlive())
        {
            enemies = new Transform[1];
            enemies[0] = enemy1;
        }
        else if (enemyNumber == 2)
        {
            if (enemy1.GetComponent<EnemyTeamScript>().IsAlive())
            {
                if (enemy2.GetComponent<EnemyTeamScript>().IsAlive())
                {
                    enemies = new Transform[2];
                    enemies[0] = enemy1;
                    enemies[1] = enemy2;
                }
                else
                {
                    enemies = new Transform[1];
                    enemies[0] = enemy1;
                }
            }
            else if (enemy2.GetComponent<EnemyTeamScript>().IsAlive())
            {
                enemies = new Transform[1];
                enemies[0] = enemy2;
            }
        }
        else if (enemyNumber == 3)
        {
            if (enemy1.GetComponent<EnemyTeamScript>().IsAlive())
            {
                if (enemy2.GetComponent<EnemyTeamScript>().IsAlive())
                {
                    if (enemy3.GetComponent<EnemyTeamScript>().IsAlive())
                    {
                        enemies = new Transform[3];
                        enemies[0] = enemy1;
                        enemies[1] = enemy2;
                        enemies[2] = enemy3;
                    }
                    else
                    {
                        enemies = new Transform[2];
                        enemies[0] = enemy1;
                        enemies[1] = enemy2;
                    }
                }
                else
                {
                    if (enemy3.GetComponent<EnemyTeamScript>().IsAlive())
                    {
                        enemies = new Transform[2];
                        enemies[0] = enemy1;
                        enemies[1] = enemy3;
                    }
                    else
                    {
                        enemies = new Transform[1];
                        enemies[0] = enemy1;
                    }
                }
            }
            else if (enemy2.GetComponent<EnemyTeamScript>().IsAlive())
            {
                if (enemy3.GetComponent<EnemyTeamScript>().IsAlive())
                {
                    enemies = new Transform[2];
                    enemies[0] = enemy2;
                    enemies[1] = enemy3;
                }
                else
                {
                    enemies = new Transform[1];
                    enemies[0] = enemy2;
                }
            }
            else if (enemy3.GetComponent<EnemyTeamScript>().IsAlive())
            {
                enemies = new Transform[1];
                enemies[0] = enemy3;
            }
        }
        else if (enemyNumber == 4)
        {
            if (enemy1.GetComponent<EnemyTeamScript>().IsAlive())
            {
                if (enemy2.GetComponent<EnemyTeamScript>().IsAlive())
                {
                    if (enemy3.GetComponent<EnemyTeamScript>().IsAlive())
                    {
                        if (enemy4.GetComponent<EnemyTeamScript>().IsAlive())
                        {
                            enemies = new Transform[4];
                            enemies[0] = enemy1;
                            enemies[1] = enemy2;
                            enemies[2] = enemy3;
                            enemies[3] = enemy4;
                        }
                        else
                        {
                            enemies = new Transform[3];
                            enemies[0] = enemy1;
                            enemies[1] = enemy2;
                            enemies[2] = enemy3;
                        }
                    }
                    else
                    {
                        if (enemy4.GetComponent<EnemyTeamScript>().IsAlive())
                        {
                            enemies = new Transform[3];
                            enemies[0] = enemy1;
                            enemies[1] = enemy2;
                            enemies[2] = enemy4;
                        }
                        else
                        {
                            enemies = new Transform[2];
                            enemies[0] = enemy1;
                            enemies[1] = enemy2;
                        }
                    }
                }
                else
                {
                    if (enemy3.GetComponent<EnemyTeamScript>().IsAlive())
                    {
                        if (enemy4.GetComponent<EnemyTeamScript>().IsAlive())
                        {
                            enemies = new Transform[3];
                            enemies[0] = enemy1;
                            enemies[1] = enemy3;
                            enemies[2] = enemy4;
                        }
                        else
                        {
                            enemies = new Transform[2];
                            enemies[0] = enemy1;
                            enemies[1] = enemy3;
                        }
                    }
                    else
                    {
                        if (enemy4.GetComponent<EnemyTeamScript>().IsAlive())
                        {
                            enemies = new Transform[2];
                            enemies[0] = enemy1;
                            enemies[1] = enemy4;
                        }
                        else
                        {
                            enemies = new Transform[1];
                            enemies[0] = enemy1;
                        }
                    }
                }
            }
            else if (enemy2.GetComponent<EnemyTeamScript>().IsAlive())
            {
                if (enemy3.GetComponent<EnemyTeamScript>().IsAlive())
                {
                    if (enemy4.GetComponent<EnemyTeamScript>().IsAlive())
                    {
                        enemies = new Transform[3];
                        enemies[0] = enemy2;
                        enemies[1] = enemy3;
                        enemies[2] = enemy4;
                    }
                    else
                    {
                        enemies = new Transform[2];
                        enemies[0] = enemy2;
                        enemies[1] = enemy3;
                    }
                }
                else
                {
                    if (enemy4.GetComponent<EnemyTeamScript>().IsAlive())
                    {
                        enemies = new Transform[2];
                        enemies[0] = enemy2;
                        enemies[1] = enemy4;
                    }
                    else
                    {
                        enemies = new Transform[1];
                        enemies[0] = enemy2;
                    }

                }
            }
            else if (enemy3.GetComponent<EnemyTeamScript>().IsAlive())
            {
                if (enemy4.GetComponent<EnemyTeamScript>().IsAlive())
                {
                    enemies = new Transform[2];
                    enemies[0] = enemy3;
                    enemies[1] = enemy4;
                }
                else
                {
                    enemies = new Transform[1];
                    enemies[0] = enemy3;
                }
            }
            else if (enemy4.GetComponent<EnemyTeamScript>().IsAlive())
            {
                enemies = new Transform[1];
                enemies[0] = enemy4;
            }
        }
        return enemies;
    }
    //Function to deal damage to an enemy, giving the enemy, the amount of damage and a boolean that says if it is the last attack
    public void DealDamage(Transform objective, int damage, bool last)
    {
        if(playerTurn && player.GetComponent<PlayerTeamScript>().HasLifesteal()) player.GetComponent<PlayerTeamScript>().Heal(damage, false,false, true, true);
        if (companionTurn && companion.GetComponent<PlayerTeamScript>().HasLifesteal()) companion.GetComponent<PlayerTeamScript>().Heal(damage, false, false, true, true);
        //We instantiate the damage UI and save the damage amount
        damageImage = Instantiate(damageUI, new Vector3(objective.transform.position.x -0.25f, objective.transform.position.y + 1.0f, objective.transform.position.z), Quaternion.identity, objective.transform.GetChild(0));
        damageImage.GetChild(0).GetComponent<Text>().text = damage.ToString();
        //We deal damage to the objective
        objective.transform.GetChild(0).transform.GetChild(2).GetComponent<EnemyLifeControllerScript>().DealDamage(damage);
        //if the enemy is dead and it is the last attack we play the die animation, else we play the damage animation
        if(objective.transform.GetChild(0).transform.GetChild(2).GetComponent<EnemyLifeControllerScript>().GetHealth() <= 0 && last)
        {
            if(!objective.GetComponent<EnemyTeamScript>().IsGrounded()) objective.GetComponent<EnemyTeamScript>().EnemyDied();
            objective.GetComponent<Animator>().SetBool("IsDead", true);
            objective.GetChild(0).transform.GetChild(2).gameObject.SetActive(false);
        }
        else
        {
            objective.GetComponent<Animator>().SetTrigger("TakeDamage");
        }
    }

    //Function to get the defense of the player
    public int GetDefense(int type)
    {
        if (type == 0) return defensePlayer;
        else return defenseCompanion;
    }
    //Functions to add one to the regeneration heal and light increase values
    public void IncreaseRegenerationHeal()
    {
        soulRegenHeal += 1;
    }
    public void IncreaseRegenerationLight()
    {
        soulRegenLight += 1;
    }

    //Functions to end the regeneration attack
    public void EndRegenerationAttack()
    {
        soulRegenMovUp = false;
        soulRegenMovLeft = false;
        soulRegenMovRight = false;
        soulRegenMovDown = false;
        soulRegenRingSpeed = 0.03f;
        soulRegenGreenSpeed = 0.075f;
        player.GetComponent<PlayerTeamScript>().Heal(soulRegenHeal/2, true, firstPosPlayer, true, true);
        companion.GetComponent<PlayerTeamScript>().Heal(soulRegenHeal / 2, false, !firstPosPlayer, false, true);
        player.GetComponent<PlayerTeamScript>().IncreaseLight(soulRegenLight/2, true, true, true);
        soulRegenHeal = 0;
        soulRegenLight = 0;
        actionInstructions.SetActive(false);
        Destroy(ring1[0].gameObject);
        Destroy(ring1[1].gameObject);
        Destroy(ring2[0].gameObject);
        Destroy(ring2[1].gameObject);
        Destroy(ring3[0].gameObject);
        Destroy(ring3[1].gameObject);
        Destroy(ring4[0].gameObject);
        Destroy(ring4[1].gameObject);
        Destroy(ring5[0].gameObject);
        Destroy(ring5[1].gameObject);
        Destroy(ring6[0].gameObject);
        Destroy(ring6[1].gameObject);
        Destroy(ring7[0].gameObject);
        Destroy(ring7[1].gameObject);
        Destroy(ring8[0].gameObject);
        Destroy(ring8[1].gameObject);
        Destroy(greenSoul.gameObject);
        soulRegen = false;
        player.GetComponent<PlayerTeamScript>().EndRegenerationAttack();
    }

    public void EndSoulRegenerationAttack()
    {
        finalAttack = false;
        EndPlayerTurn(1);
    }

    //Functions to end the lightning attack
    public void EndLightningAttack()
    {
        yellowSoulRight = true;
        actionInstructions.SetActive(false);
        soulLightning = false;
        Destroy(yellowSoul.gameObject);
        player.GetComponent<PlayerTeamScript>().EndLightningAttack();
    }

    public void EndSoulLightningAttack()
    {
        finalAttack = false;
        EndPlayerTurn(1);
    }
    //Functions to end the disappear attack
    public void EndDisappearAttack()
    {
        player.GetComponent<PlayerTeamScript>().SetDisappearTime(blueSoul.GetComponent<Image>().color.a);
        player.GetComponent<PlayerTeamScript>().HideBuffDebuff();
        actionInstructions.SetActive(false);
        soulDisappear = false;
        Destroy(blueSoul.gameObject);
        Destroy(wall1.gameObject);
        Destroy(wall2.gameObject);
        Destroy(wall3.gameObject);
        Destroy(wall4.gameObject);
        Destroy(wall5.gameObject);
        player.GetComponent<PlayerTeamScript>().EndDisappearAttack();
    }
    public void EndSoulDisappearAttack()
    {
        finalAttack = false;        
        EndPlayerTurn(1);
    }
    //Function to change the position of the player team. 1-> player, 2-> companion
    private void StartChangePosition(int user)
    {
        changePosAction.SetActive(false);
        if (user == 1)
        {
            player.GetComponent<Animator>().SetFloat("Speed", 0.5f);
            player.GetComponent<Animator>().SetFloat("attackSpeed", -2.0f);
            companion.GetComponent<Animator>().SetFloat("Speed", 1.0f);
            companion.GetComponent<Animator>().SetFloat("RunSpeed", 0.5f);            
            changePos = true;
            playerChoosingAction = false;
            player.GetChild(0).GetChild(0).GetComponent<Animator>().SetBool("Active", false);
        }
        else if(user == 2)
        {
            player.GetComponent<Animator>().SetFloat("Speed", 0.5f);
            player.GetComponent<Animator>().SetFloat("attackSpeed", 2.0f);
            companion.GetComponent<Animator>().SetFloat("Speed", -1.0f);
            companion.GetComponent<Animator>().SetFloat("RunSpeed", 0.5f);
            changePos = true;
            companionChoosingAction = false;
            companion.GetChild(0).GetChild(0).GetComponent<Animator>().SetBool("Active", false);
        }
    }

    private void EndChangePosition(int user)
    {
        changePosAction.SetActive(true);
        if (user == 1)
        {
            player.GetComponent<Animator>().SetFloat("Speed", 0.0f);
            player.GetComponent<Animator>().SetFloat("attackSpeed", 1.0f);
            companion.GetComponent<Animator>().SetFloat("Speed", 1.0f);
            companion.GetComponent<Animator>().SetFloat("RunSpeed", 0.0f);
            changePos = false;
            firstPosPlayer = false;
            playerTurn = false;
            companionTurn = true;
            companionChoosingAction = true;
            player.position = new Vector3(-6.4f, player.position.y, -2.05f);
            companion.position = new Vector3(-5.0f, companion.position.y, -2.04f);
            companion.GetChild(0).GetChild(0).GetComponent<Animator>().SetBool("Active", true);
        }
        else if (user == 2)
        {
            player.GetComponent<Animator>().SetFloat("Speed", 0.0f);
            player.GetComponent<Animator>().SetFloat("attackSpeed", 1.0f);
            companion.GetComponent<Animator>().SetFloat("Speed", 1.0f);
            companion.GetComponent<Animator>().SetFloat("RunSpeed", 0.0f);
            changePos = false;
            firstPosPlayer = true;
            companionTurn = false;
            playerTurn = true;
            playerChoosingAction = true;
            player.position = new Vector3(-5.0f, player.position.y, -2.05f);
            companion.position = new Vector3(-6.4f, companion.position.y, -2.04f);
            player.GetChild(0).GetChild(0).GetComponent<Animator>().SetBool("Active", true);
        }
    }

    //A function to end players turn. User-->1 player, User-->2 companion
    public void EndPlayerTurn(int user)
    {
        if(GetAllEnemies() != null)
        {
            if (GetGroundEnemies() == null)
            {
                player.GetChild(0).GetChild(0).GetChild(0).GetComponent<RawImage>().color = new Color(0.4f, 0.4f, 0.4f, player.GetChild(0).GetChild(0).GetChild(0).GetComponent<RawImage>().color.a);
                player.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<RawImage>().color = new Color(0.4f, 0.4f, 0.4f, player.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<RawImage>().color.a);
                player.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<Text>().color = new Color(0.4f, 0.4f, 0.4f, player.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<Text>().color.a);
            }
            if (user == 1) playerTurnCompleted = true;
            else if (user == 2) companionTurnCompleted = true;
            if (playerTurnCompleted && companionTurnCompleted)
            {
                player.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, player.GetComponent<SpriteRenderer>().color.a);
                companion.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, companion.GetComponent<SpriteRenderer>().color.a);
                player.GetComponent<PlayerTeamScript>().ShowBuffDebuff();
                player.GetComponent<PlayerTeamScript>().RestBuffDebuff();
                companion.GetComponent<PlayerTeamScript>().ShowBuffDebuff();
                companion.GetComponent<PlayerTeamScript>().RestBuffDebuff();
                canvas.GetComponent<Animator>().SetBool("Hide", false);
                playerChoosingAction = true;
                playerTeamTurn = false;
                playerTurnCompleted = false;
                companionTurnCompleted = false;
                if (playerTurn)
                {
                    if (!firstPosPlayer && attackType == 2) player.GetChild(0).transform.position = new Vector3(player.GetChild(0).transform.position.x - 1.4f, player.GetChild(0).transform.position.y, player.GetChild(0).transform.position.z);
                    playerTurn = false;
                    companionTurn = true;
                }
                else if (companionTurn)
                {
                    playerTurn = true;
                    companionTurn = false;
                }
                enemyTeamTurn = true;
                enemy1Turn = true;
            }
            else if (playerTurnCompleted && !companionTurnCompleted)
            {
                if (!firstPosPlayer && attackType == 2) player.GetChild(0).transform.position = new Vector3(player.GetChild(0).transform.position.x - 1.4f, player.GetChild(0).transform.position.y, player.GetChild(0).transform.position.z);
                player.GetComponent<SpriteRenderer>().color = new Color(0.2f, 0.2f, 0.2f, player.GetComponent<SpriteRenderer>().color.a);
                canvas.GetComponent<Animator>().SetBool("Hide", false);
                player.GetComponent<PlayerTeamScript>().ShowBuffDebuff();
                companion.GetComponent<PlayerTeamScript>().ShowBuffDebuff();
                playerTurn = false;
                companionTurn = true;
                companionChoosingAction = true;
                companion.GetChild(0).GetChild(0).GetComponent<Animator>().SetBool("Active", true);
            }
            else if (!playerTurnCompleted && companionTurnCompleted)
            {
                companion.GetComponent<SpriteRenderer>().color = new Color(0.2f, 0.2f, 0.2f, companion.GetComponent<SpriteRenderer>().color.a);
                canvas.GetComponent<Animator>().SetBool("Hide", false);
                player.GetComponent<PlayerTeamScript>().ShowBuffDebuff();
                companion.GetComponent<PlayerTeamScript>().ShowBuffDebuff();
                playerTurn = true;
                playerChoosingAction = true;
                companionTurn = false;
                player.GetChild(0).GetChild(0).GetComponent<Animator>().SetBool("Active", true);
            }
        }
        else
        {
            player.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, player.GetComponent<SpriteRenderer>().color.a);
            companion.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, companion.GetComponent<SpriteRenderer>().color.a);
            canvas.GetComponent<Animator>().SetBool("Hide", false);
            mainCamera.GetComponent<CameraScript>().ChangeCameraState(1);
            xpObject.SetActive(false);
            victoryXP.transform.GetChild(18).GetComponent<Image>().color = new Color(1.0f,1.0f,1.0f,0.4f);
            victoryXP.transform.GetChild(19).gameObject.SetActive(true);
            victoryXP.transform.GetChild(20).gameObject.SetActive(true);
            victoryXP.transform.GetChild(21).gameObject.SetActive(true);
            victoryXP.transform.GetChild(21).GetComponent<Text>().text = currentFightXP.ToString();
            playerTeamTurn = false;
            playerTurnCompleted = false;
            companionTurnCompleted = false;
            victory = true;
            ShowVictoryXP();
            player.GetComponent<Animator>().SetTrigger("Victory");
            companion.GetComponent<Animator>().SetTrigger("Victory");
        }
    }

    //A function to end enemy turn
    public void EndEnemyTurn()
    {
        defensePlayer = 0;
        defenseCompanion = 0;
        changePosAction.SetActive(true);
        playerTeamTurn = true;
        if (firstPosPlayer)
        {
            player.GetChild(0).transform.GetChild(0).GetComponent<Animator>().SetBool("Active", true);
            companionTurn = false;
            companionChoosingAction = false;
            playerTurn = true;
            playerChoosingAction = true;
        }
        else
        {
            companion.GetChild(0).transform.GetChild(0).GetComponent<Animator>().SetBool("Active", true);
            playerTurn = false;
            playerChoosingAction = false;
            companionTurn = true;
            companionChoosingAction = true;
        }
        enemyTeamTurn = false;
    }
    //Function to get the aim rotation
    public float GetAimRotation()
    {
        return aimRotation;
    }

    //A function to pass the turn to the next enemy
    public void NextEnemy(int numb)
    {
        if(numb == 1)
        {
            enemy2Turn = true;
        }
        else if (numb == 2)
        {
            enemy3Turn = true;
        }
        else if (numb == 3)
        {
            enemy4Turn = true;
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

    //Function to start a soul attack
    public void StartSoulMusicAttack(int lvl)
    {
        int actualLvl = lvl;
        if (actualLvl > 4) actualLvl = 4;
        player.GetChild(0).transform.GetChild(7).transform.GetChild(1).GetComponent<Image>().fillAmount = 0.0f;
        float key1pos = Random.Range(-4.75f, -4.75f + (10.0f/(actualLvl + 3)));
        key1 = Instantiate(keyPrefab, new Vector3(0.0f, player.GetChild(0).transform.GetChild(7).transform.position.y, player.GetChild(0).transform.GetChild(7).transform.position.z), Quaternion.identity, player.GetChild(0).transform.GetChild(7).transform);
        key1.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(key1pos, 0.0f, 0.0f);
        key1Input = Random.Range(0, 4);
        if(key1Input == 0) key1.GetComponent<Image>().sprite = upArrowSprite;
        if (key1Input == 1) key1.GetComponent<Image>().sprite = leftArrowSprite;
        if (key1Input == 2) key1.GetComponent<Image>().sprite = rightArrowSprite;
        if (key1Input == 3) key1.GetComponent<Image>().sprite = downArrowSprite;
        key1.GetComponent<Image>().color = new Vector4(0.4f, 0.4f, 0.4f, 1.0f);
        key1Cover = Instantiate(keyPrefab, new Vector3(0.0f, player.GetChild(0).transform.GetChild(7).transform.position.y, player.GetChild(0).transform.GetChild(7).transform.position.z), Quaternion.identity, player.GetChild(0).transform.GetChild(7).transform);
        key1Cover.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(key1pos, 0.0f, 0.0f);
        float key2pos = Random.Range(key1pos + 1.0f, -5.0f + (10.0f / (actualLvl + 3)) * 2);
        key2 = Instantiate(keyPrefab, new Vector3(0.0f, player.GetChild(0).transform.GetChild(7).transform.position.y, player.GetChild(0).transform.GetChild(7).transform.position.z), Quaternion.identity, player.GetChild(0).transform.GetChild(7).transform);
        key2.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(key2pos, 0.0f, 0.0f);
        key2Input = Random.Range(0, 4);
        if (key2Input == 0) key2.GetComponent<Image>().sprite = upArrowSprite;
        if (key2Input == 1) key2.GetComponent<Image>().sprite = leftArrowSprite;
        if (key2Input == 2) key2.GetComponent<Image>().sprite = rightArrowSprite;
        if (key2Input == 3) key2.GetComponent<Image>().sprite = downArrowSprite;
        key2.GetComponent<Image>().color = new Vector4(0.4f, 0.4f, 0.4f, 1.0f);
        key2Cover = Instantiate(keyPrefab, new Vector3(0.0f, player.GetChild(0).transform.GetChild(7).transform.position.y, player.GetChild(0).transform.GetChild(7).transform.position.z), Quaternion.identity, player.GetChild(0).transform.GetChild(7).transform);
        key2Cover.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(key2pos, 0.0f, 0.0f);
        float key3pos = Random.Range(key2pos + 1.0f, -5.0f + (10.0f / (actualLvl + 3)) * 3);
        key3 = Instantiate(keyPrefab, new Vector3(0.0f, player.GetChild(0).transform.GetChild(7).transform.position.y, player.GetChild(0).transform.GetChild(7).transform.position.z), Quaternion.identity, player.GetChild(0).transform.GetChild(7).transform);
        key3.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(key3pos, 0.0f, 0.0f);
        key3Input = Random.Range(0, 4);
        if (key3Input == 0) key3.GetComponent<Image>().sprite = upArrowSprite;
        if (key3Input == 1) key3.GetComponent<Image>().sprite = leftArrowSprite;
        if (key3Input == 2) key3.GetComponent<Image>().sprite = rightArrowSprite;
        if (key3Input == 3) key3.GetComponent<Image>().sprite = downArrowSprite;
        key3.GetComponent<Image>().color = new Vector4(0.4f, 0.4f, 0.4f, 1.0f);
        key3Cover = Instantiate(keyPrefab, new Vector3(0.0f, player.GetChild(0).transform.GetChild(7).transform.position.y, player.GetChild(0).transform.GetChild(7).transform.position.z), Quaternion.identity, player.GetChild(0).transform.GetChild(7).transform);
        key3Cover.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(key3pos, 0.0f, 0.0f);
        float key4pos = Random.Range(key3pos + 1.0f, -5.0f + (10.0f / (actualLvl + 3)) * 4);
        key4 = Instantiate(keyPrefab, new Vector3(0.0f, player.GetChild(0).transform.GetChild(7).transform.position.y, player.GetChild(0).transform.GetChild(7).transform.position.z), Quaternion.identity, player.GetChild(0).transform.GetChild(7).transform);
        key4.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(key4pos, 0.0f, 0.0f);
        key4Input = Random.Range(0, 4);
        if (key4Input == 0) key4.GetComponent<Image>().sprite = upArrowSprite;
        if (key4Input == 1) key4.GetComponent<Image>().sprite = leftArrowSprite;
        if (key4Input == 2) key4.GetComponent<Image>().sprite = rightArrowSprite;
        if (key4Input == 3) key4.GetComponent<Image>().sprite = downArrowSprite;
        key4.GetComponent<Image>().color = new Vector4(0.4f, 0.4f, 0.4f, 1.0f);
        key4Cover = Instantiate(keyPrefab, new Vector3(0.0f, player.GetChild(0).transform.GetChild(7).transform.position.y, player.GetChild(0).transform.GetChild(7).transform.position.z), Quaternion.identity, player.GetChild(0).transform.GetChild(7).transform);
        key4Cover.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(key4pos, 0.0f, 0.0f);
        if (actualLvl > 1)
        {
            float key5pos = Random.Range(key4pos + 1.0f, -5.0f + (10.0f / (actualLvl + 3)) * 5);
            key5 = Instantiate(keyPrefab, new Vector3(0.0f, player.GetChild(0).transform.GetChild(7).transform.position.y, player.GetChild(0).transform.GetChild(7).transform.position.z), Quaternion.identity, player.GetChild(0).transform.GetChild(7).transform);
            key5.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(key5pos, 0.0f, 0.0f);
            key5Input = Random.Range(0, 4);
            if (key5Input == 0) key5.GetComponent<Image>().sprite = upArrowSprite;
            if (key5Input == 1) key5.GetComponent<Image>().sprite = leftArrowSprite;
            if (key5Input == 2) key5.GetComponent<Image>().sprite = rightArrowSprite;
            if (key5Input == 3) key5.GetComponent<Image>().sprite = downArrowSprite;
            key5.GetComponent<Image>().color = new Vector4(0.4f, 0.4f, 0.4f, 1.0f);
            key5Cover = Instantiate(keyPrefab, new Vector3(0.0f, player.GetChild(0).transform.GetChild(7).transform.position.y, player.GetChild(0).transform.GetChild(7).transform.position.z), Quaternion.identity, player.GetChild(0).transform.GetChild(7).transform);
            key5Cover.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(key5pos, 0.0f, 0.0f);
            if (actualLvl > 2)
            {
                float key6pos = Random.Range(key5pos + 1.0f, -5.0f + (10.0f / (actualLvl + 3)) * 6);
                key6 = Instantiate(keyPrefab, new Vector3(0.0f, player.GetChild(0).transform.GetChild(7).transform.position.y, player.GetChild(0).transform.GetChild(7).transform.position.z), Quaternion.identity, player.GetChild(0).transform.GetChild(7).transform);
                key6.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(key6pos, 0.0f, 0.0f);
                key6Input = Random.Range(0, 4);
                if (key6Input == 0) key6.GetComponent<Image>().sprite = upArrowSprite;
                if (key6Input == 1) key6.GetComponent<Image>().sprite = leftArrowSprite;
                if (key6Input == 2) key6.GetComponent<Image>().sprite = rightArrowSprite;
                if (key6Input == 3) key6.GetComponent<Image>().sprite = downArrowSprite;
                key6.GetComponent<Image>().color = new Vector4(0.4f, 0.4f, 0.4f, 1.0f);
                key6Cover = Instantiate(keyPrefab, new Vector3(0.0f, player.GetChild(0).transform.GetChild(7).transform.position.y, player.GetChild(0).transform.GetChild(7).transform.position.z), Quaternion.identity, player.GetChild(0).transform.GetChild(7).transform);
                key6Cover.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(key6pos, 0.0f, 0.0f);
                if (actualLvl > 3)
                {
                    float key7pos = Random.Range(key6pos + 1.0f, -5.0f + (10.0f / (actualLvl + 3)) * 7);
                    key7 = Instantiate(keyPrefab, new Vector3(0.0f, player.GetChild(0).transform.GetChild(7).transform.position.y, player.GetChild(0).transform.GetChild(7).transform.position.z), Quaternion.identity, player.GetChild(0).transform.GetChild(7).transform);
                    key7.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(key7pos, 0.0f, 0.0f);
                    key7Input = Random.Range(0, 4);
                    if (key7Input == 0) key7.GetComponent<Image>().sprite = upArrowSprite;
                    if (key7Input == 1) key7.GetComponent<Image>().sprite = leftArrowSprite;
                    if (key7Input == 2) key7.GetComponent<Image>().sprite = rightArrowSprite;
                    if (key7Input == 3) key7.GetComponent<Image>().sprite = downArrowSprite;
                    key7.GetComponent<Image>().color = new Vector4(0.4f, 0.4f, 0.4f, 1.0f);
                    key7Cover = Instantiate(keyPrefab, new Vector3(0.0f, player.GetChild(0).transform.GetChild(7).transform.position.y, player.GetChild(0).transform.GetChild(7).transform.position.z), Quaternion.identity, player.GetChild(0).transform.GetChild(7).transform);
                    key7Cover.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(key7pos, 0.0f, 0.0f);
                }
            }            
        }

        soulMusic = lvl;
        finalAttack = true;
    }

    //Function to end the soul music attack
    public void EndSoulAttack(int lvl)
    {
        Transform[] enemies = GetAllEnemies();
        for(int i = 0; i < enemies.Length; i++)
        {
            enemies[i].GetComponent<EnemyTeamScript>().SetAsleepTime(lvl);
        }
        soulMusic = 0;
        finalAttack = false;
        EndPlayerTurn(1);
    }
    
    //Function to start the regeneration attack
    public void StartRegenerationAttack()
    {
        float randx = Random.Range(-5.0f,5.0f);
        float randc = Random.Range(0.0f, 1.0f);
        if (randc < 0.5f) ring1[0] = Instantiate(redRingBck, regenerationAction.transform);
        else ring1[0] = Instantiate(yellowRingBck, regenerationAction.transform);
        ring1[0].GetComponent<RectTransform>().anchoredPosition = new Vector2(randx, -5.0f);
        if (randx < -2.0f) randx = -2.0f;
        else if (randx > 2.0f) randx = 2.0f;
        randx = Random.Range(randx-3.0f, randx+3.0f);
        randc = Random.Range(0.0f, 1.0f);
        if(randc < 0.5f) ring2[0] = Instantiate(redRingBck, regenerationAction.transform);
        else ring2[0] = Instantiate(yellowRingBck, regenerationAction.transform);
        ring2[0].GetComponent<RectTransform>().anchoredPosition = new Vector2(randx, -6.0f);
        if (randx < -2.0f) randx = -2.0f;
        else if (randx > 2.0f) randx = 2.0f;
        randx = Random.Range(randx - 3.0f, randx + 3.0f);
        randc = Random.Range(0.0f, 1.0f);
        if(randc < 0.5f) ring3[0] = Instantiate(redRingBck, regenerationAction.transform);
        else ring3[0] = Instantiate(yellowRingBck, regenerationAction.transform);
        ring3[0].GetComponent<RectTransform>().anchoredPosition = new Vector2(randx, -7.0f);
        if (randx < -2.0f) randx = -2.0f;
        else if (randx > 2.0f) randx = 2.0f;
        randx = Random.Range(randx - 3.0f, randx + 3.0f);
        randc = Random.Range(0.0f, 1.0f);
        if(randc < 0.5f) ring4[0] = Instantiate(redRingBck, regenerationAction.transform);
        else ring4[0] = Instantiate(yellowRingBck, regenerationAction.transform);
        ring4[0].GetComponent<RectTransform>().anchoredPosition = new Vector2(randx, -8.0f);
        if (randx < -2.0f) randx = -2.0f;
        else if (randx > 2.0f) randx = 2.0f;
        randx = Random.Range(randx - 3.0f, randx + 3.0f);
        randc = Random.Range(0.0f, 1.0f);
        if(randc < 0.5f) ring5[0] = Instantiate(redRingBck, regenerationAction.transform);
        else ring5[0] = Instantiate(yellowRingBck, regenerationAction.transform);
        ring5[0].GetComponent<RectTransform>().anchoredPosition = new Vector2(randx, -9.0f);
        if (randx < -2.0f) randx = -2.0f;
        else if (randx > 2.0f) randx = 2.0f;
        randx = Random.Range(randx - 3.0f, randx + 3.0f);
        randc = Random.Range(0.0f, 1.0f);
        if(randc < 0.5f) ring6[0] = Instantiate(redRingBck, regenerationAction.transform);
        else ring6[0] = Instantiate(yellowRingBck, regenerationAction.transform);
        ring6[0].GetComponent<RectTransform>().anchoredPosition = new Vector2(randx, -10.0f);
        if (randx < -2.0f) randx = -2.0f;
        else if (randx > 2.0f) randx = 2.0f;
        randx = Random.Range(randx - 3.0f, randx + 3.0f);
        randc = Random.Range(0.0f, 1.0f);
        if(randc < 0.5f) ring7[0] = Instantiate(redRingBck, regenerationAction.transform);
        else ring7[0] = Instantiate(yellowRingBck, regenerationAction.transform);
        ring7[0].GetComponent<RectTransform>().anchoredPosition = new Vector2(randx, -11.0f);
        if (randx < -2.0f) randx = -2.0f;
        else if (randx > 2.0f) randx = 2.0f;
        randx = Random.Range(randx - 3.0f, randx + 3.0f);
        randc = Random.Range(0.0f, 1.0f);
        if (randc < 0.5f) ring8[0] = Instantiate(redRingBck, regenerationAction.transform);
        else ring8[0] = Instantiate(yellowRingBck, regenerationAction.transform);
        ring8[0].GetComponent<RectTransform>().anchoredPosition = new Vector2(randx, -12.0f);
        greenSoul = Instantiate(greenSoulPrefab, regenerationAction.transform);
        greenSoul.GetComponent<RectTransform>().anchoredPosition = new Vector2(0.0f, 0.0f);
        ring1[1] = Instantiate(RingFront, regenerationAction.transform);
        if (ring1[0].tag == "RedRing") ring1[1].GetComponent<RingScript>().SetColor(true);
        else ring1[1].GetComponent<RingScript>().SetColor(false);
        ring1[1].GetComponent<RingScript>().SetTopRing(ring1[0]);
        ring1[1].GetComponent<RingScript>().SetPrevRing(ring8[0]);
        ring1[1].GetComponent<RectTransform>().anchoredPosition = new Vector2(ring1[0].GetComponent<RectTransform>().anchoredPosition.x, ring1[0].GetComponent<RectTransform>().anchoredPosition.y + 0.009f);
        ring2[1] = Instantiate(RingFront, regenerationAction.transform);
        if (ring2[0].tag == "RedRing") ring2[1].GetComponent<RingScript>().SetColor(true);
        else ring2[1].GetComponent<RingScript>().SetColor(false);
        ring2[1].GetComponent<RingScript>().SetTopRing(ring2[0]);
        ring2[1].GetComponent<RingScript>().SetPrevRing(ring1[0]);
        ring2[1].GetComponent<RectTransform>().anchoredPosition = new Vector2(ring2[0].GetComponent<RectTransform>().anchoredPosition.x, ring2[0].GetComponent<RectTransform>().anchoredPosition.y + 0.009f);
        ring3[1] = Instantiate(RingFront, regenerationAction.transform);
        if (ring3[0].tag == "RedRing") ring3[1].GetComponent<RingScript>().SetColor(true);
        else ring3[1].GetComponent<RingScript>().SetColor(false);
        ring3[1].GetComponent<RingScript>().SetTopRing(ring3[0]);
        ring3[1].GetComponent<RingScript>().SetPrevRing(ring2[0]);
        ring3[1].GetComponent<RectTransform>().anchoredPosition = new Vector2(ring3[0].GetComponent<RectTransform>().anchoredPosition.x, ring3[0].GetComponent<RectTransform>().anchoredPosition.y + 0.009f);
        ring4[1] = Instantiate(RingFront, regenerationAction.transform);
        if (ring4[0].tag == "RedRing") ring4[1].GetComponent<RingScript>().SetColor(true);
        else ring4[1].GetComponent<RingScript>().SetColor(false);
        ring4[1].GetComponent<RingScript>().SetTopRing(ring4[0]);
        ring4[1].GetComponent<RingScript>().SetPrevRing(ring3[0]);
        ring4[1].GetComponent<RectTransform>().anchoredPosition = new Vector2(ring4[0].GetComponent<RectTransform>().anchoredPosition.x, ring4[0].GetComponent<RectTransform>().anchoredPosition.y + 0.009f);
        ring5[1] = Instantiate(RingFront, regenerationAction.transform);
        if (ring5[0].tag == "RedRing") ring5[1].GetComponent<RingScript>().SetColor(true);
        else ring5[1].GetComponent<RingScript>().SetColor(false);
        ring5[1].GetComponent<RingScript>().SetTopRing(ring5[0]);
        ring5[1].GetComponent<RingScript>().SetPrevRing(ring4[0]);
        ring5[1].GetComponent<RectTransform>().anchoredPosition = new Vector2(ring5[0].GetComponent<RectTransform>().anchoredPosition.x, ring5[0].GetComponent<RectTransform>().anchoredPosition.y + 0.009f);
        ring6[1] = Instantiate(RingFront, regenerationAction.transform);
        if (ring6[0].tag == "RedRing") ring6[1].GetComponent<RingScript>().SetColor(true);
        else ring6[1].GetComponent<RingScript>().SetColor(false);
        ring6[1].GetComponent<RingScript>().SetTopRing(ring6[0]);
        ring6[1].GetComponent<RingScript>().SetPrevRing(ring5[0]);
        ring6[1].GetComponent<RectTransform>().anchoredPosition = new Vector2(ring6[0].GetComponent<RectTransform>().anchoredPosition.x, ring6[0].GetComponent<RectTransform>().anchoredPosition.y + 0.009f);
        ring7[1] = Instantiate(RingFront, regenerationAction.transform);
        if (ring7[0].tag == "RedRing") ring7[1].GetComponent<RingScript>().SetColor(true);
        else ring7[1].GetComponent<RingScript>().SetColor(false);
        ring7[1].GetComponent<RingScript>().SetTopRing(ring7[0]);
        ring7[1].GetComponent<RingScript>().SetPrevRing(ring6[0]);
        ring7[1].GetComponent<RectTransform>().anchoredPosition = new Vector2(ring7[0].GetComponent<RectTransform>().anchoredPosition.x, ring7[0].GetComponent<RectTransform>().anchoredPosition.y + 0.009f);
        ring8[1] = Instantiate(RingFront, regenerationAction.transform);
        if (ring8[0].tag == "RedRing") ring8[1].GetComponent<RingScript>().SetColor(true);
        else ring8[1].GetComponent<RingScript>().SetColor(false);
        ring8[1].GetComponent<RingScript>().SetTopRing(ring8[0]);
        ring8[1].GetComponent<RingScript>().SetPrevRing(ring7[0]);
        ring8[1].GetComponent<RectTransform>().anchoredPosition = new Vector2(ring8[0].GetComponent<RectTransform>().anchoredPosition.x, ring8[0].GetComponent<RectTransform>().anchoredPosition.y + 0.009f);
        finalAttack = true;
        soulRegen = true;
    }
    //A function to start the lightning attack
    public void StartLightningAttack()
    {
        yellowSoul = Instantiate(yellowSoulPrefab, lightningAction.transform);
        yellowSoul.position = new Vector3(player.position.x, 3.5f, player.position.z);
        finalAttack = true;
        soulLightning = true;
    }
    //A function to start the lifesteal attack
    public void StartLifestealAttack()
    {
        float randx = Random.Range(-5.0f, 5.0f);
        redSoul1 = Instantiate(redSoulPrefab, lifestealAction.transform);
        redSoul1.GetComponent<RectTransform>().anchoredPosition = new Vector2(randx, 3.0f);
        if (randx < -2.0f) randx = -2.0f;
        else if (randx > 2.0f) randx = 2.0f;
        randx = Random.Range(randx - 3.0f, randx + 3.0f);
        redSoul2 = Instantiate(redSoulPrefab, lifestealAction.transform);
        redSoul2.GetComponent<RectTransform>().anchoredPosition = new Vector2(randx, 4.1f);
        if (randx < -2.0f) randx = -2.0f;
        else if (randx > 2.0f) randx = 2.0f;
        randx = Random.Range(randx - 3.0f, randx + 3.0f);
        redSoul3 = Instantiate(redSoulPrefab, lifestealAction.transform);
        redSoul3.GetComponent<RectTransform>().anchoredPosition = new Vector2(randx, 5.2f);
        if (randx < -2.0f) randx = -2.0f;
        else if (randx > 2.0f) randx = 2.0f;
        randx = Random.Range(randx - 3.0f, randx + 3.0f);
        redSoul4 = Instantiate(redSoulPrefab, lifestealAction.transform);
        redSoul4.GetComponent<RectTransform>().anchoredPosition = new Vector2(randx, 6.3f);
        if (randx < -2.0f) randx = -2.0f;
        else if (randx > 2.0f) randx = 2.0f;
        randx = Random.Range(randx - 3.0f, randx + 3.0f);
        redSoul5 = Instantiate(redSoulPrefab, lifestealAction.transform);
        redSoul5.GetComponent<RectTransform>().anchoredPosition = new Vector2(randx, 7.4f);
        if (randx < -2.0f) randx = -2.0f;
        else if (randx > 2.0f) randx = 2.0f;
        randx = Random.Range(randx - 3.0f, randx + 3.0f);
        redSoul6 = Instantiate(redSoulPrefab, lifestealAction.transform);
        redSoul6.GetComponent<RectTransform>().anchoredPosition = new Vector2(randx, 8.5f);
        if (randx < -2.0f) randx = -2.0f;
        else if (randx > 2.0f) randx = 2.0f;
        randx = Random.Range(randx - 3.0f, randx + 3.0f);
        redSoul7 = Instantiate(redSoulPrefab, lifestealAction.transform);
        redSoul7.GetComponent<RectTransform>().anchoredPosition = new Vector2(randx, 9.6f);
        if (randx < -2.0f) randx = -2.0f;
        else if (randx > 2.0f) randx = 2.0f;
        randx = Random.Range(randx - 3.0f, randx + 3.0f);
        redSoul8 = Instantiate(redSoulPrefab, lifestealAction.transform);
        redSoul8.GetComponent<RectTransform>().anchoredPosition = new Vector2(randx, 10.7f);
        if (randx < -2.0f) randx = -2.0f;
        else if (randx > 2.0f) randx = 2.0f;
        randx = Random.Range(randx - 3.0f, randx + 3.0f);
        redSoul9 = Instantiate(redSoulPrefab, lifestealAction.transform);
        redSoul9.GetComponent<RectTransform>().anchoredPosition = new Vector2(randx, 11.8f);
        if (randx < -2.0f) randx = -2.0f;
        else if (randx > 2.0f) randx = 2.0f;
        randx = Random.Range(randx - 3.0f, randx + 3.0f);
        redSoul10 = Instantiate(redSoulPrefab, lifestealAction.transform);
        redSoul10.GetComponent<RectTransform>().anchoredPosition = new Vector2(randx, 12.9f);
        jar = Instantiate(jarPrefab, lifestealAction.transform);
        finalAttack = true;
        soulLifesteal = true;
    }
    //A function to sum 1 to soulLifestealNumb
    public void GatherRedSoul()
    {
        soulLifestealNumb += 1;
    }

    //Functions to end the lifsteal attack
    public void EndLifestealAttack()
    {
        player.GetComponent<PlayerTeamScript>().SetLifestealTime(soulLifestealNumb);
        player.GetComponent<PlayerTeamScript>().HideBuffDebuff();
        companion.GetComponent<PlayerTeamScript>().HideBuffDebuff();
        soulLifestealNumb = 0;
        soulLifesteal = false;
        actionInstructions.SetActive(false);
        Destroy(jar.gameObject);
        player.GetComponent<PlayerTeamScript>().EndLifestealAttack();
    }

    public void EndSoulLifestealAttack()
    {
        finalAttack = false;
        EndPlayerTurn(1);
    }
    //A function to start the disappear attack
    public void StartDisappearAttack()
    {
        blueSoul = Instantiate(blueSoulPrefab, disappearAction.transform);
        float randy = Random.Range(-1.5f, 1.5f);
        wall1 = Instantiate(wallPrefab, disappearAction.transform);
        wall1.GetComponent<RectTransform>().anchoredPosition = new Vector2(6.5f, randy);
        randy = Random.Range(-1.5f, 1.5f);
        wall2 = Instantiate(wallPrefab, disappearAction.transform);
        wall2.GetComponent<RectTransform>().anchoredPosition = new Vector2(9.5f, randy);
        wall2.GetComponent<WallScript>().SetPreviousWall(wall1);
        randy = Random.Range(-1.5f, 1.5f);
        wall3 = Instantiate(wallPrefab, disappearAction.transform);
        wall3.GetComponent<RectTransform>().anchoredPosition = new Vector2(12.5f, randy);
        wall3.GetComponent<WallScript>().SetPreviousWall(wall2);
        randy = Random.Range(-1.5f, 1.5f);
        wall4 = Instantiate(wallPrefab, disappearAction.transform);
        wall4.GetComponent<RectTransform>().anchoredPosition = new Vector2(15.5f, randy);
        wall4.GetComponent<WallScript>().SetPreviousWall(wall3);
        randy = Random.Range(-1.5f, 1.5f);
        wall5 = Instantiate(wallPrefab, disappearAction.transform);
        wall5.GetComponent<RectTransform>().anchoredPosition = new Vector2(18.5f, randy);
        wall5.GetComponent<WallScript>().SetPreviousWall(wall4);
        wall1.GetComponent<WallScript>().SetPreviousWall(wall5);
        finalAttack = true;
        soulDisappear = true;
    }
    //Function to start the light up attack
    public void StartLightUpAttack()
    {
        magentaSoul = Instantiate(magentaSoulPrefab, lightUpAction.transform);
        fog = Instantiate(fogPrefab, lightUpAction.transform);
        magentaShard = Instantiate(magentaShardPrefab, lightUpAction.transform);
        magentaShard.GetComponent<RectTransform>().localScale = new Vector3(0.2f, 0.2f, 1.0f);
        magentaShard.transform.SetAsFirstSibling();
        float posx = Random.Range(-5.45f,5.45f);
        float posy = Random.Range(-2.3f,2.0f);
        magentaShard.GetComponent<RectTransform>().anchoredPosition = new Vector2(posx, posy);
        finalAttack = true;
        soulLightUp = true;
    }
    //Functions to end the light up attack
    public void EndLightUpAttack()
    {
        player.GetComponent<PlayerTeamScript>().SetLightUpPower(minFogScale);
        player.GetComponent<PlayerTeamScript>().HideBuffDebuff();
        magentaSoulMovUp = false;
        magentaSoulMovLeft = false;
        magentaSoulMovRight = false;
        magentaSoulMovDown = false;
        actionInstructions.SetActive(false);
        minFogScale = 1.0f;
        fogScaled = false;
        soulLightUp = false;
        Destroy(magentaSoul.gameObject);
        Destroy(magentaShard.gameObject);
        Destroy(fog.gameObject);
        player.GetComponent<PlayerTeamScript>().EndLightUpAttack();
    }
    public void EndSoulLightUpAttack()
    {
        finalAttack = false;
        EndPlayerTurn(1);
    }
    //Function to create a magenta shard
    public void CreateMagentaShard()
    {
        magentaShard = Instantiate(magentaShardPrefab, lightUpAction.transform);
        magentaShard.GetComponent<RectTransform>().localScale = new Vector3(0.2f, 0.2f, 1.0f);
        magentaShard.transform.SetAsFirstSibling();
        float posx = Random.Range(-5.45f, 5.45f);
        float posy = Random.Range(-2.3f, 2.0f);
        magentaShard.GetComponent<RectTransform>().anchoredPosition = new Vector2(posx, posy);
    }
    //Function to increment the minimum fog scale
    public void IncrementFogSize()
    {
        minFogScale += 0.5f;
    }
    //A function to select the next flying or grounded enemy.
    private Transform SelectNextShuriken(bool grounded)
    {
        Transform[] enemies = GetAllEnemies();
        int i = 0;
        bool found = false;
        while (i < enemies.Length && !found)
        {
            if(grounded)
            {
                if (!enemies[i].GetComponent<EnemyTeamScript>().IsGrounded()) found = true;
            }
            else
            {
                if (enemies[i].GetComponent<EnemyTeamScript>().IsGrounded()) found = true;
            }
            i++;
        }
        if (found) return enemies[i - 1];
        else return null;
    }
    //A function to select the first available enemy
    private void SelectFirstEnemy()
    {
        enemyName.transform.GetChild(1).gameObject.SetActive(false);
        enemyName.transform.GetChild(2).gameObject.SetActive(false);
        enemyName.transform.GetChild(3).gameObject.SetActive(false);
        enemyName.transform.GetChild(4).gameObject.SetActive(false);
        if (enemy1.GetComponent<EnemyTeamScript>().IsAlive() && ((playerTurn && (selectingAction == 0 && enemy1.GetComponent<EnemyTeamScript>().IsGrounded()) || selectingAction != 0) || (companionTurn && ((usingStyle != 1 && companion.GetComponent<PlayerTeamScript>().GetPlayerType() == 1 && enemy1.GetComponent<EnemyTeamScript>().IsGrounded()) || (usingStyle == 1 && companion.GetComponent<PlayerTeamScript>().GetPlayerType() == 1) || companion.GetComponent<PlayerTeamScript>().GetPlayerType() != 1))))
        {
            enemy1.GetChild(0).transform.GetChild(0).gameObject.SetActive(true);
            if(enemy1.GetComponent<EnemyTeamScript>().enemyType == 0)
            {
                enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = "Bandit";
            }
            else if (enemy1.GetComponent<EnemyTeamScript>().enemyType == 1)
            {
                enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = "Wizard";
            }
        }
        else if(enemyNumber > 1 && enemy2.GetComponent<EnemyTeamScript>().IsAlive() && ((playerTurn && (selectingAction == 0 && enemy2.GetComponent<EnemyTeamScript>().IsGrounded()) || selectingAction != 0) || (companionTurn && ((usingStyle != 1 && companion.GetComponent<PlayerTeamScript>().GetPlayerType() == 1 && enemy2.GetComponent<EnemyTeamScript>().IsGrounded()) || (usingStyle == 1 && companion.GetComponent<PlayerTeamScript>().GetPlayerType() == 1) || companion.GetComponent<PlayerTeamScript>().GetPlayerType() != 1))))
        {
            enemy2.GetChild(0).transform.GetChild(0).gameObject.SetActive(true);
            if (enemy2.GetComponent<EnemyTeamScript>().enemyType == 0)
            {
                enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = "Bandit";
            }
            else if (enemy2.GetComponent<EnemyTeamScript>().enemyType == 1)
            {
                enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = "Wizard";
            }
        }
        else if (enemyNumber > 2 && enemy3.GetComponent<EnemyTeamScript>().IsAlive() && ((playerTurn && (selectingAction == 0 && enemy3.GetComponent<EnemyTeamScript>().IsGrounded()) || selectingAction != 0) || (companionTurn && ((usingStyle != 1 && companion.GetComponent<PlayerTeamScript>().GetPlayerType() == 1 && enemy3.GetComponent<EnemyTeamScript>().IsGrounded()) || (usingStyle == 1 && companion.GetComponent<PlayerTeamScript>().GetPlayerType() == 1) || companion.GetComponent<PlayerTeamScript>().GetPlayerType() != 1))))
        {
            enemy3.GetChild(0).transform.GetChild(0).gameObject.SetActive(true);
            if (enemy3.GetComponent<EnemyTeamScript>().enemyType == 0)
            {
                enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = "Bandit";
            }
            else if (enemy3.GetComponent<EnemyTeamScript>().enemyType == 1)
            {
                enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = "Wizard";
            }
        }
        else if (enemyNumber > 3 && enemy4.GetComponent<EnemyTeamScript>().IsAlive() && ((playerTurn && (selectingAction == 0 && enemy4.GetComponent<EnemyTeamScript>().IsGrounded()) || selectingAction != 0) || (companionTurn && ((usingStyle != 1 && companion.GetComponent<PlayerTeamScript>().GetPlayerType() == 1 && enemy4.GetComponent<EnemyTeamScript>().IsGrounded()) || (usingStyle == 1 && companion.GetComponent<PlayerTeamScript>().GetPlayerType() == 1) || companion.GetComponent<PlayerTeamScript>().GetPlayerType() != 1))))
        {
            enemy4.GetChild(0).transform.GetChild(0).gameObject.SetActive(true);
            if (enemy4.GetComponent<EnemyTeamScript>().enemyType == 0)
            {
                enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = "Bandit";
            }
            else if (enemy4.GetComponent<EnemyTeamScript>().enemyType == 1)
            {
                enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = "Wizard";
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
            else if(groundEnemies[i].GetComponent<EnemyTeamScript>().enemyType == 1)
            {
                groundEnemies[i].GetChild(0).transform.GetChild(0).gameObject.SetActive(true);
                enemyName.transform.GetChild(i).gameObject.SetActive(true);
                enemyName.transform.GetChild(i).transform.GetChild(0).GetComponent<Text>().text = "Wizard";
                lastI = i;
            }
        }
        for (int i = lastI+1; i < 5; i++)
        {
            enemyName.transform.GetChild(i).gameObject.SetActive(false);
        }
        canSelect = false;
    }



    //A function to select all enemies
    private void SelectAllEnemies()
    {
        int lastI = -1;
        Transform[] groundEnemies = GetAllEnemies();
        for (int i = 0; i < groundEnemies.Length; i++)
        {
            if (groundEnemies[i].GetComponent<EnemyTeamScript>().enemyType == 0)
            {
                groundEnemies[i].GetChild(0).transform.GetChild(0).gameObject.SetActive(true);
                enemyName.transform.GetChild(i).gameObject.SetActive(true);
                enemyName.transform.GetChild(i).transform.GetChild(0).GetComponent<Text>().text = "Bandit";
                lastI = i;
            }
            else if (groundEnemies[i].GetComponent<EnemyTeamScript>().enemyType == 1)
            {
                groundEnemies[i].GetChild(0).transform.GetChild(0).gameObject.SetActive(true);
                enemyName.transform.GetChild(i).gameObject.SetActive(true);
                enemyName.transform.GetChild(i).transform.GetChild(0).GetComponent<Text>().text = "Wizard";
                lastI = i;
            }
        }
        for (int i = lastI + 1; i < 5; i++)
        {
            enemyName.transform.GetChild(i).gameObject.SetActive(false);
        }
        canSelect = false;
    }
    //Function to refresh the state of the health bar of every enemy
    public void KnowHealth()
    {
        Transform[] enemies = GetAllEnemies();
        for (int i = 0; i < enemies.Length; i++)
        {
            enemies[i].GetComponent<EnemyTeamScript>().KnowHealth();
        }
    }
    //Function to reset the aim rotation
    public void ResetAim()
    {
        aimRotation = 0.0f;
        aimUp = true;
    }

    //Function to set the shoot ready state
    public void SetReadyShoot(bool ready)
    {
        readyShoot = ready;
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

    //Function to fill the souls
    public void FillSouls(float soul)
    {
        if(soul1.GetComponent<Image>().fillAmount != 1.0f)
        {
            if ((soul1.GetComponent<Image>().fillAmount + soul) > 1.0f)
            {
                if (PlayerPrefs.GetInt("Souls") > 1) soul2.GetComponent<Image>().fillAmount = (soul1.GetComponent<Image>().fillAmount + soul) - 1.0f;
                soul1.GetComponent<Image>().fillAmount = 1.0f;
            }
            else soul1.GetComponent<Image>().fillAmount += soul;
        }
        else if (soul2.GetComponent<Image>().fillAmount != 1.0f)
        {
            if ((soul2.GetComponent<Image>().fillAmount + soul) > 1.0f)
            {
                if (PlayerPrefs.GetInt("Souls") > 2) soul3.GetComponent<Image>().fillAmount = (soul2.GetComponent<Image>().fillAmount + soul) - 1.0f;
                soul2.GetComponent<Image>().fillAmount = 1.0f;
            }
            else soul2.GetComponent<Image>().fillAmount += soul;
        }
        else if (soul3.GetComponent<Image>().fillAmount != 1.0f)
        {
            if ((soul3.GetComponent<Image>().fillAmount + soul) > 1.0f)
            {
                if (PlayerPrefs.GetInt("Souls") > 3) soul4.GetComponent<Image>().fillAmount = (soul3.GetComponent<Image>().fillAmount + soul) - 1.0f;
                soul3.GetComponent<Image>().fillAmount = 1.0f;
            }
            else soul3.GetComponent<Image>().fillAmount += soul;
        }
        else if (soul4.GetComponent<Image>().fillAmount != 1.0f)
        {
            if ((soul4.GetComponent<Image>().fillAmount + soul) > 1.0f)
            {
                if (PlayerPrefs.GetInt("Souls") > 4) soul5.GetComponent<Image>().fillAmount = (soul4.GetComponent<Image>().fillAmount + soul) - 1.0f;
                soul4.GetComponent<Image>().fillAmount = 1.0f;
            }
            else soul4.GetComponent<Image>().fillAmount += soul;
        }
        else if (soul5.GetComponent<Image>().fillAmount != 1.0f)
        {
            if ((soul5.GetComponent<Image>().fillAmount + soul) > 1.0f)
            {
                if (PlayerPrefs.GetInt("Souls") > 5) soul6.GetComponent<Image>().fillAmount = (soul5.GetComponent<Image>().fillAmount + soul) - 1.0f;
                soul5.GetComponent<Image>().fillAmount = 1.0f;
            }
            else soul5.GetComponent<Image>().fillAmount += soul;
        }
        else if (soul6.GetComponent<Image>().fillAmount != 1.0f)
        {
            if ((soul6.GetComponent<Image>().fillAmount + soul) > 1.0f)
            {
                soul6.GetComponent<Image>().fillAmount = 1.0f;
            }
            else soul6.GetComponent<Image>().fillAmount += soul;
        }
    }

    //Function to spend souls
    public void SpendSouls(int amount)
    {
        if(soul6.GetComponent<Image>().fillAmount > 0.0f)
        {
            if(amount == 3)
            {
                soul3.GetComponent<Image>().fillAmount = soul6.GetComponent<Image>().fillAmount;
                soul6.GetComponent<Image>().fillAmount = 0.0f;
                soul5.GetComponent<Image>().fillAmount = 0.0f;
                soul4.GetComponent<Image>().fillAmount = 0.0f;
            }
            else if(amount == 2)
            {
                soul4.GetComponent<Image>().fillAmount = soul6.GetComponent<Image>().fillAmount;
                soul6.GetComponent<Image>().fillAmount = 0.0f;
                soul5.GetComponent<Image>().fillAmount = 0.0f;
            }
            else if(amount == 1)
            {
                soul5.GetComponent<Image>().fillAmount = soul6.GetComponent<Image>().fillAmount;
                soul6.GetComponent<Image>().fillAmount = 0.0f;
            }
        }
        else if(soul5.GetComponent<Image>().fillAmount > 0.0f)
        {
            if (amount == 3)
            {
                soul2.GetComponent<Image>().fillAmount = soul5.GetComponent<Image>().fillAmount;
                soul5.GetComponent<Image>().fillAmount = 0.0f;
                soul4.GetComponent<Image>().fillAmount = 0.0f;
                soul3.GetComponent<Image>().fillAmount = 0.0f;
            }
            else if (amount == 2)
            {
                soul3.GetComponent<Image>().fillAmount = soul5.GetComponent<Image>().fillAmount;
                soul5.GetComponent<Image>().fillAmount = 0.0f;
                soul4.GetComponent<Image>().fillAmount = 0.0f;
            }
            else if (amount == 1)
            {
                soul4.GetComponent<Image>().fillAmount = soul5.GetComponent<Image>().fillAmount;
                soul5.GetComponent<Image>().fillAmount = 0.0f;
            }
        }
        else if (soul4.GetComponent<Image>().fillAmount > 0.0f)
        {
            if (amount == 3)
            {
                soul1.GetComponent<Image>().fillAmount = soul4.GetComponent<Image>().fillAmount;
                soul4.GetComponent<Image>().fillAmount = 0.0f;
                soul3.GetComponent<Image>().fillAmount = 0.0f;
                soul2.GetComponent<Image>().fillAmount = 0.0f;
            }
            else if (amount == 2)
            {
                soul2.GetComponent<Image>().fillAmount = soul4.GetComponent<Image>().fillAmount;
                soul4.GetComponent<Image>().fillAmount = 0.0f;
                soul3.GetComponent<Image>().fillAmount = 0.0f;
            }
            else if (amount == 1)
            {
                soul3.GetComponent<Image>().fillAmount = soul4.GetComponent<Image>().fillAmount;
                soul4.GetComponent<Image>().fillAmount = 0.0f;
            }
        }
        else if (soul3.GetComponent<Image>().fillAmount > 0.0f)
        {
            if (amount == 3 && soul3.GetComponent<Image>().fillAmount == 1.0f)
            {
                soul3.GetComponent<Image>().fillAmount = 0.0f;
                soul2.GetComponent<Image>().fillAmount = 0.0f;
                soul1.GetComponent<Image>().fillAmount = 0.0f;
            }
            else if (amount == 2)
            {
                soul1.GetComponent<Image>().fillAmount = soul3.GetComponent<Image>().fillAmount;
                soul3.GetComponent<Image>().fillAmount = 0.0f;
                soul2.GetComponent<Image>().fillAmount = 0.0f;
            }
            else if (amount == 1)
            {
                soul2.GetComponent<Image>().fillAmount = soul3.GetComponent<Image>().fillAmount;
                soul3.GetComponent<Image>().fillAmount = 0.0f;
            }
        }
        else if (soul2.GetComponent<Image>().fillAmount > 0.0f)
        {
            if (amount == 2 && soul2.GetComponent<Image>().fillAmount == 1.0f)
            {
                soul2.GetComponent<Image>().fillAmount = 0.0f;
                soul1.GetComponent<Image>().fillAmount = 0.0f;
            }
            else if (amount == 1)
            {
                soul1.GetComponent<Image>().fillAmount = soul2.GetComponent<Image>().fillAmount;
                soul2.GetComponent<Image>().fillAmount = 0.0f;
            }
        }
        else if (amount == 1 && soul1.GetComponent<Image>().fillAmount == 1.0f)
        {
            soul1.GetComponent<Image>().fillAmount = 0.0f;
        }
    }
    //Function to set the talking state
    public void SetTalking(bool state)
    {
        talking = state;
    }

    //Function to get the soul points
    private bool CanUseSoulPoints(int usingSouls)
    {
        int soulPoints = 0;
        if (soul1.GetComponent<Image>().fillAmount == 1.0f) soulPoints += 1;
        if (PlayerPrefs.GetInt("Souls") > 1 && soul2.GetComponent<Image>().fillAmount == 1.0f) soulPoints += 1;
        if (PlayerPrefs.GetInt("Souls") > 2 && soul3.GetComponent<Image>().fillAmount == 1.0f) soulPoints += 1;
        if (PlayerPrefs.GetInt("Souls") > 3 && soul4.GetComponent<Image>().fillAmount == 1.0f) soulPoints += 1;
        if (PlayerPrefs.GetInt("Souls") > 4 && soul5.GetComponent<Image>().fillAmount == 1.0f) soulPoints += 1;
        if (PlayerPrefs.GetInt("Souls") > 5 && soul6.GetComponent<Image>().fillAmount == 1.0f) soulPoints += 1;
        return soulPoints>=usingSouls;
    }
    //Function to add xp to the current xp
    public void AddXPToCurrent(int xp)
    {
        currentFightXP += xp;
        ShowCurrentXP();
    }
    //Function to show the current xp
    private void ShowCurrentXP()
    {
        int rest = currentFightXP % 10;
        int quotient = currentFightXP / 10;
        if (rest == 0)
        {
            xpObject.transform.GetChild(0).GetComponent<Image>().color = new Color(xpObject.transform.GetChild(0).GetComponent<Image>().color.r, xpObject.transform.GetChild(0).GetComponent<Image>().color.g, xpObject.transform.GetChild(0).GetComponent<Image>().color.b, 0.0f);
            xpObject.transform.GetChild(1).GetComponent<Image>().color = new Color(xpObject.transform.GetChild(0).GetComponent<Image>().color.r, xpObject.transform.GetChild(0).GetComponent<Image>().color.g, xpObject.transform.GetChild(0).GetComponent<Image>().color.b, 0.0f);
            xpObject.transform.GetChild(2).GetComponent<Image>().color = new Color(xpObject.transform.GetChild(0).GetComponent<Image>().color.r, xpObject.transform.GetChild(0).GetComponent<Image>().color.g, xpObject.transform.GetChild(0).GetComponent<Image>().color.b, 0.0f);
            xpObject.transform.GetChild(3).GetComponent<Image>().color = new Color(xpObject.transform.GetChild(0).GetComponent<Image>().color.r, xpObject.transform.GetChild(0).GetComponent<Image>().color.g, xpObject.transform.GetChild(0).GetComponent<Image>().color.b, 0.0f);
            xpObject.transform.GetChild(4).GetComponent<Image>().color = new Color(xpObject.transform.GetChild(0).GetComponent<Image>().color.r, xpObject.transform.GetChild(0).GetComponent<Image>().color.g, xpObject.transform.GetChild(0).GetComponent<Image>().color.b, 0.0f);
            xpObject.transform.GetChild(5).GetComponent<Image>().color = new Color(xpObject.transform.GetChild(0).GetComponent<Image>().color.r, xpObject.transform.GetChild(0).GetComponent<Image>().color.g, xpObject.transform.GetChild(0).GetComponent<Image>().color.b, 0.0f);
            xpObject.transform.GetChild(6).GetComponent<Image>().color = new Color(xpObject.transform.GetChild(0).GetComponent<Image>().color.r, xpObject.transform.GetChild(0).GetComponent<Image>().color.g, xpObject.transform.GetChild(0).GetComponent<Image>().color.b, 0.0f);
            xpObject.transform.GetChild(7).GetComponent<Image>().color = new Color(xpObject.transform.GetChild(0).GetComponent<Image>().color.r, xpObject.transform.GetChild(0).GetComponent<Image>().color.g, xpObject.transform.GetChild(0).GetComponent<Image>().color.b, 0.0f);
            xpObject.transform.GetChild(8).GetComponent<Image>().color = new Color(xpObject.transform.GetChild(0).GetComponent<Image>().color.r, xpObject.transform.GetChild(0).GetComponent<Image>().color.g, xpObject.transform.GetChild(0).GetComponent<Image>().color.b, 0.0f);
        }
        else if (rest == 1)
        {
            xpObject.transform.GetChild(0).GetComponent<Image>().color = new Color(xpObject.transform.GetChild(0).GetComponent<Image>().color.r, xpObject.transform.GetChild(0).GetComponent<Image>().color.g, xpObject.transform.GetChild(0).GetComponent<Image>().color.b, 1.0f);
            xpObject.transform.GetChild(1).GetComponent<Image>().color = new Color(xpObject.transform.GetChild(0).GetComponent<Image>().color.r, xpObject.transform.GetChild(0).GetComponent<Image>().color.g, xpObject.transform.GetChild(0).GetComponent<Image>().color.b, 0.0f);
            xpObject.transform.GetChild(2).GetComponent<Image>().color = new Color(xpObject.transform.GetChild(0).GetComponent<Image>().color.r, xpObject.transform.GetChild(0).GetComponent<Image>().color.g, xpObject.transform.GetChild(0).GetComponent<Image>().color.b, 0.0f);
            xpObject.transform.GetChild(3).GetComponent<Image>().color = new Color(xpObject.transform.GetChild(0).GetComponent<Image>().color.r, xpObject.transform.GetChild(0).GetComponent<Image>().color.g, xpObject.transform.GetChild(0).GetComponent<Image>().color.b, 0.0f);
            xpObject.transform.GetChild(4).GetComponent<Image>().color = new Color(xpObject.transform.GetChild(0).GetComponent<Image>().color.r, xpObject.transform.GetChild(0).GetComponent<Image>().color.g, xpObject.transform.GetChild(0).GetComponent<Image>().color.b, 0.0f);
            xpObject.transform.GetChild(5).GetComponent<Image>().color = new Color(xpObject.transform.GetChild(0).GetComponent<Image>().color.r, xpObject.transform.GetChild(0).GetComponent<Image>().color.g, xpObject.transform.GetChild(0).GetComponent<Image>().color.b, 0.0f);
            xpObject.transform.GetChild(6).GetComponent<Image>().color = new Color(xpObject.transform.GetChild(0).GetComponent<Image>().color.r, xpObject.transform.GetChild(0).GetComponent<Image>().color.g, xpObject.transform.GetChild(0).GetComponent<Image>().color.b, 0.0f);
            xpObject.transform.GetChild(7).GetComponent<Image>().color = new Color(xpObject.transform.GetChild(0).GetComponent<Image>().color.r, xpObject.transform.GetChild(0).GetComponent<Image>().color.g, xpObject.transform.GetChild(0).GetComponent<Image>().color.b, 0.0f);
            xpObject.transform.GetChild(8).GetComponent<Image>().color = new Color(xpObject.transform.GetChild(0).GetComponent<Image>().color.r, xpObject.transform.GetChild(0).GetComponent<Image>().color.g, xpObject.transform.GetChild(0).GetComponent<Image>().color.b, 0.0f);
        }
        else if (rest == 2)
        {
            xpObject.transform.GetChild(0).GetComponent<Image>().color = new Color(xpObject.transform.GetChild(0).GetComponent<Image>().color.r, xpObject.transform.GetChild(0).GetComponent<Image>().color.g, xpObject.transform.GetChild(0).GetComponent<Image>().color.b, 1.0f);
            xpObject.transform.GetChild(1).GetComponent<Image>().color = new Color(xpObject.transform.GetChild(0).GetComponent<Image>().color.r, xpObject.transform.GetChild(0).GetComponent<Image>().color.g, xpObject.transform.GetChild(0).GetComponent<Image>().color.b, 1.0f);
            xpObject.transform.GetChild(2).GetComponent<Image>().color = new Color(xpObject.transform.GetChild(0).GetComponent<Image>().color.r, xpObject.transform.GetChild(0).GetComponent<Image>().color.g, xpObject.transform.GetChild(0).GetComponent<Image>().color.b, 0.0f);
            xpObject.transform.GetChild(3).GetComponent<Image>().color = new Color(xpObject.transform.GetChild(0).GetComponent<Image>().color.r, xpObject.transform.GetChild(0).GetComponent<Image>().color.g, xpObject.transform.GetChild(0).GetComponent<Image>().color.b, 0.0f);
            xpObject.transform.GetChild(4).GetComponent<Image>().color = new Color(xpObject.transform.GetChild(0).GetComponent<Image>().color.r, xpObject.transform.GetChild(0).GetComponent<Image>().color.g, xpObject.transform.GetChild(0).GetComponent<Image>().color.b, 0.0f);
            xpObject.transform.GetChild(5).GetComponent<Image>().color = new Color(xpObject.transform.GetChild(0).GetComponent<Image>().color.r, xpObject.transform.GetChild(0).GetComponent<Image>().color.g, xpObject.transform.GetChild(0).GetComponent<Image>().color.b, 0.0f);
            xpObject.transform.GetChild(6).GetComponent<Image>().color = new Color(xpObject.transform.GetChild(0).GetComponent<Image>().color.r, xpObject.transform.GetChild(0).GetComponent<Image>().color.g, xpObject.transform.GetChild(0).GetComponent<Image>().color.b, 0.0f);
            xpObject.transform.GetChild(7).GetComponent<Image>().color = new Color(xpObject.transform.GetChild(0).GetComponent<Image>().color.r, xpObject.transform.GetChild(0).GetComponent<Image>().color.g, xpObject.transform.GetChild(0).GetComponent<Image>().color.b, 0.0f);
            xpObject.transform.GetChild(8).GetComponent<Image>().color = new Color(xpObject.transform.GetChild(0).GetComponent<Image>().color.r, xpObject.transform.GetChild(0).GetComponent<Image>().color.g, xpObject.transform.GetChild(0).GetComponent<Image>().color.b, 0.0f);
        }
        else if (rest == 3)
        {
            xpObject.transform.GetChild(0).GetComponent<Image>().color = new Color(xpObject.transform.GetChild(0).GetComponent<Image>().color.r, xpObject.transform.GetChild(0).GetComponent<Image>().color.g, xpObject.transform.GetChild(0).GetComponent<Image>().color.b, 1.0f);
            xpObject.transform.GetChild(1).GetComponent<Image>().color = new Color(xpObject.transform.GetChild(0).GetComponent<Image>().color.r, xpObject.transform.GetChild(0).GetComponent<Image>().color.g, xpObject.transform.GetChild(0).GetComponent<Image>().color.b, 1.0f);
            xpObject.transform.GetChild(2).GetComponent<Image>().color = new Color(xpObject.transform.GetChild(0).GetComponent<Image>().color.r, xpObject.transform.GetChild(0).GetComponent<Image>().color.g, xpObject.transform.GetChild(0).GetComponent<Image>().color.b, 1.0f);
            xpObject.transform.GetChild(3).GetComponent<Image>().color = new Color(xpObject.transform.GetChild(0).GetComponent<Image>().color.r, xpObject.transform.GetChild(0).GetComponent<Image>().color.g, xpObject.transform.GetChild(0).GetComponent<Image>().color.b, 0.0f);
            xpObject.transform.GetChild(4).GetComponent<Image>().color = new Color(xpObject.transform.GetChild(0).GetComponent<Image>().color.r, xpObject.transform.GetChild(0).GetComponent<Image>().color.g, xpObject.transform.GetChild(0).GetComponent<Image>().color.b, 0.0f);
            xpObject.transform.GetChild(5).GetComponent<Image>().color = new Color(xpObject.transform.GetChild(0).GetComponent<Image>().color.r, xpObject.transform.GetChild(0).GetComponent<Image>().color.g, xpObject.transform.GetChild(0).GetComponent<Image>().color.b, 0.0f);
            xpObject.transform.GetChild(6).GetComponent<Image>().color = new Color(xpObject.transform.GetChild(0).GetComponent<Image>().color.r, xpObject.transform.GetChild(0).GetComponent<Image>().color.g, xpObject.transform.GetChild(0).GetComponent<Image>().color.b, 0.0f);
            xpObject.transform.GetChild(7).GetComponent<Image>().color = new Color(xpObject.transform.GetChild(0).GetComponent<Image>().color.r, xpObject.transform.GetChild(0).GetComponent<Image>().color.g, xpObject.transform.GetChild(0).GetComponent<Image>().color.b, 0.0f);
            xpObject.transform.GetChild(8).GetComponent<Image>().color = new Color(xpObject.transform.GetChild(0).GetComponent<Image>().color.r, xpObject.transform.GetChild(0).GetComponent<Image>().color.g, xpObject.transform.GetChild(0).GetComponent<Image>().color.b, 0.0f);
        }
        else if (rest == 4)
        {
            xpObject.transform.GetChild(0).GetComponent<Image>().color = new Color(xpObject.transform.GetChild(0).GetComponent<Image>().color.r, xpObject.transform.GetChild(0).GetComponent<Image>().color.g, xpObject.transform.GetChild(0).GetComponent<Image>().color.b, 1.0f);
            xpObject.transform.GetChild(1).GetComponent<Image>().color = new Color(xpObject.transform.GetChild(0).GetComponent<Image>().color.r, xpObject.transform.GetChild(0).GetComponent<Image>().color.g, xpObject.transform.GetChild(0).GetComponent<Image>().color.b, 1.0f);
            xpObject.transform.GetChild(2).GetComponent<Image>().color = new Color(xpObject.transform.GetChild(0).GetComponent<Image>().color.r, xpObject.transform.GetChild(0).GetComponent<Image>().color.g, xpObject.transform.GetChild(0).GetComponent<Image>().color.b, 1.0f);
            xpObject.transform.GetChild(3).GetComponent<Image>().color = new Color(xpObject.transform.GetChild(0).GetComponent<Image>().color.r, xpObject.transform.GetChild(0).GetComponent<Image>().color.g, xpObject.transform.GetChild(0).GetComponent<Image>().color.b, 1.0f);
            xpObject.transform.GetChild(4).GetComponent<Image>().color = new Color(xpObject.transform.GetChild(0).GetComponent<Image>().color.r, xpObject.transform.GetChild(0).GetComponent<Image>().color.g, xpObject.transform.GetChild(0).GetComponent<Image>().color.b, 0.0f);
            xpObject.transform.GetChild(5).GetComponent<Image>().color = new Color(xpObject.transform.GetChild(0).GetComponent<Image>().color.r, xpObject.transform.GetChild(0).GetComponent<Image>().color.g, xpObject.transform.GetChild(0).GetComponent<Image>().color.b, 0.0f);
            xpObject.transform.GetChild(6).GetComponent<Image>().color = new Color(xpObject.transform.GetChild(0).GetComponent<Image>().color.r, xpObject.transform.GetChild(0).GetComponent<Image>().color.g, xpObject.transform.GetChild(0).GetComponent<Image>().color.b, 0.0f);
            xpObject.transform.GetChild(7).GetComponent<Image>().color = new Color(xpObject.transform.GetChild(0).GetComponent<Image>().color.r, xpObject.transform.GetChild(0).GetComponent<Image>().color.g, xpObject.transform.GetChild(0).GetComponent<Image>().color.b, 0.0f);
            xpObject.transform.GetChild(8).GetComponent<Image>().color = new Color(xpObject.transform.GetChild(0).GetComponent<Image>().color.r, xpObject.transform.GetChild(0).GetComponent<Image>().color.g, xpObject.transform.GetChild(0).GetComponent<Image>().color.b, 0.0f);
        }
        else if (rest == 5)
        {
            xpObject.transform.GetChild(0).GetComponent<Image>().color = new Color(xpObject.transform.GetChild(0).GetComponent<Image>().color.r, xpObject.transform.GetChild(0).GetComponent<Image>().color.g, xpObject.transform.GetChild(0).GetComponent<Image>().color.b, 1.0f);
            xpObject.transform.GetChild(1).GetComponent<Image>().color = new Color(xpObject.transform.GetChild(0).GetComponent<Image>().color.r, xpObject.transform.GetChild(0).GetComponent<Image>().color.g, xpObject.transform.GetChild(0).GetComponent<Image>().color.b, 1.0f);
            xpObject.transform.GetChild(2).GetComponent<Image>().color = new Color(xpObject.transform.GetChild(0).GetComponent<Image>().color.r, xpObject.transform.GetChild(0).GetComponent<Image>().color.g, xpObject.transform.GetChild(0).GetComponent<Image>().color.b, 1.0f);
            xpObject.transform.GetChild(3).GetComponent<Image>().color = new Color(xpObject.transform.GetChild(0).GetComponent<Image>().color.r, xpObject.transform.GetChild(0).GetComponent<Image>().color.g, xpObject.transform.GetChild(0).GetComponent<Image>().color.b, 1.0f);
            xpObject.transform.GetChild(4).GetComponent<Image>().color = new Color(xpObject.transform.GetChild(0).GetComponent<Image>().color.r, xpObject.transform.GetChild(0).GetComponent<Image>().color.g, xpObject.transform.GetChild(0).GetComponent<Image>().color.b, 1.0f);
            xpObject.transform.GetChild(5).GetComponent<Image>().color = new Color(xpObject.transform.GetChild(0).GetComponent<Image>().color.r, xpObject.transform.GetChild(0).GetComponent<Image>().color.g, xpObject.transform.GetChild(0).GetComponent<Image>().color.b, 0.0f);
            xpObject.transform.GetChild(6).GetComponent<Image>().color = new Color(xpObject.transform.GetChild(0).GetComponent<Image>().color.r, xpObject.transform.GetChild(0).GetComponent<Image>().color.g, xpObject.transform.GetChild(0).GetComponent<Image>().color.b, 0.0f);
            xpObject.transform.GetChild(7).GetComponent<Image>().color = new Color(xpObject.transform.GetChild(0).GetComponent<Image>().color.r, xpObject.transform.GetChild(0).GetComponent<Image>().color.g, xpObject.transform.GetChild(0).GetComponent<Image>().color.b, 0.0f);
            xpObject.transform.GetChild(8).GetComponent<Image>().color = new Color(xpObject.transform.GetChild(0).GetComponent<Image>().color.r, xpObject.transform.GetChild(0).GetComponent<Image>().color.g, xpObject.transform.GetChild(0).GetComponent<Image>().color.b, 0.0f);
        }
        else if (rest == 6)
        {
            xpObject.transform.GetChild(0).GetComponent<Image>().color = new Color(xpObject.transform.GetChild(0).GetComponent<Image>().color.r, xpObject.transform.GetChild(0).GetComponent<Image>().color.g, xpObject.transform.GetChild(0).GetComponent<Image>().color.b, 1.0f);
            xpObject.transform.GetChild(1).GetComponent<Image>().color = new Color(xpObject.transform.GetChild(0).GetComponent<Image>().color.r, xpObject.transform.GetChild(0).GetComponent<Image>().color.g, xpObject.transform.GetChild(0).GetComponent<Image>().color.b, 1.0f);
            xpObject.transform.GetChild(2).GetComponent<Image>().color = new Color(xpObject.transform.GetChild(0).GetComponent<Image>().color.r, xpObject.transform.GetChild(0).GetComponent<Image>().color.g, xpObject.transform.GetChild(0).GetComponent<Image>().color.b, 1.0f);
            xpObject.transform.GetChild(3).GetComponent<Image>().color = new Color(xpObject.transform.GetChild(0).GetComponent<Image>().color.r, xpObject.transform.GetChild(0).GetComponent<Image>().color.g, xpObject.transform.GetChild(0).GetComponent<Image>().color.b, 1.0f);
            xpObject.transform.GetChild(4).GetComponent<Image>().color = new Color(xpObject.transform.GetChild(0).GetComponent<Image>().color.r, xpObject.transform.GetChild(0).GetComponent<Image>().color.g, xpObject.transform.GetChild(0).GetComponent<Image>().color.b, 1.0f);
            xpObject.transform.GetChild(5).GetComponent<Image>().color = new Color(xpObject.transform.GetChild(0).GetComponent<Image>().color.r, xpObject.transform.GetChild(0).GetComponent<Image>().color.g, xpObject.transform.GetChild(0).GetComponent<Image>().color.b, 1.0f);
            xpObject.transform.GetChild(6).GetComponent<Image>().color = new Color(xpObject.transform.GetChild(0).GetComponent<Image>().color.r, xpObject.transform.GetChild(0).GetComponent<Image>().color.g, xpObject.transform.GetChild(0).GetComponent<Image>().color.b, 0.0f);
            xpObject.transform.GetChild(7).GetComponent<Image>().color = new Color(xpObject.transform.GetChild(0).GetComponent<Image>().color.r, xpObject.transform.GetChild(0).GetComponent<Image>().color.g, xpObject.transform.GetChild(0).GetComponent<Image>().color.b, 0.0f);
            xpObject.transform.GetChild(8).GetComponent<Image>().color = new Color(xpObject.transform.GetChild(0).GetComponent<Image>().color.r, xpObject.transform.GetChild(0).GetComponent<Image>().color.g, xpObject.transform.GetChild(0).GetComponent<Image>().color.b, 0.0f);
        }
        else if (rest == 7)
        {
            xpObject.transform.GetChild(0).GetComponent<Image>().color = new Color(xpObject.transform.GetChild(0).GetComponent<Image>().color.r, xpObject.transform.GetChild(0).GetComponent<Image>().color.g, xpObject.transform.GetChild(0).GetComponent<Image>().color.b, 1.0f);
            xpObject.transform.GetChild(1).GetComponent<Image>().color = new Color(xpObject.transform.GetChild(0).GetComponent<Image>().color.r, xpObject.transform.GetChild(0).GetComponent<Image>().color.g, xpObject.transform.GetChild(0).GetComponent<Image>().color.b, 1.0f);
            xpObject.transform.GetChild(2).GetComponent<Image>().color = new Color(xpObject.transform.GetChild(0).GetComponent<Image>().color.r, xpObject.transform.GetChild(0).GetComponent<Image>().color.g, xpObject.transform.GetChild(0).GetComponent<Image>().color.b, 1.0f);
            xpObject.transform.GetChild(3).GetComponent<Image>().color = new Color(xpObject.transform.GetChild(0).GetComponent<Image>().color.r, xpObject.transform.GetChild(0).GetComponent<Image>().color.g, xpObject.transform.GetChild(0).GetComponent<Image>().color.b, 1.0f);
            xpObject.transform.GetChild(4).GetComponent<Image>().color = new Color(xpObject.transform.GetChild(0).GetComponent<Image>().color.r, xpObject.transform.GetChild(0).GetComponent<Image>().color.g, xpObject.transform.GetChild(0).GetComponent<Image>().color.b, 1.0f);
            xpObject.transform.GetChild(5).GetComponent<Image>().color = new Color(xpObject.transform.GetChild(0).GetComponent<Image>().color.r, xpObject.transform.GetChild(0).GetComponent<Image>().color.g, xpObject.transform.GetChild(0).GetComponent<Image>().color.b, 1.0f);
            xpObject.transform.GetChild(6).GetComponent<Image>().color = new Color(xpObject.transform.GetChild(0).GetComponent<Image>().color.r, xpObject.transform.GetChild(0).GetComponent<Image>().color.g, xpObject.transform.GetChild(0).GetComponent<Image>().color.b, 1.0f);
            xpObject.transform.GetChild(7).GetComponent<Image>().color = new Color(xpObject.transform.GetChild(0).GetComponent<Image>().color.r, xpObject.transform.GetChild(0).GetComponent<Image>().color.g, xpObject.transform.GetChild(0).GetComponent<Image>().color.b, 0.0f);
            xpObject.transform.GetChild(8).GetComponent<Image>().color = new Color(xpObject.transform.GetChild(0).GetComponent<Image>().color.r, xpObject.transform.GetChild(0).GetComponent<Image>().color.g, xpObject.transform.GetChild(0).GetComponent<Image>().color.b, 0.0f);
        }
        else if (rest == 8)
        {
            xpObject.transform.GetChild(0).GetComponent<Image>().color = new Color(xpObject.transform.GetChild(0).GetComponent<Image>().color.r, xpObject.transform.GetChild(0).GetComponent<Image>().color.g, xpObject.transform.GetChild(0).GetComponent<Image>().color.b, 1.0f);
            xpObject.transform.GetChild(1).GetComponent<Image>().color = new Color(xpObject.transform.GetChild(0).GetComponent<Image>().color.r, xpObject.transform.GetChild(0).GetComponent<Image>().color.g, xpObject.transform.GetChild(0).GetComponent<Image>().color.b, 1.0f);
            xpObject.transform.GetChild(2).GetComponent<Image>().color = new Color(xpObject.transform.GetChild(0).GetComponent<Image>().color.r, xpObject.transform.GetChild(0).GetComponent<Image>().color.g, xpObject.transform.GetChild(0).GetComponent<Image>().color.b, 1.0f);
            xpObject.transform.GetChild(3).GetComponent<Image>().color = new Color(xpObject.transform.GetChild(0).GetComponent<Image>().color.r, xpObject.transform.GetChild(0).GetComponent<Image>().color.g, xpObject.transform.GetChild(0).GetComponent<Image>().color.b, 1.0f);
            xpObject.transform.GetChild(4).GetComponent<Image>().color = new Color(xpObject.transform.GetChild(0).GetComponent<Image>().color.r, xpObject.transform.GetChild(0).GetComponent<Image>().color.g, xpObject.transform.GetChild(0).GetComponent<Image>().color.b, 1.0f);
            xpObject.transform.GetChild(5).GetComponent<Image>().color = new Color(xpObject.transform.GetChild(0).GetComponent<Image>().color.r, xpObject.transform.GetChild(0).GetComponent<Image>().color.g, xpObject.transform.GetChild(0).GetComponent<Image>().color.b, 1.0f);
            xpObject.transform.GetChild(6).GetComponent<Image>().color = new Color(xpObject.transform.GetChild(0).GetComponent<Image>().color.r, xpObject.transform.GetChild(0).GetComponent<Image>().color.g, xpObject.transform.GetChild(0).GetComponent<Image>().color.b, 1.0f);
            xpObject.transform.GetChild(7).GetComponent<Image>().color = new Color(xpObject.transform.GetChild(0).GetComponent<Image>().color.r, xpObject.transform.GetChild(0).GetComponent<Image>().color.g, xpObject.transform.GetChild(0).GetComponent<Image>().color.b, 1.0f);
            xpObject.transform.GetChild(8).GetComponent<Image>().color = new Color(xpObject.transform.GetChild(0).GetComponent<Image>().color.r, xpObject.transform.GetChild(0).GetComponent<Image>().color.g, xpObject.transform.GetChild(0).GetComponent<Image>().color.b, 0.0f);
        }
        else if (rest == 9)
        {
            xpObject.transform.GetChild(0).GetComponent<Image>().color = new Color(xpObject.transform.GetChild(0).GetComponent<Image>().color.r, xpObject.transform.GetChild(0).GetComponent<Image>().color.g, xpObject.transform.GetChild(0).GetComponent<Image>().color.b, 1.0f);
            xpObject.transform.GetChild(1).GetComponent<Image>().color = new Color(xpObject.transform.GetChild(0).GetComponent<Image>().color.r, xpObject.transform.GetChild(0).GetComponent<Image>().color.g, xpObject.transform.GetChild(0).GetComponent<Image>().color.b, 1.0f);
            xpObject.transform.GetChild(2).GetComponent<Image>().color = new Color(xpObject.transform.GetChild(0).GetComponent<Image>().color.r, xpObject.transform.GetChild(0).GetComponent<Image>().color.g, xpObject.transform.GetChild(0).GetComponent<Image>().color.b, 1.0f);
            xpObject.transform.GetChild(3).GetComponent<Image>().color = new Color(xpObject.transform.GetChild(0).GetComponent<Image>().color.r, xpObject.transform.GetChild(0).GetComponent<Image>().color.g, xpObject.transform.GetChild(0).GetComponent<Image>().color.b, 1.0f);
            xpObject.transform.GetChild(4).GetComponent<Image>().color = new Color(xpObject.transform.GetChild(0).GetComponent<Image>().color.r, xpObject.transform.GetChild(0).GetComponent<Image>().color.g, xpObject.transform.GetChild(0).GetComponent<Image>().color.b, 1.0f);
            xpObject.transform.GetChild(5).GetComponent<Image>().color = new Color(xpObject.transform.GetChild(0).GetComponent<Image>().color.r, xpObject.transform.GetChild(0).GetComponent<Image>().color.g, xpObject.transform.GetChild(0).GetComponent<Image>().color.b, 1.0f);
            xpObject.transform.GetChild(6).GetComponent<Image>().color = new Color(xpObject.transform.GetChild(0).GetComponent<Image>().color.r, xpObject.transform.GetChild(0).GetComponent<Image>().color.g, xpObject.transform.GetChild(0).GetComponent<Image>().color.b, 1.0f);
            xpObject.transform.GetChild(7).GetComponent<Image>().color = new Color(xpObject.transform.GetChild(0).GetComponent<Image>().color.r, xpObject.transform.GetChild(0).GetComponent<Image>().color.g, xpObject.transform.GetChild(0).GetComponent<Image>().color.b, 1.0f);
            xpObject.transform.GetChild(8).GetComponent<Image>().color = new Color(xpObject.transform.GetChild(0).GetComponent<Image>().color.r, xpObject.transform.GetChild(0).GetComponent<Image>().color.g, xpObject.transform.GetChild(0).GetComponent<Image>().color.b, 1.0f);
        }
        if(quotient == 0)
        {
            xpObject.transform.GetChild(9).GetComponent<Image>().color = new Color(xpObject.transform.GetChild(0).GetComponent<Image>().color.r, xpObject.transform.GetChild(0).GetComponent<Image>().color.g, xpObject.transform.GetChild(0).GetComponent<Image>().color.b, 0.0f);
            xpObject.transform.GetChild(10).GetComponent<Image>().color = new Color(xpObject.transform.GetChild(0).GetComponent<Image>().color.r, xpObject.transform.GetChild(0).GetComponent<Image>().color.g, xpObject.transform.GetChild(0).GetComponent<Image>().color.b, 0.0f);
            xpObject.transform.GetChild(11).GetComponent<Image>().color = new Color(xpObject.transform.GetChild(0).GetComponent<Image>().color.r, xpObject.transform.GetChild(0).GetComponent<Image>().color.g, xpObject.transform.GetChild(0).GetComponent<Image>().color.b, 0.0f);
            xpObject.transform.GetChild(12).GetComponent<Image>().color = new Color(xpObject.transform.GetChild(0).GetComponent<Image>().color.r, xpObject.transform.GetChild(0).GetComponent<Image>().color.g, xpObject.transform.GetChild(0).GetComponent<Image>().color.b, 0.0f);
            xpObject.transform.GetChild(13).GetComponent<Image>().color = new Color(xpObject.transform.GetChild(0).GetComponent<Image>().color.r, xpObject.transform.GetChild(0).GetComponent<Image>().color.g, xpObject.transform.GetChild(0).GetComponent<Image>().color.b, 0.0f);
            xpObject.transform.GetChild(14).GetComponent<Image>().color = new Color(xpObject.transform.GetChild(0).GetComponent<Image>().color.r, xpObject.transform.GetChild(0).GetComponent<Image>().color.g, xpObject.transform.GetChild(0).GetComponent<Image>().color.b, 0.0f);
            xpObject.transform.GetChild(15).GetComponent<Image>().color = new Color(xpObject.transform.GetChild(0).GetComponent<Image>().color.r, xpObject.transform.GetChild(0).GetComponent<Image>().color.g, xpObject.transform.GetChild(0).GetComponent<Image>().color.b, 0.0f);
            xpObject.transform.GetChild(16).GetComponent<Image>().color = new Color(xpObject.transform.GetChild(0).GetComponent<Image>().color.r, xpObject.transform.GetChild(0).GetComponent<Image>().color.g, xpObject.transform.GetChild(0).GetComponent<Image>().color.b, 0.0f);
            xpObject.transform.GetChild(17).GetComponent<Image>().color = new Color(xpObject.transform.GetChild(0).GetComponent<Image>().color.r, xpObject.transform.GetChild(0).GetComponent<Image>().color.g, xpObject.transform.GetChild(0).GetComponent<Image>().color.b, 0.0f);
        }
        else if (quotient == 1)
        {
            xpObject.transform.GetChild(9).GetComponent<Image>().color = new Color(xpObject.transform.GetChild(0).GetComponent<Image>().color.r, xpObject.transform.GetChild(0).GetComponent<Image>().color.g, xpObject.transform.GetChild(0).GetComponent<Image>().color.b, 1.0f);
            xpObject.transform.GetChild(10).GetComponent<Image>().color = new Color(xpObject.transform.GetChild(0).GetComponent<Image>().color.r, xpObject.transform.GetChild(0).GetComponent<Image>().color.g, xpObject.transform.GetChild(0).GetComponent<Image>().color.b, 0.0f);
            xpObject.transform.GetChild(11).GetComponent<Image>().color = new Color(xpObject.transform.GetChild(0).GetComponent<Image>().color.r, xpObject.transform.GetChild(0).GetComponent<Image>().color.g, xpObject.transform.GetChild(0).GetComponent<Image>().color.b, 0.0f);
            xpObject.transform.GetChild(12).GetComponent<Image>().color = new Color(xpObject.transform.GetChild(0).GetComponent<Image>().color.r, xpObject.transform.GetChild(0).GetComponent<Image>().color.g, xpObject.transform.GetChild(0).GetComponent<Image>().color.b, 0.0f);
            xpObject.transform.GetChild(13).GetComponent<Image>().color = new Color(xpObject.transform.GetChild(0).GetComponent<Image>().color.r, xpObject.transform.GetChild(0).GetComponent<Image>().color.g, xpObject.transform.GetChild(0).GetComponent<Image>().color.b, 0.0f);
            xpObject.transform.GetChild(14).GetComponent<Image>().color = new Color(xpObject.transform.GetChild(0).GetComponent<Image>().color.r, xpObject.transform.GetChild(0).GetComponent<Image>().color.g, xpObject.transform.GetChild(0).GetComponent<Image>().color.b, 0.0f);
            xpObject.transform.GetChild(15).GetComponent<Image>().color = new Color(xpObject.transform.GetChild(0).GetComponent<Image>().color.r, xpObject.transform.GetChild(0).GetComponent<Image>().color.g, xpObject.transform.GetChild(0).GetComponent<Image>().color.b, 0.0f);
            xpObject.transform.GetChild(16).GetComponent<Image>().color = new Color(xpObject.transform.GetChild(0).GetComponent<Image>().color.r, xpObject.transform.GetChild(0).GetComponent<Image>().color.g, xpObject.transform.GetChild(0).GetComponent<Image>().color.b, 0.0f);
            xpObject.transform.GetChild(17).GetComponent<Image>().color = new Color(xpObject.transform.GetChild(0).GetComponent<Image>().color.r, xpObject.transform.GetChild(0).GetComponent<Image>().color.g, xpObject.transform.GetChild(0).GetComponent<Image>().color.b, 0.0f);
        }
        else if (quotient == 2)
        {
            xpObject.transform.GetChild(9).GetComponent<Image>().color = new Color(xpObject.transform.GetChild(0).GetComponent<Image>().color.r, xpObject.transform.GetChild(0).GetComponent<Image>().color.g, xpObject.transform.GetChild(0).GetComponent<Image>().color.b, 1.0f);
            xpObject.transform.GetChild(10).GetComponent<Image>().color = new Color(xpObject.transform.GetChild(0).GetComponent<Image>().color.r, xpObject.transform.GetChild(0).GetComponent<Image>().color.g, xpObject.transform.GetChild(0).GetComponent<Image>().color.b, 1.0f);
            xpObject.transform.GetChild(11).GetComponent<Image>().color = new Color(xpObject.transform.GetChild(0).GetComponent<Image>().color.r, xpObject.transform.GetChild(0).GetComponent<Image>().color.g, xpObject.transform.GetChild(0).GetComponent<Image>().color.b, 0.0f);
            xpObject.transform.GetChild(12).GetComponent<Image>().color = new Color(xpObject.transform.GetChild(0).GetComponent<Image>().color.r, xpObject.transform.GetChild(0).GetComponent<Image>().color.g, xpObject.transform.GetChild(0).GetComponent<Image>().color.b, 0.0f);
            xpObject.transform.GetChild(13).GetComponent<Image>().color = new Color(xpObject.transform.GetChild(0).GetComponent<Image>().color.r, xpObject.transform.GetChild(0).GetComponent<Image>().color.g, xpObject.transform.GetChild(0).GetComponent<Image>().color.b, 0.0f);
            xpObject.transform.GetChild(14).GetComponent<Image>().color = new Color(xpObject.transform.GetChild(0).GetComponent<Image>().color.r, xpObject.transform.GetChild(0).GetComponent<Image>().color.g, xpObject.transform.GetChild(0).GetComponent<Image>().color.b, 0.0f);
            xpObject.transform.GetChild(15).GetComponent<Image>().color = new Color(xpObject.transform.GetChild(0).GetComponent<Image>().color.r, xpObject.transform.GetChild(0).GetComponent<Image>().color.g, xpObject.transform.GetChild(0).GetComponent<Image>().color.b, 0.0f);
            xpObject.transform.GetChild(16).GetComponent<Image>().color = new Color(xpObject.transform.GetChild(0).GetComponent<Image>().color.r, xpObject.transform.GetChild(0).GetComponent<Image>().color.g, xpObject.transform.GetChild(0).GetComponent<Image>().color.b, 0.0f);
            xpObject.transform.GetChild(17).GetComponent<Image>().color = new Color(xpObject.transform.GetChild(0).GetComponent<Image>().color.r, xpObject.transform.GetChild(0).GetComponent<Image>().color.g, xpObject.transform.GetChild(0).GetComponent<Image>().color.b, 0.0f);
        }
        else if (quotient == 3)
        {
            xpObject.transform.GetChild(9).GetComponent<Image>().color = new Color(xpObject.transform.GetChild(0).GetComponent<Image>().color.r, xpObject.transform.GetChild(0).GetComponent<Image>().color.g, xpObject.transform.GetChild(0).GetComponent<Image>().color.b, 1.0f);
            xpObject.transform.GetChild(10).GetComponent<Image>().color = new Color(xpObject.transform.GetChild(0).GetComponent<Image>().color.r, xpObject.transform.GetChild(0).GetComponent<Image>().color.g, xpObject.transform.GetChild(0).GetComponent<Image>().color.b, 1.0f);
            xpObject.transform.GetChild(11).GetComponent<Image>().color = new Color(xpObject.transform.GetChild(0).GetComponent<Image>().color.r, xpObject.transform.GetChild(0).GetComponent<Image>().color.g, xpObject.transform.GetChild(0).GetComponent<Image>().color.b, 1.0f);
            xpObject.transform.GetChild(12).GetComponent<Image>().color = new Color(xpObject.transform.GetChild(0).GetComponent<Image>().color.r, xpObject.transform.GetChild(0).GetComponent<Image>().color.g, xpObject.transform.GetChild(0).GetComponent<Image>().color.b, 0.0f);
            xpObject.transform.GetChild(13).GetComponent<Image>().color = new Color(xpObject.transform.GetChild(0).GetComponent<Image>().color.r, xpObject.transform.GetChild(0).GetComponent<Image>().color.g, xpObject.transform.GetChild(0).GetComponent<Image>().color.b, 0.0f);
            xpObject.transform.GetChild(14).GetComponent<Image>().color = new Color(xpObject.transform.GetChild(0).GetComponent<Image>().color.r, xpObject.transform.GetChild(0).GetComponent<Image>().color.g, xpObject.transform.GetChild(0).GetComponent<Image>().color.b, 0.0f);
            xpObject.transform.GetChild(15).GetComponent<Image>().color = new Color(xpObject.transform.GetChild(0).GetComponent<Image>().color.r, xpObject.transform.GetChild(0).GetComponent<Image>().color.g, xpObject.transform.GetChild(0).GetComponent<Image>().color.b, 0.0f);
            xpObject.transform.GetChild(16).GetComponent<Image>().color = new Color(xpObject.transform.GetChild(0).GetComponent<Image>().color.r, xpObject.transform.GetChild(0).GetComponent<Image>().color.g, xpObject.transform.GetChild(0).GetComponent<Image>().color.b, 0.0f);
            xpObject.transform.GetChild(17).GetComponent<Image>().color = new Color(xpObject.transform.GetChild(0).GetComponent<Image>().color.r, xpObject.transform.GetChild(0).GetComponent<Image>().color.g, xpObject.transform.GetChild(0).GetComponent<Image>().color.b, 0.0f);
        }
        else if (quotient == 4)
        {
            xpObject.transform.GetChild(9).GetComponent<Image>().color = new Color(xpObject.transform.GetChild(0).GetComponent<Image>().color.r, xpObject.transform.GetChild(0).GetComponent<Image>().color.g, xpObject.transform.GetChild(0).GetComponent<Image>().color.b, 1.0f);
            xpObject.transform.GetChild(10).GetComponent<Image>().color = new Color(xpObject.transform.GetChild(0).GetComponent<Image>().color.r, xpObject.transform.GetChild(0).GetComponent<Image>().color.g, xpObject.transform.GetChild(0).GetComponent<Image>().color.b, 1.0f);
            xpObject.transform.GetChild(11).GetComponent<Image>().color = new Color(xpObject.transform.GetChild(0).GetComponent<Image>().color.r, xpObject.transform.GetChild(0).GetComponent<Image>().color.g, xpObject.transform.GetChild(0).GetComponent<Image>().color.b, 1.0f);
            xpObject.transform.GetChild(12).GetComponent<Image>().color = new Color(xpObject.transform.GetChild(0).GetComponent<Image>().color.r, xpObject.transform.GetChild(0).GetComponent<Image>().color.g, xpObject.transform.GetChild(0).GetComponent<Image>().color.b, 1.0f);
            xpObject.transform.GetChild(13).GetComponent<Image>().color = new Color(xpObject.transform.GetChild(0).GetComponent<Image>().color.r, xpObject.transform.GetChild(0).GetComponent<Image>().color.g, xpObject.transform.GetChild(0).GetComponent<Image>().color.b, 0.0f);
            xpObject.transform.GetChild(14).GetComponent<Image>().color = new Color(xpObject.transform.GetChild(0).GetComponent<Image>().color.r, xpObject.transform.GetChild(0).GetComponent<Image>().color.g, xpObject.transform.GetChild(0).GetComponent<Image>().color.b, 0.0f);
            xpObject.transform.GetChild(15).GetComponent<Image>().color = new Color(xpObject.transform.GetChild(0).GetComponent<Image>().color.r, xpObject.transform.GetChild(0).GetComponent<Image>().color.g, xpObject.transform.GetChild(0).GetComponent<Image>().color.b, 0.0f);
            xpObject.transform.GetChild(16).GetComponent<Image>().color = new Color(xpObject.transform.GetChild(0).GetComponent<Image>().color.r, xpObject.transform.GetChild(0).GetComponent<Image>().color.g, xpObject.transform.GetChild(0).GetComponent<Image>().color.b, 0.0f);
            xpObject.transform.GetChild(17).GetComponent<Image>().color = new Color(xpObject.transform.GetChild(0).GetComponent<Image>().color.r, xpObject.transform.GetChild(0).GetComponent<Image>().color.g, xpObject.transform.GetChild(0).GetComponent<Image>().color.b, 0.0f);
        }
        else if (quotient == 5)
        {
            xpObject.transform.GetChild(9).GetComponent<Image>().color = new Color(xpObject.transform.GetChild(0).GetComponent<Image>().color.r, xpObject.transform.GetChild(0).GetComponent<Image>().color.g, xpObject.transform.GetChild(0).GetComponent<Image>().color.b, 1.0f);
            xpObject.transform.GetChild(10).GetComponent<Image>().color = new Color(xpObject.transform.GetChild(0).GetComponent<Image>().color.r, xpObject.transform.GetChild(0).GetComponent<Image>().color.g, xpObject.transform.GetChild(0).GetComponent<Image>().color.b, 1.0f);
            xpObject.transform.GetChild(11).GetComponent<Image>().color = new Color(xpObject.transform.GetChild(0).GetComponent<Image>().color.r, xpObject.transform.GetChild(0).GetComponent<Image>().color.g, xpObject.transform.GetChild(0).GetComponent<Image>().color.b, 1.0f);
            xpObject.transform.GetChild(12).GetComponent<Image>().color = new Color(xpObject.transform.GetChild(0).GetComponent<Image>().color.r, xpObject.transform.GetChild(0).GetComponent<Image>().color.g, xpObject.transform.GetChild(0).GetComponent<Image>().color.b, 1.0f);
            xpObject.transform.GetChild(13).GetComponent<Image>().color = new Color(xpObject.transform.GetChild(0).GetComponent<Image>().color.r, xpObject.transform.GetChild(0).GetComponent<Image>().color.g, xpObject.transform.GetChild(0).GetComponent<Image>().color.b, 1.0f);
            xpObject.transform.GetChild(14).GetComponent<Image>().color = new Color(xpObject.transform.GetChild(0).GetComponent<Image>().color.r, xpObject.transform.GetChild(0).GetComponent<Image>().color.g, xpObject.transform.GetChild(0).GetComponent<Image>().color.b, 0.0f);
            xpObject.transform.GetChild(15).GetComponent<Image>().color = new Color(xpObject.transform.GetChild(0).GetComponent<Image>().color.r, xpObject.transform.GetChild(0).GetComponent<Image>().color.g, xpObject.transform.GetChild(0).GetComponent<Image>().color.b, 0.0f);
            xpObject.transform.GetChild(16).GetComponent<Image>().color = new Color(xpObject.transform.GetChild(0).GetComponent<Image>().color.r, xpObject.transform.GetChild(0).GetComponent<Image>().color.g, xpObject.transform.GetChild(0).GetComponent<Image>().color.b, 0.0f);
            xpObject.transform.GetChild(17).GetComponent<Image>().color = new Color(xpObject.transform.GetChild(0).GetComponent<Image>().color.r, xpObject.transform.GetChild(0).GetComponent<Image>().color.g, xpObject.transform.GetChild(0).GetComponent<Image>().color.b, 0.0f);
        }
        else if (quotient == 6)
        {
            xpObject.transform.GetChild(9).GetComponent<Image>().color = new Color(xpObject.transform.GetChild(0).GetComponent<Image>().color.r, xpObject.transform.GetChild(0).GetComponent<Image>().color.g, xpObject.transform.GetChild(0).GetComponent<Image>().color.b, 1.0f);
            xpObject.transform.GetChild(10).GetComponent<Image>().color = new Color(xpObject.transform.GetChild(0).GetComponent<Image>().color.r, xpObject.transform.GetChild(0).GetComponent<Image>().color.g, xpObject.transform.GetChild(0).GetComponent<Image>().color.b, 1.0f);
            xpObject.transform.GetChild(11).GetComponent<Image>().color = new Color(xpObject.transform.GetChild(0).GetComponent<Image>().color.r, xpObject.transform.GetChild(0).GetComponent<Image>().color.g, xpObject.transform.GetChild(0).GetComponent<Image>().color.b, 1.0f);
            xpObject.transform.GetChild(12).GetComponent<Image>().color = new Color(xpObject.transform.GetChild(0).GetComponent<Image>().color.r, xpObject.transform.GetChild(0).GetComponent<Image>().color.g, xpObject.transform.GetChild(0).GetComponent<Image>().color.b, 1.0f);
            xpObject.transform.GetChild(13).GetComponent<Image>().color = new Color(xpObject.transform.GetChild(0).GetComponent<Image>().color.r, xpObject.transform.GetChild(0).GetComponent<Image>().color.g, xpObject.transform.GetChild(0).GetComponent<Image>().color.b, 1.0f);
            xpObject.transform.GetChild(14).GetComponent<Image>().color = new Color(xpObject.transform.GetChild(0).GetComponent<Image>().color.r, xpObject.transform.GetChild(0).GetComponent<Image>().color.g, xpObject.transform.GetChild(0).GetComponent<Image>().color.b, 1.0f);
            xpObject.transform.GetChild(15).GetComponent<Image>().color = new Color(xpObject.transform.GetChild(0).GetComponent<Image>().color.r, xpObject.transform.GetChild(0).GetComponent<Image>().color.g, xpObject.transform.GetChild(0).GetComponent<Image>().color.b, 0.0f);
            xpObject.transform.GetChild(16).GetComponent<Image>().color = new Color(xpObject.transform.GetChild(0).GetComponent<Image>().color.r, xpObject.transform.GetChild(0).GetComponent<Image>().color.g, xpObject.transform.GetChild(0).GetComponent<Image>().color.b, 0.0f);
            xpObject.transform.GetChild(17).GetComponent<Image>().color = new Color(xpObject.transform.GetChild(0).GetComponent<Image>().color.r, xpObject.transform.GetChild(0).GetComponent<Image>().color.g, xpObject.transform.GetChild(0).GetComponent<Image>().color.b, 0.0f);
        }
        else if (quotient == 7)
        {
            xpObject.transform.GetChild(9).GetComponent<Image>().color = new Color(xpObject.transform.GetChild(0).GetComponent<Image>().color.r, xpObject.transform.GetChild(0).GetComponent<Image>().color.g, xpObject.transform.GetChild(0).GetComponent<Image>().color.b, 1.0f);
            xpObject.transform.GetChild(10).GetComponent<Image>().color = new Color(xpObject.transform.GetChild(0).GetComponent<Image>().color.r, xpObject.transform.GetChild(0).GetComponent<Image>().color.g, xpObject.transform.GetChild(0).GetComponent<Image>().color.b, 1.0f);
            xpObject.transform.GetChild(11).GetComponent<Image>().color = new Color(xpObject.transform.GetChild(0).GetComponent<Image>().color.r, xpObject.transform.GetChild(0).GetComponent<Image>().color.g, xpObject.transform.GetChild(0).GetComponent<Image>().color.b, 1.0f);
            xpObject.transform.GetChild(12).GetComponent<Image>().color = new Color(xpObject.transform.GetChild(0).GetComponent<Image>().color.r, xpObject.transform.GetChild(0).GetComponent<Image>().color.g, xpObject.transform.GetChild(0).GetComponent<Image>().color.b, 1.0f);
            xpObject.transform.GetChild(13).GetComponent<Image>().color = new Color(xpObject.transform.GetChild(0).GetComponent<Image>().color.r, xpObject.transform.GetChild(0).GetComponent<Image>().color.g, xpObject.transform.GetChild(0).GetComponent<Image>().color.b, 1.0f);
            xpObject.transform.GetChild(14).GetComponent<Image>().color = new Color(xpObject.transform.GetChild(0).GetComponent<Image>().color.r, xpObject.transform.GetChild(0).GetComponent<Image>().color.g, xpObject.transform.GetChild(0).GetComponent<Image>().color.b, 1.0f);
            xpObject.transform.GetChild(15).GetComponent<Image>().color = new Color(xpObject.transform.GetChild(0).GetComponent<Image>().color.r, xpObject.transform.GetChild(0).GetComponent<Image>().color.g, xpObject.transform.GetChild(0).GetComponent<Image>().color.b, 1.0f);
            xpObject.transform.GetChild(16).GetComponent<Image>().color = new Color(xpObject.transform.GetChild(0).GetComponent<Image>().color.r, xpObject.transform.GetChild(0).GetComponent<Image>().color.g, xpObject.transform.GetChild(0).GetComponent<Image>().color.b, 0.0f);
            xpObject.transform.GetChild(17).GetComponent<Image>().color = new Color(xpObject.transform.GetChild(0).GetComponent<Image>().color.r, xpObject.transform.GetChild(0).GetComponent<Image>().color.g, xpObject.transform.GetChild(0).GetComponent<Image>().color.b, 0.0f);
        }
        else if (quotient == 8)
        {
            xpObject.transform.GetChild(9).GetComponent<Image>().color = new Color(xpObject.transform.GetChild(0).GetComponent<Image>().color.r, xpObject.transform.GetChild(0).GetComponent<Image>().color.g, xpObject.transform.GetChild(0).GetComponent<Image>().color.b, 1.0f);
            xpObject.transform.GetChild(10).GetComponent<Image>().color = new Color(xpObject.transform.GetChild(0).GetComponent<Image>().color.r, xpObject.transform.GetChild(0).GetComponent<Image>().color.g, xpObject.transform.GetChild(0).GetComponent<Image>().color.b, 1.0f);
            xpObject.transform.GetChild(11).GetComponent<Image>().color = new Color(xpObject.transform.GetChild(0).GetComponent<Image>().color.r, xpObject.transform.GetChild(0).GetComponent<Image>().color.g, xpObject.transform.GetChild(0).GetComponent<Image>().color.b, 1.0f);
            xpObject.transform.GetChild(12).GetComponent<Image>().color = new Color(xpObject.transform.GetChild(0).GetComponent<Image>().color.r, xpObject.transform.GetChild(0).GetComponent<Image>().color.g, xpObject.transform.GetChild(0).GetComponent<Image>().color.b, 1.0f);
            xpObject.transform.GetChild(13).GetComponent<Image>().color = new Color(xpObject.transform.GetChild(0).GetComponent<Image>().color.r, xpObject.transform.GetChild(0).GetComponent<Image>().color.g, xpObject.transform.GetChild(0).GetComponent<Image>().color.b, 1.0f);
            xpObject.transform.GetChild(14).GetComponent<Image>().color = new Color(xpObject.transform.GetChild(0).GetComponent<Image>().color.r, xpObject.transform.GetChild(0).GetComponent<Image>().color.g, xpObject.transform.GetChild(0).GetComponent<Image>().color.b, 1.0f);
            xpObject.transform.GetChild(15).GetComponent<Image>().color = new Color(xpObject.transform.GetChild(0).GetComponent<Image>().color.r, xpObject.transform.GetChild(0).GetComponent<Image>().color.g, xpObject.transform.GetChild(0).GetComponent<Image>().color.b, 1.0f);
            xpObject.transform.GetChild(16).GetComponent<Image>().color = new Color(xpObject.transform.GetChild(0).GetComponent<Image>().color.r, xpObject.transform.GetChild(0).GetComponent<Image>().color.g, xpObject.transform.GetChild(0).GetComponent<Image>().color.b, 1.0f);
            xpObject.transform.GetChild(17).GetComponent<Image>().color = new Color(xpObject.transform.GetChild(0).GetComponent<Image>().color.r, xpObject.transform.GetChild(0).GetComponent<Image>().color.g, xpObject.transform.GetChild(0).GetComponent<Image>().color.b, 0.0f);
        }
        else if (quotient == 9)
        {
            xpObject.transform.GetChild(9).GetComponent<Image>().color = new Color(xpObject.transform.GetChild(0).GetComponent<Image>().color.r, xpObject.transform.GetChild(0).GetComponent<Image>().color.g, xpObject.transform.GetChild(0).GetComponent<Image>().color.b, 1.0f);
            xpObject.transform.GetChild(10).GetComponent<Image>().color = new Color(xpObject.transform.GetChild(0).GetComponent<Image>().color.r, xpObject.transform.GetChild(0).GetComponent<Image>().color.g, xpObject.transform.GetChild(0).GetComponent<Image>().color.b, 1.0f);
            xpObject.transform.GetChild(11).GetComponent<Image>().color = new Color(xpObject.transform.GetChild(0).GetComponent<Image>().color.r, xpObject.transform.GetChild(0).GetComponent<Image>().color.g, xpObject.transform.GetChild(0).GetComponent<Image>().color.b, 1.0f);
            xpObject.transform.GetChild(12).GetComponent<Image>().color = new Color(xpObject.transform.GetChild(0).GetComponent<Image>().color.r, xpObject.transform.GetChild(0).GetComponent<Image>().color.g, xpObject.transform.GetChild(0).GetComponent<Image>().color.b, 1.0f);
            xpObject.transform.GetChild(13).GetComponent<Image>().color = new Color(xpObject.transform.GetChild(0).GetComponent<Image>().color.r, xpObject.transform.GetChild(0).GetComponent<Image>().color.g, xpObject.transform.GetChild(0).GetComponent<Image>().color.b, 1.0f);
            xpObject.transform.GetChild(14).GetComponent<Image>().color = new Color(xpObject.transform.GetChild(0).GetComponent<Image>().color.r, xpObject.transform.GetChild(0).GetComponent<Image>().color.g, xpObject.transform.GetChild(0).GetComponent<Image>().color.b, 1.0f);
            xpObject.transform.GetChild(15).GetComponent<Image>().color = new Color(xpObject.transform.GetChild(0).GetComponent<Image>().color.r, xpObject.transform.GetChild(0).GetComponent<Image>().color.g, xpObject.transform.GetChild(0).GetComponent<Image>().color.b, 1.0f);
            xpObject.transform.GetChild(16).GetComponent<Image>().color = new Color(xpObject.transform.GetChild(0).GetComponent<Image>().color.r, xpObject.transform.GetChild(0).GetComponent<Image>().color.g, xpObject.transform.GetChild(0).GetComponent<Image>().color.b, 1.0f);
            xpObject.transform.GetChild(17).GetComponent<Image>().color = new Color(xpObject.transform.GetChild(0).GetComponent<Image>().color.r, xpObject.transform.GetChild(0).GetComponent<Image>().color.g, xpObject.transform.GetChild(0).GetComponent<Image>().color.b, 1.0f);
        }
    }

    //Function to show the victory xp
    private void ShowVictoryXP()
    {
        int rest = currentFightXP % 10;
        int quotient = currentFightXP / 10;
        if (rest == 0)
        {
            victoryXP.transform.GetChild(0).GetComponent<Image>().color = new Color(victoryXP.transform.GetChild(0).GetComponent<Image>().color.r, victoryXP.transform.GetChild(0).GetComponent<Image>().color.g, victoryXP.transform.GetChild(0).GetComponent<Image>().color.b, 0.0f);
            victoryXP.transform.GetChild(1).GetComponent<Image>().color = new Color(victoryXP.transform.GetChild(0).GetComponent<Image>().color.r, victoryXP.transform.GetChild(0).GetComponent<Image>().color.g, victoryXP.transform.GetChild(0).GetComponent<Image>().color.b, 0.0f);
            victoryXP.transform.GetChild(2).GetComponent<Image>().color = new Color(victoryXP.transform.GetChild(0).GetComponent<Image>().color.r, victoryXP.transform.GetChild(0).GetComponent<Image>().color.g, victoryXP.transform.GetChild(0).GetComponent<Image>().color.b, 0.0f);
            victoryXP.transform.GetChild(3).GetComponent<Image>().color = new Color(victoryXP.transform.GetChild(0).GetComponent<Image>().color.r, victoryXP.transform.GetChild(0).GetComponent<Image>().color.g, victoryXP.transform.GetChild(0).GetComponent<Image>().color.b, 0.0f);
            victoryXP.transform.GetChild(4).GetComponent<Image>().color = new Color(victoryXP.transform.GetChild(0).GetComponent<Image>().color.r, victoryXP.transform.GetChild(0).GetComponent<Image>().color.g, victoryXP.transform.GetChild(0).GetComponent<Image>().color.b, 0.0f);
            victoryXP.transform.GetChild(5).GetComponent<Image>().color = new Color(victoryXP.transform.GetChild(0).GetComponent<Image>().color.r, victoryXP.transform.GetChild(0).GetComponent<Image>().color.g, victoryXP.transform.GetChild(0).GetComponent<Image>().color.b, 0.0f);
            victoryXP.transform.GetChild(6).GetComponent<Image>().color = new Color(victoryXP.transform.GetChild(0).GetComponent<Image>().color.r, victoryXP.transform.GetChild(0).GetComponent<Image>().color.g, victoryXP.transform.GetChild(0).GetComponent<Image>().color.b, 0.0f);
            victoryXP.transform.GetChild(7).GetComponent<Image>().color = new Color(victoryXP.transform.GetChild(0).GetComponent<Image>().color.r, victoryXP.transform.GetChild(0).GetComponent<Image>().color.g, victoryXP.transform.GetChild(0).GetComponent<Image>().color.b, 0.0f);
            victoryXP.transform.GetChild(8).GetComponent<Image>().color = new Color(victoryXP.transform.GetChild(0).GetComponent<Image>().color.r, victoryXP.transform.GetChild(0).GetComponent<Image>().color.g, victoryXP.transform.GetChild(0).GetComponent<Image>().color.b, 0.0f);
        }
        else if (rest == 1)
        {
            victoryXP.transform.GetChild(0).GetComponent<Image>().color = new Color(victoryXP.transform.GetChild(0).GetComponent<Image>().color.r, victoryXP.transform.GetChild(0).GetComponent<Image>().color.g, victoryXP.transform.GetChild(0).GetComponent<Image>().color.b, 1.0f);
            victoryXP.transform.GetChild(1).GetComponent<Image>().color = new Color(victoryXP.transform.GetChild(0).GetComponent<Image>().color.r, victoryXP.transform.GetChild(0).GetComponent<Image>().color.g, victoryXP.transform.GetChild(0).GetComponent<Image>().color.b, 0.0f);
            victoryXP.transform.GetChild(2).GetComponent<Image>().color = new Color(victoryXP.transform.GetChild(0).GetComponent<Image>().color.r, victoryXP.transform.GetChild(0).GetComponent<Image>().color.g, victoryXP.transform.GetChild(0).GetComponent<Image>().color.b, 0.0f);
            victoryXP.transform.GetChild(3).GetComponent<Image>().color = new Color(victoryXP.transform.GetChild(0).GetComponent<Image>().color.r, victoryXP.transform.GetChild(0).GetComponent<Image>().color.g, victoryXP.transform.GetChild(0).GetComponent<Image>().color.b, 0.0f);
            victoryXP.transform.GetChild(4).GetComponent<Image>().color = new Color(victoryXP.transform.GetChild(0).GetComponent<Image>().color.r, victoryXP.transform.GetChild(0).GetComponent<Image>().color.g, victoryXP.transform.GetChild(0).GetComponent<Image>().color.b, 0.0f);
            victoryXP.transform.GetChild(5).GetComponent<Image>().color = new Color(victoryXP.transform.GetChild(0).GetComponent<Image>().color.r, victoryXP.transform.GetChild(0).GetComponent<Image>().color.g, victoryXP.transform.GetChild(0).GetComponent<Image>().color.b, 0.0f);
            victoryXP.transform.GetChild(6).GetComponent<Image>().color = new Color(victoryXP.transform.GetChild(0).GetComponent<Image>().color.r, victoryXP.transform.GetChild(0).GetComponent<Image>().color.g, victoryXP.transform.GetChild(0).GetComponent<Image>().color.b, 0.0f);
            victoryXP.transform.GetChild(7).GetComponent<Image>().color = new Color(victoryXP.transform.GetChild(0).GetComponent<Image>().color.r, victoryXP.transform.GetChild(0).GetComponent<Image>().color.g, victoryXP.transform.GetChild(0).GetComponent<Image>().color.b, 0.0f);
            victoryXP.transform.GetChild(8).GetComponent<Image>().color = new Color(victoryXP.transform.GetChild(0).GetComponent<Image>().color.r, victoryXP.transform.GetChild(0).GetComponent<Image>().color.g, victoryXP.transform.GetChild(0).GetComponent<Image>().color.b, 0.0f);
        }
        else if (rest == 2)
        {
            victoryXP.transform.GetChild(0).GetComponent<Image>().color = new Color(victoryXP.transform.GetChild(0).GetComponent<Image>().color.r, victoryXP.transform.GetChild(0).GetComponent<Image>().color.g, victoryXP.transform.GetChild(0).GetComponent<Image>().color.b, 1.0f);
            victoryXP.transform.GetChild(1).GetComponent<Image>().color = new Color(victoryXP.transform.GetChild(0).GetComponent<Image>().color.r, victoryXP.transform.GetChild(0).GetComponent<Image>().color.g, victoryXP.transform.GetChild(0).GetComponent<Image>().color.b, 1.0f);
            victoryXP.transform.GetChild(2).GetComponent<Image>().color = new Color(victoryXP.transform.GetChild(0).GetComponent<Image>().color.r, victoryXP.transform.GetChild(0).GetComponent<Image>().color.g, victoryXP.transform.GetChild(0).GetComponent<Image>().color.b, 0.0f);
            victoryXP.transform.GetChild(3).GetComponent<Image>().color = new Color(victoryXP.transform.GetChild(0).GetComponent<Image>().color.r, victoryXP.transform.GetChild(0).GetComponent<Image>().color.g, victoryXP.transform.GetChild(0).GetComponent<Image>().color.b, 0.0f);
            victoryXP.transform.GetChild(4).GetComponent<Image>().color = new Color(victoryXP.transform.GetChild(0).GetComponent<Image>().color.r, victoryXP.transform.GetChild(0).GetComponent<Image>().color.g, victoryXP.transform.GetChild(0).GetComponent<Image>().color.b, 0.0f);
            victoryXP.transform.GetChild(5).GetComponent<Image>().color = new Color(victoryXP.transform.GetChild(0).GetComponent<Image>().color.r, victoryXP.transform.GetChild(0).GetComponent<Image>().color.g, victoryXP.transform.GetChild(0).GetComponent<Image>().color.b, 0.0f);
            victoryXP.transform.GetChild(6).GetComponent<Image>().color = new Color(victoryXP.transform.GetChild(0).GetComponent<Image>().color.r, victoryXP.transform.GetChild(0).GetComponent<Image>().color.g, victoryXP.transform.GetChild(0).GetComponent<Image>().color.b, 0.0f);
            victoryXP.transform.GetChild(7).GetComponent<Image>().color = new Color(victoryXP.transform.GetChild(0).GetComponent<Image>().color.r, victoryXP.transform.GetChild(0).GetComponent<Image>().color.g, victoryXP.transform.GetChild(0).GetComponent<Image>().color.b, 0.0f);
            victoryXP.transform.GetChild(8).GetComponent<Image>().color = new Color(victoryXP.transform.GetChild(0).GetComponent<Image>().color.r, victoryXP.transform.GetChild(0).GetComponent<Image>().color.g, victoryXP.transform.GetChild(0).GetComponent<Image>().color.b, 0.0f);
        }
        else if (rest == 3)
        {
            victoryXP.transform.GetChild(0).GetComponent<Image>().color = new Color(victoryXP.transform.GetChild(0).GetComponent<Image>().color.r, victoryXP.transform.GetChild(0).GetComponent<Image>().color.g, victoryXP.transform.GetChild(0).GetComponent<Image>().color.b, 1.0f);
            victoryXP.transform.GetChild(1).GetComponent<Image>().color = new Color(victoryXP.transform.GetChild(0).GetComponent<Image>().color.r, victoryXP.transform.GetChild(0).GetComponent<Image>().color.g, victoryXP.transform.GetChild(0).GetComponent<Image>().color.b, 1.0f);
            victoryXP.transform.GetChild(2).GetComponent<Image>().color = new Color(victoryXP.transform.GetChild(0).GetComponent<Image>().color.r, victoryXP.transform.GetChild(0).GetComponent<Image>().color.g, victoryXP.transform.GetChild(0).GetComponent<Image>().color.b, 1.0f);
            victoryXP.transform.GetChild(3).GetComponent<Image>().color = new Color(victoryXP.transform.GetChild(0).GetComponent<Image>().color.r, victoryXP.transform.GetChild(0).GetComponent<Image>().color.g, victoryXP.transform.GetChild(0).GetComponent<Image>().color.b, 0.0f);
            victoryXP.transform.GetChild(4).GetComponent<Image>().color = new Color(victoryXP.transform.GetChild(0).GetComponent<Image>().color.r, victoryXP.transform.GetChild(0).GetComponent<Image>().color.g, victoryXP.transform.GetChild(0).GetComponent<Image>().color.b, 0.0f);
            victoryXP.transform.GetChild(5).GetComponent<Image>().color = new Color(victoryXP.transform.GetChild(0).GetComponent<Image>().color.r, victoryXP.transform.GetChild(0).GetComponent<Image>().color.g, victoryXP.transform.GetChild(0).GetComponent<Image>().color.b, 0.0f);
            victoryXP.transform.GetChild(6).GetComponent<Image>().color = new Color(victoryXP.transform.GetChild(0).GetComponent<Image>().color.r, victoryXP.transform.GetChild(0).GetComponent<Image>().color.g, victoryXP.transform.GetChild(0).GetComponent<Image>().color.b, 0.0f);
            victoryXP.transform.GetChild(7).GetComponent<Image>().color = new Color(victoryXP.transform.GetChild(0).GetComponent<Image>().color.r, victoryXP.transform.GetChild(0).GetComponent<Image>().color.g, victoryXP.transform.GetChild(0).GetComponent<Image>().color.b, 0.0f);
            victoryXP.transform.GetChild(8).GetComponent<Image>().color = new Color(victoryXP.transform.GetChild(0).GetComponent<Image>().color.r, victoryXP.transform.GetChild(0).GetComponent<Image>().color.g, victoryXP.transform.GetChild(0).GetComponent<Image>().color.b, 0.0f);
        }
        else if (rest == 4)
        {
            victoryXP.transform.GetChild(0).GetComponent<Image>().color = new Color(victoryXP.transform.GetChild(0).GetComponent<Image>().color.r, victoryXP.transform.GetChild(0).GetComponent<Image>().color.g, victoryXP.transform.GetChild(0).GetComponent<Image>().color.b, 1.0f);
            victoryXP.transform.GetChild(1).GetComponent<Image>().color = new Color(victoryXP.transform.GetChild(0).GetComponent<Image>().color.r, victoryXP.transform.GetChild(0).GetComponent<Image>().color.g, victoryXP.transform.GetChild(0).GetComponent<Image>().color.b, 1.0f);
            victoryXP.transform.GetChild(2).GetComponent<Image>().color = new Color(victoryXP.transform.GetChild(0).GetComponent<Image>().color.r, victoryXP.transform.GetChild(0).GetComponent<Image>().color.g, victoryXP.transform.GetChild(0).GetComponent<Image>().color.b, 1.0f);
            victoryXP.transform.GetChild(3).GetComponent<Image>().color = new Color(victoryXP.transform.GetChild(0).GetComponent<Image>().color.r, victoryXP.transform.GetChild(0).GetComponent<Image>().color.g, victoryXP.transform.GetChild(0).GetComponent<Image>().color.b, 1.0f);
            victoryXP.transform.GetChild(4).GetComponent<Image>().color = new Color(victoryXP.transform.GetChild(0).GetComponent<Image>().color.r, victoryXP.transform.GetChild(0).GetComponent<Image>().color.g, victoryXP.transform.GetChild(0).GetComponent<Image>().color.b, 0.0f);
            victoryXP.transform.GetChild(5).GetComponent<Image>().color = new Color(victoryXP.transform.GetChild(0).GetComponent<Image>().color.r, victoryXP.transform.GetChild(0).GetComponent<Image>().color.g, victoryXP.transform.GetChild(0).GetComponent<Image>().color.b, 0.0f);
            victoryXP.transform.GetChild(6).GetComponent<Image>().color = new Color(victoryXP.transform.GetChild(0).GetComponent<Image>().color.r, victoryXP.transform.GetChild(0).GetComponent<Image>().color.g, victoryXP.transform.GetChild(0).GetComponent<Image>().color.b, 0.0f);
            victoryXP.transform.GetChild(7).GetComponent<Image>().color = new Color(victoryXP.transform.GetChild(0).GetComponent<Image>().color.r, victoryXP.transform.GetChild(0).GetComponent<Image>().color.g, victoryXP.transform.GetChild(0).GetComponent<Image>().color.b, 0.0f);
            victoryXP.transform.GetChild(8).GetComponent<Image>().color = new Color(victoryXP.transform.GetChild(0).GetComponent<Image>().color.r, victoryXP.transform.GetChild(0).GetComponent<Image>().color.g, victoryXP.transform.GetChild(0).GetComponent<Image>().color.b, 0.0f);
        }
        else if (rest == 5)
        {
            victoryXP.transform.GetChild(0).GetComponent<Image>().color = new Color(victoryXP.transform.GetChild(0).GetComponent<Image>().color.r, victoryXP.transform.GetChild(0).GetComponent<Image>().color.g, victoryXP.transform.GetChild(0).GetComponent<Image>().color.b, 1.0f);
            victoryXP.transform.GetChild(1).GetComponent<Image>().color = new Color(victoryXP.transform.GetChild(0).GetComponent<Image>().color.r, victoryXP.transform.GetChild(0).GetComponent<Image>().color.g, victoryXP.transform.GetChild(0).GetComponent<Image>().color.b, 1.0f);
            victoryXP.transform.GetChild(2).GetComponent<Image>().color = new Color(victoryXP.transform.GetChild(0).GetComponent<Image>().color.r, victoryXP.transform.GetChild(0).GetComponent<Image>().color.g, victoryXP.transform.GetChild(0).GetComponent<Image>().color.b, 1.0f);
            victoryXP.transform.GetChild(3).GetComponent<Image>().color = new Color(victoryXP.transform.GetChild(0).GetComponent<Image>().color.r, victoryXP.transform.GetChild(0).GetComponent<Image>().color.g, victoryXP.transform.GetChild(0).GetComponent<Image>().color.b, 1.0f);
            victoryXP.transform.GetChild(4).GetComponent<Image>().color = new Color(victoryXP.transform.GetChild(0).GetComponent<Image>().color.r, victoryXP.transform.GetChild(0).GetComponent<Image>().color.g, victoryXP.transform.GetChild(0).GetComponent<Image>().color.b, 1.0f);
            victoryXP.transform.GetChild(5).GetComponent<Image>().color = new Color(victoryXP.transform.GetChild(0).GetComponent<Image>().color.r, victoryXP.transform.GetChild(0).GetComponent<Image>().color.g, victoryXP.transform.GetChild(0).GetComponent<Image>().color.b, 0.0f);
            victoryXP.transform.GetChild(6).GetComponent<Image>().color = new Color(victoryXP.transform.GetChild(0).GetComponent<Image>().color.r, victoryXP.transform.GetChild(0).GetComponent<Image>().color.g, victoryXP.transform.GetChild(0).GetComponent<Image>().color.b, 0.0f);
            victoryXP.transform.GetChild(7).GetComponent<Image>().color = new Color(victoryXP.transform.GetChild(0).GetComponent<Image>().color.r, victoryXP.transform.GetChild(0).GetComponent<Image>().color.g, victoryXP.transform.GetChild(0).GetComponent<Image>().color.b, 0.0f);
            victoryXP.transform.GetChild(8).GetComponent<Image>().color = new Color(victoryXP.transform.GetChild(0).GetComponent<Image>().color.r, victoryXP.transform.GetChild(0).GetComponent<Image>().color.g, victoryXP.transform.GetChild(0).GetComponent<Image>().color.b, 0.0f);
        }
        else if (rest == 6)
        {
            victoryXP.transform.GetChild(0).GetComponent<Image>().color = new Color(victoryXP.transform.GetChild(0).GetComponent<Image>().color.r, victoryXP.transform.GetChild(0).GetComponent<Image>().color.g, victoryXP.transform.GetChild(0).GetComponent<Image>().color.b, 1.0f);
            victoryXP.transform.GetChild(1).GetComponent<Image>().color = new Color(victoryXP.transform.GetChild(0).GetComponent<Image>().color.r, victoryXP.transform.GetChild(0).GetComponent<Image>().color.g, victoryXP.transform.GetChild(0).GetComponent<Image>().color.b, 1.0f);
            victoryXP.transform.GetChild(2).GetComponent<Image>().color = new Color(victoryXP.transform.GetChild(0).GetComponent<Image>().color.r, victoryXP.transform.GetChild(0).GetComponent<Image>().color.g, victoryXP.transform.GetChild(0).GetComponent<Image>().color.b, 1.0f);
            victoryXP.transform.GetChild(3).GetComponent<Image>().color = new Color(victoryXP.transform.GetChild(0).GetComponent<Image>().color.r, victoryXP.transform.GetChild(0).GetComponent<Image>().color.g, victoryXP.transform.GetChild(0).GetComponent<Image>().color.b, 1.0f);
            victoryXP.transform.GetChild(4).GetComponent<Image>().color = new Color(victoryXP.transform.GetChild(0).GetComponent<Image>().color.r, victoryXP.transform.GetChild(0).GetComponent<Image>().color.g, victoryXP.transform.GetChild(0).GetComponent<Image>().color.b, 1.0f);
            victoryXP.transform.GetChild(5).GetComponent<Image>().color = new Color(victoryXP.transform.GetChild(0).GetComponent<Image>().color.r, victoryXP.transform.GetChild(0).GetComponent<Image>().color.g, victoryXP.transform.GetChild(0).GetComponent<Image>().color.b, 1.0f);
            victoryXP.transform.GetChild(6).GetComponent<Image>().color = new Color(victoryXP.transform.GetChild(0).GetComponent<Image>().color.r, victoryXP.transform.GetChild(0).GetComponent<Image>().color.g, victoryXP.transform.GetChild(0).GetComponent<Image>().color.b, 0.0f);
            victoryXP.transform.GetChild(7).GetComponent<Image>().color = new Color(victoryXP.transform.GetChild(0).GetComponent<Image>().color.r, victoryXP.transform.GetChild(0).GetComponent<Image>().color.g, victoryXP.transform.GetChild(0).GetComponent<Image>().color.b, 0.0f);
            victoryXP.transform.GetChild(8).GetComponent<Image>().color = new Color(victoryXP.transform.GetChild(0).GetComponent<Image>().color.r, victoryXP.transform.GetChild(0).GetComponent<Image>().color.g, victoryXP.transform.GetChild(0).GetComponent<Image>().color.b, 0.0f);
        }
        else if (rest == 7)
        {
            victoryXP.transform.GetChild(0).GetComponent<Image>().color = new Color(victoryXP.transform.GetChild(0).GetComponent<Image>().color.r, victoryXP.transform.GetChild(0).GetComponent<Image>().color.g, victoryXP.transform.GetChild(0).GetComponent<Image>().color.b, 1.0f);
            victoryXP.transform.GetChild(1).GetComponent<Image>().color = new Color(victoryXP.transform.GetChild(0).GetComponent<Image>().color.r, victoryXP.transform.GetChild(0).GetComponent<Image>().color.g, victoryXP.transform.GetChild(0).GetComponent<Image>().color.b, 1.0f);
            victoryXP.transform.GetChild(2).GetComponent<Image>().color = new Color(victoryXP.transform.GetChild(0).GetComponent<Image>().color.r, victoryXP.transform.GetChild(0).GetComponent<Image>().color.g, victoryXP.transform.GetChild(0).GetComponent<Image>().color.b, 1.0f);
            victoryXP.transform.GetChild(3).GetComponent<Image>().color = new Color(victoryXP.transform.GetChild(0).GetComponent<Image>().color.r, victoryXP.transform.GetChild(0).GetComponent<Image>().color.g, victoryXP.transform.GetChild(0).GetComponent<Image>().color.b, 1.0f);
            victoryXP.transform.GetChild(4).GetComponent<Image>().color = new Color(victoryXP.transform.GetChild(0).GetComponent<Image>().color.r, victoryXP.transform.GetChild(0).GetComponent<Image>().color.g, victoryXP.transform.GetChild(0).GetComponent<Image>().color.b, 1.0f);
            victoryXP.transform.GetChild(5).GetComponent<Image>().color = new Color(victoryXP.transform.GetChild(0).GetComponent<Image>().color.r, victoryXP.transform.GetChild(0).GetComponent<Image>().color.g, victoryXP.transform.GetChild(0).GetComponent<Image>().color.b, 1.0f);
            victoryXP.transform.GetChild(6).GetComponent<Image>().color = new Color(victoryXP.transform.GetChild(0).GetComponent<Image>().color.r, victoryXP.transform.GetChild(0).GetComponent<Image>().color.g, victoryXP.transform.GetChild(0).GetComponent<Image>().color.b, 1.0f);
            victoryXP.transform.GetChild(7).GetComponent<Image>().color = new Color(victoryXP.transform.GetChild(0).GetComponent<Image>().color.r, victoryXP.transform.GetChild(0).GetComponent<Image>().color.g, victoryXP.transform.GetChild(0).GetComponent<Image>().color.b, 0.0f);
            victoryXP.transform.GetChild(8).GetComponent<Image>().color = new Color(victoryXP.transform.GetChild(0).GetComponent<Image>().color.r, victoryXP.transform.GetChild(0).GetComponent<Image>().color.g, victoryXP.transform.GetChild(0).GetComponent<Image>().color.b, 0.0f);
        }
        else if (rest == 8)
        {
            victoryXP.transform.GetChild(0).GetComponent<Image>().color = new Color(victoryXP.transform.GetChild(0).GetComponent<Image>().color.r, victoryXP.transform.GetChild(0).GetComponent<Image>().color.g, victoryXP.transform.GetChild(0).GetComponent<Image>().color.b, 1.0f);
            victoryXP.transform.GetChild(1).GetComponent<Image>().color = new Color(victoryXP.transform.GetChild(0).GetComponent<Image>().color.r, victoryXP.transform.GetChild(0).GetComponent<Image>().color.g, victoryXP.transform.GetChild(0).GetComponent<Image>().color.b, 1.0f);
            victoryXP.transform.GetChild(2).GetComponent<Image>().color = new Color(victoryXP.transform.GetChild(0).GetComponent<Image>().color.r, victoryXP.transform.GetChild(0).GetComponent<Image>().color.g, victoryXP.transform.GetChild(0).GetComponent<Image>().color.b, 1.0f);
            victoryXP.transform.GetChild(3).GetComponent<Image>().color = new Color(victoryXP.transform.GetChild(0).GetComponent<Image>().color.r, victoryXP.transform.GetChild(0).GetComponent<Image>().color.g, victoryXP.transform.GetChild(0).GetComponent<Image>().color.b, 1.0f);
            victoryXP.transform.GetChild(4).GetComponent<Image>().color = new Color(victoryXP.transform.GetChild(0).GetComponent<Image>().color.r, victoryXP.transform.GetChild(0).GetComponent<Image>().color.g, victoryXP.transform.GetChild(0).GetComponent<Image>().color.b, 1.0f);
            victoryXP.transform.GetChild(5).GetComponent<Image>().color = new Color(victoryXP.transform.GetChild(0).GetComponent<Image>().color.r, victoryXP.transform.GetChild(0).GetComponent<Image>().color.g, victoryXP.transform.GetChild(0).GetComponent<Image>().color.b, 1.0f);
            victoryXP.transform.GetChild(6).GetComponent<Image>().color = new Color(victoryXP.transform.GetChild(0).GetComponent<Image>().color.r, victoryXP.transform.GetChild(0).GetComponent<Image>().color.g, victoryXP.transform.GetChild(0).GetComponent<Image>().color.b, 1.0f);
            victoryXP.transform.GetChild(7).GetComponent<Image>().color = new Color(victoryXP.transform.GetChild(0).GetComponent<Image>().color.r, victoryXP.transform.GetChild(0).GetComponent<Image>().color.g, victoryXP.transform.GetChild(0).GetComponent<Image>().color.b, 1.0f);
            victoryXP.transform.GetChild(8).GetComponent<Image>().color = new Color(victoryXP.transform.GetChild(0).GetComponent<Image>().color.r, victoryXP.transform.GetChild(0).GetComponent<Image>().color.g, victoryXP.transform.GetChild(0).GetComponent<Image>().color.b, 0.0f);
        }
        else if (rest == 9)
        {
            victoryXP.transform.GetChild(0).GetComponent<Image>().color = new Color(victoryXP.transform.GetChild(0).GetComponent<Image>().color.r, victoryXP.transform.GetChild(0).GetComponent<Image>().color.g, victoryXP.transform.GetChild(0).GetComponent<Image>().color.b, 1.0f);
            victoryXP.transform.GetChild(1).GetComponent<Image>().color = new Color(victoryXP.transform.GetChild(0).GetComponent<Image>().color.r, victoryXP.transform.GetChild(0).GetComponent<Image>().color.g, victoryXP.transform.GetChild(0).GetComponent<Image>().color.b, 1.0f);
            victoryXP.transform.GetChild(2).GetComponent<Image>().color = new Color(victoryXP.transform.GetChild(0).GetComponent<Image>().color.r, victoryXP.transform.GetChild(0).GetComponent<Image>().color.g, victoryXP.transform.GetChild(0).GetComponent<Image>().color.b, 1.0f);
            victoryXP.transform.GetChild(3).GetComponent<Image>().color = new Color(victoryXP.transform.GetChild(0).GetComponent<Image>().color.r, victoryXP.transform.GetChild(0).GetComponent<Image>().color.g, victoryXP.transform.GetChild(0).GetComponent<Image>().color.b, 1.0f);
            victoryXP.transform.GetChild(4).GetComponent<Image>().color = new Color(victoryXP.transform.GetChild(0).GetComponent<Image>().color.r, victoryXP.transform.GetChild(0).GetComponent<Image>().color.g, victoryXP.transform.GetChild(0).GetComponent<Image>().color.b, 1.0f);
            victoryXP.transform.GetChild(5).GetComponent<Image>().color = new Color(victoryXP.transform.GetChild(0).GetComponent<Image>().color.r, victoryXP.transform.GetChild(0).GetComponent<Image>().color.g, victoryXP.transform.GetChild(0).GetComponent<Image>().color.b, 1.0f);
            victoryXP.transform.GetChild(6).GetComponent<Image>().color = new Color(victoryXP.transform.GetChild(0).GetComponent<Image>().color.r, victoryXP.transform.GetChild(0).GetComponent<Image>().color.g, victoryXP.transform.GetChild(0).GetComponent<Image>().color.b, 1.0f);
            victoryXP.transform.GetChild(7).GetComponent<Image>().color = new Color(victoryXP.transform.GetChild(0).GetComponent<Image>().color.r, victoryXP.transform.GetChild(0).GetComponent<Image>().color.g, victoryXP.transform.GetChild(0).GetComponent<Image>().color.b, 1.0f);
            victoryXP.transform.GetChild(8).GetComponent<Image>().color = new Color(victoryXP.transform.GetChild(0).GetComponent<Image>().color.r, victoryXP.transform.GetChild(0).GetComponent<Image>().color.g, victoryXP.transform.GetChild(0).GetComponent<Image>().color.b, 1.0f);
        }
        if (quotient == 0)
        {
            victoryXP.transform.GetChild(9).gameObject.SetActive(false);
            victoryXP.transform.GetChild(10).gameObject.SetActive(false);
            victoryXP.transform.GetChild(11).gameObject.SetActive(false);
            victoryXP.transform.GetChild(12).gameObject.SetActive(false);
            victoryXP.transform.GetChild(13).gameObject.SetActive(false);
            victoryXP.transform.GetChild(14).gameObject.SetActive(false);
            victoryXP.transform.GetChild(15).gameObject.SetActive(false);
            victoryXP.transform.GetChild(16).gameObject.SetActive(false);
            victoryXP.transform.GetChild(17).gameObject.SetActive(false);
        }
        else if (quotient == 1)
        {
            victoryXP.transform.GetChild(9).gameObject.SetActive(true);
            victoryXP.transform.GetChild(10).gameObject.SetActive(false);
            victoryXP.transform.GetChild(11).gameObject.SetActive(false);
            victoryXP.transform.GetChild(12).gameObject.SetActive(false);
            victoryXP.transform.GetChild(13).gameObject.SetActive(false);
            victoryXP.transform.GetChild(14).gameObject.SetActive(false);
            victoryXP.transform.GetChild(15).gameObject.SetActive(false);
            victoryXP.transform.GetChild(16).gameObject.SetActive(false);
            victoryXP.transform.GetChild(17).gameObject.SetActive(false);
        }
        else if (quotient == 2)
        {
            victoryXP.transform.GetChild(9).gameObject.SetActive(false);
            victoryXP.transform.GetChild(10).gameObject.SetActive(true);
            victoryXP.transform.GetChild(11).gameObject.SetActive(false);
            victoryXP.transform.GetChild(12).gameObject.SetActive(false);
            victoryXP.transform.GetChild(13).gameObject.SetActive(false);
            victoryXP.transform.GetChild(14).gameObject.SetActive(false);
            victoryXP.transform.GetChild(15).gameObject.SetActive(false);
            victoryXP.transform.GetChild(16).gameObject.SetActive(false);
            victoryXP.transform.GetChild(17).gameObject.SetActive(false);
        }
        else if (quotient == 3)
        {
            victoryXP.transform.GetChild(9).gameObject.SetActive(false);
            victoryXP.transform.GetChild(10).gameObject.SetActive(false);
            victoryXP.transform.GetChild(11).gameObject.SetActive(true);
            victoryXP.transform.GetChild(12).gameObject.SetActive(false);
            victoryXP.transform.GetChild(13).gameObject.SetActive(false);
            victoryXP.transform.GetChild(14).gameObject.SetActive(false);
            victoryXP.transform.GetChild(15).gameObject.SetActive(false);
            victoryXP.transform.GetChild(16).gameObject.SetActive(false);
            victoryXP.transform.GetChild(17).gameObject.SetActive(false);
        }
        else if (quotient == 4)
        {
            victoryXP.transform.GetChild(9).gameObject.SetActive(false);
            victoryXP.transform.GetChild(10).gameObject.SetActive(false);
            victoryXP.transform.GetChild(11).gameObject.SetActive(false);
            victoryXP.transform.GetChild(12).gameObject.SetActive(true);
            victoryXP.transform.GetChild(13).gameObject.SetActive(false);
            victoryXP.transform.GetChild(14).gameObject.SetActive(false);
            victoryXP.transform.GetChild(15).gameObject.SetActive(false);
            victoryXP.transform.GetChild(16).gameObject.SetActive(false);
            victoryXP.transform.GetChild(17).gameObject.SetActive(false);
        }
        else if (quotient == 5)
        {
            victoryXP.transform.GetChild(9).gameObject.SetActive(false);
            victoryXP.transform.GetChild(10).gameObject.SetActive(false);
            victoryXP.transform.GetChild(11).gameObject.SetActive(false);
            victoryXP.transform.GetChild(12).gameObject.SetActive(false);
            victoryXP.transform.GetChild(13).gameObject.SetActive(true);
            victoryXP.transform.GetChild(14).gameObject.SetActive(false);
            victoryXP.transform.GetChild(15).gameObject.SetActive(false);
            victoryXP.transform.GetChild(16).gameObject.SetActive(false);
            victoryXP.transform.GetChild(17).gameObject.SetActive(false);
        }
        else if (quotient == 6)
        {
            victoryXP.transform.GetChild(9).gameObject.SetActive(false);
            victoryXP.transform.GetChild(10).gameObject.SetActive(false);
            victoryXP.transform.GetChild(11).gameObject.SetActive(false);
            victoryXP.transform.GetChild(12).gameObject.SetActive(false);
            victoryXP.transform.GetChild(13).gameObject.SetActive(false);
            victoryXP.transform.GetChild(14).gameObject.SetActive(true);
            victoryXP.transform.GetChild(15).gameObject.SetActive(false);
            victoryXP.transform.GetChild(16).gameObject.SetActive(false);
            victoryXP.transform.GetChild(17).gameObject.SetActive(false);
        }
        else if (quotient == 7)
        {
            victoryXP.transform.GetChild(9).gameObject.SetActive(false);
            victoryXP.transform.GetChild(10).gameObject.SetActive(false);
            victoryXP.transform.GetChild(11).gameObject.SetActive(false);
            victoryXP.transform.GetChild(12).gameObject.SetActive(false);
            victoryXP.transform.GetChild(13).gameObject.SetActive(false);
            victoryXP.transform.GetChild(14).gameObject.SetActive(false);
            victoryXP.transform.GetChild(15).gameObject.SetActive(true);
            victoryXP.transform.GetChild(16).gameObject.SetActive(false);
            victoryXP.transform.GetChild(17).gameObject.SetActive(false);
        }
        else if (quotient == 8)
        {
            victoryXP.transform.GetChild(9).gameObject.SetActive(false);
            victoryXP.transform.GetChild(10).gameObject.SetActive(false);
            victoryXP.transform.GetChild(11).gameObject.SetActive(false);
            victoryXP.transform.GetChild(12).gameObject.SetActive(false);
            victoryXP.transform.GetChild(13).gameObject.SetActive(false);
            victoryXP.transform.GetChild(14).gameObject.SetActive(false);
            victoryXP.transform.GetChild(15).gameObject.SetActive(false);
            victoryXP.transform.GetChild(16).gameObject.SetActive(true);
            victoryXP.transform.GetChild(17).gameObject.SetActive(false);
        }
        else if (quotient == 9)
        {
            victoryXP.transform.GetChild(9).gameObject.SetActive(false);
            victoryXP.transform.GetChild(10).gameObject.SetActive(false);
            victoryXP.transform.GetChild(11).gameObject.SetActive(false);
            victoryXP.transform.GetChild(12).gameObject.SetActive(false);
            victoryXP.transform.GetChild(13).gameObject.SetActive(false);
            victoryXP.transform.GetChild(14).gameObject.SetActive(false);
            victoryXP.transform.GetChild(15).gameObject.SetActive(false);
            victoryXP.transform.GetChild(16).gameObject.SetActive(false);
            victoryXP.transform.GetChild(17).gameObject.SetActive(true);
        }
    }
    private void SaveXP()
    {
        PlayerPrefs.SetInt("lvlXP", PlayerPrefs.GetInt("lvlXP") + 1);
        currentFightXP -= 1;
        ShowVictoryXP();
        if (currentFightXP > 0) SaveXP();
    }

    //Function to create the menu
    private void CreateMenu()
    {
        int number;
        if (playerTurn)
        {
            if (selectingAction == 0)
            {
                player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(1).gameObject.SetActive(true);
                player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(1).GetComponent<Image>().color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
                player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(1).transform.GetChild(0).GetComponent<Image>().color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
                player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(1).transform.GetChild(0).GetComponent<Image>().sprite = normalSword;
                player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(1).transform.GetChild(1).GetComponent<Text>().text = "Normal sword";
                player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(1).transform.GetChild(2).GetComponent<Text>().text = "";
                menuCanUse[0] = true;
                number = PlayerPrefs.GetInt("Sword Styles");
                if (number == 1)
                {
                    player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(2).gameObject.SetActive(true);
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
                    player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(2).gameObject.SetActive(true);
                    player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(3).gameObject.SetActive(true);
                    player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(1).GetComponent<Image>().color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
                    player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(1).transform.GetChild(0).GetComponent<Image>().color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
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
                    player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(1).gameObject.SetActive(true);
                    player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(2).gameObject.SetActive(true);
                    player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(3).gameObject.SetActive(true);
                    player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(4).gameObject.SetActive(true);
                    player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(5).gameObject.SetActive(false);
                    player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(6).gameObject.SetActive(false);
                }
                else if (number == 4)
                {
                    player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(1).gameObject.SetActive(true);
                    player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(2).gameObject.SetActive(true);
                    player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(3).gameObject.SetActive(true);
                    player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(4).gameObject.SetActive(true);
                    player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(5).gameObject.SetActive(true);
                    player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(6).gameObject.SetActive(false);
                }
                else if (number == 5)
                {
                    player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(1).gameObject.SetActive(true);
                    player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(2).gameObject.SetActive(true);
                    player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(3).gameObject.SetActive(true);
                    player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(4).gameObject.SetActive(true);
                    player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(5).gameObject.SetActive(true);
                    player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(6).gameObject.SetActive(true);
                }
            }
            else if (selectingAction == 1)
            {
                player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(1).gameObject.SetActive(true);
                player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(1).GetComponent<Image>().color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
                player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(1).transform.GetChild(0).GetComponent<Image>().color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
                player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(1).transform.GetChild(0).GetComponent<Image>().sprite = normalShuriken;
                player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(1).transform.GetChild(1).GetComponent<Text>().text = "Normal shuriken";
                player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(1).transform.GetChild(2).GetComponent<Text>().text = "";
                menuCanUse[0] = true;
                number = PlayerPrefs.GetInt("Shuriken Styles");
                if (number == 1)
                {
                    player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(2).gameObject.SetActive(true);
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
                    else if (PlayerPrefs.GetInt("Fire Shuriken") == 1)
                    {
                        shurikenStyles[0] = 2;
                        player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(2).transform.GetChild(0).GetComponent<Image>().sprite = lightShuriken;
                        player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(2).transform.GetChild(1).GetComponent<Text>().text = "Light shuriken";
                        player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(2).transform.GetChild(2).GetComponent<Text>().text = "3 LP";
                        if (!lightPointsUI.GetComponent<LightPointsScript>().CanUseHability(2) || GetGroundEnemies() == null)
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
                    player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(2).gameObject.SetActive(true);
                    player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(3).gameObject.SetActive(true);
                    player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(1).GetComponent<Image>().color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
                    player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(1).transform.GetChild(0).GetComponent<Image>().color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
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
                    player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(1).gameObject.SetActive(true);
                    player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(2).gameObject.SetActive(true);
                    player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(3).gameObject.SetActive(true);
                    player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(4).gameObject.SetActive(true);
                    player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(5).gameObject.SetActive(false);
                    player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(6).gameObject.SetActive(false);
                }
                else if (number == 4)
                {
                    player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(1).gameObject.SetActive(true);
                    player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(2).gameObject.SetActive(true);
                    player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(3).gameObject.SetActive(true);
                    player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(4).gameObject.SetActive(true);
                    player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(5).gameObject.SetActive(true);
                    player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(6).gameObject.SetActive(false);
                }
                else if (number == 5)
                {
                    player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(1).gameObject.SetActive(true);
                    player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(2).gameObject.SetActive(true);
                    player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(3).gameObject.SetActive(true);
                    player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(4).gameObject.SetActive(true);
                    player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(5).gameObject.SetActive(true);
                    player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(6).gameObject.SetActive(true);
                }
            }
            else if (selectingAction == 2)
            {
                player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(1).GetComponent<Image>().color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
                player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(1).transform.GetChild(0).GetComponent<Image>().color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
                if (scroll > 0) player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(7).GetComponent<Image>().color = new Vector4(player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(7).GetComponent<Image>().color.r, player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(7).GetComponent<Image>().color.g, player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(7).GetComponent<Image>().color.b, 1.0f);
                else player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(7).GetComponent<Image>().color = new Vector4(player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(7).GetComponent<Image>().color.r, player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(7).GetComponent<Image>().color.g, player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(7).GetComponent<Image>().color.b, 0.0f);
                if ((scroll + 6) == itemSize()) player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(8).GetComponent<Image>().color = new Vector4(player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(7).GetComponent<Image>().color.r, player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(7).GetComponent<Image>().color.g, player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(7).GetComponent<Image>().color.b, 0.0f);
                else player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(8).GetComponent<Image>().color = new Vector4(player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(7).GetComponent<Image>().color.r, player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(7).GetComponent<Image>().color.g, player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(7).GetComponent<Image>().color.b, 1.0f);
                if (itemSize() > 5)
                {
                    for (int i = 1; i < 7; i++)
                    {
                        player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(i).GetComponent<Image>().color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
                        player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(i).transform.GetChild(0).GetComponent<Image>().color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
                        menuCanUse[i - 1] = true;
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
                        if (i < itemSize() + 1)
                        {
                            menuCanUse[i - 1] = true;
                            player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(i).GetComponent<Image>().color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
                            player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(i).transform.GetChild(0).GetComponent<Image>().color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
                            if (items[i - 1] == 1)
                            {
                                player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(i).gameObject.SetActive(true);
                                player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(i).transform.GetChild(0).GetComponent<Image>().sprite = apple;
                                player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(i).transform.GetChild(1).GetComponent<Text>().text = "Apple";
                                player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(i).transform.GetChild(2).GetComponent<Text>().text = "";
                            }
                            else if (items[i - 1] == 2)
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
                if (PlayerPrefs.GetInt("Souls") > 0)
                {
                    player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(1).gameObject.SetActive(true);
                    player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(1).transform.GetChild(0).GetComponent<Image>().sprite = music;
                    player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(1).transform.GetChild(1).GetComponent<Text>().text = "Soul music";
                    player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(1).transform.GetChild(2).GetComponent<Text>().text = "1 SP";
                    if (CanUseSoulPoints(1))
                    {
                        player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(1).GetComponent<Image>().color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
                        player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(1).transform.GetChild(0).GetComponent<Image>().color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
                        menuCanUse[0] = true;
                    }
                    else
                    {
                        player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(1).GetComponent<Image>().color = new Vector4(0.55f, 0.55f, 0.55f, 1.0f);
                        player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(1).transform.GetChild(0).GetComponent<Image>().color = new Vector4(0.55f, 0.55f, 0.55f, 1.0f);
                        menuCanUse[0] = false;
                    }
                    if (PlayerPrefs.GetInt("Souls") > 1)
                    {
                        player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(2).gameObject.SetActive(true);
                        player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(2).transform.GetChild(0).GetComponent<Image>().sprite = regeneration;
                        player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(2).transform.GetChild(1).GetComponent<Text>().text = "Regeneration";
                        player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(2).transform.GetChild(2).GetComponent<Text>().text = "2 SP";
                        if (CanUseSoulPoints(2))
                        {
                            player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(2).GetComponent<Image>().color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
                            player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(2).transform.GetChild(0).GetComponent<Image>().color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
                            menuCanUse[1] = true;
                        }
                        else
                        {
                            player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(2).GetComponent<Image>().color = new Vector4(0.55f, 0.55f, 0.55f, 1.0f);
                            player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(2).transform.GetChild(0).GetComponent<Image>().color = new Vector4(0.55f, 0.55f, 0.55f, 1.0f);
                            menuCanUse[1] = false;
                        }
                        if (PlayerPrefs.GetInt("Souls") > 2)
                        {
                            player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(3).gameObject.SetActive(true);
                            player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(3).transform.GetChild(0).GetComponent<Image>().sprite = thunder;
                            player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(3).transform.GetChild(1).GetComponent<Text>().text = "Thunder";
                            player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(3).transform.GetChild(2).GetComponent<Text>().text = "3 SP";
                            if (CanUseSoulPoints(3))
                            {
                                player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(3).GetComponent<Image>().color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
                                player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(3).transform.GetChild(0).GetComponent<Image>().color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
                                menuCanUse[2] = true;
                            }
                            else
                            {
                                player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(3).GetComponent<Image>().color = new Vector4(0.55f, 0.55f, 0.55f, 1.0f);
                                player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(3).transform.GetChild(0).GetComponent<Image>().color = new Vector4(0.55f, 0.55f, 0.55f, 1.0f);
                                menuCanUse[2] = false;
                            }
                            if (PlayerPrefs.GetInt("Souls") > 3)
                            {
                                player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(4).gameObject.SetActive(true);
                                player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(4).transform.GetChild(0).GetComponent<Image>().sprite = lifesteal;
                                player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(4).transform.GetChild(1).GetComponent<Text>().text = "Lifesteal";
                                player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(4).transform.GetChild(2).GetComponent<Text>().text = "3 SP";
                                if (CanUseSoulPoints(3))
                                {
                                    player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(4).GetComponent<Image>().color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
                                    player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(4).transform.GetChild(0).GetComponent<Image>().color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
                                    menuCanUse[3] = true;
                                }
                                else
                                {
                                    player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(4).GetComponent<Image>().color = new Vector4(0.55f, 0.55f, 0.55f, 1.0f);
                                    player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(4).transform.GetChild(0).GetComponent<Image>().color = new Vector4(0.55f, 0.55f, 0.55f, 1.0f);
                                    menuCanUse[3] = false;
                                }
                                if (PlayerPrefs.GetInt("Souls") > 4)
                                {
                                    player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(5).gameObject.SetActive(true);
                                    player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(5).transform.GetChild(0).GetComponent<Image>().sprite = ghost;
                                    player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(5).transform.GetChild(1).GetComponent<Text>().text = "Ghost";
                                    player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(5).transform.GetChild(2).GetComponent<Text>().text = "3 SP";
                                    if (CanUseSoulPoints(3))
                                    {
                                        player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(5).GetComponent<Image>().color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
                                        player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(5).transform.GetChild(0).GetComponent<Image>().color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
                                        menuCanUse[4] = true;
                                    }
                                    else
                                    {
                                        player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(5).GetComponent<Image>().color = new Vector4(0.55f, 0.55f, 0.55f, 1.0f);
                                        player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(5).transform.GetChild(0).GetComponent<Image>().color = new Vector4(0.55f, 0.55f, 0.55f, 1.0f);
                                        menuCanUse[4] = false;
                                    }
                                    if (PlayerPrefs.GetInt("Souls") > 5)
                                    {
                                        player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(6).gameObject.SetActive(true);
                                        player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(6).transform.GetChild(0).GetComponent<Image>().sprite = lightUp;
                                        player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(6).transform.GetChild(1).GetComponent<Text>().text = "Light up";
                                        player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(6).transform.GetChild(2).GetComponent<Text>().text = "2 SP";
                                        if (CanUseSoulPoints(2))
                                        {
                                            player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(6).GetComponent<Image>().color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
                                            player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(6).transform.GetChild(0).GetComponent<Image>().color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
                                            menuCanUse[5] = true;
                                        }
                                        else
                                        {
                                            player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(6).GetComponent<Image>().color = new Vector4(0.55f, 0.55f, 0.55f, 1.0f);
                                            player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(6).transform.GetChild(0).GetComponent<Image>().color = new Vector4(0.55f, 0.55f, 0.55f, 1.0f);
                                            menuCanUse[5] = false;
                                        }
                                    }
                                    else player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(6).gameObject.SetActive(false);
                                }
                                else
                                {
                                    player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(5).gameObject.SetActive(false);
                                    player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(6).gameObject.SetActive(false);
                                }
                            }
                            else
                            {
                                player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(4).gameObject.SetActive(false);
                                player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(5).gameObject.SetActive(false);
                                player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(6).gameObject.SetActive(false);
                            }
                        }
                        else
                        {
                            player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(3).gameObject.SetActive(false);
                            player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(4).gameObject.SetActive(false);
                            player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(5).gameObject.SetActive(false);
                            player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(6).gameObject.SetActive(false);
                        }
                    }
                    else
                    {
                        player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(2).gameObject.SetActive(false);
                        player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(3).gameObject.SetActive(false);
                        player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(4).gameObject.SetActive(false);
                        player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(5).gameObject.SetActive(false);
                        player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(6).gameObject.SetActive(false);
                    }
                }
            }
            else if (selectingAction == 4)
            {
                player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(1).gameObject.SetActive(true);
                player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(1).transform.GetChild(0).GetComponent<Image>().sprite = partnerChange;
                player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(1).transform.GetChild(1).GetComponent<Text>().text = "Change partner";
                player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(1).transform.GetChild(2).GetComponent<Text>().text = "";
                player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(1).GetComponent<Image>().color = new Vector4(0.55f, 0.55f, 0.55f, 1.0f);
                player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(1).transform.GetChild(0).GetComponent<Image>().color = new Vector4(0.55f, 0.55f, 0.55f, 1.0f);
                menuCanUse[0] = false;
                player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(2).gameObject.SetActive(true);
                player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(2).transform.GetChild(0).GetComponent<Image>().sprite = defend;
                player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(2).transform.GetChild(1).GetComponent<Text>().text = "Defend";
                player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(2).transform.GetChild(2).GetComponent<Text>().text = "";
                player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(2).GetComponent<Image>().color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
                player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(2).transform.GetChild(0).GetComponent<Image>().color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
                menuCanUse[1] = true;
                player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(3).gameObject.SetActive(true);
                player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(3).transform.GetChild(0).GetComponent<Image>().sprite = run;
                player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(3).transform.GetChild(1).GetComponent<Text>().text = "Flee";
                player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(3).transform.GetChild(2).GetComponent<Text>().text = "";
                player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(3).GetComponent<Image>().color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
                player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(3).transform.GetChild(0).GetComponent<Image>().color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
                menuCanUse[2] = true;
                player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(4).gameObject.SetActive(false);
                player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(5).gameObject.SetActive(false);
                player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(6).gameObject.SetActive(false);
            }
        }
        else if (companionTurn)
        {
            if(selectingAction == 0)
            {
                companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(1).gameObject.SetActive(true);
                companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(1).transform.GetChild(0).GetComponent<Image>().sprite = firstSkill;
                companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(1).transform.GetChild(1).GetComponent<Text>().text = "Sword";
                companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(1).transform.GetChild(2).GetComponent<Text>().text = "";
                if(GetGroundEnemies() != null)
                {
                    menuCanUse[0] = true;
                    companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(1).GetComponent<Image>().color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
                    companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(1).transform.GetChild(0).GetComponent<Image>().color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
                }
                else
                {
                    companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(1).GetComponent<Image>().color = new Vector4(0.55f, 0.55f, 0.55f, 1.0f);
                    companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(1).transform.GetChild(0).GetComponent<Image>().color = new Vector4(0.55f, 0.55f, 0.55f, 1.0f);
                    menuCanUse[0] = false;
                }
                companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(2).gameObject.SetActive(true);
                companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(2).GetComponent<Image>().color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
                companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(2).transform.GetChild(0).GetComponent<Image>().color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
                companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(2).transform.GetChild(0).GetComponent<Image>().sprite = secondSkill;
                companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(2).transform.GetChild(1).GetComponent<Text>().text = "Glance";
                companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(2).transform.GetChild(2).GetComponent<Text>().text = "";
                menuCanUse[1] = true;
                number = PlayerPrefs.GetInt("AdventurerLvl");
                if (number > 0)
                {
                    companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(3).gameObject.SetActive(true);
                    companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(3).transform.GetChild(0).GetComponent<Image>().sprite = thirdSkill;
                    companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(3).transform.GetChild(1).GetComponent<Text>().text = "Sword spin";
                    companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(3).transform.GetChild(2).GetComponent<Text>().text = "3 LP";
                    if (!lightPointsUI.GetComponent<LightPointsScript>().CanUseHability(3) || GetGroundEnemies() == null)
                    {
                        companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(3).GetComponent<Image>().color = new Vector4(0.55f, 0.55f, 0.55f, 1.0f);
                        companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(3).transform.GetChild(0).GetComponent<Image>().color = new Vector4(0.55f, 0.55f, 0.55f, 1.0f);
                        menuCanUse[2] = false;
                    }
                    else
                    {
                        companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(3).GetComponent<Image>().color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
                        companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(3).transform.GetChild(0).GetComponent<Image>().color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
                        menuCanUse[2] = true;
                    }
                    companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(4).gameObject.SetActive(false);
                    companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(5).gameObject.SetActive(false);
                    companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(6).gameObject.SetActive(false);
                }
                if(number > 1)
                {
                    companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(4).gameObject.SetActive(true);
                    companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(4).transform.GetChild(0).GetComponent<Image>().sprite = fourthSkill;
                    companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(4).transform.GetChild(1).GetComponent<Text>().text = "Dragon slayer bow";
                    companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(4).transform.GetChild(2).GetComponent<Text>().text = "4 LP";
                    if (!lightPointsUI.GetComponent<LightPointsScript>().CanUseHability(4) || GetGroundEnemies() == null)
                    {
                        companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(4).GetComponent<Image>().color = new Vector4(0.55f, 0.55f, 0.55f, 1.0f);
                        companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(4).transform.GetChild(0).GetComponent<Image>().color = new Vector4(0.55f, 0.55f, 0.55f, 1.0f);
                        menuCanUse[3] = false;
                    }
                    else
                    {
                        companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(4).GetComponent<Image>().color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
                        companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(4).transform.GetChild(0).GetComponent<Image>().color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
                        menuCanUse[3] = true;
                    }
                    companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(5).gameObject.SetActive(false);
                    companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(6).gameObject.SetActive(false);
                }
                if (number > 2)
                {
                    companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(5).gameObject.SetActive(true);
                    companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(5).transform.GetChild(0).GetComponent<Image>().sprite = fifthSkill;
                    companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(5).transform.GetChild(1).GetComponent<Text>().text = "BK-47";
                    companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(5).transform.GetChild(2).GetComponent<Text>().text = "7 LP";
                    if (!lightPointsUI.GetComponent<LightPointsScript>().CanUseHability(7))
                    {
                        companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(5).GetComponent<Image>().color = new Vector4(0.55f, 0.55f, 0.55f, 1.0f);
                        companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(5).transform.GetChild(0).GetComponent<Image>().color = new Vector4(0.55f, 0.55f, 0.55f, 1.0f);
                        menuCanUse[4] = false;
                    }
                    else
                    {
                        companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(5).GetComponent<Image>().color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
                        companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(5).transform.GetChild(0).GetComponent<Image>().color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
                        menuCanUse[4] = true;
                    }
                    companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(6).gameObject.SetActive(false);
                }
                if (number == 0)
                {
                    companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(3).gameObject.SetActive(false);
                    companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(4).gameObject.SetActive(false);
                    companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(5).gameObject.SetActive(false);
                    companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(6).gameObject.SetActive(false);
                }
            }
            else if (selectingAction == 1)
            {
                companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(1).GetComponent<Image>().color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
                companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(1).transform.GetChild(0).GetComponent<Image>().color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
                if (scroll > 0) companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(7).GetComponent<Image>().color = new Vector4(companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(7).GetComponent<Image>().color.r, companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(7).GetComponent<Image>().color.g, companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(7).GetComponent<Image>().color.b, 1.0f);
                else companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(7).GetComponent<Image>().color = new Vector4(companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(7).GetComponent<Image>().color.r, companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(7).GetComponent<Image>().color.g, companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(7).GetComponent<Image>().color.b, 0.0f);
                if ((scroll + 6) == itemSize()) companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(8).GetComponent<Image>().color = new Vector4(companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(7).GetComponent<Image>().color.r, companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(7).GetComponent<Image>().color.g, companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(7).GetComponent<Image>().color.b, 0.0f);
                else companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(8).GetComponent<Image>().color = new Vector4(companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(7).GetComponent<Image>().color.r, companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(7).GetComponent<Image>().color.g, companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(7).GetComponent<Image>().color.b, 1.0f);
                if (itemSize() > 5)
                {
                    for (int i = 1; i < 7; i++)
                    {
                        companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(i).GetComponent<Image>().color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
                        companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(i).transform.GetChild(0).GetComponent<Image>().color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
                        menuCanUse[i - 1] = true;
                        if (items[i + scroll - 1] == 1)
                        {
                            companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(i).gameObject.SetActive(true);
                            companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(i).transform.GetChild(0).GetComponent<Image>().sprite = apple;
                            companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(i).transform.GetChild(1).GetComponent<Text>().text = "Apple";
                            companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(i).transform.GetChild(2).GetComponent<Text>().text = "";
                        }
                        else if (items[i + scroll - 1] == 2)
                        {
                            companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(i).gameObject.SetActive(true);
                            companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(i).transform.GetChild(0).GetComponent<Image>().sprite = lightPotion;
                            companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(i).transform.GetChild(1).GetComponent<Text>().text = "Light potion";
                            companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(i).transform.GetChild(2).GetComponent<Text>().text = "";
                        }
                    }
                }
                else
                {
                    for (int i = 1; i < 7; i++)
                    {
                        if (i < itemSize() + 1)
                        {
                            menuCanUse[i - 1] = true;
                            companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(i).GetComponent<Image>().color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
                            companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(i).transform.GetChild(0).GetComponent<Image>().color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
                            if (items[i - 1] == 1)
                            {
                                companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(i).gameObject.SetActive(true);
                                companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(i).transform.GetChild(0).GetComponent<Image>().sprite = apple;
                                companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(i).transform.GetChild(1).GetComponent<Text>().text = "Apple";
                                companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(i).transform.GetChild(2).GetComponent<Text>().text = "";
                            }
                            else if (items[i - 1] == 2)
                            {
                                companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(i).gameObject.SetActive(true);
                                companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(i).transform.GetChild(0).GetComponent<Image>().sprite = lightPotion;
                                companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(i).transform.GetChild(1).GetComponent<Text>().text = "Light potion";
                                companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(i).transform.GetChild(2).GetComponent<Text>().text = "";
                            }
                        }
                        else
                        {
                            companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(i).gameObject.SetActive(false);
                        }
                    }
                }
            }
            else if (selectingAction == 2)
            {
                companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(1).gameObject.SetActive(true);
                companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(1).transform.GetChild(0).GetComponent<Image>().sprite = partnerChange;
                companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(1).transform.GetChild(1).GetComponent<Text>().text = "Change partner";
                companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(1).transform.GetChild(2).GetComponent<Text>().text = "";
                companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(1).GetComponent<Image>().color = new Vector4(0.55f, 0.55f, 0.55f, 1.0f);
                companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(1).transform.GetChild(0).GetComponent<Image>().color = new Vector4(0.55f, 0.55f, 0.55f, 1.0f);
                menuCanUse[0] = false;
                companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(2).gameObject.SetActive(true);
                companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(2).transform.GetChild(0).GetComponent<Image>().sprite = defend;
                companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(2).transform.GetChild(1).GetComponent<Text>().text = "Defend";
                companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(2).transform.GetChild(2).GetComponent<Text>().text = "";
                companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(2).GetComponent<Image>().color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
                companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(2).transform.GetChild(0).GetComponent<Image>().color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
                menuCanUse[1] = true;
                companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(3).gameObject.SetActive(true);
                companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(3).transform.GetChild(0).GetComponent<Image>().sprite = run;
                companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(3).transform.GetChild(1).GetComponent<Text>().text = "Flee";
                companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(3).transform.GetChild(2).GetComponent<Text>().text = "";
                companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(3).GetComponent<Image>().color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
                companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(3).transform.GetChild(0).GetComponent<Image>().color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
                menuCanUse[2] = true;
                companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(4).gameObject.SetActive(false);
                companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(5).gameObject.SetActive(false);
                companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(6).gameObject.SetActive(false);
            }
        }
    }
}
