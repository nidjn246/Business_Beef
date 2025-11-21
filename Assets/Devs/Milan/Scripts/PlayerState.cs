using UnityEngine;

public class PlayerState : MonoBehaviour
{

    public enum playerState
    {
        InControl,
        NoControl,
        Hanging,
    }

    public playerState currentState;




}
