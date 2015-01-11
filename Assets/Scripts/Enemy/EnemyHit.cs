using UnityEngine;
using System.Collections;

public class EnemyHit : MonoBehaviour 
{
	public bool HasBulletHitEnemy;
	public bool HasEnemyBeenHit;

	// Use this for initialization
	void Start () 
	{
		HasBulletHitEnemy = false;
		HasEnemyBeenHit = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	public void BulletHitEnemy()
	{
		HasBulletHitEnemy = true;
	}

	public void EnemyHitBullet()
	{
		HasEnemyBeenHit = true;
		KillEnemy ();
	}

	public void KillEnemy()
	{
		if (HasBulletHitEnemy == true && HasEnemyBeenHit == true)
		{
			Destroy(this.gameObject);
			HasBulletHitEnemy = false;
			HasEnemyBeenHit = false;
		}
	}
}
