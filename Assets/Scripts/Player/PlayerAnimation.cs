using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PlayerMove))]
public class PlayerAnimation : MonoBehaviour
{
    public Animator anim;

    private PlayerMove movement;

    void Start()
    {
        movement = GetComponent<PlayerMove>();
    }

    void Update()
    {
        if (anim)
        {
            anim.SetFloat("Speed", movement.inputVector.magnitude);
        }
    }
}
