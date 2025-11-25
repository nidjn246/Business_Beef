using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Dash : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private float dashForce = 1f;
    [SerializeField] private float dashTime = 1.0f;
    [SerializeField] private float dashTimer = 1f;
    [SerializeField] private float cooldownTimer = 2;
    [SerializeField] private float cooldownTime = 2;
    private PlayerState state;
    private void Start()
    {
        state = GetComponent<PlayerState>();
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (cooldownTimer <= 0) return;
        cooldownTimer -= Time.deltaTime;
    }

    public void OnDash(InputAction.CallbackContext context)
    {
        if (context.canceled || cooldownTimer > 0) return;
        cooldownTimer = cooldownTime;
        dashTimer = dashTime;
        StartCoroutine(Dashing());
    }
    private IEnumerator Dashing()
    {
        state.currentState = PlayerState.playerState.NoControl;

        Vector3 start = transform.position;
        Vector3 target = start + transform.forward * dashForce;

        float timer = dashTimer;

        while (timer > 0f)
        {
            float t = 1f - (timer / dashTime);
            transform.position = Vector3.Slerp(start, target, Mathf.Clamp01(t));

            timer -= Time.deltaTime;
            dashTimer = Mathf.Max(0f, timer);

            yield return null;
        }



        state.currentState = PlayerState.playerState.InControl;
        yield break;
    }

}
