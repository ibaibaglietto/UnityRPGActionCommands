using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLifeScript : MonoBehaviour
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


      
    //A function to get the current health
    public int GetHealth()
    {
        return currentHealth;
    }

    //Function to set the user
    public void SetUser(int u)
    {
        user = u;
        if (user == 0)
        {
            transform.GetChild(3).GetComponent<RawImage>().texture = playerHealth;
            maxHealth = 10 + (PlayerPrefs.GetInt("PlayerHeartLvl") + PlayerPrefs.GetInt("HPUp")) * 5;
            currentHealth = PlayerPrefs.GetInt("PlayerCurrentHealth");
        }
        else if (user == 1)
        {
            transform.GetChild(3).GetComponent<RawImage>().texture = adventurerHealth;
            maxHealth = 10 + PlayerPrefs.GetInt("AdventurerLvl") * 10 + PlayerPrefs.GetInt("CompHPUp") * 5;
            currentHealth = PlayerPrefs.GetInt("AdventurerCurrentHealth");
        }
        else if (user == 2)
        {
            transform.GetChild(3).GetComponent<RawImage>().texture = wizardHealth;
            maxHealth = 15 + PlayerPrefs.GetInt("WizardLvl") * 10 + PlayerPrefs.GetInt("CompHPUp") * 5;
            currentHealth = PlayerPrefs.GetInt("WizardCurrentHealth");
        }
        //We find the current health text and max health text and initialize them
        currentHealthText = transform.GetChild(0).GetComponent<Text>();
        maxHealthText = transform.GetChild(2).GetComponent<Text>();
        maxHealthText.text = maxHealth.ToString();
        currentHealthText.text = currentHealth.ToString();
    }

    //A function to get the max health
    public int GetMaxHealth()
    {
        if (user == 0) maxHealth = 10 + (PlayerPrefs.GetInt("PlayerHeartLvl") + PlayerPrefs.GetInt("HPUp")) * 5;
        else if (user == 1) maxHealth = 10 + PlayerPrefs.GetInt("AdventurerLvl") * 10 + PlayerPrefs.GetInt("CompHPUp") * 5;
        else if (user == 2) maxHealth = 15 + PlayerPrefs.GetInt("WizardLvl") * 10 + PlayerPrefs.GetInt("CompHPUp") * 5;
        maxHealthText.text = maxHealth.ToString();
        return maxHealth;
    }

    //A function to update the max health
    public void UpdateHealth()
    {
        if (user == 0)
        {
            maxHealthText.text = (10 + (PlayerPrefs.GetInt("PlayerHeartLvl") + PlayerPrefs.GetInt("HPUp")) * 5).ToString();
            currentHealth = PlayerPrefs.GetInt("PlayerCurrentHealth");
        }
        else if (user == 1)
        {
            maxHealthText.text = (10 + PlayerPrefs.GetInt("AdventurerLvl") * 10 + PlayerPrefs.GetInt("CompHPUp") * 5).ToString();
            currentHealth = PlayerPrefs.GetInt("AdventurerCurrentHealth");
        }
        else if (user == 2)
        {
            maxHealthText.text = (15 + PlayerPrefs.GetInt("WizardLvl") * 10 + PlayerPrefs.GetInt("CompHPUp") * 5).ToString();
            currentHealth = PlayerPrefs.GetInt("WizardCurrentHealth");
        }
    }

    //A function to deal damage to the player
    public void DealDamage(int health)
    {
        currentHealth -= health;
        if (user == 0) PlayerPrefs.SetInt("PlayerCurrentHealth", currentHealth);
        else if (user == 1) PlayerPrefs.SetInt("AdventurerCurrentHealth", currentHealth);
        else if (user == 2) PlayerPrefs.SetInt("WizardCurrentHealth", currentHealth);
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
        if (user == 0) PlayerPrefs.SetInt("PlayerCurrentHealth", currentHealth);
        else if (user == 1) PlayerPrefs.SetInt("AdventurerCurrentHealth", currentHealth);
        else if (user == 2) PlayerPrefs.SetInt("WizardCurrentHealth", currentHealth);
        if (currentHealth > maxHealth) currentHealth = maxHealth;
        currentHealthText.text = currentHealth.ToString();
    }
}
