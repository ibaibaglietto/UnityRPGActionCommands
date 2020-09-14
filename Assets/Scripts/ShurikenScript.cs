using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShurikenScript : MonoBehaviour
{
    //The objective of the shuriken
    private Vector3 objective;
    //The battle controller
    private GameObject battleController;
    //The damage of the shuriken
    private int shurikenDamage;

    private void Start()
    {
        //We find the battle controller
        battleController = GameObject.Find("BattleController");
    }

    void FixedUpdate()
    {
        //if the shuriken hasn't arrive to the objective it keeps moving
        if (gameObject.transform.position.x < objective.x) gameObject.transform.position = new Vector3(gameObject.transform.position.x + 0.3f, gameObject.transform.position.y, gameObject.transform.position.z);
        //When the shuriken arrives it deals damage and self destroys
        else
        {
            battleController.GetComponent<BattleController>().DealDamage(battleController.GetComponent<BattleController>().GetSelectedEnemy(), shurikenDamage,true);
            Destroy(gameObject);
        }
    }

    //A function to set the objective
    public void SetObjective(Vector3 obj)
    {
        objective = obj;
    }

    //A function to set the shuriken damage
    public void SetShurikenDamage(int damage)
    {
        shurikenDamage = damage;
    }
}
