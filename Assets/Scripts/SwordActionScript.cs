using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordActionScript : MonoBehaviour
{
    //The battle controller
    private GameObject battleController;


    void Start()
    {
        //We find the battle controller
        battleController = GameObject.Find("BattleController");
    }

    //A function to start the sword action
    public void StartSwordAction()
    {
        battleController.GetComponent<BattleController>().attackAction = true;
    }

    //A function to end the shuriken action
    public void EndSwordAction()
    {
        battleController.GetComponent<BattleController>().attackAction = false;
        battleController.GetComponent<BattleController>().attackFinished = true;
    }


}
