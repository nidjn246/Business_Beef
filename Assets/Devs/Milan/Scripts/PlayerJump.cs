using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerJump : MonoBehaviour
{
    private Rigidbody rb;
    private bool grounded = true;
    [SerializeField] private float jumpHeight = 5f;
    private PlayerState playerStateScript;
    private Health health;
    [SerializeField] private List<Animator> animators;
    void Start()
    {
        playerStateScript = GetComponent<PlayerState>();
        rb = GetComponent<Rigidbody>();
        health = GetComponent<Health>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (!context.performed || health.playerDied == true)
            return;

        if (grounded)
        {
            for (int i = 0; i < animators.Count; i++)
            {
                animators[i].SetTrigger("Jump");
            }
            rb.AddForce(new Vector3(0, jumpHeight, 0), ForceMode.Impulse);
            AudioManager.PlaySound(SoundType.JUMP, true, 0.6f);
            grounded = false;
        }


    }

    private void Update()
    {
        if (grounded == false)
        {
            for (int i = 0; i < animators.Count; i++)
            {
                animators[i].ResetTrigger("Land");
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        ContactPoint contact = collision.contacts[0];
        Vector3 normal = contact.normal;
        if (Vector3.Dot(normal, Vector3.up) > 0.5f)
        {
            for (int i = 0; i < animators.Count; i++)
            {
                animators[i].SetTrigger("Land");
            }
            grounded = true;
        }


    }
}
