using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MagicSpearScript : MonoBehaviour
{
    //The battle controller
    private GameObject battleController;
    [SerializeField] private Sprite upButton;
    [SerializeField] private Sprite downButton;
    [SerializeField] private Sprite leftButton;
    [SerializeField] private Sprite rightButton;


    void Start()
    {
        //We find the battle controller
        battleController = GameObject.Find("BattleController");
    }
    //Function to set the arrow
    public void SetArrow(int pos)
    {
        float r = Random.Range(0.0f, 4.0f);
        if (r < 1.0f)
        {
            battleController.GetComponent<BattleController>().SetMagicKey(KeyCode.UpArrow);
            transform.GetChild(pos+4).GetComponent<Image>().sprite = upButton;
        }
        else if (r < 2.0f)
        {
            battleController.GetComponent<BattleController>().SetMagicKey(KeyCode.DownArrow);
            transform.GetChild(pos + 4).GetComponent<Image>().sprite = downButton;
        }
        else if (r < 3.0f)
        {
            battleController.GetComponent<BattleController>().SetMagicKey(KeyCode.LeftArrow);
            transform.GetChild(pos + 4).GetComponent<Image>().sprite = leftButton;
        }
        else if (r < 4.0f)
        {
            battleController.GetComponent<BattleController>().SetMagicKey(KeyCode.RightArrow);
            transform.GetChild(pos + 4).GetComponent<Image>().sprite = rightButton;
        }
    }

    //A function to start the magic ball action
    public void StartMagicSpearAction(int pos)
    {
        battleController.GetComponent<BattleController>().attackAction = true;
        battleController.GetComponent<BattleController>().SetMagicSpearNumber(pos);
    }

    //A function to end the magic ball action
    public void EndMagicSpearAction()
    {
        battleController.GetComponent<BattleController>().attackAction = false;
        battleController.GetComponent<BattleController>().attackFinished = true;
    }
}
