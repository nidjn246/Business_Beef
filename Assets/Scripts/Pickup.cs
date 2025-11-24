using UnityEngine;
using UnityEngine.InputSystem;

public class Pickup : MonoBehaviour
{
    [SerializeField] private Transform pickupPoint;
    [SerializeField] private float pickupRange = 25f;
    [SerializeField] private float throwForce = 5f;
    [SerializeField] private LayerMask layer;
    private GameObject heldObject;
    public bool isHolding = false;
    private Vector2 gamepadDir;
    private Vector3 aimDir;

    private void Update()
    {

        if (gamepadDir.sqrMagnitude > 0.1f)
        {
            aimDir = new Vector3(gamepadDir.x, gamepadDir.y, 0).normalized;
        }
    }


    public void OnPickup(InputAction.CallbackContext context)
    {
        if (!context.performed) return;
        TryPickup();
    }

    public void OnDrop(InputAction.CallbackContext context)
    {
        if (!context.performed) return;
        DropProp();
    }

    public void OnThrow(InputAction.CallbackContext context)
    {
        if (!context.performed) return;
        ThrowProp();
    }

    public void OnAim(InputAction.CallbackContext context)
    {
        if (!context.performed) return;
        gamepadDir = context.ReadValue<Vector2>().normalized;

    }

    private void TryPickup()
    {
        if (!isHolding)
        {
            Collider[] hits = Physics.OverlapSphere(pickupPoint.position, pickupRange, layer);

            if (hits.Length == 0)
            {
                return;
            }

            // Find closest collider
            Collider closest = null;
            float closestDist = Mathf.Infinity;

            foreach (Collider c in hits)
            {
                float dist = Vector3.Distance(pickupPoint.position, c.transform.position);
                if (dist < closestDist)
                {
                    closestDist = dist;
                    closest = c;
                }
            }

            if (closest == null) return;

            GameObject obj = closest.gameObject;
            heldObject = obj;

            EquipProp(obj);
        }
    }


    private void EquipProp(GameObject prop)
    {
        isHolding = true;
        prop.transform.position = pickupPoint.position;
        prop.transform.parent = pickupPoint;
        prop.GetComponent<Rigidbody>().isKinematic = true;
        prop.GetComponent<Collider>().enabled = false;
        heldObject.GetComponent<ThrowableProp>()?.OnGrab();
        ResetCollisions();
    }

    private void DropProp()
    {
        if (isHolding)
        {
            isHolding = false;
            heldObject.transform.parent = null;
            heldObject.GetComponent<Rigidbody>().isKinematic = false;
            heldObject.GetComponent<Collider>().enabled = true;
        }
    }

    private void ThrowProp()
    {
        if (!isHolding || heldObject == null) return;

        Rigidbody heldRb = heldObject.GetComponent<Rigidbody>();
        Collider heldCollider = heldObject.GetComponent<Collider>();

        isHolding = false;
        heldObject.transform.parent = null;
        heldRb.isKinematic = false;

        // Re-enable collider so physics works when thrown
        heldCollider.enabled = true;

        // Ignore ALL player colliders
        Collider[] playerColliders = GetComponentsInChildren<Collider>();
        foreach (Collider col in playerColliders)
        {
            Physics.IgnoreCollision(heldCollider, col, true);
        }

        // Throw force
        heldRb.AddForce(aimDir * throwForce, ForceMode.Impulse);
        heldRb.AddTorque(aimDir / throwForce, ForceMode.Impulse);
        AudioManager.PlaySound(SoundType.PUSH);
    }

    public void ResetCollisions()
    {
        Collider myCollider = heldObject.GetComponent<Collider>();

        foreach (GameObject player in GameObject.FindGameObjectsWithTag("Player"))
        {
            if (player == this.gameObject) continue; // skip myself

            foreach (Collider col in player.GetComponentsInChildren<Collider>())
            {
                Physics.IgnoreCollision(myCollider, col, false);
            }
        }

    }




}
