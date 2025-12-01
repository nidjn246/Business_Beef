using UnityEngine;

public class Ladder : MonoBehaviour
{
    public Transform upTransform;
    public Transform downTransform;

    public void EnterLadderState(Transform player)
    {
        bool enteredFromBelow = player.position.y < transform.position.y;

        player.position = enteredFromBelow ? upTransform.position : downTransform.position;
    }
}
