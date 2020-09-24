using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLifeScript : MonoBehaviour
{
    //An int to save the max health of the player
    public int maxHealth;
    //An int to save the current health of the player
    private int currentHealth;
    //The max health text
    private Text maxHealthText;
    //The current health text
    private Text currentHealthText;


    void Start()
    {
        //We save the current health
        currentHealth = maxHealth;
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
        currentHealthText.text = currentHealth.ToString();
    }
    //A function to heal the player
    public void Heal(int health)
    {
        currentHealth += health;
        if (currentHealth > maxHealth) currentHealth = maxHealth;
        currentHealthText.text = currentHealth.ToString();
    }
}
