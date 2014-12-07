using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{
	public Transform target;
	public float speed = 0.3f;
	
	private Vector3 initialPos;
	
	void Start()
	{
		initialPos = transform.position - target.position;   
	}
	
	void Update()
	{
		transform.position = Vector3.Lerp(transform.position, target.position + initialPos, speed);
	}
	
	
	
	
}