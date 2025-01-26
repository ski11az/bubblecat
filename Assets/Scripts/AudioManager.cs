using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    [Header("Sources")]
    public AudioSource musicSource;
    public AudioSource sfxSource;
    public AudioSource sfxSource2;
    public AudioSource ambience;

    [Header("Clips")]
    public AudioClip blow;
    public AudioClip[] meowFall;
    public AudioClip[] meowLong;
    public AudioClip[] meowShort;
    public AudioClip[] breathe;
    public AudioClip[] hit;
    public AudioClip[] pop;
    public AudioClip[] squeak;
    public AudioClip[] horror;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayOneShot(AudioSource source, AudioClip clip, float volume)
    {
        source.PlayOneShot(clip, volume);
    }

    public void PlaySound(AudioSource source, AudioClip clip)
    {
        source.clip = clip;
        source.Play();
    }
}
