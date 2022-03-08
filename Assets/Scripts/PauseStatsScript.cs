using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseStatsScript : MonoBehaviour
{
    //The current data
    private CurrentDataScript currentData;
    //The gameobject of every stat
    private Text levelText;
    private Text levelNumb;
    private Text hpCurrent;
    private Text hpMax;
    private Text lpCurrent;
    private Text lpMax;
    private Text gpCurrent;
    private Text gpMax;
    private Text xp;
    private Text coins;
    private GameObject special;
    private GameObject specialMain;

    void Awake()
    {
        currentData = GameObject.Find("CurrentData").GetComponent<CurrentDataScript>();
        levelText = transform.Find("LevelText").GetComponent<Text>();
        levelNumb = transform.Find("LevelNumb").GetComponent<Text>();
        hpCurrent = transform.Find("HPCurrentNumb").GetComponent<Text>();
        hpMax = transform.Find("HPMaxNumb").GetComponent<Text>();
        lpCurrent = transform.Find("LPCurrentNumb").GetComponent<Text>();
        lpMax = transform.Find("LPMaxNumb").GetComponent<Text>();
        gpCurrent = transform.Find("GPCurrentNumb").GetComponent<Text>();
        gpMax = transform.Find("GPMaxHealthNumb").GetComponent<Text>();
        xp = transform.Find("PauseExtraMenuExpCoins").Find("PauseExtraMenuExpText").GetComponent<Text>();
        coins = transform.Find("PauseExtraMenuExpCoins").Find("PauseExtraMenuCoinsText").GetComponent<Text>();
        special = transform.Find("PauseExtraMenuSpecialBckImage").gameObject;
        specialMain = GameObject.Find("SpecialBckImage");
        //TODO: translation
    }

    private void OnEnable()
    {
        levelNumb.text = currentData.playerLvl.ToString();
        hpCurrent.text = currentData.playerCurrentHealth.ToString();
        hpMax.text = (10 + (currentData.playerHeartLvl + currentData.HPUp) * 5).ToString();
        lpCurrent.text = currentData.playerCurrentLight.ToString();
        lpMax.text = (5 + (currentData.playerLightLvl + currentData.LPUp) * 5).ToString();
        gpCurrent.text = (3 + currentData.playerBadgeLvl * 3 - currentData.spentGP).ToString();
        gpMax.text = (3 + currentData.playerBadgeLvl * 3).ToString();
        xp.text = currentData.lvlExp.ToString();
        coins.text = currentData.currentCoins.ToString();
        for (int i = 1; i<=6; i++)
        {
            if(i<= currentData.souls)
            {
                special.transform.GetChild(i).GetChild(0).GetComponent<Image>().fillAmount = specialMain.transform.GetChild(i).GetChild(0).GetComponent<Image>().fillAmount;
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
}
