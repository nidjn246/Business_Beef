using UnityEngine;

public class BecomeTransparent : MonoBehaviour
{
    public Material pawnShop;
    public Material pawnShopTransparent;

    public Material reclame;
    public Material reclameTransparent;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            foreach (Transform child in transform)
            {
                if (child.CompareTag("PawnShop"))
                {
                    var mr = child.GetComponent<MeshRenderer>();
                    if (mr != null)
                        mr.material = pawnShopTransparent;
                }

                if (child.CompareTag("Reclame"))
                {
                    var mr = child.GetComponent<MeshRenderer>();
                    if (mr != null)
                        mr.material = reclameTransparent;
                }
            }
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            foreach (Transform child in transform)
            {
                if (child.CompareTag("PawnShop"))
                {
                    var mr = child.GetComponent<MeshRenderer>();
                    if (mr != null)
                        mr.material = pawnShop;
                }

                if (child.CompareTag("Reclame"))
                {
                    var mr = child.GetComponent<MeshRenderer>();
                    if (mr != null)
                        mr.material = reclame;
                }
            }
        }
    }
}
