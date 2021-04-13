using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldBattleTrigger : MonoBehaviour
{
    //The user of the attack
    Transform user;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            other.GetComponent<Animator>().SetTrigger("Damage");
            user.GetComponent<WorldEnemy>().StartBattle(3, 1);
        }
        else if (other.transform.tag == "Companion")
        {
            other.transform.GetChild(0).GetComponent<Animator>().SetTrigger("Damage");
            user.GetComponent<WorldEnemy>().StartBattle(3, 2);
        }
    }

    //Function to set the user
    public void SetUser(Transform u)
    {
        user = u;
    }
   

}
