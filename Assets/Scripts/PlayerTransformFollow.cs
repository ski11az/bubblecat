using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTransformFollow : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] Transform target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        player.position = target.position;
    }

    public void SetTarget(Transform target)
    {
        this.target = target;
    }
}
