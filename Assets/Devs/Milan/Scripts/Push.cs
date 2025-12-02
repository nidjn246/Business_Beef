using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Push : MonoBehaviour
{
    [SerializeField] private float pushForce = 10f;
    [SerializeField] private List<GameObject> playersInRadius;
    [SerializeField] private List<Animator> animators;
    public bool isPushed = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playersInRadius.Add(other.gameObject);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playersInRadius.Remove(other.gameObject);
        }
    }



    public void OnPush(InputAction.CallbackContext context)
    {
        if (context.canceled) return;
        for (int i = 0; i < animators.Count; i++)
        {
            animators[i].SetTrigger("Push");
        }
        StartCoroutine(Pushing());
        AudioManager.PlaySound(SoundType.PUSH, true, 0.5f);
    }

    private IEnumerator Pushing()
    {
        foreach (GameObject player in playersInRadius)
        {
            Rigidbody rb = player.GetComponent<Rigidbody>();
            PlayerState playerState = player.GetComponent<PlayerState>();
            PlayerState.currentState = PlayerState.playerState.NoControl;
            rb.linearVelocity = Vector3.zero;
            rb.AddForce(transform.parent.forward * pushForce, ForceMode.Impulse);
            player.GetComponentInChildren<Push>().isPushed = true;
            yield return new WaitForSeconds(0.3f);
            PlayerState.currentState = PlayerState.playerState.InControl;
            yield break;
        }
    }
}
