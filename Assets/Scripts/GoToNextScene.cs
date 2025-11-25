using UnityEngine;

public class GoToNextScene : MonoBehaviour
{
    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
}
