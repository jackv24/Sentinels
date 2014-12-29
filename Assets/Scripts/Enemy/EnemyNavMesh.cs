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
		Target = GameObject.FindGameObjectWithTag ("Finish").transform;
		navMeshAgent = GetComponent <NavMeshAgent> ();
		navMeshAgent.SetDestination (Target.transform.position);
	}

	void OnCollisionEnter (Collision other)
	{

	}
}
