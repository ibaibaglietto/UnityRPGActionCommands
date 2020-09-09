using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLifeScript : MonoBehaviour
{
    public int maxHealth;
    private int currentHealth;
    private Text maxHealthText;
    private Text currentHealthText;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        currentHealthText = transform.GetChild(0).GetComponent<Text>();
        maxHealthText = transform.GetChild(2).GetComponent<Text>();
        maxHealthText.text = maxHealth.ToString();
        currentHealthText.text = currentHealth.ToString();
    }
      

    public int getHealth()
    {
        return currentHealth;
    }

    public void DealDamage(int health)
    {
        currentHealth = currentHealth - health;
        currentHealthText.text = currentHealth.ToString();
    }
}
