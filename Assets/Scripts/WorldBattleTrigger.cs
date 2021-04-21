using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldBattleTrigger : MonoBehaviour
{
    //The user of the attack
    private Transform user;
    //A boolean to know if the battle already started
    private bool inBattle;
    // Start is called before the first frame update
    void Awake()
    {
        inBattle = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player" && !other.GetComponent<WorldPlayerMovementScript>().IsFleeing() &&!inBattle)
        {
            inBattle = true;
            other.GetComponent<Animator>().SetTrigger("Damage");
            user.GetComponent<WorldEnemy>().StartBattle(3, 1);
            user.GetComponent<WorldEnemy>().SetInBattle(true);
            Destroy(gameObject);
        }
        else if (other.transform.tag == "Companion" && !other.GetComponent<WorldCompanionMovementScript>().IsFleeing() && !inBattle)
        {
            inBattle = true;
            other.transform.GetChild(0).GetComponent<Animator>().SetTrigger("Damage");
            user.GetComponent<WorldEnemy>().StartBattle(3, 2);
            user.GetComponent<WorldEnemy>().SetInBattle(true);
            Destroy(gameObject);
        }
    }

    //Function to set the user
    public void SetUser(Transform u)
    {
        user = u;
    }
   

}
