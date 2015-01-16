using UnityEngine;
using System.Collections;

public class FlameBullet : MonoBehaviour 
{
	public float speed = 10f;
	public float range = 10f;

	public int damage = 1;

	public GameObject collisionEffect;

	private float distance = 0f;

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
			Destroy(gameObject);
	}

	void OnCollisionEnter(Collision coll)
	{ 
		//When the flame bullet hits an enemy apply the DOT effect and start the DOT timer
		if (coll.gameObject.name == "Enemy(Clone)")
		{
			Destroy (this.gameObject);
			
			GameObject health = GameObject.Find ("Enemy(Clone)");
			EnemyStats HealthScript = health.GetComponent<EnemyStats>();
			HealthScript.ApplyDot();

			StartCoroutine ("CountSecond");
		}
		
		if (coll.gameObject.name == "EnemyLvl2(Clone)")
		{
			Destroy (this.gameObject);
			
			GameObject health = GameObject.Find ("EnemyLvl2(Clone)");
			EnemyStats HealthScript = health.GetComponent<EnemyStats>();
			HealthScript.ApplyDot();

			StartCoroutine ("CountSencond");
		}
	}
}
