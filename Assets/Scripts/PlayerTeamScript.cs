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
    //The prefab of the damage, heart and light UI
    [SerializeField] private Transform damageUI;
    [SerializeField] private Transform heartUI;
    [SerializeField] private Transform lightUI;

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
    //The damage the shuriken will do
    private int shurikenDamage;
    //A boolean to check if it is the las attack
    private bool lastAttack;
    //The type of the player team user. 0-> Player
    public int playerTeamType; 
    //The start position
    private float startPos;
    //The move position
    private float movePos;
    //A bool to check if the player is moving towards the enemy
    private bool movingToEnemy;
    //A bool to check if the player is returning to the start position
    private bool returnStartPos;
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

    void Awake()
    {
        //We find the gameobjects and initialize some variables
        lightPointsUI = GameObject.Find("LightBckImage");
        battleController = GameObject.Find("BattleController");
        playerLife = GameObject.Find("PlayerLifeBckImage");
        soulLight = transform.GetChild(3).gameObject;
        soulMusicAction = GameObject.Find("SoulMusicAction");
        canvas = GameObject.Find("Canvas");
        soulMusicAction.SetActive(false);
        lastAttack = false;
        movingToEnemy = false;
        returnStartPos = false;
        soulLightUp = false;
        attackSpeed = 1.0f;
    }


    void FixedUpdate()
    {
        //The player moves to the enemy to attack it
        if (movingToEnemy)
        {
            if (transform.position.x < movePos)
            {
                transform.position = new Vector3(transform.position.x + 0.10f, transform.position.y, transform.position.z);
                GetComponent<Animator>().SetFloat("Speed", 0.5f);
            }
            else
            {
                GetComponent<Animator>().SetFloat("Speed", 0.0f);
                movingToEnemy = false;
                if (attackStyle == 1)
                {
                    gameObject.transform.GetChild(0).transform.GetChild(2).GetComponent<Animator>().SetBool("active", true);
                    gameObject.GetComponent<Animator>().SetTrigger("statChargeLightMelee");
                }
                battleController.GetComponent<BattleController>().finalAttack = true;
            }
        }
        //The player returns to the start position after attacking
        else if (returnStartPos)
        {
            if (transform.position.x > startPos)
            {
                if(attackStyle == 0 || attackStyle == 2)
                {
                    attackObjective.GetChild(0).transform.GetChild(1).gameObject.GetComponent<Animator>().SetBool("Pressed", false);
                    attackObjective.GetChild(0).transform.GetChild(1).gameObject.SetActive(false);
                }
                transform.position = new Vector3(transform.position.x - 0.15f, transform.position.y, transform.position.z);
                GetComponent<Animator>().SetFloat("Speed", 0.5f);
            }
            else
            {
                battleController.GetComponent<BattleController>().attackFinished = false;
                Vector3 scale = transform.localScale;
                scale.x *= -1;
                transform.localScale = scale;
                GetComponent<Animator>().SetFloat("Speed", 0.0f);
                returnStartPos = false;
                battleController.GetComponent<BattleController>().EndPlayerTurn();
            }
        }
        //Soul light going up
        if (soulLightUp && soulLight.transform.position.y < 75.0f)
        {
            soulLight.transform.position = new Vector3(soulLight.transform.position.x, soulLight.transform.position.y + 0.5f, soulLight.transform.position.z);
        }
        else if(soulLightUp && soulLight.transform.position.y >= 75.0f)
        {
            if(attackStyle == 0)
            {
                soulMusicAction.SetActive(true);
                soulLightUp = false;
                battleController.GetComponent<BattleController>().StartSoulMusicAttack(1);
            }
            else if(attackStyle == 1)
            {
                soulLightUp = false;
                battleController.GetComponent<BattleController>().StartRegenerationAttack();
            }
            else if(attackStyle == 2)
            {
                soulLightUp = false;
                battleController.GetComponent<BattleController>().StartLightningAttack();
            }
            else if(attackStyle == 3)
            {
                soulLightUp = false;
                battleController.GetComponent<BattleController>().StartLifestealAttack();
            }
        }
        if (soulLightDown && soulLight.transform.position.y > -2.0f)
        {
            soulLight.transform.position = new Vector3(soulLight.transform.position.x, soulLight.transform.position.y - 0.5f, soulLight.transform.position.z);
        }
        else if(soulLightDown && soulLight.transform.position.y <= -2.0f)
        {
            GetComponent<Animator>().SetBool("soulAttack", false);
            soulLightDown = false;
            if (attackStyle == 0) battleController.GetComponent<BattleController>().EndSoulAttack(soulLvl);
            else if (attackStyle == 1) battleController.GetComponent<BattleController>().EndSoulRegenerationAttack();
            else if(attackStyle == 2) battleController.GetComponent<BattleController>().EndSoulLightningAttack();
            else if(attackStyle == 3) battleController.GetComponent<BattleController>().EndSoulLifestealAttack();
        }
    }

    //A function to end the soul attack
    public void EndSoulAttack(int lvl)
    {
        soulMusicAction.SetActive(false);
        soulLightDown = true;
        soulLvl = lvl;
    }
    //A function to end the regeneration attack
    public void EndRegenerationAttack()
    {
        soulLightDown = true;
    }
    //A function to end the lightning attack
    public void EndLightningAttack()
    {
        soulLightDown = true;
    }

    //A function to end the lifesteal attack
    public void EndLifestealAttack()
    {
        soulLightDown = true;
    }

    //A function to attack the enemy.type: 0-> melee, 1-> ranged. style: style of melee or ranged attack
    public void Attack(int type, int style, Transform objective)
    {
        canvas.GetComponent<Animator>().SetBool("Hide", true);
        attackStyle = style;
        //If the one attacking is the player
        if (playerTeamType == 0)
        {
            //We save the objective
            attackObjective = objective;
            //If it is the melee attack
            if (type == 0)
            {
                //To do the normal attack the player needs to move towards the enemy
                if(style == 0)
                {
                    attackObjective.GetChild(0).transform.GetChild(1).gameObject.SetActive(true);
                    startPos = transform.position.x;
                    movePos = attackObjective.position.x - 1.1f;
                    movingToEnemy = true;
                }
                else if(style == 1)
                {
                    lightPointsUI.GetComponent<LightPointsScript>().ReduceLight(2);
                    startPos = transform.position.x;
                    movePos = attackObjective.position.x - 1.1f;
                    movingToEnemy = true;
                }
                else if(style == 2)
                {
                    attackObjective.GetChild(0).transform.GetChild(1).gameObject.SetActive(true);
                    lightPointsUI.GetComponent<LightPointsScript>().ReduceLight(3);
                    startPos = transform.position.x;
                    movePos = attackObjective.position.x - 1.1f;
                    movingToEnemy = true;
                }
            }
            //The shuriken attack
            if(type == 1)
            {
                //To do the normal attack we save the objective and the player starts spinning
                if(style == 0)
                {
                    shurikenObjective = attackObjective.position;
                    GetComponent<Animator>().SetBool("isSpinning", true);
                }
                else if(style == 1)
                {
                    transform.GetChild(2).GetComponent<Light>().color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
                    lightPointsUI.GetComponent<LightPointsScript>().ReduceLight(2);
                    shurikenObjective = attackObjective.position;
                    GetComponent<Animator>().SetBool("isSpinning", true);
                }
                else if(style == 2)
                {
                    transform.GetChild(2).GetComponent<Light>().color = new Vector4(0.8862745f, 0.345098f, 0.1333333f, 1.0f); 
                    lightPointsUI.GetComponent<LightPointsScript>().ReduceLight(3);
                    shurikenObjective = new Vector3(12.0f, attackObjective.position.y, attackObjective.position.z);
                    GetComponent<Animator>().SetBool("isSpinning", true);
                }
            }
            //Soul attack
            if(type == 2)
            {
                //Soul music attack
                if(style == 0)
                {
                    battleController.GetComponent<BattleController>().SpendSouls(1);
                    GetComponent<Animator>().SetBool("soulAttack", true);
                    soulLight.GetComponent<Light>().color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
                    soulLightUp = true;
                }
                else if(style == 1)
                {
                    battleController.GetComponent<BattleController>().SpendSouls(2);
                    GetComponent<Animator>().SetBool("soulAttack", true);
                    soulLight.GetComponent<Light>().color = new Vector4(0.0f, 0.7264151f, 0.09315347f, 1.0f);
                    soulLightUp = true;
                }
                else if(style == 2)
                {
                    battleController.GetComponent<BattleController>().SpendSouls(3);
                    GetComponent<Animator>().SetBool("soulAttack", true);
                    soulLight.GetComponent<Light>().color = new Vector4(1.0f, 0.9935299f, 0.0f, 1.0f);
                    soulLightUp = true;
                }
                else if (style == 3)
                {
                    battleController.GetComponent<BattleController>().SpendSouls(3);
                    GetComponent<Animator>().SetBool("soulAttack", true);
                    soulLight.GetComponent<Light>().color = new Vector4(0.6320754f, 0.0f, 0.0f, 1.0f);
                    soulLightUp = true;
                }
            }
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
        //If it was the first attack and the player has done correctly the action command the player attacks again
        if(attackStyle == 0)
        {
            if (battleController.GetComponent<BattleController>().goodAttack == true && lastAttack == false)
            {
                battleController.GetComponent<BattleController>().FillSouls(0.15f);
                lastAttack = true;
                battleController.GetComponent<BattleController>().attackAction = false;
                battleController.GetComponent<BattleController>().DealDamage(battleController.GetComponent<BattleController>().GetSelectedEnemy(), 1, false);
            }
            //else we end the attack and the player goes to the starting position
            else
            {
                lastAttack = false;
                battleController.GetComponent<BattleController>().FillSouls(0.15f);
                battleController.GetComponent<BattleController>().badAttack = false;
                battleController.GetComponent<BattleController>().goodAttack = false;
                battleController.GetComponent<BattleController>().attackAction = false;
                gameObject.GetComponent<Animator>().SetBool("isAttacking", false);
                battleController.GetComponent<BattleController>().finalAttack = false;
                returnStartPos = true;
                Vector3 scale = transform.localScale;
                scale.x *= -1;
                transform.localScale = scale;
                battleController.GetComponent<BattleController>().DealDamage(battleController.GetComponent<BattleController>().GetSelectedEnemy(), 1, true);
            }
        }
        else if (attackStyle == 2)
        {
            if (battleController.GetComponent<BattleController>().goodAttack == true)
            {
                battleController.GetComponent<BattleController>().FillSouls(0.1f);
                if (attackSpeed < 1.80f) attackSpeed += 0.20f;
                gameObject.GetComponent<Animator>().SetFloat("attackSpeed", attackSpeed);
                battleController.GetComponent<BattleController>().goodAttack = false;
                battleController.GetComponent<BattleController>().attackAction = false;
                battleController.GetComponent<BattleController>().DealDamage(battleController.GetComponent<BattleController>().GetSelectedEnemy(), 1, false);
            }
            //else we end the attack and the player goes to the starting position
            else
            {
                battleController.GetComponent<BattleController>().FillSouls(0.1f);
                attackSpeed = 1.0f;
                gameObject.GetComponent<Animator>().SetFloat("attackSpeed", attackSpeed);
                battleController.GetComponent<BattleController>().badAttack = false;
                battleController.GetComponent<BattleController>().goodAttack = false;
                battleController.GetComponent<BattleController>().attackAction = false;
                gameObject.GetComponent<Animator>().SetBool("isAttacking", false);
                battleController.GetComponent<BattleController>().finalAttack = false;
                returnStartPos = true;
                Vector3 scale = transform.localScale;
                scale.x *= -1;
                transform.localScale = scale;
                battleController.GetComponent<BattleController>().DealDamage(battleController.GetComponent<BattleController>().GetSelectedEnemy(), 1, true);
            }
        }
               
    }

    //Function to en the light melee attack
    public void EndLightMeleeAttack(int damage)
    {
        battleController.GetComponent<BattleController>().FillSouls(0.4f);
        returnStartPos = true;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
        battleController.GetComponent<BattleController>().DealDamage(battleController.GetComponent<BattleController>().GetSelectedEnemy(), damage, true);
    }

    //A function to throw a shuriken
    public void ThrowShuriken()
    {
        if(attackStyle == 0)
        {
            battleController.GetComponent<BattleController>().DeactivateActionInstructions();
            shuriken = Instantiate(shurikenPrefab, gameObject.transform.position, Quaternion.identity);
            shuriken.GetComponent<ShurikenScript>().SetObjective(shurikenObjective);
            shuriken.GetComponent<ShurikenScript>().SetShurikenDamage(shurikenDamage);
        }
        else if (attackStyle == 1)
        {
            transform.GetChild(2).GetComponent<Light>().intensity = 0.0f;
            battleController.GetComponent<BattleController>().DeactivateActionInstructions();
            shuriken = Instantiate(lightShurikenPrefab, gameObject.transform.position, Quaternion.identity);
            shuriken.GetComponent<ShurikenScript>().SetObjective(shurikenObjective);
            shuriken.GetComponent<ShurikenScript>().SetShurikenDamage(shurikenDamage);
        }
        else if (attackStyle == 2)
        {
            transform.GetChild(2).GetComponent<Light>().intensity = 0.0f;
            battleController.GetComponent<BattleController>().DeactivateActionInstructions();
            shuriken = Instantiate(fireShurikenPrefab, gameObject.transform.position, Quaternion.identity);
            shuriken.GetComponent<ShurikenScript>().SetFireObjectives(battleController.GetComponent<BattleController>().GetGroundEnemies());
            shuriken.GetComponent<ShurikenScript>().SetObjective(shurikenObjective);
            shuriken.GetComponent<ShurikenScript>().SetShurikenDamage(shurikenDamage);
            shuriken.GetComponent<ShurikenScript>().OnFireShuriken(true);
        }
    }
    
    //A function to activate the shuriken action
    public void ShurikenActionActivate()
    {
        if(attackStyle == 0)
        {
            gameObject.transform.GetChild(0).transform.GetChild(1).GetComponent<Animator>().SetBool("Active", true);
            battleController.GetComponent<BattleController>().finalAttack = true;
        }
        else if (attackStyle == 1)
        {
            battleController.GetComponent<BattleController>().shurikenTime = Time.fixedTime;
            gameObject.transform.GetChild(0).transform.GetChild(3).gameObject.SetActive(true);
            battleController.GetComponent<BattleController>().finalAttack = true;
        }
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
        battleController.GetComponent<BattleController>().shurikenHit = true;
    }

    //A function to set the shuriken damage
    public void SetShurikenDamage(int damage)
    {
        shurikenDamage = damage;
    }

    //A function to deal damage
    public void DealDamage(int Damage)
    {
        Damage -= battleController.GetComponent<BattleController>().GetDefense();
        if (Damage < 0) Damage = 0;
        damageImage = Instantiate(damageUI, new Vector3(transform.position.x + 1.25f, transform.position.y + 1.25f, transform.GetChild(0).position.z), Quaternion.identity, transform.GetChild(0));
        damageImage.GetChild(0).GetComponent<Text>().text = Damage.ToString();
        playerLife.GetComponent<PlayerLifeScript>().DealDamage(Damage);
    }

    //A function to heal
    public void Heal(int points, bool regen)
    {
        if(regen) heartImage = Instantiate(heartUI, new Vector3(transform.position.x + 1.5f, transform.position.y + 0.8f, transform.GetChild(0).position.z), Quaternion.identity, transform.GetChild(0));
        else heartImage = Instantiate(heartUI, new Vector3(transform.position.x + 1.25f, transform.position.y + 1.25f, transform.GetChild(0).position.z), Quaternion.identity, transform.GetChild(0));
        heartImage.GetChild(0).GetComponent<Text>().text = points.ToString();
        playerLife.GetComponent<PlayerLifeScript>().Heal(points);
    }

    //A function to increase the light points
    public void IncreaseLight(int points, bool regen) 
    {
        if(regen) lightImage = Instantiate(lightUI, new Vector3(transform.position.x + 0.0f, transform.position.y + 2.3f, transform.GetChild(0).position.z), Quaternion.identity, transform.GetChild(0));
        else lightImage = Instantiate(lightUI, new Vector3(transform.position.x + 1.25f, transform.position.y + 1.25f, transform.GetChild(0).position.z), Quaternion.identity, transform.GetChild(0));
        lightImage.GetChild(0).GetComponent<Text>().text = points.ToString();
        lightPointsUI.GetComponent<LightPointsScript>().IncreaseLight(points);
    }
}
