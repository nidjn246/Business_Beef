using System.Collections.Generic;
using UnityEngine;

public class Bomb : ThrowableProp
{
    [SerializeField] private float explosionForce = 5f;
    [SerializeField] private List<GameObject> playersInRange;
    [SerializeField] private float explosionDamage = 10;
    public override void Die()
    {
        for (int i = 0; i < playersInRange.Count; i++)
        {
            playersInRange[i].GetComponent<Rigidbody>().AddExplosionForce(explosionForce, transform.position, 5f, 1f, ForceMode.Impulse);
            playersInRange[i].GetComponent<Health>().TakeDamage(explosionDamage);
        }
        base.Die();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && playersInRange.Contains(other.gameObject) == false)
            playersInRange.Add(other.gameObject);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            playersInRange.Remove(other.gameObject);
    }

}
