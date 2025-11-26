using Unity.Cinemachine;
using UnityEngine;

public class CameraMatch : MonoBehaviour
{
    private Transform group;
    [SerializeField] private CinemachineCamera cam;
    void Start()
    {
        group = FindFirstObjectByType<CinemachineTargetGroup>().transform;
        cam.Follow = group;
        Destroy(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
