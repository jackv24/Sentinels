using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemyStats : MonoBehaviour
{
    //Health Variables
    public Slider healthBar; //The slider that will display health

    public int maxHealth = 10; 
    public float currentHealth = 10f;

	public bool isTicking;
	public int ticks = 0;
	public int DotDuration;

	public float tickDamage = 0.5f;

    void Update()
    {
        if (healthBar)
        {
            //Set health slider value to health value (0-1)
            healthBar.value = (float)currentHealth / maxHealth;
        }

		if (isTicking == true)
		{
			ApplyDot();
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
		Debug.Log (currentHealth);
        if (currentHealth <= 0)
		{
			currentHealth = 10;
			Destroy(this.gameObject);
		}
    }

    //Function that handles the damage over time effect for the flame turret
	public void ApplyDot()
	{
		ticks++;
		if (ticks % 60 == 0)
		{
			DecrementHealth(tickDamage);
		}
	}

	void DecrementHealth(float Tdmg)
	{
		currentHealth -= Tdmg;
		Debug.Log (currentHealth);
		if (currentHealth <= 0)
		{
			currentHealth = 10;
			Destroy (this.gameObject);
		}
	}

	//A count down timer for the duration of the DOT effect
	IEnumerator CountSeconds()
	{
		DotDuration = 0;
		while (true)
		{
			for (float timer = 0; timer < 1; timer += Time.deltaTime)
			{
				yield return 0;
				DotDuration++;
				Debug.Log (DotDuration + " seconds have passed since the Coroutine started");

				if (DotDuration == 10)
				{
					//Cancel the DOT when the timer runs out
					StopCoroutine ("CountSeconds");
					isTicking = false;
				}
			}
		}
	}
}
