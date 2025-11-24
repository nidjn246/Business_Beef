using UnityEngine;

public class ThrowableProp : MonoBehaviour
{
    [SerializeField] private float damage = 20f;
    private bool armed = false;

    virtual public void OnCollisionEnter(Collision collision)
    {
        if (!armed) return;

        // Damage player
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Health>().TakeDamage(damage);
        }

        // Disarm after hitting anything
        armed = false;
        Die();
    }

    public void OnGrab()
    {
        // First: check if the crate even has a parent
        if (transform.parent != null && transform.parent.name == "Inventory")
        {
            // Crate is inside inventory → unarmed
            armed = true;
        }
    }

    virtual public void Die()
    {
        Destroy(gameObject);
    }

}
