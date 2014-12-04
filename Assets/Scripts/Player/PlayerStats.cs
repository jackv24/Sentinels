using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    //Creates a static instance so public functions can be accessed with GetComponent()
    public static PlayerStats instance;

    //Health Variables
    public Slider healthBar; //The slider that will display health
    public Text healthText; //The text within the slider that will display health as text
    private string healthTextString; //Stores inital text value, so string.Format() can be used on text added in inspector

    public int maxHealth = 100; 
    public int currentHealth = 100;

    //Resource variables (Exactly the same as health)
    public Slider resourcesBar;
    public Text resourcesText;
    private string resourcesTextString;

    public int maxResources = 100;
    public int currentResources = 100;

    void Start()
    {
        //Makes this class a static instance to be accessed easily
        instance = this;

        //Store initial text values
        healthTextString = healthText.text;
        resourcesTextString = resourcesText.text;
    }

    void Update()
    {
        //Set health slider value to health value (0-1)
        healthBar.value = (float)currentHealth / maxHealth;
        //Replace '{0}' and '{1}' in text with current health and max health
        healthText.text = string.Format(healthTextString, currentHealth, maxHealth);

        //Same as health
        resourcesBar.value = (float)currentResources / maxResources;
        resourcesText.text = string.Format(resourcesTextString, currentResources, maxResources);
    }

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
