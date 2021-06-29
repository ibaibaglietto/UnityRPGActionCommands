using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldShurikenArrowScript : MonoBehaviour
{
    //The material of the arrow when no objective is locked
    public Material noObjectiveLockedMaterial;
    //The material of the arrow when an objective is locked
    public Material objectiveLockedMaterial;
    //An int to know the number of enemies in range
    private int enemyNumb;
    //The targeted objective
    private GameObject objective;

    void Start()
    {
        enemyNumb = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "enemy")
        {
            if(enemyNumb == 0) transform.GetChild(0).GetComponent<MeshRenderer>().material = objectiveLockedMaterial;
            enemyNumb += 1;
        }
        if (other.tag == "target")
        {
            objective = other.gameObject;
            transform.parent.GetComponent<WorldPlayerMovementScript>().LockArrow(true);
            other.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "enemy")
        {
            enemyNumb -= 1;
            if (enemyNumb == 0) transform.GetChild(0).GetComponent<MeshRenderer>().material = noObjectiveLockedMaterial;
        }
        if (other.tag == "target")
        {
            other.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
        }
    }

    public GameObject GetObjective()
    {
        return objective;
    }

    public void ResetArrow()
    {
        transform.parent.GetComponent<WorldPlayerMovementScript>().LockArrow(false);
        enemyNumb = 0;
        transform.GetChild(0).GetComponent<MeshRenderer>().material = noObjectiveLockedMaterial;
        if(objective != null) objective.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
    }

}
