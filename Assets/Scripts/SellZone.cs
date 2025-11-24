using System.Collections;
using UnityEngine;

public class SellZone : MonoBehaviour
{
    [SerializeField] private bool selling;
    [SerializeField] private float currentTime = 0f;
    [SerializeField] private float timeToSell = 5f;

    private Coroutine sellingCoroutine;

    private void OnTriggerEnter(Collider collider)
    {
        // Only start selling when the CapsuleCollider enters
        if (!collider.TryGetComponent<CapsuleCollider>(out _)) return;

        Transform inventory = collider.transform.Find("Inventory");

        if (inventory != null && inventory.childCount > 0)
        {
            GameObject valuable = inventory.GetChild(0).gameObject;

            if (sellingCoroutine == null)  // Prevent double coroutine
            {
                selling = true;
                sellingCoroutine = StartCoroutine(StartSelling(valuable));
            }
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        // Only stop selling when the CapsuleCollider exits
        if (!collider.TryGetComponent<CapsuleCollider>(out _)) return;

        selling = false;

        if (sellingCoroutine != null)
        {
            StopCoroutine(sellingCoroutine);
            sellingCoroutine = null;
        }

        currentTime = 0f;
    }

    private IEnumerator StartSelling(GameObject valuable)
    {
        currentTime = 0f;

        while (selling)
        {
            currentTime += Time.deltaTime;

            if (currentTime >= timeToSell)
            {
                valuable.GetComponent<ValuableProp>().OnSell();
                valuable.GetComponent<ValuableProp>().RestoreSpeed();
                valuable.transform.parent.parent.GetComponent<Pickup>().isHolding = false;
                valuable.transform.parent = null;
                selling = false;
                Destroy(valuable);
                AudioManager.PlaySound(SoundType.CASHREGISTER, true, 0.5f);
                break;
            }

            yield return null;
        }

        sellingCoroutine = null;
    }

}
