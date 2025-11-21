using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Push : MonoBehaviour
{
    [SerializeField] private float pushForce = 10f;
    [SerializeField] private List<GameObject> playersInRadius;
    public bool isPushed = false;
    private Rigidbody rb;
    private PlayerState playerState;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playersInRadius.Add(other.gameObject);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playersInRadius.Remove(other.gameObject);
        }
    }


    private void Start()
    {
        rb = GetComponentInParent<Rigidbody>();
        playerState = GetComponentInParent<PlayerState>();
    }


    public void OnPush()
    {
        StartCoroutine(Pushing());
    }

    private IEnumerator Pushing()
    {
        foreach (GameObject player in playersInRadius)
        {
            Rigidbody rb = player.GetComponent<Rigidbody>();
            PlayerState playerState = player.GetComponent<PlayerState>();
            playerState.currentState = PlayerState.playerState.NoControl;
            rb.linearVelocity = Vector3.zero;
            rb.AddForce(transform.parent.forward * pushForce, ForceMode.Impulse);
            player.GetComponentInChildren<Push>().isPushed = true;
            yield return new WaitForSeconds(0.3f);
            playerState.currentState = PlayerState.playerState.InControl;
            yield break;
        }
    }
}
