using UnityEngine;
using UnityEngine.InputSystem;

public class LadderDetection : MonoBehaviour
{
    [SerializeField] private Ladder currentLadder;
    [SerializeField] private Transform player;

    private void Start()
    {
        player = transform.parent;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ladder"))
            currentLadder = other.gameObject.GetComponent<Ladder>();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ladder"))
            currentLadder = null;
    }

    public void OnEnterLadder(InputAction.CallbackContext ctx)
    {
        if (currentLadder != null && ctx.started)
        {
            currentLadder.EnterLadderState(player);
        }
    }
}
