﻿using System.Collections;
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
    //The companion life
    private GameObject companionLife;
    //The damage the shuriken will do
    private int shurikenDamage;
    //A boolean to check if it is the las attack
    private bool lastAttack;
    //The type of the player team user. 0-> Player, 1-> adventurer
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

    void Awake()
    {
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
        returnStartPos = false;
        soulLightUp = false;
        asleep = 0;
        lifesteal = 0;
        disappear = 0;
        lightUp = 0;
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
                if (playerTeamType == 0) GetComponent<Animator>().SetFloat("Speed", 0.5f);
                else if (playerTeamType == 1)
                {
                    GetComponent<Animator>().SetBool("IsRunning", true);
                    GetComponent<Animator>().SetFloat("Speed", 1.0f);
                }
            }
            else
            {
                if (playerTeamType == 0) GetComponent<Animator>().SetFloat("Speed", 0.0f);
                else if (playerTeamType == 1)
                {
                    GetComponent<Animator>().SetTrigger("Melee1");
                    GetComponent<Animator>().SetBool("IsRunning", false);
                }
                movingToEnemy = false;
                if (playerTeamType == 0 && attackStyle == 1)
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
                if (playerTeamType == 0) GetComponent<Animator>().SetFloat("Speed", 0.5f);
                else if (playerTeamType == 1) GetComponent<Animator>().SetBool("IsRunning", true);
            }
            else
            {
                battleController.GetComponent<BattleController>().attackFinished = false;
                Vector3 scale = transform.localScale;
                scale.x *= -1;
                transform.localScale = scale;
                scale = transform.GetChild(0).transform.localScale;
                scale.x *= -1;
                transform.GetChild(0).transform.localScale = scale;
                if (playerTeamType == 0) GetComponent<Animator>().SetFloat("Speed", 0.0f);
                else if (playerTeamType == 1) GetComponent<Animator>().SetBool("IsRunning", false);
                returnStartPos = false;
                if (playerTeamType == 0) battleController.GetComponent<BattleController>().EndPlayerTurn(1);
                else if (playerTeamType == 1) battleController.GetComponent<BattleController>().EndPlayerTurn(2);
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
            else if (attackStyle == 4)
            {
                soulLightUp = false;
                battleController.GetComponent<BattleController>().StartDisappearAttack();
            }
            else if (attackStyle == 5)
            {
                soulLightUp = false;
                battleController.GetComponent<BattleController>().StartLightUpAttack();
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
            else if (attackStyle == 2) battleController.GetComponent<BattleController>().EndSoulLightningAttack();
            else if (attackStyle == 3) battleController.GetComponent<BattleController>().EndSoulLifestealAttack();
            else if (attackStyle == 4) battleController.GetComponent<BattleController>().EndSoulDisappearAttack();
            else if (attackStyle == 5) battleController.GetComponent<BattleController>().EndSoulLightUpAttack();
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
    //A function to end the disappear attack
    public void EndDisappearAttack()
    {
        soulLightDown = true;
    }
    //A function to end the light up attack
    public void EndLightUpAttack()
    {
        soulLightDown = true;
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
    //A function to put a buff or a debuff in the UI. buffDeb = 0 -> Sleep, buffDeb = 1 -> lifesteal, buffDeb = 2 -> invisible
    public void SetBuffDebuff(int buffDeb, int duration)
    {
        if (buffDeb == 0)
        {
            if (asleep == 0)
            {
                //GetComponent<Animator>().SetBool("IsAsleep", true);
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
                EndBuffDebuff(disappearPos);
            }
        }
    }
    //Function to end a buff or a debuff
    private void EndBuffDebuff(int pos)
    {
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
        HideBuffDebuff();
        canvas.GetComponent<Animator>().SetBool("Hide", true);
        attackStyle = style;
        //We save the objective
        attackObjective = objective;
        //If the one attacking is the player
        if (playerTeamType == 0)
        {            
            //If it is the melee attack
            if (type == 0)
            {
                //To do the normal attack the player needs to move towards the enemy
                if (style == 0)
                {
                    attackObjective.GetChild(0).transform.GetChild(1).gameObject.SetActive(true);
                    startPos = transform.position.x;
                    movePos = attackObjective.position.x - 1.1f;
                    movingToEnemy = true;
                }
                else if (style == 1)
                {
                    lightPointsUI.GetComponent<LightPointsScript>().ReduceLight(2);
                    startPos = transform.position.x;
                    movePos = attackObjective.position.x - 1.1f;
                    movingToEnemy = true;
                }
                else if (style == 2)
                {
                    attackObjective.GetChild(0).transform.GetChild(1).gameObject.SetActive(true);
                    lightPointsUI.GetComponent<LightPointsScript>().ReduceLight(3);
                    startPos = transform.position.x;
                    movePos = attackObjective.position.x - 1.1f;
                    movingToEnemy = true;
                }
            }
            //The shuriken attack
            if (type == 1)
            {
                //To do the normal attack we save the objective and the player starts spinning
                if (style == 0)
                {
                    shurikenObjective = attackObjective.position;
                    GetComponent<Animator>().SetBool("isSpinning", true);
                }
                else if (style == 1)
                {
                    transform.GetChild(2).GetComponent<Light>().color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
                    lightPointsUI.GetComponent<LightPointsScript>().ReduceLight(2);
                    shurikenObjective = attackObjective.position;
                    GetComponent<Animator>().SetBool("isSpinning", true);
                }
                else if (style == 2)
                {
                    transform.GetChild(2).GetComponent<Light>().color = new Vector4(0.8862745f, 0.345098f, 0.1333333f, 1.0f);
                    lightPointsUI.GetComponent<LightPointsScript>().ReduceLight(3);
                    shurikenObjective = new Vector3(12.0f, attackObjective.position.y, attackObjective.position.z);
                    GetComponent<Animator>().SetBool("isSpinning", true);
                }
            }
            //Soul attack
            if (type == 2)
            {
                //Soul music attack
                if (style == 0)
                {
                    battleController.GetComponent<BattleController>().SpendSouls(1);
                    GetComponent<Animator>().SetBool("soulAttack", true);
                    soulLight.GetComponent<Light>().color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
                    soulLightUp = true;
                }
                else if (style == 1)
                {
                    battleController.GetComponent<BattleController>().SpendSouls(2);
                    GetComponent<Animator>().SetBool("soulAttack", true);
                    soulLight.GetComponent<Light>().color = new Vector4(0.0f, 0.7264151f, 0.09315347f, 1.0f);
                    soulLightUp = true;
                }
                else if (style == 2)
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
                else if (style == 4)
                {
                    battleController.GetComponent<BattleController>().SpendSouls(3);
                    GetComponent<Animator>().SetBool("soulAttack", true);
                    soulLight.GetComponent<Light>().color = new Vector4(0.0f, 0.1461225f, 0.7264151f, 1.0f);
                    soulLightUp = true;
                }
                else if (style == 5)
                {
                    battleController.GetComponent<BattleController>().SpendSouls(2);
                    GetComponent<Animator>().SetBool("soulAttack", true);
                    soulLight.GetComponent<Light>().color = new Vector4(0.6320754f, 0.0f, 0.5f, 1.0f);
                    soulLightUp = true;
                }
            }
        }
        else if (playerTeamType == 1)
        {
            if (type == 0)
            {
                //To do the normal attack the player needs to move towards the enemy
                if (style == 0)
                {
                    attackObjective.GetChild(0).transform.GetChild(1).gameObject.SetActive(true);
                    startPos = transform.position.x;
                    movePos = attackObjective.position.x - 1.1f;
                    movingToEnemy = true;
                }
                else if(style == 1)
                {
                    glanceAction = Instantiate(glanceActionPrefab, attackObjective.GetChild(0));
                    glanceAction.position = attackObjective.position;
                    glanceAction.rotation = Quaternion.Euler(0.0f,0.0f, Random.Range(-45.0f,10.0f));
                    gameObject.GetComponent<Animator>().SetBool("IsGlancing", true);
                    battleController.GetComponent<BattleController>().finalAttack = true;
                }
                else if(style == 2)
                {
                    attackObjective.GetChild(0).transform.GetChild(1).gameObject.SetActive(true);
                    startPos = transform.position.x;
                    movePos = attackObjective.position.x - 1.1f;
                    movingToEnemy = true;
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
                if(playerTeamType == 1) gameObject.GetComponent<Animator>().SetBool("Melee2", true);
                battleController.GetComponent<BattleController>().FillSouls(0.15f);
                lastAttack = true;
                battleController.GetComponent<BattleController>().attackAction = false;
                if (playerTeamType == 0) battleController.GetComponent<BattleController>().DealDamage(battleController.GetComponent<BattleController>().GetSelectedEnemy(), 1 + lightUp, false);
                else if (playerTeamType == 1) battleController.GetComponent<BattleController>().DealDamage(battleController.GetComponent<BattleController>().GetSelectedEnemy(), 1 + lightUp, false);
            }
            //else we end the attack and the player goes to the starting position
            else
            {
                lastAttack = false;
                battleController.GetComponent<BattleController>().FillSouls(0.15f);
                battleController.GetComponent<BattleController>().badAttack = false;
                battleController.GetComponent<BattleController>().goodAttack = false;
                battleController.GetComponent<BattleController>().attackAction = false;
                if(playerTeamType == 0) gameObject.GetComponent<Animator>().SetBool("isAttacking", false);
                else if (playerTeamType == 1) gameObject.GetComponent<Animator>().SetBool("Melee2", false);
                battleController.GetComponent<BattleController>().finalAttack = false;
                returnStartPos = true;
                Vector3 scale = transform.localScale;
                scale.x *= -1;
                transform.localScale = scale;
                scale = transform.GetChild(0).transform.localScale;
                scale.x *= -1;
                transform.GetChild(0).transform.localScale = scale;
                battleController.GetComponent<BattleController>().DealDamage(battleController.GetComponent<BattleController>().GetSelectedEnemy(), 1 + lightUp, true);
                if (lightUp!=0) EndBuffDebuff(lightUpPos);
                lightUp = 0;                
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
                battleController.GetComponent<BattleController>().DealDamage(battleController.GetComponent<BattleController>().GetSelectedEnemy(), 1 + lightUp, false);
                if(lightUp>0) lightUp -= 1;
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
                scale = transform.GetChild(0).transform.localScale;
                scale.x *= -1;
                transform.GetChild(0).transform.localScale = scale;
                battleController.GetComponent<BattleController>().DealDamage(battleController.GetComponent<BattleController>().GetSelectedEnemy(), 1 + lightUp, true);
                if (lightUp != 0) EndBuffDebuff(lightUpPos);
                lightUp = 0;
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
        scale = transform.GetChild(0).transform.localScale;
        scale.x *= -1;
        transform.GetChild(0).transform.localScale = scale;
        battleController.GetComponent<BattleController>().DealDamage(battleController.GetComponent<BattleController>().GetSelectedEnemy(), damage + lightUp, true);
        if (lightUp != 0) EndBuffDebuff(lightUpPos);
        lightUp = 0;
    }

    //A function to throw a shuriken
    public void ThrowShuriken()
    {
        if(attackStyle == 0)
        {
            battleController.GetComponent<BattleController>().DeactivateActionInstructions();
            shuriken = Instantiate(shurikenPrefab, gameObject.transform.position, Quaternion.identity);
            shuriken.GetComponent<ShurikenScript>().SetObjective(shurikenObjective);
            shuriken.GetComponent<ShurikenScript>().SetShurikenDamage(shurikenDamage + lightUp);
            if (lightUp != 0) EndBuffDebuff(lightUpPos);
            lightUp = 0;
        }
        else if (attackStyle == 1)
        {
            transform.GetChild(2).GetComponent<Light>().intensity = 0.0f;
            battleController.GetComponent<BattleController>().DeactivateActionInstructions();
            shuriken = Instantiate(lightShurikenPrefab, gameObject.transform.position, Quaternion.identity);
            shuriken.GetComponent<ShurikenScript>().SetObjective(shurikenObjective);
            shuriken.GetComponent<ShurikenScript>().SetShurikenDamage(shurikenDamage + lightUp);
            if (lightUp != 0) EndBuffDebuff(lightUpPos);
            lightUp = 0;
        }
        else if (attackStyle == 2)
        {
            transform.GetChild(2).GetComponent<Light>().intensity = 0.0f;
            battleController.GetComponent<BattleController>().DeactivateActionInstructions();
            shuriken = Instantiate(fireShurikenPrefab, gameObject.transform.position, Quaternion.identity);
            shuriken.GetComponent<ShurikenScript>().SetFireObjectives(battleController.GetComponent<BattleController>().GetGroundEnemies());
            shuriken.GetComponent<ShurikenScript>().SetObjective(shurikenObjective);
            shuriken.GetComponent<ShurikenScript>().SetShurikenDamage(shurikenDamage + lightUp);
            shuriken.GetComponent<ShurikenScript>().OnFireShuriken(true);
            if(lightUp !=0) EndBuffDebuff(lightUpPos);
            lightUp = 0;
            
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
    //Function to get the player type
    public int GetPlayerType()
    {
        return playerTeamType;
    }

    //A function to deal damage
    public void DealDamage(int Damage)
    {
        if(disappear == 0)
        {
            Damage -= battleController.GetComponent<BattleController>().GetDefense(playerTeamType);
            if (Damage < 0) Damage = 0;
            damageImage = Instantiate(damageUI, new Vector3(transform.position.x + 1.25f, transform.position.y + 1.25f, transform.GetChild(0).position.z), Quaternion.identity, transform.GetChild(0));
            damageImage.GetChild(0).GetComponent<Text>().text = Damage.ToString();
            if(playerTeamType==0) playerLife.GetComponent<PlayerLifeScript>().DealDamage(Damage);
            else companionLife.GetComponent<PlayerLifeScript>().DealDamage(Damage);
        }        
    }
    //A function to end the glance
    public void EndGlance()
    {
        battleController.GetComponent<BattleController>().DeactivateActionInstructions();
        if (battleController.GetComponent<BattleController>().goodAttack == true && lastAttack == false)
        {
            lastAttack = true;
            glanceAction.rotation = Quaternion.Euler(0.0f, 0.0f, Random.Range(-45.0f, 10.0f));
            attackObjective.GetChild(0).GetChild(4).GetChild(1).GetComponent<Animator>().SetTrigger("restart");
        }
        else 
        {
            if (battleController.GetComponent<BattleController>().goodAttack == true)
            {
                battleController.GetComponent<DialogueManager>().StartDialogue(attackObjective.GetComponent<EnemyTeamScript>().dialogue);
                if (attackObjective.GetComponent<EnemyTeamScript>().enemyType == 0) PlayerPrefs.SetInt("bandit", 1);
                battleController.GetComponent<BattleController>().KnowHealth();
            }
            else
            {
                battleController.GetComponent<BattleController>().EndPlayerTurn(2);
            }
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
        if (playerTeamType == 0)
        {
            heartImage.GetComponent<DamageImageScript>().SetUser(isPlayer);
            playerLife.GetComponent<PlayerLifeScript>().Heal(points);
        }
        else
        {
            heartImage.GetComponent<DamageImageScript>().SetUser(isPlayer);
            companionLife.GetComponent<PlayerLifeScript>().Heal(points);
        }
    }

    //A function to increase the light points
    public void IncreaseLight(int points, bool regen, bool isPlayer, bool dontEndTurn) 
    {
        if(regen) lightImage = Instantiate(lightUI, new Vector3(transform.position.x + 0.0f, transform.position.y + 2.3f, transform.GetChild(0).position.z), Quaternion.identity, transform.GetChild(0));
        else lightImage = Instantiate(lightUI, new Vector3(transform.position.x + 0.5f, transform.position.y + 1.5f, transform.GetChild(0).position.z), Quaternion.identity, transform.GetChild(0));
        lightImage.GetChild(0).GetComponent<Text>().text = points.ToString();
        lightPointsUI.GetComponent<LightPointsScript>().IncreaseLight(points);
        lightImage.GetComponent<DamageImageScript>().SetDamage(dontEndTurn);
        lightImage.GetComponent<DamageImageScript>().SetUser(isPlayer);
    }
}
