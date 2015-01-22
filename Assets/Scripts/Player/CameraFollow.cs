using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

/* Reads in mouse input, and therefore orbits the camera based on that input. */

public class CameraFollow : MonoBehaviour
{
    public Transform target;

    public float heightOffset = 1.5f;

    public float distance = 6.0f;
    public float distanceMin = 1.0f;
    public float distanceMax = 10.0f;

    public float CameraZoomSpeed = 50.0f;

    void Start()
    {
        if (target == null)
            target = GameObject.FindWithTag("Player").transform;
    }

    void LateUpdate()
    {
        //Don't do anything if no player is registered.
        if (target == null)
            return;

        //Zoom
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            if (Input.GetAxisRaw("Mouse ScrollWheel") > 0)
                distance -= CameraZoomSpeed * Time.deltaTime;
            else if (Input.GetAxisRaw("Mouse ScrollWheel") < 0)
                distance += CameraZoomSpeed * Time.deltaTime;
        }
        distance = Mathf.Clamp(distance, distanceMin, distanceMax);

        transform.position = target.position;
        transform.position += transform.rotation * Vector3.back * distance;
        transform.position += Vector3.up * heightOffset;
    }
}
