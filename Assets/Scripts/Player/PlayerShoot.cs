using UnityEngine;
using System.Collections;

public class PlayerShoot : MonoBehaviour {
	public float BulletSpeed = 1;
	public GameObject PlayerGunBullet;
	public GameObject Bullet;
		public Transform myTransform;
	
	void Start () {
		myTransform = transform;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0))
		{
			Instantiate (Bullet,PlayerGunBullet.transform.position,PlayerGunBullet.transform.rotation);
			            
		}
	
	}
		 
}