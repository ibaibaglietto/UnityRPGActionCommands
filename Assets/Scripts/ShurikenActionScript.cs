using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShurikenActionScript : MonoBehaviour
{

    private GameObject battleController;
    private Transform player;

    // Start is called before the first frame update
    void Start()
    {
        battleController = GameObject.Find("BattleController");
        player = transform.parent.parent;
    }

    public void startShurikenAction()
    {
        battleController.GetComponent<BattleController>().attackAction = true;
    }

    public void endShurikenAction()
    {
        battleController.GetComponent<BattleController>().attackAction = false;
    }

}
