using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MagicBallScript : MonoBehaviour
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
    public void SetArrow()
    {
        float r = Random.Range(0.0f, 4.0f);
        if (r < 1.0f)
        {
            transform.GetChild(6).GetComponent<Image>().sprite = upButton;
        }
        else if (r < 2.0f)
        {
            transform.GetChild(6).GetComponent<Image>().sprite = downButton;
        }
        else if (r < 3.0f)
        {
            transform.GetChild(6).GetComponent<Image>().sprite = leftButton;
        }
        else if (r < 4.0f)
        {
            transform.GetChild(6).GetComponent<Image>().sprite = rightButton;
        }
    }

    //A function to start the magic ball action
    public void StartMagicBallAction()
    {
        
        battleController.GetComponent<BattleController>().attackAction = true;
    }

    //A function to end the magic ball action
    public void EndMagicBallAction()
    {
        battleController.GetComponent<BattleController>().attackAction = false;
        battleController.GetComponent<BattleController>().attackFinished = true;
    }

}
