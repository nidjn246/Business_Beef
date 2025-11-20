using UnityEngine;

public class PlayerState : MonoBehaviour
{

    public enum playerState
    {
        Idle,
        Running,
        Jumping,
        Hanging,
        Dashing,
    }

    public playerState currentState;




}
