using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class ShurikenScript : MonoBehaviour
{
    //The objective of the shuriken
    private Vector3 objective;
    //The objectives of the fire shuriken
    private Transform[] fireObjectives;
    //The battle controller
    private GameObject battleController;
    //The damage of the shuriken
    private int shurikenDamage;
    //A boolean to know if the shuriken is a fire shuriken
    private bool fire;
    //An int to know the number of enemies hit
    private int hit;
    //A boolean to know if the bullet is thrown by the BK47
    private bool BK47;
    //A float to save the rotation of the bk47 arrow
    private float rotation;
    //A boolean to know if the bullet is a magic ball
    private bool magic;
    //A boolean to know if the magic ball has exploded
    private bool exploded;

    private void Awake()
    {
        //We find the battle controller
        battleController = GameObject.Find("BattleController");
        //We initialize the hit int
        hit = 0;
        BK47 = false;
        magic = false;
        exploded = false;
        rotation = 0.0f;
    }

    void FixedUpdate()
    {
        if (!BK47)
        {
            //if the shuriken hasn't arrived to the objective it keeps moving
            if (gameObject.transform.position.x < objective.x) gameObject.transform.position = new Vector3(gameObject.transform.position.x + 0.39f * Mathf.Cos(rotation), gameObject.transform.position.y + 0.39f * Mathf.Sin(rotation), gameObject.transform.position.z);
            //When the shuriken arrives it deals damage and self destroys
            else
            {
                if (!fire && !exploded)
                {
                    battleController.GetComponent<BattleController>().DealDamage(battleController.GetComponent<BattleController>().GetSelectedEnemy(), shurikenDamage, true);
                    if (shurikenDamage == 1) battleController.GetComponent<BattleController>().FillSouls(0.1f);
                    else if (shurikenDamage == 2) battleController.GetComponent<BattleController>().FillSouls(0.3f);
                    else battleController.GetComponent<BattleController>().FillSouls(0.4f);
                }
                if (!magic) Destroy(gameObject);
                else
                {
                    exploded = true;
                    GetComponent<Animator>().SetTrigger("explode");
                }
            }
            if (fire && fireObjectives.Length > hit && gameObject.transform.position.x > (fireObjectives[hit].transform.position.x - 0.2f) && gameObject.transform.position.x <= (fireObjectives[hit].transform.position.x + 0.2f))
            {
                if (shurikenDamage == 1) battleController.GetComponent<BattleController>().FillSouls(0.075f);
                else battleController.GetComponent<BattleController>().FillSouls(0.15f);
                battleController.GetComponent<BattleController>().DealDamage(fireObjectives[hit], shurikenDamage, true);
                hit += 1;
            }
        }
        else
        {
            if(gameObject.transform.position.x < 10.0f) gameObject.transform.position = new Vector3(gameObject.transform.position.x + 0.39f * Mathf.Cos(rotation), gameObject.transform.position.y + 0.39f * Mathf.Sin(rotation), gameObject.transform.position.z);
            else Destroy(gameObject);
        }      
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(BK47 && collision.tag.Equals("enemy") && collision.GetComponent<EnemyTeamScript>().IsAlive())
        {
            battleController.GetComponent<BattleController>().DealDamage(collision.transform, shurikenDamage, true);
            Destroy(gameObject);
        }
    }

    //A function to set the objective
    public void SetObjective(Vector3 obj)
    {
        objective = obj;
        if (!BK47) 
        {
            rotation = Mathf.Atan2(objective.y - transform.position.y, objective.x - transform.position.x);
            transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotation * Mathf.Rad2Deg);
        } 
    }
    //A function to set the objectives of the fire shuriken
    public void SetFireObjectives(Transform[] objs)
    {
        fireObjectives = objs;
    }

    //A function to set the shuriken damage
    public void SetShurikenDamage(int damage)
    {
        shurikenDamage = damage;
    }

    //Function to set the shuriken on fire
    public void OnFireShuriken(bool onFire)
    {
        fire = onFire;
    }

    //Function to set the magic ball
    public void SetMagic()
    {
        magic = true;
    }

    //Function to set the bk47 mode
    public void SetBK47(float rot)
    {
        rotation = rot;
        BK47 = true;
    }
    //Function to self destroy
    public void SelfDestroy()
    {
        Destroy(gameObject);
    }

}
