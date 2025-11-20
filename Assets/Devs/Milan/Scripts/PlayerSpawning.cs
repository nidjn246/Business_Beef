using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawning : MonoBehaviour
{
    [SerializeField] private List<GameObject> spawns;
    void Start()
    {
        StartCoroutine(CoroutineAction());
    }

    public IEnumerator CoroutineAction()
    {

        yield return new WaitForEndOfFrame();
        for (int i = 0; i < TeamManager.instance.blueTeamMembers.Count; i++)
        {

            TeamManager.instance.blueTeamMembers[i].transform.position = spawns[i].transform.position;

        }
        for (int i = 0; i < TeamManager.instance.orangeTeamMembers.Count; i++)
        {
            TeamManager.instance.orangeTeamMembers[i].transform.position = spawns[i + 2].transform.position;


        }
    }
}
