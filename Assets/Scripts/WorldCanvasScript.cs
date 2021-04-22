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
    private Text xpText;
    private Text coinsText;
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
        xpText = transform.GetChild(3).GetChild(1).GetComponent<Text>();
        if (!PlayerPrefs.HasKey("lvlXP")) PlayerPrefs.SetInt("lvlXP", 0);
        xpText.text = PlayerPrefs.GetInt("lvlXP").ToString();
        coinsText = transform.GetChild(3).GetChild(3).GetComponent<Text>();
        if (!PlayerPrefs.HasKey("currentCoins")) PlayerPrefs.SetInt("currentCoins", 0);
        coinsText.text = PlayerPrefs.GetInt("currentCoins").ToString();
        playerLife = GameObject.Find("PlayerLifeBckImage");
        companionLife = GameObject.Find("CompanionLifeBckImage");
        playerLife.GetComponent<PlayerLifeScript>().SetUser(0);
        companionLife.GetComponent<PlayerLifeScript>().SetUser(1);
        //We set the state to open world
        PlayerPrefs.SetInt("Battle", 0);
    }

    public void UpdateCoins()
    {
        coinsText.text = PlayerPrefs.GetInt("currentCoins").ToString();
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
