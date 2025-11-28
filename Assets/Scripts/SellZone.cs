using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class SellZone : MonoBehaviour
{
    [SerializeField] private bool selling;
    [SerializeField] private float currentTime = 0f;
    [SerializeField] private float timeToSell = 5f;
    public string team;

    private Canvas ui;
    [SerializeField] private Image progressBar;
    [SerializeField] private GameObject sellParticles;

    private Coroutine sellingCoroutine;

    private void Start()
    {
        ui = GetComponentInChildren<Canvas>();
        ui.enabled = false;
    }

    private void OnTriggerEnter(Collider collider)
    {
        // Only start selling when the CapsuleCollider enters
        if (!collider.TryGetComponent<CapsuleCollider>(out _)) return;


        Transform inventory = collider.transform.Find("Inventory");

        if (inventory != null && inventory.childCount > 0)
        {
            GameObject valuable = inventory.GetChild(0).gameObject;

            if (sellingCoroutine == null && valuable.CompareTag("Valuable"))  // Prevent double coroutine
            {
                selling = true;
                sellingCoroutine = StartCoroutine(StartSelling(valuable));
                ui.enabled = true;
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
            ui.enabled = false;
        }

        currentTime = 0f;
    }

    private IEnumerator StartSelling(GameObject valuable)
    {
        currentTime = 0f;

        while (selling)
        {
            currentTime += Time.deltaTime;
            progressBar.fillAmount = currentTime / timeToSell;

            if (valuable.transform.parent == null)
            {
                ui.enabled = false;
                selling = false;
                yield return null;
            }

            if (currentTime >= timeToSell)
            {
                valuable.GetComponent<ValuableProp>().OnSell();
                valuable.GetComponent<ValuableProp>().RestoreSpeed();
                valuable.transform.parent.parent.GetComponent<Pickup>().isHolding = false;
                valuable.transform.parent = null;
                selling = false;
                Sell();
                Destroy(valuable);

                break;
            }

            yield return null;
        }

        sellingCoroutine = null;
    }

    private void Sell()
    {
        AudioManager.PlaySound(SoundType.CASHREGISTER, true, 0.5f);
        ui.enabled = false;

        GameObject particles = Instantiate(sellParticles, gameObject.transform.position, Quaternion.identity);
        Destroy(particles, 5f);

    }

    

}
