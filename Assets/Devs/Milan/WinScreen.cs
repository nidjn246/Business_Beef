using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

public class WinScreen : MonoBehaviour
{
    private void Start()
    {
        Destroy(FindFirstObjectByType<CinemachineTargetGroup>().gameObject);
        Destroy(TeamManager.instance.gameObject);
        Destroy(FindFirstObjectByType<PlayerInputManager>().gameObject);
        for (int i = 0; i < TeamManager.instance.blueTeamMembers.Count; i++)
        {
            Destroy(TeamManager.instance.blueTeamMembers[i]);
            Destroy(TeamManager.instance.orangeTeamMembers[i]);
        }
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void RestartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("PlayerSelect");
    }

    public void MainMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Main Menu");
    }
}
