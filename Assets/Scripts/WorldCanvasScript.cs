using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorldCanvasScript : MonoBehaviour
{
    //The UI that is only used in battle
    private GameObject actionInstructions;
    private GameObject enemyNames;
    private GameObject fleeAction;
    private GameObject lvlUp;
    private GameObject changePosAction;
    private GameObject canvas;
    private Text xpText;
    //The player life
    private GameObject playerLife;
    //The companion life
    private GameObject companionLife;


    void Awake()
    {
        //We find the UI that is only used in battle
        actionInstructions = GameObject.Find("ActionInstructions");
        enemyNames = GameObject.Find("EnemyNames");
        fleeAction = GameObject.Find("FleeAction");
        lvlUp = GameObject.Find("LvlUp");
        changePosAction = GameObject.Find("ChangeOrder");
        //We put the real values on the canvas
        canvas = GameObject.Find("Canvas");
        xpText = canvas.transform.GetChild(3).GetChild(1).GetComponent<Text>();
        xpText.text = PlayerPrefs.GetInt("lvlXP").ToString();
        playerLife = GameObject.Find("PlayerLifeBckImage");
        companionLife = GameObject.Find("CompanionLifeBckImage");
        playerLife.GetComponent<PlayerLifeScript>().SetUser(0);
        companionLife.GetComponent<PlayerLifeScript>().SetUser(1);
        //We set the state to open world
        PlayerPrefs.SetInt("Battle", 0);
    }

    //Function to hide the UI that is only used in battle
    public void HideUI()
    {
        actionInstructions.SetActive(false);
        enemyNames.SetActive(false);
        fleeAction.SetActive(false);
        lvlUp.SetActive(false);
        changePosAction.SetActive(false);
    }

    //Function to show the UI that is only used in battle
    public void ShowUI()
    {
        actionInstructions.SetActive(true);
        enemyNames.SetActive(true);
        fleeAction.SetActive(true);
        lvlUp.SetActive(true);
        changePosAction.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

}
