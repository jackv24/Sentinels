using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
	public GameObject Enemy;
	public GameObject EnemyLvl2;
    public float EnemySpawn = 100f;

	// Use this for initialization
	void Start ()
    {

	}
	
	// Update is called once per frame
	void Update () 
    {
		EnemySpawn -= 1;

        if (EnemySpawn < 10)
        {
            float RandNum = Random.Range(0, 4);
            float ChosenNum = RandNum;

            if (ChosenNum <= 2)
            {
                GameObject Spawn = Instantiate(Enemy, transform.position, transform.rotation) as GameObject;
            }
			else
			{
				GameObject Spawn = Instantiate (EnemyLvl2, transform.position, transform.rotation) as GameObject;
			}

            EnemySpawn = 100f;
        }
	}
}
