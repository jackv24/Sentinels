using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TowerStats : MonoBehaviour
{
    //Health Variables
    public Slider healthBar; //The slider that will display health

    public int maxHealth = 10; 
    public int currentHealth = 10;

    public int currentXP = 0;
    public int levelXP = 1000;

    public int currentLevel = 0;
    public int maxLevel = 0;

    void Update()
    {
        //Set health slider value to health value (0-1)
        healthBar.value = (float)currentHealth / maxHealth;
    }

    #region edit_stats
    //Public functions for adding and removing health and resources
    public void AddHealth(int amount)
    {
        currentHealth += amount;

        if (currentHealth > maxHealth)
            currentHealth = maxHealth;
    }

    public void RemoveHealth(int amount)
    {
        currentHealth -= amount;

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Die();
        }
    }

    public void AddXP(int amount)
    {
        currentXP += amount;

        if (currentXP > levelXP)
        {
            currentXP = currentXP - levelXP;
            currentLevel++;
        }
    }

    public void RemoveXP(int amount)
    {
        currentXP -= amount;

        if (currentXP < 0)
            currentXP = 0;
    }
    #endregion

    void Die()
    {
        Destroy(gameObject);
    }
}
