using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameTimer : MonoBehaviour
{
    [Header("Time")]
    [SerializeField] float TimeLeft;
    [SerializeField] float maxTime = 60f;
    [Space]

    [Header("References")]
    [SerializeField] private TextMeshProUGUI timerText;
    [Space]

    [Header("Scene")]
    [SerializeField] private string winsceneName;

    void Start()
    {
        TimeLeft = maxTime;
    }

    void Update()
    {
        Timer();

        if (TimeLeft <= 0f)
        {
            GameEnd();
        }
    }

    private void Timer()
    {
        TimeLeft -= Time.deltaTime;
        TimeLeft = Mathf.Max(TimeLeft, 0f);

        int minutes = Mathf.FloorToInt(TimeLeft / 60);
        int seconds = Mathf.FloorToInt(TimeLeft % 60);

        timerText.text = $"{minutes:00}:{seconds:00}";
    }

    private void GameEnd()
    {
        SceneManager.LoadScene(winsceneName);
    }

}