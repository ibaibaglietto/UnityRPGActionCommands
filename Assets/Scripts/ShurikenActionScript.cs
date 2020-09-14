using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShurikenActionScript : MonoBehaviour
{
    //The battle controller
    private GameObject battleController;


    void Start()
    {
        //We find the battle controller
        battleController = GameObject.Find("BattleController");
    }

    //A function to start the shuriken action
    public void StartShurikenAction()
    {
        battleController.GetComponent<BattleController>().attackAction = true;
    }

    //A function to end the shuriken action
    public void EndShurikenAction()
    {
        battleController.GetComponent<BattleController>().attackAction = false;
    }

}
