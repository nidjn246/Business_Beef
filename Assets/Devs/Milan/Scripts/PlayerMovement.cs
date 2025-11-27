using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(PlayerInput))]

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float stepDistance = 0.5f;
    [SerializeField] private List<Animator> animators;
    public float speed = 5f;
    [SerializeField] private GameObject feet;
    [SerializeField] private float stepSpeed = 5f;
    private Rigidbody rb;
    private float moveDirection;
    private PlayerState playerStateScript;
    void Awake()
    {
        playerStateScript = GetComponent<PlayerState>();
        rb = GetComponent<Rigidbody>();


    }


    void FixedUpdate()
    {

        if (playerStateScript.currentState == PlayerState.playerState.InControl)
        {
            rb.linearVelocity = new Vector3(moveDirection, rb.linearVelocity.y, 0);
        }

        if (moveDirection < 0)
        {
            transform.rotation = Quaternion.Euler(0, 270, 0);
        }
        else if (moveDirection > 1)
        {
            transform.rotation = Quaternion.Euler(0, 90, 0);
        }





    }

    private void Update()
    {
        for (int i = 0; i < animators.Count; i++)
        {
            if (animators[i].gameObject.activeSelf)
            {
                if (moveDirection == 0)
                {
                    animators[i].SetBool("IsMoving", false);
                }
                else
                {
                    animators[i].SetBool("IsMoving", true);

                }
                animators[i].SetFloat("Speed", speed / 30);
            }
        }

        //Ray ray = new Ray(feet.transform.position, transform.forward);
        //Debug.DrawRay(ray.origin, ray.direction * stepDistance, Color.red);

        //if (Physics.Raycast(ray, out RaycastHit hit, 50, ~LayerMask.GetMask("Players")))
        //{
        //    if (hit.distance <= stepDistance)
        //    {
        //        transform.position = Vector3.Lerp(transform.position, transform.position + Vector3.up, Time.deltaTime * stepSpeed);
        //    }

        //}








    }








    public void OnMove(InputAction.CallbackContext context)
    {
        moveDirection = context.ReadValue<Vector2>().x;
        moveDirection *= speed;

    }

    private void OnCollisionEnter(Collision collision)
    {
        ContactPoint contact = collision.contacts[0];
        Vector3 normal = contact.normal;
        if (Vector3.Dot(normal, Vector3.up) > 0.5f) return;


    }
}
