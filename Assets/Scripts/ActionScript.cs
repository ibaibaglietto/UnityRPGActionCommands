using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionScript : MonoBehaviour
{
    private GameObject battleController;
    // Start is called before the first frame update
    void Awake()
    {
        battleController = GameObject.Find("BattleController");
    }


    // Update is called once per frame
    void Update()
    {

    }

    void SelectAction(int action)
    {
        battleController.GetComponent<BattleController>().selectingAction = action;
    }
}
