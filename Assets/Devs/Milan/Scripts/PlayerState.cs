using UnityEngine;

public class PlayerState : MonoBehaviour
{

    public enum playerState
    {
        Idle,
        Running,
        Jumping,
        Hanging,
    }

    public playerState currentState;



    void Update()
    {

    }
}
