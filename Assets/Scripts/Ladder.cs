using UnityEngine;
using UnityEngine.InputSystem;

public class Ladder : MonoBehaviour
{
    private bool playerInside = false;
    private GameObject player;
    private float offset = -1f;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = true;
            player = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = false;

            // re-enable gravity
            other.GetComponent<Rigidbody>().useGravity = true;

        }
    }

    public void EnterLadder(InputAction.CallbackContext ctx)
    {

        // If player is inside ladder trigger
        if (playerInside && ctx.performed)
        {
            // If ALREADY climbing → exit ladder
            if (player.GetComponent<PlayerMovement>().isClimbingLadder)
            {
                ExitLadder();
            }
            else
            {
                // Not climbing → enter ladder
                EnterLadderState();
            }
        }
    }

    private void EnterLadderState()
    {
        if (!player.GetComponent<PlayerMovement>().isClimbingLadder) return;
        Debug.Log("Enter ladder");

        PlayerState.currentState = PlayerState.playerState.OnLadder;

        // disable gravity while climbing
        player.GetComponent<Rigidbody>().useGravity = false;

        player.GetComponent<PlayerMovement>().isClimbingLadder = true;

        // snap player onto ladder
        player.transform.position = new Vector3(
            transform.position.x,
            player.transform.position.y,
            transform.position.z + offset
        );
    }

    private void ExitLadder()
    {
        Debug.Log("Exit ladder");
        PlayerState.currentState = PlayerState.playerState.InControl;

        player.GetComponent<PlayerMovement>().isClimbingLadder = false;

        // restore gravity
        player.GetComponent<Rigidbody>().useGravity = true;

        // move player back to original position
        player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, 0f);
    }
}
