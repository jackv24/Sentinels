using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class PlayerAbilities : MonoBehaviour
{
    //enum to store all player abilities
	public enum Abilities
	{
		NormalShoot,
		MultiShot,
		Blink,
		FreezingFire,
		RapidFire,
		SelfRepair,
	}
    
    //The transform from where the bullets are instantiated
    public Transform gunMuzzle;

    //The basic bullet to be instantiated
    public GameObject bulletPrefab;

    //The gameobject to which all projectgiles will be parented (to clean up the heirarchy during runtime)
    private GameObject projectiles;

    private PlayerStats playerStats;

    void Start()
    {
        //If the gameobject doesn't exist, create it
        if (!GameObject.Find("Projectiles"))
            projectiles = new GameObject("Projectiles");
        //If the gameobject does exist, set it's reference
        else
            projectiles = GameObject.Find("Projectiles");

        playerStats = GetComponent<PlayerStats>();
    }

    void Update()
    {
        GetButtonInput();
    }

    //Gets input from buttons
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

    //Gets input from external call (from UI button)
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

    //Use an ability
    void Use(Abilities ability)
    {
        //If the player can shoot
        if (Preferences.instance.canPlayerShoot)
        {
            //Call the corresponding ability's method
            switch (ability)
            {
                case Abilities.NormalShoot:
                    FireBullet(bulletPrefab); //Fire one bullet
                    break;

                case Abilities.MultiShot:
                    int cost = 10; //How much energy does this ability cost to use?

                    if (playerStats.currentEnergy >= cost) //If there is enough energy...
                    {
                        FireBullet(bulletPrefab, 5, 30f); //Fire multiple bullets
                        playerStats.RemoveEnergy(cost);
                    }
                    break;

                case Abilities.Blink:
                    Debug.Log("Blink"); //Call the blink method from here (once you have created it below, that is)
                    break;

                case Abilities.FreezingFire:
                    Debug.Log("FreezingFire"); //Call the freezing fire method
                    break;

                case Abilities.RapidFire:
                    Debug.Log("RapidFire"); //Call the rapid fire method
                    break;

                case Abilities.SelfRepair:
                    Debug.Log("SelfRepair"); //Call the self repair method
                    break;

            }
        }
    }

    #region ability_methods 

    //Instantiates a bullet prefab, and returns it
    GameObject FireBullet(GameObject bullet)
    {
        //If there is a bullet, and a place to fire from
        if (bullet && gunMuzzle)
        {
            //Instantiate the bullet
            GameObject obj = (GameObject)Instantiate(bullet, gunMuzzle.position, gunMuzzle.rotation);

            //Ignore collisions between the player and the bullet
            Physics.IgnoreCollision(gameObject.collider, obj.collider);

            //Set bullet parent to projectiles (for heirarchy cleanup)
            obj.transform.parent = projectiles.transform;

            //Return the bullet
            return obj;
        }
        else
        {
            Debug.Log("Missing bullet prefab and/or muzzle transform!");
            return null;
        }
    }

    //Overloaded method to fire multiple bullets in a spread
    void FireBullet(GameObject bullet, int amount, float spreadAngle)
    {
        //Calculates the angle between each bullet, based on the spreadAngle
        float perBulletAngle = spreadAngle / (amount - 1);
        float startAngle = spreadAngle * -0.5f;

        //For the amount specified...
        for (int i = 0; i < amount; i++)
        {
            //Fire a bullet
            GameObject obj = FireBullet(bullet);
            //Rotate the fired bullet to spread out
            obj.transform.Rotate(Vector3.up, startAngle + i * perBulletAngle);
        }
    }

    #endregion
}
