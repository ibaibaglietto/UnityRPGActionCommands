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
    //The current data
    private GameObject currentData;


    void Awake()
    {
        currentData = GameObject.Find("CurrentData");
        //We save the max light and the current light
        maxLight = 5 + (currentData.GetComponent<CurrentDataScript>().playerLightLvl + currentData.GetComponent<CurrentDataScript>().LPUp) * 5;
        currentLight = currentData.GetComponent<CurrentDataScript>().playerCurrentLight;
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
        currentData.GetComponent<CurrentDataScript>().playerCurrentLight = currentLight;
    }

    //Function to increase the amount of light
    public void IncreaseLight(int light)
    {
        currentLight += light;
        if (currentLight > maxLight) currentLight = maxLight;
        currentData.GetComponent<CurrentDataScript>().playerCurrentLight = currentLight;
        currentLightText.text = currentLight.ToString();
    }

    //Function to get the max light
    public int GetMaxLight()
    {
        maxLight = 5 + (currentData.GetComponent<CurrentDataScript>().playerLightLvl + currentData.GetComponent<CurrentDataScript>().LPUp) * 5;
        maxLightText.text = maxLight.ToString();
        return maxLight;
    }

    //Function to update the max light 
    public void UpdateLight()
    {
        maxLightText.text = (5 + (currentData.GetComponent<CurrentDataScript>().playerLightLvl + currentData.GetComponent<CurrentDataScript>().LPUp) * 5).ToString();
        currentLightText.text = currentData.GetComponent<CurrentDataScript>().playerCurrentLight.ToString();
    }

}
