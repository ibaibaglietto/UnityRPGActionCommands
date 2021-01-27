using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour
{
    private GameObject mainMenu;
    private GameObject settings;
    private GameObject battleSettings;
    private Dropdown LifeLvl;
    private Dropdown LightLvl;
    private Dropdown SwordLvl;
    private Dropdown ShurikenLvl;
    private Dropdown AdventurerLvl;
    private Dropdown WizardLvl;
    private Dropdown Enemy1;
    private Dropdown Enemy2;
    private Dropdown Enemy3;
    private Dropdown Enemy4;
    private Text explanationText;

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
        PlayerPrefs.SetInt("Enemy1", 0);
        PlayerPrefs.SetInt("Enemy2", -1);
        PlayerPrefs.SetInt("Enemy3", -1);
        PlayerPrefs.SetInt("Enemy4", -1);
        PlayerPrefs.SetInt("UnlockedCompanions", 2);
        //We find the gameobjects
        mainMenu = transform.GetChild(1).gameObject;
        settings = transform.GetChild(2).gameObject;
        battleSettings = transform.GetChild(3).gameObject;
        LifeLvl = battleSettings.transform.Find("LifeLvlDropdown").GetComponent<Dropdown>();
        LightLvl = battleSettings.transform.Find("LightLvlDropdown").GetComponent<Dropdown>();
        SwordLvl = battleSettings.transform.Find("SwordLvlDropdown").GetComponent<Dropdown>();
        ShurikenLvl = battleSettings.transform.Find("ShurikenLvlDropdown").GetComponent<Dropdown>();
        AdventurerLvl = battleSettings.transform.Find("AdventurerDropdown").GetComponent<Dropdown>();
        WizardLvl = battleSettings.transform.Find("WizardDropdown").GetComponent<Dropdown>();
        Enemy1 = battleSettings.transform.Find("Enemy1Dropdown").GetComponent<Dropdown>();
        Enemy2 = battleSettings.transform.Find("Enemy2Dropdown").GetComponent<Dropdown>();
        Enemy3 = battleSettings.transform.Find("Enemy3Dropdown").GetComponent<Dropdown>();
        Enemy4 = battleSettings.transform.Find("Enemy4Dropdown").GetComponent<Dropdown>();
        explanationText = battleSettings.transform.Find("ExplanationText").GetComponent<Text>();
    }


    void Update()
    {
        
    }

    //Function to start the game
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    //Function to open the battle settings
    public void OpenBattleSettings()
    {
        mainMenu.SetActive(false);
        battleSettings.SetActive(true);
    }

    //Function to make active the enemy3 and enemy4 dropdowns
    public void ActivateEnemyDropdown()
    {
        if (Enemy2.value > 0) Enemy3.interactable = true;
        if (Enemy3.value > 0) Enemy4.interactable = true;
        if (Enemy2.value == 0)
        {
            Enemy3.value = 0;
            Enemy3.interactable = false;
            Enemy4.value = 0;
            Enemy4.interactable = false;
        }
        if (Enemy3.value == 0)
        {
            Enemy4.value = 0;
            Enemy4.interactable = false;
        }
    }

    //Function to change the explanation text
    public void ChangeExplanationText(int d)
    {
        if (d == 0) explanationText.text = "Change the maximum life points of the player.";
        else if (d == 1) explanationText.text = "Change the maximum light points of the player. You will need them to use some abilities.";
        else if (d == 2) explanationText.text = "Change the sword level. More level equals more damage.";
        else if (d == 3) explanationText.text = "Change the shuriken level. More level equals more damage.";
        else if (d == 4) explanationText.text = "Change the level of the adventurer companion. He will gain life points, abilities and damage.";
        else if (d == 5) explanationText.text = "Change the level of the wizard companion. He will gain life points, abilities and damage.";
        else if (d == 6) explanationText.text = "Change the first enemy. You can choose between two normal enemies, a bandit and a wizard, and a boss, the king.";
        else if (d == 7) explanationText.text = "Change the second enemy. You can choose between two normal enemies, a bandit and a wizard, and a boss, the king.";
        else if (d == 8) explanationText.text = "Change the third enemy. You can choose between two normal enemies, a bandit and a wizard, and a boss, the king.";
        else if (d == 9) explanationText.text = "Change the fourth enemy. You can choose between two normal enemies, a bandit and a wizard, and a boss, the king.";
        else if (d == 10) explanationText.text = "Change the battle settings.";
    }

    //Function to close the battle settings
    public void CloseBattleSettings()
    {
        PlayerPrefs.SetInt("PlayerHeartLvl", LifeLvl.value);
        PlayerPrefs.SetInt("PlayerLightLvl", LightLvl.value);
        PlayerPrefs.SetInt("PlayerLvl", 1 + PlayerPrefs.GetInt("PlayerHeartLvl") + PlayerPrefs.GetInt("PlayerLightLvl") + PlayerPrefs.GetInt("PlayerBadgeLvl"));
        PlayerPrefs.SetInt("PlayerCurrentHealth", 10 + LifeLvl.value*5);
        PlayerPrefs.SetInt("AdventurerLvl", AdventurerLvl.value + 1); 
        PlayerPrefs.SetInt("AdventurerCurrentHealth", 10 + (AdventurerLvl.value + 1) * 10);
        PlayerPrefs.SetInt("WizardLvl", WizardLvl.value + 1); 
        PlayerPrefs.SetInt("WizardCurrentHealth", 15 + (WizardLvl.value + 1) * 10);
        PlayerPrefs.SetInt("SwordLvl", SwordLvl.value + 1); 
        PlayerPrefs.SetInt("ShurikenLvl", ShurikenLvl.value + 1); 
        PlayerPrefs.SetInt("Enemy1", Enemy1.value);
        PlayerPrefs.SetInt("Enemy2", Enemy2.value);
        PlayerPrefs.SetInt("Enemy3", Enemy3.value);
        PlayerPrefs.SetInt("Enemy4", Enemy4.value);
        mainMenu.SetActive(true);
        battleSettings.SetActive(false);
    }

    //Function to close the game
    public void CloseGame()
    {
        Debug.Log("Closing...");
        Application.Quit();
    }

}
