using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSettings : MonoBehaviour
{
    public static LoadSettings Instance;

    public int playerSpeed;
    public int playerHealth;
    public int gameTime;
    public int propSpawnSpeed;

    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "Match")
        {
            GameTimer timer = FindFirstObjectByType<GameTimer>();
            timer.maxTime = gameTime;
            timer.SetTime();
            FindFirstObjectByType<PropSpawner>().spawnCooldown = propSpawnSpeed;
            for (int i = 0; i < TeamManager.instance.blueTeamMembers.Count; i++)
            {
                TeamManager.instance.blueTeamMembers[i].GetComponent<PlayerMovement>().speed = playerSpeed;
                Health health = TeamManager.instance.blueTeamMembers[i].GetComponent<Health>();
                health.maxHealth = playerHealth;
                health.Heal(playerHealth);
                TeamManager.instance.orangeTeamMembers[i].GetComponent<PlayerMovement>().speed = playerSpeed;
                TeamManager.instance.orangeTeamMembers[i].GetComponent<Health>().maxHealth = playerHealth;
            }

            Destroy(gameObject);
        }
    }
}
