using System.Collections;
using UnityEngine;

public class MetalPipe : ThrowableProp
{
    [Header("Elements")]
    [SerializeField] private GameObject deathParticles;

    [Header("Stats")]
    [SerializeField] private float stunTime;
    public override void Die()
    {
        SpawnParticles();
        base.Die();
        AudioManager.PlaySound(SoundType.METALPIPE, true, 0.6f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(StunPlayer(collision.gameObject));
        }
    }

    private void SpawnParticles()
    {
        GameObject particles = Instantiate(deathParticles, gameObject.transform.position, Quaternion.identity);

        Destroy(particles, 5f);
    }

    private IEnumerator StunPlayer(GameObject playerToStun)
    {
        playerToStun.GetComponent<PlayerState>().enabled = false;
        yield return new WaitForSeconds(stunTime);
        playerToStun.GetComponent <PlayerState>().enabled = true;
    }
}
