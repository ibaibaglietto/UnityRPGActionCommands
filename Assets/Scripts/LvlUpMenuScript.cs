using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LvlUpMenuScript : MonoBehaviour
{
    private GameObject battleController;
    private void Start()
    {
        battleController = GameObject.Find("BattleController");
    }
    //Function to select one of the level up positions
    public void SelectPosition(int pos)
    {
        battleController.GetComponent<BattleController>().SetLvlUpSelected(pos);
    }
}
