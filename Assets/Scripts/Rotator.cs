using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] AnimationCurve rotationSpeed;

    Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float rotateDelta = Time.deltaTime * rotationSpeed.Evaluate(Time.time);
        rb.MoveRotation(rb.rotation + rotateDelta);
    }
}
