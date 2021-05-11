using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsPlayerXPCoins : MonoBehaviour
{

    
    public void UpdateStats()
    {
        transform.GetChild(1).GetComponent<Text>().text = PlayerPrefs.GetInt("lvlXP").ToString();
        transform.GetChild(3).GetComponent<Text>().text = PlayerPrefs.GetInt("currentCoins").ToString();
    }
}
