using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundOnCollision : MonoBehaviour
{
    // Start is called before the first frame update
    AudioManager aM;
    private void Start()
    {
        aM = AudioManager.Instance;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        int random = Random.Range(0, aM.squeak.Length);
        AudioManager.Instance.PlaySound(aM.sfxSource, aM.squeak[random]);
    }
}
