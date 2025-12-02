using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameTimer : MonoBehaviour
{
    [Header("Time")]
    [SerializeField] float TimeLeft;
    public float maxTime = 60f;
    [Space]

    [Header("References")]
    [SerializeField] private TextMeshProUGUI timerText;
    [Space]

    [Header("Scene")]
    [SerializeField] private string blueWonScene;
    [SerializeField] private string orangeWonScene;
    [SerializeField] GameScore GameScore;

    private void Start()
    {
        SetTime();
    }

    public void SetTime()
    {
        TimeLeft = maxTime;
    }

    void Update()
    {
        Timer();

        if (TimeLeft <= 0)
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
        GameObject[] allPlayers = GameObject.FindGameObjectsWithTag("Player");

        List<GameObject> blueList = new List<GameObject>();
        List<GameObject> orangeList = new List<GameObject>();

        foreach (GameObject player in allPlayers)
        {
            if (player.layer == LayerMask.NameToLayer("Blue"))
            {
                blueList.Add(player);
            }
            else if (player.layer == LayerMask.NameToLayer("Orange"))
            {
                orangeList.Add(player);
            }
        }

        GameObject[] bluePlayers = blueList.ToArray();
        GameObject[] orangePlayers = orangeList.ToArray();

        bool blueWon = GameScore.GetWinner();

        if (blueWon)
        {
            foreach (GameObject p in orangePlayers)
            {
                Destroy(p);
            }

            SceneManager.LoadScene(blueWonScene);
        }
        else
        {
            foreach (GameObject p in bluePlayers)
            {
                Destroy(p);
            }

            SceneManager.LoadScene(orangeWonScene);
        }
    }



}