using UnityEngine;
using System.Collections;

public class EnemyNavMesh : MonoBehaviour 
{
	NavMeshAgent navMeshAgent;
	Transform Target;
		
	// Use this for initialization
	void Start () 
	{

	}

	// Update is called once per frame
	void Update () 
	{
        //Tells the spawned enemies to find the finish line and move towards it
		Target = GameObject.FindGameObjectWithTag ("Finish").transform;
		navMeshAgent = GetComponent <NavMeshAgent> ();
		navMeshAgent.SetDestination (Target.transform.position);
	}	
}
