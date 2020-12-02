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

    public void SelectPosition(int pos)
    {
        battleController.GetComponent<BattleController>().SetLvlUpSelected(pos);
    }
}
