using UnityEngine;

public class PlayerState : MonoBehaviour
{
    public static PlayerState Instance;
    public enum playerState
    {
        Idle,
        Running,
        Jumping,
        Hanging,
    }

    public playerState currentState;

    void Awake()
    {
        Instance = this;
    }

    void Update()
    {

    }
}
