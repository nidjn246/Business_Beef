using UnityEngine;

public class BecomeTransparent : MonoBehaviour
{
    public Shader toon;
    [SerializeField] private Material objectsMaterial;
    [Range(0f, 1f)]
    [SerializeField] private float transparency;

    private void Start()
    {
        toon = Shader.Find("Toon");
    }

    private void OnTriggerStay(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            SetTransparency(0.3f); // lower value = more transparent
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            SetTransparency(1f); // back to normal
        }
    }

    private void SetTransparency(float alpha)
    {
        objectsMaterial.shader = toon;
    }
}
