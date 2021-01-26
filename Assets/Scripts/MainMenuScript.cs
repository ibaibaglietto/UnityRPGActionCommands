using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuScript : MonoBehaviour
{
    private GameObject mainMenu;
    private GameObject settings;
    private GameObject battleSettings;

    void Start()
    {
        //We initialize the playerprefs
        PlayerPrefs.SetInt("Light Sword", 1);
        PlayerPrefs.SetInt("Multistrike Sword", 1);
        PlayerPrefs.SetInt("Sword Styles", PlayerPrefs.GetInt("Light Sword") + PlayerPrefs.GetInt("Multistrike Sword"));
        PlayerPrefs.SetInt("Light Shuriken", 1);
        PlayerPrefs.SetInt("Fire Shuriken", 1);
        PlayerPrefs.SetInt("Shuriken Styles", PlayerPrefs.GetInt("Light Shuriken") + PlayerPrefs.GetInt("Fire Shuriken"));
        PlayerPrefs.SetInt("Souls", 6);
        PlayerPrefs.SetInt("PlayerHeartLvl", 5);
        PlayerPrefs.SetInt("PlayerLightLvl", 4);
        PlayerPrefs.SetInt("PlayerBadgeLvl", 0);
        PlayerPrefs.SetInt("PlayerLvl", 1 + PlayerPrefs.GetInt("PlayerHeartLvl") + PlayerPrefs.GetInt("PlayerLightLvl") + PlayerPrefs.GetInt("PlayerBadgeLvl"));
        PlayerPrefs.SetInt("PlayerCurrentHealth", 20);
        PlayerPrefs.SetInt("AdventurerLvl", 3); //3
        PlayerPrefs.SetInt("AdventurerCurrentHealth", 1);
        PlayerPrefs.SetInt("WizardLvl", 3); //3
        PlayerPrefs.SetInt("WizardCurrentHealth", 1);
        PlayerPrefs.SetInt("SwordLvl", 3); //3
        PlayerPrefs.SetInt("ShurikenLvl", 1); //3
        PlayerPrefs.SetInt("language", 0);
        PlayerPrefs.SetInt("bandit", 0);
        PlayerPrefs.SetInt("wizard", 0);
        PlayerPrefs.SetInt("king", 0);
        PlayerPrefs.SetInt("lvlXP", 90);
        PlayerPrefs.SetInt("UnlockedCompanions", 2);
        //We find the gameobjects
        mainMenu = transform.GetChild(1).gameObject;
        settings = transform.GetChild(2).gameObject;
        battleSettings = transform.GetChild(3).gameObject;
    }


    void Update()
    {
        
    }

    public void StartGame()
    {
        
    }

    public void OpenBattleSettings()
    {
        mainMenu.SetActive(false);
        battleSettings.SetActive(true);
    }

    public void CloseGame()
    {
        Application.Quit();
    }

}
