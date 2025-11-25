using TMPro;
using UnityEngine;

public class SaveSettings : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown playerSpeed;
    [SerializeField] private TMP_Dropdown playerHealth;
    [SerializeField] private TMP_Dropdown gameTimer;
    [SerializeField] private TMP_Dropdown propSpawnSpeed;


    private void Update()
    {

        LoadSettings.Instance.playerSpeed = (playerSpeed.value + 1) * 10;
        LoadSettings.Instance.playerHealth = int.Parse(playerHealth.captionText.text);
        LoadSettings.Instance.gameTime = int.Parse(gameTimer.captionText.text);
        LoadSettings.Instance.propSpawnSpeed = -propSpawnSpeed.value + 3;
    }
}
