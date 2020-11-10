using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    private void Start()
    {
        //We find the battle controller
        battleController = GameObject.Find("BattleController");
        //We initialize the hit int
        hit = 0;
    }

    void FixedUpdate()
    {
        //if the shuriken hasn't arrive to the objective it keeps moving
        if (gameObject.transform.position.x < objective.x) gameObject.transform.position = new Vector3(gameObject.transform.position.x + 0.4f, gameObject.transform.position.y, gameObject.transform.position.z);
        //When the shuriken arrives it deals damage and self destroys
        else
        {
            if (!fire)
            {
                battleController.GetComponent<BattleController>().DealDamage(battleController.GetComponent<BattleController>().GetSelectedEnemy(), shurikenDamage, true);
                if (shurikenDamage == 1) battleController.GetComponent<BattleController>().FillSouls(0.1f);
                else if (shurikenDamage == 2) battleController.GetComponent<BattleController>().FillSouls(0.3f);
                else battleController.GetComponent<BattleController>().FillSouls(0.4f);
            }
            Destroy(gameObject);
        }
        if (fire && fireObjectives.Length > hit && gameObject.transform.position.x > (fireObjectives[hit].transform.position.x - 0.15f) && gameObject.transform.position.x <= (fireObjectives[hit].transform.position.x + 0.15f))
        {
            if(shurikenDamage == 1) battleController.GetComponent<BattleController>().FillSouls(0.075f);
            else battleController.GetComponent<BattleController>().FillSouls(0.15f);
            battleController.GetComponent<BattleController>().DealDamage(fireObjectives[hit], shurikenDamage, true);
            hit += 1;
        }       
        
    }
    //A function to set the objective
    public void SetObjective(Vector3 obj)
    {
        objective = obj;
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
}
