using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShurikenScript : MonoBehaviour
{
    private Vector3 objective;
    private GameObject battleController;
    private int shurikenDamage;

    private void Start()
    {
        battleController = GameObject.Find("BattleController");
    }

    void FixedUpdate()
    {
        if (gameObject.transform.position.x < objective.x) gameObject.transform.position = new Vector3(gameObject.transform.position.x + 0.3f, gameObject.transform.position.y, gameObject.transform.position.z);
        else
        {
            battleController.GetComponent<BattleController>().DealDamage(battleController.GetComponent<BattleController>().getSelectedEnemy(), shurikenDamage);
            Destroy(gameObject);
        }
    }

    public void SetObjective(Vector3 obj)
    {
        objective = obj;
    }

    public void SetShurikenDamage(int damage)
    {
        shurikenDamage = damage;
    }
}
