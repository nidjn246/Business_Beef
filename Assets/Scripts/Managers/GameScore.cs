using UnityEngine;
using TMPro;

public class GameScore : MonoBehaviour
{
    public static GameScore Instance { get; private set; }

    [Header("Team Score")]
    private float team1Score;
    private float team2Score;

    [Header("UI Elements")]
    [SerializeField] private TextMeshPro scoreText1;
    [SerializeField] private TextMeshPro scoreText2;
    public enum TeamNumber
    {
        Team1, Team2
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
        
    }

    
}
