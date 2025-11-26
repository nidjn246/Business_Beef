using UnityEngine;
using System.Collections;

public class Ventilator : MonoBehaviour
{
    [SerializeField] private float launchForce = 20f;
    [SerializeField] private float noControlDuration = 1f;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            Rigidbody rb = collision.GetComponent<Rigidbody>();
            PlayerState ps = collision.GetComponent<PlayerState>();

            Debug.Log("Force added");

            // Set player to NoControl
            ps.currentState = PlayerState.playerState.NoControl;

            Vector3 force = transform.up * (launchForce / 1.5f) + transform.forward * -launchForce;

            rb.linearVelocity = force;

            // Start coroutine to give back control after 1 second
            StartCoroutine(ReturnControl(ps, noControlDuration));
        }
    }

    private IEnumerator ReturnControl(PlayerState ps, float delay)
    {
        yield return new WaitForSeconds(delay);

        ps.currentState = PlayerState.playerState.InControl;
    }
}
