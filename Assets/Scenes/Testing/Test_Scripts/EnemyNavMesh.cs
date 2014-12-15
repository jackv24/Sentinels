using UnityEngine;
using System.Collections;

public class EnemyNavMesh : MonoBehaviour 
{

	NavMeshAgent navMeshAgent;
	public GameObject Target;

	// Use this for initialization
	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update () 
	{
		navMeshAgent = GetComponent<NavMeshAgent> ();
		navMeshAgent.SetDestination (Target.transform.position);
	}
}
