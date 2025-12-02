using System.Collections;
using UnityEngine;

public class Ladder : MonoBehaviour
{
    public Transform upTransform;
    public Transform downTransform;

    public void EnterLadderState(Transform player)
    {
        StartCoroutine(WaitForNextFrameToTP(player));
    }

    private IEnumerator WaitForNextFrameToTP(Transform player)
    {
        bool enteredFromBelow = player.position.y < transform.position.y;

        player.position = enteredFromBelow ? upTransform.position : downTransform.position;
        yield return null;
        player.position = enteredFromBelow ? upTransform.position : downTransform.position;
        yield return null;
        player.position = enteredFromBelow ? upTransform.position : downTransform.position;
        yield return null;
        player.position = enteredFromBelow ? upTransform.position : downTransform.position;
        yield return null;
        player.position = enteredFromBelow ? upTransform.position : downTransform.position;
        yield return null;
        player.position = enteredFromBelow ? upTransform.position : downTransform.position;
        yield break;

    }
}
