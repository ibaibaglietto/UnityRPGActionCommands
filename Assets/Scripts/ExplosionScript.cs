using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExplosionScript : MonoBehaviour
{
    //The battle controller
    private GameObject battleController;
    //The enemies the explosion will damage
    private Transform[] enemies;
    //The damage the explosion will do
    private int damage;
    //The state of the x button
    private bool xButtonPressed;
    //The time until the next change
    private float changeTime;
    //The x button gameobject
    private GameObject xButton;
    //The fill bar gameobject
    private GameObject fillBar;
    void Start()
    {
        //We find the gameobjects and initialize the variables
        battleController = GameObject.Find("BattleController");
        xButton = GameObject.Find("ExplodeX");
        fillBar = GameObject.Find("FillExplodeBar");
        xButtonPressed = false;
        //We change the button action randomly
        changeTime = Time.fixedTime + Random.Range(0.5f, 1.5f);
        //We save the starting time
        battleController.GetComponent<BattleController>().shurikenTime = Time.fixedTime;
    }


    void Update()
    {
        //We change the button action when a certain amount of time passes
        if(Time.fixedTime > changeTime)
        {
            if (xButtonPressed)
            {
                xButtonPressed = false;
                xButton.GetComponent<Animator>().SetBool("Pressed", false);
                battleController.GetComponent<BattleController>().attackAction = false;
            }
            else
            {
                xButtonPressed = true;
                xButton.GetComponent<Animator>().SetBool("Pressed", true);
                battleController.GetComponent<BattleController>().attackAction = true;
            }
            //We recalculate the time
            changeTime = Time.fixedTime + Random.Range(0.5f, 1.5f);
        }
        //We scale the explosion depending on the fill amount
        gameObject.transform.localScale = new Vector3(1.0f + 4.0f* fillBar.GetComponent<Image>().fillAmount, 1.0f + 4.0f * fillBar.GetComponent<Image>().fillAmount, 1.0f);
    }

    //Function to set the enemies that will take damage
    public void SetExplosionEnemies(Transform[] e)
    {
        enemies = e;
    }

    //Function to set the damage
    public void SetExplosionDamage(int d)
    {
        damage = d;
    }

    //Function to deal damage to the enemies
    public void Explode()
    {
        battleController.GetComponent<BattleController>().attackAction = false;
        gameObject.GetComponent<Animator>().SetTrigger("explode");
        for (int i=0; i<enemies.Length; i++) battleController.GetComponent<BattleController>().DealDamage(enemies[i],damage,true); 
    }

    //function to self destroy the explosion
    public void SelfDestroy()
    {
        Destroy(gameObject);
    }

}
