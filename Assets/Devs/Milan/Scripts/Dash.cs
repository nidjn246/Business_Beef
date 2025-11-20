using UnityEngine;

public class Dash : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private float dashForce = 10f;
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
    public void onDash()
    {
        if (cooldownTimer <= 0f)
        {
            state.currentState = PlayerState.playerState.Dashing;
            rb.AddForce(transform.forward * dashForce, ForceMode.Impulse);
            cooldownTimer = cooldownTime;
        }
    }
}
