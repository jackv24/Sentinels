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

    //Resource variables
    public Text resourcesText;
    private string resourcesTextString;

    public int currentResources = 100;

    //Experience variables
    public Slider xpBar;
    public Text xpText;
    private string xpTextString;

    public Text levelText;
    private string levelTextString;

    public int currentXP = 0;
    public int levelXP = 1000;
    public int currentLevel = 0;

    public float barAnimSmoothness = 0.25f;

    void Start()
    {
        //Makes this class a static instance to be accessed easily
        instance = this;

        //Store initial text values
        if(healthText)
            healthTextString = healthText.text;
        if(resourcesText)
            resourcesTextString = resourcesText.text;
        if (xpText)
            xpTextString = xpText.text;
        if(levelText)
            levelTextString = levelText.text;
    }

    void Update()
    {
        if(healthBar)
            //Set health slider value to health value (0-1)
            healthBar.value = Mathf.Lerp(healthBar.value, (float)currentHealth / maxHealth, barAnimSmoothness);
        if(healthText)
            //Replace '{0}' and '{1}' in text with current health and max health
            healthText.text = string.Format(healthTextString, currentHealth, maxHealth);

        if(resourcesText)
            //Set resources text with current value
            resourcesText.text = string.Format(resourcesTextString, currentResources);

        if(xpBar)
            //Set xp slider value to xp value (0-1)
            xpBar.value = Mathf.Lerp(xpBar.value, (float)currentXP / levelXP, barAnimSmoothness);
        if(xpText)
            //Replace '{0}' and '{1}' in text with current health and max health
            xpText.text = string.Format(xpTextString, currentXP, levelXP);

        if(levelText)
            //Replace {0} with current level
            levelText.text = string.Format(levelTextString, currentLevel);

        //For testing purposes
        if (Input.GetKeyDown(KeyCode.U))
            AddXP(110);
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
}
