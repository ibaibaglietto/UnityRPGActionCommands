using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldBattleTrigger : MonoBehaviour
{
    //The user of the attack
    private Transform user;
    //A boolean to know if the battle already started
    private bool inBattle;
    //The current data
    private GameObject currentData;

    void Awake()
    {
        inBattle = false;
        currentData = GameObject.Find("CurrentData");
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player" && !other.GetComponent<WorldPlayerMovementScript>().IsFleeing() &&!inBattle && currentData.GetComponent<CurrentDataScript>().battle == 0)
        {
            inBattle = true;
            other.GetComponent<Animator>().SetTrigger("Damage");
            user.GetComponent<WorldEnemy>().StartBattle(3, 1,0);
            user.GetComponent<WorldEnemy>().SetInBattle(true);
        }
        else if (other.transform.tag == "Companion" && !other.GetComponent<WorldCompanionMovementScript>().IsFleeing() && !inBattle && currentData.GetComponent<CurrentDataScript>().battle == 0)
        {
            inBattle = true;
            other.transform.GetChild(0).GetComponent<Animator>().SetTrigger("Damage");
            user.GetComponent<WorldEnemy>().StartBattle(3, 2,0);
            user.GetComponent<WorldEnemy>().SetInBattle(true);
        }
    }

    //Function to set the user
    public void SetUser(Transform u)
    {
        user = u;
    }
   

}
