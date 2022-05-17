using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class IngameConfigurationScript : MonoBehaviour
{
    //The audio mixer
    [SerializeField] private AudioMixer mixer;
    //The menus
    private GameObject confirmResolution;
    //The configuration sliders dropdowns and toggle
    private Slider masterSlider;
    private Slider musicSlider;
    private Slider effectsSlider;
    private Dropdown resolution;
    private Toggle fullscreen;
    private Dropdown language;
    //The confirm resolution time and button
    private float confirmTime;
    private Text confirmTimeNumb;
    private Button saveResolutionButton;
    private AudioSource effectsSource;
    //The current data
    private CurrentDataScript currentData;
    //The language resolver
    private LangResolverScript langResolver;


    void Start()
    {
        //We find the gameobjects and others
        currentData = GameObject.Find("CurrentData").GetComponent<CurrentDataScript>();
        langResolver = GameObject.Find("CurrentData").GetComponent<LangResolverScript>();
        saveResolutionButton = transform.Find("SaveResolution").GetComponent<Button>();
        confirmResolution = transform.Find("ConfirmResolutionChange").gameObject;
        confirmTimeNumb = confirmResolution.transform.Find("TimeNumb").GetComponent<Text>();
        masterSlider = transform.Find("MainVolumeSlider").GetComponent<Slider>();
        musicSlider = transform.Find("MusicVolumeSlider").GetComponent<Slider>();
        effectsSlider = transform.Find("EffectsVolumeSlider").GetComponent<Slider>();
        fullscreen = transform.Find("FullScreenToggle").GetComponent<Toggle>();
        resolution = transform.Find("ResolutionDropdown").GetComponent<Dropdown>();
        language = transform.Find("LanguageDropdown").GetComponent<Dropdown>();
        //We set the audio mixers
        mixer.SetFloat("Master", Mathf.Log10(currentData.master) * 20);
        mixer.SetFloat("Music", Mathf.Log10(currentData.music) * 20);
        mixer.SetFloat("Effects", Mathf.Log10(currentData.effects) * 20);
        //We find the effects audio source
        effectsSource = GameObject.Find("UISource").GetComponent<AudioSource>();
        //We initialize the settings
        masterSlider.value = currentData.master;
        musicSlider.value = currentData.music;
        effectsSlider.value = currentData.effects;
        fullscreen.isOn = (currentData.fullScreen == 1);
        if (currentData.resolutionY == 360) resolution.value = 0;
        else if (currentData.resolutionY == 480) resolution.value = 1;
        else if (currentData.resolutionY == 720) resolution.value = 2;
        else if (currentData.resolutionY == 1080) resolution.value = 3;
        else if (currentData.resolutionY == 1440) resolution.value = 4;
        else if (currentData.resolutionY == 2160) resolution.value = 5;
        language.value = currentData.language - 1;

        confirmTime = -1.0f;
        confirmResolution.SetActive(false);
    }


    void Update()
    {
        //If we are changing the resolution
        if (confirmTime != -1.0f)
        {
            //We change the countdown number
            confirmTimeNumb.text = (5 - (int)(Time.fixedTime - confirmTime)).ToString();
            //If the player presses the space button we confirm the resolution
            if (Input.GetKeyDown(KeyCode.Space) && (Time.fixedTime - confirmTime) > 0.05f) ConfirmResolution();
            //If the countdown reaches 0 we restore the previous resolution
            if ((Time.fixedTime - confirmTime) > 5.0f)
            {
                Screen.SetResolution(currentData.resolutionX, currentData.resolutionY, currentData.fullScreen == 1);
                fullscreen.isOn = (currentData.fullScreen == 1);
                if (currentData.resolutionY == 360) resolution.value = 0;
                else if (currentData.resolutionY == 480) resolution.value = 1;
                else if (currentData.resolutionY == 720) resolution.value = 2;
                else if (currentData.resolutionY == 1080) resolution.value = 3;
                else if (currentData.resolutionY == 1440) resolution.value = 4;
                else if (currentData.resolutionY == 2160) resolution.value = 5;
                confirmResolution.SetActive(false);
                confirmTime = -1.0f;
                saveResolutionButton.interactable = false;
            }
        }
    }
    //Function to change the language
    public void ChangeLanguage()
    {
        effectsSource.Play();
        currentData.language = language.value + 1;
        langResolver.ReadProperties();
    }

    //Function to make the effect play
    public void UIEffect()
    {
        effectsSource.Play();
    }


    //Function to close the settings
    public void CloseSettings()
    {
        effectsSource.Play();
        fullscreen.isOn = (currentData.fullScreen == 1);
        if (currentData.resolutionY == 360) resolution.value = 0;
        else if (currentData.resolutionY == 480) resolution.value = 1;
        else if (currentData.resolutionY == 720) resolution.value = 2;
        else if (currentData.resolutionY == 1080) resolution.value = 3;
        else if (currentData.resolutionY == 1440) resolution.value = 4;
        else if (currentData.resolutionY == 2160) resolution.value = 5;
    }

    //Function to make the save resolution button interactable
    public void ResolutionChanged()
    {
        if (!confirmResolution.activeSelf) effectsSource.Play();
        if (fullscreen.isOn != (currentData.fullScreen == 1))
        {
            saveResolutionButton.interactable = true;
        }
        else
        {
            if (currentData.resolutionY == 360 && resolution.value == 0)
            {
                saveResolutionButton.interactable = false;
            }
            else if (currentData.resolutionY == 480 && resolution.value == 1)
            {
                saveResolutionButton.interactable = false;
            }
            else if (currentData.resolutionY == 720 && resolution.value == 2)
            {
                saveResolutionButton.interactable = false;
            }
            else if (currentData.resolutionY == 1080 && resolution.value == 3)
            {
                saveResolutionButton.interactable = false;
            }
            else if (currentData.resolutionY == 1440 && resolution.value == 4)
            {
                saveResolutionButton.interactable = false;
            }
            else if (currentData.resolutionY == 2160 && resolution.value == 5)
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
        effectsSource.Play();
        if (resolution.value == 0) Screen.SetResolution(640, 360, fullscreen.isOn);
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
        effectsSource.Play();
        if (resolution.value == 0)
        {
            currentData.resolutionX = 640;
            currentData.resolutionY = 360;
        }
        else if (resolution.value == 1)
        {
            currentData.resolutionX = 854;
            currentData.resolutionY = 480;
        }
        else if (resolution.value == 2)
        {
            currentData.resolutionX = 1280;
            currentData.resolutionY = 720;
        }
        else if (resolution.value == 3)
        {
            currentData.resolutionX = 1920;
            currentData.resolutionY = 1080;
        }
        else if (resolution.value == 4)
        {
            currentData.resolutionX = 2560;
            currentData.resolutionY = 1440;
        }
        else if (resolution.value == 5)
        {
            currentData.resolutionX = 3840;
            currentData.resolutionY = 2160;
        }
        if (fullscreen.isOn) currentData.fullScreen = 1;
        else currentData.fullScreen = 0;
        confirmTime = -1.0f;
        confirmResolution.SetActive(false);
        saveResolutionButton.interactable = false;
    }

    //3 functions to set the master, music and effects volumes
    public void SetMasterLevel(float sliderValue)
    {
        effectsSource.Play();
        mixer.SetFloat("Master", Mathf.Log10(sliderValue) * 20);
        currentData.GetComponent<CurrentDataScript>().master = sliderValue;
    }
    public void SetMusicLevel(float sliderValue)
    {
        mixer.SetFloat("Music", Mathf.Log10(sliderValue) * 20);
        currentData.GetComponent<CurrentDataScript>().music = sliderValue;
    }
    public void SetEffectsLevel(float sliderValue)
    {
        effectsSource.Play();
        mixer.SetFloat("Effects", Mathf.Log10(sliderValue) * 20);
        currentData.GetComponent<CurrentDataScript>().effects = sliderValue;
    }

    //Function to close the game
    public void CloseGame()
    {
        effectsSource.Play();
        Debug.Log("Closing...");
        Application.Quit();
    }
}
