using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(PlayerInput))]

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
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
        rb.linearVelocity = new Vector3(moveDirection, rb.linearVelocity.y, 0);
    }

    public void OnMove(InputAction.CallbackContext context)
    {

        moveDirection = context.ReadValue<Vector2>().x;
        moveDirection *= speed;

        if (playerStateScript.currentState == PlayerState.playerState.Hanging)
            return;
        if (moveDirection != 0)
        {
            playerStateScript.currentState = PlayerState.playerState.Running;
        }
        else
        {
            playerStateScript.currentState = PlayerState.playerState.Idle;
        }

    }
}
