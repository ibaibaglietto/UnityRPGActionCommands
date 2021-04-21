using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LightPointsScript : MonoBehaviour
{
    //An int to save the max health of the player
    private int maxLight;
    //An int to save the current health of the player
    private int currentLight;
    //The max health text
    private Text maxLightText;
    //The current health text
    private Text currentLightText;


    void Start()
    {
        //We save the max light and the current light
        maxLight = 5 + PlayerPrefs.GetInt("PlayerLightLvl") * 5;
        if (PlayerPrefs.HasKey("PlayerCurrentLight"))
        {
            currentLight = PlayerPrefs.GetInt("PlayerCurrentLight");
        }
        else currentLight = maxLight;
        //We find the current light text and max light text and initialize them
        currentLightText = transform.GetChild(0).GetComponent<Text>();
        maxLightText = transform.GetChild(2).GetComponent<Text>();
        maxLightText.text = maxLight.ToString();
        currentLightText.text = currentLight.ToString();
    }

    //Function to see if we can use an hability
    public bool CanUseHability(int light)
    {
        return currentLight >= light;
    }

    //Function to reduce the amount of light
    public void ReduceLight(int light)
    {
        currentLight -= light;
        currentLightText.text = currentLight.ToString();
        PlayerPrefs.SetInt("PlayerCurrentLight", currentLight);
    }

    //Function to increase the amount of light
    public void IncreaseLight(int light)
    {
        currentLight += light;
        if (currentLight > maxLight) currentLight = maxLight;
        PlayerPrefs.SetInt("PlayerCurrentLight", currentLight);
        currentLightText.text = currentLight.ToString();
    }

    //Function to get the max light
    public int GetMaxLight()
    {
        maxLight = 5 + PlayerPrefs.GetInt("PlayerLightLvl") * 5;
        maxLightText.text = maxLight.ToString();
        return maxLight;
    }

}
