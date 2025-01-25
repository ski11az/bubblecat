using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SittingCat : MonoBehaviour
{
    [SerializeField] GameObject dangleCat;
    [SerializeField] CinemachineVirtualCamera cinemachine;

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
    }

    private void OnDisable()
    {
        dangleCat.transform.position = transform.position;
        dangleCat.SetActive(true);
    }
}
