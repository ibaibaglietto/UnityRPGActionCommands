using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsPlayerLife : MonoBehaviour
{
    //An int to know who is the player or companion using the bar. 0-> Player, 1-> Adventurer 2-> wizard
    public int user;
    //An int to save the max health of the player
    private int maxHealth;
    //An int to save the current health of the player
    private int currentHealth;
    //The max health text
    private Text maxHealthText;
    //The current health text
    private Text currentHealthText;
    //The image of the player health
    [SerializeField] private Texture playerHealth;
    //The image of the adventurer health
    [SerializeField] private Texture adventurerHealth;
    //The image of the wizard health
    [SerializeField] private Texture wizardHealth;
    //The current data
    private GameObject currentData;

    void Awake()
    {
        currentData = GameObject.Find("CurrentData");
        UpdateStats();
    }

    public void UpdateStats()
    {
        if (user == 0)
        {
            transform.GetChild(3).GetComponent<RawImage>().texture = playerHealth;
            maxHealth = 10 + (currentData.GetComponent<CurrentDataScript>().playerHeartLvl + currentData.GetComponent<CurrentDataScript>().HPUp) * 5;
            currentHealth = currentData.GetComponent<CurrentDataScript>().playerCurrentHealth;
        }
        else if (user == 1)
        {
            if (currentData.GetComponent<CurrentDataScript>().unlockedCompanions > 0)
            {
                transform.GetChild(3).GetComponent<RawImage>().texture = adventurerHealth;
                maxHealth = 10 + (currentData.GetComponent<CurrentDataScript>().adventurerLvl - 1) * 10 + currentData.GetComponent<CurrentDataScript>().compHPUp * 5;
                currentHealth = currentData.GetComponent<CurrentDataScript>().adventurerCurrentHealth;
                GetComponent<RawImage>().color = new Color(GetComponent<RawImage>().color.r, GetComponent<RawImage>().color.g, GetComponent<RawImage>().color.b, 1.0f);
                transform.GetChild(0).GetComponent<Text>().color = new Color(transform.GetChild(0).GetComponent<Text>().color.r, transform.GetChild(0).GetComponent<Text>().color.g, transform.GetChild(0).GetComponent<Text>().color.b, 1.0f);
                transform.GetChild(1).GetComponent<Text>().color = new Color(transform.GetChild(1).GetComponent<Text>().color.r, transform.GetChild(1).GetComponent<Text>().color.g, transform.GetChild(1).GetComponent<Text>().color.b, 1.0f);
                transform.GetChild(2).GetComponent<Text>().color = new Color(transform.GetChild(2).GetComponent<Text>().color.r, transform.GetChild(2).GetComponent<Text>().color.g, transform.GetChild(2).GetComponent<Text>().color.b, 1.0f);
                transform.GetChild(3).GetComponent<RawImage>().color = new Color(transform.GetChild(3).GetComponent<RawImage>().color.r, transform.GetChild(3).GetComponent<RawImage>().color.g, transform.GetChild(3).GetComponent<RawImage>().color.b, 1.0f);
            }
            else
            {
                GetComponent<RawImage>().color = new Color(GetComponent<RawImage>().color.r, GetComponent<RawImage>().color.g, GetComponent<RawImage>().color.b, 0.0f);
                transform.GetChild(0).GetComponent<Text>().color = new Color(transform.GetChild(0).GetComponent<Text>().color.r, transform.GetChild(0).GetComponent<Text>().color.g, transform.GetChild(0).GetComponent<Text>().color.b, 0.0f);
                transform.GetChild(1).GetComponent<Text>().color = new Color(transform.GetChild(1).GetComponent<Text>().color.r, transform.GetChild(1).GetComponent<Text>().color.g, transform.GetChild(1).GetComponent<Text>().color.b, 0.0f);
                transform.GetChild(2).GetComponent<Text>().color = new Color(transform.GetChild(2).GetComponent<Text>().color.r, transform.GetChild(2).GetComponent<Text>().color.g, transform.GetChild(2).GetComponent<Text>().color.b, 0.0f);
                transform.GetChild(3).GetComponent<RawImage>().color = new Color(transform.GetChild(3).GetComponent<RawImage>().color.r, transform.GetChild(3).GetComponent<RawImage>().color.g, transform.GetChild(3).GetComponent<RawImage>().color.b, 0.0f);
            }
        }
        else if (user == 2)
        {
            if(currentData.GetComponent<CurrentDataScript>().unlockedCompanions > 1)
            {
                transform.GetChild(3).GetComponent<RawImage>().texture = wizardHealth;
                maxHealth = 15 + (currentData.GetComponent<CurrentDataScript>().wizardLvl - 1) * 10 + currentData.GetComponent<CurrentDataScript>().compHPUp * 5;
                currentHealth = currentData.GetComponent<CurrentDataScript>().wizardCurrentHealth;
                GetComponent<RawImage>().color = new Color(GetComponent<RawImage>().color.r, GetComponent<RawImage>().color.g, GetComponent<RawImage>().color.b, 1.0f);
                transform.GetChild(0).GetComponent<Text>().color = new Color(transform.GetChild(0).GetComponent<Text>().color.r, transform.GetChild(0).GetComponent<Text>().color.g, transform.GetChild(0).GetComponent<Text>().color.b, 1.0f);
                transform.GetChild(1).GetComponent<Text>().color = new Color(transform.GetChild(1).GetComponent<Text>().color.r, transform.GetChild(1).GetComponent<Text>().color.g, transform.GetChild(1).GetComponent<Text>().color.b, 1.0f);
                transform.GetChild(2).GetComponent<Text>().color = new Color(transform.GetChild(2).GetComponent<Text>().color.r, transform.GetChild(2).GetComponent<Text>().color.g, transform.GetChild(2).GetComponent<Text>().color.b, 1.0f);
                transform.GetChild(3).GetComponent<RawImage>().color = new Color(transform.GetChild(3).GetComponent<RawImage>().color.r, transform.GetChild(3).GetComponent<RawImage>().color.g, transform.GetChild(3).GetComponent<RawImage>().color.b, 1.0f);
            }
            else
            {
                GetComponent<RawImage>().color = new Color(GetComponent<RawImage>().color.r, GetComponent<RawImage>().color.g, GetComponent<RawImage>().color.b, 0.0f);
                transform.GetChild(0).GetComponent<Text>().color = new Color(transform.GetChild(0).GetComponent<Text>().color.r, transform.GetChild(0).GetComponent<Text>().color.g, transform.GetChild(0).GetComponent<Text>().color.b, 0.0f);
                transform.GetChild(1).GetComponent<Text>().color = new Color(transform.GetChild(1).GetComponent<Text>().color.r, transform.GetChild(1).GetComponent<Text>().color.g, transform.GetChild(1).GetComponent<Text>().color.b, 0.0f);
                transform.GetChild(2).GetComponent<Text>().color = new Color(transform.GetChild(2).GetComponent<Text>().color.r, transform.GetChild(2).GetComponent<Text>().color.g, transform.GetChild(2).GetComponent<Text>().color.b, 0.0f);
                transform.GetChild(3).GetComponent<RawImage>().color = new Color(transform.GetChild(3).GetComponent<RawImage>().color.r, transform.GetChild(3).GetComponent<RawImage>().color.g, transform.GetChild(3).GetComponent<RawImage>().color.b, 0.0f);
            }
        }
        //We find the current health text and max health text and initialize them
        currentHealthText = transform.GetChild(0).GetComponent<Text>();
        maxHealthText = transform.GetChild(2).GetComponent<Text>();
        maxHealthText.text = maxHealth.ToString();
        currentHealthText.text = currentHealth.ToString();
    }
}
