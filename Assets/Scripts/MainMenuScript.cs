using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class MainMenuScript : MonoBehaviour
{
    [SerializeField] private AudioMixer mixer;
    private GameObject mainMenu;
    private GameObject settings;
    private GameObject battleSettings;
    private GameObject confirmResolution;
    private GameObject howToPlay;
    private Dropdown resolution;
    private Toggle fullscreen; 
    private Dropdown lifeLvl;
    private Dropdown lightLvl;
    private Dropdown swordLvl;
    private Dropdown shurikenLvl;
    private Dropdown adventurerLvl;
    private Dropdown wizardLvl;
    private Dropdown enemy1;
    private Dropdown enemy2;
    private Dropdown enemy3;
    private Dropdown enemy4;
    private Text explanationText;
    private float confirmTime;
    private Text confirmTimeNumb;
    private Button saveResolutionButton;
    //Int to know the actual explanation
    private int explanation;


    void Start()
    {
        //PlayerPrefs.DeleteAll();
        //We initialize the playerprefs
        if (!PlayerPrefs.HasKey("First"))
        {
            PlayerPrefs.SetInt("Light Sword", 1);
            PlayerPrefs.SetInt("Multistrike Sword", 1);
            PlayerPrefs.SetInt("Sword Styles", PlayerPrefs.GetInt("Light Sword") + PlayerPrefs.GetInt("Multistrike Sword"));
            PlayerPrefs.SetInt("Light Shuriken", 1);
            PlayerPrefs.SetInt("Fire Shuriken", 1);
            PlayerPrefs.SetInt("Shuriken Styles", PlayerPrefs.GetInt("Light Shuriken") + PlayerPrefs.GetInt("Fire Shuriken"));
            PlayerPrefs.SetInt("Souls", 6);
            PlayerPrefs.SetInt("PlayerHeartLvl", 0);
            PlayerPrefs.SetInt("PlayerLightLvl", 0);
            PlayerPrefs.SetInt("PlayerBadgeLvl", 0);
            PlayerPrefs.SetInt("PlayerLvl", 1 + PlayerPrefs.GetInt("PlayerHeartLvl") + PlayerPrefs.GetInt("PlayerLightLvl") + PlayerPrefs.GetInt("PlayerBadgeLvl"));
            PlayerPrefs.SetInt("PlayerCurrentHealth", 10);
            PlayerPrefs.SetInt("AdventurerLvl", 1); //3
            PlayerPrefs.SetInt("AdventurerCurrentHealth", 20);
            PlayerPrefs.SetInt("WizardLvl", 1); //3
            PlayerPrefs.SetInt("WizardCurrentHealth", 25);
            PlayerPrefs.SetInt("SwordLvl", 1); //3
            PlayerPrefs.SetInt("ShurikenLvl", 1); //3
            PlayerPrefs.SetInt("language", 0);
            PlayerPrefs.SetInt("bandit", 0);
            PlayerPrefs.SetInt("wizard", 0);
            PlayerPrefs.SetInt("king", 0);
            PlayerPrefs.SetInt("lvlXP", 90);
            PlayerPrefs.SetInt("Enemy1", 0);
            PlayerPrefs.SetInt("Enemy2", 0);
            PlayerPrefs.SetInt("Enemy3", 0);
            PlayerPrefs.SetInt("Enemy4", 0);
            PlayerPrefs.SetFloat("Master", 1.0f);
            PlayerPrefs.SetFloat("Music", 1.0f);
            PlayerPrefs.SetFloat("Effects", 1.0f);
            PlayerPrefs.SetInt("UnlockedCompanions", 2);
            PlayerPrefs.SetInt("FullScreen", 1);
            PlayerPrefs.SetInt("Resolutionx", 1280);
            PlayerPrefs.SetInt("Resolutiony", 720);
            PlayerPrefs.SetInt("First", 1);
        }
        mixer.SetFloat("Master", Mathf.Log10(PlayerPrefs.GetFloat("Master")) * 20);
        mixer.SetFloat("Music", Mathf.Log10(PlayerPrefs.GetFloat("Music")) * 20);
        mixer.SetFloat("Effects", Mathf.Log10(PlayerPrefs.GetFloat("Effects")) * 20);
        //We find the gameobjects
        mainMenu = transform.GetChild(1).gameObject;
        settings = transform.GetChild(2).gameObject;
        saveResolutionButton = settings.transform.Find("SaveResolution").GetComponent<Button>();
        battleSettings = transform.GetChild(3).gameObject;
        howToPlay = transform.GetChild(4).gameObject;
        confirmResolution = settings.transform.Find("ConfirmResolutionChange").gameObject;
        confirmTimeNumb = confirmResolution.transform.Find("TimeNumb").GetComponent<Text>();
        fullscreen = settings.transform.Find("FullScreenToggle").GetComponent<Toggle>();
        resolution = settings.transform.Find("ResolutionDropdown").GetComponent<Dropdown>();
        lifeLvl = battleSettings.transform.Find("LifeLvlDropdown").GetComponent<Dropdown>();
        lightLvl = battleSettings.transform.Find("LightLvlDropdown").GetComponent<Dropdown>();
        swordLvl = battleSettings.transform.Find("SwordLvlDropdown").GetComponent<Dropdown>();
        shurikenLvl = battleSettings.transform.Find("ShurikenLvlDropdown").GetComponent<Dropdown>();
        adventurerLvl = battleSettings.transform.Find("AdventurerDropdown").GetComponent<Dropdown>();
        wizardLvl = battleSettings.transform.Find("WizardDropdown").GetComponent<Dropdown>();
        enemy1 = battleSettings.transform.Find("Enemy1Dropdown").GetComponent<Dropdown>();
        enemy2 = battleSettings.transform.Find("Enemy2Dropdown").GetComponent<Dropdown>();
        enemy3 = battleSettings.transform.Find("Enemy3Dropdown").GetComponent<Dropdown>();
        enemy4 = battleSettings.transform.Find("Enemy4Dropdown").GetComponent<Dropdown>();
        explanationText = battleSettings.transform.Find("ExplanationText").GetComponent<Text>();
        //We initialize the settings
        fullscreen.isOn = (PlayerPrefs.GetInt("FullScreen") == 1);
        if (PlayerPrefs.GetInt("Resolutiony") == 360) resolution.value = 0;
        else if (PlayerPrefs.GetInt("Resolutiony") == 480) resolution.value = 1;
        else if (PlayerPrefs.GetInt("Resolutiony") == 720) resolution.value = 2;
        else if (PlayerPrefs.GetInt("Resolutiony") == 1080) resolution.value = 3;
        else if (PlayerPrefs.GetInt("Resolutiony") == 1440) resolution.value = 4;
        else if (PlayerPrefs.GetInt("Resolutiony") == 2160) resolution.value = 5;
        confirmTime = -1.0f;
        //We initialize the battle settings
        lifeLvl.value = PlayerPrefs.GetInt("PlayerHeartLvl");
        lightLvl.value = PlayerPrefs.GetInt("PlayerLightLvl");
        adventurerLvl.value = PlayerPrefs.GetInt("AdventurerLvl") - 1;
        wizardLvl.value = PlayerPrefs.GetInt("WizardLvl") - 1;
        swordLvl.value = PlayerPrefs.GetInt("SwordLvl") - 1;
        shurikenLvl.value = PlayerPrefs.GetInt("ShurikenLvl") - 1;
        enemy1.value = PlayerPrefs.GetInt("Enemy1");
        enemy2.value = PlayerPrefs.GetInt("Enemy2");
        enemy3.value = PlayerPrefs.GetInt("Enemy3");
        enemy4.value = PlayerPrefs.GetInt("Enemy4");
        settings.SetActive(false);
        battleSettings.SetActive(false);
        confirmResolution.SetActive(false);
        howToPlay.SetActive(false);
        explanation = 1;
    }


    void Update()
    {
        if(confirmTime != -1.0f)
        {
            confirmTimeNumb.text = (5 - (int)(Time.fixedTime - confirmTime)).ToString();
            if ((Time.fixedTime - confirmTime) > 5.0f)
            {
                Screen.SetResolution(PlayerPrefs.GetInt("Resolutionx"), PlayerPrefs.GetInt("Resolutiony"), PlayerPrefs.GetInt("FullScreen") == 1);
                confirmResolution.SetActive(false);
                settings.SetActive(true);
                fullscreen.isOn = (PlayerPrefs.GetInt("FullScreen") == 1);
                if (PlayerPrefs.GetInt("Resolutiony") == 360) resolution.value = 0;
                else if (PlayerPrefs.GetInt("Resolutiony") == 480) resolution.value = 1;
                else if (PlayerPrefs.GetInt("Resolutiony") == 720) resolution.value = 2;
                else if (PlayerPrefs.GetInt("Resolutiony") == 1080) resolution.value = 3;
                else if (PlayerPrefs.GetInt("Resolutiony") == 1440) resolution.value = 4;
                else if (PlayerPrefs.GetInt("Resolutiony") == 2160) resolution.value = 5;
                confirmTime = -1.0f;
                saveResolutionButton.interactable = false;
            }
        }
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
        if (enemy2.value > 0) enemy3.interactable = true;
        if (enemy3.value > 0) enemy4.interactable = true;
        if (enemy2.value == 0)
        {
            enemy3.value = 0;
            enemy3.interactable = false;
            enemy4.value = 0;
            enemy4.interactable = false;
        }
        if (enemy3.value == 0)
        {
            enemy4.value = 0;
            enemy4.interactable = false;
        }
    }

    //Function to open the settings
    public void OpenSettings()
    {
        mainMenu.SetActive(false);
        settings.SetActive(true);
    }

    //Function to close the settings
    public void CloseSettings()
    {
        mainMenu.SetActive(true);
        settings.SetActive(false);
        fullscreen.isOn = (PlayerPrefs.GetInt("FullScreen") == 1);
        if (PlayerPrefs.GetInt("Resolutiony") == 360) resolution.value = 0;
        else if (PlayerPrefs.GetInt("Resolutiony") == 480) resolution.value = 1;
        else if (PlayerPrefs.GetInt("Resolutiony") == 720) resolution.value = 2;
        else if (PlayerPrefs.GetInt("Resolutiony") == 1080) resolution.value = 3;
        else if (PlayerPrefs.GetInt("Resolutiony") == 1440) resolution.value = 4;
        else if (PlayerPrefs.GetInt("Resolutiony") == 2160) resolution.value = 5;
    }

    //Function to make the save resolution button interactable
    public void ResolutionChanged()
    {
        if (fullscreen.isOn != (PlayerPrefs.GetInt("FullScreen") == 1))
        {
            saveResolutionButton.interactable = true;
        }
        else 
        {
            if (PlayerPrefs.GetInt("Resolutiony") == 360 && resolution.value == 0) 
            {
                saveResolutionButton.interactable = false;
            }
            else if (PlayerPrefs.GetInt("Resolutiony") == 480 && resolution.value == 1)
            {
                saveResolutionButton.interactable = false;
            }
            else if (PlayerPrefs.GetInt("Resolutiony") == 720 && resolution.value == 2)
            {
                saveResolutionButton.interactable = false;
            }
            else if (PlayerPrefs.GetInt("Resolutiony") == 1080 && resolution.value == 3)
            {
                saveResolutionButton.interactable = false;
            }
            else if (PlayerPrefs.GetInt("Resolutiony") == 1440 && resolution.value == 4)
            {
                saveResolutionButton.interactable = false;
            }
            else if (PlayerPrefs.GetInt("Resolutiony") == 2160 && resolution.value == 5)
            {
                saveResolutionButton.interactable = false;
            }
            else
            {
                saveResolutionButton.interactable = true;
            }
        }
    }

    //Function to save the resolution settings
    public void SaveResolution()
    {
        if (resolution.value == 0) Screen.SetResolution(640,360,fullscreen.isOn);
        else if (resolution.value == 1) Screen.SetResolution(854, 480, fullscreen.isOn);
        else if (resolution.value == 2) Screen.SetResolution(1280, 720, fullscreen.isOn);
        else if (resolution.value == 3) Screen.SetResolution(1920, 1080, fullscreen.isOn);
        else if (resolution.value == 4) Screen.SetResolution(2560, 1440, fullscreen.isOn);
        else if (resolution.value == 5) Screen.SetResolution(3840, 2160, fullscreen.isOn);
        confirmTime = Time.fixedTime;
        confirmResolution.SetActive(true);
    }
    //Function to confirm the resolution settings
    public void ConfirmResolution()
    {
        if (resolution.value == 0)
        {
            PlayerPrefs.SetInt("Resolutionx", 640);
            PlayerPrefs.SetInt("Resolutiony", 360);
        }
        else if (resolution.value == 1)
        {
            PlayerPrefs.SetInt("Resolutionx", 854);
            PlayerPrefs.SetInt("Resolutiony", 480);
        }
        else if (resolution.value == 2)
        {
            PlayerPrefs.SetInt("Resolutionx", 1280);
            PlayerPrefs.SetInt("Resolutiony", 720);
        }
        else if (resolution.value == 3)
        {
            PlayerPrefs.SetInt("Resolutionx", 1920);
            PlayerPrefs.SetInt("Resolutiony", 1080);
        }
        else if (resolution.value == 4)
        {
            PlayerPrefs.SetInt("Resolutionx", 2560);
            PlayerPrefs.SetInt("Resolutiony", 1440);
        }
        else if (resolution.value == 5)
        {
            PlayerPrefs.SetInt("Resolutionx", 3840);
            PlayerPrefs.SetInt("Resolutiony", 2160);
        }
        if (fullscreen.isOn) PlayerPrefs.SetInt("FullScreen", 1);
        else PlayerPrefs.SetInt("FullScreen", 0);
        confirmTime = -1.0f;
        confirmResolution.SetActive(false); 
        saveResolutionButton.interactable = false;
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
        PlayerPrefs.SetInt("PlayerHeartLvl", lifeLvl.value);
        PlayerPrefs.SetInt("PlayerLightLvl", lightLvl.value);
        PlayerPrefs.SetInt("PlayerLvl", 1 + PlayerPrefs.GetInt("PlayerHeartLvl") + PlayerPrefs.GetInt("PlayerLightLvl") + PlayerPrefs.GetInt("PlayerBadgeLvl"));
        PlayerPrefs.SetInt("PlayerCurrentHealth", 10 + lifeLvl.value*5);
        PlayerPrefs.SetInt("AdventurerLvl", adventurerLvl.value + 1); 
        PlayerPrefs.SetInt("AdventurerCurrentHealth", 10 + (adventurerLvl.value + 1) * 10);
        PlayerPrefs.SetInt("WizardLvl", wizardLvl.value + 1); 
        PlayerPrefs.SetInt("WizardCurrentHealth", 15 + (wizardLvl.value + 1) * 10);
        PlayerPrefs.SetInt("SwordLvl", swordLvl.value + 1); 
        PlayerPrefs.SetInt("ShurikenLvl", shurikenLvl.value + 1); 
        PlayerPrefs.SetInt("Enemy1", enemy1.value);
        PlayerPrefs.SetInt("Enemy2", enemy2.value);
        PlayerPrefs.SetInt("Enemy3", enemy3.value);
        PlayerPrefs.SetInt("Enemy4", enemy4.value);
        mainMenu.SetActive(true);
        battleSettings.SetActive(false);
    }

    //Function to open the how to play tutorial
    public void OpenHowToPlay()
    {
        mainMenu.SetActive(false);
        howToPlay.SetActive(true);
    }

    //Function to close the how to play tutorial
    public void CloseHowToPlay()
    {
        howToPlay.transform.GetChild(1 + explanation).gameObject.SetActive(false);
        explanation = 1;
        howToPlay.transform.GetChild(1 + explanation).gameObject.SetActive(true);
        howToPlay.transform.GetChild(8).GetComponent<Button>().interactable = false;
        howToPlay.transform.GetChild(9).GetComponent<Button>().interactable = true;
        mainMenu.SetActive(true);
        howToPlay.SetActive(false);
    }

    public void NextExplanation()
    {
        howToPlay.transform.GetChild(1+explanation).gameObject.SetActive(false);
        explanation += 1;
        howToPlay.transform.GetChild(1 + explanation).gameObject.SetActive(true);
        if (explanation == 6) howToPlay.transform.GetChild(9).GetComponent<Button>().interactable = false;
        else howToPlay.transform.GetChild(9).GetComponent<Button>().interactable = true;
        howToPlay.transform.GetChild(8).GetComponent<Button>().interactable = true;
    }

    public void PrevExplanation()
    {
        howToPlay.transform.GetChild(1 + explanation).gameObject.SetActive(false);
        explanation -= 1;
        howToPlay.transform.GetChild(1 + explanation).gameObject.SetActive(true);
        if (explanation == 1) howToPlay.transform.GetChild(8).GetComponent<Button>().interactable = false;
        else howToPlay.transform.GetChild(8).GetComponent<Button>().interactable = true;
        howToPlay.transform.GetChild(9).GetComponent<Button>().interactable = true;
    }


    //Function to close the game
    public void CloseGame()
    {
        Debug.Log("Closing...");
        Application.Quit();
    }

}
