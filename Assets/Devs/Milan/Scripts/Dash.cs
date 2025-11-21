using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Dash : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private float dashForce = 10f;
    [SerializeField] private float dashTime = 1.0f;
    [SerializeField] private float dashTimer = 2f;
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
        if (cooldownTimer > 0f)
        {
            cooldownTimer -= Time.deltaTime;
        }
    }

    public void OnDash(InputAction.CallbackContext context)
    {
        if (context.canceled) return;
        cooldownTimer = cooldownTime;
        StartCoroutine(Dashing());
    }
    private IEnumerator Dashing()
    {
        bool isDashing = true;
        Vector3 target = transform.position + new Vector3(10, 0, 0);
        while (cooldownTimer > cooldownTime)
        {
            transform.position = Vector3.Slerp(transform.position, target, dashForce);
            //if (Vector3.Distance(transform.position, target) < 0.1f)
            //{
            //    isDashing = false;
            //}
        }
        yield return null;
    }

}
