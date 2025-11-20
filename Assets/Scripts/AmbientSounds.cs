using UnityEngine;

public class AmbientSounds : MonoBehaviour
{

    private void Start()
    {
        GetComponent<AudioSource>().Play();
    }

}
