using System.Collections;
using UnityEngine;

public class PlayerLedge : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private float hoistHeight = 2f;
    [SerializeField] private bool goLerp = false;
    [SerializeField] private Vector3 target;
    [SerializeField] float lerpSpeed = 0.5f;
    private PlayerState ps;
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        ps = GetComponent<PlayerState>();
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
        ps.currentState = PlayerState.playerState.Hanging;
        target = other.transform.position;
        rb.linearVelocity = Vector3.zero;
        rb.useGravity = false;
        goLerp = true;
    }

    void StopHang()
    {
        ps.currentState = PlayerState.playerState.InControl;
        rb.useGravity = true;
        goLerp = false;
        target = Vector3.zero;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ledge"))
        {
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
        if (ps.currentState != PlayerState.playerState.Hanging) return;
        StopHang();
        rb.linearVelocity = (Vector3.up * hoistHeight);

    }
}
