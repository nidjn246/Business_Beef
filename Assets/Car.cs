using System.Collections;
using UnityEngine;

public class Car : MonoBehaviour
{
    [SerializeField] private float carSpeed = 100f;
    [SerializeField] private float knockbackForce = 10f;
    [SerializeField] private float damage = 75f;

    private Rigidbody rb;
    private AudioSource audioSource;
    


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        audioSource.pitch = Random.Range(2.5f, 3f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && other is CapsuleCollider)
        {
            Rigidbody playerRb = other.GetComponent<Rigidbody>();
            Health playerHealth = other.GetComponent<Health>();
            PlayerState ps = other.GetComponent<PlayerState>();

            // Knockback direction
            Vector3 knockbackDir = (other.transform.position - transform.position).normalized;
            knockbackDir.y = 0.5f * knockbackForce / 2; // upward lift
            knockbackDir.x *= knockbackForce * 3f;
            knockbackDir.z = 0f;

            // Apply knockback
            ps.currentState = PlayerState.playerState.NoControl;
            playerRb.linearVelocity = knockbackDir;
            StartCoroutine(WaitForControl(ps));
            

            // Deal damage
            playerHealth.TakeDamage(damage);
            AudioManager.PlaySound(SoundType.CARHONK);
            AudioManager.PlaySound(SoundType.TRAFFICCONE);
        }
    }

    private void Update()
    {
        // Car always moves forward at consistent speed
        rb.linearVelocity = transform.forward * carSpeed;
    }

    private IEnumerator WaitForControl(PlayerState ps)
    {
        yield return new WaitForSeconds(1.5f);
        ps.currentState = PlayerState.playerState.InControl;
    }
}
