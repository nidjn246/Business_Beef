using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{
    public void OpenCredits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void CloseCredits()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
