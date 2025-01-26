using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinAnim : MonoBehaviour
{
    public GameObject win1, win2, win3, win4;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Win");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator Win()
    {
        AudioManager.Instance.PlayOneShot(AudioManager.Instance.sfxSource, AudioManager.Instance.pop[Random.Range(0, 1)], 1);
        win1.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        AudioManager.Instance.PlayOneShot(AudioManager.Instance.sfxSource, AudioManager.Instance.pop[Random.Range(0, 1)], 1);
        win2.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        AudioManager.Instance.PlayOneShot(AudioManager.Instance.sfxSource, AudioManager.Instance.pop[Random.Range(0, 1)], 1);
        win3.SetActive(true);
        yield return new WaitForSeconds(0.8f);
        AudioManager.Instance.PlayOneShot(AudioManager.Instance.sfxSource, AudioManager.Instance.pop[Random.Range(0, 1)], 1);
        win4.SetActive(true);
    }
}
