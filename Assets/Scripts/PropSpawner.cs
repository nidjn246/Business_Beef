using System.Collections;
using UnityEngine;

public class PropSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] props;
    [SerializeField] private GameObject[] valuables;
    [SerializeField] private float range = 5f;

    [SerializeField] private bool spawning = false;
    public float spawnCooldown = 2f;
    public float valuableSpawnCooldown = 5f;

    private void Start()
    {
        StartSpawning();
    }
    private void SpawnProp()
    {
        GameObject randomProp = props[Random.Range(0, props.Length)];
        Vector3 randomLocation = transform.position + new Vector3(Random.Range(-range, range), 0, 0);
        
        Instantiate(randomProp, randomLocation, Quaternion.identity);

    }

    private void SpawnValuable()
    {
        GameObject randomProp = valuables[Random.Range(0, props.Length)];
        Vector3 randomLocation = transform.position + new Vector3(Random.Range(-range / 2, range / 2), 0, 0);

        Instantiate(randomProp, randomLocation, Quaternion.identity);

    }

    public void StartSpawning()
    {
        spawning = true;
        StartCoroutine(SpawnPropsLoop());
        StartCoroutine(SpawnValuablesLoop());
    }
    public void StopSpawning()
    {
        spawning = false;
    }

    private IEnumerator SpawnPropsLoop()
    {
        while (spawning)
        {
            yield return new WaitForSeconds(spawnCooldown);
            SpawnProp();
        }
    }

    private IEnumerator SpawnValuablesLoop()
    {
        while (spawning)
        {
            yield return new WaitForSeconds(valuableSpawnCooldown);
            SpawnValuable();
        }
    }

}
