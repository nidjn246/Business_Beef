using UnityEngine;

public class WoodCrate : MonoBehaviour
{
    private float damage = 20f;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Health>().TakeDamage(damage);
        }
    }
}
