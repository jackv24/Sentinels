using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]
public class PlayerMove : MonoBehaviour
{
	public float speed = 0.5f;

    [HideInInspector]
    public Vector3 inputVector;

	CharacterController controller;

	void Start ()
    {
		controller = GetComponent<CharacterController>();
	}
	
	void Update ()
    {
        inputVector = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

		if (inputVector.magnitude > 1)
			inputVector.Normalize();

		Vector3 velocity = inputVector * speed;

		controller.SimpleMove(velocity);
	}
}