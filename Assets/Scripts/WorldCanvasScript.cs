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
    //The souls
    private GameObject special;

    //The current data
    private GameObject currentData;

    void Awake()
    {
        currentData = GameObject.Find("CurrentData");
        //We find the UI that is only used in battle
        actionInstructions = GameObject.Find("ActionInstructions");
        enemyNames = GameObject.Find("EnemyNames");
        fleeAction = GameObject.Find("FleeAction");
        lvlUp = GameObject.Find("LvlUp");
        changePosAction = GameObject.Find("ChangeOrder");
        //We put the real values on the canvas
        xpText = transform.GetChild(3).GetChild(1).GetComponent<Text>();
        xpText.text = currentData.GetComponent<CurrentDataScript>().lvlExp.ToString();
        coinsText = transform.GetChild(3).GetChild(3).GetComponent<Text>();
        coinsText.text = currentData.GetComponent<CurrentDataScript>().currentCoins.ToString();
        playerLife = GameObject.Find("PlayerLifeBckImage");
        companionLife = GameObject.Find("CompanionLifeBckImage");
        teamLight = GameObject.Find("LightBckImage");
        playerLife.GetComponent<PlayerLifeScript>().SetUser(0);
        companionLife.GetComponent<PlayerLifeScript>().SetUser(currentData.GetComponent<CurrentDataScript>().currentCompanion);
        //We set the state to open world
        currentData.GetComponent<CurrentDataScript>().battle = 0;
        special = GameObject.Find("SpecialBckImage");
        if (currentData.GetComponent<CurrentDataScript>().unlockedCompanions < 1)
        {
            companionLife.GetComponent<RawImage>().color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
            companionLife.transform.GetChild(0).GetComponent<Text>().color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
            companionLife.transform.GetChild(1).GetComponent<Text>().color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
            companionLife.transform.GetChild(2).GetComponent<Text>().color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
            companionLife.transform.GetChild(3).GetComponent<RawImage>().color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
        }
        for (int i = 1; i <= 6; i++)
        {
            if (i <= currentData.GetComponent<CurrentDataScript>().souls)
            {
                //TODO: fill amount
                special.transform.GetChild(i).GetComponent<Image>().color = new Color(special.transform.GetChild(i).GetComponent<Image>().color.r, special.transform.GetChild(i).GetComponent<Image>().color.g, special.transform.GetChild(i).GetComponent<Image>().color.b, 1.0f);
                special.transform.GetChild(i).GetChild(0).GetComponent<Image>().color = new Color(special.transform.GetChild(i).GetChild(0).GetComponent<Image>().color.r, special.transform.GetChild(i).GetChild(0).GetComponent<Image>().color.g, special.transform.GetChild(i).GetChild(0).GetComponent<Image>().color.b, 1.0f);
            }
            else
            {
                special.transform.GetChild(i).GetComponent<Image>().color = new Color(special.transform.GetChild(i).GetComponent<Image>().color.r, special.transform.GetChild(i).GetComponent<Image>().color.g, special.transform.GetChild(i).GetComponent<Image>().color.b, 0.0f);
                special.transform.GetChild(i).GetChild(0).GetComponent<Image>().color = new Color(special.transform.GetChild(i).GetChild(0).GetComponent<Image>().color.r, special.transform.GetChild(i).GetChild(0).GetComponent<Image>().color.g, special.transform.GetChild(i).GetChild(0).GetComponent<Image>().color.b, 0.0f);
            }
        }
    }
    //Function to update the actual coins
    public void UpdateCoins()
    {
        coinsText.text = currentData.GetComponent<CurrentDataScript>().currentCoins.ToString();
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
