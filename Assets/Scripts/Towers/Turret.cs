using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Turret : MonoBehaviour
{
    //Behaviour variables
    public float reloadTime = 0.5f;
    public float turnSpeed = 10f;
    public float firePauseTime = 0.25f;
    public float errorAmount = 1f;

    //To be assigned in inspector
	public string targetTag = "Player";

    public GameObject bulletPrefab;
    public GameObject muzzleEffect; //Optional

    public Transform turretBall;
    public Transform[] muzzleTransforms;

    //Private variables
    private float nextFireTime;
    private float nextMoveTime;
    private Quaternion desiredRotation;
    private float aimError;

    //A found target will be assigned to this variable
    private Transform target;

    //If the turret has an audio source attached (automatically determined in Start())
    private bool hasAudioSource = false;

    //Searching behaviour variables
    private float idleTime = 0;
    private int direction;

    //Stores a list of spawned projectiles
    private List<GameObject> spawnedProjectiles = new List<GameObject>();

    void Start()
    {
        //If the turret has an audio source, use it (for projectile firing sounds).
        if (GetComponent<AudioSource>())
            hasAudioSource = true;
    }

    void Update()
    {
        //If there is a target:
        if (target)
        {
            //If time elapsed is more than or equal to nextMoveTime
            if (Time.time >= nextMoveTime)
            {
                //Calculate the position to aim, and rotate the turret to that position.
                CalculateAimPosition(target.position + Vector3.up);
                turretBall.rotation = Quaternion.Lerp(turretBall.rotation, desiredRotation, Time.deltaTime * turnSpeed);
            }

            //If time elapsed is more than or equal to nextFireTime, fire a projectile.
            if (Time.time >= nextFireTime)
                FireProjectile();
        }
        else //If there is no target, act as if in "search" mode
        {
            //Keep track of time spent idle
            idleTime += Time.deltaTime;

            //If idle for more than 2 seconds...
            if (idleTime >= 2f)
            {
                //Generate a random direction
                direction = Random.Range(-1, 2);

                //Reset idle time
                idleTime = 0;
            }

            //Rotate turret
            turretBall.Rotate(Vector3.up, turnSpeed * 3 * Time.deltaTime * direction);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        //If an enemy has entered the trigger, reset time and set as target.
        if (other.tag == targetTag)
        {
            nextFireTime = Time.time + (reloadTime * 0.5f);
            target = other.transform;
        }
    }

    void OnTriggerExit(Collider other)
    {
        //If the current target has left the attack trigger range, reset target.
        if (other.transform == target)
            target = null;
    }

    //For resetting after a respawn
    void OnEnable()
    {
        //Clear target
        target = null;

        //Remove previously shot projectiles
        foreach(GameObject obj in spawnedProjectiles)
            Destroy(obj);
    }

    void CalculateAimPosition(Vector3 targetPos)
    {
        //Calculate an aim point from target position, within a margin of error.
        Vector3 aimPoint = new Vector3(targetPos.x + aimError, targetPos.y - 1, targetPos.z + aimError);
        desiredRotation = Quaternion.LookRotation(aimPoint - transform.position);
    }

    void CalculateAimError()
    {
        //Calculate the aim error
        aimError = Random.Range(-errorAmount, errorAmount);
    }

    void FireProjectile()
    {
        //If there is an audio source, play the audio.
        if (hasAudioSource)
        {
            audio.pitch = 1 + Random.Range(-0.1f, 0.1f);
            audio.Play();
        }

        //Set next timings.
        nextFireTime = Time.time + reloadTime;
        nextMoveTime = Time.time + firePauseTime;

        CalculateAimError();

        //Fire a projectile from every muzzle transform
        foreach(Transform muzzlePos in muzzleTransforms)
        {
            GameObject obj = Instantiate(bulletPrefab, muzzlePos.position, muzzlePos.rotation) as GameObject;
			obj.transform.parent = transform;
            Physics.IgnoreCollision(gameObject.GetComponent<BoxCollider>(), obj.collider);

            spawnedProjectiles.Add(obj);

            //Spawn a muzzle flash particle system and destroy after time.
            if (muzzleEffect)
            {
                GameObject flash = Instantiate(muzzleEffect, muzzlePos.position, muzzlePos.rotation) as GameObject;
                flash.transform.parent = transform;
                Destroy(flash, 2f);
            }
        }
    }
}
