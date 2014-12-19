using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class PlayerAbilities : MonoBehaviour
{
	public enum Abilities
	{
		NormalShoot,
		MultiShot,
		Blink,
		FreezingFire,
		RapidFire,
		SelfRepair,
	}

    public GameObject gunMuzzle;
    public GameObject bulletPrefab;

    private GameObject projectiles;

    void Start()
    {
        //If the gameobject doesn't exist, create it
        if (!GameObject.Find("Projectiles"))
            projectiles = new GameObject("Projectiles");
        //If the gameobject does exist, set it's reference
        else
            projectiles = GameObject.Find("Projectiles");
    }

    void Update()
    {
        GetButtonInput();
    }

    void GetButtonInput()
    {
        if (Input.GetButtonDown("Primary") && !EventSystem.current.IsPointerOverGameObject())
            Use(Abilities.NormalShoot);

        if (Input.GetButtonDown("Secondary") && !EventSystem.current.IsPointerOverGameObject())
            Use(Abilities.MultiShot);

        if (Input.GetButtonDown("Ability1"))
            Use(Abilities.Blink);

        if (Input.GetButtonDown("Ability2"))
            Use(Abilities.FreezingFire);

        if (Input.GetButtonDown("Ability3"))
            Use(Abilities.RapidFire);

        if (Input.GetButtonDown("Ability4"))
            Use(Abilities.SelfRepair);
    }

    public void GetUIInput(string button)
    {
        if (button == "Primary")
            Use(Abilities.NormalShoot);

        if (button == "Secondary")
            Use(Abilities.MultiShot);

        if (button == "Ability1")
            Use(Abilities.Blink);

        if (button == "Ability2")
            Use(Abilities.FreezingFire);

        if (button == "Ability3")
            Use(Abilities.RapidFire);

        if (button == "Ability4")
            Use(Abilities.SelfRepair);
    }

    void Use(Abilities ability)
    {
        if (Preferences.instance.canPlayerShoot)
        {
            switch (ability)
            {
                case Abilities.NormalShoot:
                    FireBullet(bulletPrefab);
                    break;

                case Abilities.MultiShot:
                    FireBullet(bulletPrefab, 5, 30f);
                    break;

                case Abilities.Blink:
                    Debug.Log("Blink");
                    break;

                case Abilities.FreezingFire:
                    Debug.Log("FreezingFire");
                    break;

                case Abilities.RapidFire:
                    Debug.Log("RapidFire");
                    break;

                case Abilities.SelfRepair:
                    Debug.Log("SelfRepair");
                    break;

            }
        }
    }

    GameObject FireBullet(GameObject bullet)
    {
        if (bullet && gunMuzzle)
        {
            GameObject obj = (GameObject)Instantiate(bullet, gunMuzzle.transform.position, gunMuzzle.transform.rotation);
            Physics.IgnoreCollision(gameObject.collider, obj.collider);

            obj.transform.parent = projectiles.transform;

            return obj;
        }
        else
        {
            Debug.Log("Missing bullet prefab and/or muzzle transform!");
            return null;
        }
    }

    void FireBullet(GameObject bullet, int amount, float spreadAngle)
    {
        // Todo - need a special case for when amount is 1
        float perBulletAngle = spreadAngle / (amount - 1);
        float startAngle = spreadAngle * -0.5f;

        for (int i = 0; i < amount; i++)
        {
            GameObject obj = FireBullet(bullet);
            obj.transform.Rotate(Vector3.up, startAngle + i * perBulletAngle);
        }
    }
}
