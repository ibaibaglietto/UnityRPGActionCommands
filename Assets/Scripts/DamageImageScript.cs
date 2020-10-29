using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageImageScript : MonoBehaviour
{
    private bool isDamage;
    private GameObject battleController;
    //1-> player, 2-> companion
    private int isPlayer; 
    private void Awake()
    {
        isDamage = true;
        battleController = GameObject.Find("BattleController");
    }
    //Function to save if the action type
    public void SetDamage(bool type)
    {
        isDamage = type;
    }
    //Function to save if the user is the player or the companion
    public void SetUser(int user)
    {
        isPlayer = user;
    }
    //Function to self Destroy
    public void SelfDestroy()
    {
        if (!isDamage) battleController.GetComponent<BattleController>().EndPlayerTurn(isPlayer);
        Destroy(gameObject);
    }
}
