using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerTeamScript : MonoBehaviour
{
    //The prefab of the shuriken
    [SerializeField] private Transform shurikenPrefab;
    //The prefab of the light shuriken
    [SerializeField] private Transform lightShurikenPrefab;
    //The prefab of the fire shuriken
    [SerializeField] private Transform fireShurikenPrefab;
    //The prefab of the magic ball
    [SerializeField] private Transform magicBallPrefab;
    //The prefab of the magic spear
    [SerializeField] private Transform magicSpearPrefab;    
    //The prefab of the arrow
    [SerializeField] private Transform arrow;
    //The prefab of the damage, heart and light UI
    [SerializeField] private Transform damageUI;
    [SerializeField] private Transform heartUI;
    [SerializeField] private Transform lightUI;
    [SerializeField] private Material shadowMaterial;
    [SerializeField] private Material transparentMaterial;

    //The canvas
    private GameObject canvas;
    //The life points UI
    private GameObject lightPointsUI;
    //The shuriken
    private Transform shuriken;
    //The damage, heart and light images
    private Transform damageImage;
    private Transform heartImage;
    private Transform lightImage;
    //The attack style
    private int attackStyle;
    //The objective of the shuriken
    public Vector3 shurikenObjective;
    //The battle controller
    private GameObject battleController;
    //The player life
    private GameObject playerLife;
    //The companion life
    private GameObject companionLife;
    //The damage the shuriken will do
    private int shurikenDamage;
    //A boolean to check if it is the las attack
    private bool lastAttack;
    //The type of the player team user. 0-> Player, 1-> adventurer, 2-> wizard
    public int playerTeamType; 
    //The start position
    private float startPos;
    //The move position
    private float movePos;
    //A bool to check if the player is moving towards the enemy
    private bool movingToEnemy;
    //A bool to check if the player is moving towards an ally
    private bool movingToAlly;
    //A bool to check if the player is returning to the start position
    private bool returnStartPos;
    //A bool to check if the player is returning to the start position from an ally
    private bool returnStartPosAlly;
    //Boolean to check if we are on the state where the soul light goes up
    private bool soulLightUp;
    //Boolean to check if we are on the state where the soul light goes down
    private bool soulLightDown;
    //The soul music action gameobject
    private GameObject soulMusicAction;
    //The soul light gameobject
    private GameObject soulLight;
    //The objective of the attack
    private Transform attackObjective;
    //The attack speed
    private float attackSpeed;
    //int to know the end lvl of the soul attack
    private int soulLvl;
    //An int to see for how many rounds is the player asleep
    private int asleep;
    //The gameobject of the buffDebuff UI
    private GameObject buffDebuffUI;
    //An int to see for how many rounds has lifesteal the player
    private int lifesteal;
    //The position of the lifesteal buff
    private int lifestealPos;
    //An int to see for how many rounds has invisibility the player
    private int disappear;
    //The position of the invisibility buff
    private int disappearPos;
    //An int to know the power of the light up buff
    private int lightUp;
    //The position of the light up buff
    private int lightUpPos;
    //An int to see the number of buffs or debuffs
    private int buffDebuffNumb;
    //The position of the slep debuff
    private int sleepPos;
    //The sprite of the sleepUI
    [SerializeField] private Sprite sleepSprite;
    //The sprite of the lifestealUI
    [SerializeField] private Sprite lifestealSprite;
    //The sprite of the disappearUI
    [SerializeField] private Sprite disappearSprite;
    //The sprite of the lightUpUI
    [SerializeField] private Sprite lightUpSprite;
    //The prefab of the glance action
    [SerializeField] private Transform glanceActionPrefab;
    private Transform glanceAction;
    //The number of arrows shot by the BK47
    private int arrowNumb;
    //A boolean to know if the player has recovered
    private bool recovered;
    //Booleans to know if the companion is going out or in
    private bool companionOut;
    private bool companionIn;
    private int enteringCompanion;
    //The prefab of the explosion
    [SerializeField] private Transform explosionPrefab;
    private Transform explosion;
    //An int to know the current extra damage of the repeating attack (player or adventurer)
    private int repeatingDamage;
    //The audio source
    private AudioSource source;
    //The audios of the player
    [SerializeField] private AudioClip playerNormalSwordAudio;
    [SerializeField] private AudioClip playerSwordLightAudio;
    [SerializeField] private AudioClip playerTakeDamageAudio;
    [SerializeField] private AudioClip playerDefendDamageAudio;
    [SerializeField] private AudioClip playerDieAudio;
    [SerializeField] private AudioClip playerShurikenAudio;
    [SerializeField] private AudioClip playerSoulAudio;
    //The audios of the adventurer
    [SerializeField] private AudioClip adventurerNormalSwordAudio;
    [SerializeField] private AudioClip adventurerGlanceAudio;
    [SerializeField] private AudioClip adventurerBowAudio;
    [SerializeField] private AudioClip adventurerTakeDamageAudio;
    [SerializeField] private AudioClip adventurerDefendDamageAudio;
    [SerializeField] private AudioClip adventurerDieAudio;
    //The audios of the wizard
    [SerializeField] private AudioClip wizardMagicAudio;
    [SerializeField] private AudioClip wizardBarrierAudio;
    [SerializeField] private AudioClip wizardLaserAudio;
    [SerializeField] private AudioClip wizardExplosionAudio;
    [SerializeField] private AudioClip wizardTakeDamageAudio;
    [SerializeField] private AudioClip wizardDefendDamageAudio;
    [SerializeField] private AudioClip wizardDieAudio;

    //The text of the UI that we are going to translate
    private Text playerSwordText;
    private Text playerShurikenText;
    private Text playerItemsText;
    private Text playerSpecialText;
    private Text playerOtherText;
    private Text companionAttackText;
    private Text companionItemsText;
    private Text companionOtherText;
    //The current data
    private GameObject currentData;

    void Awake()
    {
        currentData = GameObject.Find("CurrentData");
        //We find the gameobjects and initialize some variables
        lightPointsUI = GameObject.Find("LightBckImage");
        battleController = GameObject.Find("BattleController");
        playerLife = GameObject.Find("PlayerLifeBckImage");
        companionLife = GameObject.Find("CompanionLifeBckImage");
        if (playerTeamType == 0) soulLight = transform.GetChild(3).gameObject;
        if (playerTeamType == 0) soulMusicAction = GameObject.Find("SoulMusicAction");
        canvas = GameObject.Find("Canvas");
        buffDebuffUI = transform.GetChild(0).Find("BuffsDebuffs").gameObject;
        buffDebuffUI.transform.GetChild(0).gameObject.SetActive(false);
        buffDebuffUI.transform.GetChild(1).gameObject.SetActive(false);
        buffDebuffUI.transform.GetChild(2).gameObject.SetActive(false);
        buffDebuffUI.transform.GetChild(3).gameObject.SetActive(false);
        if (playerTeamType == 0) soulMusicAction.SetActive(false);
        lastAttack = false;
        movingToEnemy = false;
        movingToAlly = false;
        returnStartPos = false;
        returnStartPosAlly = false;
        soulLightUp = false;
        asleep = 0;
        lifesteal = 0;
        disappear = 0;
        lightUp = 0;
        attackSpeed = 1.0f;
        arrowNumb = 0;
        recovered = true;
        companionOut = false;
        companionIn = false;
        repeatingDamage = 0;
        source = transform.Find("partyAudio").GetComponent<AudioSource>();
        //We find the texts
        if(playerTeamType == 0)
        {
            playerSwordText = GameObject.Find("SwordActionImageText").GetComponent<Text>();
            playerShurikenText = GameObject.Find("ShurikenActionImageText").GetComponent<Text>();
            playerItemsText = GameObject.Find("ConsumablesActionImageText").GetComponent<Text>();
            playerSpecialText = GameObject.Find("SpecialActionImageText").GetComponent<Text>();
            playerOtherText = GameObject.Find("OtherActionImageText").GetComponent<Text>();
        }
        else
        {
            companionAttackText = GameObject.Find("AttackActionImageText").GetComponent<Text>();
            companionItemsText = GameObject.Find("ConsumablesActionImageText").GetComponent<Text>();
            companionOtherText = GameObject.Find("OtherActionImageText").GetComponent<Text>();
        }        
        //We translate the texts
        if (currentData.GetComponent<CurrentDataScript>().language == 1)
        {
            if (playerTeamType == 0)
            {
                playerSwordText.text = "Sword";
                playerShurikenText.text = "Shuriken";
                playerItemsText.text = "Items";
                playerSpecialText.text = "Special";
                playerOtherText.text = "Other";
            }
            else
            {
                companionAttackText.text = "Attack";
                companionItemsText.text = "Items";
                companionOtherText.text = "Other";
            }
        }
        else if (currentData.GetComponent<CurrentDataScript>().language == 2)
        {
            if (playerTeamType == 0)
            {
                playerSwordText.text = "Espada";
                playerShurikenText.text = "Shuriken";
                playerItemsText.text = "Objetos";
                playerSpecialText.text = "Especial";
                playerOtherText.text = "Otros";
            }
            else
            {
                companionAttackText.text = "Atacar";
                companionItemsText.text = "Objetos";
                companionOtherText.text = "Otros";
            }
        }
        else
        {
            if (playerTeamType == 0)
            {
                playerSwordText.text = "Ezpata";
                playerShurikenText.text = "Shuriken";
                playerItemsText.text = "Objektuak";
                playerSpecialText.text = "Berezia";
                playerOtherText.text = "Bestelakoak";
            }
            else
            {
                companionAttackText.text = "Eraso";
                companionItemsText.text = "Objektuak";
                companionOtherText.text = "Bestelakoak";
            }
        }
    }
    private void Start()
    {
        //We set the user
        if (playerTeamType == 0) playerLife.GetComponent<PlayerLifeScript>().SetUser(0);
        else
        {
            companionLife.GetComponent<PlayerLifeScript>().SetUser(playerTeamType);
            if (IsDead()) GetComponent<Animator>().SetBool("spawnDead", true);
        }
    }


    void FixedUpdate()
    {
        //The player moves to the enemy to attack it
        if (movingToEnemy)
        {
            if (transform.position.x < movePos)
            {
                transform.position = new Vector3(transform.position.x + 0.10f, transform.position.y, transform.position.z);
                if (playerTeamType == 0) GetComponent<Animator>().SetFloat("Speed", 0.5f);
                else if (playerTeamType == 1 || playerTeamType == 2)
                {
                    GetComponent<Animator>().SetFloat("RunSpeed", 0.5f);
                    GetComponent<Animator>().SetFloat("Speed", 1.0f);
                }
            }
            //When they arrive the attack starts
            else
            {
                transform.position = new Vector3(movePos, transform.position.y, transform.position.z);
                if (playerTeamType == 0) GetComponent<Animator>().SetFloat("Speed", 0.0f);
                else if (playerTeamType == 1)
                {
                    GetComponent<Animator>().SetTrigger("Melee1");
                    GetComponent<Animator>().SetFloat("RunSpeed", 0.0f);
                }
                else if (playerTeamType == 2) GetComponent<Animator>().SetFloat("RunSpeed", 0.0f);
                movingToEnemy = false;
                if (playerTeamType == 0 && attackStyle == 1)
                {
                    gameObject.transform.GetChild(0).transform.GetChild(2).GetComponent<Animator>().SetBool("active", true);
                    gameObject.GetComponent<Animator>().SetTrigger("statChargeLightMelee");
                }
                else if (playerTeamType == 2)
                {
                    if(attackStyle == 2) gameObject.GetComponent<Animator>().SetBool("magicBall", true);
                    else if(attackStyle == 4) gameObject.GetComponent<Animator>().SetBool("Explode", true);
                }
                if(playerTeamType != 2) battleController.GetComponent<BattleController>().finalAttack = true;
            }
        }
        //The player returns to the start position after attacking
        else if (returnStartPos)
        {
            if (transform.position.x > startPos)
            {
                if ((attackStyle == 0 || attackStyle == 2) && playerTeamType !=2)
                {
                    attackObjective.GetChild(0).transform.GetChild(1).gameObject.GetComponent<Animator>().SetBool("Pressed", false);
                    attackObjective.GetChild(0).transform.GetChild(1).gameObject.SetActive(false);
                }
                transform.position = new Vector3(transform.position.x - 0.15f, transform.position.y, transform.position.z);
                if (playerTeamType == 0) GetComponent<Animator>().SetFloat("Speed", -0.5f);
                else if (playerTeamType == 1 || playerTeamType == 2) GetComponent<Animator>().SetFloat("RunSpeed", -0.5f);
            }
            //When they arrive the attack ends
            else
            {
                transform.position = new Vector3(startPos, transform.position.y, transform.position.z);
                battleController.GetComponent<BattleController>().attackFinished = false;
                if (playerTeamType == 0) GetComponent<Animator>().SetFloat("Speed", 0.0f);
                else if (playerTeamType == 1 || playerTeamType == 2) GetComponent<Animator>().SetFloat("RunSpeed", 0.0f);
                returnStartPos = false;
                if (playerTeamType == 0) battleController.GetComponent<BattleController>().EndPlayerTurn(1);
                else if (playerTeamType == 1 || playerTeamType == 2) battleController.GetComponent<BattleController>().EndPlayerTurn(2);
            }
        }
        //The wizard moves to the player to put the barrier
        if (movingToAlly)
        {
            //We look the position of the player to know where to move the wizard
            if (battleController.GetComponent<BattleController>().IsPlayerFirst())
            {
                if (transform.position.x < movePos)
                {
                    transform.position = new Vector3(transform.position.x + 0.05f, transform.position.y, transform.position.z);
                    if (playerTeamType == 2)
                    {
                        GetComponent<Animator>().SetFloat("RunSpeed", 0.5f);
                        GetComponent<Animator>().SetFloat("Speed", 1.0f);
                    }
                }
                else
                {
                    transform.position = new Vector3(movePos, transform.position.y, transform.position.z);
                    GetComponent<Animator>().SetFloat("RunSpeed", 0.0f);
                    movingToAlly = false;
                    if (playerTeamType == 2 && attackStyle == 1) GetComponent<Animator>().SetBool("isDefending", true);                    
                    battleController.GetComponent<BattleController>().finalAttack = true;
                    battleController.GetComponent<BattleController>().CreateBarrierAction();
                }
            }
            else
            {
                if (transform.position.x > movePos)
                {
                    transform.position = new Vector3(transform.position.x - 0.05f, transform.position.y, transform.position.z);
                    if (playerTeamType == 2)
                    {
                        GetComponent<Animator>().SetFloat("RunSpeed", -0.5f);
                        GetComponent<Animator>().SetFloat("Speed", 1.0f);
                    }
                }
                else
                {
                    transform.position = new Vector3(movePos, transform.position.y, transform.position.z);
                    GetComponent<Animator>().SetFloat("RunSpeed", 0.0f);
                    movingToAlly = false;
                    if(playerTeamType == 2 && attackStyle == 1) GetComponent<Animator>().SetBool("isDefending", true);
                    battleController.GetComponent<BattleController>().finalAttack = true;
                    battleController.GetComponent<BattleController>().CreateBarrierAction();
                }
            }
        }
        //The wizard returns to the start position
        else if (returnStartPosAlly)
        {
            if (battleController.GetComponent<BattleController>().IsPlayerFirst())
            {
                if (transform.position.x > startPos)
                {
                    transform.position = new Vector3(transform.position.x - 0.05f, transform.position.y, transform.position.z);
                    if (playerTeamType == 2)
                    {
                        GetComponent<Animator>().SetFloat("RunSpeed", -0.5f);
                        GetComponent<Animator>().SetFloat("Speed", 1.0f);
                    }
                }
                else
                {
                    transform.position = new Vector3(startPos, transform.position.y, transform.position.z);
                    GetComponent<Animator>().SetFloat("RunSpeed", 0.0f);
                    returnStartPosAlly = false;
                    if(!IsDead()) battleController.GetComponent<BattleController>().EndPlayerTurn(2);
                }
            }
            else
            {
                if (transform.position.x < startPos)
                {
                    transform.position = new Vector3(transform.position.x + 0.05f, transform.position.y, transform.position.z);
                    if (playerTeamType == 2)
                    {
                        GetComponent<Animator>().SetFloat("RunSpeed", 0.5f);
                        GetComponent<Animator>().SetFloat("Speed", 1.0f);
                    }
                }
                else
                {
                    transform.position = new Vector3(startPos, transform.position.y, transform.position.z);
                    GetComponent<Animator>().SetFloat("RunSpeed", 0.0f);
                    returnStartPosAlly = false;
                    if(!IsDead()) battleController.GetComponent<BattleController>().EndPlayerTurn(2);
                }
            }
        }
        //Companion change
        if (companionOut)
        {
            //We move the companion out of the camera view
            if (transform.position.x > -9.0f)
            {
                transform.position = new Vector3(transform.position.x - 0.1f, transform.position.y, transform.position.z);
                GetComponent<Animator>().SetFloat("RunSpeed", -0.5f);
                GetComponent<Animator>().SetFloat("Speed", 1.0f);
            }
            //We spawn the other companion out of camera view
            else
            {
                battleController.GetComponent<BattleController>().SpawnCharacter(-1, enteringCompanion);
                Destroy(gameObject);
            }
        }
        //The companion moves to their position
        else if (companionIn)
        {
            if(battleController.GetComponent<BattleController>().IsPlayerFirst() && transform.position.x < -6.4f)
            {
                transform.position = new Vector3(transform.position.x + 0.1f, transform.position.y, transform.position.z);
                GetComponent<Animator>().SetFloat("RunSpeed", 0.5f);
                GetComponent<Animator>().SetFloat("Speed", 1.0f);
            }
            else if (!battleController.GetComponent<BattleController>().IsPlayerFirst() && transform.position.x < -5.0f)
            {
                transform.position = new Vector3(transform.position.x + 0.1f, transform.position.y, transform.position.z);
                GetComponent<Animator>().SetFloat("RunSpeed", 0.5f);
                GetComponent<Animator>().SetFloat("Speed", 1.0f);
            }
            else
            {
                companionIn = false;
                if(battleController.GetComponent<BattleController>().IsPlayerFirst()) battleController.GetComponent<BattleController>().EndPlayerTurn(1);
                else battleController.GetComponent<BattleController>().EndPlayerTurn(2);
                GetComponent<Animator>().SetFloat("RunSpeed", 0.0f);
            }
        }
        //Soul light going up
        if (soulLightUp && soulLight.transform.position.y < 75.0f)
        {
            soulLight.transform.position = new Vector3(soulLight.transform.position.x, soulLight.transform.position.y + 0.5f, soulLight.transform.position.z);
        }
        else if(soulLightUp && soulLight.transform.position.y >= 75.0f)
        {
            //Soul music
            if(attackStyle == 0)
            {
                soulMusicAction.SetActive(true);
                soulLightUp = false;
                battleController.GetComponent<BattleController>().StartSoulMusicAttack(1);
            }
            //Regeneration
            else if(attackStyle == 1)
            {
                soulLightUp = false;
                battleController.GetComponent<BattleController>().StartRegenerationAttack();
            }
            //Lightning
            else if(attackStyle == 2)
            {
                soulLightUp = false;
                battleController.GetComponent<BattleController>().StartLightningAttack();
            }
            //Lifesteal
            else if(attackStyle == 3)
            {
                soulLightUp = false;
                battleController.GetComponent<BattleController>().StartLifestealAttack();
            }
            //Dissapear
            else if (attackStyle == 4)
            {
                soulLightUp = false;
                battleController.GetComponent<BattleController>().StartDisappearAttack();
            }
            //LightUp
            else if (attackStyle == 5)
            {
                soulLightUp = false;
                battleController.GetComponent<BattleController>().StartLightUpAttack();
            }
        }
        //Soul light going down
        if (soulLightDown && soulLight.transform.position.y > -2.0f)
        {
            soulLight.transform.position = new Vector3(soulLight.transform.position.x, soulLight.transform.position.y - 0.5f, soulLight.transform.position.z);
        }
        //When the light arrives we end the correspondent attack
        else if(soulLightDown && soulLight.transform.position.y <= -2.0f)
        {
            GetComponent<Animator>().SetBool("soulAttack", false);
            soulLightDown = false;
            if (attackStyle == 0) battleController.GetComponent<BattleController>().EndSoulAttack(soulLvl);
            else if (attackStyle == 1) battleController.GetComponent<BattleController>().EndSoulRegenerationAttack();
            else if (attackStyle == 2) battleController.GetComponent<BattleController>().EndSoulLightningAttack();
            else if (attackStyle == 3) battleController.GetComponent<BattleController>().EndSoulLifestealAttack();
            else if (attackStyle == 4) battleController.GetComponent<BattleController>().EndSoulDisappearAttack();
            else if (attackStyle == 5) battleController.GetComponent<BattleController>().EndSoulLightUpAttack();
        }
    }
    //A function to make the barrier sound
    public void BarrierSound()
    {
        source.clip = wizardBarrierAudio;
        source.Play();
    }
    //A function to make the magic sound
    public void MagicSound()
    {
        source.clip = wizardMagicAudio;
        source.Play();
    }
    //A function to end the soul attack
    public void EndSoulAttack(int lvl)
    {
        source.clip = playerSoulAudio;
        source.Play();
        soulMusicAction.SetActive(false);
        soulLightDown = true;
        soulLvl = lvl;
    }
    //A function to end the regeneration attack
    public void EndRegenerationAttack()
    {
        source.clip = playerSoulAudio;
        source.Play();
        soulLightDown = true;
    }
    //A function to end the lightning attack
    public void EndLightningAttack()
    {
        source.clip = playerSoulAudio;
        source.Play();
        soulLightDown = true;
    }

    //A function to end the lifesteal attack
    public void EndLifestealAttack()
    {
        source.clip = playerSoulAudio;
        source.Play();
        soulLightDown = true;
    }
    //A function to end the disappear attack
    public void EndDisappearAttack()
    {
        source.clip = playerSoulAudio;
        source.Play();
        soulLightDown = true;
    }
    //A function to end the light up attack
    public void EndLightUpAttack()
    {
        source.clip = playerSoulAudio;
        source.Play();
        soulLightDown = true;
    }
    //A function to change the companion
    public void ChangeCompanion(int comp)
    {
        companionOut = true;
        enteringCompanion = comp;
    }

    //A function to set the companion entering the battle
    public void SetEnter()
    {
        companionIn = true;
    }

    //Function to set the amount of time the player will be asleep
    public void SetAsleepTime(int lvl)
    {
        int duration;
        float rand;
        duration = Mathf.FloorToInt((lvl - 1) / 2.0f);
        rand = ((lvl - 1) / 2.0f) - Mathf.FloorToInt((lvl - 1) / 2.0f);
        if (rand >= Random.Range(0.0f, 1.0f)) duration += 1;
        if (duration > 0) SetBuffDebuff(0, duration);
    }
    //Function to set the amount of time the player will have lifesteal
    public void SetLifestealTime(int lvl)
    {
        int duration = 0;
        if (lvl < 4) duration = 1;
        else if (lvl < 7) duration = 2;
        else if (lvl < 10) duration = 3;
        else if (lvl == 10) duration = 4;
        attackObjective.GetComponent<PlayerTeamScript>().SetBuffDebuff(1, duration);
    }    
    //Function to see if the player has lifesteal
    public bool HasLifesteal()
    {
        return lifesteal > 0;
    }
    //Function to set the amount of time the player will be invisible
    public void SetDisappearTime(float alpha)
    {
        attackObjective.GetComponent<SpriteRenderer>().color = new Color(attackObjective.GetComponent<SpriteRenderer>().color.r, attackObjective.GetComponent<SpriteRenderer>().color.g, attackObjective.GetComponent<SpriteRenderer>().color.b, 0.5f);
        attackObjective.GetComponent<SpriteRenderer>().material = transparentMaterial;
        int duration;
        if (alpha > 0.5f) duration = 1;
        else if (alpha > 0.05f) duration = 2;
        else duration = 3;
        attackObjective.GetComponent<PlayerTeamScript>().SetBuffDebuff(2, duration);
    }
    //Function to set the Light Up power
    public void SetLightUpPower(float lvl)
    {
        attackObjective.GetComponent<PlayerTeamScript>().SetBuffDebuff(3, (int)((lvl - 1.0f) * 2.0f));
    }
    //Function to see if the player is visible
    public bool IsInvisible()
    {
        return disappear > 0;
    }
    //Function to get the light up power
    public int GetLightUpPower()
    {
        return lightUp;
    }

    //Function to make the wizard return to the start position after
    public void ReturnStartPosWizard()
    {
        returnStartPosAlly = true;
    }

    //Function to make the player return to the start position
    public void ReturnStartPos()
    {
        returnStartPos = true;
    }
    //A function to put a buff or a debuff in the UI. buffDeb = 0 -> Sleep, buffDeb = 1 -> lifesteal, buffDeb = 2 -> invisible
    public void SetBuffDebuff(int buffDeb, int duration)
    {
        //Sleep
        if (buffDeb == 0)
        {
            if (asleep == 0)
            {
                //We put the new debuff in a new position depending on the current number of buffs or debuffs
                sleepPos = 3 - buffDebuffNumb;
                //We save the duration
                asleep = duration;
                buffDebuffUI.transform.GetChild(sleepPos).gameObject.SetActive(true);
                buffDebuffUI.transform.GetChild(sleepPos).GetChild(0).GetComponent<Image>().sprite = sleepSprite;
                buffDebuffUI.transform.GetChild(sleepPos).GetChild(1).GetComponent<Text>().text = asleep.ToString();
                //We add one to the number of buffs and debuffs
                buffDebuffNumb += 1;
            }
            else
            {
                asleep += duration;
                buffDebuffUI.transform.GetChild(sleepPos).GetChild(1).GetComponent<Text>().text = asleep.ToString();
            }
        }
        //Lifesteal
        else if(buffDeb == 1)
        {
            if(lifesteal == 0)
            {
                lifestealPos = 3 - buffDebuffNumb;
                lifesteal = duration;
                buffDebuffUI.transform.GetChild(lifestealPos).gameObject.SetActive(true);
                buffDebuffUI.transform.GetChild(lifestealPos).GetChild(0).GetComponent<Image>().sprite = lifestealSprite;
                buffDebuffUI.transform.GetChild(lifestealPos).GetChild(1).GetComponent<Text>().text = lifesteal.ToString();
                buffDebuffNumb += 1;
            }
            else
            {
                lifesteal += duration;
                buffDebuffUI.transform.GetChild(lifestealPos).GetChild(1).GetComponent<Text>().text = lifesteal.ToString();
            }
        }
        //Disappear
        else if(buffDeb == 2)
        {
            if(disappear == 0)
            {
                disappearPos = 3 - buffDebuffNumb;
                disappear = duration;
                buffDebuffUI.transform.GetChild(disappearPos).gameObject.SetActive(true);
                buffDebuffUI.transform.GetChild(disappearPos).GetChild(0).GetComponent<Image>().sprite = disappearSprite;
                buffDebuffUI.transform.GetChild(disappearPos).GetChild(1).GetComponent<Text>().text = disappear.ToString();
                buffDebuffNumb += 1;
            }
            else
            {
                disappear += duration;
                buffDebuffUI.transform.GetChild(disappearPos).GetChild(1).GetComponent<Text>().text = disappear.ToString();
            }
        }
        //Light Up
        else if(buffDeb == 3)
        {
            if(lightUp == 0)
            {
                lightUpPos = 3 - buffDebuffNumb;
                lightUp = duration;
                buffDebuffUI.transform.GetChild(lightUpPos).gameObject.SetActive(true);
                buffDebuffUI.transform.GetChild(lightUpPos).GetChild(0).GetComponent<Image>().sprite = lightUpSprite;
                buffDebuffUI.transform.GetChild(lightUpPos).GetChild(1).GetComponent<Text>().text = lightUp.ToString();
                buffDebuffNumb += 1;
            }
            else
            {
                lightUp += duration;
                buffDebuffUI.transform.GetChild(lightUpPos).GetChild(1).GetComponent<Text>().text = lightUp.ToString();
            }
        }
    }
    //Function to rest 1 to the active buffs and debuffs
    public void RestBuffDebuff()
    {
        //We rest 1 to all the active buffs and make them disappear if they are 0
        if (asleep != 0)
        {
            asleep -= 1;
            buffDebuffUI.transform.GetChild(sleepPos).GetChild(1).GetComponent<Text>().text = asleep.ToString();
            if (asleep == 0) EndBuffDebuff(sleepPos);
        }
        if(lifesteal != 0)
        {
            lifesteal -= 1;
            buffDebuffUI.transform.GetChild(lifestealPos).GetChild(1).GetComponent<Text>().text = lifesteal.ToString();
            if (lifesteal == 0) EndBuffDebuff(lifestealPos);
        }
        if(disappear != 0)
        {
            disappear -= 1;
            buffDebuffUI.transform.GetChild(disappearPos).GetChild(1).GetComponent<Text>().text = disappear.ToString();
            if (disappear == 0)
            {
                GetComponent<SpriteRenderer>().color = new Color(GetComponent<SpriteRenderer>().color.r, GetComponent<SpriteRenderer>().color.g, GetComponent<SpriteRenderer>().color.b, 1.0f);
                GetComponent<SpriteRenderer>().material = shadowMaterial;
                EndBuffDebuff(disappearPos);
            }
        }
    }
    //Function to end a buff or a debuff
    private void EndBuffDebuff(int pos)
    {
        //Depending on the position we need to change the position of all the other active buffs
        //0--> top, 3--> bot
        if (pos == 0)
        {
            buffDebuffUI.transform.GetChild(0).gameObject.SetActive(false);
            buffDebuffNumb -= 1;
        }
        else if (pos == 1)
        {
            if (buffDebuffNumb > 3)
            {
                buffDebuffUI.transform.GetChild(1).GetChild(0).GetComponent<Image>().sprite = buffDebuffUI.transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite;
                buffDebuffUI.transform.GetChild(1).GetChild(1).GetComponent<Text>().text = buffDebuffUI.transform.GetChild(0).GetChild(1).GetComponent<Text>().text;
                buffDebuffUI.transform.GetChild(0).gameObject.SetActive(false);
                if (sleepPos == 0) sleepPos = 1;
                if (lifestealPos == 0) lifestealPos = 1;
                if (disappearPos == 0) disappearPos = 1;
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
                if (sleepPos <= 1) sleepPos += 1;
                if (lifestealPos <= 1) lifestealPos += 1;
                if (disappearPos <= 1) disappearPos += 1;
            }
            else if (buffDebuffNumb > 2)
            {
                buffDebuffUI.transform.GetChild(2).GetChild(0).GetComponent<Image>().sprite = buffDebuffUI.transform.GetChild(1).GetChild(0).GetComponent<Image>().sprite;
                buffDebuffUI.transform.GetChild(2).GetChild(1).GetComponent<Text>().text = buffDebuffUI.transform.GetChild(1).GetChild(1).GetComponent<Text>().text;
                buffDebuffUI.transform.GetChild(1).gameObject.SetActive(false);
                if (sleepPos <= 1) sleepPos += 1;
                if (lifestealPos <= 1) lifestealPos = 1;
                if (disappearPos <= 1) disappearPos += 1;
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
                if (sleepPos <= 2) sleepPos += 1;
                if (lifestealPos <= 2) lifestealPos += 1;
                if (disappearPos <= 2) disappearPos += 1;
            }
            else if (buffDebuffNumb > 2)
            {
                buffDebuffUI.transform.GetChild(3).GetChild(0).GetComponent<Image>().sprite = buffDebuffUI.transform.GetChild(2).GetChild(0).GetComponent<Image>().sprite;
                buffDebuffUI.transform.GetChild(3).GetChild(1).GetComponent<Text>().text = buffDebuffUI.transform.GetChild(2).GetChild(1).GetComponent<Text>().text;
                buffDebuffUI.transform.GetChild(2).GetChild(0).GetComponent<Image>().sprite = buffDebuffUI.transform.GetChild(1).GetChild(0).GetComponent<Image>().sprite;
                buffDebuffUI.transform.GetChild(2).GetChild(1).GetComponent<Text>().text = buffDebuffUI.transform.GetChild(1).GetChild(1).GetComponent<Text>().text;
                buffDebuffUI.transform.GetChild(1).gameObject.SetActive(false);
                if (sleepPos <= 2) sleepPos += 1;
                if (lifestealPos <= 2) lifestealPos += 1;
                if (disappearPos <= 2) disappearPos += 1;
            }
            else if (buffDebuffNumb > 1)
            {
                buffDebuffUI.transform.GetChild(3).GetChild(0).GetComponent<Image>().sprite = buffDebuffUI.transform.GetChild(2).GetChild(0).GetComponent<Image>().sprite;
                buffDebuffUI.transform.GetChild(3).GetChild(1).GetComponent<Text>().text = buffDebuffUI.transform.GetChild(2).GetChild(1).GetComponent<Text>().text;
                buffDebuffUI.transform.GetChild(2).gameObject.SetActive(false);
                if (sleepPos <= 2) sleepPos += 1;
                if (lifestealPos <= 2) lifestealPos += 1;
                if (disappearPos <= 2) disappearPos += 1;
            }
            else buffDebuffUI.transform.GetChild(3).gameObject.SetActive(false);
            buffDebuffNumb -= 1;
        }
    }
    //Function to hide the buffs and debuffs
    public void HideBuffDebuff()
    {
        //We make the buffs and debuffs disappear to see better the action commands
        if (buffDebuffNumb > 0)
        {
            buffDebuffUI.transform.GetChild(3).GetComponent<Image>().color = new Color(buffDebuffUI.transform.GetChild(3).GetComponent<Image>().color.r, buffDebuffUI.transform.GetChild(3).GetComponent<Image>().color.g, buffDebuffUI.transform.GetChild(3).GetComponent<Image>().color.b, 0.0f);
            buffDebuffUI.transform.GetChild(3).GetChild(0).GetComponent<Image>().color = new Color(buffDebuffUI.transform.GetChild(3).GetChild(0).GetComponent<Image>().color.r, buffDebuffUI.transform.GetChild(3).GetChild(0).GetComponent<Image>().color.g, buffDebuffUI.transform.GetChild(3).GetChild(0).GetComponent<Image>().color.b, 0.0f);
            buffDebuffUI.transform.GetChild(3).GetChild(1).GetComponent<Text>().color = new Color(buffDebuffUI.transform.GetChild(3).GetChild(1).GetComponent<Text>().color.r, buffDebuffUI.transform.GetChild(3).GetChild(1).GetComponent<Text>().color.g, buffDebuffUI.transform.GetChild(3).GetChild(1).GetComponent<Text>().color.b, 0.0f);
        }
        if(buffDebuffNumb > 1)
        {
            buffDebuffUI.transform.GetChild(2).GetComponent<Image>().color = new Color(buffDebuffUI.transform.GetChild(2).GetComponent<Image>().color.r, buffDebuffUI.transform.GetChild(2).GetComponent<Image>().color.g, buffDebuffUI.transform.GetChild(2).GetComponent<Image>().color.b, 0.0f);
            buffDebuffUI.transform.GetChild(2).GetChild(0).GetComponent<Image>().color = new Color(buffDebuffUI.transform.GetChild(2).GetChild(0).GetComponent<Image>().color.r, buffDebuffUI.transform.GetChild(2).GetChild(0).GetComponent<Image>().color.g, buffDebuffUI.transform.GetChild(2).GetChild(0).GetComponent<Image>().color.b, 0.0f);
            buffDebuffUI.transform.GetChild(2).GetChild(1).GetComponent<Text>().color = new Color(buffDebuffUI.transform.GetChild(2).GetChild(1).GetComponent<Text>().color.r, buffDebuffUI.transform.GetChild(2).GetChild(1).GetComponent<Text>().color.g, buffDebuffUI.transform.GetChild(2).GetChild(1).GetComponent<Text>().color.b, 0.0f);
        }
        if (buffDebuffNumb > 2)
        {
            buffDebuffUI.transform.GetChild(1).GetComponent<Image>().color = new Color(buffDebuffUI.transform.GetChild(1).GetComponent<Image>().color.r, buffDebuffUI.transform.GetChild(1).GetComponent<Image>().color.g, buffDebuffUI.transform.GetChild(1).GetComponent<Image>().color.b, 0.0f);
            buffDebuffUI.transform.GetChild(1).GetChild(0).GetComponent<Image>().color = new Color(buffDebuffUI.transform.GetChild(1).GetChild(0).GetComponent<Image>().color.r, buffDebuffUI.transform.GetChild(1).GetChild(0).GetComponent<Image>().color.g, buffDebuffUI.transform.GetChild(1).GetChild(0).GetComponent<Image>().color.b, 0.0f);
            buffDebuffUI.transform.GetChild(1).GetChild(1).GetComponent<Text>().color = new Color(buffDebuffUI.transform.GetChild(1).GetChild(1).GetComponent<Text>().color.r, buffDebuffUI.transform.GetChild(1).GetChild(1).GetComponent<Text>().color.g, buffDebuffUI.transform.GetChild(1).GetChild(1).GetComponent<Text>().color.b, 0.0f);
        }
        if (buffDebuffNumb > 3)
        {
            buffDebuffUI.transform.GetChild(0).GetComponent<Image>().color = new Color(buffDebuffUI.transform.GetChild(0).GetComponent<Image>().color.r, buffDebuffUI.transform.GetChild(0).GetComponent<Image>().color.g, buffDebuffUI.transform.GetChild(0).GetComponent<Image>().color.b, 0.0f);
            buffDebuffUI.transform.GetChild(0).GetChild(0).GetComponent<Image>().color = new Color(buffDebuffUI.transform.GetChild(0).GetChild(0).GetComponent<Image>().color.r, buffDebuffUI.transform.GetChild(0).GetChild(0).GetComponent<Image>().color.g, buffDebuffUI.transform.GetChild(0).GetChild(0).GetComponent<Image>().color.b, 0.0f);
            buffDebuffUI.transform.GetChild(0).GetChild(1).GetComponent<Text>().color = new Color(buffDebuffUI.transform.GetChild(0).GetChild(1).GetComponent<Text>().color.r, buffDebuffUI.transform.GetChild(0).GetChild(1).GetComponent<Text>().color.g, buffDebuffUI.transform.GetChild(0).GetChild(1).GetComponent<Text>().color.b, 0.0f);
        }
    }
    //Function to show the buffs and debuffs
    public void ShowBuffDebuff()
    {
        if (buffDebuffNumb > 0)
        {
            buffDebuffUI.transform.GetChild(3).GetComponent<Image>().color = new Color(buffDebuffUI.transform.GetChild(3).GetComponent<Image>().color.r, buffDebuffUI.transform.GetChild(3).GetComponent<Image>().color.g, buffDebuffUI.transform.GetChild(3).GetComponent<Image>().color.b, 1.0f);
            buffDebuffUI.transform.GetChild(3).GetChild(0).GetComponent<Image>().color = new Color(buffDebuffUI.transform.GetChild(3).GetChild(0).GetComponent<Image>().color.r, buffDebuffUI.transform.GetChild(3).GetChild(0).GetComponent<Image>().color.g, buffDebuffUI.transform.GetChild(3).GetChild(0).GetComponent<Image>().color.b, 1.0f);
            buffDebuffUI.transform.GetChild(3).GetChild(1).GetComponent<Text>().color = new Color(buffDebuffUI.transform.GetChild(3).GetChild(1).GetComponent<Text>().color.r, buffDebuffUI.transform.GetChild(3).GetChild(1).GetComponent<Text>().color.g, buffDebuffUI.transform.GetChild(3).GetChild(1).GetComponent<Text>().color.b, 1.0f);
        }
        if (buffDebuffNumb > 1)
        {
            buffDebuffUI.transform.GetChild(2).GetComponent<Image>().color = new Color(buffDebuffUI.transform.GetChild(2).GetComponent<Image>().color.r, buffDebuffUI.transform.GetChild(2).GetComponent<Image>().color.g, buffDebuffUI.transform.GetChild(2).GetComponent<Image>().color.b, 1.0f);
            buffDebuffUI.transform.GetChild(2).GetChild(0).GetComponent<Image>().color = new Color(buffDebuffUI.transform.GetChild(2).GetChild(0).GetComponent<Image>().color.r, buffDebuffUI.transform.GetChild(2).GetChild(0).GetComponent<Image>().color.g, buffDebuffUI.transform.GetChild(2).GetChild(0).GetComponent<Image>().color.b, 1.0f);
            buffDebuffUI.transform.GetChild(2).GetChild(1).GetComponent<Text>().color = new Color(buffDebuffUI.transform.GetChild(2).GetChild(1).GetComponent<Text>().color.r, buffDebuffUI.transform.GetChild(2).GetChild(1).GetComponent<Text>().color.g, buffDebuffUI.transform.GetChild(2).GetChild(1).GetComponent<Text>().color.b, 1.0f);
        }
        if (buffDebuffNumb > 2)
        {
            buffDebuffUI.transform.GetChild(1).GetComponent<Image>().color = new Color(buffDebuffUI.transform.GetChild(1).GetComponent<Image>().color.r, buffDebuffUI.transform.GetChild(1).GetComponent<Image>().color.g, buffDebuffUI.transform.GetChild(1).GetComponent<Image>().color.b, 1.0f);
            buffDebuffUI.transform.GetChild(1).GetChild(0).GetComponent<Image>().color = new Color(buffDebuffUI.transform.GetChild(1).GetChild(0).GetComponent<Image>().color.r, buffDebuffUI.transform.GetChild(1).GetChild(0).GetComponent<Image>().color.g, buffDebuffUI.transform.GetChild(1).GetChild(0).GetComponent<Image>().color.b, 1.0f);
            buffDebuffUI.transform.GetChild(1).GetChild(1).GetComponent<Text>().color = new Color(buffDebuffUI.transform.GetChild(1).GetChild(1).GetComponent<Text>().color.r, buffDebuffUI.transform.GetChild(1).GetChild(1).GetComponent<Text>().color.g, buffDebuffUI.transform.GetChild(1).GetChild(1).GetComponent<Text>().color.b, 1.0f);
        }
        if (buffDebuffNumb > 3)
        {
            buffDebuffUI.transform.GetChild(0).GetComponent<Image>().color = new Color(buffDebuffUI.transform.GetChild(0).GetComponent<Image>().color.r, buffDebuffUI.transform.GetChild(0).GetComponent<Image>().color.g, buffDebuffUI.transform.GetChild(0).GetComponent<Image>().color.b, 1.0f);
            buffDebuffUI.transform.GetChild(0).GetChild(0).GetComponent<Image>().color = new Color(buffDebuffUI.transform.GetChild(0).GetChild(0).GetComponent<Image>().color.r, buffDebuffUI.transform.GetChild(0).GetChild(0).GetComponent<Image>().color.g, buffDebuffUI.transform.GetChild(0).GetChild(0).GetComponent<Image>().color.b, 1.0f);
            buffDebuffUI.transform.GetChild(0).GetChild(1).GetComponent<Text>().color = new Color(buffDebuffUI.transform.GetChild(0).GetChild(1).GetComponent<Text>().color.r, buffDebuffUI.transform.GetChild(0).GetChild(1).GetComponent<Text>().color.g, buffDebuffUI.transform.GetChild(0).GetChild(1).GetComponent<Text>().color.b, 1.0f);
        }
    }
    //A function to attack the enemy.type: 0-> melee, 1-> ranged. style: style of melee or ranged attack
    public void Attack(int type, int style, Transform objective)
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, -2.06f);
        HideBuffDebuff();
        canvas.GetComponent<Animator>().SetBool("Hide", true);
        attackStyle = style;
        //We save the objective
        attackObjective = objective;
        //If the one attacking is the player
        if (playerTeamType == 0)
        {
            //If it is the melee attack
            //To do the all the sword attacks the player needs to move towards the enemy
            if (type == 0)
            {      
                //Normal attack
                if (style == 0)
                {
                    attackObjective.GetChild(0).transform.GetChild(1).gameObject.SetActive(true);
                    startPos = transform.position.x;
                    movePos = attackObjective.position.x - 1.1f;
                    movingToEnemy = true;
                }
                //Light sword
                else if (style == 1)
                {
                    lightPointsUI.GetComponent<LightPointsScript>().ReduceLight(2);
                    startPos = transform.position.x;
                    movePos = attackObjective.position.x - 1.1f;
                    movingToEnemy = true;
                }
                //Multistrike sword
                else if (style == 2)
                {
                    attackObjective.GetChild(0).transform.GetChild(1).gameObject.SetActive(true);
                    lightPointsUI.GetComponent<LightPointsScript>().ReduceLight(3);
                    startPos = transform.position.x;
                    movePos = attackObjective.position.x - 1.1f;
                    movingToEnemy = true;
                    repeatingDamage = currentData.GetComponent<CurrentDataScript>().swordLvl - 1;
                }
            }
            //The shuriken attack
            //To do the all the shuriken attacks we save the objective and the player starts spinning
            if (type == 1)
            {
                //Normal shuriken
                if (style == 0)
                {
                    transform.GetChild(2).GetComponent<Light>().color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
                    shurikenObjective = attackObjective.position;
                    GetComponent<Animator>().SetBool("isSpinning", true);
                }
                //Light shuriken
                else if (style == 1)
                {
                    transform.GetChild(2).GetComponent<Light>().color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
                    lightPointsUI.GetComponent<LightPointsScript>().ReduceLight(2);
                    shurikenObjective = attackObjective.position;
                    GetComponent<Animator>().SetBool("isSpinning", true);
                }
                //Fire shuriken
                else if (style == 2)
                {
                    transform.GetChild(2).GetComponent<Light>().color = new Vector4(0.8862745f, 0.345098f, 0.1333333f, 1.0f);
                    lightPointsUI.GetComponent<LightPointsScript>().ReduceLight(3);
                    //We save where the shuriken will be destroyed
                    shurikenObjective = new Vector3(12.0f, attackObjective.position.y, attackObjective.position.z);
                    GetComponent<Animator>().SetBool("isSpinning", true);
                }
            }
            //Soul attack
            if (type == 2)
            {
                source.clip = playerSoulAudio;
                source.Play();
                //Soul music attack
                if (style == 0)
                {
                    //We spend the correct amount of souls, put the correct light color and start the attack
                    battleController.GetComponent<BattleController>().SpendSouls(1);
                    GetComponent<Animator>().SetBool("soulAttack", true);
                    soulLight.GetComponent<Light>().color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
                    soulLightUp = true;
                }
                //Regeneration
                else if (style == 1)
                {
                    battleController.GetComponent<BattleController>().SpendSouls(2);
                    GetComponent<Animator>().SetBool("soulAttack", true);
                    soulLight.GetComponent<Light>().color = new Vector4(0.0f, 0.7264151f, 0.09315347f, 1.0f);
                    soulLightUp = true;
                }
                //Lightning
                else if (style == 2)
                {
                    battleController.GetComponent<BattleController>().SpendSouls(3);
                    GetComponent<Animator>().SetBool("soulAttack", true);
                    soulLight.GetComponent<Light>().color = new Vector4(1.0f, 0.9935299f, 0.0f, 1.0f);
                    soulLightUp = true;
                }
                //Lifesteal
                else if (style == 3)
                {
                    battleController.GetComponent<BattleController>().SpendSouls(3);
                    GetComponent<Animator>().SetBool("soulAttack", true);
                    soulLight.GetComponent<Light>().color = new Vector4(0.6320754f, 0.0f, 0.0f, 1.0f);
                    soulLightUp = true;
                }
                //Disappear
                else if (style == 4)
                {
                    battleController.GetComponent<BattleController>().SpendSouls(3);
                    GetComponent<Animator>().SetBool("soulAttack", true);
                    soulLight.GetComponent<Light>().color = new Vector4(0.0f, 0.1461225f, 0.7264151f, 1.0f);
                    soulLightUp = true;
                }
                //Light Up
                else if (style == 5)
                {
                    battleController.GetComponent<BattleController>().SpendSouls(2);
                    GetComponent<Animator>().SetBool("soulAttack", true);
                    soulLight.GetComponent<Light>().color = new Vector4(0.6320754f, 0.0f, 0.5f, 1.0f);
                    soulLightUp = true;
                }
            }
        }
        //Adventurer
        else if (playerTeamType == 1)
        {
            //Attack
            if (type == 0)
            {
                //Normal Sword
                if (style == 0)
                {
                    //We save the attack position and the adventurer starts moving towards it
                    attackObjective.GetChild(0).transform.GetChild(1).gameObject.SetActive(true);
                    startPos = transform.position.x;
                    movePos = attackObjective.position.x - 1.1f;
                    movingToEnemy = true;
                }
                //Glance
                else if(style == 1)
                {
                    //We instantiate the glance action with a random rotation and start the attack
                    glanceAction = Instantiate(glanceActionPrefab, attackObjective.GetChild(0));
                    glanceAction.position = attackObjective.position;
                    glanceAction.rotation = Quaternion.Euler(0.0f,0.0f, Random.Range(-45.0f,10.0f));
                    gameObject.GetComponent<Animator>().SetBool("IsGlancing", true);
                    battleController.GetComponent<BattleController>().finalAttack = true;
                }
                //Multistrike
                else if(style == 2)
                {
                    //We save the attack position and the adventurer starts moving towards it
                    lightPointsUI.GetComponent<LightPointsScript>().ReduceLight(3);
                    attackObjective.GetChild(0).transform.GetChild(1).gameObject.SetActive(true);
                    startPos = transform.position.x;
                    movePos = attackObjective.position.x - 1.1f;
                    movingToEnemy = true;
                    repeatingDamage = currentData.GetComponent<CurrentDataScript>().adventurerLvl - 1;
                }
                //Dragonslayer bow
                else if(style == 3)
                {
                    //We activate the dragonslayer action, save the objective and start the attack
                    transform.GetChild(0).transform.GetChild(3).GetComponent<Animator>().SetBool("active", true);
                    lightPointsUI.GetComponent<LightPointsScript>().ReduceLight(4);
                    shurikenObjective = new Vector3(12.0f, attackObjective.position.y, attackObjective.position.z);
                    gameObject.GetComponent<Animator>().SetTrigger("ChargeBow");
                    battleController.GetComponent<BattleController>().finalAttack = true;
                }
                //BK-47
                else if(style == 4)
                {
                    //We activate the BK-47 action
                    transform.GetChild(0).transform.GetChild(4).gameObject.SetActive(true);
                    lightPointsUI.GetComponent<LightPointsScript>().ReduceLight(7);
                    gameObject.GetComponent<Animator>().SetTrigger("ChargeBow");
                    //Boolean to be able to shoot faster than normal
                    GetComponent<Animator>().SetBool("ShootFast",true);
                    battleController.GetComponent<BattleController>().finalAttack = true;
                }
            }
        }
        //Wizard
        else if(playerTeamType == 2)
        {
            //Attack
            if(type == 0)
            {
                //Magic Ball
                if (style == 0)
                {
                    //We save the objective and start the attack
                    GetComponent<Animator>().SetBool("magicBall", true);
                    shurikenObjective = attackObjective.position;
                }
                //Barrier
                else if(style == 1)
                {
                    //We save the position of the player and the starting position and start the attack
                    lightPointsUI.GetComponent<LightPointsScript>().ReduceLight(1);
                    startPos = transform.position.x;
                    movePos = attackObjective.position.x + 0.9f;
                    movingToAlly = true;
                }
                //Pulsing Magic
                else if(style == 2)
                {
                    //We save the position of the enemy and the wizard starts moving towards them
                    lightPointsUI.GetComponent<LightPointsScript>().ReduceLight(3);
                    startPos = transform.position.x;
                    movePos = attackObjective.position.x - 1.5f;
                    movingToEnemy = true;
                    //We save the number of hits
                    repeatingDamage = currentData.GetComponent<CurrentDataScript>().wizardLvl - 1;
                }
                //Magic Spear
                else if(style == 3)
                {
                    //We save the objective and start the attack
                    lightPointsUI.GetComponent<LightPointsScript>().ReduceLight(4);
                    GetComponent<Animator>().SetBool("magicBall", true);
                    shurikenObjective = attackObjective.position;
                }
                //Explode
                else if(style == 4)
                {
                    //We save the position of the attack and the wizard starts moving towards it
                    lightPointsUI.GetComponent<LightPointsScript>().ReduceLight(9);
                    startPos = transform.position.x;
                    movePos = 3.75f;
                    movingToEnemy = true;
                }
            }
        }
    }
    //Function to get the health
    public int GetHealth()
    {
        //We get the health depending on the user
        if (playerTeamType == 0) return playerLife.GetComponent<PlayerLifeScript>().GetHealth();
        else return companionLife.GetComponent<PlayerLifeScript>().GetHealth();
    }

    //A function to make the magic ball action appear
    public void AppearMagicBallAction()
    {
        //We activate the action depending on the attack
        battleController.GetComponent<BattleController>().finalAttack = true;
        //Magic Ball
        if (attackStyle == 0) transform.GetChild(0).transform.GetChild(3).gameObject.SetActive(true);
        //Pulsing Magic
        else if (attackStyle == 2)
        {
            transform.GetChild(0).transform.GetChild(5).gameObject.SetActive(true);
            //We start the timer
            battleController.GetComponent<BattleController>().shurikenTime = Time.fixedTime;
        }
        //Magic Spear
        else if (attackStyle == 3)
        {
            transform.GetChild(0).GetChild(6).gameObject.SetActive(true);
            transform.GetChild(0).GetChild(6).GetComponent<Animator>().SetBool("charge", true);
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
        battleController.GetComponent<BattleController>().DeactivateActionInstructions();
        //If it was the first attack and the player has done correctly the action command the player or the adventurer attack again
        if(attackStyle == 0)
        {
            if (battleController.GetComponent<BattleController>().goodAttack == true && lastAttack == false)
            {
                if(playerTeamType == 1) gameObject.GetComponent<Animator>().SetBool("Melee2", true);
                battleController.GetComponent<BattleController>().FillSouls(0.15f);
                lastAttack = true;
                battleController.GetComponent<BattleController>().attackAction = false;
                //Player
                if (playerTeamType == 0)
                {
                    battleController.GetComponent<BattleController>().DealDamage(battleController.GetComponent<BattleController>().GetSelectedEnemy(), 1 + lightUp + (currentData.GetComponent<CurrentDataScript>().swordLvl - 1), false);
                    source.clip = playerNormalSwordAudio;
                    source.Play();
                }
                //Adventurer
                else if (playerTeamType == 1)
                {
                    battleController.GetComponent<BattleController>().DealDamage(battleController.GetComponent<BattleController>().GetSelectedEnemy(), 1 + lightUp + (currentData.GetComponent<CurrentDataScript>().adventurerLvl - 1), false);
                    source.clip = adventurerNormalSwordAudio;
                    source.Play();
                }
            }
            //else we end the attack and the player or the adventurer return to the starting position
            else
            {
                lastAttack = false;
                battleController.GetComponent<BattleController>().FillSouls(0.15f);
                battleController.GetComponent<BattleController>().badAttack = false;
                battleController.GetComponent<BattleController>().goodAttack = false;
                battleController.GetComponent<BattleController>().attackAction = false;
                //Player
                if (playerTeamType == 0)
                {
                    gameObject.GetComponent<Animator>().SetBool("isAttacking", false);
                    battleController.GetComponent<BattleController>().DealDamage(battleController.GetComponent<BattleController>().GetSelectedEnemy(), 1 + lightUp + (currentData.GetComponent<CurrentDataScript>().swordLvl - 1), true); 
                    source.clip = playerNormalSwordAudio;
                    source.Play();
                }
                //Adventurer
                else if (playerTeamType == 1)
                {
                    gameObject.GetComponent<Animator>().SetBool("Melee2", false);
                    battleController.GetComponent<BattleController>().DealDamage(battleController.GetComponent<BattleController>().GetSelectedEnemy(), 1 + lightUp + (currentData.GetComponent<CurrentDataScript>().adventurerLvl - 1), true);
                    source.clip = adventurerNormalSwordAudio;
                    source.Play();
                }
                battleController.GetComponent<BattleController>().finalAttack = false;
                returnStartPos = true;
                if (lightUp!=0) EndBuffDebuff(lightUpPos);
                lightUp = 0;                
            }
        }
        //The multistrike sword
        else if (attackStyle == 2)
        {
            //If the attack is good
            if (battleController.GetComponent<BattleController>().goodAttack == true)
            {
                //player
                if (playerTeamType == 0)
                {
                    source.clip = playerNormalSwordAudio;
                    source.Play();
                }
                //adventurer
                else if (playerTeamType == 1)
                {
                    gameObject.GetComponent<Animator>().SetBool("Melee3", true);
                    source.clip = adventurerNormalSwordAudio;
                    source.Play();
                }
                battleController.GetComponent<BattleController>().FillSouls(0.1f);
                //We increase the speed of the attack each time until it arrives to 1.8
                if (attackSpeed < 1.80f) attackSpeed += 0.20f;
                gameObject.GetComponent<Animator>().SetFloat("attackSpeed", attackSpeed);
                battleController.GetComponent<BattleController>().goodAttack = false;
                battleController.GetComponent<BattleController>().attackAction = false;
                battleController.GetComponent<BattleController>().DealDamage(battleController.GetComponent<BattleController>().GetSelectedEnemy(), 1 + lightUp + repeatingDamage, false);
                //We decrease the damage each time the enemy is hit
                if (repeatingDamage > 0) repeatingDamage -= 1;
                else
                {
                    if (lightUp > 1) lightUp -= 1;
                    else if (lightUp == 1)
                    {
                        EndBuffDebuff(lightUpPos);
                        lightUp = 0;
                    }
                }                
            }
            //else we end the attack and the player or the adventurer return to the starting position
            else
            {
                battleController.GetComponent<BattleController>().FillSouls(0.1f);
                attackSpeed = 1.0f;
                gameObject.GetComponent<Animator>().SetFloat("attackSpeed", attackSpeed);
                battleController.GetComponent<BattleController>().badAttack = false;
                battleController.GetComponent<BattleController>().goodAttack = false;
                battleController.GetComponent<BattleController>().attackAction = false;
                //player
                if (playerTeamType == 0)
                {
                    gameObject.GetComponent<Animator>().SetBool("isAttacking", false);
                    source.clip = playerNormalSwordAudio;
                    source.Play();
                }
                //Adventurer
                else if (playerTeamType == 1)
                {
                    gameObject.GetComponent<Animator>().SetBool("Melee3", false);
                    source.clip = adventurerNormalSwordAudio;
                    source.Play();
                }
                battleController.GetComponent<BattleController>().finalAttack = false;
                returnStartPos = true;
                battleController.GetComponent<BattleController>().DealDamage(battleController.GetComponent<BattleController>().GetSelectedEnemy(), 1 + lightUp, true);
                if (lightUp != 0) EndBuffDebuff(lightUpPos);
                lightUp = 0;
            }
        }
               
    }

    //Function to en the light melee attack
    public void EndLightMeleeAttack(int damage)
    {
        source.clip = playerSwordLightAudio;
        source.Play();
        battleController.GetComponent<BattleController>().FillSouls(0.2f * damage);
        returnStartPos = true;
        battleController.GetComponent<BattleController>().DealDamage(battleController.GetComponent<BattleController>().GetSelectedEnemy(), damage * currentData.GetComponent<CurrentDataScript>().swordLvl + lightUp + 2, true);
        if (lightUp != 0) EndBuffDebuff(lightUpPos);
        lightUp = 0;
    }
    //A function to throw a projectile
    public void ThrowShuriken()
    {
        //Player
        if(playerTeamType == 0)
        {
            source.clip = playerShurikenAudio;
            source.Play();
            //Normal shuriken
            if (attackStyle == 0)
            {
                battleController.GetComponent<BattleController>().DeactivateActionInstructions();
                //We instantiate the shuriken, save the objective and the damage
                shuriken = Instantiate(shurikenPrefab, gameObject.transform.position, Quaternion.identity);
                shuriken.GetComponent<ShurikenScript>().SetObjective(shurikenObjective);
                shuriken.GetComponent<ShurikenScript>().SetShurikenDamage(shurikenDamage + lightUp + (currentData.GetComponent<CurrentDataScript>().shurikenLvl - 1) * 2);
                if (lightUp != 0) EndBuffDebuff(lightUpPos);
                lightUp = 0;
            }
            //Light shuriken
            else if (attackStyle == 1)
            {
                transform.GetChild(2).GetComponent<Light>().intensity = 0.0f;
                battleController.GetComponent<BattleController>().DeactivateActionInstructions();
                //We instantiate the shuriken, save the objective and the damage
                shuriken = Instantiate(lightShurikenPrefab, gameObject.transform.position, Quaternion.identity);
                shuriken.GetComponent<ShurikenScript>().SetObjective(shurikenObjective);
                shuriken.GetComponent<ShurikenScript>().SetShurikenDamage(shurikenDamage * currentData.GetComponent<CurrentDataScript>().shurikenLvl + lightUp + 2);
                if (lightUp != 0) EndBuffDebuff(lightUpPos);
                lightUp = 0;
            }
            //Fire shuriken
            else if (attackStyle == 2)
            {
                transform.GetChild(2).GetComponent<Light>().intensity = 0.0f;
                battleController.GetComponent<BattleController>().DeactivateActionInstructions();
                //We instantiate the shuriken, save the objectives and the damage
                shuriken = Instantiate(fireShurikenPrefab, gameObject.transform.position, Quaternion.identity);
                shuriken.GetComponent<ShurikenScript>().SetFireObjectives(battleController.GetComponent<BattleController>().GetGroundEnemies());
                shuriken.GetComponent<ShurikenScript>().OnFireShuriken(true);
                shuriken.GetComponent<ShurikenScript>().SetObjective(shurikenObjective);
                shuriken.GetComponent<ShurikenScript>().SetShurikenDamage(shurikenDamage + lightUp + (currentData.GetComponent<CurrentDataScript>().shurikenLvl - 1) * 2);
                if (lightUp != 0) EndBuffDebuff(lightUpPos);
                lightUp = 0;
            }
        }
        //Adventurer
        else if(playerTeamType == 1)
        {
            source.clip = adventurerBowAudio;
            source.Play();
            //Dragonslayer bow
            if (attackStyle == 3)
            {
                battleController.GetComponent<BattleController>().DeactivateActionInstructions();
                //We instantiate the arrow, save the objectives and the damage
                shuriken = Instantiate(arrow, gameObject.transform.position, Quaternion.identity);
                shuriken.GetComponent<ShurikenScript>().SetFireObjectives(battleController.GetComponent<BattleController>().GetGroundEnemies());
                shuriken.GetComponent<ShurikenScript>().OnFireShuriken(true);
                shuriken.GetComponent<ShurikenScript>().SetObjective(shurikenObjective);
                shuriken.GetComponent<ShurikenScript>().SetShurikenDamage(shurikenDamage * currentData.GetComponent<CurrentDataScript>().adventurerLvl + lightUp);
                if (lightUp != 0) EndBuffDebuff(lightUpPos);
                lightUp = 0;
            }
            //BK-47
            else if (attackStyle == 4)
            {
                //We prepare the attack
                SetReadyShoot(0);
                arrowNumb += 1;
                //We instantiate the arrow and shoot it depending on the rotation
                shuriken = Instantiate(arrow, gameObject.transform.GetChild(0).GetChild(4).GetChild(0).position, Quaternion.Euler(0.0f,0.0f,battleController.GetComponent<BattleController>().GetAimRotation()));
                shuriken.GetComponent<ShurikenScript>().SetBK47(battleController.GetComponent<BattleController>().GetAimRotation() * Mathf.Deg2Rad);
                shuriken.GetComponent<ShurikenScript>().SetShurikenDamage(shurikenDamage + lightUp); 
                if (lightUp > 1) lightUp -= 1;
                else if (lightUp == 1)
                {
                    EndBuffDebuff(lightUpPos);
                    lightUp = 0;
                }
            }
        }
        //Wizard
        else if(playerTeamType == 2)
        {
            //Magic ball
            if(attackStyle == 0)
            {
                source.clip = wizardMagicAudio;
                source.Play();
                battleController.GetComponent<BattleController>().DeactivateActionInstructions();
                //We instantiate the magic ball, save the objective and the damage
                shuriken = Instantiate(magicBallPrefab, new Vector3(gameObject.transform.position.x + 1.0104f, gameObject.transform.position.y + 0.3781f, gameObject.transform.position.z), Quaternion.identity);
                shuriken.GetComponent<ShurikenScript>().SetObjective(shurikenObjective);
                shuriken.GetComponent<ShurikenScript>().SetMagic();
                shuriken.GetComponent<ShurikenScript>().SetShurikenDamage(shurikenDamage + lightUp + (currentData.GetComponent<CurrentDataScript>().wizardLvl - 1) * 2);
                if (lightUp != 0) EndBuffDebuff(lightUpPos);
                lightUp = 0;
            }
            //Magic spear
            else if(attackStyle == 3)
            {
                source.clip = wizardLaserAudio;
                source.Play();
                battleController.GetComponent<BattleController>().DeactivateActionInstructions();
                //We instantiate the magic spear, save the objective and the damage
                shuriken = Instantiate(magicSpearPrefab, new Vector3(gameObject.transform.position.x + 1.0104f, gameObject.transform.position.y + 0.3781f, gameObject.transform.position.z), Quaternion.identity);
                shuriken.GetComponent<ShurikenScript>().SetObjective(shurikenObjective);
                shuriken.GetComponent<ShurikenScript>().SetMagic();
                shuriken.GetComponent<ShurikenScript>().SetShurikenDamage(shurikenDamage * currentData.GetComponent<CurrentDataScript>().wizardLvl + lightUp);
                if (lightUp != 0) EndBuffDebuff(lightUpPos);
                lightUp = 0;
            }
        }
    }
    //A function to create the explosion
    public void CreateExplosion()
    {
        transform.GetChild(0).GetChild(7).gameObject.SetActive(true);
        explosion = Instantiate(explosionPrefab, new Vector3(transform.position.x + 1.11f, transform.position.y + 0.695f, gameObject.transform.position.z), Quaternion.identity);
        explosion.GetComponent<ExplosionScript>().SetExplosionEnemies(battleController.GetComponent<BattleController>().GetAllEnemies());
        battleController.GetComponent<BattleController>().finalAttack = true;
    }
    //Function to set the damage of the explosion
    public void EndExplosion(int damage)
    {
        source.clip = wizardExplosionAudio;
        source.Play();
        battleController.GetComponent<BattleController>().FillSouls(damage*0.5f);
        explosion.GetComponent<ExplosionScript>().SetExplosionDamage(damage + lightUp);
        if (lightUp != 0) EndBuffDebuff(lightUpPos);
        lightUp = 0;
        GetComponent<Animator>().SetBool("Explode", false);
        explosion.GetComponent<Animator>().SetTrigger("explode");
        transform.GetChild(0).GetChild(7).gameObject.SetActive(false);
    }



    //A function to activate the shuriken action
    public void ShurikenActionActivate()
    {
        //Normal shuriken
        if(attackStyle == 0)
        {
            gameObject.transform.GetChild(0).transform.GetChild(1).GetComponent<Animator>().SetBool("Active", true);
            battleController.GetComponent<BattleController>().finalAttack = true;
        }
        //light shuriken
        else if (attackStyle == 1)
        {
            battleController.GetComponent<BattleController>().shurikenTime = Time.fixedTime;
            gameObject.transform.GetChild(0).transform.GetChild(3).gameObject.SetActive(true);
            battleController.GetComponent<BattleController>().finalAttack = true;
        }
        //Fire shuriken
        else if (attackStyle == 2)
        {
            battleController.GetComponent<BattleController>().shurikenTime = Time.fixedTime;
            gameObject.transform.GetChild(0).transform.GetChild(4).gameObject.SetActive(true);
            battleController.GetComponent<BattleController>().finalAttack = true;
        }

    }

    //A function to end the shuriken throw
    public void EndShurikenThrow()
    {
        //Player
        if (playerTeamType == 0) battleController.GetComponent<BattleController>().shurikenHit = true;
        //Adventurer
        else if (playerTeamType == 1) 
        {
            //Dragonslayer bow
            if (attackStyle == 3) battleController.GetComponent<BattleController>().EndPlayerTurn(2);
            //BK-47
            else if (attackStyle == 4) 
            { 
                //If there are enemies left
                if(battleController.GetComponent<BattleController>().GetAllEnemies() != null)
                {
                    //If there are arrows left we prepare the shot
                    if (arrowNumb < 5) gameObject.GetComponent<Animator>().SetTrigger("ChargeBow");
                    //Else we end the turn
                    else
                    {
                        arrowNumb = 0;
                        if (lightUp != 0) EndBuffDebuff(lightUpPos);
                        lightUp = 0;
                        battleController.GetComponent<BattleController>().ResetAim();
                        transform.GetChild(0).transform.GetChild(4).gameObject.SetActive(false);
                        battleController.GetComponent<BattleController>().EndPlayerTurn(2);
                    }
                    //If it is the last arrow we dont let the player shoot another arrow
                    if (arrowNumb == 4) GetComponent<Animator>().SetBool("ShootFast", false);
                }
                //We end the turn if there are not enemies left
                else
                {
                    arrowNumb = 0;
                    if (lightUp != 0) EndBuffDebuff(lightUpPos);
                    lightUp = 0;
                    GetComponent<Animator>().SetBool("ShootFast", false);
                    GetComponent<Animator>().SetTrigger("DontShoot");
                    battleController.GetComponent<BattleController>().ResetAim();
                    transform.GetChild(0).transform.GetChild(4).gameObject.SetActive(false);
                    battleController.GetComponent<BattleController>().EndPlayerTurn(2);
                }
            }
        }
        //Wizard
        else if(playerTeamType == 2) battleController.GetComponent<BattleController>().EndPlayerTurn(2);
    }


    //A function to set the shuriken damage
    public void SetShurikenDamage(int damage)
    {
        shurikenDamage = damage;
    }
    //A function to activate the shoot ability of the BK47
    public void SetReadyShoot(int ready)
    {
        if(ready == 1) battleController.GetComponent<BattleController>().SetReadyShoot(true);
        else battleController.GetComponent<BattleController>().SetReadyShoot(false);
    }


    //Function to get the player type
    public int GetPlayerType()
    {
        return playerTeamType;
    }
    //A function to use a recover potion
    public void UseRecoverPotion()
    {
        GetComponent<Animator>().SetBool("isDefending", false);
        //If we have a recover potion we use it on the player
        if (battleController.GetComponent<BattleController>().UseRecoverPotion())
        {
            GetComponent<Animator>().SetBool("isDead", false);
            if(playerTeamType!=0) GetComponent<Animator>().SetBool("spawnDead", false);
        }
        //If we dont have one the battle ends
        else battleController.GetComponent<BattleController>().EndBattle();
    }

    //A function to continue with the enemy turn
    public void ContinueEnemy()
    {
        recovered = true;
        battleController.GetComponent<BattleController>().ContinueEnemy();
    }
    //A function to deal pulse damage to the enemy
    public void PulseDamage(bool last)
    {
        battleController.GetComponent<BattleController>().FillSouls(0.1f);
        //If it isnt the last pulse
        if (!last)
        {
            //We deal the damage and reduce the light up damage
            battleController.GetComponent<BattleController>().DealDamage(battleController.GetComponent<BattleController>().GetSelectedEnemy(), 1 + lightUp, false);
            if (lightUp > 1) lightUp -= 1;
            else if (lightUp == 1)
            {
                EndBuffDebuff(lightUpPos);
                lightUp = 0;
            }
        }
        //If its the last pulse we deal the damage and end the light up
        else
        {
            battleController.GetComponent<BattleController>().DealDamage(battleController.GetComponent<BattleController>().GetSelectedEnemy(), 1 + lightUp, true);
            if (lightUp != 0) EndBuffDebuff(lightUpPos);
            lightUp = 0;
        }
    }

    //A function to deal damage to the player or the companions
    public void DealDamage(int Damage)
    {
        //If the user isnt invisible or dead
        if(disappear == 0 && ((playerTeamType == 0 && !playerLife.GetComponent<PlayerLifeScript>().IsDead()) || (playerTeamType != 0 && !companionLife.GetComponent<PlayerLifeScript>().IsDead())))
        {
            //We save the damage and show it in the UI
            Damage -= battleController.GetComponent<BattleController>().GetDefense(playerTeamType);
            if (Damage < 0) Damage = 0;
            damageImage = Instantiate(damageUI, new Vector3(transform.position.x + 1.25f, transform.position.y + 1.25f, transform.GetChild(0).position.z), Quaternion.identity, transform.GetChild(0));
            damageImage.GetChild(0).GetComponent<Text>().text = Damage.ToString();
            //If the user is the player we deal the damage and check if they are still alive
            if (playerTeamType == 0)
            {
                playerLife.GetComponent<PlayerLifeScript>().DealDamage(Damage);
                if (playerLife.GetComponent<PlayerLifeScript>().IsDead())
                {
                    source.clip = playerDieAudio;
                    source.Play();
                    recovered = false;
                    GetComponent<Animator>().SetBool("isDead", true);
                }
                else
                {
                    if (GetComponent<Animator>().GetBool("isDefending")) source.clip = playerDefendDamageAudio;
                    else source.clip = playerTakeDamageAudio;
                    source.Play();
                }
            }
            //If the user is a companion we do the same but with the correct audios
            else
            {
                companionLife.GetComponent<PlayerLifeScript>().DealDamage(Damage);
                if (companionLife.GetComponent<PlayerLifeScript>().IsDead())
                {
                    //Adventurer
                    if(playerTeamType == 1)
                    {
                        source.clip = adventurerDieAudio;
                        source.Play();
                    }
                    //Wizard
                    else if(playerTeamType == 2)
                    {
                        source.clip = wizardDieAudio;
                        source.Play();
                    }
                    recovered = false; 
                    GetComponent<Animator>().SetBool("isDefending", false);
                    GetComponent<Animator>().SetBool("isDead", true);
                }
                else
                {
                    //Adventurer
                    if(playerTeamType == 1)
                    {
                        if (GetComponent<Animator>().GetBool("isDefending")) source.clip = adventurerDefendDamageAudio;
                        else source.clip = adventurerTakeDamageAudio;                        
                    }
                    //Wizard
                    else if(playerTeamType == 2)
                    {
                        if (GetComponent<Animator>().GetBool("isDefending")) source.clip = wizardDefendDamageAudio;
                        else source.clip = wizardTakeDamageAudio;
                    }
                    source.Play();
                }
            }            
        }        
    }
    //A function to know if the player is dead
    public bool IsDead()
    {
        if (playerTeamType == 0) return playerLife.GetComponent<PlayerLifeScript>().IsDead() || !recovered;
        else return companionLife.GetComponent<PlayerLifeScript>().IsDead();       
    }
    //A function to end the glance
    public void EndGlance()
    {
        battleController.GetComponent<BattleController>().DeactivateActionInstructions();
        //If the player completes the first command correctly we start the second one
        if (battleController.GetComponent<BattleController>().goodAttack == true && lastAttack == false)
        {
            lastAttack = true;
            glanceAction.rotation = Quaternion.Euler(0.0f, 0.0f, Random.Range(-45.0f, 10.0f));
            attackObjective.GetChild(0).GetChild(4).GetChild(1).GetComponent<Animator>().SetTrigger("restart");
        }
        else 
        {
            //If the second one is good too we start the dialogue 
            if (battleController.GetComponent<BattleController>().goodAttack == true)
            {
                battleController.GetComponent<BattleController>().GoodCommand();
                source.clip = adventurerGlanceAudio;
                source.Play();
                battleController.GetComponent<DialogueManager>().StartBattleDialogue(attackObjective.GetComponent<EnemyTeamScript>().dialogue);
                //Bandit
                if (attackObjective.GetComponent<EnemyTeamScript>().enemyType == 0) currentData.GetComponent<CurrentDataScript>().bandit = 1;
                //Wizard
                else if (attackObjective.GetComponent<EnemyTeamScript>().enemyType == 1) currentData.GetComponent<CurrentDataScript>().wizard = 1;
                //King
                else if (attackObjective.GetComponent<EnemyTeamScript>().enemyType == 2) currentData.GetComponent<CurrentDataScript>().king = 1;
                battleController.GetComponent<BattleController>().KnowHealth();
            }
            //If one of them is wrongly done we end the turn
            else
            {
                battleController.GetComponent<BattleController>().EndPlayerTurn(2);
            }
            //Either way we destroy the gameobject and end the attack
            Destroy(attackObjective.GetChild(0).GetChild(4).gameObject);
            lastAttack = false;
            battleController.GetComponent<BattleController>().badAttack = false;
            battleController.GetComponent<BattleController>().goodAttack = false;
            battleController.GetComponent<BattleController>().attackAction = false;
            battleController.GetComponent<BattleController>().finalAttack = false;
            gameObject.GetComponent<Animator>().SetBool("IsGlancing", false); 
            
        }
    }

    //A function to heal
    public void Heal(int points, bool regen, bool right, bool isPlayer, bool dontEndTurn)
    {
        //We check where we have to spawn the heal UI: right or left. If we are doing the regeneration attack we change the position a bit to have space to put the light regeneration.
        if (right)
        {
            if (regen) heartImage = Instantiate(heartUI, new Vector3(transform.position.x + 0.75f, transform.position.y + 0.8f, transform.GetChild(0).position.z), Quaternion.identity, transform.GetChild(0));
            else heartImage = Instantiate(heartUI, new Vector3(transform.position.x + 0.5f, transform.position.y + 1.25f, transform.GetChild(0).position.z), Quaternion.identity, transform.GetChild(0));
        }
        else
        {
            if(regen) heartImage = Instantiate(heartUI, new Vector3(transform.position.x - 0.75f, transform.position.y + 0.8f, transform.GetChild(0).position.z), Quaternion.identity, transform.GetChild(0));
            else heartImage = Instantiate(heartUI, new Vector3(transform.position.x - 0.5f, transform.position.y + 1.25f, transform.GetChild(0).position.z), Quaternion.identity, transform.GetChild(0));
        }
        heartImage.GetChild(0).GetComponent<Text>().text = points.ToString();
        heartImage.GetComponent<DamageImageScript>().SetDamage(dontEndTurn);
        //Player
        if (playerTeamType == 0)
        {
            heartImage.GetComponent<DamageImageScript>().SetUser(isPlayer);
            playerLife.GetComponent<PlayerLifeScript>().Heal(points);
        }
        //Companion
        else
        {
            heartImage.GetComponent<DamageImageScript>().SetUser(isPlayer);
            companionLife.GetComponent<PlayerLifeScript>().Heal(points);
        }
    }

    //A function to recover a team mate
    public void Recover(bool isPlayer, bool full)
    {
        //We instantiate the heart UI
        heartImage = Instantiate(heartUI, new Vector3(transform.position.x + 0.5f, transform.position.y + 1.25f, transform.GetChild(0).position.z), Quaternion.identity, transform.GetChild(0));
        heartImage.GetChild(0).GetComponent<Text>().text = 10.ToString();
        //player
        if (playerTeamType == 0)
        {
            //We heal the player 10 points
            if(playerLife.GetComponent<PlayerLifeScript>().IsDead()) heartImage.GetComponent<DamageImageScript>().SetDamage(true);
            else heartImage.GetComponent<DamageImageScript>().SetDamage(false);
            heartImage.GetComponent<DamageImageScript>().SetUser(isPlayer);
            playerLife.GetComponent<PlayerLifeScript>().Heal(10);
        }
        //Companion
        else
        {            
            heartImage.GetComponent<DamageImageScript>().SetUser(isPlayer);
            //When there is a level up and the companion was dead we heal them completly
            if (full)
            {
                heartImage.GetComponent<DamageImageScript>().SetDamage(true);
                companionLife.GetComponent<PlayerLifeScript>().Heal(GetMaxHealth());
            }
            //If it is a normal recovery we heal the companion 10 points
            else
            {
                heartImage.GetComponent<DamageImageScript>().SetDamage(false);
                companionLife.GetComponent<PlayerLifeScript>().Heal(10);
            }
            GetComponent<Animator>().SetBool("isDead", false);
            if (playerTeamType != 0) GetComponent<Animator>().SetBool("spawnDead", false);
        }
    }

    //A function to increase the light points
    public void IncreaseLight(int points, bool regen, bool isPlayer, bool dontEndTurn) 
    {
        //we check the position of the image and increase the light points of the player
        if(regen) lightImage = Instantiate(lightUI, new Vector3(transform.position.x + 0.0f, transform.position.y + 2.3f, transform.GetChild(0).position.z), Quaternion.identity, transform.GetChild(0));
        else lightImage = Instantiate(lightUI, new Vector3(transform.position.x + 0.5f, transform.position.y + 1.5f, transform.GetChild(0).position.z), Quaternion.identity, transform.GetChild(0));
        lightImage.GetChild(0).GetComponent<Text>().text = points.ToString();
        lightPointsUI.GetComponent<LightPointsScript>().IncreaseLight(points);
        lightImage.GetComponent<DamageImageScript>().SetDamage(dontEndTurn);
        lightImage.GetComponent<DamageImageScript>().SetUser(isPlayer);
    }
    //A function to get the max health
    public int GetMaxHealth()
    {
        //Player
        if (playerTeamType == 0)
        {
            return playerLife.GetComponent<PlayerLifeScript>().GetMaxHealth();
        }
        //Companion
        else return companionLife.GetComponent<PlayerLifeScript>().GetMaxHealth();
    }

    //A function to get the max light
    public int GetMaxLight()
    {
        return lightPointsUI.GetComponent<LightPointsScript>().GetMaxLight();
    }

}
