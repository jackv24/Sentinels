using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {
	public float speed = 0.5f;
	CharacterController controller;
	// Use this for initialization
	void Start () {
		controller = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
		float x = Input.GetAxis("Horizontal");
		float z = Input.GetAxis("Vertical");
		Vector3 direction = new Vector3(x,0,z);
		if (direction.magnitude > 1)
			direction.Normalize();
		direction.Normalize();
		Vector3 velocity = direction * speed;
		controller.SimpleMove(velocity);
		
		
	}
}