using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsPlayerXPCoins : MonoBehaviour
{

    //The current data
    private GameObject currentData;

    void Awake()
    {
        currentData = GameObject.Find("CurrentData");
    }

    public void UpdateStats()
    {
        transform.GetChild(1).GetComponent<Text>().text = currentData.GetComponent<CurrentDataScript>().lvlExp.ToString();
        transform.GetChild(3).GetComponent<Text>().text = currentData.GetComponent<CurrentDataScript>().currentCoins.ToString();
    }
}
