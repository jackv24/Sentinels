using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{
	public Transform Target;
	public float speed = 10.0f;
	
	Vector3 direction;
	
	void Update() {
		direction = Target.position - transform.position;
		direction.y = 0;
		float distance = direction.magnitude;
		direction.Normalize();
		
		if(distance > 2){			
			transform.position = transform.position + direction * speed * Time.deltaTime;
		}
	}
	
	
	
	
}