using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private float maxHealth = 100f;
    [SerializeField] private float currentHealth;
    [SerializeField] private Image healthbar;
    [SerializeField] private GameObject respawnPoint;
    [SerializeField] private float respawnTimer = 5f;

    private bool playerDied;


    private void Start()
    {
        ResetHealth();
    }

    private void Awake()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
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
    }

    private void DisplayHealth()
    {
        healthbar.fillAmount = currentHealth / maxHealth;

    }

    public IEnumerator RespawnCooldown()
    {
        yield return new WaitForSeconds(respawnTimer);
        Respawn();
    }

    // Respawn functionality
    private void Respawn()
    {
        gameObject.transform.position = respawnPoint.transform.position;
        ResetHealth();
        playerDied = false;
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

}
