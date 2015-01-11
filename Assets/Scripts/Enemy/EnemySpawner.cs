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
        //Removes 1 from the spawn timer every frame
		EnemySpawn -= 1;

        if (EnemySpawn < 10)
        {
            //When the spawn timer gets below 10, RandNum chooses a random number between 0 and 4
            float RandNum = Random.Range(0, 4);
            float ChosenNum = RandNum;

            if (ChosenNum <= 2)
            {
                //Spawns a normal enemy
                GameObject Spawn = Instantiate(Enemy, transform.position, transform.rotation) as GameObject;
            }
			else
			{
                //Spawns a special enemy
				GameObject Spawn = Instantiate (EnemyLvl2, transform.position, transform.rotation) as GameObject;
			}
            
            //Resets the spawn timer to 100
            EnemySpawn = 100f;
        }
	}
}
