using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(PlayerInput))]

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    private Rigidbody rb;
    private float moveDirection;
    void Start()
    {
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

        if (PlayerState.Instance.currentState == PlayerState.playerState.Hanging)
            return;
        if (moveDirection != 0)
        {
            PlayerState.Instance.currentState = PlayerState.playerState.Running;
        }
        else
        {
            PlayerState.Instance.currentState = PlayerState.playerState.Idle;
        }

    }
}
