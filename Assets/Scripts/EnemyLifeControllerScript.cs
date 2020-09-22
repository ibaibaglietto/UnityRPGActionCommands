using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyLifeControllerScript : MonoBehaviour
{
    //The max health of the enemy
    public int maxHealth;
    //The current health of the enemy
    private int currentHealth;
    //The image of the life fill
    private Image lifeFill;
    //The text to represent the life the enemy has
    private Text lifeNumb;
    // Start is called before the first frame update
    void Start()
    {
        //We initialize the variables and find the lifeFill and lifeNumb
        currentHealth = maxHealth;
        lifeFill = transform.GetChild(2).GetComponent<Image>();
        lifeNumb = transform.GetChild(3).GetComponent<Text>();
    }

    //A function to get the current health of the enemy
    public int GetHealth()
    {
        return currentHealth;
    }

    //A function to deal damage to the enemy
    public void DealDamage(int health)
    {
        if (currentHealth > 0)
        {
            currentHealth -= health;
            lifeFill.fillAmount = (float)currentHealth / (float)maxHealth;
            lifeNumb.text = currentHealth.ToString();
        }
    }

    

}
