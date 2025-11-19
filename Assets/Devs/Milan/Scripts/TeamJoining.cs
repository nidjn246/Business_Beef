using UnityEngine;

public class TeamJoining : MonoBehaviour
{
    [SerializeField] private string teamName;
    [SerializeField] private Material teamMaterial;
    [SerializeField] private Material defaultMaterial;
    [SerializeField] private bool isThereBoss = false;
    void Start()
    {

    }

    void Update()
    {

    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            TeamManager.instance.AddTeamMember(teamName, collision.gameObject);


        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            TeamManager.instance.RemoveTeamMember(teamName, collision.gameObject);
        }
    }
}
