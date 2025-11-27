using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    private Pickup pickupScript;

    public float maxHealth = 100f;
    [SerializeField] private float currentHealth;
    [SerializeField] private Image healthbar;
    [SerializeField] private GameObject respawnPoint;
    public float respawnSpeed = 5f;

    [SerializeField] private GameObject deathParticles;

    private bool playerDied;


    private void Start()
    {
        ResetHealth();
    }

    private void Awake()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        pickupScript = GetComponent<Pickup>();
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Match")
        {
            respawnPoint = GameObject.FindWithTag("RespawnPoint");
        }
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void Update()
    {
        DisplayHealth();
    }

    // Function to Damage the player
    public void TakeDamage(float damageAmount)
    {
        currentHealth -= damageAmount;
        AudioManager.PlaySound(SoundType.HIT, true);
        if (currentHealth <= 0 && !playerDied)
        {
            Die();
        }
    }

    // Function to Heal the player
    public void Heal(float healAmount)
    {
        currentHealth += healAmount; // Adds amount to health

        // Health can't go above max
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    public void Die()
    {
        StartCoroutine(RespawnCooldown());
        playerDied = true;
        PlayerActive(false);
        SpawnParticles(deathParticles);

    }

    private void DisplayHealth()
    {
        healthbar.fillAmount = currentHealth / maxHealth;

    }

    public IEnumerator RespawnCooldown()
    {
        yield return new WaitForSeconds(respawnSpeed);
        Respawn();
    }

    // Respawn functionality
    private void Respawn()
    {
        gameObject.transform.position = respawnPoint.transform.position;
        ResetHealth();
        playerDied = false;

        PlayerActive(true);
    }

    [ContextMenu("TakeDamage")]
    public void Damage10()
    {
        TakeDamage(50f);
    }

    // Sets currentHealth to Max
    private void ResetHealth()
    {
        currentHealth = maxHealth;
    }

    private void PlayerActive(bool enabled)
    {
        if (enabled)
        {
            // Turns player visable
            foreach (MeshRenderer mr in gameObject.GetComponentsInChildren<MeshRenderer>())
            {
                mr.enabled = true;
            }

            pickupScript.enabled = true;
            gameObject.GetComponentInChildren<Canvas>().enabled = true;
            GetComponent<PlayerMovement>().enabled = enabled;
        }

        if (!enabled)
        {
            // Turns player invisible
            foreach (MeshRenderer mr in gameObject.GetComponentsInChildren<MeshRenderer>())
            {
                mr.enabled = false;
            }


            pickupScript.enabled = false;
            gameObject.GetComponentInChildren<Canvas>().enabled = false;
            GetComponent<PlayerMovement>().enabled = false;
        }


    }

    private void SpawnParticles(GameObject particles)
    {
       GameObject particle = Instantiate(particles, gameObject.transform.position, Quaternion.identity);
       Destroy(particle, 5f);
    }

}
