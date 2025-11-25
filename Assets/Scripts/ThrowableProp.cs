using UnityEngine;

public class ThrowableProp : MonoBehaviour
{
    [SerializeField] private float damage = 20f;
    private bool armed = false;
    [SerializeField] private float lifetime = 30f;
    [SerializeField] private GameObject expiringParticles;
    private float timer = 0f;
    private bool spawnedParticles = false;


    private void Start()
    {
        Destroy(gameObject, lifetime);
    }



    private void Update()
    {
        timer += Time.deltaTime;

        if (!spawnedParticles && timer > lifetime - 5f)
        {
            GameObject particles = Instantiate(expiringParticles, transform.position, Quaternion.identity);
            Destroy(particles, 5f);
            spawnedParticles = true;
        }
    }


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
