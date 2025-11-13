using UnityEngine;

public class PlayerLedge : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private float hoistHeight = 2f;
    [SerializeField] private bool goLerp = false;
    [SerializeField] private Vector3 target;
    [SerializeField] float lerpSpeed = 0.5f;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (goLerp)
        {
            transform.position = Vector3.Lerp(transform.position, target, lerpSpeed);
            if (Vector3.Distance(transform.position, target) < 0.1f)
            {
                goLerp = false;
            }
        }
    }



    void GoHang(Collider other)
    {
        target = other.transform.position;
        rb.linearVelocity = Vector3.zero;
        rb.useGravity = false;
        goLerp = true;
    }

    void StopHang()
    {
        rb.useGravity = true;
        goLerp = false;
        target = Vector3.zero;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ledge"))
        {
            PlayerState.Instance.currentState = PlayerState.playerState.Hanging;
            GoHang(other);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Ledge"))
        {
            StopHang();
        }
    }
    public void Hoist()
    {
        if (PlayerState.Instance.currentState != PlayerState.playerState.Hanging)
            return;
        StopHang();
        rb.AddForce(Vector3.up * hoistHeight, ForceMode.Impulse);
        PlayerState.Instance.currentState = PlayerState.playerState.Idle;
    }
}
