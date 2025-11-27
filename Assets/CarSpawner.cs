using System.Collections;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    public float carSpawnInterval = 15f;
    [SerializeField] private GameObject carPrefab;
    [SerializeField] private float lifetime = 10f;

    private void Start()
    {
        StartCoroutine(SpawnCar());
    }
    public IEnumerator SpawnCar()
    {
        while (true)
        {
            yield return new WaitForSeconds(carSpawnInterval);
            GameObject car = Instantiate(carPrefab, gameObject.transform);
            Destroy(car, lifetime);
        }
        
    }
}
