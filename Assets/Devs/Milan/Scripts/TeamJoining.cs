using UnityEngine;

public class TeamJoining : MonoBehaviour
{
    [SerializeField] private Material teamMaterial;
    [SerializeField] private Material defaultMaterial;
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
            collision.gameObject.GetComponentInChildren<Renderer>().material = teamMaterial;
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponentInChildren<Renderer>().material = defaultMaterial;
        }
    }
}
