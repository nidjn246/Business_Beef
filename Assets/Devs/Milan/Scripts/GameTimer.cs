using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameTimer : MonoBehaviour
{
    [SerializeField] float TimeLeft;
    [SerializeField] float maxTime = 60f;
    private TextMeshProUGUI timerText;
    void Start()
    {
        timerText = GetComponentInChildren<TextMeshProUGUI>();
        TimeLeft = maxTime;
    }
    void Update()
    {
        timerText.text = "Time left: " + Mathf.Round(TimeLeft);
        TimeLeft -= Time.deltaTime;

        if (TimeLeft <= 0f)
        {
            int index = SceneManager.GetActiveScene().buildIndex + 1;
            SceneManager.LoadScene(index);
        }
    }

}