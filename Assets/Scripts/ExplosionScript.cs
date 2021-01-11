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
        //We find the battle controller
        battleController = GameObject.Find("BattleController");
        xButton = GameObject.Find("ExplodeX");
        fillBar = GameObject.Find("FillExplodeBar");
        xButtonPressed = false;
        changeTime = Time.fixedTime + Random.Range(0.5f, 1.5f);
        battleController.GetComponent<BattleController>().shurikenTime = Time.fixedTime;
    }


    void Update()
    {
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
            changeTime = Time.fixedTime + Random.Range(0.5f, 1.5f);
        }
        gameObject.transform.localScale = new Vector3(1.0f + 4.0f* fillBar.GetComponent<Image>().fillAmount, 1.0f + 4.0f * fillBar.GetComponent<Image>().fillAmount, 1.0f);
    }

    public void SetExplosionEnemies(Transform[] e)
    {
        enemies = e;
    }

    public void SetExplosionDamage(int d)
    {
        damage = d;
    }

    public void Explode()
    {
        battleController.GetComponent<BattleController>().attackAction = false;
        gameObject.GetComponent<Animator>().SetTrigger("explode");
        for (int i=0; i<enemies.Length; i++) battleController.GetComponent<BattleController>().DealDamage(enemies[i],damage,true); 
    }

    public void SelfDestroy()
    {
        Destroy(gameObject);
    }

}
