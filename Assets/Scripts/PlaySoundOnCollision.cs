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
        if (!aM.sfxSource2.isPlaying)
        {
            int random = Random.Range(0, aM.squeak.Length);
            AudioManager.Instance.PlaySound(aM.sfxSource2, aM.squeak[random]);
        }

    }


}
