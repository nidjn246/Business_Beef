using UnityEngine;

public class PlayerState : MonoBehaviour
{

    public enum playerState
    {
        InControl,
        NoControl,
        Hanging,
        OnLadder,
    }

    public static playerState currentState;




}
