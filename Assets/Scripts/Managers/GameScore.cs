using TMPro;
using UnityEngine;

public class GameScore : MonoBehaviour
{
    public static GameScore instance;

    [Header("Team Score")]
    private float team1Score;
    private float team2Score;

    [Header("UI Elements")]
    [SerializeField] private TextMeshProUGUI scoreText1;
    [SerializeField] private TextMeshProUGUI scoreText2;
    public enum TeamNumber
    {
        Team1, Team2
    }

    private void Update()
    {
        DisplayScore();
    }

    public void AddScore(TeamNumber teamNumber, float amount)
    {
        switch (teamNumber)
        {
            case TeamNumber.Team1:
                team1Score += amount;
                break;
            case TeamNumber.Team2:
                team2Score += amount;
                break;
        }
    }

    private void DisplayScore()
    {
        scoreText1.text = team1Score.ToString("F0");
        scoreText2.text = team2Score.ToString("F0");
    }


}
