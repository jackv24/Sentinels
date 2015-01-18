using UnityEngine;
using System.Collections;

public class EnemyAOE : MonoBehaviour 
{
	public float CoolDown = 100f;
	public GameObject enemy;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		CoolDown -= 1;

		if (CoolDown <= 0)
		{
			float RandNum = Random.Range(0, 4);
			float ChosenNum = RandNum;

			if (ChosenNum <= 2)
			{
				AOE (enemy.transform.position, 20f, 2f);
			}

			CoolDown = 100f;
		}
	}

	void AOE (Vector3 location, float radius, float damage)
	{

		Collider[] objectsInRange = Physics.OverlapSphere (location, radius);
		foreach (Collider col in objectsInRange)
		{
			TowerStats KillTower = col.GetComponent<TowerStats>();
			PlayerStats KillPlayer = col.GetComponent<PlayerStats>();

			if (KillTower != null)
			{
				//Linear fall off effect
				float proximity = (location - enemy.transform.position).magnitude;
				float effect = 1 - (proximity/radius);
				KillTower.RemoveHealth ((int)damage * (int)effect);
				Debug.Log ("Attack");
			}

			if (KillPlayer != null)
			{
				//Linear fall off effect
				float proximity = (location - enemy.transform.position).magnitude;
				float effect = 1 - (proximity/radius);
				KillPlayer.RemoveHealth ((int)damage * (int)effect);
				//Debug.Log ("Attack");
			}
		}
	}
}
