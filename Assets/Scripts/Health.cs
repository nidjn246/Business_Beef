using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private float maxHealth = 100f;
    [SerializeField] private float currentHealth;
    [SerializeField] private Image healthbar;
    [SerializeField] private GameObject respawnPoint;
    [SerializeField] private float respawnTimer = 5f;


    private void Start()
    {
        currentHealth = maxHealth;
        respawnPoint = GameObject.FindWithTag("RespawnPoint");

    }
    private void Update()
    {
        DisplayHealth();
    }

    // Function to Damage the player
    public void TakeDamage(float damageAmount)
    {
        currentHealth -= damageAmount;

        if (currentHealth <= 0)
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
        if (respawnPoint == null)
        {
            Debug.LogWarning("Player Health: No Respawn Point Assigned!");
        }
        gameObject.transform.position = respawnPoint.transform.position;
    }

    [ContextMenu("TakeDamage")]
    public void Damage10()
    {
        TakeDamage(50f);
    }

}
