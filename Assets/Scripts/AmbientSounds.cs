using System.Collections;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class AmbientSounds : MonoBehaviour
{

    private void Start()
    {
        GetComponent<AudioSource>().Play();
    }



}
