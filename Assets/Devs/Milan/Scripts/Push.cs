using System.Collections.Generic;
using UnityEngine;

public class Push : MonoBehaviour
{
    [SerializeField] private float pushForce = 10f;
    [SerializeField] private List<GameObject> playersInRadius;
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

    public void OnPush()
    {
        foreach (GameObject player in playersInRadius)
        {
            Rigidbody rb = player.GetComponent<Rigidbody>();
            rb.AddForce(transform.parent.forward * pushForce, ForceMode.Impulse);
        }
    }
}
