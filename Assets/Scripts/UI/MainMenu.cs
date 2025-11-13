using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MainMenu : MonoBehaviour
{
    [Header("Elements")]
    private UIDocument mainMenuUI;
    private Button startButton;
    private Button quitButton;
    [SerializeField] private string sceneName;

    private void Awake()
    {
        mainMenuUI = GetComponent<UIDocument>();
        startButton = mainMenuUI.rootVisualElement.Q("StartGame") as Button;
        quitButton = mainMenuUI.rootVisualElement.Q("QuitGame") as Button;

        startButton.RegisterCallback<ClickEvent>(StartGame);
        quitButton.RegisterCallback<ClickEvent>(QuitGame);
    }

    private void StartGame(ClickEvent clickEvent)
    {
        SceneManager.LoadScene(sceneName);
    }

    private void QuitGame(ClickEvent clickEvent)
    {
        Application.Quit();
        Debug.Log("Game Quit");
    }
}
