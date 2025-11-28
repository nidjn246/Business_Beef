using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TeamManager : MonoBehaviour
{
    public static TeamManager instance;
    [SerializeField] GameObject startCanvas;
    public List<GameObject> blueTeamMembers;
    [SerializeField] GameObject startButton;
    public List<GameObject> orangeTeamMembers;
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void Update()
    {
        if (startCanvas == null) return;

        if (Time.timeScale == 0)
        {
            startCanvas.SetActive(false);
            return;
        }


        if (blueTeamMembers.Count == 1 && orangeTeamMembers.Count == 1)
        {
            startCanvas.SetActive(true);
            EventSystem.current.SetSelectedGameObject(startButton);
        }
        else if (blueTeamMembers.Count == 2 && orangeTeamMembers.Count == 2)
        {
            startCanvas.SetActive(true);
            EventSystem.current.SetSelectedGameObject(startButton);
        }
        else
        {
            startCanvas.SetActive(false);
        }
    }

    public void AddTeamMember(string team, GameObject player)
    {
        if (blueTeamMembers.Contains(player) || orangeTeamMembers.Contains(player))
        {
            return;
        }
        if (team == "blue")
        {
            blueTeamMembers.Add(player);
            player.layer = 9;
        }
        else if (team == "orange")
        {
            orangeTeamMembers.Add(player);
            player.layer = 10;
        }
    }

    public void RemoveTeamMember(string team, GameObject player)
    {
        if (team == "blue")
        {
            blueTeamMembers.Remove(player);

        }
        else if (team == "orange")
        {
            orangeTeamMembers.Remove(player);
        }
    }


}
