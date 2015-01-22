using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemyStats : MonoBehaviour
{
    //Health Variables
    public Slider healthBar; //The slider that will display health

    public float maxHealth = 50f; 
    public float currentHealth = 50f;
	public float incHealth = 0f;

    void Update()
    {
		incHealth += Time.deltaTime;

		if (currentHealth == 50)
		{
			maxHealth = incHealth = 50f;
		}

        if (healthBar)
        {
            //Set health slider value to health value (0-1)
            healthBar.value = (float)currentHealth / maxHealth;
        }
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

        if (currentHealth <= 0)
		{
			currentHealth = 50;
			Destroy (this.gameObject);
			GiveStats ();
		}
    }

	public void GiveStats()
	{
		GameObject Player = GameObject.Find ("Player");

		PlayerStats playerResources = Player.GetComponent<PlayerStats> ();
		playerResources.AddResources (10);

		PlayerStats PlayerXp = Player.GetComponent<PlayerStats>();
		PlayerXp.AddXP (110);

	}
}
