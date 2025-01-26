using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SittingCat : MonoBehaviour
{
    [SerializeField] GameObject dangleCat;
    [SerializeField] CinemachineVirtualCamera cinemachine;

    private void Start()
    {
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            gameObject.SetActive(false);
        }
    }

    private void OnEnable()
    {
        cinemachine.Follow = transform;
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CalculateDistance>().SetTarget(2, this.gameObject);
        int random = Random.Range(0, AudioManager.Instance.meowShort.Length);
        AudioManager.Instance.PlayOneShot(AudioManager.Instance.sfxSource, AudioManager.Instance.meowShort[random], 1);
    }

    private void OnDisable()
    {
        dangleCat.transform.position = transform.position;
        dangleCat.SetActive(true);
    }
}
