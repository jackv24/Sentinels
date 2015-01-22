using UnityEngine;
using System.Collections;

public class FireNova : MonoBehaviour 
{
	public float speed = 10f;
	public float range = 10f;
	public float distance = 0f;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		//Moves the bullet forward at Speed per second
		transform.Translate(Vector3.forward * Time.deltaTime * speed);
		
		//Calculates distance based on formula d = vt;
		distance += Time.deltaTime * speed;
		
		//If the bullet has reached it's max distance, destroy itself.
		if (distance >= range)
		{
			Destroy(gameObject);
		}
	}
}
