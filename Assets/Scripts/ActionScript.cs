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

    //Function to save the action we are selecting at the moment
    void SelectAction(int action)
    {
        battleController.GetComponent<BattleController>().selectingAction = action;
        gameObject.GetComponent<Animator>().SetInteger("Selected",action);
    }

    //Function to save the menu position
    void SelectedMenuPos(int pos)
    {
        battleController.GetComponent<BattleController>().SetMenuSelectionPos(pos);
        gameObject.GetComponent<Animator>().SetInteger("SelectedMenu", pos);
    }


}
