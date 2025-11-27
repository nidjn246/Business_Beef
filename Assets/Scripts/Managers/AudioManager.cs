using System;
using UnityEngine;

public enum SoundType
{
    FOOTSTEPS,
    PUSH,
    JUMP,
    HIT,
    COINDROP,
    CRATEBREAK,
    METALPIPE,
    GUNSHOT,
    CASHREGISTER,
    GRUNT,
    TIMETICKING,
    CATMEOW,
    CATSCREAM,
    BASEBALLBAT,
    EXPLOSION,
    PIANOBREAK,
    TRAFFICCONE,
    SEWERGRATE,
    CARHONK,
    CARHIT,
}

[RequireComponent(typeof(AudioSource)), ExecuteInEditMode]
public class AudioManager : MonoBehaviour
{
    [SerializeField] private SoundList[] soundList;
    private static AudioManager instance;
    private AudioSource audioSource;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

#if UNITY_EDITOR
    private void OnEnable()
    {
        string[] names = Enum.GetNames(typeof(SoundType));
        Array.Resize(ref soundList, names.Length);

        for (int i = 0; i < soundList.Length; i++)
        {
            soundList[i].name = names[i];
        }
    }
#endif

    public static void PlaySound(SoundType sound, bool doPitchShift = true, float volume = 1)
    {
        if (instance == null || instance.audioSource == null) return;

        AudioClip[] clips = instance.soundList[(int)sound].Sounds;
        if (clips == null || clips.Length == 0) return;

        AudioClip randomClip = clips[UnityEngine.Random.Range(0, clips.Length)];

        if (doPitchShift)
            instance.audioSource.pitch = UnityEngine.Random.Range(0.9f, 1.1f);

        instance.audioSource.PlayOneShot(randomClip, volume);
    }


    [Serializable]
    public struct SoundList
    {
        public AudioClip[] Sounds { get => sounds; }
        [HideInInspector] public string name;
        [SerializeField] private AudioClip[] sounds;
    }
}