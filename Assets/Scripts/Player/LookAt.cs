using UnityEngine;
using System.Collections;

public class LookAt : MonoBehaviour {
	
	// Use this for initializationvoid Start () { 
	
	
	// Update is called once per frame
	void Update()
	{
		Vector3 mouse = Input.mousePosition;
		
		//  Cast a ray from the screen into the world
		Ray ray = Camera.main.ScreenPointToRay(mouse);
		RaycastHit hitInfo;
		Physics.Raycast(ray, out hitInfo);
		
		//  Adjust target position's Y
		Vector3 target = hitInfo.point;
		target.y = transform.position.y;
		transform.LookAt(target);
		
	}
}
