using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    //Health variables
    public int maxHealth = 100; 
    public int currentHealth = 100;

    //Health variables
    public int maxEnergy = 100;
    public int currentEnergy = 100;

    public int currentResources = 100;

    //Xp variables
    public int currentXP = 0;
    public int levelXP = 1000;
    public int currentLevel = 0;

    void Update()
    {
        //For testing purposes
        if (Input.GetKeyDown(KeyCode.U))
            AddXP(110);
    }

    #region edit_stats
    //Public functions for adding and removing health
    public void AddHealth(int amount)
    {
        currentHealth += amount;

        if (currentHealth > maxHealth)
            currentHealth = maxHealth;
    }

    public void RemoveHealth(int amount)
    {
        currentHealth -= amount;

        if (currentHealth < 0)
            currentHealth = 0;
    }

    //...energy
    public void AddEnergy(int amount)
    {
        currentEnergy += amount;

        if (currentEnergy > maxEnergy)
            currentEnergy = maxEnergy;
    }

    public void RemoveEnergy(int amount)
    {
        currentEnergy -= amount;

        if (currentEnergy < 0)
            currentEnergy = 0;
    }

    //...and resources
    public void AddResources(int amount)
    {
        currentResources += amount;
    }

    public void RemoveResources(int amount)
    {
        currentResources -= amount;

        if (currentResources < 0)
            currentResources = 0;
    }

    //Add and remove XP
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
}
