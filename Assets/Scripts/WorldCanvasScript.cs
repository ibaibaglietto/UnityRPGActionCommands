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
    //The light
    private GameObject teamLight;

    //The items the player has. 0-> no item, 1-> apple, 2 -> light potion, 3-> resurrect potion
    private int[] items = { 2, 1, 1, 2, 3, 1, 1, 2, 1, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

    void Awake()
    {
        PlayerPrefsX.SetIntArray("Items", items);
        //We set the current companion if it has not been set
        if (!PlayerPrefs.HasKey("CurrentCompanion")) PlayerPrefs.SetInt("CurrentCompanion", 1);
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
        teamLight = GameObject.Find("LightBckImage");
        playerLife.GetComponent<PlayerLifeScript>().SetUser(0);
        companionLife.GetComponent<PlayerLifeScript>().SetUser(PlayerPrefs.GetInt("CurrentCompanion"));
        //We set the state to open world
        PlayerPrefs.SetInt("Battle", 0);
    }
    //Function to update the actual coins
    public void UpdateCoins()
    {
        coinsText.text = PlayerPrefs.GetInt("currentCoins").ToString();
    }

    //Function to update the max health and light points
    public void UpdateStats()
    {
        playerLife.GetComponent<PlayerLifeScript>().UpdateHealth();
        companionLife.GetComponent<PlayerLifeScript>().UpdateHealth();
        teamLight.GetComponent<LightPointsScript>().UpdateLight();
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
