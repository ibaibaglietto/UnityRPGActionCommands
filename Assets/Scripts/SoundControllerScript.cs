using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundControllerScript : MonoBehaviour
{
    //The audio mixer
    public AudioMixer mixer;
    //The current data
    private GameObject currentData;


    void Awake()
    {
        currentData = GameObject.Find("CurrentData");
    }

    //3 functions to set the master, music and effects volumes
    public void SetMasterLevel(float sliderValue)
    {
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
        mixer.SetFloat("Effects", Mathf.Log10(sliderValue) * 20);
        currentData.GetComponent<CurrentDataScript>().effects = sliderValue;
    }
}