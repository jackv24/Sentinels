using UnityEngine;
using System.Collections;

public class PlayerShoot : MonoBehaviour
{
	public float BulletSpeed = 1;
	public GameObject PlayerGunBullet;
	public GameObject Bullet;

    private GameObject player;

	void Start ()
    {
        player = GameObject.FindWithTag("Player");
	}
	
	void Update ()
    {
		if(Input.GetMouseButtonDown(0) && Preferences.instance.canPlayerShoot)
		{
			GameObject obj = (GameObject)Instantiate (Bullet, PlayerGunBullet.transform.position, PlayerGunBullet.transform.rotation);

            Physics.IgnoreCollision(player.collider, obj.collider);
		}
	}
}