using System.Collections;
using UnityEngine;

public class MetalPipe : ThrowableProp
{

    [Header("Stats")]
    [SerializeField] private float stunTime;
    public override void Die()
    {
        base.Die();
        AudioManager.PlaySound(SoundType.METALPIPE, true, 0.3f);
    }

    public override void OnCollisionEnter(Collision collision)
    {
        base.OnCollisionEnter(collision);

        if (collision.gameObject.CompareTag("Player") && gameObject.transform.parent != null)
        {
            StartCoroutine(StunPlayer(collision.gameObject));
        }
    }

    private IEnumerator StunPlayer(GameObject playerToStun)
    {
        // Calculate knockback direction from "this" object to the player
        Vector3 knockbackDirection = (playerToStun.transform.position - transform.position).normalized;

        // Disable player movement
        PlayerMovement playerMovement = playerToStun.GetComponent<PlayerMovement>();
        Rigidbody rb = playerToStun.GetComponent<Rigidbody>();
        playerMovement.enabled = false;

        // Apply knockback force
        float knockbackForce = 10f; // Adjust this value as needed
        rb.AddForce(knockbackDirection * knockbackForce, ForceMode.Impulse);

        // Wait for the stun duration
        yield return new WaitForSeconds(stunTime);

        // Re-enable player movement
        playerMovement.enabled = true;
    }

}
