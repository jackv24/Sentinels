using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats instance;

    public Slider healthBar;
    public Text healthText;
    private string healthTextString;

    public int maxHealth = 100;
    public int currentHealth = 100;

    public Slider resourcesBar;
    public Text resourcesText;
    private string resourcesTextString;

    public int maxResources = 100;
    public int currentResources = 100;

    void Start()
    {
        instance = this;

        healthTextString = healthText.text;
        resourcesTextString = resourcesText.text;
    }

    void Update()
    {
        healthBar.value = (float)currentHealth / maxHealth;
        healthText.text = string.Format(healthTextString, currentHealth, maxHealth);

        resourcesBar.value = (float)currentResources / maxResources;
        resourcesText.text = string.Format(resourcesTextString, currentResources, maxResources);
    }

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

    public void AddResources(int amount)
    {
        currentResources += amount;

        if (currentResources > maxResources)
            currentResources = maxResources;
    }

    public void RemoveResources(int amount)
    {
        currentResources -= amount;

        if (currentResources < 0)
            currentResources = 0;
    }
}
