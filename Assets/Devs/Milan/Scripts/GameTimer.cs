using UnityEngine;

public class GameTimer : MonoBehaviour
{
    [SerializeField] float TimeLeft;
    [SerializeField] float maxTime = 60f;
    void Start()
    {
        TimeLeft = maxTime;
    }
    void Update()
    {
        TimeLeft -= Time.deltaTime;
    }
}
