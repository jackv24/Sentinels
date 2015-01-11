﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemyStats : MonoBehaviour
{
    //Health Variables
    public Slider healthBar; //The slider that will display health

    public int maxHealth = 10; 
    public int currentHealth = 10;
	public Collision coll;

    void Update()
    {
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
			currentHealth = 10;
		}
    }

	void OnCollisionEnter (Collision coll)
	{
		if (coll.gameObject.tag == "Bullet")
		{
			if (currentHealth <= 1)
			{
				GameObject kill = GameObject.Find ("Enemy(Clone)");
				EnemyHit KillCommand = kill.GetComponent<EnemyHit>();
				KillCommand.EnemyHitBullet ();
			}
		}
	}
}
