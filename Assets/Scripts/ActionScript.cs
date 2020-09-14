using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionScript : MonoBehaviour
{
    //The battle controller
    private GameObject battleController;

    void Awake()
    {
        battleController = GameObject.Find("BattleController");
    }

    //FUnction to save the action we are selecting at the moment
    void SelectAction(int action)
    {
        battleController.GetComponent<BattleController>().selectingAction = action;
    }
}
