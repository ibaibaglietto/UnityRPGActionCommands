using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLifeScript : MonoBehaviour
{
    //An int to know who is the player or companion using the bar. 0-> Player, 1-> Adventurer
    public int user;
    //An int to save the max health of the player
    private int maxHealth;
    //An int to save the current health of the player
    private int currentHealth;
    //The max health text
    private Text maxHealthText;
    //The current health text
    private Text currentHealthText;


    void Start()
    {
        if(user == 0) maxHealth = 10 + PlayerPrefs.GetInt("PlayerHeartLvl") * 5;
        else if (user == 1) maxHealth = 10 + PlayerPrefs.GetInt("AdventurerLvl") * 10;
        //We save the current health
        currentHealth = maxHealth - 9;
        //We find the current health text and max health text and initialize them
        currentHealthText = transform.GetChild(0).GetComponent<Text>();
        maxHealthText = transform.GetChild(2).GetComponent<Text>();
        maxHealthText.text = maxHealth.ToString();
        currentHealthText.text = currentHealth.ToString();
    }
      
    //A function to get the current health
    public int GetHealth()
    {
        return currentHealth;
    }

    //A function to deal damage to the player
    public void DealDamage(int health)
    {
        currentHealth -= health;
        if (currentHealth < 0) currentHealth = 0;
        currentHealthText.text = currentHealth.ToString();
    }
    //A function to know if the player is dead
    public bool IsDead()
    {
        return currentHealth == 0;
    }
    //A function to heal the player
    public void Heal(int health)
    {
        currentHealth += health;
        if (currentHealth > maxHealth) currentHealth = maxHealth;
        currentHealthText.text = currentHealth.ToString();
    }
}
