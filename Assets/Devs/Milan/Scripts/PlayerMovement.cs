using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(PlayerInput))]

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
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

    public void OnMove(InputAction.CallbackContext context)
    {

        moveDirection = context.ReadValue<Vector2>().x;
        moveDirection *= speed;

    }
}
