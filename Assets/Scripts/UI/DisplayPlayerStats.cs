using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DisplayPlayerStats : MonoBehaviour
{
    //Health Variables
    public Slider healthBar; //The slider that will display health
    public Text healthText; //The text within the slider that will display health as text
    private string healthTextString; //Stores inital text value, so string.Format() can be used on text added in inspector

    //Resource variables
    public Text resourcesText;
    private string resourcesTextString;

    //Experience variables
    public Slider xpBar;
    public Text xpText;
    private string xpTextString;

    public Text levelText;
    private string levelTextString;

    public float barAnimSmoothness = 0.25f;

    private PlayerStats playerStats;

    void Start()
    {
        //Store initial text values
        if (healthText)
            healthTextString = healthText.text;
        if (resourcesText)
            resourcesTextString = resourcesText.text;
        if (xpText)
            xpTextString = xpText.text;
        if (levelText)
            levelTextString = levelText.text;

        playerStats = GameObject.Find("Player").GetComponent<PlayerStats>();
    }

    void Update()
    {
        if (healthBar)
            //Set health slider value to health value (0-1)
            healthBar.value = Mathf.Lerp(healthBar.value, (float)playerStats.currentHealth / playerStats.maxHealth, barAnimSmoothness);
        if (healthText)
            //Replace '{0}' and '{1}' in text with playerStats.current health and max health
            healthText.text = string.Format(healthTextString, playerStats.currentHealth, playerStats.maxHealth);

        if (resourcesText)
            //Set resources text with playerStats.current value
            resourcesText.text = string.Format(resourcesTextString, playerStats.currentResources);

        if (xpBar)
            //Set xp slider value to xp value (0-1)
            xpBar.value = Mathf.Lerp(xpBar.value, (float)playerStats.currentXP / playerStats.levelXP, barAnimSmoothness);
        if (xpText)
            //Replace '{0}' and '{1}' in text with playerStats.current health and max health
            xpText.text = string.Format(xpTextString, playerStats.currentXP, playerStats.levelXP);

        if (levelText)
            //Replace {0} with playerStats.current level
            levelText.text = string.Format(levelTextString, playerStats.currentLevel);
    }
}
