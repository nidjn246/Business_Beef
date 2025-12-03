using UnityEngine;
using UnityEngine.InputSystem;

public class EmoteSystem : MonoBehaviour
{
    [SerializeField] private GameObject[] particles;

    public void OnEmote1(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            SpawnParticles(0);
        }
    }

    public void OnEmote2(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            SpawnParticles(1);
        }
    }

    private void SpawnParticles(int arrayIndex)
    {
        GameObject particle = Instantiate(particles[arrayIndex], transform.position, particles[arrayIndex].gameObject.transform.rotation);
        Destroy(particle, 5f);
    }
}
