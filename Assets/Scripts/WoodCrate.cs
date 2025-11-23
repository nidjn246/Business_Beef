using UnityEngine;

public class WoodCrate : ThrowableProp
{
    [Header("Elements")]
    [SerializeField] private GameObject deathParticles;
    public override void Die()
    {
        SpawnParticles();
        base.Die();
        AudioManager.PlaySound(SoundType.CRATEBREAK, true, 0.6f);
    }

    private void SpawnParticles()
    {
        GameObject particles = Instantiate(deathParticles, gameObject.transform.position, Quaternion.identity);

        Destroy(particles, 5f);
    }
}
