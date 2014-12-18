using UnityEngine;
using System.Collections;

public class LookAt : MonoBehaviour {

	public LayerMask Mask;

	// Update is called once per frame
	void Update()
	{
		Vector3 mouse = Input.mousePosition;
		
		//  Cast a ray from the screen into the world
		Ray ray = Camera.main.ScreenPointToRay(mouse);
		RaycastHit hitInfo;
		if(Physics.Raycast(ray, out hitInfo, 1000f, Mask) && !Preferences.instance.isGamePaused)
		{
			//  Adjust target position's Y
			Vector3 target = hitInfo.point;
			target.y = transform.position.y;
			transform.LookAt(target);
		}
		
	
		
	}
}
