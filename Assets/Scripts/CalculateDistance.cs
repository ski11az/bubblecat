using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalculateDistance : MonoBehaviour
{
    [SerializeField] GameObject point1_gameobject;
    [SerializeField] GameObject point2_gameobject;
    [SerializeField] float baseDistance; // Ideal distance when "distance"-value should be 1 (no effects applied)

    private float _distance;

    // Update is called once per frame
    void Update()
    {
        _distance = GetDistance();
        Debug.Log(_distance);
    }

    public float GetDistance() { // Returns distance as a value between 0-1
        if (point1_gameobject && point2_gameobject)
        {
            return Vector3.Distance(point1_gameobject.transform.position, point2_gameobject.transform.position) / baseDistance;
        }

        else return -1;
    }
}
