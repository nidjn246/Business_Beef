using UnityEngine;

public class VentilatorTurn : MonoBehaviour
{
    [SerializeField] private float turnSpeed;

    private void Update()
    {
        transform.Rotate(0, 0, turnSpeed * Time.deltaTime);
    }
}
