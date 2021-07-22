﻿using System.Collections;
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
    //a boolean to know if an enemy is already targeted
    private bool targeted;
    //The targeted objective
    private GameObject objective;

    void Start()
    {
        targeted = false;
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
            if (targeted)
            {
                if((Mathf.Abs(objective.transform.position.x - transform.position.x) + Mathf.Abs(objective.transform.position.z - transform.position.z)) > (Mathf.Abs(other.transform.position.x - transform.position.x) + Mathf.Abs(other.transform.position.z - transform.position.z)))
                {
                    objective.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
                    objective = other.gameObject;
                    transform.parent.GetComponent<WorldPlayerMovementScript>().LockArrow(true);
                    other.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
                }
            }
            else
            {
                transform.GetChild(0).GetComponent<MeshRenderer>().material = objectiveLockedMaterial;
                targeted = true;
                objective = other.gameObject;
                transform.parent.GetComponent<WorldPlayerMovementScript>().LockArrow(true);
                other.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
            }
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
            transform.GetChild(0).GetComponent<MeshRenderer>().material = noObjectiveLockedMaterial;
            other.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
            targeted = false;
        }
    }

    public GameObject GetObjective()
    {
        if(targeted) return objective.transform.parent.gameObject;
        else return transform.GetChild(1).gameObject;
    }

    public void ResetArrow()
    {
        transform.parent.GetComponent<WorldPlayerMovementScript>().LockArrow(false);
        enemyNumb = 0;
        transform.GetChild(0).GetComponent<MeshRenderer>().material = noObjectiveLockedMaterial;
        if(targeted) objective.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
        targeted = false;
    }

}