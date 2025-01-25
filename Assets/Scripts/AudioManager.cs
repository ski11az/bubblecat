using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    [Header("Sources")]
    public AudioSource musicSource;
    public AudioSource sfxSource;

    [Header("Sources")]
    public AudioClip blow;
    public AudioClip[] meowFall;
    public AudioClip[] meowLong;
    public AudioClip[] meowShort;
    public AudioClip[] breathe;
    public AudioClip[] hit;
    public AudioClip[] pop;
    public AudioClip[] squeak;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            musicSource.Play();
        }
        else if (Input.GetKeyDown(KeyCode.O))
        {
            musicSource.Pause();
        }
    }

    public void PlayOneShot(AudioSource source, AudioClip clip)
    {
        source.PlayOneShot(clip);
    }

    public void PlaySound(AudioSource source, AudioClip clip)
    {
        source.clip = clip;
        source.Play();
    }
}
