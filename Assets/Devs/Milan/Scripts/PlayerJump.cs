using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerJump : MonoBehaviour
{
    private Rigidbody rb;
    private bool grounded = true;
    [SerializeField] private float jumpHeight = 5f;
    private PlayerState playerStateScript;
    void Start()
    {
        playerStateScript = GetComponent<PlayerState>();
        rb = GetComponent<Rigidbody>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (!context.performed)
            return;

        if (grounded)
        {
            rb.AddForce(new Vector3(0, jumpHeight, 0), ForceMode.Impulse);
            playerStateScript.currentState = PlayerState.playerState.Jumping;
            grounded = false;
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        ContactPoint contact = collision.contacts[0];
        Vector3 normal = contact.normal;
        if (Vector3.Dot(normal, Vector3.up) > 0.5f)
        {
            playerStateScript.currentState = PlayerState.playerState.Idle;
            grounded = true;
        }


    }
}
