using UnityEngine;
using System.Collections;

public class EnemyNavMesh : MonoBehaviour 
{

	NavMeshAgent navMeshAgent;
	public GameObject Target;
	public GameObject PlayerTarget;
	public GameObject EnemyGO;
	//public float Distance = Vector3.Distance ();

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

	void oncollisionenter (Collision coll)
	{
		if (coll.transform.tag == "Player")
		{
			navMeshAgent = GetComponent<NavMeshAgent> ();
			navMeshAgent.SetDestination (PlayerTarget.transform.position);
		}
	}
}
