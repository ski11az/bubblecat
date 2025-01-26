using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LosingScript : MonoBehaviour
{
    [SerializeField] Canvas loseCanvas;

    private CalculateDistance _calcDistance;

    // Start is called before the first frame update
    void Start()
    {
        _calcDistance = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CalculateDistance>();
    }

    // Update is called once per frame
    void Update()
    {
        if(_calcDistance.GetDistance() == 0)
        {
            loseCanvas.enabled = true;
        }
    }
}
