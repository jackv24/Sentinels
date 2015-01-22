using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CoreDamage : MonoBehaviour 
{
	//Health Variables
	public Slider healthBar; //The slider that will display health
	
	public int maxHealth = 1000; 
	public int currentHealth = 1000;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{

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
		
		if (currentHealth <= 0)
		{
			currentHealth = 0;
			Die();
		}
	}

	void Die()
	{
		Destroy(gameObject);
	}
}
