using UnityEngine;
using System.Collections;

public class EnemyAOE : MonoBehaviour 
{
	public float CoolDown = 200f;
	public GameObject enemy;

	//number of points on the radius to place prefabs
	public int numPoints = 10;
	
	//center of circle/elipsoid
	public Vector3 centerPos;
	public GameObject Prefab;
	//public GameObject Enemy;
	
	//radii for each x,y axes, respectively
	public float radiusX, radiusY;
	
	//public float radius = 5f;
	public Vector3 pos;
	
	//is the drawb shape on the xy-plane?
	public bool vertical = false;
	
	//position to place each prefab along the given circle/eliptoid
	//*is set during each iteration of the loop
	Vector3 pointPos;

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
				AOE (enemy.transform.position, 15f, 10f);
			}

			CoolDown = 200f;
		}
	}

	void AOE (Vector3 location, float radius, float damage)
	{
		centerPos = enemy.transform.position;
		for (int i = 0; i < numPoints; i++)
		{
			//multiply 'i' by '1.0f' to ensure the result is a fraction
			float pointNum = (i * 1.0f) / numPoints;
			
			//angle along the unit circle for placing points
			float angle = pointNum * Mathf.PI * 2;
			
			float x = Mathf.Sin (angle) * radiusX;
			float y = Mathf.Cos (angle) * radiusY;
			
			//position for the point prefab
			if (vertical)
			{
				pointPos = new Vector3(x, y) + centerPos;
			}
			else if (!vertical)
			{
				pointPos = new Vector3(x, 0, y) + centerPos;
			}

			//place the prefab at given position
			Instantiate (Prefab, pointPos, Quaternion.identity);
		}

		Collider[] objectsInRange = Physics.OverlapSphere (location, radius);
		foreach (Collider col in objectsInRange)
		{
			TowerStats KillTower = col.GetComponent<TowerStats>();
			PlayerStats KillPlayer = col.GetComponent<PlayerStats>();
			CoreDamage KillCore = col.GetComponent<CoreDamage>();

			if (KillTower != null)
			{
				//Linear fall off effect
				float proximity = (location - enemy.transform.position).magnitude;
				float effect = 1 - (proximity/radius);
				KillTower.RemoveHealth ((int)damage * (int)effect);
			}

			if (KillPlayer != null)
			{
				//Linear fall off effect
				float proximity = (location - enemy.transform.position).magnitude;
				float effect = 1 - (proximity/radius);
				KillPlayer.RemoveHealth ((int)damage * (int)effect);
			}

			if (KillCore != null)
			{
				//Linear fall off effect
				float proximity = (location - enemy.transform.position).magnitude;
				float effect = 1 - (proximity/radius);
				KillCore.RemoveHealth ((int)damage * (int)effect);
			}
		}
	}	
}