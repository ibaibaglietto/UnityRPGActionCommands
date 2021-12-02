using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BattleController : MonoBehaviour
{
    //The prefabs of the player, companions and enemies
    [SerializeField] private Transform playerBattle;
    [SerializeField] private Transform adventurerBattle;
    [SerializeField] private Transform companionWizardBattle;
    [SerializeField] private Transform banditBattle;
    [SerializeField] private Transform banditBossBattle;
    [SerializeField] private Transform wizardBattle;
    [SerializeField] private Transform wizardBossBattle;
    [SerializeField] private Transform knightBattle;
    [SerializeField] private Transform knightBossBattle;
    [SerializeField] private Transform kingBattle;
    //The prefabs of the damage UI, heart and light
    [SerializeField] private Transform damageUI;
    //The prefab of the correct command text and the actual transform
    [SerializeField] private Transform correctCommandUIPrefab;
    private Transform correctCommandUI;
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
    [SerializeField] private Sprite resurrectPotion;
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
    [SerializeField] private Sprite upArrowSpritePressed;
    [SerializeField] private Sprite leftArrowSpritePressed;
    [SerializeField] private Sprite rightArrowSpritePressed;
    [SerializeField] private Sprite downArrowSpritePressed;
    //The sprites of the companions
    [SerializeField] private Sprite adventurerIcon;
    [SerializeField] private Sprite wizardIcon;
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
    //The items the player has. 0-> no item, 1-> apple, 2 -> light potion, 3-> resurrect potion
    private int[] items;
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
    //The positions of the red soul
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
    //A bool to know if we are waiting to start the conversation
    private bool waitTalk;
    //A bool to know if we have already seen a tutorial this turn
    private bool tutorialTurn;
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
    //The end battle state
    private bool endBattle;
    //A boolean to know if the player lvl up this fight
    private bool lvlUp;
    //The lvl up gameobject
    private GameObject lvlUpMenu;
    //The end battle image
    private GameObject endBattleImage;
    //The selected atribute to lvl up. 0 -> Heart, 1 -> Light, 2 -> Gem
    private int lvlUpSelected;
    //The number of the enemy that killed the player
    private int killerEnemy;
    //An int to know who is the current companion. 0-> Adventurer, 1-> Wizard
    private int currentCompanion;
    //The randomly generated key to be used with the magic ball action
    private KeyCode magicKey;
    //An array to know the keys the player has to press to perform the barrier action
    private KeyCode[] barrierKeys;
    //An int to know how many keys has the player pressed during the barrier action
    private int barrierNumber;
    //A float to know the time the player started the barrier action
    private float barrierTime;
    //A bool to know if the wizard is taunting the enemies
    private bool taunting;
    //A bool to know if we are changing companion
    private bool changeCompanion;
    //The prefab of the magic pulse
    [SerializeField] private Transform magicPulsePrefab;
    //The the magic pulse
    private Transform magicPulse;
    //The number of the magic spear key
    private int magicSpearKey;
    //The attack objectives
    private Transform[] attackObjectives;
    //A boolean to know if the boss has finished the death animation
    private bool bossDieAnimationEnded;
    //A boolean to know if all the enemies are dead;
    private bool allEnemiesDead;
    //The UI effects source and clips
    private AudioSource UISource;
    [SerializeField] private AudioClip correctCommandAudio;
    [SerializeField] private AudioClip incorrectCommandAudio;
    [SerializeField] private AudioClip healClip;
    [SerializeField] private AudioClip lightClip;
    [SerializeField] private AudioClip recoverClip;
    //The level up text
    private Text lvlUpText;
    //The current data
    private GameObject currentData;
    //A float to know the time, used for the tutorial
    private float tutorialTime;
    

    private void Start()
    {
        currentData = GameObject.Find("CurrentData");
        items = currentData.GetComponent<CurrentDataScript>().items;
        //We put the time scale back to normal
        Time.timeScale = 1.0f;
        //Find the gameobjects and others
        canvas = GameObject.Find("Canvas");
        canvas.GetComponent<WorldCanvasScript>().ShowUI();
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
        lvlUpMenu = GameObject.Find("LvlUp");
        xpText = canvas.transform.GetChild(3).GetChild(1).GetComponent<Text>();
        xpText.text = currentData.GetComponent<CurrentDataScript>().lvlExp.ToString();
        xpObject = GameObject.Find("EXP");
        endBattleImage = GameObject.Find("EndBattleImage");
        UISource = GameObject.Find("UISource").GetComponent<AudioSource>();
        lvlUpText = GameObject.Find("LvlUpText").GetComponent<Text>();
        //Initialize variables
        if (currentData.GetComponent<CurrentDataScript>().souls == 1)
        {
            soul1.GetComponent<Image>().color = new Color(soul1.GetComponent<Image>().color.r, soul1.GetComponent<Image>().color.g, soul1.GetComponent<Image>().color.b, 1.0f);
            soul1.transform.parent.gameObject.GetComponent<Image>().color = new Color(soul1.transform.parent.gameObject.GetComponent<Image>().color.r, soul1.transform.parent.gameObject.GetComponent<Image>().color.g, soul1.transform.parent.gameObject.GetComponent<Image>().color.b, 1.0f);
            soul2.GetComponent<Image>().color = new Color(soul2.GetComponent<Image>().color.r, soul2.GetComponent<Image>().color.g, soul2.GetComponent<Image>().color.b, 0.0f);
            soul2.transform.parent.gameObject.GetComponent<Image>().color = new Color(soul2.transform.parent.gameObject.GetComponent<Image>().color.r, soul2.transform.parent.gameObject.GetComponent<Image>().color.g, soul2.transform.parent.gameObject.GetComponent<Image>().color.b, 0.0f);
            soul3.GetComponent<Image>().color = new Color(soul3.GetComponent<Image>().color.r, soul3.GetComponent<Image>().color.g, soul3.GetComponent<Image>().color.b, 0.0f);
            soul3.transform.parent.gameObject.GetComponent<Image>().color = new Color(soul3.transform.parent.gameObject.GetComponent<Image>().color.r, soul3.transform.parent.gameObject.GetComponent<Image>().color.g, soul3.transform.parent.gameObject.GetComponent<Image>().color.b, 0.0f);
            soul4.GetComponent<Image>().color = new Color(soul4.GetComponent<Image>().color.r, soul4.GetComponent<Image>().color.g, soul4.GetComponent<Image>().color.b, 0.0f);
            soul4.transform.parent.gameObject.GetComponent<Image>().color = new Color(soul4.transform.parent.gameObject.GetComponent<Image>().color.r, soul4.transform.parent.gameObject.GetComponent<Image>().color.g, soul4.transform.parent.gameObject.GetComponent<Image>().color.b, 0.0f);
            soul5.GetComponent<Image>().color = new Color(soul5.GetComponent<Image>().color.r, soul5.GetComponent<Image>().color.g, soul5.GetComponent<Image>().color.b, 0.0f);
            soul5.transform.parent.gameObject.GetComponent<Image>().color = new Color(soul5.transform.parent.gameObject.GetComponent<Image>().color.r, soul5.transform.parent.gameObject.GetComponent<Image>().color.g, soul5.transform.parent.gameObject.GetComponent<Image>().color.b, 0.0f);
            soul6.GetComponent<Image>().color = new Color(soul6.GetComponent<Image>().color.r, soul6.GetComponent<Image>().color.g, soul6.GetComponent<Image>().color.b, 0.0f);
            soul6.transform.parent.gameObject.GetComponent<Image>().color = new Color(soul6.transform.parent.gameObject.GetComponent<Image>().color.r, soul6.transform.parent.gameObject.GetComponent<Image>().color.g, soul6.transform.parent.gameObject.GetComponent<Image>().color.b, 0.0f);
        }
        else if (currentData.GetComponent<CurrentDataScript>().souls == 2)
        {
            soul1.GetComponent<Image>().color = new Color(soul1.GetComponent<Image>().color.r, soul1.GetComponent<Image>().color.g, soul1.GetComponent<Image>().color.b, 1.0f);
            soul1.transform.parent.gameObject.GetComponent<Image>().color = new Color(soul1.transform.parent.gameObject.GetComponent<Image>().color.r, soul1.transform.parent.gameObject.GetComponent<Image>().color.g, soul1.transform.parent.gameObject.GetComponent<Image>().color.b, 1.0f);
            soul2.GetComponent<Image>().color = new Color(soul2.GetComponent<Image>().color.r, soul2.GetComponent<Image>().color.g, soul2.GetComponent<Image>().color.b, 1.0f);
            soul2.transform.parent.gameObject.GetComponent<Image>().color = new Color(soul2.transform.parent.gameObject.GetComponent<Image>().color.r, soul2.transform.parent.gameObject.GetComponent<Image>().color.g, soul2.transform.parent.gameObject.GetComponent<Image>().color.b, 1.0f);
            soul3.GetComponent<Image>().color = new Color(soul3.GetComponent<Image>().color.r, soul3.GetComponent<Image>().color.g, soul3.GetComponent<Image>().color.b, 0.0f);
            soul3.transform.parent.gameObject.GetComponent<Image>().color = new Color(soul3.transform.parent.gameObject.GetComponent<Image>().color.r, soul3.transform.parent.gameObject.GetComponent<Image>().color.g, soul3.transform.parent.gameObject.GetComponent<Image>().color.b, 0.0f);
            soul4.GetComponent<Image>().color = new Color(soul4.GetComponent<Image>().color.r, soul4.GetComponent<Image>().color.g, soul4.GetComponent<Image>().color.b, 0.0f);
            soul4.transform.parent.gameObject.GetComponent<Image>().color = new Color(soul4.transform.parent.gameObject.GetComponent<Image>().color.r, soul4.transform.parent.gameObject.GetComponent<Image>().color.g, soul4.transform.parent.gameObject.GetComponent<Image>().color.b, 0.0f);
            soul5.GetComponent<Image>().color = new Color(soul5.GetComponent<Image>().color.r, soul5.GetComponent<Image>().color.g, soul5.GetComponent<Image>().color.b, 0.0f);
            soul5.transform.parent.gameObject.GetComponent<Image>().color = new Color(soul5.transform.parent.gameObject.GetComponent<Image>().color.r, soul5.transform.parent.gameObject.GetComponent<Image>().color.g, soul5.transform.parent.gameObject.GetComponent<Image>().color.b, 0.0f);
            soul6.GetComponent<Image>().color = new Color(soul6.GetComponent<Image>().color.r, soul6.GetComponent<Image>().color.g, soul6.GetComponent<Image>().color.b, 0.0f);
            soul6.transform.parent.gameObject.GetComponent<Image>().color = new Color(soul6.transform.parent.gameObject.GetComponent<Image>().color.r, soul6.transform.parent.gameObject.GetComponent<Image>().color.g, soul6.transform.parent.gameObject.GetComponent<Image>().color.b, 0.0f);
        }
        else if (currentData.GetComponent<CurrentDataScript>().souls == 3)
        {
            soul1.GetComponent<Image>().color = new Color(soul1.GetComponent<Image>().color.r, soul1.GetComponent<Image>().color.g, soul1.GetComponent<Image>().color.b, 1.0f);
            soul1.transform.parent.gameObject.GetComponent<Image>().color = new Color(soul1.transform.parent.gameObject.GetComponent<Image>().color.r, soul1.transform.parent.gameObject.GetComponent<Image>().color.g, soul1.transform.parent.gameObject.GetComponent<Image>().color.b, 1.0f);
            soul2.GetComponent<Image>().color = new Color(soul2.GetComponent<Image>().color.r, soul2.GetComponent<Image>().color.g, soul2.GetComponent<Image>().color.b, 1.0f);
            soul2.transform.parent.gameObject.GetComponent<Image>().color = new Color(soul2.transform.parent.gameObject.GetComponent<Image>().color.r, soul2.transform.parent.gameObject.GetComponent<Image>().color.g, soul2.transform.parent.gameObject.GetComponent<Image>().color.b, 1.0f);
            soul3.GetComponent<Image>().color = new Color(soul3.GetComponent<Image>().color.r, soul3.GetComponent<Image>().color.g, soul3.GetComponent<Image>().color.b, 1.0f);
            soul3.transform.parent.gameObject.GetComponent<Image>().color = new Color(soul3.transform.parent.gameObject.GetComponent<Image>().color.r, soul3.transform.parent.gameObject.GetComponent<Image>().color.g, soul3.transform.parent.gameObject.GetComponent<Image>().color.b, 1.0f);
            soul4.GetComponent<Image>().color = new Color(soul4.GetComponent<Image>().color.r, soul4.GetComponent<Image>().color.g, soul4.GetComponent<Image>().color.b, 0.0f);
            soul4.transform.parent.gameObject.GetComponent<Image>().color = new Color(soul4.transform.parent.gameObject.GetComponent<Image>().color.r, soul4.transform.parent.gameObject.GetComponent<Image>().color.g, soul4.transform.parent.gameObject.GetComponent<Image>().color.b, 0.0f);
            soul5.GetComponent<Image>().color = new Color(soul5.GetComponent<Image>().color.r, soul5.GetComponent<Image>().color.g, soul5.GetComponent<Image>().color.b, 0.0f);
            soul5.transform.parent.gameObject.GetComponent<Image>().color = new Color(soul5.transform.parent.gameObject.GetComponent<Image>().color.r, soul5.transform.parent.gameObject.GetComponent<Image>().color.g, soul5.transform.parent.gameObject.GetComponent<Image>().color.b, 0.0f);
            soul6.GetComponent<Image>().color = new Color(soul6.GetComponent<Image>().color.r, soul6.GetComponent<Image>().color.g, soul6.GetComponent<Image>().color.b, 0.0f);
            soul6.transform.parent.gameObject.GetComponent<Image>().color = new Color(soul6.transform.parent.gameObject.GetComponent<Image>().color.r, soul6.transform.parent.gameObject.GetComponent<Image>().color.g, soul6.transform.parent.gameObject.GetComponent<Image>().color.b, 0.0f);
        }
        else if (currentData.GetComponent<CurrentDataScript>().souls == 4)
        {
            soul1.GetComponent<Image>().color = new Color(soul1.GetComponent<Image>().color.r, soul1.GetComponent<Image>().color.g, soul1.GetComponent<Image>().color.b, 1.0f);
            soul1.transform.parent.gameObject.GetComponent<Image>().color = new Color(soul1.transform.parent.gameObject.GetComponent<Image>().color.r, soul1.transform.parent.gameObject.GetComponent<Image>().color.g, soul1.transform.parent.gameObject.GetComponent<Image>().color.b, 1.0f);
            soul2.GetComponent<Image>().color = new Color(soul2.GetComponent<Image>().color.r, soul2.GetComponent<Image>().color.g, soul2.GetComponent<Image>().color.b, 1.0f);
            soul2.transform.parent.gameObject.GetComponent<Image>().color = new Color(soul2.transform.parent.gameObject.GetComponent<Image>().color.r, soul2.transform.parent.gameObject.GetComponent<Image>().color.g, soul2.transform.parent.gameObject.GetComponent<Image>().color.b, 1.0f);
            soul3.GetComponent<Image>().color = new Color(soul3.GetComponent<Image>().color.r, soul3.GetComponent<Image>().color.g, soul3.GetComponent<Image>().color.b, 1.0f);
            soul3.transform.parent.gameObject.GetComponent<Image>().color = new Color(soul3.transform.parent.gameObject.GetComponent<Image>().color.r, soul3.transform.parent.gameObject.GetComponent<Image>().color.g, soul3.transform.parent.gameObject.GetComponent<Image>().color.b, 1.0f);
            soul4.GetComponent<Image>().color = new Color(soul4.GetComponent<Image>().color.r, soul4.GetComponent<Image>().color.g, soul4.GetComponent<Image>().color.b, 1.0f);
            soul4.transform.parent.gameObject.GetComponent<Image>().color = new Color(soul4.transform.parent.gameObject.GetComponent<Image>().color.r, soul4.transform.parent.gameObject.GetComponent<Image>().color.g, soul4.transform.parent.gameObject.GetComponent<Image>().color.b, 1.0f);
            soul5.GetComponent<Image>().color = new Color(soul5.GetComponent<Image>().color.r, soul5.GetComponent<Image>().color.g, soul5.GetComponent<Image>().color.b, 0.0f);
            soul5.transform.parent.gameObject.GetComponent<Image>().color = new Color(soul5.transform.parent.gameObject.GetComponent<Image>().color.r, soul5.transform.parent.gameObject.GetComponent<Image>().color.g, soul5.transform.parent.gameObject.GetComponent<Image>().color.b, 0.0f);
            soul6.GetComponent<Image>().color = new Color(soul6.GetComponent<Image>().color.r, soul6.GetComponent<Image>().color.g, soul6.GetComponent<Image>().color.b, 0.0f);
            soul6.transform.parent.gameObject.GetComponent<Image>().color = new Color(soul6.transform.parent.gameObject.GetComponent<Image>().color.r, soul6.transform.parent.gameObject.GetComponent<Image>().color.g, soul6.transform.parent.gameObject.GetComponent<Image>().color.b, 0.0f);
        }
        else if (currentData.GetComponent<CurrentDataScript>().souls == 5)
        {
            soul1.GetComponent<Image>().color = new Color(soul1.GetComponent<Image>().color.r, soul1.GetComponent<Image>().color.g, soul1.GetComponent<Image>().color.b, 1.0f);
            soul1.transform.parent.gameObject.GetComponent<Image>().color = new Color(soul1.transform.parent.gameObject.GetComponent<Image>().color.r, soul1.transform.parent.gameObject.GetComponent<Image>().color.g, soul1.transform.parent.gameObject.GetComponent<Image>().color.b, 1.0f);
            soul2.GetComponent<Image>().color = new Color(soul2.GetComponent<Image>().color.r, soul2.GetComponent<Image>().color.g, soul2.GetComponent<Image>().color.b, 1.0f);
            soul2.transform.parent.gameObject.GetComponent<Image>().color = new Color(soul2.transform.parent.gameObject.GetComponent<Image>().color.r, soul2.transform.parent.gameObject.GetComponent<Image>().color.g, soul2.transform.parent.gameObject.GetComponent<Image>().color.b, 1.0f);
            soul3.GetComponent<Image>().color = new Color(soul3.GetComponent<Image>().color.r, soul3.GetComponent<Image>().color.g, soul3.GetComponent<Image>().color.b, 1.0f);
            soul3.transform.parent.gameObject.GetComponent<Image>().color = new Color(soul3.transform.parent.gameObject.GetComponent<Image>().color.r, soul3.transform.parent.gameObject.GetComponent<Image>().color.g, soul3.transform.parent.gameObject.GetComponent<Image>().color.b, 1.0f);
            soul4.GetComponent<Image>().color = new Color(soul4.GetComponent<Image>().color.r, soul4.GetComponent<Image>().color.g, soul4.GetComponent<Image>().color.b, 1.0f);
            soul4.transform.parent.gameObject.GetComponent<Image>().color = new Color(soul4.transform.parent.gameObject.GetComponent<Image>().color.r, soul4.transform.parent.gameObject.GetComponent<Image>().color.g, soul4.transform.parent.gameObject.GetComponent<Image>().color.b, 1.0f);
            soul5.GetComponent<Image>().color = new Color(soul5.GetComponent<Image>().color.r, soul5.GetComponent<Image>().color.g, soul5.GetComponent<Image>().color.b, 1.0f);
            soul5.transform.parent.gameObject.GetComponent<Image>().color = new Color(soul5.transform.parent.gameObject.GetComponent<Image>().color.r, soul5.transform.parent.gameObject.GetComponent<Image>().color.g, soul5.transform.parent.gameObject.GetComponent<Image>().color.b, 1.0f);
            soul6.GetComponent<Image>().color = new Color(soul6.GetComponent<Image>().color.r, soul6.GetComponent<Image>().color.g, soul6.GetComponent<Image>().color.b, 0.0f);
            soul6.transform.parent.gameObject.GetComponent<Image>().color = new Color(soul6.transform.parent.gameObject.GetComponent<Image>().color.r, soul6.transform.parent.gameObject.GetComponent<Image>().color.g, soul6.transform.parent.gameObject.GetComponent<Image>().color.b, 0.0f);
        }
        else if (currentData.GetComponent<CurrentDataScript>().souls == 6)
        {
            soul1.GetComponent<Image>().color = new Color(soul1.GetComponent<Image>().color.r, soul1.GetComponent<Image>().color.g, soul1.GetComponent<Image>().color.b, 1.0f);
            soul1.transform.parent.gameObject.GetComponent<Image>().color = new Color(soul1.transform.parent.gameObject.GetComponent<Image>().color.r, soul1.transform.parent.gameObject.GetComponent<Image>().color.g, soul1.transform.parent.gameObject.GetComponent<Image>().color.b, 1.0f);
            soul2.GetComponent<Image>().color = new Color(soul2.GetComponent<Image>().color.r, soul2.GetComponent<Image>().color.g, soul2.GetComponent<Image>().color.b, 1.0f);
            soul2.transform.parent.gameObject.GetComponent<Image>().color = new Color(soul2.transform.parent.gameObject.GetComponent<Image>().color.r, soul2.transform.parent.gameObject.GetComponent<Image>().color.g, soul2.transform.parent.gameObject.GetComponent<Image>().color.b, 1.0f);
            soul3.GetComponent<Image>().color = new Color(soul3.GetComponent<Image>().color.r, soul3.GetComponent<Image>().color.g, soul3.GetComponent<Image>().color.b, 1.0f);
            soul3.transform.parent.gameObject.GetComponent<Image>().color = new Color(soul3.transform.parent.gameObject.GetComponent<Image>().color.r, soul3.transform.parent.gameObject.GetComponent<Image>().color.g, soul3.transform.parent.gameObject.GetComponent<Image>().color.b, 1.0f);
            soul4.GetComponent<Image>().color = new Color(soul4.GetComponent<Image>().color.r, soul4.GetComponent<Image>().color.g, soul4.GetComponent<Image>().color.b, 1.0f);
            soul4.transform.parent.gameObject.GetComponent<Image>().color = new Color(soul4.transform.parent.gameObject.GetComponent<Image>().color.r, soul4.transform.parent.gameObject.GetComponent<Image>().color.g, soul4.transform.parent.gameObject.GetComponent<Image>().color.b, 1.0f);
            soul5.GetComponent<Image>().color = new Color(soul5.GetComponent<Image>().color.r, soul5.GetComponent<Image>().color.g, soul5.GetComponent<Image>().color.b, 1.0f);
            soul5.transform.parent.gameObject.GetComponent<Image>().color = new Color(soul5.transform.parent.gameObject.GetComponent<Image>().color.r, soul5.transform.parent.gameObject.GetComponent<Image>().color.g, soul5.transform.parent.gameObject.GetComponent<Image>().color.b, 1.0f);
            soul6.GetComponent<Image>().color = new Color(soul6.GetComponent<Image>().color.r, soul6.GetComponent<Image>().color.g, soul6.GetComponent<Image>().color.b, 1.0f);
            soul6.transform.parent.gameObject.GetComponent<Image>().color = new Color(soul6.transform.parent.gameObject.GetComponent<Image>().color.r, soul6.transform.parent.gameObject.GetComponent<Image>().color.g, soul6.transform.parent.gameObject.GetComponent<Image>().color.b, 1.0f);
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
        bossDieAnimationEnded = true;
        //We set the battle scene as the active scene
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("BattleScene"));
        //Spawn the player
        SpawnCharacter(0,0);
        player.GetChild(0).GetChild(0).GetChild(0).GetComponent<RawImage>().color = new Color(0.4f, 0.4f, 0.4f, player.GetChild(0).GetChild(0).GetChild(0).GetComponent<RawImage>().color.a);
        player.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<RawImage>().color = new Color(0.4f, 0.4f, 0.4f, player.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<RawImage>().color.a);
        player.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<Text>().color = new Color(0.4f, 0.4f, 0.4f, player.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<Text>().color.a); 
        //If we dont have items we deactivate the items option
        if (currentData.GetComponent<CurrentDataScript>().itemSize() == 0)
        {
            player.GetChild(0).GetChild(0).GetChild(2).GetComponent<RawImage>().color = new Color(0.4f, 0.4f, 0.4f, player.GetChild(0).GetChild(0).GetChild(0).GetComponent<RawImage>().color.a);
            player.GetChild(0).GetChild(0).GetChild(2).GetChild(0).GetComponent<RawImage>().color = new Color(0.4f, 0.4f, 0.4f, player.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<RawImage>().color.a);
            player.GetChild(0).GetChild(0).GetChild(2).GetChild(0).GetChild(0).GetComponent<Text>().color = new Color(0.4f, 0.4f, 0.4f, player.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<Text>().color.a);
        }
        //Spawn the companion
        SpawnCharacter(1, currentData.GetComponent<CurrentDataScript>().currentCompanion - 1);  
        //Spawn the enemies
        SpawnCharacter(2, currentData.GetComponent<CurrentDataScript>().enemy1 - 1);
        if (currentData.GetComponent<CurrentDataScript>().enemy2 > 0) SpawnCharacter(3, currentData.GetComponent<CurrentDataScript>().enemy2 - 1);
        if (currentData.GetComponent<CurrentDataScript>().enemy3 > 0) SpawnCharacter(4, currentData.GetComponent<CurrentDataScript>().enemy3 - 1);
        if (currentData.GetComponent<CurrentDataScript>().enemy4 > 0) SpawnCharacter(5, currentData.GetComponent<CurrentDataScript>().enemy4 - 1);
        //Put the game in the correct state
        if (currentData.GetComponent<CurrentDataScript>().enemyStart == 1)
        {
            playerTeamTurn = false;
            playerTurn = false;
            playerTurnCompleted = false;
            companionTurn = false;
            companionTurnCompleted = false;
            enemyTeamTurn = true;
            enemy1Turn = true;
            changePos = false;
            playerChoosingAction = false;
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
            player.GetChild(0).transform.GetChild(0).GetComponent<Animator>().SetBool("Active", false);
            changePosAction.SetActive(false);
        }
        else if(currentData.GetComponent<CurrentDataScript>().playerFirstAttack == 1)
        {
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
            attackType = currentData.GetComponent<CurrentDataScript>().playerAttack;
            usingStyle = currentData.GetComponent<CurrentDataScript>().playerStyle;
            player.GetChild(0).transform.GetChild(0).GetComponent<Animator>().SetBool("Active", false);
            changePosAction.SetActive(false);
        }
        else if (currentData.GetComponent<CurrentDataScript>().companionFirstAttack == 1)
        {
            playerTeamTurn = true;
            playerTurn = false;
            playerTurnCompleted = false;
            companionTurn = true;
            companionTurnCompleted = false;
            enemyTeamTurn = false;
            enemy1Turn = false;
            changePos = false;
            playerChoosingAction = false;
            companionChoosingAction = true;
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
            player.GetChild(0).transform.GetChild(0).GetComponent<Animator>().SetBool("Active", false);
            changePosAction.SetActive(false);
        }
        else
        {
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
        }            
        //Initialize all the variables
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
        waitTalk = false;
        tutorialTurn = false;
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
        aimRotation = 0.0f;
        aimUp = true;
        currentFightXP = 0;
        readyShoot = false;
        lvlUp = false;
        lvlUpSelected = 0;
        victory = false;
        endBattle = false;
        killerEnemy = -1;
        menuCanUse = new bool[6];
        barrierKeys = new KeyCode[5];
        taunting = false;
        changeCompanion = false;
        allEnemiesDead = false;
        //We put the UI on the correct state
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
        lvlUpMenu.SetActive(false);
        //We translate the lvl up text
        lvlUpText.text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_lvlup_title");
        //If we havent unlocked companions we deactivate the change position image
        if(currentData.GetComponent<CurrentDataScript>().unlockedCompanions < 1) changePosAction.SetActive(false);
    }

    private void Update()
    {
        //Press escape to return to the main menu
        //if(Input.GetKeyDown(KeyCode.Escape)) SceneManager.LoadScene(0);
        //When its player teams turn
        if (playerTeamTurn)
        {
            //When its players turn
            if (playerTurn)
            {                
                //The fase when the player chooses what action to do
                if (playerChoosingAction)
                {
                    if (!tutorialTurn && currentData.GetComponent<CurrentDataScript>().tutorialState < 6)
                    {
                        if (!talking)
                        {
                            talking = true;
                            player.GetChild(0).transform.GetChild(0).GetComponent<Animator>().SetBool("Active", false);
                            GetComponent<DialogueManager>().SetTutorial(true);
                            tutorialTime = Time.fixedTime;
                            waitTalk = true;
                        }
                        if (Time.fixedTime - tutorialTime > 1.5f && waitTalk)
                        {
                            if (currentData.GetComponent<CurrentDataScript>().tutorialState == 0)
                            {
                                GetComponent<DialogueManager>().StartBattleDialogue(new Dialogue(new Transform[] { enemy1.transform }, new string[] { "npc_prisonerAdventurer_1" }), false);
                                player.GetChild(0).GetChild(0).GetChild(1).GetComponent<RawImage>().color = new Color(0.4f, 0.4f, 0.4f, player.GetChild(0).GetChild(0).GetChild(0).GetComponent<RawImage>().color.a);
                                player.GetChild(0).GetChild(0).GetChild(1).GetChild(0).GetComponent<RawImage>().color = new Color(0.4f, 0.4f, 0.4f, player.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<RawImage>().color.a);
                                player.GetChild(0).GetChild(0).GetChild(1).GetChild(0).GetChild(0).GetComponent<Text>().color = new Color(0.4f, 0.4f, 0.4f, player.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<Text>().color.a);
                                player.GetChild(0).GetChild(0).GetChild(2).GetComponent<RawImage>().color = new Color(0.4f, 0.4f, 0.4f, player.GetChild(0).GetChild(0).GetChild(0).GetComponent<RawImage>().color.a);
                                player.GetChild(0).GetChild(0).GetChild(2).GetChild(0).GetComponent<RawImage>().color = new Color(0.4f, 0.4f, 0.4f, player.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<RawImage>().color.a);
                                player.GetChild(0).GetChild(0).GetChild(2).GetChild(0).GetChild(0).GetComponent<Text>().color = new Color(0.4f, 0.4f, 0.4f, player.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<Text>().color.a);
                                player.GetChild(0).GetChild(0).GetChild(3).GetComponent<RawImage>().color = new Color(0.4f, 0.4f, 0.4f, player.GetChild(0).GetChild(0).GetChild(0).GetComponent<RawImage>().color.a);
                                player.GetChild(0).GetChild(0).GetChild(3).GetChild(0).GetComponent<RawImage>().color = new Color(0.4f, 0.4f, 0.4f, player.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<RawImage>().color.a);
                                player.GetChild(0).GetChild(0).GetChild(3).GetChild(0).GetChild(0).GetComponent<Text>().color = new Color(0.4f, 0.4f, 0.4f, player.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<Text>().color.a);
                                player.GetChild(0).GetChild(0).GetChild(4).GetComponent<RawImage>().color = new Color(0.4f, 0.4f, 0.4f, player.GetChild(0).GetChild(0).GetChild(0).GetComponent<RawImage>().color.a);
                                player.GetChild(0).GetChild(0).GetChild(4).GetChild(0).GetComponent<RawImage>().color = new Color(0.4f, 0.4f, 0.4f, player.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<RawImage>().color.a);
                                player.GetChild(0).GetChild(0).GetChild(4).GetChild(0).GetChild(0).GetComponent<Text>().color = new Color(0.4f, 0.4f, 0.4f, player.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<Text>().color.a);
                            }
                            else if (currentData.GetComponent<CurrentDataScript>().tutorialState == 1)
                            {
                                GetComponent<DialogueManager>().StartBattleDialogue(new Dialogue(new Transform[] { player.transform }, new string[] { "npc_prisonerAdventurer_1" }), false);
                                player.GetChild(0).GetChild(0).GetChild(0).GetComponent<RawImage>().color = new Color(0.4f, 0.4f, 0.4f, player.GetChild(0).GetChild(0).GetChild(0).GetComponent<RawImage>().color.a);
                                player.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<RawImage>().color = new Color(0.4f, 0.4f, 0.4f, player.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<RawImage>().color.a);
                                player.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<Text>().color = new Color(0.4f, 0.4f, 0.4f, player.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<Text>().color.a);
                                player.GetChild(0).GetChild(0).GetChild(1).GetComponent<RawImage>().color = new Color(1.0f, 1.0f, 1.0f, player.GetChild(0).GetChild(0).GetChild(0).GetComponent<RawImage>().color.a);
                                player.GetChild(0).GetChild(0).GetChild(1).GetChild(0).GetComponent<RawImage>().color = new Color(1.0f, 1.0f, 1.0f, player.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<RawImage>().color.a);
                                player.GetChild(0).GetChild(0).GetChild(1).GetChild(0).GetChild(0).GetComponent<Text>().color = new Color(1.0f, 1.0f, 1.0f, player.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<Text>().color.a);
                                player.GetChild(0).GetChild(0).GetChild(2).GetComponent<RawImage>().color = new Color(0.4f, 0.4f, 0.4f, player.GetChild(0).GetChild(0).GetChild(0).GetComponent<RawImage>().color.a);
                                player.GetChild(0).GetChild(0).GetChild(2).GetChild(0).GetComponent<RawImage>().color = new Color(0.4f, 0.4f, 0.4f, player.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<RawImage>().color.a);
                                player.GetChild(0).GetChild(0).GetChild(2).GetChild(0).GetChild(0).GetComponent<Text>().color = new Color(0.4f, 0.4f, 0.4f, player.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<Text>().color.a);
                                player.GetChild(0).GetChild(0).GetChild(3).GetComponent<RawImage>().color = new Color(0.4f, 0.4f, 0.4f, player.GetChild(0).GetChild(0).GetChild(0).GetComponent<RawImage>().color.a);
                                player.GetChild(0).GetChild(0).GetChild(3).GetChild(0).GetComponent<RawImage>().color = new Color(0.4f, 0.4f, 0.4f, player.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<RawImage>().color.a);
                                player.GetChild(0).GetChild(0).GetChild(3).GetChild(0).GetChild(0).GetComponent<Text>().color = new Color(0.4f, 0.4f, 0.4f, player.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<Text>().color.a);
                                player.GetChild(0).GetChild(0).GetChild(4).GetComponent<RawImage>().color = new Color(0.4f, 0.4f, 0.4f, player.GetChild(0).GetChild(0).GetChild(0).GetComponent<RawImage>().color.a);
                                player.GetChild(0).GetChild(0).GetChild(4).GetChild(0).GetComponent<RawImage>().color = new Color(0.4f, 0.4f, 0.4f, player.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<RawImage>().color.a);
                                player.GetChild(0).GetChild(0).GetChild(4).GetChild(0).GetChild(0).GetComponent<Text>().color = new Color(0.4f, 0.4f, 0.4f, player.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<Text>().color.a);
                            }
                            else if (currentData.GetComponent<CurrentDataScript>().tutorialState == 2)
                            {
                                GetComponent<DialogueManager>().StartBattleDialogue(new Dialogue(new Transform[] { player.transform }, new string[] { "npc_prisonerAdventurer_1" }), false);
                                player.GetChild(0).GetChild(0).GetChild(0).GetComponent<RawImage>().color = new Color(0.4f, 0.4f, 0.4f, player.GetChild(0).GetChild(0).GetChild(0).GetComponent<RawImage>().color.a);
                                player.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<RawImage>().color = new Color(0.4f, 0.4f, 0.4f, player.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<RawImage>().color.a);
                                player.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<Text>().color = new Color(0.4f, 0.4f, 0.4f, player.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<Text>().color.a);
                                player.GetChild(0).GetChild(0).GetChild(1).GetComponent<RawImage>().color = new Color(0.4f, 0.4f, 0.4f, player.GetChild(0).GetChild(0).GetChild(0).GetComponent<RawImage>().color.a);
                                player.GetChild(0).GetChild(0).GetChild(1).GetChild(0).GetComponent<RawImage>().color = new Color(0.4f, 0.4f, 0.4f, player.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<RawImage>().color.a);
                                player.GetChild(0).GetChild(0).GetChild(1).GetChild(0).GetChild(0).GetComponent<Text>().color = new Color(0.4f, 0.4f, 0.4f, player.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<Text>().color.a);
                                player.GetChild(0).GetChild(0).GetChild(2).GetComponent<RawImage>().color = new Color(1.0f, 1.0f, 1.0f, player.GetChild(0).GetChild(0).GetChild(0).GetComponent<RawImage>().color.a);
                                player.GetChild(0).GetChild(0).GetChild(2).GetChild(0).GetComponent<RawImage>().color = new Color(1.0f, 1.0f, 1.0f, player.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<RawImage>().color.a);
                                player.GetChild(0).GetChild(0).GetChild(2).GetChild(0).GetChild(0).GetComponent<Text>().color = new Color(1.0f, 1.0f, 1.0f, player.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<Text>().color.a);
                                player.GetChild(0).GetChild(0).GetChild(3).GetComponent<RawImage>().color = new Color(0.4f, 0.4f, 0.4f, player.GetChild(0).GetChild(0).GetChild(0).GetComponent<RawImage>().color.a);
                                player.GetChild(0).GetChild(0).GetChild(3).GetChild(0).GetComponent<RawImage>().color = new Color(0.4f, 0.4f, 0.4f, player.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<RawImage>().color.a);
                                player.GetChild(0).GetChild(0).GetChild(3).GetChild(0).GetChild(0).GetComponent<Text>().color = new Color(0.4f, 0.4f, 0.4f, player.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<Text>().color.a);
                                player.GetChild(0).GetChild(0).GetChild(4).GetComponent<RawImage>().color = new Color(0.4f, 0.4f, 0.4f, player.GetChild(0).GetChild(0).GetChild(0).GetComponent<RawImage>().color.a);
                                player.GetChild(0).GetChild(0).GetChild(4).GetChild(0).GetComponent<RawImage>().color = new Color(0.4f, 0.4f, 0.4f, player.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<RawImage>().color.a);
                                player.GetChild(0).GetChild(0).GetChild(4).GetChild(0).GetChild(0).GetComponent<Text>().color = new Color(0.4f, 0.4f, 0.4f, player.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<Text>().color.a);
                            }
                            else if (currentData.GetComponent<CurrentDataScript>().tutorialState == 5)
                            {
                                currentData.GetComponent<CurrentDataScript>().unlockedCompanions = 1;
                                Destroy(companion.gameObject);
                                SpawnCharacter(-1, 0);
                                GetComponent<DialogueManager>().StartBattleDialogue(new Dialogue(new Transform[] { player.transform }, new string[] { "npc_prisonerAdventurer_1" }), false);
                                player.GetChild(0).GetChild(0).GetChild(0).GetComponent<RawImage>().color = new Color(0.4f, 0.4f, 0.4f, player.GetChild(0).GetChild(0).GetChild(0).GetComponent<RawImage>().color.a);
                                player.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<RawImage>().color = new Color(0.4f, 0.4f, 0.4f, player.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<RawImage>().color.a);
                                player.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<Text>().color = new Color(0.4f, 0.4f, 0.4f, player.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<Text>().color.a);
                                player.GetChild(0).GetChild(0).GetChild(1).GetComponent<RawImage>().color = new Color(0.4f, 0.4f, 0.4f, player.GetChild(0).GetChild(0).GetChild(0).GetComponent<RawImage>().color.a);
                                player.GetChild(0).GetChild(0).GetChild(1).GetChild(0).GetComponent<RawImage>().color = new Color(0.4f, 0.4f, 0.4f, player.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<RawImage>().color.a);
                                player.GetChild(0).GetChild(0).GetChild(1).GetChild(0).GetChild(0).GetComponent<Text>().color = new Color(0.4f, 0.4f, 0.4f, player.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<Text>().color.a);
                                player.GetChild(0).GetChild(0).GetChild(2).GetComponent<RawImage>().color = new Color(0.4f, 0.4f, 0.4f, player.GetChild(0).GetChild(0).GetChild(0).GetComponent<RawImage>().color.a);
                                player.GetChild(0).GetChild(0).GetChild(2).GetChild(0).GetComponent<RawImage>().color = new Color(0.4f, 0.4f, 0.4f, player.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<RawImage>().color.a);
                                player.GetChild(0).GetChild(0).GetChild(2).GetChild(0).GetChild(0).GetComponent<Text>().color = new Color(0.4f, 0.4f, 0.4f, player.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<Text>().color.a);
                                player.GetChild(0).GetChild(0).GetChild(3).GetComponent<RawImage>().color = new Color(1.0f, 1.0f, 1.0f, player.GetChild(0).GetChild(0).GetChild(0).GetComponent<RawImage>().color.a);
                                player.GetChild(0).GetChild(0).GetChild(3).GetChild(0).GetComponent<RawImage>().color = new Color(1.0f, 1.0f, 1.0f, player.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<RawImage>().color.a);
                                player.GetChild(0).GetChild(0).GetChild(3).GetChild(0).GetChild(0).GetComponent<Text>().color = new Color(1.0f, 1.0f, 1.0f, player.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<Text>().color.a);
                                player.GetChild(0).GetChild(0).GetChild(4).GetComponent<RawImage>().color = new Color(0.4f, 0.4f, 0.4f, player.GetChild(0).GetChild(0).GetChild(0).GetComponent<RawImage>().color.a);
                                player.GetChild(0).GetChild(0).GetChild(4).GetChild(0).GetComponent<RawImage>().color = new Color(0.4f, 0.4f, 0.4f, player.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<RawImage>().color.a);
                                player.GetChild(0).GetChild(0).GetChild(4).GetChild(0).GetChild(0).GetComponent<Text>().color = new Color(0.4f, 0.4f, 0.4f, player.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<Text>().color.a);
                            }
                            waitTalk = false;
                        }
                        //When the player is talking we display the next sentece pressing X
                        if (talking && Input.GetKeyDown(KeyCode.X)) GetComponent<DialogueManager>().DisplayNextSentence();
                    }                    
                    else
                    {
                        //if the player attacks first
                        if (currentData.GetComponent<CurrentDataScript>().playerFirstAttack == 1)
                        {
                            playerChoosingAction = false;
                            selectedEnemy = enemy1;
                            player.GetComponent<PlayerTeamScript>().Attack(currentData.GetComponent<CurrentDataScript>().playerAttack, currentData.GetComponent<CurrentDataScript>().playerStyle, selectedEnemy);
                        }
                        //When we are on the action selection menu
                        else if (!player.GetChild(0).transform.GetChild(0).GetComponent<Animator>().GetBool("MenuOpened"))
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
                            if (selectingAction == 0 && Input.GetKeyDown(KeyCode.Space) && GetGroundEnemies() != null && (currentData.GetComponent<CurrentDataScript>().tutorialState > 6 || currentData.GetComponent<CurrentDataScript>().tutorialState == 1))
                            {
                                //if nothing is unlocked we change the UI state and open the first sword attack
                                if (currentData.GetComponent<CurrentDataScript>().swordStyles == 0)
                                {
                                    changePosAction.SetActive(false);
                                    playerChoosingAction = false;
                                    actionInstructions.SetActive(true);
                                    actionInstructions.GetComponent<Image>().color = new Vector4(actionInstructions.GetComponent<Image>().color.r, actionInstructions.GetComponent<Image>().color.g, actionInstructions.GetComponent<Image>().color.b, 0.5f);
                                    actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = new Vector4(actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color.r, actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color.g, actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color.b, 0.5f);
                                    actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_player_sword_normalsword_action");
                                    player.GetChild(0).transform.GetChild(0).GetComponent<Animator>().SetBool("Active", false);
                                    attackType = 0;
                                    selectingEnemy = true;
                                    enemyName.SetActive(true);
                                    SelectFirstEnemy();
                                }
                                //Else we open the sword menu
                                else
                                {
                                    changePosAction.SetActive(false);
                                    CreateMenu();
                                    actionInstructions.SetActive(true);
                                    player.GetChild(0).transform.GetChild(0).GetComponent<Animator>().SetBool("MenuOpened", true);
                                }
                            }
                            else if (selectingAction == 1 && Input.GetKeyDown(KeyCode.Space) && (currentData.GetComponent<CurrentDataScript>().tutorialState > 6 || currentData.GetComponent<CurrentDataScript>().tutorialState == 2))
                            {
                                //if nothing is unlocked we change the UI state and open the first shuriken attack
                                if (currentData.GetComponent<CurrentDataScript>().shurikenStyles == 0)
                                {
                                    changePosAction.SetActive(false);
                                    playerChoosingAction = false;
                                    actionInstructions.SetActive(true);
                                    actionInstructions.GetComponent<Image>().color = new Vector4(actionInstructions.GetComponent<Image>().color.r, actionInstructions.GetComponent<Image>().color.g, actionInstructions.GetComponent<Image>().color.b, 0.5f);
                                    actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = new Vector4(actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color.r, actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color.g, actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color.b, 0.5f);
                                    actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_player_shuriken_normalshuriken_action");
                                    player.GetChild(0).transform.GetChild(0).GetComponent<Animator>().SetBool("Active", false);
                                    attackType = 1;
                                    selectingEnemy = true;
                                    enemyName.SetActive(true);
                                    SelectFirstEnemy();
                                }
                                //Else we open the shuriken menu
                                else
                                {
                                    changePosAction.SetActive(false);
                                    CreateMenu();
                                    actionInstructions.SetActive(true);
                                    player.GetChild(0).transform.GetChild(0).GetComponent<Animator>().SetBool("MenuOpened", true);
                                }
                            }
                            //We open the Objects menu
                            else if (selectingAction == 2 && Input.GetKeyDown(KeyCode.Space) && currentData.GetComponent<CurrentDataScript>().itemSize() > 0 && (currentData.GetComponent<CurrentDataScript>().tutorialState > 6 || currentData.GetComponent<CurrentDataScript>().tutorialState == 3))
                            {
                                changePosAction.SetActive(false);
                                CreateMenu();
                                actionInstructions.SetActive(true);
                                player.GetChild(0).transform.GetChild(0).GetComponent<Animator>().SetBool("MenuOpened", true);
                            }
                            //We open the Special menu
                            else if (selectingAction == 3 && Input.GetKeyDown(KeyCode.Space) && (currentData.GetComponent<CurrentDataScript>().tutorialState > 6 || currentData.GetComponent<CurrentDataScript>().tutorialState == 6))
                            {
                                changePosAction.SetActive(false);
                                CreateMenu();
                                actionInstructions.SetActive(true);
                                player.GetChild(0).transform.GetChild(0).GetComponent<Animator>().SetBool("MenuOpened", true);
                            }
                            //We open the Others menu
                            else if (selectingAction == 4 && Input.GetKeyDown(KeyCode.Space) && currentData.GetComponent<CurrentDataScript>().tutorialState > 6)
                            {
                                changePosAction.SetActive(false);
                                CreateMenu();
                                actionInstructions.SetActive(true);
                                player.GetChild(0).transform.GetChild(0).GetComponent<Animator>().SetBool("MenuOpened", true);
                            }
                            //We change the party order
                            if (!companionTurnCompleted && Input.GetKeyDown(KeyCode.Z) && !companion.GetComponent<PlayerTeamScript>().IsDead()) StartChangePosition(1);
                        }
                        else
                        {
                            //When we open the sword action we can select the attack using up or down and accept using space
                            if (selectingAction == 0)
                            {
                                if (menuSelectionPos == 0) usingStyle = 0;
                                else if (menuSelectionPos == 1) usingStyle = swordStyles[0];
                                else if (menuSelectionPos == 2) usingStyle = swordStyles[1];
                                if (usingStyle == 0) actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_player_sword_normalsword_description");
                                else if (usingStyle == 1) actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_player_sword_lightsword_description");
                                else if (usingStyle == 2) actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_player_sword_multistrikesword_description");
                                if ((menuSelectionPos < currentData.GetComponent<CurrentDataScript>().swordStyles) && Input.GetKeyDown(KeyCode.DownArrow))
                                {
                                    player.GetChild(0).transform.GetChild(0).GetComponent<Animator>().SetTrigger("Down");
                                }
                                else if (menuSelectionPos > 0 && Input.GetKeyDown(KeyCode.UpArrow))
                                {
                                    player.GetChild(0).transform.GetChild(0).GetComponent<Animator>().SetTrigger("Up");
                                }
                                //When we press space we change to the attack state
                                if (Input.GetKeyDown(KeyCode.Space) && menuCanUse[menuSelectionPos])
                                {
                                    player.GetChild(0).transform.GetChild(0).GetComponent<Animator>().SetBool("MenuHide", true);
                                    playerChoosingAction = false;
                                    actionInstructions.GetComponent<Image>().color = new Vector4(actionInstructions.GetComponent<Image>().color.r, actionInstructions.GetComponent<Image>().color.g, actionInstructions.GetComponent<Image>().color.b, 0.5f);
                                    actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = new Vector4(actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color.r, actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color.g, actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color.b, 0.5f);
                                    if (usingStyle == 0) actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_player_sword_normalsword_action");
                                    else if (usingStyle == 1) actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_player_sword_lightsword_action");
                                    else if (usingStyle == 2) actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_player_sword_multistrikesword_action");
                                    attackType = 0;
                                    selectingEnemy = true;
                                    enemyName.SetActive(true);
                                    SelectFirstEnemy();
                                }
                            }
                            //When we open the shuriken action we can select the attack using up or down and accept using space
                            else if (selectingAction == 1)
                            {
                                if (menuSelectionPos == 0) usingStyle = 0;
                                else if (menuSelectionPos == 1) usingStyle = shurikenStyles[0];
                                else if (menuSelectionPos == 2) usingStyle = shurikenStyles[1];
                                if (usingStyle == 0) actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_player_shuriken_normalshuriken_description");
                                else if (usingStyle == 1) actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_player_shuriken_lightshuriken_description");
                                else if (usingStyle == 2) actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_player_shuriken_fireshuriken_description");
                                if ((menuSelectionPos < currentData.GetComponent<CurrentDataScript>().shurikenStyles) && Input.GetKeyDown(KeyCode.DownArrow))
                                {
                                    player.GetChild(0).transform.GetChild(0).GetComponent<Animator>().SetTrigger("Down");
                                }
                                else if (menuSelectionPos > 0 && Input.GetKeyDown(KeyCode.UpArrow))
                                {
                                    player.GetChild(0).transform.GetChild(0).GetComponent<Animator>().SetTrigger("Up");
                                }
                                //When we press space we change to the attack state
                                if (Input.GetKeyDown(KeyCode.Space) && menuCanUse[menuSelectionPos])
                                {
                                    player.GetChild(0).transform.GetChild(0).GetComponent<Animator>().SetBool("MenuHide", true);
                                    playerChoosingAction = false;
                                    actionInstructions.GetComponent<Image>().color = new Vector4(actionInstructions.GetComponent<Image>().color.r, actionInstructions.GetComponent<Image>().color.g, actionInstructions.GetComponent<Image>().color.b, 0.5f);
                                    actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = new Vector4(actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color.r, actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color.g, actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color.b, 0.5f);
                                    if (usingStyle == 0) actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_player_shuriken_normalshuriken_action");
                                    else if (usingStyle == 1) actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_player_shuriken_lightshuriken_action");
                                    else if (usingStyle == 2) actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_player_shuriken_fireshuriken_action");
                                    attackType = 1;
                                    selectingEnemy = true;
                                    enemyName.SetActive(true);
                                    if (usingStyle != 2) SelectFirstEnemy();
                                    else SelectGroundEnemies();
                                }
                            }
                            //When we open the Objects action we can select the object using up or down and accept using space
                            else if (selectingAction == 2)
                            {
                                if (items[menuSelectionPos + scroll] == 1) actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_item_apple_description");
                                else if (items[menuSelectionPos + scroll] == 2) actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_item_lightpotion_description");
                                else if (items[menuSelectionPos + scroll] == 3) actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_item_resurrectionpotion_description");
                                if (((menuSelectionPos + scroll) < (currentData.GetComponent<CurrentDataScript>().itemSize() - 1)) && Input.GetKeyDown(KeyCode.DownArrow))
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
                                //When we press space we change to the object state
                                if (Input.GetKeyDown(KeyCode.Space) && menuCanUse[menuSelectionPos])
                                {
                                    player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(7).GetComponent<Image>().color = new Vector4(player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(7).GetComponent<Image>().color.r, player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(7).GetComponent<Image>().color.g, player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(7).GetComponent<Image>().color.b, 0.0f);
                                    player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(8).GetComponent<Image>().color = new Vector4(player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(7).GetComponent<Image>().color.r, player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(7).GetComponent<Image>().color.g, player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(7).GetComponent<Image>().color.b, 0.0f);
                                    enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_player_name");
                                    enemyName.transform.GetChild(1).gameObject.SetActive(false);
                                    enemyName.transform.GetChild(2).gameObject.SetActive(false);
                                    enemyName.transform.GetChild(3).gameObject.SetActive(false);
                                    enemyName.transform.GetChild(4).gameObject.SetActive(false);
                                    player.GetChild(0).transform.GetChild(5).gameObject.SetActive(true);
                                    player.GetChild(0).transform.GetChild(0).GetComponent<Animator>().SetBool("MenuHide", true);
                                    playerChoosingAction = false;
                                    if (items[menuSelectionPos] == 1) actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_item_apple_action");
                                    else if (items[menuSelectionPos] == 2) actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_item_lightpotion_action");
                                    else if (items[menuSelectionPos] == 3) actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_item_resurrectionpotion_action");
                                    selectingPlayer = true;
                                    canSelect = true;
                                    enemyName.SetActive(true);
                                }
                            }
                            //When we open the Special action we can select the attack using up or down and accept using space
                            else if (selectingAction == 3)
                            {
                                usingStyle = menuSelectionPos;
                                if (menuSelectionPos == 0) actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_player_special_soulmusic_description");
                                else if (menuSelectionPos == 1) actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_player_special_regeneration_description");
                                else if (menuSelectionPos == 2) actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_player_special_lightning_description");
                                else if (menuSelectionPos == 3) actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_player_special_lifesteal_description");
                                else if (menuSelectionPos == 4) actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_player_special_ghost_description");
                                else if (menuSelectionPos == 5) actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_player_special_lightup_description");
                                if ((menuSelectionPos < currentData.GetComponent<CurrentDataScript>().souls - 1) && Input.GetKeyDown(KeyCode.DownArrow))
                                {
                                    player.GetChild(0).transform.GetChild(0).GetComponent<Animator>().SetTrigger("Down");
                                }
                                else if (menuSelectionPos > 0 && Input.GetKeyDown(KeyCode.UpArrow))
                                {
                                    player.GetChild(0).transform.GetChild(0).GetComponent<Animator>().SetTrigger("Up");
                                }
                                //When we press space we change to the attack state or the select player state, depending on the attack
                                if (Input.GetKeyDown(KeyCode.Space) && menuCanUse[menuSelectionPos])
                                {
                                    player.GetChild(0).transform.GetChild(0).GetComponent<Animator>().SetBool("MenuHide", true);
                                    playerChoosingAction = false;
                                    actionInstructions.GetComponent<Image>().color = new Vector4(actionInstructions.GetComponent<Image>().color.r, actionInstructions.GetComponent<Image>().color.g, actionInstructions.GetComponent<Image>().color.b, 0.5f);
                                    actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = new Vector4(actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color.r, actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color.g, actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color.b, 0.5f);
                                    if (menuSelectionPos == 0) actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_player_special_soulmusic_action");
                                    else if (menuSelectionPos == 1) actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_player_special_regeneration_action");
                                    else if (menuSelectionPos == 2) actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_player_special_lightning_action");
                                    else if (menuSelectionPos == 3) actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_player_special_lifesteal_action");
                                    else if (menuSelectionPos == 4) actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_player_special_ghost_action");
                                    else if (menuSelectionPos == 5) actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_player_special_lightup_action");
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
                                        enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_player_name");
                                        enemyName.transform.GetChild(1).gameObject.SetActive(false);
                                        enemyName.transform.GetChild(2).gameObject.SetActive(false);
                                        enemyName.transform.GetChild(3).gameObject.SetActive(false);
                                        enemyName.transform.GetChild(4).gameObject.SetActive(false);
                                        selectingPlayer = true;
                                        if (menuSelectionPos == 1)
                                        {
                                            if (!companion.GetComponent<PlayerTeamScript>().IsDead())
                                            {
                                                companion.GetChild(0).transform.GetChild(1).gameObject.SetActive(true);
                                                enemyName.transform.GetChild(1).gameObject.SetActive(true);
                                                if (currentCompanion == 0) enemyName.transform.GetChild(1).transform.GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_adventurer_name");
                                                else if (currentCompanion == 1) enemyName.transform.GetChild(1).transform.GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_wizard_name");
                                            }
                                            canSelect = false;
                                        }
                                        else canSelect = true;
                                    }
                                }
                            }
                            //When we open the Other action we can select the action using up or down and accept using space
                            else if (selectingAction == 4)
                            {
                                if (!changeCompanion)
                                {
                                    if (menuSelectionPos == 0) actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_other_changepartner_description");
                                    else if (menuSelectionPos == 1) actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_other_defend_description");
                                    else if (menuSelectionPos == 2) actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_other_flee_description");

                                    if ((menuSelectionPos < 2) && Input.GetKeyDown(KeyCode.DownArrow))
                                    {
                                        player.GetChild(0).transform.GetChild(0).GetComponent<Animator>().SetTrigger("Down");
                                    }
                                    else if (menuSelectionPos > 0 && Input.GetKeyDown(KeyCode.UpArrow))
                                    {
                                        player.GetChild(0).transform.GetChild(0).GetComponent<Animator>().SetTrigger("Up");
                                    }
                                    //Depending on the action we open the party menu, end the player turn adding 1 to the defense or start the flee action
                                    if (Input.GetKeyDown(KeyCode.Space) && menuCanUse[menuSelectionPos])
                                    {
                                        if (menuSelectionPos == 0)
                                        {
                                            changeCompanion = true;
                                            player.GetChild(0).transform.GetChild(0).GetComponent<Animator>().SetTrigger("SelectCompanion");
                                            CreateMenu();
                                        }
                                        else if (menuSelectionPos == 1)
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
                                            actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_other_flee_action");
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
                                //When we open the change action menu we select the companion using up or down and accept using space
                                else
                                {
                                    if (menuSelectionPos == 0) actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_other_changepartner_adventurer");
                                    else if (menuSelectionPos == 1) actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_other_changepartner_wizard");
                                    if ((menuSelectionPos < currentData.GetComponent<CurrentDataScript>().unlockedCompanions - 1) && Input.GetKeyDown(KeyCode.DownArrow))
                                    {
                                        player.GetChild(0).transform.GetChild(0).GetComponent<Animator>().SetTrigger("Down");
                                    }
                                    else if (menuSelectionPos > 0 && Input.GetKeyDown(KeyCode.UpArrow))
                                    {
                                        player.GetChild(0).transform.GetChild(0).GetComponent<Animator>().SetTrigger("Up");
                                    }
                                    //We start the changing companion state
                                    if (Input.GetKeyDown(KeyCode.Space) && menuCanUse[menuSelectionPos])
                                    {
                                        if (menuSelectionPos == 0)
                                        {
                                            companion.GetComponent<PlayerTeamScript>().ChangeCompanion(0);
                                        }
                                        else if (menuSelectionPos == 1)
                                        {
                                            companion.GetComponent<PlayerTeamScript>().ChangeCompanion(1);
                                        }
                                        actionInstructions.SetActive(false);
                                        playerChoosingAction = false;
                                        changeCompanion = false;
                                        player.GetChild(0).transform.GetChild(0).GetComponent<Animator>().SetBool("Active", false);
                                        player.GetChild(0).transform.GetChild(0).GetComponent<Animator>().SetBool("MenuHide", false);
                                        player.GetChild(0).transform.GetChild(0).GetComponent<Animator>().SetBool("MenuOpened", false);
                                    }
                                }
                            }
                            //We can press Q to return to the previous menu
                            if (Input.GetKeyDown(KeyCode.Q))
                            {
                                if (!changeCompanion)
                                {
                                    changePosAction.SetActive(!companionTurnCompleted && !companion.GetComponent<PlayerTeamScript>().IsDead());
                                    actionInstructions.SetActive(false);
                                    player.GetChild(0).transform.GetChild(0).GetComponent<Animator>().SetBool("MenuOpened", false);
                                    player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(7).GetComponent<Image>().color = new Vector4(player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(7).GetComponent<Image>().color.r, player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(7).GetComponent<Image>().color.g, player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(7).GetComponent<Image>().color.b, 0.0f);
                                    player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(8).GetComponent<Image>().color = new Vector4(player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(7).GetComponent<Image>().color.r, player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(7).GetComponent<Image>().color.g, player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(7).GetComponent<Image>().color.b, 0.0f);
                                }
                                else
                                {
                                    changeCompanion = false;
                                    CreateMenu();
                                }
                            }
                        }
                    }
                    
                }
                //When we select a frindly action we give it to a party member
                else if (selectingPlayer)
                {
                    //We can press Q to return to the previous menu
                    if (Input.GetKeyDown(KeyCode.Q))
                    {
                        CreateMenu();
                        enemyName.SetActive(false);
                        playerChoosingAction = true;
                        selectingPlayer = false;
                        actionInstructions.GetComponent<Image>().color = new Vector4(actionInstructions.GetComponent<Image>().color.r, actionInstructions.GetComponent<Image>().color.g, actionInstructions.GetComponent<Image>().color.b, 1.0f);
                        actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = new Vector4(actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color.r, actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color.g, actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color.b, 1.0f);
                        player.GetChild(0).transform.GetChild(0).GetComponent<Animator>().SetBool("MenuHide", false);
                        player.GetChild(0).transform.GetChild(5).gameObject.SetActive(false);
                        companion.GetChild(0).transform.GetChild(1).gameObject.SetActive(false);
                    }
                    //If we can select 
                    if (canSelect)
                    {
                        //If the player is the one being selected we can only change the selection to the other active party member
                        if (player.GetChild(0).transform.GetChild(5).gameObject.activeSelf)
                        {
                            //Depending on the position of the player we press left or right to change the selection
                            if (firstPosPlayer)
                            {
                                if (Input.GetKeyDown(KeyCode.LeftArrow) && ((companion.GetComponent<PlayerTeamScript>().IsDead() && items[menuSelectionPos] == 3 && currentData.GetComponent<CurrentDataScript>().unlockedCompanions > 0) || !companion.GetComponent<PlayerTeamScript>().IsDead()))
                                {
                                    player.GetChild(0).transform.GetChild(5).gameObject.SetActive(false);
                                    companion.GetChild(0).transform.GetChild(1).gameObject.SetActive(true);
                                    if (currentCompanion == 0) enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_adventurer_name");
                                    else if (currentCompanion == 1) enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_wizard_name");
                                }
                            }
                            else
                            {
                                if (Input.GetKeyDown(KeyCode.RightArrow) && ((companion.GetComponent<PlayerTeamScript>().IsDead() && items[menuSelectionPos] == 3 && currentData.GetComponent<CurrentDataScript>().unlockedCompanions > 0) || !companion.GetComponent<PlayerTeamScript>().IsDead()))
                                {
                                    player.GetChild(0).transform.GetChild(5).gameObject.SetActive(false);
                                    companion.GetChild(0).transform.GetChild(1).gameObject.SetActive(true);
                                    if (currentCompanion == 0) enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_adventurer_name");
                                    else if (currentCompanion == 1) enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_wizard_name");
                                }
                            }
                            //We accept pressing space starting the friendly action we previously selected
                            if (Input.GetKeyDown(KeyCode.Space))
                            {
                                player.GetChild(0).transform.GetChild(5).gameObject.SetActive(false);
                                player.GetChild(0).transform.GetChild(0).GetComponent<Animator>().SetBool("Active", false);
                                player.GetChild(0).transform.GetChild(0).GetComponent<Animator>().SetBool("MenuHide", false);
                                player.GetChild(0).transform.GetChild(0).GetComponent<Animator>().SetBool("MenuOpened", false);
                                enemyName.SetActive(false);
                                selectingPlayer = false;
                                if (selectingAction == 2)
                                {
                                    if (items[menuSelectionPos + scroll] == 1)
                                    {
                                        UISource.clip = healClip;
                                        UISource.Play();
                                        player.GetComponent<PlayerTeamScript>().Heal(5, false, true, true, false);
                                    }
                                    else if (items[menuSelectionPos + scroll] == 2)
                                    {
                                        UISource.clip = lightClip;
                                        UISource.Play();
                                        player.GetComponent<PlayerTeamScript>().IncreaseLight(5, false, true, false);
                                    }
                                    else if (items[menuSelectionPos + scroll] == 3)
                                    {
                                        UISource.clip = recoverClip;
                                        UISource.Play();
                                        player.GetComponent<PlayerTeamScript>().Recover(true, false);
                                    }
                                    currentData.GetComponent<CurrentDataScript>().DeleteItem(menuSelectionPos + scroll);
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
                        //If the companion is the one being selected we can only change to the player
                        else if (companion.GetChild(0).transform.GetChild(1).gameObject.activeSelf)
                        {
                            if (firstPosPlayer)
                            {
                                if (Input.GetKeyDown(KeyCode.RightArrow))
                                {
                                    player.GetChild(0).transform.GetChild(5).gameObject.SetActive(true);
                                    companion.GetChild(0).transform.GetChild(1).gameObject.SetActive(false);
                                    enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_player_name");
                                }
                            }
                            else
                            {
                                if (Input.GetKeyDown(KeyCode.LeftArrow))
                                {
                                    player.GetChild(0).transform.GetChild(5).gameObject.SetActive(true);
                                    companion.GetChild(0).transform.GetChild(1).gameObject.SetActive(false);
                                    enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_player_name");
                                }
                            }
                            //We accept pressing space starting the friendly action we previously selected
                            if (Input.GetKeyDown(KeyCode.Space))
                            {
                                companion.GetChild(0).transform.GetChild(1).gameObject.SetActive(false);
                                player.GetChild(0).transform.GetChild(0).GetComponent<Animator>().SetBool("Active", false);
                                player.GetChild(0).transform.GetChild(0).GetComponent<Animator>().SetBool("MenuHide", false);
                                player.GetChild(0).transform.GetChild(0).GetComponent<Animator>().SetBool("MenuOpened", false);
                                selectingPlayer = false;
                                enemyName.SetActive(false);
                                if (selectingAction == 2)
                                {
                                    if (items[menuSelectionPos + scroll] == 1)
                                    {
                                        UISource.clip = healClip;
                                        UISource.Play();
                                        companion.GetComponent<PlayerTeamScript>().Heal(5, false, true, true, false);
                                    }
                                    else if (items[menuSelectionPos + scroll] == 2)
                                    {
                                        UISource.clip = lightClip;
                                        UISource.Play();
                                        player.GetComponent<PlayerTeamScript>().IncreaseLight(5, false, true, false);
                                    }
                                    else if (items[menuSelectionPos + scroll] == 3)
                                    {
                                        UISource.clip = recoverClip;
                                        UISource.Play();
                                        companion.GetComponent<PlayerTeamScript>().Recover(true, false);
                                    }
                                    currentData.GetComponent<CurrentDataScript>().DeleteItem(menuSelectionPos + scroll);
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
                    //If we cant select we will start the friendly action pressing space
                    else
                    {
                        if (Input.GetKeyDown(KeyCode.Space))
                        {
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
                        if((selectingAction == 0 && currentData.GetComponent<CurrentDataScript>().swordStyles == 0) || (selectingAction == 1 && currentData.GetComponent<CurrentDataScript>().shurikenStyles == 0))
                        {
                            changePosAction.SetActive(!companionTurnCompleted && !companion.GetComponent<PlayerTeamScript>().IsDead());
                            playerChoosingAction = true;
                            actionInstructions.SetActive(false);
                            player.GetChild(0).transform.GetChild(0).GetComponent<Animator>().SetBool("Active", true);
                            selectingEnemy = false;
                            enemyName.SetActive(false);
                        }
                        else
                        {
                            enemyName.SetActive(false);
                            playerChoosingAction = true;
                            selectingEnemy = false;
                            actionInstructions.GetComponent<Image>().color = new Vector4(actionInstructions.GetComponent<Image>().color.r, actionInstructions.GetComponent<Image>().color.g, actionInstructions.GetComponent<Image>().color.b, 1.0f);
                            actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = new Vector4(actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color.r, actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color.g, actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color.b, 1.0f);
                            player.GetChild(0).transform.GetChild(0).GetComponent<Animator>().SetBool("MenuHide", false);
                        }                        
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
                        //When we use a sword attack we can only select grounded enemies
                        //When we use a shuriken attack we can only select the first flying enemy and the first grounded enemy
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
                                            if (enemy2.GetComponent<EnemyTeamScript>().enemyType == 0) enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_enemy_bandit");
                                            else if (enemy2.GetComponent<EnemyTeamScript>().enemyType == 1) enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_enemy_evilwizard");
                                            else if (enemy2.GetComponent<EnemyTeamScript>().enemyType == 2) enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_enemy_king");
                                            else if (enemy2.GetComponent<EnemyTeamScript>().enemyType == 3) enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_enemy_knight");
                                        }
                                        else if (enemyNumber > 2 && enemy3.GetComponent<EnemyTeamScript>().IsAlive() && ((selectingAction == 0 && enemy3.GetComponent<EnemyTeamScript>().IsGrounded()) || selectingAction == 1))
                                        {
                                            enemy1.GetChild(0).transform.GetChild(0).gameObject.SetActive(false);
                                            enemy3.GetChild(0).transform.GetChild(0).gameObject.SetActive(true);
                                            if (enemy3.GetComponent<EnemyTeamScript>().enemyType == 0) enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_enemy_bandit");
                                            else if (enemy3.GetComponent<EnemyTeamScript>().enemyType == 1) enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_enemy_evilwizard");
                                            else if (enemy3.GetComponent<EnemyTeamScript>().enemyType == 2) enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_enemy_king");
                                            else if (enemy3.GetComponent<EnemyTeamScript>().enemyType == 3) enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_enemy_knight");
                                        }
                                        else if (enemyNumber > 3 && enemy4.GetComponent<EnemyTeamScript>().IsAlive() && ((selectingAction == 0 && enemy4.GetComponent<EnemyTeamScript>().IsGrounded()) || selectingAction == 1))
                                        {
                                            enemy1.GetChild(0).transform.GetChild(0).gameObject.SetActive(false);
                                            enemy4.GetChild(0).transform.GetChild(0).gameObject.SetActive(true);
                                            if (enemy4.GetComponent<EnemyTeamScript>().enemyType == 0) enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_enemy_bandit");
                                            else if (enemy4.GetComponent<EnemyTeamScript>().enemyType == 1) enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_enemy_evilwizard");
                                            else if (enemy4.GetComponent<EnemyTeamScript>().enemyType == 2) enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_enemy_king");
                                            else if (enemy4.GetComponent<EnemyTeamScript>().enemyType == 3) enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_enemy_knight");
                                        }
                                    }
                                    else
                                    {
                                        Transform enemy = SelectNextShuriken(enemy1.GetComponent<EnemyTeamScript>().IsGrounded());
                                        if(enemy!= null)
                                        {
                                            enemy1.GetChild(0).transform.GetChild(0).gameObject.SetActive(false);
                                            enemy.GetChild(0).transform.GetChild(0).gameObject.SetActive(true);
                                            if (enemy.GetComponent<EnemyTeamScript>().enemyType == 0) enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_enemy_bandit");
                                            else if (enemy.GetComponent<EnemyTeamScript>().enemyType == 1) enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_enemy_evilwizard");
                                            else if (enemy.GetComponent<EnemyTeamScript>().enemyType == 2) enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_enemy_king");
                                            else if (enemy.GetComponent<EnemyTeamScript>().enemyType == 3) enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_enemy_knight");
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
                                    if (enemy1.GetComponent<EnemyTeamScript>().enemyType == 0) enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_enemy_bandit");
                                    else if (enemy1.GetComponent<EnemyTeamScript>().enemyType == 1) enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_enemy_evilwizard");
                                    else if (enemy1.GetComponent<EnemyTeamScript>().enemyType == 2) enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_enemy_king");
                                    else if (enemy1.GetComponent<EnemyTeamScript>().enemyType == 3) enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_enemy_knight");
                                }
                                if (Input.GetKeyDown(KeyCode.RightArrow))
                                {
                                    if(selectingAction == 0)
                                    {
                                        if (enemyNumber > 2 && enemy3.GetComponent<EnemyTeamScript>().IsAlive() && ((selectingAction == 0 && enemy3.GetComponent<EnemyTeamScript>().IsGrounded()) || selectingAction == 1))
                                        {
                                            enemy2.GetChild(0).transform.GetChild(0).gameObject.SetActive(false);
                                            enemy3.GetChild(0).transform.GetChild(0).gameObject.SetActive(true);
                                            if (enemy3.GetComponent<EnemyTeamScript>().enemyType == 0) enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_enemy_bandit");
                                            else if (enemy3.GetComponent<EnemyTeamScript>().enemyType == 1) enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_enemy_evilwizard");
                                            else if (enemy3.GetComponent<EnemyTeamScript>().enemyType == 2) enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_enemy_king");
                                            else if (enemy3.GetComponent<EnemyTeamScript>().enemyType == 3) enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_enemy_knight");
                                        }
                                        else if (enemyNumber > 3 && enemy4.GetComponent<EnemyTeamScript>().IsAlive() && ((selectingAction == 0 && enemy4.GetComponent<EnemyTeamScript>().IsGrounded()) || selectingAction == 1))
                                        {
                                            enemy2.GetChild(0).transform.GetChild(0).gameObject.SetActive(false);
                                            enemy4.GetChild(0).transform.GetChild(0).gameObject.SetActive(true);
                                            if (enemy4.GetComponent<EnemyTeamScript>().enemyType == 0) enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_enemy_bandit");
                                            else if (enemy4.GetComponent<EnemyTeamScript>().enemyType == 1) enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_enemy_evilwizard");
                                            else if (enemy4.GetComponent<EnemyTeamScript>().enemyType == 2) enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_enemy_king");
                                            else if (enemy4.GetComponent<EnemyTeamScript>().enemyType == 3) enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_enemy_knight");
                                        }
                                    }
                                    else if(!enemy1.GetComponent<EnemyTeamScript>().IsAlive())
                                    {
                                        Transform enemy = SelectNextShuriken(enemy2.GetComponent<EnemyTeamScript>().IsGrounded());
                                        if(enemy != null)
                                        {
                                            enemy2.GetChild(0).transform.GetChild(0).gameObject.SetActive(false);
                                            enemy.GetChild(0).transform.GetChild(0).gameObject.SetActive(true);
                                            if (enemy.GetComponent<EnemyTeamScript>().enemyType == 0) enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_enemy_bandit");
                                            else if (enemy.GetComponent<EnemyTeamScript>().enemyType == 1) enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_enemy_evilwizard");
                                            else if (enemy.GetComponent<EnemyTeamScript>().enemyType == 2) enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_enemy_king");
                                            else if (enemy.GetComponent<EnemyTeamScript>().enemyType == 3) enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_enemy_knight");
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
                            else if (enemyNumber>2 && enemy3.GetChild(0).transform.GetChild(0).gameObject.activeSelf)
                            {
                                if (Input.GetKeyDown(KeyCode.LeftArrow))
                                {
                                    if(selectingAction == 0)
                                    {
                                        if (enemy2.GetComponent<EnemyTeamScript>().IsAlive() && ((selectingAction == 0 && enemy2.GetComponent<EnemyTeamScript>().IsGrounded()) || selectingAction == 1))
                                        {
                                            enemy2.GetChild(0).transform.GetChild(0).gameObject.SetActive(true);
                                            enemy3.GetChild(0).transform.GetChild(0).gameObject.SetActive(false);
                                            if (enemy2.GetComponent<EnemyTeamScript>().enemyType == 0) enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_enemy_bandit");
                                            else if (enemy2.GetComponent<EnemyTeamScript>().enemyType == 1) enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_enemy_evilwizard");
                                            else if (enemy2.GetComponent<EnemyTeamScript>().enemyType == 2) enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_enemy_king");
                                            else if (enemy2.GetComponent<EnemyTeamScript>().enemyType == 3) enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_enemy_knight");
                                        }
                                        else if (enemy1.GetComponent<EnemyTeamScript>().IsAlive() && ((selectingAction == 0 && enemy1.GetComponent<EnemyTeamScript>().IsGrounded()) || selectingAction == 1))
                                        {
                                            enemy1.GetChild(0).transform.GetChild(0).gameObject.SetActive(true);
                                            enemy3.GetChild(0).transform.GetChild(0).gameObject.SetActive(false);
                                            if (enemy1.GetComponent<EnemyTeamScript>().enemyType == 0) enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_enemy_bandit");
                                            else if (enemy1.GetComponent<EnemyTeamScript>().enemyType == 1) enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_enemy_evilwizard");
                                            else if (enemy1.GetComponent<EnemyTeamScript>().enemyType == 2) enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_enemy_king");
                                            else if (enemy1.GetComponent<EnemyTeamScript>().enemyType == 3) enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_enemy_knight");
                                        }
                                    }
                                    else if(enemy1.GetComponent<EnemyTeamScript>().IsAlive() || enemy2.GetComponent<EnemyTeamScript>().IsAlive())
                                    {
                                        Transform enemy = SelectNextShuriken(enemy3.GetComponent<EnemyTeamScript>().IsGrounded());
                                        if (enemy != null)
                                        {
                                            enemy3.GetChild(0).transform.GetChild(0).gameObject.SetActive(false);
                                            enemy.GetChild(0).transform.GetChild(0).gameObject.SetActive(true);
                                            if (enemy.GetComponent<EnemyTeamScript>().enemyType == 0) enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_enemy_bandit");
                                            else if (enemy.GetComponent<EnemyTeamScript>().enemyType == 1) enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_enemy_evilwizard");
                                            else if (enemy.GetComponent<EnemyTeamScript>().enemyType == 2) enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_enemy_king");
                                            else if (enemy.GetComponent<EnemyTeamScript>().enemyType == 3) enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_enemy_knight");
                                        }
                                    }
                                }
                                if (Input.GetKeyDown(KeyCode.RightArrow))
                                {
                                    if (selectingAction == 0)
                                    {
                                        if (enemyNumber > 3 && enemy4.GetComponent<EnemyTeamScript>().IsAlive() && ((selectingAction == 0 && enemy4.GetComponent<EnemyTeamScript>().IsGrounded()) || selectingAction == 1))
                                        {
                                            enemy3.GetChild(0).transform.GetChild(0).gameObject.SetActive(false);
                                            enemy4.GetChild(0).transform.GetChild(0).gameObject.SetActive(true);
                                            if (enemy4.GetComponent<EnemyTeamScript>().enemyType == 0) enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_enemy_bandit");
                                            else if (enemy4.GetComponent<EnemyTeamScript>().enemyType == 1) enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_enemy_evilwizard");
                                            else if (enemy4.GetComponent<EnemyTeamScript>().enemyType == 2) enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_enemy_king");
                                            else if (enemy4.GetComponent<EnemyTeamScript>().enemyType == 3) enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_enemy_knight");
                                        }
                                    }
                                    else if (!enemy1.GetComponent<EnemyTeamScript>().IsAlive() && !enemy2.GetComponent<EnemyTeamScript>().IsAlive())
                                    {
                                        Transform enemy = SelectNextShuriken(enemy3.GetComponent<EnemyTeamScript>().IsGrounded());
                                        if (enemy != null)
                                        {
                                            enemy3.GetChild(0).transform.GetChild(0).gameObject.SetActive(false);
                                            enemy.GetChild(0).transform.GetChild(0).gameObject.SetActive(true);
                                            if (enemy.GetComponent<EnemyTeamScript>().enemyType == 0) enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_enemy_bandit");
                                            else if (enemy.GetComponent<EnemyTeamScript>().enemyType == 1) enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_enemy_evilwizard");
                                            else if (enemy.GetComponent<EnemyTeamScript>().enemyType == 2) enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_enemy_king");
                                            else if (enemy.GetComponent<EnemyTeamScript>().enemyType == 3) enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_enemy_knight");
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
                            else if (enemyNumber > 3 && enemy4.GetChild(0).transform.GetChild(0).gameObject.activeSelf)
                            {
                                if (Input.GetKeyDown(KeyCode.LeftArrow))
                                {
                                    if(selectingAction == 0)
                                    {
                                        if (enemy3.GetComponent<EnemyTeamScript>().IsAlive() && ((selectingAction == 0 && enemy3.GetComponent<EnemyTeamScript>().IsGrounded()) || selectingAction == 1))
                                        {
                                            enemy3.GetChild(0).transform.GetChild(0).gameObject.SetActive(true);
                                            enemy4.GetChild(0).transform.GetChild(0).gameObject.SetActive(false);
                                            if (enemy3.GetComponent<EnemyTeamScript>().enemyType == 0) enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_enemy_bandit");
                                            else if (enemy3.GetComponent<EnemyTeamScript>().enemyType == 1) enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_enemy_evilwizard");
                                            else if (enemy3.GetComponent<EnemyTeamScript>().enemyType == 2) enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_enemy_king");
                                            else if (enemy3.GetComponent<EnemyTeamScript>().enemyType == 3) enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_enemy_knight");
                                        }
                                        else if (enemy2.GetComponent<EnemyTeamScript>().IsAlive() && ((selectingAction == 0 && enemy2.GetComponent<EnemyTeamScript>().IsGrounded()) || selectingAction == 1))
                                        {
                                            enemy2.GetChild(0).transform.GetChild(0).gameObject.SetActive(true);
                                            enemy4.GetChild(0).transform.GetChild(0).gameObject.SetActive(false);
                                            if (enemy2.GetComponent<EnemyTeamScript>().enemyType == 0) enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_enemy_bandit");
                                            else if (enemy2.GetComponent<EnemyTeamScript>().enemyType == 1) enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_enemy_evilwizard");
                                            else if (enemy2.GetComponent<EnemyTeamScript>().enemyType == 2) enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_enemy_king");
                                            else if (enemy2.GetComponent<EnemyTeamScript>().enemyType == 3) enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_enemy_knight");
                                        }
                                        else if (enemy1.GetComponent<EnemyTeamScript>().IsAlive() && ((selectingAction == 0 && enemy1.GetComponent<EnemyTeamScript>().IsGrounded()) || selectingAction == 1))
                                        {
                                            enemy1.GetChild(0).transform.GetChild(0).gameObject.SetActive(true);
                                            enemy4.GetChild(0).transform.GetChild(0).gameObject.SetActive(false);
                                            if (enemy1.GetComponent<EnemyTeamScript>().enemyType == 0) enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_enemy_bandit");
                                            else if (enemy1.GetComponent<EnemyTeamScript>().enemyType == 1) enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_enemy_evilwizard");
                                            else if (enemy1.GetComponent<EnemyTeamScript>().enemyType == 2) enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_enemy_king");
                                            else if (enemy1.GetComponent<EnemyTeamScript>().enemyType == 3) enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_enemy_knight");
                                        }
                                    }
                                    else
                                    {
                                        Transform enemy = SelectNextShuriken(enemy4.GetComponent<EnemyTeamScript>().IsGrounded());
                                        if (enemy != null)
                                        {
                                            enemy4.GetChild(0).transform.GetChild(0).gameObject.SetActive(false);
                                            enemy.GetChild(0).transform.GetChild(0).gameObject.SetActive(true);
                                            if (enemy.GetComponent<EnemyTeamScript>().enemyType == 0) enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_enemy_bandit");
                                            else if (enemy.GetComponent<EnemyTeamScript>().enemyType == 1) enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_enemy_evilwizard");
                                            else if (enemy.GetComponent<EnemyTeamScript>().enemyType == 2) enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_enemy_king");
                                            else if (enemy.GetComponent<EnemyTeamScript>().enemyType == 3) enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_enemy_knight");
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
                            actionInstructions.GetComponent<Image>().color = new Vector4(actionInstructions.GetComponent<Image>().color.r, actionInstructions.GetComponent<Image>().color.g, actionInstructions.GetComponent<Image>().color.b, 1.0f);
                            actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = new Vector4(actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color.r, actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color.g, actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color.b, 1.0f);
                            player.GetComponent<PlayerTeamScript>().Attack(attackType, usingStyle, selectedEnemy);
                        }
                    }
                    //If we cant select we start the attack pressing space
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
                        //Normal sword attack
                        if (usingStyle == 0)
                        {
                            //We check if the player presses the button when it is asked to be pressed
                            if (!attackAction && Input.GetKeyDown(KeyCode.X)) badAttack = true;
                            if (attackAction)
                            {
                                selectedEnemy.GetChild(0).transform.GetChild(1).gameObject.GetComponent<Animator>().SetBool("Pressed", true);
                                if (Input.GetKeyDown(KeyCode.X) && !badAttack)
                                {
                                    if (currentData.GetComponent<CurrentDataScript>().tutorialState == 1)
                                    {
                                        Time.timeScale = 1.0f;
                                        GetComponent<DialogueManager>().DisplayNextSentence();
                                    }
                                    goodAttack = true;
                                }
                            }
                            else
                            {
                                selectedEnemy.GetChild(0).transform.GetChild(1).gameObject.GetComponent<Animator>().SetBool("Pressed", false);
                            }
                            player.GetComponent<Animator>().SetBool("isAttacking", true);
                        }
                        //Light sword
                        else if (usingStyle == 1)
                        {
                            //We check that the player releases the x button when they have to do it
                            if (Input.GetKey(KeyCode.X) && !player.transform.GetChild(0).transform.GetChild(2).GetComponent<Animator>().GetBool("charging"))
                            {
                                DeactivateActionInstructions();
                                player.GetComponent<Animator>().SetTrigger("chargeLightMelee");
                                player.transform.GetChild(0).transform.GetChild(2).GetComponent<Animator>().SetBool("charging", true);
                            }
                            if (Input.GetKeyUp(KeyCode.X) && attackAction)
                            {
                                GoodCommand(true,1);
                                player.GetComponent<Animator>().SetTrigger("goodChargeMelee");
                                player.transform.GetChild(0).transform.GetChild(2).GetComponent<Animator>().SetBool("charging", false);
                                player.transform.GetChild(0).transform.GetChild(2).GetComponent<Animator>().SetBool("active", false);
                                attackAction = false;
                                finalAttack = false;
                            }
                            else if (Input.GetKeyUp(KeyCode.X) && !attackAction && !attackFinished)
                            {
                                BadCommand();
                                player.GetComponent<Animator>().SetTrigger("badChargeMelee");
                                player.transform.GetChild(0).transform.GetChild(2).GetComponent<Animator>().SetBool("charging", false);
                                player.transform.GetChild(0).transform.GetChild(2).GetComponent<Animator>().SetBool("active", false);
                                finalAttack = false;
                            }
                            else if (attackFinished)
                            {
                                BadCommand();
                                player.GetComponent<Animator>().SetTrigger("badChargeMelee");
                                player.transform.GetChild(0).transform.GetChild(2).GetComponent<Animator>().SetBool("charging", false);
                                player.transform.GetChild(0).transform.GetChild(2).GetComponent<Animator>().SetBool("active", false);
                                finalAttack = false;
                            }
                        }
                        //Multistrike sword
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
                        //Normal shuriken attack
                        if (usingStyle == 0)
                        {
                            //We check if the button is pressed correctly and we wait the shuriken to hit
                            if (Input.GetKeyDown(KeyCode.X))
                            {
                                player.GetChild(0).transform.GetChild(1).GetComponent<Animator>().SetBool("Active", false);
                                if (attackAction)
                                {
                                    if (currentData.GetComponent<CurrentDataScript>().tutorialState == 2)
                                    {
                                        Time.timeScale = 1.0f;
                                        GetComponent<DialogueManager>().DisplayNextSentence();
                                    }
                                    GoodCommand(true,1);
                                    player.GetComponent<PlayerTeamScript>().SetShurikenDamage(2);
                                }
                                else
                                {
                                    BadCommand();
                                    player.GetComponent<PlayerTeamScript>().SetShurikenDamage(1);
                                }
                                player.GetComponent<Animator>().SetBool("isSpinning", false);
                                finalAttack = false;
                            }
                        }
                        //Light shuriken
                        else if (usingStyle == 1)
                        {
                            //We check that the fill amount is 1 at the end of the action
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
                        //Fire shuriken
                        else if (usingStyle == 2)
                        {
                            //We check that the fill amount is 1 at the end of the action
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
                    //Soul music attack
                    else if (soulMusic > 0 && !failMusic)
                    {
                        //We put the white soul at the starting position
                        player.GetChild(0).transform.GetChild(7).transform.GetChild(2).GetComponent<RectTransform>().anchoredPosition = new Vector3(player.GetChild(0).transform.GetChild(7).transform.GetChild(1).GetComponent<Image>().fillAmount * 10.9f - 5.45f, player.GetChild(0).transform.GetChild(7).transform.GetChild(2).GetComponent<RectTransform>().anchoredPosition.y, 0.0f);
                        //When the bar is filling we check the position of the keys and that the player is pressing the buttons correctly
                        //Each time the player fills the bar correctly 1 key will be added until there are 7 keys in total. The speed will increase too.
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
                                            if(soulMusic == 4) GoodCommand(true,4);
                                            else GoodCommand(true, 5);
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
                                        GoodCommand(true,3);
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
                                    GoodCommand(true,2);
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
                                GoodCommand(true,1);
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
                        //When the soul returns the starting position we add 1 to the difficulty level and start again
                        else if (player.GetChild(0).transform.GetChild(7).transform.GetChild(1).GetComponent<Image>().fillAmount == 0.0f)
                        {
                            soulMusic += 1;
                            StartSoulMusicAttack(soulMusic);
                            soulMusicFilling = true;
                        }
                    }
                    //When the player fails the action command we check the level they died on and en the attack
                    else if (failMusic)
                    {
                        BadCommand();
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
                    //We initialize the soul regeneration attack
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
                    //We initialize the soul lightning attack
                    else if (soulLightning)
                    {
                        if (Input.GetKeyDown(KeyCode.X)) Instantiate(lightningPrefab, new Vector3(yellowSoul.position.x, 1.5f, enemy1.position.z), Quaternion.identity);
                    }
                    //We initialize the soul lifesteal attack
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
                    //We initialize the soul disappear attack
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
                    //We initialize the soul Light up attack
                    else if (soulLightUp)
                    {
                        //We wait until the fog has scaled to the starting scale
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
                //We check if the player presses the x button while they are trying to flee, if so we add 0.02 to the fill amount
                else if (fleeing && (Time.fixedTime - fleeTime) < 10.0f)
                {
                    if (Input.GetKeyDown(KeyCode.X))
                    {
                        if (fleeAction.transform.GetChild(1).GetComponent<Image>().fillAmount != 1.0f) fleeAction.transform.GetChild(1).GetComponent<Image>().fillAmount += 0.02f;
                    }
                }
            }
            //Companion turn
            else if (companionTurn)
            {
                //Choosing action
                if (companionChoosingAction)
                {
                    if (currentData.GetComponent<CurrentDataScript>().tutorialState == 6)
                    {

                    }
                    else
                    {
                        //if the player attacks first
                        if (currentData.GetComponent<CurrentDataScript>().companionFirstAttack == 1)
                        {
                            companionChoosingAction = false;
                            selectedEnemy = enemy1;
                            companion.GetComponent<PlayerTeamScript>().Attack(currentData.GetComponent<CurrentDataScript>().companionAttack, currentData.GetComponent<CurrentDataScript>().companionStyle, selectedEnemy);
                        }
                        //When the companion is choosing the main action
                        else if (!companion.GetChild(0).transform.GetChild(0).GetComponent<Animator>().GetBool("MenuOpened"))
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
                            //Attack
                            if (selectingAction == 0 && Input.GetKeyDown(KeyCode.Space))
                            {
                                changePosAction.SetActive(false);
                                CreateMenu();
                                actionInstructions.SetActive(true);
                                companion.GetChild(0).transform.GetChild(0).GetComponent<Animator>().SetBool("MenuOpened", true);
                            }
                            //Item
                            else if (selectingAction == 1 && Input.GetKeyDown(KeyCode.Space))
                            {
                                changePosAction.SetActive(false);
                                CreateMenu();
                                actionInstructions.SetActive(true);
                                companion.GetChild(0).transform.GetChild(0).GetComponent<Animator>().SetBool("MenuOpened", true);
                            }
                            //Others
                            else if (selectingAction == 2 && Input.GetKeyDown(KeyCode.Space))
                            {
                                changePosAction.SetActive(false);
                                CreateMenu();
                                actionInstructions.SetActive(true);
                                companion.GetChild(0).transform.GetChild(0).GetComponent<Animator>().SetBool("MenuOpened", true);
                            }
                            //We swap team position pressing Z
                            if (!playerTurnCompleted && Input.GetKeyDown(KeyCode.Z)) StartChangePosition(2);
                        }
                        //When the action is already choosen
                        else
                        {
                            //Attack
                            if (selectingAction == 0)
                            {
                                //Adventurer
                                //We change the attack using the arrows and accept pressing space
                                if (currentCompanion == 0)
                                {
                                    usingStyle = menuSelectionPos;
                                    if (usingStyle == 0) actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_adventurer_attack_sword_description");
                                    else if (usingStyle == 1) actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_adventurer_attack_glance_description");
                                    else if (usingStyle == 2) actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_adventurer_attack_swordspin_description");
                                    else if (usingStyle == 3) actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_adventurer_attack_dragonslayerbow_description");
                                    else if (usingStyle == 4) actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_adventurer_attack_bk-47_description");
                                    if ((menuSelectionPos < currentData.GetComponent<CurrentDataScript>().adventurerLvl + 1) && Input.GetKeyDown(KeyCode.DownArrow))
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
                                        if (usingStyle == 0)
                                        {
                                            actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_adventurer_attack_sword_action");
                                            attackType = 0;
                                        }
                                        else if (usingStyle == 1)
                                        {
                                            actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_adventurer_attack_glance_action");
                                            attackType = 2;
                                        }
                                        else if (usingStyle == 2)
                                        {
                                            actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_adventurer_attack_swordspin_action");
                                            attackType = 0;
                                        }
                                        else if (usingStyle == 3)
                                        {
                                            actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_adventurer_attack_dragonslayerbow_action");
                                            attackType = 1;
                                        }
                                        else if (usingStyle == 4)
                                        {
                                            actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_adventurer_attack_bk-47_action");
                                            attackType = 1;
                                        }
                                        selectingEnemyCompanion = true;
                                        enemyName.SetActive(true);
                                        if (usingStyle < 3) SelectFirstEnemy();
                                        else if (usingStyle == 3) SelectGroundEnemies();
                                        else SelectAllEnemies();
                                    }
                                }
                                //Wizard
                                //We change the attack using the arrows and accept pressing space
                                else if (currentCompanion == 1)
                                {
                                    usingStyle = menuSelectionPos;
                                    if (usingStyle == 0) actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_wizard_attack_magicball_description");
                                    else if (usingStyle == 1) actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_wizard_attack_barrier_description");
                                    else if (usingStyle == 2) actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_wizard_attack_pulsingmagic_description");
                                    else if (usingStyle == 3) actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_wizard_attack_magicspear_description");
                                    else if (usingStyle == 4) actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_wizard_attack_energybomb_description");

                                    if ((menuSelectionPos < currentData.GetComponent<CurrentDataScript>().wizardLvl + 1) && Input.GetKeyDown(KeyCode.DownArrow))
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
                                        attackType = 1;
                                        if (usingStyle == 0) actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_wizard_attack_magicball_action");
                                        else if (usingStyle == 1)
                                        {
                                            actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_wizard_attack_barrier_action");
                                            attackType = 2;
                                        }
                                        else if (usingStyle == 2) actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_wizard_attack_pulsingmagic_action");
                                        else if (usingStyle == 3) actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_wizard_attack_magicspear_action");
                                        else if (usingStyle == 4) actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_wizard_attack_energybomb_action");

                                        enemyName.SetActive(true);
                                        if (usingStyle == 0 || usingStyle == 2 || usingStyle == 3)
                                        {
                                            selectingEnemyCompanion = true;
                                            SelectFirstEnemy();
                                        }
                                        else if (usingStyle == 1)
                                        {
                                            player.transform.GetChild(0).transform.GetChild(5).gameObject.SetActive(true);
                                            enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_player_name");
                                            enemyName.transform.GetChild(1).gameObject.SetActive(false);
                                            enemyName.transform.GetChild(2).gameObject.SetActive(false);
                                            enemyName.transform.GetChild(3).gameObject.SetActive(false);
                                            enemyName.transform.GetChild(4).gameObject.SetActive(false);
                                            selectingCompanion = true;
                                            canSelect = false;
                                        }
                                        else
                                        {
                                            selectingEnemyCompanion = true;
                                            SelectAllEnemies();
                                        }
                                    }
                                }
                            }
                            //Items
                            //We change the item using the arrows and accept pressing space
                            else if (selectingAction == 1)
                            {
                                if (items[menuSelectionPos + scroll] == 1) actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_item_apple_description");
                                else if (items[menuSelectionPos + scroll] == 2) actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_item_lightpotion_description");
                                else if (items[menuSelectionPos + scroll] == 3) actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_item_resurrectionpotion_description");

                                if (((menuSelectionPos + scroll) < (currentData.GetComponent<CurrentDataScript>().itemSize() - 1)) && Input.GetKeyDown(KeyCode.DownArrow))
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
                                    if (currentCompanion == 0) enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_adventurer_name");
                                    else if (currentCompanion == 1) enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_wizard_name");
                                    enemyName.transform.GetChild(1).gameObject.SetActive(false);
                                    enemyName.transform.GetChild(2).gameObject.SetActive(false);
                                    enemyName.transform.GetChild(3).gameObject.SetActive(false);
                                    enemyName.transform.GetChild(4).gameObject.SetActive(false);
                                    companion.GetChild(0).transform.GetChild(1).gameObject.SetActive(true);
                                    companion.GetChild(0).transform.GetChild(0).GetComponent<Animator>().SetBool("MenuHide", true);
                                    companionChoosingAction = false;
                                    if (items[menuSelectionPos] == 1) actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_item_apple_action");
                                    else if (items[menuSelectionPos] == 2) actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_item_lightpotion_action");
                                    else if (items[menuSelectionPos] == 3) actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_item_resurrectionpotion_action");
                                    selectingCompanion = true;
                                    canSelect = true;
                                    enemyName.SetActive(true);
                                }
                            }
                            //Other
                            //We change the action using the arrows and accept pressing space
                            else if (selectingAction == 2)
                            {
                                if (!changeCompanion)
                                {
                                    if (menuSelectionPos == 0) actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_other_changepartner_description");
                                    else if (menuSelectionPos == 1) actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_other_defend_description");
                                    else if (menuSelectionPos == 2) actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_other_flee_description");

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
                                        if (menuSelectionPos == 0)
                                        {
                                            changeCompanion = true;
                                            companion.GetChild(0).transform.GetChild(0).GetComponent<Animator>().SetTrigger("SelectCompanion");
                                            CreateMenu();
                                        }
                                        else if (menuSelectionPos == 1)
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
                                            actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_other_flee_action");
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
                                //If we select the change companion action we can choose using the arrows and accept pressing the space
                                else
                                {
                                    if (menuSelectionPos == 0) actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_other_changepartner_adventurer");
                                    else if (menuSelectionPos == 1) actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_other_changepartner_wizard");

                                    if ((menuSelectionPos < currentData.GetComponent<CurrentDataScript>().unlockedCompanions - 1) && Input.GetKeyDown(KeyCode.DownArrow))
                                    {
                                        companion.GetChild(0).transform.GetChild(0).GetComponent<Animator>().SetTrigger("Down");
                                    }
                                    else if (menuSelectionPos > 0 && Input.GetKeyDown(KeyCode.UpArrow))
                                    {
                                        companion.GetChild(0).transform.GetChild(0).GetComponent<Animator>().SetTrigger("Up");
                                    }
                                    if (Input.GetKeyDown(KeyCode.Space) && menuCanUse[menuSelectionPos])
                                    {
                                        if (menuSelectionPos == 0)
                                        {
                                            companion.GetComponent<PlayerTeamScript>().ChangeCompanion(0);
                                        }
                                        else if (menuSelectionPos == 1)
                                        {
                                            companion.GetComponent<PlayerTeamScript>().ChangeCompanion(1);
                                        }
                                        actionInstructions.SetActive(false);
                                        companionChoosingAction = false;
                                        changeCompanion = false;
                                        companion.GetChild(0).transform.GetChild(0).GetComponent<Animator>().SetBool("Active", false);
                                        companion.GetChild(0).transform.GetChild(0).GetComponent<Animator>().SetBool("MenuHide", false);
                                        companion.GetChild(0).transform.GetChild(0).GetComponent<Animator>().SetBool("MenuOpened", false);
                                    }
                                }
                            }
                            //We can return to the previous menu pressing Q
                            if (Input.GetKeyDown(KeyCode.Q))
                            {
                                if (!changeCompanion)
                                {
                                    changePosAction.SetActive(!playerTurnCompleted);
                                    actionInstructions.SetActive(false);
                                    companion.GetChild(0).transform.GetChild(0).GetComponent<Animator>().SetBool("MenuOpened", false);
                                    companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(7).GetComponent<Image>().color = new Vector4(companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(7).GetComponent<Image>().color.r, companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(7).GetComponent<Image>().color.g, companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(7).GetComponent<Image>().color.b, 0.0f);
                                    companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(8).GetComponent<Image>().color = new Vector4(companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(8).GetComponent<Image>().color.r, companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(8).GetComponent<Image>().color.g, companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(8).GetComponent<Image>().color.b, 0.0f);
                                }
                                else
                                {
                                    changeCompanion = false;
                                    CreateMenu();
                                }
                            }
                        }
                    }                    
                }
                //When we select a frindly action we give it to a party member
                else if (selectingCompanion)
                {
                    //We can return to the previous menu pressing q
                    if (Input.GetKeyDown(KeyCode.Q))
                    {
                        CreateMenu();
                        enemyName.SetActive(false);
                        companionChoosingAction = true;
                        selectingCompanion = false;
                        actionInstructions.GetComponent<Image>().color = new Vector4(actionInstructions.GetComponent<Image>().color.r, actionInstructions.GetComponent<Image>().color.g, actionInstructions.GetComponent<Image>().color.b, 1.0f);
                        actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = new Vector4(actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color.r, actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color.g, actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color.b, 1.0f);
                        companion.GetChild(0).transform.GetChild(0).GetComponent<Animator>().SetBool("MenuHide", false);
                        companion.GetChild(0).transform.GetChild(1).gameObject.SetActive(false);
                        player.GetChild(0).transform.GetChild(5).gameObject.SetActive(false);
                    }
                    //If we can select
                    if (canSelect)
                    {
                        //If the player is the one being selected we only can change to a partner usign the arrows and space to accept
                        if (player.GetChild(0).transform.GetChild(5).gameObject.activeSelf)
                        {
                            if (firstPosPlayer)
                            {
                                if (Input.GetKeyDown(KeyCode.LeftArrow))
                                {
                                    player.GetChild(0).transform.GetChild(5).gameObject.SetActive(false);
                                    companion.GetChild(0).transform.GetChild(1).gameObject.SetActive(true);
                                    if (currentCompanion == 0) enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_adventurer_name");
                                    else if (currentCompanion == 1) enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_wizard_name");                                        
                                }
                            }
                            else
                            {
                                if (Input.GetKeyDown(KeyCode.RightArrow))
                                {
                                    player.GetChild(0).transform.GetChild(5).gameObject.SetActive(false);
                                    companion.GetChild(0).transform.GetChild(1).gameObject.SetActive(true);
                                    companion.GetChild(0).transform.GetChild(1).gameObject.SetActive(true);
                                    if (currentCompanion == 0) enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_adventurer_name");
                                    else if (currentCompanion == 1) enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_wizard_name");
                                }
                            }
                            if (Input.GetKeyDown(KeyCode.Space))
                            {
                                player.GetChild(0).transform.GetChild(5).gameObject.SetActive(false);
                                if (items[menuSelectionPos + scroll] == 1)
                                {
                                    UISource.clip = healClip;
                                    UISource.Play();
                                    player.GetComponent<PlayerTeamScript>().Heal(5, false, true, false, false);
                                }
                                else if (items[menuSelectionPos + scroll] == 2)
                                {
                                    UISource.clip = lightClip;
                                    UISource.Play();
                                    player.GetComponent<PlayerTeamScript>().IncreaseLight(5, false, false, false);
                                }
                                else if (items[menuSelectionPos + scroll] == 3)
                                {
                                    UISource.clip = recoverClip;
                                    UISource.Play();
                                    player.GetComponent<PlayerTeamScript>().Recover(false, false);
                                }
                                currentData.GetComponent<CurrentDataScript>().DeleteItem(menuSelectionPos + scroll);
                                scroll = 0;
                                actionInstructions.SetActive(false);
                                companion.GetChild(0).transform.GetChild(0).GetComponent<Animator>().SetBool("Active", false);
                                companion.GetChild(0).transform.GetChild(0).GetComponent<Animator>().SetBool("MenuHide", false);
                                companion.GetChild(0).transform.GetChild(0).GetComponent<Animator>().SetBool("MenuOpened", false);
                                enemyName.SetActive(false);
                                selectingCompanion = false;
                            }
                        }
                        //If the companion is the one being selected we only can change to the player usign the arrows and space to accept
                        else if (companion.GetChild(0).transform.GetChild(1).gameObject.activeSelf)
                        {
                            if (firstPosPlayer)
                            {
                                if (Input.GetKeyDown(KeyCode.RightArrow))
                                {
                                    player.GetChild(0).transform.GetChild(5).gameObject.SetActive(true);
                                    companion.GetChild(0).transform.GetChild(1).gameObject.SetActive(false);
                                    enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_player_name");
                                }
                            }
                            else
                            {
                                if (Input.GetKeyDown(KeyCode.LeftArrow))
                                {
                                    player.GetChild(0).transform.GetChild(5).gameObject.SetActive(true);
                                    companion.GetChild(0).transform.GetChild(1).gameObject.SetActive(false);
                                    enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_player_name");
                                }
                            }
                            //When a companion can select a team mate it can only be because they are using an item
                            if (Input.GetKeyDown(KeyCode.Space))
                            {
                                companion.GetChild(0).transform.GetChild(1).gameObject.SetActive(false);
                                if (items[menuSelectionPos + scroll] == 1)
                                {
                                    UISource.clip = healClip;
                                    UISource.Play();
                                    companion.GetComponent<PlayerTeamScript>().Heal(5, false, true, false, false);
                                }
                                else if (items[menuSelectionPos + scroll] == 2)
                                {
                                    UISource.clip = lightClip;
                                    UISource.Play();
                                    player.GetComponent<PlayerTeamScript>().IncreaseLight(5, false, false, false);
                                }
                                else if (items[menuSelectionPos + scroll] == 3)
                                {
                                    UISource.clip = recoverClip;
                                    UISource.Play();
                                    companion.GetComponent<PlayerTeamScript>().Recover(false, false);
                                }
                                currentData.GetComponent<CurrentDataScript>().DeleteItem(menuSelectionPos + scroll);
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
                    //When we cant select we start an attack when we press space
                    else if (Input.GetKeyDown(KeyCode.Space))
                    {
                        player.GetChild(0).transform.GetChild(5).gameObject.SetActive(false);
                        companion.GetChild(0).transform.GetChild(0).GetComponent<Animator>().SetBool("Active", false);
                        companion.GetChild(0).transform.GetChild(0).GetComponent<Animator>().SetBool("MenuHide", false);
                        companion.GetChild(0).transform.GetChild(0).GetComponent<Animator>().SetBool("MenuOpened", false);
                        enemyName.SetActive(false);
                        selectingCompanion = false;
                        actionInstructions.GetComponent<Image>().color = new Vector4(actionInstructions.GetComponent<Image>().color.r, actionInstructions.GetComponent<Image>().color.g, actionInstructions.GetComponent<Image>().color.b, 1.0f);
                        actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = new Vector4(actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color.r, actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color.g, actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color.b, 1.0f);
                        companion.GetComponent<PlayerTeamScript>().Attack(attackType, usingStyle, player);
                    }
                }
                //Selecting enemy
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
                        //When we use the adventurer we can only select grounded enemies, unless we are using the glance being able to target all the enemies
                        //When we use the wizard we can only select the first flying enemy and the first grounded enemy, unless we are using the pulsing magic targeting the grounded enemies only
                        if (enemyNumber > 1)
                        {
                            if (enemy1.GetChild(0).transform.GetChild(0).gameObject.activeSelf)
                            {
                                if (Input.GetKeyDown(KeyCode.RightArrow))
                                {
                                    if (currentCompanion != 1 || ((usingStyle != 0 && usingStyle != 3) && currentCompanion == 1))
                                    {
                                        if (enemy2.GetComponent<EnemyTeamScript>().IsAlive() && ((usingStyle != 1 && companion.GetComponent<PlayerTeamScript>().GetPlayerType() == 1 && enemy2.GetComponent<EnemyTeamScript>().IsGrounded()) || (usingStyle == 1 && companion.GetComponent<PlayerTeamScript>().GetPlayerType() == 1) || (companion.GetComponent<PlayerTeamScript>().GetPlayerType() == 2 && usingStyle == 2 && enemy2.GetComponent<EnemyTeamScript>().IsGrounded())))
                                        {
                                            enemy1.GetChild(0).transform.GetChild(0).gameObject.SetActive(false);
                                            enemy2.GetChild(0).transform.GetChild(0).gameObject.SetActive(true);
                                            if (enemy2.GetComponent<EnemyTeamScript>().enemyType == 0) enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_enemy_bandit");
                                            else if (enemy2.GetComponent<EnemyTeamScript>().enemyType == 1) enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_enemy_evilwizard");
                                            else if (enemy2.GetComponent<EnemyTeamScript>().enemyType == 2) enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_enemy_king");
                                            else if (enemy2.GetComponent<EnemyTeamScript>().enemyType == 3) enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_enemy_knight");
                                        }
                                        else if (enemyNumber > 2 && enemy3.GetComponent<EnemyTeamScript>().IsAlive() && ((usingStyle != 1 && companion.GetComponent<PlayerTeamScript>().GetPlayerType() == 1 && enemy3.GetComponent<EnemyTeamScript>().IsGrounded()) || (usingStyle == 1 && companion.GetComponent<PlayerTeamScript>().GetPlayerType() == 1) || (companion.GetComponent<PlayerTeamScript>().GetPlayerType() == 2 && usingStyle == 2 && enemy3.GetComponent<EnemyTeamScript>().IsGrounded())))
                                        {
                                            enemy1.GetChild(0).transform.GetChild(0).gameObject.SetActive(false);
                                            enemy3.GetChild(0).transform.GetChild(0).gameObject.SetActive(true);
                                            if (enemy3.GetComponent<EnemyTeamScript>().enemyType == 0) enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_enemy_bandit");
                                            else if (enemy3.GetComponent<EnemyTeamScript>().enemyType == 1) enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_enemy_evilwizard");
                                            else if (enemy3.GetComponent<EnemyTeamScript>().enemyType == 2) enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_enemy_king");
                                            else if (enemy3.GetComponent<EnemyTeamScript>().enemyType == 3) enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_enemy_knight");
                                        }
                                        else if (enemyNumber > 3 && enemy4.GetComponent<EnemyTeamScript>().IsAlive() && ((usingStyle != 1 && companion.GetComponent<PlayerTeamScript>().GetPlayerType() == 1 && enemy4.GetComponent<EnemyTeamScript>().IsGrounded()) || (usingStyle == 1 && companion.GetComponent<PlayerTeamScript>().GetPlayerType() == 1) || (companion.GetComponent<PlayerTeamScript>().GetPlayerType() == 2 && usingStyle == 2 && enemy4.GetComponent<EnemyTeamScript>().IsGrounded())))
                                        {
                                            enemy1.GetChild(0).transform.GetChild(0).gameObject.SetActive(false);
                                            enemy4.GetChild(0).transform.GetChild(0).gameObject.SetActive(true);
                                            if (enemy4.GetComponent<EnemyTeamScript>().enemyType == 0) enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_enemy_bandit");
                                            else if (enemy4.GetComponent<EnemyTeamScript>().enemyType == 1) enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_enemy_evilwizard");
                                            else if (enemy4.GetComponent<EnemyTeamScript>().enemyType == 2) enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_enemy_king");
                                            else if (enemy4.GetComponent<EnemyTeamScript>().enemyType == 3) enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_enemy_knight");
                                        }
                                    }                                        
                                    else 
                                    {
                                        Transform enemy = SelectNextShuriken(enemy1.GetComponent<EnemyTeamScript>().IsGrounded());
                                        if (enemy != null)
                                        {
                                            enemy1.GetChild(0).transform.GetChild(0).gameObject.SetActive(false);
                                            enemy.GetChild(0).transform.GetChild(0).gameObject.SetActive(true);
                                            if (enemy.GetComponent<EnemyTeamScript>().enemyType == 0) enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_enemy_bandit");
                                            else if (enemy.GetComponent<EnemyTeamScript>().enemyType == 1) enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_enemy_evilwizard");
                                            else if (enemy.GetComponent<EnemyTeamScript>().enemyType == 2) enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_enemy_king");
                                            else if (enemy.GetComponent<EnemyTeamScript>().enemyType == 3) enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_enemy_knight");
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
                                if (Input.GetKeyDown(KeyCode.LeftArrow) && enemy1.GetComponent<EnemyTeamScript>().IsAlive() && ((usingStyle != 1 && companion.GetComponent<PlayerTeamScript>().GetPlayerType() == 1 && enemy1.GetComponent<EnemyTeamScript>().IsGrounded()) || (usingStyle == 1 && companion.GetComponent<PlayerTeamScript>().GetPlayerType() == 1) || (companion.GetComponent<PlayerTeamScript>().GetPlayerType() == 2 && ((usingStyle == 2 && enemy1.GetComponent<EnemyTeamScript>().IsGrounded()) || usingStyle == 0 || usingStyle == 3))))
                                {
                                    enemy1.GetChild(0).transform.GetChild(0).gameObject.SetActive(true);
                                    enemy2.GetChild(0).transform.GetChild(0).gameObject.SetActive(false);
                                    if (enemy1.GetComponent<EnemyTeamScript>().enemyType == 0) enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_enemy_bandit");
                                    else if (enemy1.GetComponent<EnemyTeamScript>().enemyType == 1) enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_enemy_evilwizard");
                                    else if (enemy1.GetComponent<EnemyTeamScript>().enemyType == 2) enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_enemy_king");
                                    else if (enemy1.GetComponent<EnemyTeamScript>().enemyType == 3) enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_enemy_knight");
                                }
                                if (Input.GetKeyDown(KeyCode.RightArrow))
                                {
                                    if (currentCompanion != 1 || ((usingStyle != 0 && usingStyle != 3) && currentCompanion == 1))
                                    {
                                        if (enemyNumber > 2 && enemy3.GetComponent<EnemyTeamScript>().IsAlive() && ((usingStyle != 1 && companion.GetComponent<PlayerTeamScript>().GetPlayerType() == 1 && enemy3.GetComponent<EnemyTeamScript>().IsGrounded()) || (usingStyle == 1 && companion.GetComponent<PlayerTeamScript>().GetPlayerType() == 1) || (companion.GetComponent<PlayerTeamScript>().GetPlayerType() == 2 && usingStyle == 2 && enemy3.GetComponent<EnemyTeamScript>().IsGrounded())))
                                        {
                                            enemy2.GetChild(0).transform.GetChild(0).gameObject.SetActive(false);
                                            enemy3.GetChild(0).transform.GetChild(0).gameObject.SetActive(true);
                                            if (enemy3.GetComponent<EnemyTeamScript>().enemyType == 0) enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_enemy_bandit");
                                            else if (enemy3.GetComponent<EnemyTeamScript>().enemyType == 1) enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_enemy_evilwizard");
                                            else if (enemy3.GetComponent<EnemyTeamScript>().enemyType == 2) enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_enemy_king");
                                            else if (enemy3.GetComponent<EnemyTeamScript>().enemyType == 3) enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_enemy_knight");
                                        }
                                        else if (enemyNumber > 3 && enemy4.GetComponent<EnemyTeamScript>().IsAlive() && ((usingStyle != 1 && companion.GetComponent<PlayerTeamScript>().GetPlayerType() == 1 && enemy4.GetComponent<EnemyTeamScript>().IsGrounded()) || (usingStyle == 1 && companion.GetComponent<PlayerTeamScript>().GetPlayerType() == 1) || (companion.GetComponent<PlayerTeamScript>().GetPlayerType() == 2 && usingStyle == 2 && enemy4.GetComponent<EnemyTeamScript>().IsGrounded())))
                                        {
                                            enemy2.GetChild(0).transform.GetChild(0).gameObject.SetActive(false);
                                            enemy4.GetChild(0).transform.GetChild(0).gameObject.SetActive(true);
                                            if (enemy4.GetComponent<EnemyTeamScript>().enemyType == 0) enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_enemy_bandit");
                                            else if (enemy4.GetComponent<EnemyTeamScript>().enemyType == 1) enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_enemy_evilwizard");
                                            else if (enemy4.GetComponent<EnemyTeamScript>().enemyType == 2) enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_enemy_king");
                                            else if (enemy4.GetComponent<EnemyTeamScript>().enemyType == 3) enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_enemy_knight");
                                        }
                                    }                                    
                                    else if (!enemy1.GetComponent<EnemyTeamScript>().IsAlive())
                                    {
                                        Transform enemy = SelectNextShuriken(enemy2.GetComponent<EnemyTeamScript>().IsGrounded());
                                        if (enemy != null)
                                        {
                                            enemy2.GetChild(0).transform.GetChild(0).gameObject.SetActive(false);
                                            enemy.GetChild(0).transform.GetChild(0).gameObject.SetActive(true);
                                            if (enemy.GetComponent<EnemyTeamScript>().enemyType == 0) enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_enemy_bandit");
                                            else if (enemy.GetComponent<EnemyTeamScript>().enemyType == 1) enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_enemy_evilwizard");
                                            else if (enemy.GetComponent<EnemyTeamScript>().enemyType == 2) enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_enemy_king");
                                            else if (enemy.GetComponent<EnemyTeamScript>().enemyType == 3) enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_enemy_knight");
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
                            else if (enemyNumber > 2 && enemy3.GetChild(0).transform.GetChild(0).gameObject.activeSelf)
                            {
                                if (Input.GetKeyDown(KeyCode.LeftArrow))
                                {
                                    if(currentCompanion != 1 || (currentCompanion == 1 && (usingStyle != 0 && usingStyle != 3)))
                                    {
                                        if (enemy2.GetComponent<EnemyTeamScript>().IsAlive() && ((usingStyle != 1 && companion.GetComponent<PlayerTeamScript>().GetPlayerType() == 1 && enemy2.GetComponent<EnemyTeamScript>().IsGrounded()) || (usingStyle == 1 && companion.GetComponent<PlayerTeamScript>().GetPlayerType() == 1) || (companion.GetComponent<PlayerTeamScript>().GetPlayerType() == 2 && usingStyle == 2 && enemy2.GetComponent<EnemyTeamScript>().IsGrounded())))
                                        {
                                            enemy2.GetChild(0).transform.GetChild(0).gameObject.SetActive(true);
                                            enemy3.GetChild(0).transform.GetChild(0).gameObject.SetActive(false);
                                            if (enemy2.GetComponent<EnemyTeamScript>().enemyType == 0) enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_enemy_bandit");
                                            else if (enemy2.GetComponent<EnemyTeamScript>().enemyType == 1) enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_enemy_evilwizard");
                                            else if (enemy2.GetComponent<EnemyTeamScript>().enemyType == 2) enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_enemy_king");
                                            else if (enemy2.GetComponent<EnemyTeamScript>().enemyType == 3) enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_enemy_knight");
                                        }
                                        else if (enemy1.GetComponent<EnemyTeamScript>().IsAlive() && ((usingStyle != 1 && companion.GetComponent<PlayerTeamScript>().GetPlayerType() == 1 && enemy1.GetComponent<EnemyTeamScript>().IsGrounded()) || (usingStyle == 1 && companion.GetComponent<PlayerTeamScript>().GetPlayerType() == 1) || (companion.GetComponent<PlayerTeamScript>().GetPlayerType() == 2 && usingStyle == 2 && enemy1.GetComponent<EnemyTeamScript>().IsGrounded())))
                                        {
                                            enemy1.GetChild(0).transform.GetChild(0).gameObject.SetActive(true);
                                            enemy3.GetChild(0).transform.GetChild(0).gameObject.SetActive(false);
                                            if (enemy1.GetComponent<EnemyTeamScript>().enemyType == 0) enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_enemy_bandit");
                                            else if (enemy1.GetComponent<EnemyTeamScript>().enemyType == 1) enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_enemy_evilwizard");
                                            else if (enemy1.GetComponent<EnemyTeamScript>().enemyType == 2) enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_enemy_king");
                                            else if (enemy1.GetComponent<EnemyTeamScript>().enemyType == 3) enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_enemy_knight");
                                        }
                                    }                                    
                                    else if (enemy1.GetComponent<EnemyTeamScript>().IsAlive() || enemy2.GetComponent<EnemyTeamScript>().IsAlive())
                                    {
                                        Transform enemy = SelectNextShuriken(enemy3.GetComponent<EnemyTeamScript>().IsGrounded());
                                        if (enemy != null)
                                        {
                                            enemy3.GetChild(0).transform.GetChild(0).gameObject.SetActive(false);
                                            enemy.GetChild(0).transform.GetChild(0).gameObject.SetActive(true);
                                            if (enemy.GetComponent<EnemyTeamScript>().enemyType == 0) enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_enemy_bandit");
                                            else if (enemy.GetComponent<EnemyTeamScript>().enemyType == 1) enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_enemy_evilwizard");
                                            else if (enemy.GetComponent<EnemyTeamScript>().enemyType == 2) enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_enemy_king");
                                            else if (enemy.GetComponent<EnemyTeamScript>().enemyType == 3) enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_enemy_knight");
                                        }
                                    }
                                }
                                if (Input.GetKeyDown(KeyCode.RightArrow))
                                {
                                    if (currentCompanion != 1 || (currentCompanion == 1 && (usingStyle != 0 && usingStyle != 3)))
                                    {
                                        if (enemyNumber > 3 && enemy4.GetComponent<EnemyTeamScript>().IsAlive() && ((usingStyle != 1 && companion.GetComponent<PlayerTeamScript>().GetPlayerType() == 1 && enemy4.GetComponent<EnemyTeamScript>().IsGrounded()) || (usingStyle == 1 && companion.GetComponent<PlayerTeamScript>().GetPlayerType() == 1) || (companion.GetComponent<PlayerTeamScript>().GetPlayerType() == 2 && usingStyle == 2 && enemy4.GetComponent<EnemyTeamScript>().IsGrounded())))
                                        {
                                            enemy3.GetChild(0).transform.GetChild(0).gameObject.SetActive(false);
                                            enemy4.GetChild(0).transform.GetChild(0).gameObject.SetActive(true);
                                            if (enemy4.GetComponent<EnemyTeamScript>().enemyType == 0) enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_enemy_bandit");
                                            else if (enemy4.GetComponent<EnemyTeamScript>().enemyType == 1) enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_enemy_evilwizard");
                                            else if (enemy4.GetComponent<EnemyTeamScript>().enemyType == 2) enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_enemy_king");
                                            else if (enemy4.GetComponent<EnemyTeamScript>().enemyType == 3) enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_enemy_knight");
                                        }
                                    }                                        
                                    else if (!enemy1.GetComponent<EnemyTeamScript>().IsAlive() && !enemy2.GetComponent<EnemyTeamScript>().IsAlive())
                                    {
                                        Transform enemy = SelectNextShuriken(enemy3.GetComponent<EnemyTeamScript>().IsGrounded());
                                        if (enemy != null)
                                        {
                                            enemy3.GetChild(0).transform.GetChild(0).gameObject.SetActive(false);
                                            enemy.GetChild(0).transform.GetChild(0).gameObject.SetActive(true);
                                            if (enemy.GetComponent<EnemyTeamScript>().enemyType == 0) enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_enemy_bandit");
                                            else if (enemy.GetComponent<EnemyTeamScript>().enemyType == 1) enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_enemy_evilwizard");
                                            else if (enemy.GetComponent<EnemyTeamScript>().enemyType == 2) enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_enemy_king");
                                            else if (enemy.GetComponent<EnemyTeamScript>().enemyType == 3) enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_enemy_knight");
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
                            else if (enemyNumber > 3 && enemy4.GetChild(0).transform.GetChild(0).gameObject.activeSelf)
                            {
                                if (Input.GetKeyDown(KeyCode.LeftArrow))
                                {
                                    if (currentCompanion != 1 || (currentCompanion == 1 && (usingStyle != 0 && usingStyle != 3)))
                                    {
                                        if (enemy3.GetComponent<EnemyTeamScript>().IsAlive() && ((usingStyle != 1 && companion.GetComponent<PlayerTeamScript>().GetPlayerType() == 1 && enemy3.GetComponent<EnemyTeamScript>().IsGrounded()) || (usingStyle == 1 && companion.GetComponent<PlayerTeamScript>().GetPlayerType() == 1) || (companion.GetComponent<PlayerTeamScript>().GetPlayerType() == 2 && usingStyle == 2 && enemy3.GetComponent<EnemyTeamScript>().IsGrounded())))
                                        {
                                            enemy3.GetChild(0).transform.GetChild(0).gameObject.SetActive(true);
                                            enemy4.GetChild(0).transform.GetChild(0).gameObject.SetActive(false);
                                            if (enemy3.GetComponent<EnemyTeamScript>().enemyType == 0) enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_enemy_bandit");
                                            else if (enemy3.GetComponent<EnemyTeamScript>().enemyType == 1) enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_enemy_evilwizard");
                                            else if (enemy3.GetComponent<EnemyTeamScript>().enemyType == 2) enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_enemy_king");
                                            else if (enemy3.GetComponent<EnemyTeamScript>().enemyType == 3) enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_enemy_knight");
                                        }
                                        else if (enemy2.GetComponent<EnemyTeamScript>().IsAlive() && ((usingStyle != 1 && companion.GetComponent<PlayerTeamScript>().GetPlayerType() == 1 && enemy2.GetComponent<EnemyTeamScript>().IsGrounded()) || (usingStyle == 1 && companion.GetComponent<PlayerTeamScript>().GetPlayerType() == 1) || (companion.GetComponent<PlayerTeamScript>().GetPlayerType() == 2 && usingStyle == 2 && enemy2.GetComponent<EnemyTeamScript>().IsGrounded())))
                                        {
                                            enemy2.GetChild(0).transform.GetChild(0).gameObject.SetActive(true);
                                            enemy4.GetChild(0).transform.GetChild(0).gameObject.SetActive(false);
                                            if (enemy2.GetComponent<EnemyTeamScript>().enemyType == 0) enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_enemy_bandit");
                                            else if (enemy2.GetComponent<EnemyTeamScript>().enemyType == 1) enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_enemy_evilwizard");
                                            else if (enemy2.GetComponent<EnemyTeamScript>().enemyType == 2) enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_enemy_king");
                                            else if (enemy2.GetComponent<EnemyTeamScript>().enemyType == 3) enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_enemy_knight");
                                        }
                                        else if (enemy1.GetComponent<EnemyTeamScript>().IsAlive() && ((usingStyle != 1 && companion.GetComponent<PlayerTeamScript>().GetPlayerType() == 1 && enemy1.GetComponent<EnemyTeamScript>().IsGrounded()) || (usingStyle == 1 && companion.GetComponent<PlayerTeamScript>().GetPlayerType() == 1) || (companion.GetComponent<PlayerTeamScript>().GetPlayerType() == 2 && usingStyle == 2 && enemy1.GetComponent<EnemyTeamScript>().IsGrounded())))
                                        {
                                            enemy1.GetChild(0).transform.GetChild(0).gameObject.SetActive(true);
                                            enemy4.GetChild(0).transform.GetChild(0).gameObject.SetActive(false);
                                            if (enemy1.GetComponent<EnemyTeamScript>().enemyType == 0) enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_enemy_bandit");
                                            else if (enemy1.GetComponent<EnemyTeamScript>().enemyType == 1) enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_enemy_evilwizard");
                                            else if (enemy1.GetComponent<EnemyTeamScript>().enemyType == 2) enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_enemy_king");
                                            else if (enemy1.GetComponent<EnemyTeamScript>().enemyType == 3) enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_enemy_knight");
                                        }
                                    }                                        
                                    else
                                    {
                                        Transform enemy = SelectNextShuriken(enemy4.GetComponent<EnemyTeamScript>().IsGrounded());
                                        if (enemy != null)
                                        {
                                            enemy4.GetChild(0).transform.GetChild(0).gameObject.SetActive(false);
                                            enemy.GetChild(0).transform.GetChild(0).gameObject.SetActive(true);
                                            if (enemy.GetComponent<EnemyTeamScript>().enemyType == 0) enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_enemy_bandit");
                                            else if (enemy.GetComponent<EnemyTeamScript>().enemyType == 1) enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_enemy_evilwizard");
                                            else if (enemy.GetComponent<EnemyTeamScript>().enemyType == 2) enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_enemy_king");
                                            else if (enemy.GetComponent<EnemyTeamScript>().enemyType == 3) enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_enemy_knight");
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
                            actionInstructions.GetComponent<Image>().color = new Vector4(actionInstructions.GetComponent<Image>().color.r, actionInstructions.GetComponent<Image>().color.g, actionInstructions.GetComponent<Image>().color.b, 1.0f);
                            actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = new Vector4(actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color.r, actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color.g, actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color.b, 1.0f);
                            companion.GetComponent<PlayerTeamScript>().Attack(attackType, usingStyle, selectedEnemy);
                        }
                    }
                    //If we cant select we press space and the attack starts
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
                //The fase where the companion deals the attack
                else if (finalAttack)
                {
                    //Adventurer
                    if(currentCompanion == 0)
                    { 
                        //Normal sword or Multi strike sword
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
                        //Glance
                        else if (usingStyle == 1)
                        {
                            //We check that the player presses X when it is said so
                            if (!attackAction && Input.GetKeyDown(KeyCode.X))
                            {
                                BadCommand();
                                badAttack = true;
                                companion.GetComponent<PlayerTeamScript>().EndGlance();
                                badAttack = false;
                            }
                            if (attackAction)
                            {
                                if (Input.GetKeyDown(KeyCode.X) && !badAttack)
                                {
                                    goodAttack = true;
                                    attackAction = false;
                                    companion.GetComponent<PlayerTeamScript>().EndGlance();
                                    goodAttack = false;
                                }
                            }
                        }
                        //Dragonslayer bow
                        else if (usingStyle == 3)
                        {
                            //We check that the player releases the X button when it is said so
                            if (Input.GetKey(KeyCode.X) && !companion.transform.GetChild(0).transform.GetChild(3).GetComponent<Animator>().GetBool("charging"))
                            {
                                DeactivateActionInstructions();
                                companion.transform.GetChild(0).transform.GetChild(3).GetComponent<Animator>().SetBool("charging", true);
                            }
                            if (Input.GetKeyUp(KeyCode.X) && attackAction)
                            {
                                GoodCommand(true,1);
                                companion.GetComponent<PlayerTeamScript>().SetShurikenDamage(2);
                                companion.transform.GetChild(0).transform.GetChild(3).GetComponent<Animator>().SetBool("charging", false);
                                companion.GetComponent<Animator>().SetTrigger("ShootArrow");
                                companion.transform.GetChild(0).transform.GetChild(3).GetComponent<Animator>().SetBool("active", false);
                                attackAction = false;
                                finalAttack = false;
                            }
                            else if (Input.GetKeyUp(KeyCode.X) && !attackAction && !attackFinished)
                            {
                                BadCommand();
                                companion.GetComponent<PlayerTeamScript>().SetShurikenDamage(1);
                                companion.GetComponent<Animator>().SetTrigger("ShootArrow");
                                companion.transform.GetChild(0).transform.GetChild(3).GetComponent<Animator>().SetBool("charging", false);
                                companion.transform.GetChild(0).transform.GetChild(3).GetComponent<Animator>().SetBool("active", false);
                                finalAttack = false;
                            }
                            else if (attackFinished)
                            {
                                BadCommand();
                                companion.GetComponent<PlayerTeamScript>().SetShurikenDamage(1);
                                companion.GetComponent<Animator>().SetTrigger("ShootArrow");
                                companion.transform.GetChild(0).transform.GetChild(3).GetComponent<Animator>().SetBool("charging", false);
                                companion.transform.GetChild(0).transform.GetChild(3).GetComponent<Animator>().SetBool("active", false);
                                finalAttack = false;
                            }
                        }
                        //BK-47
                        else if (usingStyle == 4)
                        {
                            //We shot an arrow when the player presses X
                            if (GetAllEnemies() != null)
                            {
                                if (readyShoot && Input.GetKeyDown(KeyCode.X))
                                {
                                    DeactivateActionInstructions();
                                    companion.GetComponent<PlayerTeamScript>().SetShurikenDamage(3);
                                    companion.GetComponent<Animator>().SetTrigger("ShootArrow");
                                }
                            }
                            else companion.GetComponent<PlayerTeamScript>().EndShurikenThrow();
                        }
                        
                    }
                    //Wizard
                    else if(currentCompanion == 1)
                    {
                        //Magic ball
                        if(usingStyle == 0)
                        {
                            //We check that the player presses the correct button
                            if (!attackAction && (Input.GetKeyDown(KeyCode.UpArrow)|| Input.GetKeyDown(KeyCode.DownArrow)|| Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow)))
                            {
                                BadCommand();
                                companion.transform.GetChild(0).transform.GetChild(3).gameObject.SetActive(false);
                                companion.GetComponent<PlayerTeamScript>().SetShurikenDamage(1);
                                companion.GetComponent<Animator>().SetBool("magicBall", false);
                            }
                            if (attackAction)
                            {
                                if (Input.GetKeyDown(magicKey) && !badAttack)
                                {
                                    GoodCommand(true,1);
                                    companion.transform.GetChild(0).transform.GetChild(3).gameObject.SetActive(false);
                                    companion.GetComponent<PlayerTeamScript>().SetShurikenDamage(2);
                                    companion.GetComponent<Animator>().SetBool("magicBall", false);
                                    attackAction = false;
                                }
                            }
                            if (attackFinished)
                            {
                                BadCommand();
                                companion.transform.GetChild(0).transform.GetChild(3).gameObject.SetActive(false);
                                companion.GetComponent<PlayerTeamScript>().SetShurikenDamage(1);
                                companion.GetComponent<Animator>().SetBool("magicBall", false);
                                attackAction = false;
                            }
                        }
                        //Barrier
                        else if(usingStyle == 1)
                        {
                            //We check that the player presses the button sequence in time
                            if ((Time.fixedTime - barrierTime) < 2.0f && barrierNumber < 5)
                            {
                                if (Input.GetKeyDown(barrierKeys[barrierNumber]))
                                {
                                    if (barrierKeys[barrierNumber] == KeyCode.UpArrow) companion.transform.GetChild(0).GetChild(4).GetChild(barrierNumber).GetComponent<Image>().sprite = upArrowSpritePressed;
                                    else if (barrierKeys[barrierNumber] == KeyCode.DownArrow) companion.transform.GetChild(0).GetChild(4).GetChild(barrierNumber).GetComponent<Image>().sprite = downArrowSpritePressed;
                                    else if (barrierKeys[barrierNumber] == KeyCode.LeftArrow) companion.transform.GetChild(0).GetChild(4).GetChild(barrierNumber).GetComponent<Image>().sprite = leftArrowSpritePressed;
                                    else if (barrierKeys[barrierNumber] == KeyCode.RightArrow) companion.transform.GetChild(0).GetChild(4).GetChild(barrierNumber).GetComponent<Image>().sprite = rightArrowSpritePressed;
                                    barrierNumber += 1;
                                }
                                else if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
                                {
                                    BadCommand();
                                    actionInstructions.SetActive(false);
                                    barrierNumber = 0;
                                    taunting = true;
                                    companion.GetChild(0).Find("BarrierAction").gameObject.SetActive(false);
                                    finalAttack = false;
                                    EndPlayerTurn(2);
                                }
                            }
                            else
                            {
                                if (barrierNumber < 5)
                                {
                                    BadCommand();
                                    actionInstructions.SetActive(false);
                                    barrierNumber = 0;
                                    taunting = true;
                                    companion.GetChild(0).Find("BarrierAction").gameObject.SetActive(false);
                                    finalAttack = false;
                                    EndPlayerTurn(2);
                                }
                                else
                                {
                                    GoodCommand(true,1);
                                    actionInstructions.SetActive(false);
                                    barrierNumber = 0;
                                    defenseCompanion = 1;
                                    taunting = true;
                                    companion.GetChild(0).Find("BarrierAction").gameObject.SetActive(false);
                                    finalAttack = false;
                                    companion.GetComponent<PlayerTeamScript>().BarrierSound();
                                    companion.GetChild(1).GetComponent<SpriteRenderer>().color = new Color(companion.GetChild(1).GetComponent<SpriteRenderer>().color.r, companion.GetChild(1).GetComponent<SpriteRenderer>().color.g, companion.GetChild(1).GetComponent<SpriteRenderer>().color.b, 1.0f);
                                    EndPlayerTurn(2);
                                }
                            }
                        }
                        //Pulsing magic
                        else if (usingStyle == 2)
                        {
                            //We check that the player fills the bar
                            if ((Time.fixedTime - shurikenTime) < 5.0f && player.transform.GetChild(0).transform.GetChild(4).transform.GetChild(1).GetComponent<Image>().fillAmount < 1.0f)
                            {
                                if (Input.GetKeyDown(KeyCode.RightArrow))companion.transform.GetChild(0).transform.GetChild(5).transform.GetChild(1).GetComponent<Image>().fillAmount += 0.06f;
                            }
                        }
                        //Magic spear
                        else if (usingStyle == 3)
                        {
                            //We check that the player presses the correct buttons when they are said so
                            if (!attackAction && (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow)))
                            {
                                BadCommand();
                                companion.GetChild(0).GetChild(6).GetComponent<Animator>().SetBool("charge", false);
                                companion.GetChild(0).GetChild(6).gameObject.SetActive(false);
                                companion.GetComponent<PlayerTeamScript>().SetShurikenDamage(2);
                                companion.GetComponent<Animator>().SetBool("magicBall", false);
                            }
                            if (attackAction)
                            {
                                if (Input.GetKeyDown(magicKey) && !badAttack)
                                {
                                    if(magicSpearKey == 3)
                                    {
                                        GoodCommand(true,1);
                                        companion.GetChild(0).GetChild(6).GetComponent<Animator>().SetBool("charge", false);
                                        companion.GetChild(0).GetChild(6).gameObject.SetActive(false);
                                        companion.GetComponent<PlayerTeamScript>().SetShurikenDamage(3);
                                        companion.GetComponent<Animator>().SetBool("magicBall", false);
                                        attackAction = false;
                                    }
                                    else
                                    {
                                        if(magicKey == KeyCode.UpArrow) companion.GetChild(0).GetChild(6).GetChild(magicSpearKey + 4).GetComponent<Image>().sprite = upArrowSpritePressed;
                                        else if (magicKey == KeyCode.LeftArrow) companion.GetChild(0).GetChild(6).GetChild(magicSpearKey + 4).GetComponent<Image>().sprite = leftArrowSpritePressed;
                                        else if (magicKey == KeyCode.RightArrow) companion.GetChild(0).GetChild(6).GetChild(magicSpearKey + 4).GetComponent<Image>().sprite = rightArrowSpritePressed;
                                        else if (magicKey == KeyCode.DownArrow) companion.GetChild(0).GetChild(6).GetChild(magicSpearKey + 4).GetComponent<Image>().sprite = downArrowSpritePressed;
                                        magicSpearKey = 4;
                                        attackAction = false;
                                    }
                                }
                            }
                            if (attackFinished)
                            {
                                if(magicSpearKey != 4)
                                {
                                    BadCommand();
                                    companion.GetChild(0).GetChild(6).GetComponent<Animator>().SetBool("charge", false);
                                    companion.GetChild(0).GetChild(6).gameObject.SetActive(false);
                                    companion.GetComponent<PlayerTeamScript>().SetShurikenDamage(2);
                                    companion.GetComponent<Animator>().SetBool("magicBall", false);
                                    attackAction = false;
                                    attackFinished = false;
                                }
                                else attackFinished = false; 
                            }
                        }
                    }
                }
                //When the adventurer is talking we display the next sentece pressing X
                else if (talking)
                {
                    if (Input.GetKeyDown(KeyCode.X)) GetComponent<DialogueManager>().DisplayNextSentence();
                }
                //We check if the player presses the x button while they are trying to flee, if so we add 0.02 to the fill amount
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
                    //If the companion is dead the enemy can only attack the player
                    if (companion.GetComponent<PlayerTeamScript>().IsDead())
                    {
                        attackObjectives = new Transform[1];
                        attackObjectives[0] = player;
                        companion.GetComponent<SpriteRenderer>().color = new Color(0.2f, 0.2f, 0.2f, companion.GetComponent<SpriteRenderer>().color.a);
                        enemy1.GetComponent<EnemyTeamScript>().Attack(attackObjectives);
                        enemy1Turn = false;
                    }
                    else
                    {
                        //If the wizard is not using the barrier the enemy will attack the team mate in the first position 3/4 times and 1/4 times the second one will be attacked
                        if (!taunting)
                        {
                            if ((Random.Range(0.0f, 1.0f) < 0.75f || currentData.GetComponent<CurrentDataScript>().firstAttackObjective == 1) && currentData.GetComponent<CurrentDataScript>().firstAttackObjective != 2)
                            {
                                if (firstPosPlayer)
                                {
                                    attackObjectives = new Transform[2];
                                    attackObjectives[0] = player;
                                    attackObjectives[1] = companion;
                                    companion.GetComponent<SpriteRenderer>().color = new Color(0.2f, 0.2f, 0.2f, companion.GetComponent<SpriteRenderer>().color.a);
                                    enemy1.GetComponent<EnemyTeamScript>().Attack(attackObjectives);
                                }
                                else
                                {
                                    attackObjectives = new Transform[2];
                                    attackObjectives[0] = companion;
                                    attackObjectives[1] = player;
                                    player.GetComponent<SpriteRenderer>().color = new Color(0.2f, 0.2f, 0.2f, player.GetComponent<SpriteRenderer>().color.a);
                                    enemy1.GetComponent<EnemyTeamScript>().Attack(attackObjectives);
                                }
                            }
                            else
                            {
                                if (firstPosPlayer)
                                {
                                    attackObjectives = new Transform[2];
                                    attackObjectives[0] = companion;
                                    attackObjectives[1] = player;
                                    player.GetComponent<SpriteRenderer>().color = new Color(0.2f, 0.2f, 0.2f, player.GetComponent<SpriteRenderer>().color.a);
                                    enemy1.GetComponent<EnemyTeamScript>().Attack(attackObjectives);
                                }
                                else
                                {
                                    attackObjectives = new Transform[2];
                                    attackObjectives[0] = player;
                                    attackObjectives[1] = companion;
                                    companion.GetComponent<SpriteRenderer>().color = new Color(0.2f, 0.2f, 0.2f, companion.GetComponent<SpriteRenderer>().color.a);
                                    enemy1.GetComponent<EnemyTeamScript>().Attack(attackObjectives);
                                }
                            }
                        }
                        //If the wizard is using the barrier the enemy can only attack the player
                        else
                        {
                            attackObjectives = new Transform[1];
                            attackObjectives[0] = companion;
                            player.GetComponent<SpriteRenderer>().color = new Color(0.2f, 0.2f, 0.2f, player.GetComponent<SpriteRenderer>().color.a);
                            enemy1.GetComponent<EnemyTeamScript>().Attack(attackObjectives);
                        }
                        enemy1Turn = false;
                    }                    
                }
                //If the first enemy isnt alive the next enemy will attack
                else
                {
                    enemy1Turn = false;
                    if (enemyNumber > 1)
                    {
                        NextEnemy(1);
                    }
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
                        if (currentData.GetComponent<CurrentDataScript>().tutorialState == 1)
                        {
                            Time.timeScale = 1.0f;
                            GetComponent<DialogueManager>().DisplayNextSentence();
                        }
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
                        if (companion.GetComponent<PlayerTeamScript>().IsDead())
                        {
                            attackObjectives = new Transform[1];
                            attackObjectives[0] = player;
                            companion.GetComponent<SpriteRenderer>().color = new Color(0.2f, 0.2f, 0.2f, companion.GetComponent<SpriteRenderer>().color.a);
                            enemy2.GetComponent<EnemyTeamScript>().Attack(attackObjectives);
                            enemy2Turn = false;
                        }
                        else
                        {
                            if (!taunting)
                            {
                                if (Random.Range(0.0f, 1.0f) < 0.75f)
                                {
                                    if (firstPosPlayer)
                                    {
                                        attackObjectives = new Transform[2];
                                        attackObjectives[0] = player;
                                        attackObjectives[1] = companion;
                                        companion.GetComponent<SpriteRenderer>().color = new Color(0.2f, 0.2f, 0.2f, companion.GetComponent<SpriteRenderer>().color.a);
                                        enemy2.GetComponent<EnemyTeamScript>().Attack(attackObjectives);
                                    }
                                    else
                                    {
                                        attackObjectives = new Transform[2];
                                        attackObjectives[0] = companion;
                                        attackObjectives[1] = player;
                                        player.GetComponent<SpriteRenderer>().color = new Color(0.2f, 0.2f, 0.2f, player.GetComponent<SpriteRenderer>().color.a);
                                        enemy2.GetComponent<EnemyTeamScript>().Attack(attackObjectives);
                                    }
                                }
                                else
                                {
                                    if (firstPosPlayer)
                                    {
                                        attackObjectives = new Transform[2];
                                        attackObjectives[0] = companion;
                                        attackObjectives[1] = player;
                                        player.GetComponent<SpriteRenderer>().color = new Color(0.2f, 0.2f, 0.2f, player.GetComponent<SpriteRenderer>().color.a);
                                        enemy2.GetComponent<EnemyTeamScript>().Attack(attackObjectives);
                                    }
                                    else
                                    {
                                        attackObjectives = new Transform[2];
                                        attackObjectives[0] = player;
                                        attackObjectives[1] = companion;
                                        companion.GetComponent<SpriteRenderer>().color = new Color(0.2f, 0.2f, 0.2f, companion.GetComponent<SpriteRenderer>().color.a);
                                        enemy2.GetComponent<EnemyTeamScript>().Attack(attackObjectives);
                                    }
                                }
                            }
                            else
                            {
                                attackObjectives = new Transform[1];
                                attackObjectives[0] = companion;
                                player.GetComponent<SpriteRenderer>().color = new Color(0.2f, 0.2f, 0.2f, player.GetComponent<SpriteRenderer>().color.a);
                                enemy2.GetComponent<EnemyTeamScript>().Attack(attackObjectives);
                            }
                            enemy2Turn = false;
                        }
                    }
                    else
                    {
                        enemy2Turn = false;
                        if (enemyNumber > 2)
                        {
                            NextEnemy(2);
                        }
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
                        if (companion.GetComponent<PlayerTeamScript>().IsDead())
                        {
                            attackObjectives = new Transform[1];
                            attackObjectives[0] = player;
                            companion.GetComponent<SpriteRenderer>().color = new Color(0.2f, 0.2f, 0.2f, companion.GetComponent<SpriteRenderer>().color.a);
                            enemy3.GetComponent<EnemyTeamScript>().Attack(attackObjectives);
                            enemy3Turn = false;
                        }
                        else
                        {
                            if (!taunting)
                            {
                                if (Random.Range(0.0f, 1.0f) < 0.75f)
                                {
                                    if (firstPosPlayer)
                                    {
                                        attackObjectives = new Transform[2];
                                        attackObjectives[0] = player;
                                        attackObjectives[1] = companion;
                                        companion.GetComponent<SpriteRenderer>().color = new Color(0.2f, 0.2f, 0.2f, companion.GetComponent<SpriteRenderer>().color.a);
                                        enemy3.GetComponent<EnemyTeamScript>().Attack(attackObjectives);
                                    }
                                    else
                                    {
                                        attackObjectives = new Transform[2];
                                        attackObjectives[0] = companion;
                                        attackObjectives[1] = player;
                                        player.GetComponent<SpriteRenderer>().color = new Color(0.2f, 0.2f, 0.2f, player.GetComponent<SpriteRenderer>().color.a);
                                        enemy3.GetComponent<EnemyTeamScript>().Attack(attackObjectives);
                                    }
                                }
                                else
                                {
                                    if (firstPosPlayer)
                                    {
                                        attackObjectives = new Transform[2];
                                        attackObjectives[0] = companion;
                                        attackObjectives[1] = player;
                                        player.GetComponent<SpriteRenderer>().color = new Color(0.2f, 0.2f, 0.2f, player.GetComponent<SpriteRenderer>().color.a);
                                        enemy3.GetComponent<EnemyTeamScript>().Attack(attackObjectives);
                                    }
                                    else
                                    {
                                        attackObjectives = new Transform[2];
                                        attackObjectives[0] = player;
                                        attackObjectives[1] = companion;
                                        companion.GetComponent<SpriteRenderer>().color = new Color(0.2f, 0.2f, 0.2f, companion.GetComponent<SpriteRenderer>().color.a);
                                        enemy3.GetComponent<EnemyTeamScript>().Attack(attackObjectives);
                                    }
                                }
                            }
                            else
                            {
                                attackObjectives = new Transform[1];
                                attackObjectives[0] = companion;
                                player.GetComponent<SpriteRenderer>().color = new Color(0.2f, 0.2f, 0.2f, player.GetComponent<SpriteRenderer>().color.a);
                                enemy3.GetComponent<EnemyTeamScript>().Attack(attackObjectives);
                            }
                            enemy3Turn = false;
                        }
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
                        if (companion.GetComponent<PlayerTeamScript>().IsDead())
                        {
                            attackObjectives = new Transform[1];
                            attackObjectives[0] = player;
                            companion.GetComponent<SpriteRenderer>().color = new Color(0.2f, 0.2f, 0.2f, companion.GetComponent<SpriteRenderer>().color.a);
                            enemy4.GetComponent<EnemyTeamScript>().Attack(attackObjectives);
                            enemy4Turn = false;
                        }
                        else
                        {
                            if (!taunting)
                            {
                                if (Random.Range(0.0f, 1.0f) < 0.75f)
                                {
                                    if (firstPosPlayer)
                                    {
                                        attackObjectives = new Transform[2];
                                        attackObjectives[0] = player;
                                        attackObjectives[1] = companion;
                                        companion.GetComponent<SpriteRenderer>().color = new Color(0.2f, 0.2f, 0.2f, companion.GetComponent<SpriteRenderer>().color.a);
                                        enemy4.GetComponent<EnemyTeamScript>().Attack(attackObjectives);
                                    }
                                    else
                                    {
                                        attackObjectives = new Transform[2];
                                        attackObjectives[0] = companion;
                                        attackObjectives[1] = player;
                                        player.GetComponent<SpriteRenderer>().color = new Color(0.2f, 0.2f, 0.2f, player.GetComponent<SpriteRenderer>().color.a);
                                        enemy4.GetComponent<EnemyTeamScript>().Attack(attackObjectives);
                                    }
                                }
                                else
                                {
                                    if (firstPosPlayer)
                                    {
                                        attackObjectives = new Transform[2];
                                        attackObjectives[0] = companion;
                                        attackObjectives[1] = player;
                                        player.GetComponent<SpriteRenderer>().color = new Color(0.2f, 0.2f, 0.2f, player.GetComponent<SpriteRenderer>().color.a);
                                        enemy4.GetComponent<EnemyTeamScript>().Attack(attackObjectives);
                                    }
                                    else
                                    {
                                        attackObjectives = new Transform[2];
                                        attackObjectives[0] = player;
                                        attackObjectives[1] = companion;
                                        companion.GetComponent<SpriteRenderer>().color = new Color(0.2f, 0.2f, 0.2f, companion.GetComponent<SpriteRenderer>().color.a);
                                        enemy4.GetComponent<EnemyTeamScript>().Attack(attackObjectives);
                                    }
                                }
                            }
                            else
                            {
                                attackObjectives = new Transform[1];
                                attackObjectives[0] = companion;
                                player.GetComponent<SpriteRenderer>().color = new Color(0.2f, 0.2f, 0.2f, player.GetComponent<SpriteRenderer>().color.a);
                                enemy4.GetComponent<EnemyTeamScript>().Attack(attackObjectives);
                            }
                            enemy4Turn = false;
                        }
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
        //When all the enemies are dead and the boss has ended the dieing animation the battle ends
        if (bossDieAnimationEnded && allEnemiesDead)
        {
            bossDieAnimationEnded = false;
            if (currentFightXP == 0)
            {
                currentFightXP = 1;
                ShowCurrentXP();
            }
            player.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, player.GetComponent<SpriteRenderer>().color.a);
            companion.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, companion.GetComponent<SpriteRenderer>().color.a);
            canvas.GetComponent<Animator>().SetBool("Hide", false);
            mainCamera.GetComponent<CameraScript>().ChangeCameraState(1);
            ResetXP();
            victoryXP.transform.GetChild(18).GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, 0.4f);
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
            if (!companion.GetComponent<PlayerTeamScript>().IsDead()) companion.GetComponent<Animator>().SetTrigger("Victory");
        }
        //When the victory is achieved
        if (victory)
        {
            //We save the xp and activate the lvl up menu when the camera returns from the victory position, only when the player levels up.
            if (!lvlUpMenu.activeSelf && Input.GetKeyDown(KeyCode.X)) StartCoroutine(SaveXP());
            if (!lvlUpMenu.activeSelf && mainCamera.GetComponent<CameraScript>().GetCameraState() == 0) lvlUpMenu.SetActive(true);
            if (lvlUpMenu.activeSelf && lvlUpSelected != -2)
            {
                if (Input.GetKeyDown(KeyCode.Space) && lvlUpSelected> -1) LvlUpPlayer(lvlUpSelected);
                else if (Input.GetKeyDown(KeyCode.RightArrow) && lvlUpSelected != 2)
                {
                    actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = new Vector4(actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color.r, actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color.g, actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color.b, 1.0f);
                    lvlUpMenu.GetComponent<Animator>().SetTrigger("Right");
                    if (lvlUpSelected == -1) actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_lvlup_hp");
                    else if (lvlUpSelected == 0) actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_lvlup_lp");
                    else if (lvlUpSelected == 1) actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_lvlup_gp");
                }
                else if (Input.GetKeyDown(KeyCode.LeftArrow) && lvlUpSelected != 0)
                {
                    actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = new Vector4(actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color.r, actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color.g, actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color.b, 1.0f);
                    lvlUpMenu.GetComponent<Animator>().SetTrigger("Left");
                    if (lvlUpSelected == -1) actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_lvlup_hp");
                    else if (lvlUpSelected == 1) actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_lvlup_lp");
                    else if (lvlUpSelected == 2) actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_lvlup_gp");
                }
            }
        }
    }

    private void FixedUpdate()
    {
        //The player light shuriken attack
        if (playerTurn && finalAttack && attackType == 1 && usingStyle == 1)
        {
            //We decrease slowly the fill amount only if it hasnt been filled yet
            if (Time.fixedTime - shurikenTime < 2.5f)
            {
                if (player.transform.GetChild(0).transform.GetChild(3).transform.GetChild(1).GetComponent<Image>().fillAmount < 1.0f)
                {
                    player.transform.GetChild(0).transform.GetChild(3).transform.GetChild(1).GetComponent<Image>().fillAmount -= 0.002f;
                    player.transform.GetChild(2).GetComponent<Light>().intensity = player.transform.GetChild(0).transform.GetChild(3).transform.GetChild(1).GetComponent<Image>().fillAmount * 4.0f;
                }
            }
            //We check if the player has correctly filled the bar
            else if (player.transform.GetChild(0).transform.GetChild(3).transform.GetChild(1).GetComponent<Image>().fillAmount < 1.0f)
            {
                BadCommand();
                finalAttack = false;
                player.transform.GetChild(0).transform.GetChild(3).transform.GetChild(2).GetComponent<Image>().sprite = emptyIcon;
                player.GetChild(0).transform.GetChild(3).gameObject.SetActive(false);
                player.transform.GetChild(0).transform.GetChild(3).transform.GetChild(1).GetComponent<Image>().fillAmount = 0.0f;
                player.GetComponent<PlayerTeamScript>().SetShurikenDamage(1);
                player.GetComponent<Animator>().SetBool("isSpinning", false);
            }
            else if (player.transform.GetChild(0).transform.GetChild(3).transform.GetChild(1).GetComponent<Image>().fillAmount >= 1.0f)
            {
                GoodCommand(true,1);
                finalAttack = false;
                player.transform.GetChild(0).transform.GetChild(3).transform.GetChild(2).GetComponent<Image>().sprite = emptyIcon;
                player.GetChild(0).transform.GetChild(3).gameObject.SetActive(false);
                player.transform.GetChild(0).transform.GetChild(3).transform.GetChild(1).GetComponent<Image>().fillAmount = 0.0f;
                player.GetComponent<PlayerTeamScript>().SetShurikenDamage(2);
                player.GetComponent<Animator>().SetBool("isSpinning", false);
            }
        }
        //The player fire shuriken attack
        if (playerTurn && finalAttack && attackType == 1 && usingStyle == 2)
        {
            //We decrease slowly the fill amount only if it hasnt been filled yet
            if (Time.fixedTime - shurikenTime < 2.5f)
            {
                if (player.transform.GetChild(0).transform.GetChild(4).transform.GetChild(1).GetComponent<Image>().fillAmount < 1.0f)
                {
                    player.transform.GetChild(0).transform.GetChild(4).transform.GetChild(1).GetComponent<Image>().fillAmount -= 0.002f;
                    player.GetComponent<Animator>().SetFloat("attackSpeed", player.transform.GetChild(0).transform.GetChild(4).transform.GetChild(1).GetComponent<Image>().fillAmount * 2.0f + 0.5f);
                    player.transform.GetChild(2).GetComponent<Light>().intensity = player.transform.GetChild(0).transform.GetChild(4).transform.GetChild(1).GetComponent<Image>().fillAmount * 4.0f;
                }
            }
            //We check if the player has correctly filled the bar
            else if (player.transform.GetChild(0).transform.GetChild(4).transform.GetChild(1).GetComponent<Image>().fillAmount < 1.0f)
            {
                BadCommand();
                finalAttack = false;
                player.GetComponent<Animator>().SetFloat("attackSpeed", 1.0f);
                player.transform.GetChild(0).transform.GetChild(4).transform.GetChild(2).GetComponent<Image>().sprite = emptyIcon;
                player.GetChild(0).transform.GetChild(4).gameObject.SetActive(false);
                player.transform.GetChild(0).transform.GetChild(4).transform.GetChild(1).GetComponent<Image>().fillAmount = 0.0f;
                player.GetComponent<PlayerTeamScript>().SetShurikenDamage(1);
                player.GetComponent<Animator>().SetBool("isSpinning", false);
            }
            else if (player.transform.GetChild(0).transform.GetChild(4).transform.GetChild(1).GetComponent<Image>().fillAmount >= 1.0f)
            {
                GoodCommand(true,1);
                finalAttack = false;
                player.GetComponent<Animator>().SetFloat("attackSpeed", 1.0f);
                player.transform.GetChild(0).transform.GetChild(4).transform.GetChild(2).GetComponent<Image>().sprite = emptyIcon;
                player.GetChild(0).transform.GetChild(4).gameObject.SetActive(false);
                player.transform.GetChild(0).transform.GetChild(4).transform.GetChild(1).GetComponent<Image>().fillAmount = 0.0f;
                player.GetComponent<PlayerTeamScript>().SetShurikenDamage(2);
                player.GetComponent<Animator>().SetBool("isSpinning", false);
            }
        }
        //We change the position of the two active party members
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
            //Soul music attack
            if (soulMusic > 0 && !failMusic)
            {
                //We fill the bar depending on the soul music level
                if (soulMusicFilling) player.GetChild(0).transform.GetChild(7).transform.GetChild(1).GetComponent<Image>().fillAmount += 0.0005f + 0.0005f * soulMusic;
                //We decrease the fill to return to the starting position
                else player.GetChild(0).transform.GetChild(7).transform.GetChild(1).GetComponent<Image>().fillAmount -= 0.015f;
            }
            //Soul Regeneration attack
            if (soulRegen)
            {
                //We increase the ring speed
                soulRegenRingSpeed += 0.00005f;
                soulRegenGreenSpeed += 0.00005f;
                //We move the green soul using the arrows
                if (soulRegenMovUp && greenSoul.GetComponent<RectTransform>().anchoredPosition.y < 2.0f) greenSoul.GetComponent<RectTransform>().anchoredPosition = new Vector2(greenSoul.GetComponent<RectTransform>().anchoredPosition.x, greenSoul.GetComponent<RectTransform>().anchoredPosition.y + soulRegenGreenSpeed);
                if (soulRegenMovLeft && greenSoul.GetComponent<RectTransform>().anchoredPosition.x > -5.45f) greenSoul.GetComponent<RectTransform>().anchoredPosition = new Vector2(greenSoul.GetComponent<RectTransform>().anchoredPosition.x - soulRegenGreenSpeed, greenSoul.GetComponent<RectTransform>().anchoredPosition.y);
                if (soulRegenMovRight && greenSoul.GetComponent<RectTransform>().anchoredPosition.x < 5.45f) greenSoul.GetComponent<RectTransform>().anchoredPosition = new Vector2(greenSoul.GetComponent<RectTransform>().anchoredPosition.x + soulRegenGreenSpeed, greenSoul.GetComponent<RectTransform>().anchoredPosition.y);
                if (soulRegenMovDown && greenSoul.GetComponent<RectTransform>().anchoredPosition.y > -1.8f) greenSoul.GetComponent<RectTransform>().anchoredPosition = new Vector2(greenSoul.GetComponent<RectTransform>().anchoredPosition.x, greenSoul.GetComponent<RectTransform>().anchoredPosition.y - soulRegenGreenSpeed);
                //We move the rings depending on the ring speed
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
            //Soul lightning attack
            if (soulLightning)
            {
                //We move the yellow soul to the right and when it arrives to the end it returns to the starting pos
                if (yellowSoul.position.x < 7.0f && yellowSoulRight) yellowSoul.position = new Vector3(yellowSoul.position.x + 0.05f, yellowSoul.position.y, yellowSoul.position.z);
                else if (yellowSoul.position.x >= 7.0f && yellowSoulRight) yellowSoulRight = false;
                else if (yellowSoul.position.x > player.position.x && !yellowSoulRight) yellowSoul.position = new Vector3(yellowSoul.position.x - 0.05f, yellowSoul.position.y, yellowSoul.position.z);
                else EndLightningAttack();
            }
            //Soul lifesteal attack
            if (soulLifesteal)
            {
                //We move the jar using the arrows
                if (jarMovUp && jar.GetComponent<RectTransform>().anchoredPosition.y < 2.0f) jar.GetComponent<RectTransform>().anchoredPosition = new Vector2(jar.GetComponent<RectTransform>().anchoredPosition.x, jar.GetComponent<RectTransform>().anchoredPosition.y + 0.09f);
                if (jarMovLeft && jar.GetComponent<RectTransform>().anchoredPosition.x > -5.45f) jar.GetComponent<RectTransform>().anchoredPosition = new Vector2(jar.GetComponent<RectTransform>().anchoredPosition.x - 0.09f, jar.GetComponent<RectTransform>().anchoredPosition.y);
                if (jarMovRight && jar.GetComponent<RectTransform>().anchoredPosition.x < 5.45f) jar.GetComponent<RectTransform>().anchoredPosition = new Vector2(jar.GetComponent<RectTransform>().anchoredPosition.x + 0.09f, jar.GetComponent<RectTransform>().anchoredPosition.y);
                if (jarMovDown && jar.GetComponent<RectTransform>().anchoredPosition.y > -1.70f) jar.GetComponent<RectTransform>().anchoredPosition = new Vector2(jar.GetComponent<RectTransform>().anchoredPosition.x, jar.GetComponent<RectTransform>().anchoredPosition.y - 0.09f);
                //We change the red soul positions
                if (redSoul1 != null) redSoul1.GetComponent<RectTransform>().anchoredPosition = new Vector2(redSoul1.GetComponent<RectTransform>().anchoredPosition.x, redSoul1.GetComponent<RectTransform>().anchoredPosition.y - 0.045f);
                if (redSoul2 != null) redSoul2.GetComponent<RectTransform>().anchoredPosition = new Vector2(redSoul2.GetComponent<RectTransform>().anchoredPosition.x, redSoul2.GetComponent<RectTransform>().anchoredPosition.y - 0.045f);
                if (redSoul3 != null) redSoul3.GetComponent<RectTransform>().anchoredPosition = new Vector2(redSoul3.GetComponent<RectTransform>().anchoredPosition.x, redSoul3.GetComponent<RectTransform>().anchoredPosition.y - 0.045f);
                if (redSoul4 != null) redSoul4.GetComponent<RectTransform>().anchoredPosition = new Vector2(redSoul4.GetComponent<RectTransform>().anchoredPosition.x, redSoul4.GetComponent<RectTransform>().anchoredPosition.y - 0.045f);
                if (redSoul5 != null) redSoul5.GetComponent<RectTransform>().anchoredPosition = new Vector2(redSoul5.GetComponent<RectTransform>().anchoredPosition.x, redSoul5.GetComponent<RectTransform>().anchoredPosition.y - 0.045f);
                if (redSoul6 != null) redSoul6.GetComponent<RectTransform>().anchoredPosition = new Vector2(redSoul6.GetComponent<RectTransform>().anchoredPosition.x, redSoul6.GetComponent<RectTransform>().anchoredPosition.y - 0.045f);
                if (redSoul7 != null) redSoul7.GetComponent<RectTransform>().anchoredPosition = new Vector2(redSoul7.GetComponent<RectTransform>().anchoredPosition.x, redSoul7.GetComponent<RectTransform>().anchoredPosition.y - 0.045f);
                if (redSoul8 != null) redSoul8.GetComponent<RectTransform>().anchoredPosition = new Vector2(redSoul8.GetComponent<RectTransform>().anchoredPosition.x, redSoul8.GetComponent<RectTransform>().anchoredPosition.y - 0.045f);
                if (redSoul9 != null) redSoul9.GetComponent<RectTransform>().anchoredPosition = new Vector2(redSoul9.GetComponent<RectTransform>().anchoredPosition.x, redSoul9.GetComponent<RectTransform>().anchoredPosition.y - 0.045f);
                if (redSoul10 != null) redSoul10.GetComponent<RectTransform>().anchoredPosition = new Vector2(redSoul10.GetComponent<RectTransform>().anchoredPosition.x, redSoul10.GetComponent<RectTransform>().anchoredPosition.y - 0.045f);
                //When all the red souls are collected or despawned the attack ends
                if (redSoul1 == null && redSoul2 == null && redSoul2 == null && redSoul3 == null && redSoul4 == null && redSoul5 == null && redSoul6 == null && redSoul7 == null && redSoul8 == null && redSoul9 == null && redSoul10 == null) EndLifestealAttack();
            }
            //The soul disappear attack
            if (soulDisappear)
            {
                //We move the soul using the arrows
                if (blueSoulMovUp && blueSoul.GetComponent<RectTransform>().anchoredPosition.y < 2.0f) blueSoul.GetComponent<RectTransform>().anchoredPosition = new Vector2(blueSoul.GetComponent<RectTransform>().anchoredPosition.x, blueSoul.GetComponent<RectTransform>().anchoredPosition.y + 0.075f);
                if (blueSoulMovLeft && blueSoul.GetComponent<RectTransform>().anchoredPosition.x > -5.45f) blueSoul.GetComponent<RectTransform>().anchoredPosition = new Vector2(blueSoul.GetComponent<RectTransform>().anchoredPosition.x - 0.075f, blueSoul.GetComponent<RectTransform>().anchoredPosition.y);
                if (blueSoulMovRight && blueSoul.GetComponent<RectTransform>().anchoredPosition.x < 5.45f) blueSoul.GetComponent<RectTransform>().anchoredPosition = new Vector2(blueSoul.GetComponent<RectTransform>().anchoredPosition.x + 0.075f, blueSoul.GetComponent<RectTransform>().anchoredPosition.y);
                if (blueSoulMovDown && blueSoul.GetComponent<RectTransform>().anchoredPosition.y > -2.10f) blueSoul.GetComponent<RectTransform>().anchoredPosition = new Vector2(blueSoul.GetComponent<RectTransform>().anchoredPosition.x, blueSoul.GetComponent<RectTransform>().anchoredPosition.y - 0.075f);
                //We move the walls to the left
                wall1.GetComponent<RectTransform>().anchoredPosition = new Vector2(wall1.GetComponent<RectTransform>().anchoredPosition.x - 0.045f, wall1.GetComponent<RectTransform>().anchoredPosition.y);
                wall2.GetComponent<RectTransform>().anchoredPosition = new Vector2(wall2.GetComponent<RectTransform>().anchoredPosition.x - 0.045f, wall2.GetComponent<RectTransform>().anchoredPosition.y);
                wall3.GetComponent<RectTransform>().anchoredPosition = new Vector2(wall3.GetComponent<RectTransform>().anchoredPosition.x - 0.045f, wall3.GetComponent<RectTransform>().anchoredPosition.y);
                wall4.GetComponent<RectTransform>().anchoredPosition = new Vector2(wall4.GetComponent<RectTransform>().anchoredPosition.x - 0.045f, wall4.GetComponent<RectTransform>().anchoredPosition.y);
                wall5.GetComponent<RectTransform>().anchoredPosition = new Vector2(wall5.GetComponent<RectTransform>().anchoredPosition.x - 0.045f, wall5.GetComponent<RectTransform>().anchoredPosition.y);
                //We decrease the soul alpha, if it arrives to 0.05 the attack ends
                if (blueSoul.GetComponent<Image>().color.a > 0.05) blueSoul.GetComponent<Image>().color = new Color(blueSoul.GetComponent<Image>().color.r, blueSoul.GetComponent<Image>().color.g, blueSoul.GetComponent<Image>().color.b, blueSoul.GetComponent<Image>().color.a - 0.0006f);
                else
                {
                    GoodCommand(true,1);
                    EndDisappearAttack();
                }
            }
            //The soul light up attack
            if (soulLightUp)
            {
                //We sacle the fog to the start scale
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
                    //When the time ends the attack is finished
                    if ((Time.fixedTime - lightUpTime) > 10.0f) EndLightUpAttack();
                    //If the fog scale is bigger than the min scale the scale decreases slowly
                    if (fog.GetComponent<RectTransform>().localScale.x >= minFogScale) fog.GetComponent<RectTransform>().localScale = new Vector3(fog.GetComponent<RectTransform>().localScale.x - 0.004f, fog.GetComponent<RectTransform>().localScale.y - 0.004f, fog.GetComponent<RectTransform>().localScale.z);
                    //If it is smaller it increases slowly
                    else fog.GetComponent<RectTransform>().localScale = new Vector3(fog.GetComponent<RectTransform>().localScale.x + 0.004f, fog.GetComponent<RectTransform>().localScale.y + 0.004f, fog.GetComponent<RectTransform>().localScale.z);
                    //We move the magenta soul using the arrows
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
                    if (magentaSoulMovDown && magentaSoul.GetComponent<RectTransform>().anchoredPosition.y > -1.9f)
                    {
                        magentaSoul.GetComponent<RectTransform>().anchoredPosition = new Vector2(magentaSoul.GetComponent<RectTransform>().anchoredPosition.x, magentaSoul.GetComponent<RectTransform>().anchoredPosition.y - 0.05f);
                        fog.GetComponent<RectTransform>().anchoredPosition = new Vector2(fog.GetComponent<RectTransform>().anchoredPosition.x, fog.GetComponent<RectTransform>().anchoredPosition.y - 0.05f);
                    }
                }
            }
        }
        if (companionTurn && finalAttack)
        { 
            //Adventurer
            if(currentCompanion == 0)
            {
                //BK-47
                if (usingStyle == 4)
                {
                    //We aim up and down slowly
                    if (aimRotation < 40.0f && aimUp)
                    {
                        aimRotation += 0.5f;
                        companion.GetChild(0).GetChild(4).GetChild(0).GetComponent<RectTransform>().rotation = Quaternion.Euler(0.0f, 0.0f, aimRotation);
                    }
                    else if (aimRotation >= 40.0f && aimUp)
                    {
                        aimUp = false;
                    }
                    else if (aimRotation > -10.0f && !aimUp)
                    {
                        aimRotation -= 0.5f;
                        companion.GetChild(0).GetChild(4).GetChild(0).GetComponent<RectTransform>().rotation = Quaternion.Euler(0.0f, 0.0f, aimRotation);
                    }
                    else if (aimRotation <= -10.0f && !aimUp)
                    {
                        aimUp = true;
                    }
                }
            }
            //Adventurer
            else if(currentCompanion == 1)
            {
                //Pulsing magic
                if(usingStyle == 2)
                {
                    //We decrease the fill amount until it fills. When it fills we activate an animation.
                    if ((Time.fixedTime - shurikenTime) < 5.0f)
                    {
                        if (companion.transform.GetChild(0).transform.GetChild(5).transform.GetChild(1).GetComponent<Image>().fillAmount < 1.0f) companion.transform.GetChild(0).transform.GetChild(5).transform.GetChild(1).GetComponent<Image>().fillAmount -= 0.002f;
                        else companion.transform.GetChild(0).transform.GetChild(5).transform.GetChild(1).GetComponent<Animator>().SetBool("pulse", true);
                    }
                    //We check if the player fills the bar correctly
                    else if (companion.transform.GetChild(0).transform.GetChild(5).transform.GetChild(1).GetComponent<Image>().fillAmount < 1.0f)
                    {
                        BadCommand();
                        finalAttack = false;
                        companion.transform.GetChild(0).transform.GetChild(5).transform.GetChild(1).GetComponent<Animator>().SetBool("pulse", false);
                        companion.transform.GetChild(0).transform.GetChild(5).transform.GetChild(1).GetComponent<Image>().fillAmount = 0.0f;
                        companion.transform.GetChild(0).transform.GetChild(5).gameObject.SetActive(false);
                        magicPulse = Instantiate(magicPulsePrefab, companion.transform.position, Quaternion.identity);
                        actionInstructions.SetActive(false);
                        magicPulse.transform.GetComponent<MagicPulse>().Create(2 + currentData.GetComponent<CurrentDataScript>().wizardLvl - 1, companion);
                    }
                    else if (companion.transform.GetChild(0).transform.GetChild(5).transform.GetChild(1).GetComponent<Image>().fillAmount >= 1.0f)
                    {
                        GoodCommand(true,1);
                        finalAttack = false;
                        companion.transform.GetChild(0).transform.GetChild(5).transform.GetChild(1).GetComponent<Animator>().SetBool("pulse", false);
                        companion.transform.GetChild(0).transform.GetChild(5).transform.GetChild(1).GetComponent<Image>().fillAmount = 0.0f;
                        companion.transform.GetChild(0).transform.GetChild(5).gameObject.SetActive(false);
                        magicPulse = Instantiate(magicPulsePrefab, new Vector3(companion.transform.position.x + 1.0104f, companion.transform.position.y + 0.3781f, companion.transform.position.z), Quaternion.identity);
                        actionInstructions.SetActive(false);
                        magicPulse.transform.GetComponent<MagicPulse>().Create(4 + currentData.GetComponent<CurrentDataScript>().wizardLvl - 1, companion);
                    }
                }
                //Explode
                else if (usingStyle == 4)
                {                    
                    if((Time.fixedTime - shurikenTime) < 10.0f)
                    {
                        //We fill the bar if the player presses or releases the X button when it is said so
                        if((Input.GetKey(KeyCode.X) && attackAction) || (!Input.GetKey(KeyCode.X) && !attackAction)) companion.GetChild(0).GetChild(7).GetChild(6).GetComponent<Image>().fillAmount += 0.004f; 
                        //If the command is incorrect we decrease the bar fill
                        else companion.GetChild(0).GetChild(7).GetChild(6).GetComponent<Image>().fillAmount -= 0.003f; 
                        //We save the damage depending on the bar fill
                        if (companion.GetChild(0).GetChild(7).GetChild(6).GetComponent<Image>().fillAmount < 0.5f) companion.GetChild(0).GetChild(7).GetChild(8).GetChild(0).GetComponent<Text>().text = 3.ToString();
                        else if(companion.GetChild(0).GetChild(7).GetChild(6).GetComponent<Image>().fillAmount < 0.678f) companion.GetChild(0).GetChild(7).GetChild(8).GetChild(0).GetComponent<Text>().text = 4.ToString();
                        else if (companion.GetChild(0).GetChild(7).GetChild(6).GetComponent<Image>().fillAmount < 0.81f) companion.GetChild(0).GetChild(7).GetChild(8).GetChild(0).GetComponent<Text>().text = 5.ToString();
                        else if (companion.GetChild(0).GetChild(7).GetChild(6).GetComponent<Image>().fillAmount < 0.9f) companion.GetChild(0).GetChild(7).GetChild(8).GetChild(0).GetComponent<Text>().text = 6.ToString();
                        else if (companion.GetChild(0).GetChild(7).GetChild(6).GetComponent<Image>().fillAmount < 0.966f) companion.GetChild(0).GetChild(7).GetChild(8).GetChild(0).GetComponent<Text>().text = 7.ToString();
                        else companion.GetChild(0).GetChild(7).GetChild(8).GetChild(0).GetComponent<Text>().text = 8.ToString();
                    }
                    //When the time arrives 10 we end the attack
                    else
                    {
                        actionInstructions.SetActive(false);
                        finalAttack = false;
                        companion.GetChild(0).GetChild(7).GetChild(6).GetComponent<Image>().fillAmount = 0.0f;
                        companion.GetComponent<PlayerTeamScript>().EndExplosion(int.Parse(companion.GetChild(0).GetChild(7).GetChild(8).GetChild(0).GetComponent<Text>().text));
                    }
                }
            }
            
        }
        //Flee action
        if (fleeing)
        {
            if ((Time.fixedTime - fleeTime) < 10.0f)
            {
                //We decrease the bar fill if it is not completely filled
                if (fleeAction.transform.GetChild(1).GetComponent<Image>().fillAmount != 1.0f) fleeAction.transform.GetChild(1).GetComponent<Image>().fillAmount -= 0.001f;
                //We move the little bar left and right
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
                //When the countdown ends we check if the little bar is inside the fill amount, if so the player flees. If not the players turn ends.
                actionInstructions.SetActive(false);
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
                fleeAction.transform.GetChild(1).GetComponent<Image>().fillAmount = 0.0f;
                fleeAction.gameObject.SetActive(false);
            }
        }
        //When the player flees we move the player and the companion out of the camera view and finish the battle
        else if (fled)
        {
            if(player.transform.position.x > -10.0f) player.transform.position = new Vector3(player.transform.position.x - 0.2f, player.transform.position.y, player.transform.position.z);
            if (companion.transform.position.x > -10.0f) companion.transform.position = new Vector3(companion.transform.position.x - 0.2f, companion.transform.position.y, companion.transform.position.z);
            else
            {
                fled = false;
                currentData.GetComponent<CurrentDataScript>().fled = 1;
                EndBattle(true);
            }
        }
        //When the battle ends we increase the alpha of a black image until it is completely opaque, then we load the main menu
        /*
        if (endBattle)
        {
            if(endBattleImage.GetComponent<Image>().color.a < 1.0f)
            {
                endBattleImage.GetComponent<Image>().color = new Color(endBattleImage.GetComponent<Image>().color.r, endBattleImage.GetComponent<Image>().color.g, endBattleImage.GetComponent<Image>().color.b, endBattleImage.GetComponent<Image>().color.a + 0.02f);
            }
            else
            {
                SceneManager.LoadScene(0);
            }
        }
        */
    }

    //Function to spawn the characters. 0 -> Player, 1-> companion, 2-> Enemy1, 3-> Enemy2, 4-> Enemy3, 5-> Enemy4. companion type-> 0 adventurer, 1-> wizard. enemy type -> 0 bandit, 1 evil wizard, 2 king
    public void SpawnCharacter(int battlePos, int type)
    {
        //We use this position to spawn the companion when we are changing companion
        if(battlePos == -1)
        {
            if (type == 0) companion = Instantiate(adventurerBattle, new Vector3(-9.0f, -0.713f, -2.04f), Quaternion.identity); 
            else if (type == 1) companion = Instantiate(companionWizardBattle, new Vector3(-9.0f, -0.72f, -2.04f), Quaternion.identity);
            currentCompanion = type;
            companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(7).GetComponent<Image>().color = new Vector4(companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(7).GetComponent<Image>().color.r, companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(7).GetComponent<Image>().color.g, companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(7).GetComponent<Image>().color.b, 0.0f);
            companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(8).GetComponent<Image>().color = new Vector4(companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(8).GetComponent<Image>().color.r, companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(8).GetComponent<Image>().color.g, companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(8).GetComponent<Image>().color.b, 0.0f);
            companion.GetComponent<PlayerTeamScript>().SetEnter();
        }
        //The player is the only one that can be spawned here
        if (battlePos == 0)
        {
            player = Instantiate(playerBattle, new Vector3(-5, -1, -2.05f), Quaternion.identity);
            regenerationAction = player.GetChild(0).GetChild(8).gameObject;
            lightningAction = player.GetChild(0).GetChild(9).gameObject;
            lifestealAction = player.GetChild(0).GetChild(10).gameObject;
            disappearAction = player.GetChild(0).GetChild(11).gameObject;
            lightUpAction = player.GetChild(0).GetChild(12).gameObject;
        }
        //We can spawn two different companions: the adventurer or the wizard
        else if (battlePos == 1)
        {
            currentCompanion = type;
            if(type == 0) companion = Instantiate(adventurerBattle, new Vector3(-6.4f, -0.713f, -2.04f), Quaternion.identity);
            else if(type == 1) companion = Instantiate(companionWizardBattle, new Vector3(-6.4f, -0.72f, -2.04f), Quaternion.identity);
            if (currentData.GetComponent<CurrentDataScript>().unlockedCompanions == 0) companion.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 0.0f); 
        }
        //We can spawn 7 different enemies: the bandit, the evil wizard, the king, the knight and the boss versions of the bandit, the wizard and the knight
        else if (battlePos == 2)
        {
            if (type == 0)
            {
                enemy1 = Instantiate(banditBattle, new Vector3(2.1f, -0.64f, -2.03f), Quaternion.identity);
                player.GetChild(0).GetChild(0).GetChild(0).GetComponent<RawImage>().color = new Color(1.0f, 1.0f, 1.0f, player.GetChild(0).GetChild(0).GetChild(0).GetComponent<RawImage>().color.a);
                player.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<RawImage>().color = new Color(1.0f, 1.0f, 1.0f, player.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<RawImage>().color.a);
                player.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<Text>().color = new Color(1.0f, 1.0f, 1.0f, player.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<Text>().color.a);
            }
            else if (type == 1)
            {
                if(currentData.GetComponent<CurrentDataScript>().playerFirstAttack == 1 && currentData.GetComponent<CurrentDataScript>().playerAttack == 0) enemy1 = Instantiate(wizardBattle, new Vector3(2.1f, -0.5f, -2.03f), Quaternion.identity);
                else enemy1 = Instantiate(wizardBattle, new Vector3(2.1f, 1.0f, -2.03f), Quaternion.identity);
            }
            else if (type == 2)
            {
                bossDieAnimationEnded = false;
                enemy1 = Instantiate(kingBattle, new Vector3(2.1f, -0.43f, -2.03f), Quaternion.identity);
                player.GetChild(0).GetChild(0).GetChild(0).GetComponent<RawImage>().color = new Color(1.0f, 1.0f, 1.0f, player.GetChild(0).GetChild(0).GetChild(0).GetComponent<RawImage>().color.a);
                player.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<RawImage>().color = new Color(1.0f, 1.0f, 1.0f, player.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<RawImage>().color.a);
                player.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<Text>().color = new Color(1.0f, 1.0f, 1.0f, player.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<Text>().color.a);
            }
            else if (type == 3)
            {
                enemy1 = Instantiate(knightBattle, new Vector3(2.1f, -1.034f, -2.03f), Quaternion.identity);
                player.GetChild(0).GetChild(0).GetChild(0).GetComponent<RawImage>().color = new Color(1.0f, 1.0f, 1.0f, player.GetChild(0).GetChild(0).GetChild(0).GetComponent<RawImage>().color.a);
                player.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<RawImage>().color = new Color(1.0f, 1.0f, 1.0f, player.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<RawImage>().color.a);
                player.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<Text>().color = new Color(1.0f, 1.0f, 1.0f, player.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<Text>().color.a);
                enemy1.GetComponent<EnemyTeamScript>().SetShielded(true);
            }
            else if (type == 4)
            {
                enemy1 = Instantiate(banditBossBattle, new Vector3(2.1f, -0.64f, -2.03f), Quaternion.identity);
                player.GetChild(0).GetChild(0).GetChild(0).GetComponent<RawImage>().color = new Color(1.0f, 1.0f, 1.0f, player.GetChild(0).GetChild(0).GetChild(0).GetComponent<RawImage>().color.a);
                player.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<RawImage>().color = new Color(1.0f, 1.0f, 1.0f, player.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<RawImage>().color.a);
                player.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<Text>().color = new Color(1.0f, 1.0f, 1.0f, player.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<Text>().color.a);
            }
            else if (type == 5)
            {
                if (currentData.GetComponent<CurrentDataScript>().playerFirstAttack == 1 && currentData.GetComponent<CurrentDataScript>().playerAttack == 0) enemy1 = Instantiate(wizardBossBattle, new Vector3(2.1f, -0.5f, -2.03f), Quaternion.identity);
                else enemy1 = Instantiate(wizardBossBattle, new Vector3(2.1f, 1.0f, -2.03f), Quaternion.identity);
            }
            else if (type == 6)
            {
                enemy1 = Instantiate(knightBossBattle, new Vector3(2.1f, -1.034f, -2.03f), Quaternion.identity);
                player.GetChild(0).GetChild(0).GetChild(0).GetComponent<RawImage>().color = new Color(1.0f, 1.0f, 1.0f, player.GetChild(0).GetChild(0).GetChild(0).GetComponent<RawImage>().color.a);
                player.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<RawImage>().color = new Color(1.0f, 1.0f, 1.0f, player.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<RawImage>().color.a);
                player.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<Text>().color = new Color(1.0f, 1.0f, 1.0f, player.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<Text>().color.a);
                enemy1.GetComponent<EnemyTeamScript>().SetShielded(true);
            }
            enemyNumber += 1;
            enemy1.GetComponent<EnemyTeamScript>().SetNumber(enemyNumber);
        }
        else if (battlePos == 3)
        {
            if (type == 0)
            {
                enemy2 = Instantiate(banditBattle, new Vector3(3.6f, -0.64f, -2.02f), Quaternion.identity); 
                player.GetChild(0).GetChild(0).GetChild(0).GetComponent<RawImage>().color = new Color(1.0f, 1.0f, 1.0f, player.GetChild(0).GetChild(0).GetChild(0).GetComponent<RawImage>().color.a);
                player.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<RawImage>().color = new Color(1.0f, 1.0f, 1.0f, player.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<RawImage>().color.a);
                player.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<Text>().color = new Color(1.0f, 1.0f, 1.0f, player.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<Text>().color.a);
            }
            else if (type == 1) enemy2 = Instantiate(wizardBattle, new Vector3(3.6f, 1.0f, -2.02f), Quaternion.identity);
            else if (type == 2)
            {
                bossDieAnimationEnded = false;
                enemy2 = Instantiate(kingBattle, new Vector3(3.6f, -0.43f, -2.02f), Quaternion.identity);
                player.GetChild(0).GetChild(0).GetChild(0).GetComponent<RawImage>().color = new Color(1.0f, 1.0f, 1.0f, player.GetChild(0).GetChild(0).GetChild(0).GetComponent<RawImage>().color.a);
                player.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<RawImage>().color = new Color(1.0f, 1.0f, 1.0f, player.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<RawImage>().color.a);
                player.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<Text>().color = new Color(1.0f, 1.0f, 1.0f, player.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<Text>().color.a);
            }
            else if (type == 3)
            {
                enemy2 = Instantiate(knightBattle, new Vector3(3.6f, -1.034f, -2.02f), Quaternion.identity);
                player.GetChild(0).GetChild(0).GetChild(0).GetComponent<RawImage>().color = new Color(1.0f, 1.0f, 1.0f, player.GetChild(0).GetChild(0).GetChild(0).GetComponent<RawImage>().color.a);
                player.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<RawImage>().color = new Color(1.0f, 1.0f, 1.0f, player.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<RawImage>().color.a);
                player.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<Text>().color = new Color(1.0f, 1.0f, 1.0f, player.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<Text>().color.a);
                enemy2.GetComponent<EnemyTeamScript>().SetShielded(true);
            }
            else if (type == 4)
            {
                enemy2 = Instantiate(banditBossBattle, new Vector3(3.6f, -1.034f, -2.02f), Quaternion.identity);
                player.GetChild(0).GetChild(0).GetChild(0).GetComponent<RawImage>().color = new Color(1.0f, 1.0f, 1.0f, player.GetChild(0).GetChild(0).GetChild(0).GetComponent<RawImage>().color.a);
                player.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<RawImage>().color = new Color(1.0f, 1.0f, 1.0f, player.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<RawImage>().color.a);
                player.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<Text>().color = new Color(1.0f, 1.0f, 1.0f, player.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<Text>().color.a);
            }
            else if (type == 5) enemy2 = Instantiate(wizardBossBattle, new Vector3(3.6f, 1.0f, -2.02f), Quaternion.identity);
            else if (type == 6)
            {
                enemy2 = Instantiate(knightBossBattle, new Vector3(3.6f, -1.034f, -2.02f), Quaternion.identity);
                player.GetChild(0).GetChild(0).GetChild(0).GetComponent<RawImage>().color = new Color(1.0f, 1.0f, 1.0f, player.GetChild(0).GetChild(0).GetChild(0).GetComponent<RawImage>().color.a);
                player.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<RawImage>().color = new Color(1.0f, 1.0f, 1.0f, player.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<RawImage>().color.a);
                player.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<Text>().color = new Color(1.0f, 1.0f, 1.0f, player.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<Text>().color.a);
                enemy2.GetComponent<EnemyTeamScript>().SetShielded(true);
            }
            enemyNumber += 1;
            enemy2.GetComponent<EnemyTeamScript>().SetNumber(enemyNumber);
        }
        else if (battlePos == 4)
        {
            if (type == 0)
            {
                enemy3 = Instantiate(banditBattle, new Vector3(5.1f, -0.64f, -2.01f), Quaternion.identity);
                player.GetChild(0).GetChild(0).GetChild(0).GetComponent<RawImage>().color = new Color(1.0f, 1.0f, 1.0f, player.GetChild(0).GetChild(0).GetChild(0).GetComponent<RawImage>().color.a);
                player.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<RawImage>().color = new Color(1.0f, 1.0f, 1.0f, player.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<RawImage>().color.a);
                player.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<Text>().color = new Color(1.0f, 1.0f, 1.0f, player.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<Text>().color.a);
            }
            else if (type == 1) enemy3 = Instantiate(wizardBattle, new Vector3(5.1f, 1.0f, -2.01f), Quaternion.identity);
            else if (type == 2)
            {
                bossDieAnimationEnded = false;
                enemy3 = Instantiate(kingBattle, new Vector3(5.1f, -0.43f, -2.01f), Quaternion.identity);
                player.GetChild(0).GetChild(0).GetChild(0).GetComponent<RawImage>().color = new Color(1.0f, 1.0f, 1.0f, player.GetChild(0).GetChild(0).GetChild(0).GetComponent<RawImage>().color.a);
                player.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<RawImage>().color = new Color(1.0f, 1.0f, 1.0f, player.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<RawImage>().color.a);
                player.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<Text>().color = new Color(1.0f, 1.0f, 1.0f, player.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<Text>().color.a);
            }
            else if (type == 3)
            {
                enemy3 = Instantiate(knightBattle, new Vector3(5.1f, -1.034f, -2.01f), Quaternion.identity);
                player.GetChild(0).GetChild(0).GetChild(0).GetComponent<RawImage>().color = new Color(1.0f, 1.0f, 1.0f, player.GetChild(0).GetChild(0).GetChild(0).GetComponent<RawImage>().color.a);
                player.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<RawImage>().color = new Color(1.0f, 1.0f, 1.0f, player.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<RawImage>().color.a);
                player.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<Text>().color = new Color(1.0f, 1.0f, 1.0f, player.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<Text>().color.a);
                enemy3.GetComponent<EnemyTeamScript>().SetShielded(true);
            }
            else if (type == 4)
            {
                enemy3 = Instantiate(banditBossBattle, new Vector3(5.1f, -0.64f, -2.01f), Quaternion.identity);
                player.GetChild(0).GetChild(0).GetChild(0).GetComponent<RawImage>().color = new Color(1.0f, 1.0f, 1.0f, player.GetChild(0).GetChild(0).GetChild(0).GetComponent<RawImage>().color.a);
                player.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<RawImage>().color = new Color(1.0f, 1.0f, 1.0f, player.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<RawImage>().color.a);
                player.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<Text>().color = new Color(1.0f, 1.0f, 1.0f, player.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<Text>().color.a);
            }
            else if (type == 5) enemy3 = Instantiate(wizardBossBattle, new Vector3(5.1f, 1.0f, -2.01f), Quaternion.identity);
            else if (type == 6)
            {
                enemy3 = Instantiate(knightBossBattle, new Vector3(5.1f, -1.034f, -2.01f), Quaternion.identity);
                player.GetChild(0).GetChild(0).GetChild(0).GetComponent<RawImage>().color = new Color(1.0f, 1.0f, 1.0f, player.GetChild(0).GetChild(0).GetChild(0).GetComponent<RawImage>().color.a);
                player.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<RawImage>().color = new Color(1.0f, 1.0f, 1.0f, player.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<RawImage>().color.a);
                player.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<Text>().color = new Color(1.0f, 1.0f, 1.0f, player.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<Text>().color.a);
                enemy3.GetComponent<EnemyTeamScript>().SetShielded(true);
            }
            enemyNumber += 1;
            enemy3.GetComponent<EnemyTeamScript>().SetNumber(enemyNumber);
        }
        else if (battlePos == 5)
        {
            if (type == 0)
            {
                enemy4 = Instantiate(banditBattle, new Vector3(6.6f, -0.64f, -2.0f), Quaternion.identity);
                player.GetChild(0).GetChild(0).GetChild(0).GetComponent<RawImage>().color = new Color(1.0f, 1.0f, 1.0f, player.GetChild(0).GetChild(0).GetChild(0).GetComponent<RawImage>().color.a);
                player.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<RawImage>().color = new Color(1.0f, 1.0f, 1.0f, player.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<RawImage>().color.a);
                player.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<Text>().color = new Color(1.0f, 1.0f, 1.0f, player.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<Text>().color.a);
            }
            else if (type == 1) enemy4 = Instantiate(wizardBattle, new Vector3(6.6f, 1.0f, -2.0f), Quaternion.identity);
            else if (type == 2)
            {
                bossDieAnimationEnded = false;
                enemy4 = Instantiate(kingBattle, new Vector3(6.6f, -0.43f, -2.0f), Quaternion.identity);
                player.GetChild(0).GetChild(0).GetChild(0).GetComponent<RawImage>().color = new Color(1.0f, 1.0f, 1.0f, player.GetChild(0).GetChild(0).GetChild(0).GetComponent<RawImage>().color.a);
                player.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<RawImage>().color = new Color(1.0f, 1.0f, 1.0f, player.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<RawImage>().color.a);
                player.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<Text>().color = new Color(1.0f, 1.0f, 1.0f, player.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<Text>().color.a);
            }
            else if (type == 3)
            {
                enemy4 = Instantiate(knightBattle, new Vector3(6.6f, -1.034f, -2.0f), Quaternion.identity);
                player.GetChild(0).GetChild(0).GetChild(0).GetComponent<RawImage>().color = new Color(1.0f, 1.0f, 1.0f, player.GetChild(0).GetChild(0).GetChild(0).GetComponent<RawImage>().color.a);
                player.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<RawImage>().color = new Color(1.0f, 1.0f, 1.0f, player.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<RawImage>().color.a);
                player.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<Text>().color = new Color(1.0f, 1.0f, 1.0f, player.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<Text>().color.a);
                enemy4.GetComponent<EnemyTeamScript>().SetShielded(true);
            }
            else if (type == 4)
            {
                enemy4 = Instantiate(banditBossBattle, new Vector3(6.6f, -0.64f, -2.0f), Quaternion.identity);
                player.GetChild(0).GetChild(0).GetChild(0).GetComponent<RawImage>().color = new Color(1.0f, 1.0f, 1.0f, player.GetChild(0).GetChild(0).GetChild(0).GetComponent<RawImage>().color.a);
                player.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<RawImage>().color = new Color(1.0f, 1.0f, 1.0f, player.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<RawImage>().color.a);
                player.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<Text>().color = new Color(1.0f, 1.0f, 1.0f, player.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<Text>().color.a);
            }
            else if (type == 5) enemy4 = Instantiate(wizardBossBattle, new Vector3(6.6f, 1.0f, -2.0f), Quaternion.identity);
            else if (type == 6)
            {
                enemy4 = Instantiate(knightBossBattle, new Vector3(6.6f, -1.034f, -2.0f), Quaternion.identity);
                player.GetChild(0).GetChild(0).GetChild(0).GetComponent<RawImage>().color = new Color(1.0f, 1.0f, 1.0f, player.GetChild(0).GetChild(0).GetChild(0).GetComponent<RawImage>().color.a);
                player.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<RawImage>().color = new Color(1.0f, 1.0f, 1.0f, player.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<RawImage>().color.a);
                player.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<Text>().color = new Color(1.0f, 1.0f, 1.0f, player.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<Text>().color.a);
                enemy4.GetComponent<EnemyTeamScript>().SetShielded(true);
            }
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
        //If we have only 1 enemy we only have two options, it is grounded or not
        if (enemyNumber == 1 && enemy1.GetComponent<EnemyTeamScript>().IsGrounded() && enemy1.GetComponent<EnemyTeamScript>().IsAlive())
        {
            grounded = new Transform[1];
            grounded[0] = enemy1;
        }
        //When we have 2 enemies there are more options
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
        //When we have 2 enemies there are even more options
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
        //When we have 2 enemies there are a lot of options
        else if (enemyNumber == 4)
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

    //Function to get all enemies. Very similar to the previous function, but now we dont have to look if the enemy is grounded or not
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
        Vector3 damagepos;
        if (objective.GetComponent<EnemyTeamScript>().IsShielded()) damage -= 2;
        if (damage < 0) damage = 0;
        if (playerTurn && player.GetComponent<PlayerTeamScript>().HasLifesteal()) player.GetComponent<PlayerTeamScript>().Heal(damage, false,false, true, true);
        if (companionTurn && companion.GetComponent<PlayerTeamScript>().HasLifesteal()) companion.GetComponent<PlayerTeamScript>().Heal(damage, false, false, true, true);
        //We instantiate the damage UI and save the damage amount
        if(objective.GetComponent<EnemyTeamScript>().enemyType != 3) damagepos = new Vector3(objective.transform.position.x - 0.25f, objective.transform.position.y + 1.0f, objective.transform.position.z);
        else damagepos = new Vector3(objective.transform.position.x - 0.8f, objective.transform.position.y + 1.4f, objective.transform.position.z);
        damageImage = Instantiate(damageUI, damagepos, Quaternion.identity, objective.transform.GetChild(0));
        damageImage.GetChild(0).GetComponent<Text>().text = damage.ToString();
        objective.transform.GetChild(0).transform.GetChild(2).GetComponent<EnemyLifeControllerScript>().DealDamage(damage);
        //if the enemy is dead and it is the last attack we play the die animation, else we play the damage animation
        if (objective.transform.GetChild(0).transform.GetChild(2).GetComponent<EnemyLifeControllerScript>().GetHealth() <= 0 && last)
        {
            objective.GetComponent<Animator>().SetBool("IsDead", true);
            objective.GetChild(0).transform.GetChild(2).gameObject.SetActive(false);
        }
        else
        {            
            if (!objective.GetComponent<EnemyTeamScript>().IsShielded() || attackType == 0)
            {
                if (objective.GetComponent<EnemyTeamScript>().IsShielded() && attackType == 0)
                {
                    objective.GetComponent<EnemyTeamScript>().SetStun(2);
                    objective.GetComponent<EnemyTeamScript>().SetShielded(false);
                }
                else
                {
                    objective.GetComponent<Animator>().SetTrigger("TakeDamage");
                }
            }
        }
    }
    //Function to know if the wizard is taunting
    public bool IsTaunting()
    {
        return taunting;
    }
    //Function to set the taunt
    public void SetTaunt(bool taunt)
    {
        taunting = taunt;
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
        if((soulRegenHeal + soulRegenLight)/5.0f == 1.0f) GoodCommand(true,1);
        else if ((soulRegenHeal + soulRegenLight) / 5.0f == 2.0f) GoodCommand(true, 2);
        else if ((soulRegenHeal + soulRegenLight) / 5.0f == 3.0f) GoodCommand(true, 3);
        else if ((soulRegenHeal + soulRegenLight) / 5.0f == 4.0f) GoodCommand(true, 4);
        else if ((soulRegenHeal + soulRegenLight) / 5.0f == 5.0f) GoodCommand(true, 5);
    }
    public void IncreaseRegenerationLight()
    {
        soulRegenLight += 1;
        if ((soulRegenHeal + soulRegenLight) / 5.0f == 1.0f) GoodCommand(true, 1);
        else if ((soulRegenHeal + soulRegenLight) / 5.0f == 2.0f) GoodCommand(true, 2);
        else if ((soulRegenHeal + soulRegenLight) / 5.0f == 3.0f) GoodCommand(true, 3);
        else if ((soulRegenHeal + soulRegenLight) / 5.0f == 4.0f) GoodCommand(true, 4);
        else if ((soulRegenHeal + soulRegenLight) / 5.0f == 5.0f) GoodCommand(true, 5);
    }

    //Functions to end the regeneration attack
    public void EndRegenerationAttack()
    {
        BadCommand();
        soulRegenMovUp = false;
        soulRegenMovLeft = false;
        soulRegenMovRight = false;
        soulRegenMovDown = false;
        soulRegenRingSpeed = 0.03f;
        soulRegenGreenSpeed = 0.075f;
        //We heal and increase light depending on the number of rings the soul has crossed
        player.GetComponent<PlayerTeamScript>().Heal(soulRegenHeal/2, true, firstPosPlayer, true, true);
        if(!companion.GetComponent<PlayerTeamScript>().IsDead()) companion.GetComponent<PlayerTeamScript>().Heal(soulRegenHeal / 2, false, !firstPosPlayer, false, true);
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
        //We set the disappear time depending on the alpha of the blue soul
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
    public void StartChangePosition(int user)
    {
        changePosAction.SetActive(false);
        //We change some animation variables depending on the movement position
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
    //Function to end the change position action
    private void EndChangePosition(int user)
    {
        //if the companion isnt dead we reactivate the change position action
        if (!companion.GetComponent<PlayerTeamScript>().IsDead())
        {
            if (currentData.GetComponent<CurrentDataScript>().unlockedCompanions < 1) changePosAction.SetActive(false);
            else changePosAction.SetActive(true);
        }
        //We put the default values of the animation variables and ensure that the team members are in the correct position.
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
            if (!companion.GetComponent<PlayerTeamScript>().IsDead())
            {
                playerTurn = true;
                playerChoosingAction = true;
                player.GetChild(0).GetChild(0).GetComponent<Animator>().SetBool("Active", true);
            }
            player.position = new Vector3(-5.0f, player.position.y, -2.05f);
            companion.position = new Vector3(-6.4f, companion.position.y, -2.04f);
        }
    }
    //A function to end players turn. User-->1 player, User-->2 companion
    public void EndPlayerTurn(int user)
    {
        //We confirm that the player and the companion are in the correct position
        player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -2.05f);
        companion.transform.position = new Vector3(companion.transform.position.x, companion.transform.position.y, -2.04f);
        //We end the attack 
        attackAction = false;
        finalAttack = false;
        //We check if the user has already copleted their turn, if so we change the user
        if (user == 1 && playerTurnCompleted) user = 2;
        if (user == 2 && companionTurnCompleted) user = 1;
        //If there are still enemies allive
        if(GetAllEnemies() != null)
        {
            //If there arent any grounded enemies we deactivate the sword attacks
            if (GetGroundEnemies() == null)
            {
                player.GetChild(0).GetChild(0).GetChild(0).GetComponent<RawImage>().color = new Color(0.4f, 0.4f, 0.4f, player.GetChild(0).GetChild(0).GetChild(0).GetComponent<RawImage>().color.a);
                player.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<RawImage>().color = new Color(0.4f, 0.4f, 0.4f, player.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<RawImage>().color.a);
                player.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<Text>().color = new Color(0.4f, 0.4f, 0.4f, player.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<Text>().color.a);
            }
            //If we don't have more items we deactivate the items
            if (currentData.GetComponent<CurrentDataScript>().itemSize() == 0)
            {
                player.GetChild(0).GetChild(0).GetChild(2).GetComponent<RawImage>().color = new Color(0.4f, 0.4f, 0.4f, player.GetChild(0).GetChild(0).GetChild(0).GetComponent<RawImage>().color.a);
                player.GetChild(0).GetChild(0).GetChild(2).GetChild(0).GetComponent<RawImage>().color = new Color(0.4f, 0.4f, 0.4f, player.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<RawImage>().color.a);
                player.GetChild(0).GetChild(0).GetChild(2).GetChild(0).GetChild(0).GetComponent<Text>().color = new Color(0.4f, 0.4f, 0.4f, player.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<Text>().color.a);
            }
            //We end the player or the companion turn if they are the users or if they are dead in case of the companion
            if (user == 1) playerTurnCompleted = true;
            if (user == 2 || companion.GetComponent<PlayerTeamScript>().IsDead()) companionTurnCompleted = true;
            //We change the UI pos
            if (playerTurn && !firstPosPlayer && attackType == 2) player.GetChild(0).transform.position = new Vector3(player.GetChild(0).transform.position.x - 1.4f, player.GetChild(0).transform.position.y, player.GetChild(0).transform.position.z);
            //If both team mates completed their turn 
            if (playerTurnCompleted && companionTurnCompleted)
            {
                if(currentData.GetComponent<CurrentDataScript>().tutorialState < 3) tutorialTurn = false;
                //We put the color back to normal
                player.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, player.GetComponent<SpriteRenderer>().color.a);
                companion.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, companion.GetComponent<SpriteRenderer>().color.a);
                //We make the buff/debuff decrease
                player.GetComponent<PlayerTeamScript>().ShowBuffDebuff();
                player.GetComponent<PlayerTeamScript>().RestBuffDebuff();
                companion.GetComponent<PlayerTeamScript>().ShowBuffDebuff();
                companion.GetComponent<PlayerTeamScript>().RestBuffDebuff();
                //We hide the canvas
                canvas.GetComponent<Animator>().SetBool("Hide", false);
                //We prepare the next player turn
                playerChoosingAction = true;
                playerTeamTurn = false;
                playerTurnCompleted = false;
                companionTurnCompleted = false;
                if (playerTurn)
                {
                    playerTurn = false;
                    companionTurn = true;
                }
                else if (companionTurn)
                {
                    playerTurn = true;
                    companionTurn = false;
                }
                //We start the enemy turn
                enemyTeamTurn = true;
                enemy1Turn = true;
            }
            //If only the player has completed their turn
            else if (playerTurnCompleted && !companionTurnCompleted)
            {
                if (currentData.GetComponent<CurrentDataScript>().playerFirstAttack == 1)
                {
                    if (currentData.GetComponent<CurrentDataScript>().playerAttack == 0 && enemy1.GetComponent<EnemyTeamScript>().enemyType == 1 && enemy1.GetComponent<EnemyTeamScript>().IsAlive()) enemy1.GetComponent<EnemyTeamScript>().ReturnNormalHeight();
                    //We unhide the canvas
                    canvas.GetComponent<Animator>().SetBool("Hide", false);
                    //We reset the first attack int
                    currentData.GetComponent<CurrentDataScript>().playerFirstAttack = 0;
                    //We put the game on the initial state
                    playerTurnCompleted = false;
                    playerTurn = true;
                    playerChoosingAction = true;
                    companionTurn = false;
                    player.GetChild(0).GetChild(0).GetComponent<Animator>().SetBool("Active", true);
                }
                else
                {
                    //We put a darker color on the player 
                    player.GetComponent<SpriteRenderer>().color = new Color(0.2f, 0.2f, 0.2f, player.GetComponent<SpriteRenderer>().color.a);
                    //We unhide the canvas
                    canvas.GetComponent<Animator>().SetBool("Hide", false);
                    //We make the buff/debuff decrease
                    player.GetComponent<PlayerTeamScript>().ShowBuffDebuff();
                    companion.GetComponent<PlayerTeamScript>().ShowBuffDebuff();
                    //We start the companion turn
                    playerTurn = false;
                    companionTurn = true;
                    companionChoosingAction = true;
                    companion.GetChild(0).GetChild(0).GetComponent<Animator>().SetBool("Active", true);
                }
                
            }
            //If only the companion has completed their turn
            else if (!playerTurnCompleted && companionTurnCompleted)
            {
                if (currentData.GetComponent<CurrentDataScript>().companionFirstAttack == 1)
                {
                    //We unhide the canvas
                    canvas.GetComponent<Animator>().SetBool("Hide", false);
                    //We reset the first attack int
                    currentData.GetComponent<CurrentDataScript>().companionFirstAttack = 0;
                    //We put the game on the initial state
                    companionTurnCompleted = false;
                    playerTurn = true;
                    playerChoosingAction = true;
                    companionTurn = false;
                    player.GetChild(0).GetChild(0).GetComponent<Animator>().SetBool("Active", true);
                }
                else
                {
                    //We put a darker color on the companion 
                    companion.GetComponent<SpriteRenderer>().color = new Color(0.2f, 0.2f, 0.2f, companion.GetComponent<SpriteRenderer>().color.a);
                    //We unhide the canvas
                    canvas.GetComponent<Animator>().SetBool("Hide", false);
                    //We make the buff/debuff decrease
                    player.GetComponent<PlayerTeamScript>().ShowBuffDebuff();
                    companion.GetComponent<PlayerTeamScript>().ShowBuffDebuff();
                    //We start the player turn
                    playerTurn = true;
                    playerChoosingAction = true;
                    companionTurn = false;
                    player.GetChild(0).GetChild(0).GetComponent<Animator>().SetBool("Active", true);
                }                
            }
        }
        //If all enemies are dead
        else
        {
            allEnemiesDead = true;
            //We check that the animation of the boss has ended
            if (bossDieAnimationEnded)
            {
                //If the player didnt earn any xp we give them 1
                if (currentFightXP == 0)
                {
                    currentFightXP = 1;
                    ShowCurrentXP();
                }
                //We put the color back to normal
                player.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, player.GetComponent<SpriteRenderer>().color.a);
                companion.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, companion.GetComponent<SpriteRenderer>().color.a);
                //We hide the canvas
                canvas.GetComponent<Animator>().SetBool("Hide", false);
                //We put the camera on the victory position
                mainCamera.GetComponent<CameraScript>().ChangeCameraState(1);
                //We reset the actual xp and activate the victory xp
                ResetXP();
                victoryXP.transform.GetChild(18).GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, 0.4f);
                victoryXP.transform.GetChild(19).gameObject.SetActive(true);
                victoryXP.transform.GetChild(20).gameObject.SetActive(true);
                victoryXP.transform.GetChild(21).gameObject.SetActive(true);
                victoryXP.transform.GetChild(19).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_victory_1");
                victoryXP.transform.GetChild(20).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_victory_2");
                victoryXP.transform.GetChild(21).GetComponent<Text>().text = currentFightXP.ToString();
                //We end the player turn and enter the victory state
                playerTeamTurn = false;
                playerTurnCompleted = false;
                companionTurnCompleted = false;
                victory = true;
                //We show the victory xp
                ShowVictoryXP();
                //We activate the vitory animations
                player.GetComponent<Animator>().SetTrigger("Victory");
                if (!companion.GetComponent<PlayerTeamScript>().IsDead()) companion.GetComponent<Animator>().SetTrigger("Victory");
            }            
        }
    }
    //A function to set the bossDieAnimationEnded boolean
    public void SetBossDieAnimationEnded(bool end)
    {
        bossDieAnimationEnded = end;
    }

    //A function to end enemy turn
    public void EndEnemyTurn()
    {
        //We put the color back to normal
        player.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, player.GetComponent<SpriteRenderer>().color.a);
        companion.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, companion.GetComponent<SpriteRenderer>().color.a);
        //If the player is dead we save that the last enemy killed them
        if (player.GetComponent<PlayerTeamScript>().IsDead()) killerEnemy = 5;
        else
        {
            //We restart the defense ints
            defensePlayer = 0;
            defenseCompanion = 0;
            //We start player turn
            playerTeamTurn = true;
            //If the wizard was using the barrier
            if (taunting)
            {
                //We end the taunt
                taunting = false;
                //We end the defending animation and make the barrier disappear
                companion.GetComponent<Animator>().SetBool("isDefending", false);
                companion.GetChild(1).GetComponent<SpriteRenderer>().color = new Color(companion.GetChild(1).GetComponent<SpriteRenderer>().color.r, companion.GetChild(1).GetComponent<SpriteRenderer>().color.g, companion.GetChild(1).GetComponent<SpriteRenderer>().color.b, 0.0f);
                //We make the companion return to their position
                playerTurn = false;
                playerChoosingAction = false;
                companionTurn = true;
                companion.GetComponent<PlayerTeamScript>().ReturnStartPosWizard();
            }
            else
            {
                //IF the companion isnt dead we activate the change position action
                if (!companion.GetComponent<PlayerTeamScript>().IsDead())
                {

                    if (currentData.GetComponent<CurrentDataScript>().unlockedCompanions < 1) changePosAction.SetActive(false);
                    else changePosAction.SetActive(true);
                }
                //If they are dead we start the player turn
                if (companion.GetComponent<PlayerTeamScript>().IsDead())
                {
                    player.GetChild(0).transform.GetChild(0).GetComponent<Animator>().SetBool("Active", true);
                    companionTurn = false;
                    companionChoosingAction = false;
                    playerTurn = true;
                    playerChoosingAction = true;
                }
                else
                {
                    //If the player is in the first position we start the player turn
                    if (firstPosPlayer)
                    {
                        player.GetChild(0).transform.GetChild(0).GetComponent<Animator>().SetBool("Active", true);
                        companionTurn = false;
                        companionChoosingAction = false;
                        playerTurn = true;
                        playerChoosingAction = true;
                    }
                    //Else we start the companion turn
                    else
                    {
                        companion.GetChild(0).transform.GetChild(0).GetComponent<Animator>().SetBool("Active", true);
                        playerTurn = false;
                        playerChoosingAction = false;
                        companionTurn = true;
                        companionChoosingAction = true;
                    }
                }
            }            
            enemyTeamTurn = false;
        }                        
    }
    //Function to get the first pos teamate. true-> player, false-> companion
    public bool IsPlayerFirst()
    {
        return firstPosPlayer;
    }
    //Function to get the aim rotation
    public float GetAimRotation()
    {
        return aimRotation;
    }


    //A function to pass the turn to the next enemy
    public void NextEnemy(int numb)
    {
        //We put the color back to normal
        player.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, player.GetComponent<SpriteRenderer>().color.a);
        companion.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, companion.GetComponent<SpriteRenderer>().color.a);
        //If the player dies we save what enemy will attack when they revive
        if (player.GetComponent<PlayerTeamScript>().IsDead())
        {
            killerEnemy = numb;
        }
        else
        {
            //We activate the next enemy turn
            if (numb == 1)
            {
                if (currentData.GetComponent<CurrentDataScript>().enemyStart == 1)
                {
                    currentData.GetComponent<CurrentDataScript>().enemyStart = 0;
                    currentData.GetComponent<CurrentDataScript>().firstAttackObjective = 0;
                    EndEnemyTurn();
                }
                else
                {
                    enemy2Turn = true;
                }
            }
            else if (numb == 2)
            {
                enemy3Turn = true;
            }
            else if (numb == 3)
            {
                enemy4Turn = true;
            }
            else if (numb == 4)
            {
                EndEnemyTurn();
            }
        }        
    }
    //Function to restart the enemy attack when the player dies
    public void ContinueEnemy()
    {
        //We restart the enemy attack or end the enemy attack fase
        if (killerEnemy != 5) NextEnemy(killerEnemy);
        else EndEnemyTurn();
    }
    //A function to start the attack action zone
    public void StartAttackAction()
    {
        if (currentData.GetComponent<CurrentDataScript>().tutorialState < 3)
        {
            Time.timeScale = 0.0f;
            GetComponent<DialogueManager>().SetTutorial(true);
            GetComponent<DialogueManager>().StartBattleDialogue(new Dialogue(new Transform[] { player.transform }, new string[] { "npc_prisonerAdventurer_1" }), false);
        }
        attackAction = true;
    }

    //A function to start the defense zone
    public void StartDefenseZone()
    {
        if (currentData.GetComponent<CurrentDataScript>().tutorialState == 1)
        {
            Time.timeScale = 0.0f;
            GetComponent<DialogueManager>().SetTutorial(true);
            GetComponent<DialogueManager>().StartBattleDialogue(new Dialogue(new Transform[] { player.transform }, new string[] { "npc_prisonerAdventurer_1" }), false);
        }
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
        //We save the lvl with a max of 4
        int actualLvl = lvl;
        if (actualLvl > 4) actualLvl = 4;
        //We put the fill at the starting pos
        player.GetChild(0).transform.GetChild(7).transform.GetChild(1).GetComponent<Image>().fillAmount = 0.0f;
        //We start putting the keys at random positions depending on the lvl
        float key1pos = Random.Range(-4.75f, -4.75f + (10.0f/(actualLvl + 3)));
        key1 = Instantiate(keyPrefab, new Vector3(0.0f, player.GetChild(0).transform.GetChild(7).transform.position.y, player.GetChild(0).transform.GetChild(7).transform.position.z), Quaternion.identity, player.GetChild(0).transform.GetChild(7).transform);
        key1.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(key1pos, 0.0f, 0.0f);
        //We put a random key and save it in the previously selected position
        key1Input = Random.Range(0, 4);
        if(key1Input == 0) key1.GetComponent<Image>().sprite = upArrowSprite;
        if (key1Input == 1) key1.GetComponent<Image>().sprite = leftArrowSprite;
        if (key1Input == 2) key1.GetComponent<Image>().sprite = rightArrowSprite;
        if (key1Input == 3) key1.GetComponent<Image>().sprite = downArrowSprite;
        //We change the key color
        key1.GetComponent<Image>().color = new Vector4(0.4f, 0.4f, 0.4f, 1.0f);
        //We instantiate a key cover that we will remove when the soul arrives
        key1Cover = Instantiate(keyPrefab, new Vector3(0.0f, player.GetChild(0).transform.GetChild(7).transform.position.y, player.GetChild(0).transform.GetChild(7).transform.position.z), Quaternion.identity, player.GetChild(0).transform.GetChild(7).transform);
        key1Cover.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(key1pos, 0.0f, 0.0f);
        //We repeat this with every key
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
        //We save the real level and start the attack
        soulMusic = lvl;
        finalAttack = true;
    }

    //Function to end the soul music attack
    public void EndSoulAttack(int lvl)
    {
        //We sleep the enemies depending on the final level of the attack
        Transform[] enemies = GetAllEnemies();
        for(int i = 0; i < enemies.Length; i++)
        {
            enemies[i].GetComponent<EnemyTeamScript>().SetAsleepTime(lvl);
        }
        //We end the attack and end the player turn
        soulMusic = 0;
        finalAttack = false;
        EndPlayerTurn(1);
    }
    
    //Function to start the regeneration attack
    public void StartRegenerationAttack()
    {
        //We put a random position and a random color to the first ring
        float randx = Random.Range(-5.0f,5.0f);
        float randc = Random.Range(0.0f, 1.0f);
        //We instantiate the correct ring
        if (randc < 0.5f) ring1[0] = Instantiate(redRingBck, regenerationAction.transform);
        else ring1[0] = Instantiate(yellowRingBck, regenerationAction.transform);
        //We put the ring on the correct position
        ring1[0].GetComponent<RectTransform>().anchoredPosition = new Vector2(randx, -5.0f);
        //We generate a new position depending on the last position and a new color
        if (randx < -2.0f) randx = -2.0f;
        else if (randx > 2.0f) randx = 2.0f;
        randx = Random.Range(randx-3.0f, randx+3.0f);
        randc = Random.Range(0.0f, 1.0f);
        if(randc < 0.5f) ring2[0] = Instantiate(redRingBck, regenerationAction.transform);
        else ring2[0] = Instantiate(yellowRingBck, regenerationAction.transform);
        ring2[0].GetComponent<RectTransform>().anchoredPosition = new Vector2(randx, -6.0f);
        //We generate a new position depending on the last position and a new color
        if (randx < -2.0f) randx = -2.0f;
        else if (randx > 2.0f) randx = 2.0f;
        randx = Random.Range(randx - 3.0f, randx + 3.0f);
        randc = Random.Range(0.0f, 1.0f);
        if(randc < 0.5f) ring3[0] = Instantiate(redRingBck, regenerationAction.transform);
        else ring3[0] = Instantiate(yellowRingBck, regenerationAction.transform);
        ring3[0].GetComponent<RectTransform>().anchoredPosition = new Vector2(randx, -7.0f);
        //We generate a new position depending on the last position and a new color
        if (randx < -2.0f) randx = -2.0f;
        else if (randx > 2.0f) randx = 2.0f;
        randx = Random.Range(randx - 3.0f, randx + 3.0f);
        randc = Random.Range(0.0f, 1.0f);
        if(randc < 0.5f) ring4[0] = Instantiate(redRingBck, regenerationAction.transform);
        else ring4[0] = Instantiate(yellowRingBck, regenerationAction.transform);
        ring4[0].GetComponent<RectTransform>().anchoredPosition = new Vector2(randx, -8.0f);
        //We generate a new position depending on the last position and a new color
        if (randx < -2.0f) randx = -2.0f;
        else if (randx > 2.0f) randx = 2.0f;
        randx = Random.Range(randx - 3.0f, randx + 3.0f);
        randc = Random.Range(0.0f, 1.0f);
        if(randc < 0.5f) ring5[0] = Instantiate(redRingBck, regenerationAction.transform);
        else ring5[0] = Instantiate(yellowRingBck, regenerationAction.transform);
        ring5[0].GetComponent<RectTransform>().anchoredPosition = new Vector2(randx, -9.0f);
        //We generate a new position depending on the last position and a new color
        if (randx < -2.0f) randx = -2.0f;
        else if (randx > 2.0f) randx = 2.0f;
        randx = Random.Range(randx - 3.0f, randx + 3.0f);
        randc = Random.Range(0.0f, 1.0f);
        if(randc < 0.5f) ring6[0] = Instantiate(redRingBck, regenerationAction.transform);
        else ring6[0] = Instantiate(yellowRingBck, regenerationAction.transform);
        ring6[0].GetComponent<RectTransform>().anchoredPosition = new Vector2(randx, -10.0f);
        //We generate a new position depending on the last position and a new color
        if (randx < -2.0f) randx = -2.0f;
        else if (randx > 2.0f) randx = 2.0f;
        randx = Random.Range(randx - 3.0f, randx + 3.0f);
        randc = Random.Range(0.0f, 1.0f);
        if(randc < 0.5f) ring7[0] = Instantiate(redRingBck, regenerationAction.transform);
        else ring7[0] = Instantiate(yellowRingBck, regenerationAction.transform);
        ring7[0].GetComponent<RectTransform>().anchoredPosition = new Vector2(randx, -11.0f);
        //We generate a new position depending on the last position and a new color
        if (randx < -2.0f) randx = -2.0f;
        else if (randx > 2.0f) randx = 2.0f;
        randx = Random.Range(randx - 3.0f, randx + 3.0f);
        randc = Random.Range(0.0f, 1.0f);
        if (randc < 0.5f) ring8[0] = Instantiate(redRingBck, regenerationAction.transform);
        else ring8[0] = Instantiate(yellowRingBck, regenerationAction.transform);
        ring8[0].GetComponent<RectTransform>().anchoredPosition = new Vector2(randx, -12.0f);
        //We instantiate the green soul
        greenSoul = Instantiate(greenSoulPrefab, regenerationAction.transform);
        greenSoul.GetComponent<RectTransform>().anchoredPosition = new Vector2(0.0f, 0.0f);
        //We instantiate the top parts of the previously instantiated rings
        ring1[1] = Instantiate(RingFront, regenerationAction.transform);
        if (ring1[0].tag.Equals("RedRing")) ring1[1].GetComponent<RingScript>().SetColor(true);
        else ring1[1].GetComponent<RingScript>().SetColor(false);
        ring1[1].GetComponent<RingScript>().SetTopRing(ring1[0]);
        ring1[1].GetComponent<RingScript>().SetPrevRing(ring8[0]);
        ring1[1].GetComponent<RectTransform>().anchoredPosition = new Vector2(ring1[0].GetComponent<RectTransform>().anchoredPosition.x, ring1[0].GetComponent<RectTransform>().anchoredPosition.y + 0.009f);
        ring2[1] = Instantiate(RingFront, regenerationAction.transform);
        if (ring2[0].tag.Equals("RedRing")) ring2[1].GetComponent<RingScript>().SetColor(true);
        else ring2[1].GetComponent<RingScript>().SetColor(false);
        ring2[1].GetComponent<RingScript>().SetTopRing(ring2[0]);
        ring2[1].GetComponent<RingScript>().SetPrevRing(ring1[0]);
        ring2[1].GetComponent<RectTransform>().anchoredPosition = new Vector2(ring2[0].GetComponent<RectTransform>().anchoredPosition.x, ring2[0].GetComponent<RectTransform>().anchoredPosition.y + 0.009f);
        ring3[1] = Instantiate(RingFront, regenerationAction.transform);
        if (ring3[0].tag.Equals("RedRing")) ring3[1].GetComponent<RingScript>().SetColor(true);
        else ring3[1].GetComponent<RingScript>().SetColor(false);
        ring3[1].GetComponent<RingScript>().SetTopRing(ring3[0]);
        ring3[1].GetComponent<RingScript>().SetPrevRing(ring2[0]);
        ring3[1].GetComponent<RectTransform>().anchoredPosition = new Vector2(ring3[0].GetComponent<RectTransform>().anchoredPosition.x, ring3[0].GetComponent<RectTransform>().anchoredPosition.y + 0.009f);
        ring4[1] = Instantiate(RingFront, regenerationAction.transform);
        if (ring4[0].tag.Equals("RedRing")) ring4[1].GetComponent<RingScript>().SetColor(true);
        else ring4[1].GetComponent<RingScript>().SetColor(false);
        ring4[1].GetComponent<RingScript>().SetTopRing(ring4[0]);
        ring4[1].GetComponent<RingScript>().SetPrevRing(ring3[0]);
        ring4[1].GetComponent<RectTransform>().anchoredPosition = new Vector2(ring4[0].GetComponent<RectTransform>().anchoredPosition.x, ring4[0].GetComponent<RectTransform>().anchoredPosition.y + 0.009f);
        ring5[1] = Instantiate(RingFront, regenerationAction.transform);
        if (ring5[0].tag.Equals("RedRing")) ring5[1].GetComponent<RingScript>().SetColor(true);
        else ring5[1].GetComponent<RingScript>().SetColor(false);
        ring5[1].GetComponent<RingScript>().SetTopRing(ring5[0]);
        ring5[1].GetComponent<RingScript>().SetPrevRing(ring4[0]);
        ring5[1].GetComponent<RectTransform>().anchoredPosition = new Vector2(ring5[0].GetComponent<RectTransform>().anchoredPosition.x, ring5[0].GetComponent<RectTransform>().anchoredPosition.y + 0.009f);
        ring6[1] = Instantiate(RingFront, regenerationAction.transform);
        if (ring6[0].tag.Equals("RedRing")) ring6[1].GetComponent<RingScript>().SetColor(true);
        else ring6[1].GetComponent<RingScript>().SetColor(false);
        ring6[1].GetComponent<RingScript>().SetTopRing(ring6[0]);
        ring6[1].GetComponent<RingScript>().SetPrevRing(ring5[0]);
        ring6[1].GetComponent<RectTransform>().anchoredPosition = new Vector2(ring6[0].GetComponent<RectTransform>().anchoredPosition.x, ring6[0].GetComponent<RectTransform>().anchoredPosition.y + 0.009f);
        ring7[1] = Instantiate(RingFront, regenerationAction.transform);
        if (ring7[0].tag.Equals("RedRing")) ring7[1].GetComponent<RingScript>().SetColor(true);
        else ring7[1].GetComponent<RingScript>().SetColor(false);
        ring7[1].GetComponent<RingScript>().SetTopRing(ring7[0]);
        ring7[1].GetComponent<RingScript>().SetPrevRing(ring6[0]);
        ring7[1].GetComponent<RectTransform>().anchoredPosition = new Vector2(ring7[0].GetComponent<RectTransform>().anchoredPosition.x, ring7[0].GetComponent<RectTransform>().anchoredPosition.y + 0.009f);
        ring8[1] = Instantiate(RingFront, regenerationAction.transform);
        if (ring8[0].tag.Equals("RedRing")) ring8[1].GetComponent<RingScript>().SetColor(true);
        else ring8[1].GetComponent<RingScript>().SetColor(false);
        ring8[1].GetComponent<RingScript>().SetTopRing(ring8[0]);
        ring8[1].GetComponent<RingScript>().SetPrevRing(ring7[0]);
        ring8[1].GetComponent<RectTransform>().anchoredPosition = new Vector2(ring8[0].GetComponent<RectTransform>().anchoredPosition.x, ring8[0].GetComponent<RectTransform>().anchoredPosition.y + 0.009f);
        //We start the soul attack
        finalAttack = true;
        soulRegen = true;
    }
    //A function to start the lightning attack
    public void StartLightningAttack()
    {
        //We instantiate the yellow soul and start the soul attack
        yellowSoul = Instantiate(yellowSoulPrefab, lightningAction.transform);
        yellowSoul.position = new Vector3(player.position.x, 3.5f, player.position.z);
        finalAttack = true;
        soulLightning = true;
    }
    //A function to start the lifesteal attack
    public void StartLifestealAttack()
    {
        //We instantiate a red soul in a random position
        float randx = Random.Range(-5.0f, 5.0f);
        redSoul1 = Instantiate(redSoulPrefab, lifestealAction.transform);
        redSoul1.GetComponent<RectTransform>().anchoredPosition = new Vector2(randx, 3.0f);
        //We instantiate the next red soul depending on the last position
        if (randx < -2.0f) randx = -2.0f;
        else if (randx > 2.0f) randx = 2.0f;
        randx = Random.Range(randx - 3.0f, randx + 3.0f);
        redSoul2 = Instantiate(redSoulPrefab, lifestealAction.transform);
        redSoul2.GetComponent<RectTransform>().anchoredPosition = new Vector2(randx, 4.1f);
        //We instantiate the next red soul depending on the last position
        if (randx < -2.0f) randx = -2.0f;
        else if (randx > 2.0f) randx = 2.0f;
        randx = Random.Range(randx - 3.0f, randx + 3.0f);
        redSoul3 = Instantiate(redSoulPrefab, lifestealAction.transform);
        redSoul3.GetComponent<RectTransform>().anchoredPosition = new Vector2(randx, 5.2f);
        //We instantiate the next red soul depending on the last position
        if (randx < -2.0f) randx = -2.0f;
        else if (randx > 2.0f) randx = 2.0f;
        randx = Random.Range(randx - 3.0f, randx + 3.0f);
        redSoul4 = Instantiate(redSoulPrefab, lifestealAction.transform);
        redSoul4.GetComponent<RectTransform>().anchoredPosition = new Vector2(randx, 6.3f);
        //We instantiate the next red soul depending on the last position
        if (randx < -2.0f) randx = -2.0f;
        else if (randx > 2.0f) randx = 2.0f;
        randx = Random.Range(randx - 3.0f, randx + 3.0f);
        redSoul5 = Instantiate(redSoulPrefab, lifestealAction.transform);
        redSoul5.GetComponent<RectTransform>().anchoredPosition = new Vector2(randx, 7.4f);
        //We instantiate the next red soul depending on the last position
        if (randx < -2.0f) randx = -2.0f;
        else if (randx > 2.0f) randx = 2.0f;
        randx = Random.Range(randx - 3.0f, randx + 3.0f);
        redSoul6 = Instantiate(redSoulPrefab, lifestealAction.transform);
        redSoul6.GetComponent<RectTransform>().anchoredPosition = new Vector2(randx, 8.5f);
        //We instantiate the next red soul depending on the last position
        if (randx < -2.0f) randx = -2.0f;
        else if (randx > 2.0f) randx = 2.0f;
        randx = Random.Range(randx - 3.0f, randx + 3.0f);
        redSoul7 = Instantiate(redSoulPrefab, lifestealAction.transform);
        redSoul7.GetComponent<RectTransform>().anchoredPosition = new Vector2(randx, 9.6f);
        //We instantiate the next red soul depending on the last position
        if (randx < -2.0f) randx = -2.0f;
        else if (randx > 2.0f) randx = 2.0f;
        randx = Random.Range(randx - 3.0f, randx + 3.0f);
        redSoul8 = Instantiate(redSoulPrefab, lifestealAction.transform);
        redSoul8.GetComponent<RectTransform>().anchoredPosition = new Vector2(randx, 10.7f);
        //We instantiate the next red soul depending on the last position
        if (randx < -2.0f) randx = -2.0f;
        else if (randx > 2.0f) randx = 2.0f;
        randx = Random.Range(randx - 3.0f, randx + 3.0f);
        redSoul9 = Instantiate(redSoulPrefab, lifestealAction.transform);
        redSoul9.GetComponent<RectTransform>().anchoredPosition = new Vector2(randx, 11.8f);
        //We instantiate the next red soul depending on the last position
        if (randx < -2.0f) randx = -2.0f;
        else if (randx > 2.0f) randx = 2.0f;
        randx = Random.Range(randx - 3.0f, randx + 3.0f);
        redSoul10 = Instantiate(redSoulPrefab, lifestealAction.transform);
        redSoul10.GetComponent<RectTransform>().anchoredPosition = new Vector2(randx, 12.9f);
        //We instantiate the jar and start the attack
        jar = Instantiate(jarPrefab, lifestealAction.transform);
        finalAttack = true;
        soulLifesteal = true;
    }
    //A function to sum 1 to soulLifestealNumb
    public void GatherRedSoul()
    {
        soulLifestealNumb += 1;
        if (soulLifestealNumb == 1) GoodCommand(true,1);
        else if (soulLifestealNumb == 4) GoodCommand(true, 2);
        else if (soulLifestealNumb == 7) GoodCommand(true, 3);
        else if (soulLifestealNumb == 10) GoodCommand(true, 4);

    }

    //Functions to end the lifsteal attack
    public void EndLifestealAttack()
    {
        //We put the lifsteal buff
        player.GetComponent<PlayerTeamScript>().SetLifestealTime(soulLifestealNumb);
        player.GetComponent<PlayerTeamScript>().HideBuffDebuff();
        companion.GetComponent<PlayerTeamScript>().HideBuffDebuff();
        //we reset the lifesteal variables
        soulLifestealNumb = 0;
        soulLifesteal = false;
        actionInstructions.SetActive(false);
        //We destroy the jar and end the lifsteal attack
        Destroy(jar.gameObject);
        player.GetComponent<PlayerTeamScript>().EndLifestealAttack();
    }

    public void EndSoulLifestealAttack()
    {
        finalAttack = false;
        EndPlayerTurn(1);
    }
    //A function to get the lvl up menu position
    public void SetLvlUpSelected(int pos)
    {
        lvlUpSelected = pos;
    }
    //A function to start the disappear attack
    public void StartDisappearAttack()
    {
        //We instantiate the blue soul
        blueSoul = Instantiate(blueSoulPrefab, disappearAction.transform);
        //We instantiate the wall on a random position
        float randy = Random.Range(-1.5f, 1.5f);
        wall1 = Instantiate(wallPrefab, disappearAction.transform);
        wall1.GetComponent<RectTransform>().anchoredPosition = new Vector2(6.5f, randy);
        //We instantiate the wall on a random position
        randy = Random.Range(-1.5f, 1.5f);
        wall2 = Instantiate(wallPrefab, disappearAction.transform);
        wall2.GetComponent<RectTransform>().anchoredPosition = new Vector2(9.5f, randy);
        //We save the precious wall
        wall2.GetComponent<WallScript>().SetPreviousWall(wall1);
        //We instantiate the wall on a random position
        randy = Random.Range(-1.5f, 1.5f);
        wall3 = Instantiate(wallPrefab, disappearAction.transform);
        wall3.GetComponent<RectTransform>().anchoredPosition = new Vector2(12.5f, randy);
        //We save the precious wall
        wall3.GetComponent<WallScript>().SetPreviousWall(wall2);
        //We instantiate the wall on a random position
        randy = Random.Range(-1.5f, 1.5f);
        wall4 = Instantiate(wallPrefab, disappearAction.transform);
        wall4.GetComponent<RectTransform>().anchoredPosition = new Vector2(15.5f, randy);
        //We save the precious wall
        wall4.GetComponent<WallScript>().SetPreviousWall(wall3);
        //We instantiate the wall on a random position
        randy = Random.Range(-1.5f, 1.5f);
        wall5 = Instantiate(wallPrefab, disappearAction.transform);
        wall5.GetComponent<RectTransform>().anchoredPosition = new Vector2(18.5f, randy);
        //We save the precious wall
        wall5.GetComponent<WallScript>().SetPreviousWall(wall4);
        //We save the previous wall of the first wall
        wall1.GetComponent<WallScript>().SetPreviousWall(wall5);
        //We start the attack
        finalAttack = true;
        soulDisappear = true;
    }
    //Function to start the light up attack
    public void StartLightUpAttack()
    {
        //We instantiate the magenta soul, the fog and the first shard
        magentaSoul = Instantiate(magentaSoulPrefab, lightUpAction.transform);
        fog = Instantiate(fogPrefab, lightUpAction.transform);
        magentaShard = Instantiate(magentaShardPrefab, lightUpAction.transform);
        //We scale the shard, set the shard as the first sibling and put it in a random position
        magentaShard.GetComponent<RectTransform>().localScale = new Vector3(0.2f, 0.2f, 1.0f);
        magentaShard.transform.SetAsFirstSibling();
        float posx = Random.Range(-5.45f,5.45f);
        float posy = Random.Range(-1.75f,2.0f);
        magentaShard.GetComponent<RectTransform>().anchoredPosition = new Vector2(posx, posy);
        //We start the attack
        finalAttack = true;
        soulLightUp = true;
    }
    //Functions to end the light up attack
    public void EndLightUpAttack()
    {
        //We set the buff depending on the minimun fog scale
        if(minFogScale>1.0f) player.GetComponent<PlayerTeamScript>().SetLightUpPower(minFogScale);
        player.GetComponent<PlayerTeamScript>().HideBuffDebuff();
        //We reset the variables
        magentaSoulMovUp = false;
        magentaSoulMovLeft = false;
        magentaSoulMovRight = false;
        magentaSoulMovDown = false;
        actionInstructions.SetActive(false);
        minFogScale = 1.0f;
        fogScaled = false;
        soulLightUp = false;
        //We destroy the objects
        Destroy(magentaSoul.gameObject);
        Destroy(magentaShard.gameObject);
        Destroy(fog.gameObject);
        //We end the light up attack
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
        //We instantiate the magenta shard
        magentaShard = Instantiate(magentaShardPrefab, lightUpAction.transform);
        //We scale the shard, set the shard as the first sibling and put it in a random position
        magentaShard.GetComponent<RectTransform>().localScale = new Vector3(0.2f, 0.2f, 1.0f);
        magentaShard.transform.SetAsFirstSibling();
        float posx = Random.Range(-5.45f, 5.45f);
        float posy = Random.Range(-1.75f, 2.0f);
        magentaShard.GetComponent<RectTransform>().anchoredPosition = new Vector2(posx, posy);
    }
    //Function to increment the minimum fog scale
    public void IncrementFogSize()
    {
        minFogScale += 0.5f;
        if(minFogScale == 1.5f) GoodCommand(false,1);
        else if (minFogScale == 2.0f) GoodCommand(false, 2);
        else if (minFogScale == 2.5f) GoodCommand(false, 3);
        else if (minFogScale == 3.0f) GoodCommand(false, 4);
        else GoodCommand(false, 5);
    }
    //A function to select the next flying or grounded enemy.
    private Transform SelectNextShuriken(bool grounded)
    {
        Transform[] enemies = GetAllEnemies();
        int i = 0;
        bool found = false;
        //We look for the first grounded or flying enemy and return it
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
        //If the first enemy is alive we save the name
        if (enemy1.GetComponent<EnemyTeamScript>().IsAlive() && ((playerTurn && (selectingAction == 0 && enemy1.GetComponent<EnemyTeamScript>().IsGrounded()) || selectingAction != 0) || (companionTurn && (((usingStyle == 0 || usingStyle == 2) && companion.GetComponent<PlayerTeamScript>().GetPlayerType() == 1 && enemy1.GetComponent<EnemyTeamScript>().IsGrounded()) || (usingStyle == 1 && companion.GetComponent<PlayerTeamScript>().GetPlayerType() == 1) || (companion.GetComponent<PlayerTeamScript>().GetPlayerType() == 2 && ((usingStyle ==2 && enemy1.GetComponent<EnemyTeamScript>().IsGrounded())|| usingStyle==0 || usingStyle == 3))))))
        {
            enemy1.GetChild(0).transform.GetChild(0).gameObject.SetActive(true);
            if (enemy1.GetComponent<EnemyTeamScript>().enemyType == 0) enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_enemy_bandit");
            else if (enemy1.GetComponent<EnemyTeamScript>().enemyType == 1) enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_enemy_evilwizard");
            else if (enemy1.GetComponent<EnemyTeamScript>().enemyType == 2) enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_enemy_king");
            else if (enemy1.GetComponent<EnemyTeamScript>().enemyType == 3) enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_enemy_knight");
        }
        //if not we look all the other enemies unitl we find one that isnt dead
        else if(enemyNumber > 1 && enemy2.GetComponent<EnemyTeamScript>().IsAlive() && ((playerTurn && (selectingAction == 0 && enemy2.GetComponent<EnemyTeamScript>().IsGrounded()) || selectingAction != 0) || (companionTurn && (((usingStyle == 0 || usingStyle == 2) && companion.GetComponent<PlayerTeamScript>().GetPlayerType() == 1 && enemy2.GetComponent<EnemyTeamScript>().IsGrounded()) || (usingStyle == 1 && companion.GetComponent<PlayerTeamScript>().GetPlayerType() == 1) || (companion.GetComponent<PlayerTeamScript>().GetPlayerType() == 2 && ((usingStyle == 2 && enemy2.GetComponent<EnemyTeamScript>().IsGrounded()) || usingStyle == 0 || usingStyle == 3))))))
        {
            enemy2.GetChild(0).transform.GetChild(0).gameObject.SetActive(true);
            if (enemy2.GetComponent<EnemyTeamScript>().enemyType == 0) enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_enemy_bandit");
            else if (enemy2.GetComponent<EnemyTeamScript>().enemyType == 1) enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_enemy_evilwizard");
            else if (enemy2.GetComponent<EnemyTeamScript>().enemyType == 2) enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_enemy_king");
            else if (enemy2.GetComponent<EnemyTeamScript>().enemyType == 3) enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_enemy_knight");
        }
        else if (enemyNumber > 2 && enemy3.GetComponent<EnemyTeamScript>().IsAlive() && ((playerTurn && (selectingAction == 0 && enemy3.GetComponent<EnemyTeamScript>().IsGrounded()) || selectingAction != 0) || (companionTurn && (((usingStyle == 0 || usingStyle == 2) && companion.GetComponent<PlayerTeamScript>().GetPlayerType() == 1 && enemy3.GetComponent<EnemyTeamScript>().IsGrounded()) || (usingStyle == 1 && companion.GetComponent<PlayerTeamScript>().GetPlayerType() == 1) || (companion.GetComponent<PlayerTeamScript>().GetPlayerType() == 2 && ((usingStyle == 2 && enemy3.GetComponent<EnemyTeamScript>().IsGrounded()) || usingStyle == 0 || usingStyle == 3))))))
        {
            enemy3.GetChild(0).transform.GetChild(0).gameObject.SetActive(true);
            if (enemy3.GetComponent<EnemyTeamScript>().enemyType == 0) enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_enemy_bandit");
            else if (enemy3.GetComponent<EnemyTeamScript>().enemyType == 1) enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_enemy_evilwizard");
            else if (enemy3.GetComponent<EnemyTeamScript>().enemyType == 2) enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_enemy_king");
            else if (enemy3.GetComponent<EnemyTeamScript>().enemyType == 3) enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_enemy_knight");
        }
        else if (enemyNumber > 3 && enemy4.GetComponent<EnemyTeamScript>().IsAlive() && ((playerTurn && (selectingAction == 0 && enemy4.GetComponent<EnemyTeamScript>().IsGrounded()) || selectingAction != 0) || (companionTurn && (((usingStyle == 0 || usingStyle == 2) && companion.GetComponent<PlayerTeamScript>().GetPlayerType() == 1 && enemy4.GetComponent<EnemyTeamScript>().IsGrounded()) || (usingStyle == 1 && companion.GetComponent<PlayerTeamScript>().GetPlayerType() == 1) || (companion.GetComponent<PlayerTeamScript>().GetPlayerType() == 2 && ((usingStyle == 2 && enemy4.GetComponent<EnemyTeamScript>().IsGrounded()) || usingStyle == 0 || usingStyle == 3))))))
        {
            enemy4.GetChild(0).transform.GetChild(0).gameObject.SetActive(true);
            if (enemy4.GetComponent<EnemyTeamScript>().enemyType == 0) enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_enemy_bandit");
            else if (enemy4.GetComponent<EnemyTeamScript>().enemyType == 1) enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_enemy_evilwizard");
            else if (enemy4.GetComponent<EnemyTeamScript>().enemyType == 2) enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_enemy_king");
            else if (enemy4.GetComponent<EnemyTeamScript>().enemyType == 3) enemyName.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_enemy_knight");
        }
        canSelect = true;
    }
    //A function to select all the ground enemies
    private void SelectGroundEnemies()
    {
        int lastI = -1;
        Transform[] groundEnemies = GetGroundEnemies();
        //We write the name of all the gorunded enemies
        for (int i = 0; i < groundEnemies.Length; i++) 
        { 
            if(groundEnemies[i].GetComponent<EnemyTeamScript>().enemyType == 0)
            {
                groundEnemies[i].GetChild(0).transform.GetChild(0).gameObject.SetActive(true);
                enemyName.transform.GetChild(i).gameObject.SetActive(true);
                enemyName.transform.GetChild(i).transform.GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_enemy_bandit");
                lastI = i;
            }
            else if(groundEnemies[i].GetComponent<EnemyTeamScript>().enemyType == 1)
            {
                groundEnemies[i].GetChild(0).transform.GetChild(0).gameObject.SetActive(true);
                enemyName.transform.GetChild(i).gameObject.SetActive(true);
                enemyName.transform.GetChild(i).transform.GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_enemy_evilwizard");
                lastI = i;
            }
            else if (groundEnemies[i].GetComponent<EnemyTeamScript>().enemyType == 2)
            {
                groundEnemies[i].GetChild(0).transform.GetChild(0).gameObject.SetActive(true);
                enemyName.transform.GetChild(i).gameObject.SetActive(true);
                enemyName.transform.GetChild(i).transform.GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_enemy_king");
                lastI = i;
            }
            else if (groundEnemies[i].GetComponent<EnemyTeamScript>().enemyType == 3)
            {
                groundEnemies[i].GetChild(0).transform.GetChild(0).gameObject.SetActive(true);
                enemyName.transform.GetChild(i).gameObject.SetActive(true);
                enemyName.transform.GetChild(i).transform.GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_enemy_knight");
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
        //We write the name of all the enemies
        for (int i = 0; i < groundEnemies.Length; i++)
        {
            if (groundEnemies[i].GetComponent<EnemyTeamScript>().enemyType == 0)
            {
                groundEnemies[i].GetChild(0).transform.GetChild(0).gameObject.SetActive(true);
                enemyName.transform.GetChild(i).gameObject.SetActive(true);
                enemyName.transform.GetChild(i).transform.GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_enemy_bandit");
                lastI = i;
            }
            else if (groundEnemies[i].GetComponent<EnemyTeamScript>().enemyType == 1)
            {
                groundEnemies[i].GetChild(0).transform.GetChild(0).gameObject.SetActive(true);
                enemyName.transform.GetChild(i).gameObject.SetActive(true);
                enemyName.transform.GetChild(i).transform.GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_enemy_evilwizard");
                lastI = i;
            }
            else if (groundEnemies[i].GetComponent<EnemyTeamScript>().enemyType == 2)
            {
                groundEnemies[i].GetChild(0).transform.GetChild(0).gameObject.SetActive(true);
                enemyName.transform.GetChild(i).gameObject.SetActive(true);
                enemyName.transform.GetChild(i).transform.GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_enemy_king");
                lastI = i;
            }
            else if (groundEnemies[i].GetComponent<EnemyTeamScript>().enemyType == 3)
            {
                groundEnemies[i].GetChild(0).transform.GetChild(0).gameObject.SetActive(true);
                enemyName.transform.GetChild(i).gameObject.SetActive(true);
                enemyName.transform.GetChild(i).transform.GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_enemy_knight");
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

    //Function to know the position of the recover potion item
    private int RecoverPotionPos()
    {
        int i = 0;
        while (items[i] != 3 && i < 19)
        {
            i++;
        }
        if (items[i] == 3) return i;
        else return -1;
    }

    //Function to use a recover potion
    public bool UseRecoverPotion()
    {
        int pos = RecoverPotionPos();
        if (pos != -1)
        {
            player.GetComponent<PlayerTeamScript>().Recover(firstPosPlayer, false);
            currentData.GetComponent<CurrentDataScript>().DeleteItem(pos);
            return true;
        }
        else return false;
    }

    //Function to fill the souls
    public void FillSouls(float soul)
    {
        //We fill the souls in order and start filling the next one when the previous one is already completely filled
        if(soul1.GetComponent<Image>().fillAmount != 1.0f)
        {
            if ((soul1.GetComponent<Image>().fillAmount + soul) > 1.0f)
            {
                if (currentData.GetComponent<CurrentDataScript>().souls > 1) soul2.GetComponent<Image>().fillAmount = (soul1.GetComponent<Image>().fillAmount + soul) - 1.0f;
                soul1.GetComponent<Image>().fillAmount = 1.0f;
            }
            else soul1.GetComponent<Image>().fillAmount += soul;
        }
        else if (soul2.GetComponent<Image>().fillAmount != 1.0f)
        {
            if ((soul2.GetComponent<Image>().fillAmount + soul) > 1.0f)
            {
                if (currentData.GetComponent<CurrentDataScript>().souls > 2) soul3.GetComponent<Image>().fillAmount = (soul2.GetComponent<Image>().fillAmount + soul) - 1.0f;
                soul2.GetComponent<Image>().fillAmount = 1.0f;
            }
            else soul2.GetComponent<Image>().fillAmount += soul;
        }
        else if (soul3.GetComponent<Image>().fillAmount != 1.0f)
        {
            if ((soul3.GetComponent<Image>().fillAmount + soul) > 1.0f)
            {
                if (currentData.GetComponent<CurrentDataScript>().souls > 3) soul4.GetComponent<Image>().fillAmount = (soul3.GetComponent<Image>().fillAmount + soul) - 1.0f;
                soul3.GetComponent<Image>().fillAmount = 1.0f;
            }
            else soul3.GetComponent<Image>().fillAmount += soul;
        }
        else if (soul4.GetComponent<Image>().fillAmount != 1.0f)
        {
            if ((soul4.GetComponent<Image>().fillAmount + soul) > 1.0f)
            {
                if (currentData.GetComponent<CurrentDataScript>().souls > 4) soul5.GetComponent<Image>().fillAmount = (soul4.GetComponent<Image>().fillAmount + soul) - 1.0f;
                soul4.GetComponent<Image>().fillAmount = 1.0f;
            }
            else soul4.GetComponent<Image>().fillAmount += soul;
        }
        else if (soul5.GetComponent<Image>().fillAmount != 1.0f)
        {
            if ((soul5.GetComponent<Image>().fillAmount + soul) > 1.0f)
            {
                if (currentData.GetComponent<CurrentDataScript>().souls > 5) soul6.GetComponent<Image>().fillAmount = (soul5.GetComponent<Image>().fillAmount + soul) - 1.0f;
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
    //Function to make the good command action sound
    public void GoodCommand(bool audio, int lvl)
    {
        if (audio)
        {
            UISource.clip = correctCommandAudio;
            UISource.Play();
        }
        if (playerTurn)
        {
            correctCommandUI = Instantiate(correctCommandUIPrefab, canvas.GetComponent<RectTransform>());
            correctCommandUI.GetComponent<RectTransform>().anchoredPosition = new Vector2(new Vector2((mainCamera.GetComponent<Camera>().WorldToViewportPoint(player.transform.position).x * canvas.GetComponent<RectTransform>().sizeDelta.x) - (canvas.GetComponent<RectTransform>().sizeDelta.x * 0.5f), (mainCamera.GetComponent<Camera>().WorldToViewportPoint(player.transform.position).y * canvas.GetComponent<RectTransform>().sizeDelta.y) - (canvas.GetComponent<RectTransform>().sizeDelta.y * 0.5f)).x, 0.0f);
        }
        else if (companionTurn)
        {
            correctCommandUI = Instantiate(correctCommandUIPrefab, canvas.GetComponent<RectTransform>());
            correctCommandUI.GetComponent<RectTransform>().anchoredPosition = new Vector2(new Vector2((mainCamera.GetComponent<Camera>().WorldToViewportPoint(companion.transform.position).x * canvas.GetComponent<RectTransform>().sizeDelta.x) - (canvas.GetComponent<RectTransform>().sizeDelta.x * 0.5f), (mainCamera.GetComponent<Camera>().WorldToViewportPoint(companion.transform.position).y * canvas.GetComponent<RectTransform>().sizeDelta.y) - (canvas.GetComponent<RectTransform>().sizeDelta.y * 0.5f)).x, 0.0f);
        }
        if (lvl == 1)
        {
            correctCommandUI.GetComponent<TextMeshProUGUI>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_goodcommand_1");
            correctCommandUI.GetComponent<TextMeshProUGUI>().color = new Color(0.0f, 0.7264151f, 0.1601567f, 1.0f);
            correctCommandUI.GetComponent<TextMeshProUGUI>().outlineColor = new Color32(0, 31, 5, 255);
        }
        else if (lvl == 2)
        {
            correctCommandUI.GetComponent<TextMeshProUGUI>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_goodcommand_2");
            correctCommandUI.GetComponent<TextMeshProUGUI>().color = new Color(0.7254902f, 0.6703757f, 0.0f, 1.0f);
            correctCommandUI.GetComponent<TextMeshProUGUI>().outlineColor = new Color32(31, 30, 0, 255);
        }
        else if (lvl == 3)
        {
            correctCommandUI.GetComponent<TextMeshProUGUI>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_goodcommand_3");
            correctCommandUI.GetComponent<TextMeshProUGUI>().color = new Color(0.7254902f, 0.0f, 0.5383924f, 1.0f);
            correctCommandUI.GetComponent<TextMeshProUGUI>().outlineColor = new Color32(31, 0, 22, 255);
        }
        else if (lvl == 4)
        {
            correctCommandUI.GetComponent<TextMeshProUGUI>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_goodcommand_4");
            correctCommandUI.GetComponent<TextMeshProUGUI>().color = new Color(0.3601789f, 0.0f, 0.7254902f, 1.0f);
            correctCommandUI.GetComponent<TextMeshProUGUI>().outlineColor = new Color32(16, 0, 31, 255);
        }
        else if (lvl == 5)
        {
            correctCommandUI.GetComponent<TextMeshProUGUI>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_goodcommand_5");
            correctCommandUI.GetComponent<TextMeshProUGUI>().color = new Color(0.0f, 0.2961406f, 0.7254902f, 1.0f);
            correctCommandUI.GetComponent<TextMeshProUGUI>().outlineColor = new Color32(0, 15, 31, 255);
        }
    }

    //Function to make the bad command action sound
    public void BadCommand()
    {
        UISource.clip = incorrectCommandAudio;
        UISource.Play();
    }

    //Function to create the barrier action
    public void CreateBarrierAction()
    {
        barrierNumber = 0;
        companion.transform.GetChild(0).GetChild(4).gameObject.SetActive(true);
        float r;
        //We instantiate the keys randomly
        for (int i = 0; i<5; i++)
        {
            r = Random.Range(0.0f, 4.0f);
            if (r < 1.0f)
            {
                barrierKeys[i] = KeyCode.UpArrow;
                companion.transform.GetChild(0).GetChild(4).GetChild(i).GetComponent<Image>().sprite = upArrowSprite;
            }
            else if (r < 2.0f)
            {
                barrierKeys[i] = KeyCode.DownArrow;
                companion.transform.GetChild(0).GetChild(4).GetChild(i).GetComponent<Image>().sprite = downArrowSprite;
            }
            else if (r < 3.0f)
            {
                barrierKeys[i] = KeyCode.LeftArrow;
                companion.transform.GetChild(0).GetChild(4).GetChild(i).GetComponent<Image>().sprite = leftArrowSprite;
            }
            else if (r < 4.0f)
            {
                barrierKeys[i] = KeyCode.RightArrow;
                companion.transform.GetChild(0).GetChild(4).GetChild(i).GetComponent<Image>().sprite = rightArrowSprite;
            }
        }
        //We save the starting time to set the timer
        barrierTime = Time.fixedTime;
    }

    //Function to spend souls
    public void SpendSouls(int amount)
    {
        //We spend the souls starting from the last
        if(soul6.GetComponent<Image>().color.a > 0.0f && soul6.GetComponent<Image>().fillAmount > 0.0f)
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
        else if(soul5.GetComponent<Image>().color.a > 0.0f && soul5.GetComponent<Image>().fillAmount > 0.0f)
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
        else if (soul4.GetComponent<Image>().color.a > 0.0f && soul4.GetComponent<Image>().fillAmount > 0.0f)
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
        else if (soul3.GetComponent<Image>().color.a > 0.0f && soul3.GetComponent<Image>().fillAmount > 0.0f)
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
        else if (soul2.GetComponent<Image>().color.a > 0.0f && soul2.GetComponent<Image>().fillAmount > 0.0f)
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
        else if (amount == 1 && soul1.GetComponent<Image>().color.a > 0.0f && soul1.GetComponent<Image>().fillAmount == 1.0f)
        {
            soul1.GetComponent<Image>().fillAmount = 0.0f;
        }
    }

    //Function to set the magic key
    public void SetMagicKey(KeyCode key)
    {
        magicKey = key;
    }
    //Function to set the number of the magic spear
    public void SetMagicSpearNumber(int numb)
    {
        magicSpearKey = numb;
    }

    //Function to set the talking state
    public void SetTalking(bool state)
    {
        talking = state;
    }

    //Function to end the tutorial dialogue
    public void EndTutorialDialogue()
    {
        talking = false;
        GetComponent<DialogueManager>().SetTutorial(false);
        if (playerTeamTurn && playerTurn && !finalAttack)
        {
            player.GetChild(0).transform.GetChild(0).GetComponent<Animator>().SetBool("Active", true);
            currentData.GetComponent<CurrentDataScript>().tutorialState += 1;
            tutorialTurn = true;
        }
    }

    //Function to get the soul points
    private bool CanUseSoulPoints(int usingSouls)
    {
        //We look the amount of souls that are completely filled and return if there are more than the asked amount
        int soulPoints = 0;
        if (soul1.GetComponent<Image>().fillAmount == 1.0f) soulPoints += 1;
        if (currentData.GetComponent<CurrentDataScript>().souls > 1 && soul2.GetComponent<Image>().fillAmount == 1.0f) soulPoints += 1;
        if (currentData.GetComponent<CurrentDataScript>().souls > 2 && soul3.GetComponent<Image>().fillAmount == 1.0f) soulPoints += 1;
        if (currentData.GetComponent<CurrentDataScript>().souls > 3 && soul4.GetComponent<Image>().fillAmount == 1.0f) soulPoints += 1;
        if (currentData.GetComponent<CurrentDataScript>().souls > 4 && soul5.GetComponent<Image>().fillAmount == 1.0f) soulPoints += 1;
        if (currentData.GetComponent<CurrentDataScript>().souls > 5 && soul6.GetComponent<Image>().fillAmount == 1.0f) soulPoints += 1;
        return soulPoints>=usingSouls;
    }
    //Function to add xp to the current xp
    public void AddXPToCurrent(int xp)
    {
        currentFightXP += xp;
        ShowCurrentXP();
    }
    //Function to reset the xp
    private void ResetXP()
    {
        for (int i = 0; i<18; i++) xpObject.transform.GetChild(i).GetComponent<Image>().color = new Color(xpObject.transform.GetChild(0).GetComponent<Image>().color.r, xpObject.transform.GetChild(0).GetComponent<Image>().color.g, xpObject.transform.GetChild(0).GetComponent<Image>().color.b, 0.0f);
    }
    //Function to show the current xp
    private void ShowCurrentXP()
    {
        //We save the units and the tens separatedly to make it easier to know the exact amount
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
        //We save the units and the tens separatedly to make it easier to know the exact amount
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
    //Function to save the gained xp
    IEnumerator SaveXP()
    {
        while (currentFightXP > 0)
        {
            //We save the gained xp and save if the player level ups
            if (currentData.GetComponent<CurrentDataScript>().lvlExp < 99) currentData.GetComponent<CurrentDataScript>().lvlExp = currentData.GetComponent<CurrentDataScript>().lvlExp + 1;
            else
            {
                currentData.GetComponent<CurrentDataScript>().lvlExp = 0;
                lvlUp = true;
            }
            currentFightXP -= 1;
            ShowVictoryXP();
            xpText.text = currentData.GetComponent<CurrentDataScript>().lvlExp.ToString();
            yield return new WaitForFixedUpdate();
        }
        //If the player level ups we start the level up action
        if (lvlUp)
        {
            lvlUpMenu.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<Text>().text = (currentData.GetComponent<CurrentDataScript>().playerHeartLvl * 5 + 10).ToString();
            lvlUpMenu.transform.GetChild(0).GetChild(0).GetChild(2).GetComponent<Text>().text = (currentData.GetComponent<CurrentDataScript>().playerHeartLvl * 5 + 15).ToString();
            lvlUpMenu.transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<Text>().text = (currentData.GetComponent<CurrentDataScript>().playerLightLvl * 5 + 5).ToString();
            lvlUpMenu.transform.GetChild(1).GetChild(0).GetChild(2).GetComponent<Text>().text = (currentData.GetComponent<CurrentDataScript>().playerLightLvl * 5 + 10).ToString();
            lvlUpMenu.transform.GetChild(2).GetChild(0).GetChild(0).GetComponent<Text>().text = (currentData.GetComponent<CurrentDataScript>().playerBadgeLvl * 3 + 3).ToString();
            lvlUpMenu.transform.GetChild(2).GetChild(0).GetChild(2).GetComponent<Text>().text = (currentData.GetComponent<CurrentDataScript>().playerBadgeLvl * 3 + 6).ToString();
            canvas.GetComponent<Animator>().SetBool("Hide", true);
            actionInstructions.SetActive(true);
            actionInstructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_lvlup_select");
            victoryXP.transform.GetChild(18).GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
            victoryXP.transform.GetChild(19).gameObject.SetActive(false);
            victoryXP.transform.GetChild(20).gameObject.SetActive(false);
            victoryXP.transform.GetChild(21).gameObject.SetActive(false);
            mainCamera.GetComponent<CameraScript>().ChangeCameraState(0);
        }
        //If not we end the battle
        else
        {
            currentData.GetComponent<CurrentDataScript>().enemyDied = 1;
            victoryXP.transform.GetChild(18).GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
            victoryXP.transform.GetChild(19).gameObject.SetActive(false);
            victoryXP.transform.GetChild(20).gameObject.SetActive(false);
            victoryXP.transform.GetChild(21).gameObject.SetActive(false);
            EndBattle(true);
        }
    }
    //Function to end the battle
    public void EndBattle(bool alive)
    {
        if (alive)
        {
            canvas.GetComponent<WorldCanvasScript>().HideUI();
            endBattleImage.GetComponent<Animator>().SetTrigger("end");
        }
        else
        {
            if(currentData.GetComponent<CurrentDataScript>().tutorialState == 3)
            {
                canvas.GetComponent<WorldCanvasScript>().HideUI();
                endBattleImage.GetComponent<Animator>().SetTrigger("end");
            }
            else
            {
                //GameOver
            }
        }
    }
    //Function to lvl up the player
    private void LvlUpPlayer(int selection)
    {
        //The player will choose what to upgrade
        if(selection == 0)
        {
            currentData.GetComponent<CurrentDataScript>().playerHeartLvl = currentData.GetComponent<CurrentDataScript>().playerHeartLvl + 1;
            currentData.GetComponent<CurrentDataScript>().playerLvl = currentData.GetComponent<CurrentDataScript>().playerLvl + 1;
        }
        else if(selection == 1)
        {
            currentData.GetComponent<CurrentDataScript>().playerLightLvl = currentData.GetComponent<CurrentDataScript>().playerLightLvl + 1;
            currentData.GetComponent<CurrentDataScript>().playerLvl = currentData.GetComponent<CurrentDataScript>().playerLvl + 1;

        }
        else if(selection == 2)
        {
            currentData.GetComponent<CurrentDataScript>().playerBadgeLvl = currentData.GetComponent<CurrentDataScript>().playerBadgeLvl + 1;
            currentData.GetComponent<CurrentDataScript>().playerLvl = currentData.GetComponent<CurrentDataScript>().playerLvl + 1;
        }
        //We heal and recover all the light points
        player.GetComponent<PlayerTeamScript>().Heal(player.GetComponent<PlayerTeamScript>().GetMaxHealth(), true, firstPosPlayer, true, true);
        player.GetComponent<PlayerTeamScript>().IncreaseLight(player.GetComponent<PlayerTeamScript>().GetMaxLight() , true, true, true);
        if (companion.GetComponent<PlayerTeamScript>().IsDead()) companion.GetComponent<PlayerTeamScript>().Recover(false, true);
        else companion.GetComponent<PlayerTeamScript>().Heal(companion.GetComponent<PlayerTeamScript>().GetMaxHealth(), true, !firstPosPlayer, false, true);
        lvlUpMenu.transform.GetChild(selection).GetComponent<Animator>().SetTrigger("Selected");
        lvlUpSelected = -3;
        //We end the battle
        victory = false;
        currentData.GetComponent<CurrentDataScript>().enemyDied = 1;
        EndBattle(true);
    }
    //Function to create the menu
    private void CreateMenu()
    {
        int number;
        //Player
        if (playerTurn)
        {
            //Sword
            if (selectingAction == 0)
            {
                //We put the default attack
                player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(1).gameObject.SetActive(true);
                player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(1).GetComponent<Image>().color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
                player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(1).transform.GetChild(0).GetComponent<Image>().color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
                player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(1).transform.GetChild(0).GetComponent<Image>().sprite = normalSword;
                player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(1).transform.GetChild(1).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_player_sword_normalsword_name");
                player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(1).transform.GetChild(2).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_player_sword_normalsword_lp");
                menuCanUse[0] = true;
                //We see how many attack have we 
                number = currentData.GetComponent<CurrentDataScript>().swordStyles;
                if (number == 1)
                {
                    player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(2).gameObject.SetActive(true);
                    //We put the unlocked one on the second position and we look if we can use it or not, depending on the light points
                    if (currentData.GetComponent<CurrentDataScript>().lightSword == 1)
                    {
                        swordStyles[0] = 1;
                        player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(2).transform.GetChild(0).GetComponent<Image>().sprite = lightSword;
                        player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(2).transform.GetChild(1).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_player_sword_lightsword_name");
                        player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(2).transform.GetChild(2).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_player_sword_lightsword_lp");
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
                    else if (currentData.GetComponent<CurrentDataScript>().multistrikeSword == 1)
                    {
                        swordStyles[0] = 2;
                        player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(2).transform.GetChild(0).GetComponent<Image>().sprite = multiStrikeSword;
                        player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(2).transform.GetChild(1).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_player_sword_multistrikesword_name");
                        player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(2).transform.GetChild(2).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_player_sword_multistrikesword_lp");
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
                //We repeat the same 
                else if (number == 2)
                {
                    player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(2).gameObject.SetActive(true);
                    player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(3).gameObject.SetActive(true);
                    player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(1).GetComponent<Image>().color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
                    player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(1).transform.GetChild(0).GetComponent<Image>().color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
                    player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(1).transform.GetChild(0).GetComponent<Image>().sprite = normalSword;
                    player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(1).transform.GetChild(1).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_player_sword_normalsword_name");
                    player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(1).transform.GetChild(2).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_player_sword_normalsword_lp");
                    menuCanUse[0] = true;
                    if (currentData.GetComponent<CurrentDataScript>().lightSword == 1)
                    {
                        swordStyles[0] = 1;
                        player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(2).transform.GetChild(0).GetComponent<Image>().sprite = lightSword;
                        player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(2).transform.GetChild(1).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_player_sword_lightsword_name");
                        player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(2).transform.GetChild(2).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_player_sword_lightsword_lp");
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
                    if (currentData.GetComponent<CurrentDataScript>().multistrikeSword == 1)
                    {
                        swordStyles[1] = 2;
                        player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(3).transform.GetChild(0).GetComponent<Image>().sprite = multiStrikeSword;
                        player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(3).transform.GetChild(1).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_player_sword_multistrikesword_name");
                        player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(3).transform.GetChild(2).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_player_sword_multistrikesword_lp");
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
            //Shuriken. We do the same as we did with the sword
            else if (selectingAction == 1)
            {
                player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(1).gameObject.SetActive(true);
                player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(1).GetComponent<Image>().color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
                player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(1).transform.GetChild(0).GetComponent<Image>().color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
                player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(1).transform.GetChild(0).GetComponent<Image>().sprite = normalShuriken;
                player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(1).transform.GetChild(1).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_player_shuriken_normalshuriken_name");
                player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(1).transform.GetChild(2).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_player_shuriken_normalshuriken_lp");
                menuCanUse[0] = true;
                number = currentData.GetComponent<CurrentDataScript>().shurikenStyles;
                if (number == 1)
                {
                    player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(2).gameObject.SetActive(true);
                    if (currentData.GetComponent<CurrentDataScript>().lightShuriken== 1)
                    {
                        shurikenStyles[0] = 1;
                        player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(2).transform.GetChild(0).GetComponent<Image>().sprite = lightShuriken;
                        player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(2).transform.GetChild(1).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_player_shuriken_lightshuriken_name");
                        player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(2).transform.GetChild(2).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_player_shuriken_lightshuriken_lp");
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
                    else if (currentData.GetComponent<CurrentDataScript>().fireShuriken == 1)
                    {
                        shurikenStyles[0] = 2;
                        player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(2).transform.GetChild(0).GetComponent<Image>().sprite = fireShuriken;
                        player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(2).transform.GetChild(1).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_player_shuriken_fireshuriken_name");
                        player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(2).transform.GetChild(2).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_player_shuriken_fireshuriken_lp");
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
                    player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(1).transform.GetChild(1).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_player_shuriken_normalshuriken_name");
                    player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(1).transform.GetChild(2).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_player_shuriken_normalshuriken_lp");
                    menuCanUse[0] = true;
                    if (currentData.GetComponent<CurrentDataScript>().lightShuriken == 1)
                    {
                        shurikenStyles[0] = 1;
                        player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(2).transform.GetChild(0).GetComponent<Image>().sprite = lightShuriken;
                        player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(2).transform.GetChild(1).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_player_shuriken_lightshuriken_name");
                        player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(2).transform.GetChild(2).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_player_shuriken_lightshuriken_lp");
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
                    if (currentData.GetComponent<CurrentDataScript>().fireShuriken == 1)
                    {
                        shurikenStyles[1] = 2;
                        player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(3).transform.GetChild(0).GetComponent<Image>().sprite = fireShuriken;
                        player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(3).transform.GetChild(1).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_player_shuriken_fireshuriken_name");
                        player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(3).transform.GetChild(2).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_player_shuriken_fireshuriken_lp");
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
            //Items
            else if (selectingAction == 2)
            {
                player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(1).GetComponent<Image>().color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
                player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(1).transform.GetChild(0).GetComponent<Image>().color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
                //We can have more than 6 items so we save the scroll to know which items we need to show. When we are at the top or at the bot of the list we make the arrows disappear
                if (scroll > 0) player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(7).GetComponent<Image>().color = new Vector4(player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(7).GetComponent<Image>().color.r, player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(7).GetComponent<Image>().color.g, player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(7).GetComponent<Image>().color.b, 1.0f);
                else player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(7).GetComponent<Image>().color = new Vector4(player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(7).GetComponent<Image>().color.r, player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(7).GetComponent<Image>().color.g, player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(7).GetComponent<Image>().color.b, 0.0f);
                if ((scroll + 6) < currentData.GetComponent<CurrentDataScript>().itemSize()) player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(8).GetComponent<Image>().color = new Vector4(player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(7).GetComponent<Image>().color.r, player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(7).GetComponent<Image>().color.g, player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(7).GetComponent<Image>().color.b, 1.0f);
                else player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(8).GetComponent<Image>().color = new Vector4(player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(7).GetComponent<Image>().color.r, player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(7).GetComponent<Image>().color.g, player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(7).GetComponent<Image>().color.b, 0.0f);
                //We use the scroll variable when we have 6 items or more
                if (currentData.GetComponent<CurrentDataScript>().itemSize() > 5)
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
                            player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(i).transform.GetChild(1).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_item_apple_name");
                            player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(i).transform.GetChild(2).GetComponent<Text>().text = "";
                        }
                        else if (items[i + scroll - 1] == 2)
                        {
                            player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(i).gameObject.SetActive(true);
                            player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(i).transform.GetChild(0).GetComponent<Image>().sprite = lightPotion;
                            player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(i).transform.GetChild(1).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_item_lightpotion_name");
                            player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(i).transform.GetChild(2).GetComponent<Text>().text = "";
                        }
                        else if (items[i + scroll - 1] == 3)
                        {
                            player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(i).gameObject.SetActive(true);
                            player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(i).transform.GetChild(0).GetComponent<Image>().sprite = resurrectPotion;
                            player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(i).transform.GetChild(1).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_item_resurrectionpotion_name");
                            player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(i).transform.GetChild(2).GetComponent<Text>().text = "";
                        }
                    }
                }
                //We dont need to use the scroll when we have less items
                else
                {
                    for (int i = 1; i < 7; i++)
                    {
                        if (i < currentData.GetComponent<CurrentDataScript>().itemSize() + 1)
                        {
                            menuCanUse[i - 1] = true;
                            player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(i).GetComponent<Image>().color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
                            player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(i).transform.GetChild(0).GetComponent<Image>().color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
                            if (items[i - 1] == 1)
                            {
                                player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(i).gameObject.SetActive(true);
                                player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(i).transform.GetChild(0).GetComponent<Image>().sprite = apple;
                                player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(i).transform.GetChild(1).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_item_apple_name");
                                player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(i).transform.GetChild(2).GetComponent<Text>().text = "";
                            }
                            else if (items[i - 1] == 2)
                            {
                                player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(i).gameObject.SetActive(true);
                                player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(i).transform.GetChild(0).GetComponent<Image>().sprite = lightPotion;
                                player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(i).transform.GetChild(1).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_item_lightpotion_name");
                                player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(i).transform.GetChild(2).GetComponent<Text>().text = "";
                            }
                            else if (items[i - 1] == 3)
                            {
                                player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(i).gameObject.SetActive(true);
                                player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(i).transform.GetChild(0).GetComponent<Image>().sprite = resurrectPotion;
                                player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(i).transform.GetChild(1).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_item_resurrectionpotion_name");
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
            //Special
            else if (selectingAction == 3)
            {
                //We put the different attacks depending on the number of souls we have unlocked
                if (currentData.GetComponent<CurrentDataScript>().souls > 0)
                {
                    player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(1).gameObject.SetActive(true);
                    player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(1).transform.GetChild(0).GetComponent<Image>().sprite = music;
                    player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(1).transform.GetChild(1).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_player_special_soulmusic_name");
                    player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(1).transform.GetChild(2).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_player_special_soulmusic_sp");
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
                    if (currentData.GetComponent<CurrentDataScript>().souls > 1)
                    {
                        player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(2).gameObject.SetActive(true);
                        player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(2).transform.GetChild(0).GetComponent<Image>().sprite = regeneration;
                        player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(2).transform.GetChild(1).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_player_special_regeneration_name");
                        player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(2).transform.GetChild(2).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_player_special_regeneration_sp");
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
                        if (currentData.GetComponent<CurrentDataScript>().souls > 2)
                        {
                            player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(3).gameObject.SetActive(true);
                            player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(3).transform.GetChild(0).GetComponent<Image>().sprite = thunder;
                            player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(3).transform.GetChild(1).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_player_special_lightning_name");
                            player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(3).transform.GetChild(2).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_player_special_lightning_sp");
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
                            if (currentData.GetComponent<CurrentDataScript>().souls > 3)
                            {
                                player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(4).gameObject.SetActive(true);
                                player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(4).transform.GetChild(0).GetComponent<Image>().sprite = lifesteal;
                                player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(4).transform.GetChild(1).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_player_special_lifesteal_name");
                                player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(4).transform.GetChild(2).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_player_special_lifesteal_sp");
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
                                if (currentData.GetComponent<CurrentDataScript>().souls > 4)
                                {
                                    player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(5).gameObject.SetActive(true);
                                    player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(5).transform.GetChild(0).GetComponent<Image>().sprite = ghost;
                                    player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(5).transform.GetChild(1).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_player_special_ghost_name");
                                    player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(5).transform.GetChild(2).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_player_special_ghost_sp");
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
                                    if (currentData.GetComponent<CurrentDataScript>().souls > 5)
                                    {
                                        player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(6).gameObject.SetActive(true);
                                        player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(6).transform.GetChild(0).GetComponent<Image>().sprite = lightUp;
                                        player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(6).transform.GetChild(1).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_player_special_lightup_name");
                                        player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(6).transform.GetChild(2).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_player_special_lightup_sp");
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
            //other
            else if (selectingAction == 4)
            {
                //If we arent changing companions
                if (!changeCompanion)
                {
                    //We have 3 different actions: change partner, defend or flee. We can only change partner if we have more than one partner unlocked
                    player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(1).gameObject.SetActive(true);
                    player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(1).transform.GetChild(0).GetComponent<Image>().sprite = partnerChange;
                    player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(1).transform.GetChild(1).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_other_changepartner_name");
                    player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(1).transform.GetChild(2).GetComponent<Text>().text = "";
                    if (currentData.GetComponent<CurrentDataScript>().unlockedCompanions > 1 && !companionTurnCompleted)
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
                    player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(2).gameObject.SetActive(true);
                    player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(2).transform.GetChild(0).GetComponent<Image>().sprite = defend;
                    player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(2).transform.GetChild(1).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_other_defend_name");
                    player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(2).transform.GetChild(2).GetComponent<Text>().text = "";
                    player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(2).GetComponent<Image>().color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
                    player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(2).transform.GetChild(0).GetComponent<Image>().color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
                    menuCanUse[1] = true;
                    player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(3).gameObject.SetActive(true);
                    player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(3).transform.GetChild(0).GetComponent<Image>().sprite = run;
                    player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(3).transform.GetChild(1).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_other_flee_name");
                    player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(3).transform.GetChild(2).GetComponent<Text>().text = "";
                    player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(3).GetComponent<Image>().color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
                    player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(3).transform.GetChild(0).GetComponent<Image>().color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
                    menuCanUse[2] = true;
                    player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(4).gameObject.SetActive(false);
                    player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(5).gameObject.SetActive(false);
                    player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(6).gameObject.SetActive(false);
                }
                //If we are changing partners
                else
                {
                    //We only have 2 partners so we are using one or the other. The one that is being used cant be selected. We can see the current health of all the companions here
                    player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(1).gameObject.SetActive(true);
                    player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(1).transform.GetChild(0).GetComponent<Image>().sprite = adventurerIcon;
                    player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(1).transform.GetChild(1).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_adventurer_name");
                    if (currentCompanion == 0)
                    {
                        currentData.GetComponent<CurrentDataScript>().adventurerCurrentHealth = companion.GetComponent<PlayerTeamScript>().GetHealth();
                        player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(1).GetComponent<Image>().color = new Vector4(0.55f, 0.55f, 0.55f, 1.0f);
                        player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(1).transform.GetChild(0).GetComponent<Image>().color = new Vector4(0.55f, 0.55f, 0.55f, 1.0f);
                        menuCanUse[0] = false;
                    }
                    else
                    {
                        player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(1).GetComponent<Image>().color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
                        player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(1).transform.GetChild(0).GetComponent<Image>().color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
                        menuCanUse[0] = true;
                    }
                    player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(1).transform.GetChild(2).GetComponent<Text>().text = currentData.GetComponent<CurrentDataScript>().adventurerCurrentHealth.ToString() + "/" + (10 + currentData.GetComponent<CurrentDataScript>().adventurerCurrentHealth * 10).ToString();
                    player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(2).gameObject.SetActive(true);
                    player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(2).transform.GetChild(0).GetComponent<Image>().sprite = wizardIcon;
                    player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(2).transform.GetChild(1).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_wizard_name");
                    if (currentCompanion == 1)
                    {
                        currentData.GetComponent<CurrentDataScript>().wizardCurrentHealth = companion.GetComponent<PlayerTeamScript>().GetHealth();
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
                    player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(2).transform.GetChild(2).GetComponent<Text>().text = currentData.GetComponent<CurrentDataScript>().wizardCurrentHealth.ToString() + "/" + (15 + currentData.GetComponent<CurrentDataScript>().wizardCurrentHealth * 10).ToString();
                    player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).transform.GetChild(3).gameObject.SetActive(false);
                }
            }
        }
        //Companion
        else if (companionTurn)
        {
            //Attack
            if(selectingAction == 0)
            {
                //Adventurer
                if(currentCompanion == 0)
                {
                    //We unlock attacks depending on the level of the companion so we will look at it to know if an attack is unlocked or not. The rest works like on the players attacks.
                    companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(1).gameObject.SetActive(true);
                    companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(1).transform.GetChild(0).GetComponent<Image>().sprite = firstSkill;
                    companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(1).transform.GetChild(1).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_adventurer_attack_sword_name");
                    companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(1).transform.GetChild(2).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_adventurer_attack_sword_lp");
                    if (GetGroundEnemies() != null)
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
                    companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(2).transform.GetChild(1).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_adventurer_attack_glance_name");
                    companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(2).transform.GetChild(2).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_adventurer_attack_glance_lp");
                    menuCanUse[1] = true;
                    number = currentData.GetComponent<CurrentDataScript>().adventurerLvl;
                    if (number > 0)
                    {
                        companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(3).gameObject.SetActive(true);
                        companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(3).transform.GetChild(0).GetComponent<Image>().sprite = thirdSkill;
                        companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(3).transform.GetChild(1).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_adventurer_attack_swordspin_name");
                        companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(3).transform.GetChild(2).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_adventurer_attack_swordspin_lp");
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
                    if (number > 1)
                    {
                        companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(4).gameObject.SetActive(true);
                        companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(4).transform.GetChild(0).GetComponent<Image>().sprite = fourthSkill;
                        companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(4).transform.GetChild(1).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_adventurer_attack_dragonslayerbow_name");
                        companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(4).transform.GetChild(2).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_adventurer_attack_dragonslayerbow_lp");
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
                        companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(5).transform.GetChild(1).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_adventurer_attack_bk-47_name");
                        companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(5).transform.GetChild(2).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_adventurer_attack_bk-47_lp");
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
                //Wizard
                else if(currentCompanion == 1)
                {
                    //We unlock attacks depending on the level of the companion so we will look at it to know if an attack is unlocked or not. The rest works like on the players attacks.
                    companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(1).gameObject.SetActive(true);
                    companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(1).transform.GetChild(0).GetComponent<Image>().sprite = firstSkill;
                    companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(1).transform.GetChild(1).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_wizard_attack_magicball_name");
                    companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(1).transform.GetChild(2).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_wizard_attack_magicball_lp");
                    menuCanUse[0] = true;
                    companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(1).GetComponent<Image>().color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
                    companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(1).transform.GetChild(0).GetComponent<Image>().color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
                    if (lightPointsUI.GetComponent<LightPointsScript>().CanUseHability(1))
                    {
                        companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(2).gameObject.SetActive(true);
                        companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(2).GetComponent<Image>().color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
                        companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(2).transform.GetChild(0).GetComponent<Image>().color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
                        menuCanUse[1] = true;
                    }
                    else
                    {
                        companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(2).gameObject.SetActive(true);
                        companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(2).GetComponent<Image>().color = new Vector4(0.55f, 0.55f, 0.55f, 1.0f);
                        companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(2).transform.GetChild(0).GetComponent<Image>().color = new Vector4(0.55f, 0.55f, 0.55f, 1.0f);
                        menuCanUse[1] = false;
                    }
                    companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(2).transform.GetChild(0).GetComponent<Image>().sprite = secondSkill;
                    companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(2).transform.GetChild(1).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_wizard_attack_barrier_name");
                    companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(2).transform.GetChild(2).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_wizard_attack_barrier_lp");
                    number = currentData.GetComponent<CurrentDataScript>().wizardLvl;
                    if (number > 0)
                    {
                        companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(3).gameObject.SetActive(true);
                        companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(3).transform.GetChild(0).GetComponent<Image>().sprite = thirdSkill;
                        companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(3).transform.GetChild(1).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_wizard_attack_pulsingmagic_name");
                        companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(3).transform.GetChild(2).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_wizard_attack_pulsingmagic_lp");
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
                    if (number > 1)
                    {
                        companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(4).gameObject.SetActive(true);
                        companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(4).transform.GetChild(0).GetComponent<Image>().sprite = fourthSkill;
                        companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(4).transform.GetChild(1).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_wizard_attack_magicspear_name");
                        companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(4).transform.GetChild(2).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_wizard_attack_magicspear_lp");
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
                        companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(5).transform.GetChild(1).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_wizard_attack_energybomb_name");
                        companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(5).transform.GetChild(2).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_wizard_attack_energybomb_lp");
                        if (!lightPointsUI.GetComponent<LightPointsScript>().CanUseHability(9))
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
            }
            //Items
            else if (selectingAction == 1)
            {
                //All the team members have the same items, so it is the same as the players items.
                companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(1).GetComponent<Image>().color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
                companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(1).transform.GetChild(0).GetComponent<Image>().color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
                if (scroll > 0) companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(7).GetComponent<Image>().color = new Vector4(companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(7).GetComponent<Image>().color.r, companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(7).GetComponent<Image>().color.g, companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(7).GetComponent<Image>().color.b, 1.0f);
                else companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(7).GetComponent<Image>().color = new Vector4(companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(7).GetComponent<Image>().color.r, companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(7).GetComponent<Image>().color.g, companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(7).GetComponent<Image>().color.b, 0.0f);
                if ((scroll + 6) == currentData.GetComponent<CurrentDataScript>().itemSize()) companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(8).GetComponent<Image>().color = new Vector4(companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(7).GetComponent<Image>().color.r, companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(7).GetComponent<Image>().color.g, companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(7).GetComponent<Image>().color.b, 0.0f);
                else companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(8).GetComponent<Image>().color = new Vector4(companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(7).GetComponent<Image>().color.r, companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(7).GetComponent<Image>().color.g, companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(7).GetComponent<Image>().color.b, 1.0f);
                if (currentData.GetComponent<CurrentDataScript>().itemSize() > 5)
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
                            companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(i).transform.GetChild(1).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_item_apple_name");
                            companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(i).transform.GetChild(2).GetComponent<Text>().text = "";
                        }
                        else if (items[i + scroll - 1] == 2)
                        {
                            companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(i).gameObject.SetActive(true);
                            companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(i).transform.GetChild(0).GetComponent<Image>().sprite = lightPotion;
                            companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(i).transform.GetChild(1).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_item_lightpotion_name");
                            companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(i).transform.GetChild(2).GetComponent<Text>().text = "";
                        }
                        else if (items[i + scroll - 1] == 3)
                        {
                            companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(i).gameObject.SetActive(true);
                            companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(i).transform.GetChild(0).GetComponent<Image>().sprite = resurrectPotion;
                            companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(i).transform.GetChild(1).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_item_resurrectionpotion_name");
                            companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(i).transform.GetChild(2).GetComponent<Text>().text = "";
                        }
                    }
                }
                else
                {
                    for (int i = 1; i < 7; i++)
                    {
                        if (i < currentData.GetComponent<CurrentDataScript>().itemSize() + 1)
                        {
                            menuCanUse[i - 1] = true;
                            companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(i).GetComponent<Image>().color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
                            companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(i).transform.GetChild(0).GetComponent<Image>().color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
                            if (items[i - 1] == 1)
                            {
                                companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(i).gameObject.SetActive(true);
                                companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(i).transform.GetChild(0).GetComponent<Image>().sprite = apple;
                                companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(i).transform.GetChild(1).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_item_apple_name");
                                companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(i).transform.GetChild(2).GetComponent<Text>().text = "";
                            }
                            else if (items[i - 1] == 2)
                            {
                                companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(i).gameObject.SetActive(true);
                                companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(i).transform.GetChild(0).GetComponent<Image>().sprite = lightPotion;
                                companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(i).transform.GetChild(1).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_item_lightpotion_name");
                                companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(i).transform.GetChild(2).GetComponent<Text>().text = "";
                            }
                            else if (items[i - 1] == 3)
                            {
                                companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(i).gameObject.SetActive(true);
                                companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(i).transform.GetChild(0).GetComponent<Image>().sprite = resurrectPotion;
                                companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(i).transform.GetChild(1).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_item_resurrectionpotion_name");
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
            //change companion. Identical to the players version.
            else if (selectingAction == 2)
            {
                if (!changeCompanion)
                {
                    companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(1).gameObject.SetActive(true);
                    companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(1).transform.GetChild(0).GetComponent<Image>().sprite = partnerChange;
                    companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(1).transform.GetChild(1).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_other_changepartner_name");
                    companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(1).transform.GetChild(2).GetComponent<Text>().text = "";
                    if (currentData.GetComponent<CurrentDataScript>().unlockedCompanions > 1)
                    {
                        companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(1).GetComponent<Image>().color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
                        companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(1).transform.GetChild(0).GetComponent<Image>().color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
                        menuCanUse[0] = true;
                    }
                    else
                    {
                        companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(1).GetComponent<Image>().color = new Vector4(0.55f, 0.55f, 0.55f, 1.0f);
                        companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(1).transform.GetChild(0).GetComponent<Image>().color = new Vector4(0.55f, 0.55f, 0.55f, 1.0f);
                        menuCanUse[0] = false;
                    }
                    companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(2).gameObject.SetActive(true);
                    companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(2).transform.GetChild(0).GetComponent<Image>().sprite = defend;
                    companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(2).transform.GetChild(1).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_other_defend_name");
                    companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(2).transform.GetChild(2).GetComponent<Text>().text = "";
                    companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(2).GetComponent<Image>().color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
                    companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(2).transform.GetChild(0).GetComponent<Image>().color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
                    menuCanUse[1] = true;
                    companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(3).gameObject.SetActive(true);
                    companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(3).transform.GetChild(0).GetComponent<Image>().sprite = run;
                    companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(3).transform.GetChild(1).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_other_flee_name");
                    companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(3).transform.GetChild(2).GetComponent<Text>().text = "";
                    companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(3).GetComponent<Image>().color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
                    companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(3).transform.GetChild(0).GetComponent<Image>().color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
                    menuCanUse[2] = true;
                    companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(4).gameObject.SetActive(false);
                    companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(5).gameObject.SetActive(false);
                    companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(6).gameObject.SetActive(false);
                }
                else
                {
                    companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(1).gameObject.SetActive(true);
                    companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(1).transform.GetChild(0).GetComponent<Image>().sprite = adventurerIcon;
                    companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(1).transform.GetChild(1).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_adventurer_name");
                    if (currentCompanion == 0)
                    {
                        currentData.GetComponent<CurrentDataScript>().adventurerCurrentHealth = companion.GetComponent<PlayerTeamScript>().GetHealth();
                        companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(1).GetComponent<Image>().color = new Vector4(0.55f, 0.55f, 0.55f, 1.0f);
                        companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(1).transform.GetChild(0).GetComponent<Image>().color = new Vector4(0.55f, 0.55f, 0.55f, 1.0f);
                        menuCanUse[0] = false;
                    }
                    else
                    {
                        companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(1).GetComponent<Image>().color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
                        companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(1).transform.GetChild(0).GetComponent<Image>().color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
                        menuCanUse[0] = true;
                    }
                    companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(1).transform.GetChild(2).GetComponent<Text>().text = currentData.GetComponent<CurrentDataScript>().adventurerCurrentHealth.ToString() + "/" + (10 + currentData.GetComponent<CurrentDataScript>().adventurerCurrentHealth * 10).ToString();
                    companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(2).gameObject.SetActive(true);
                    companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(2).transform.GetChild(0).GetComponent<Image>().sprite = wizardIcon;
                    companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(2).transform.GetChild(1).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_wizard_name");
                    if (currentCompanion == 1)
                    {
                        currentData.GetComponent<CurrentDataScript>().wizardCurrentHealth = companion.GetComponent<PlayerTeamScript>().GetHealth();
                        companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(2).GetComponent<Image>().color = new Vector4(0.55f, 0.55f, 0.55f, 1.0f);
                        companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(2).transform.GetChild(0).GetComponent<Image>().color = new Vector4(0.55f, 0.55f, 0.55f, 1.0f);
                        companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(3).gameObject.SetActive(false);
                        menuCanUse[1] = false;
                    }
                    else
                    {
                        companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(2).GetComponent<Image>().color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
                        companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(2).transform.GetChild(0).GetComponent<Image>().color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
                        companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(3).gameObject.SetActive(false);
                        menuCanUse[1] = true;
                    }
                    companion.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.GetChild(2).transform.GetChild(2).GetComponent<Text>().text = currentData.GetComponent<CurrentDataScript>().wizardCurrentHealth.ToString() + "/" + (15 + currentData.GetComponent<CurrentDataScript>().wizardCurrentHealth * 10).ToString();
                }
            }
        }
    }
}