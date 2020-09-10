using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyLifeControllerScript : MonoBehaviour
{
    public int maxHealth;
    private int currentHealth;
    private Image lifeFill;
    private Text lifeNumb;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        lifeFill = transform.GetChild(2).GetComponent<Image>();
        lifeNumb = transform.GetChild(3).GetComponent<Text>();
    }

    
    public int getHealth()
    {
        return currentHealth;
    }

    public void DealDamage(int health)
    {
        currentHealth = currentHealth - health;
        lifeFill.fillAmount = (float)currentHealth / (float)maxHealth;
        lifeNumb.text = currentHealth.ToString();
    }

    

}
