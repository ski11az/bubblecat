using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Example : MonoBehaviour
{
    [SerializeField] Rigidbody2D[] bubble_rbs;
    [SerializeField] float scaleChange = 0.01f;
    private float newScale;

    void Start()
    {
        for (int i = 0; i < bubble_rbs.Length; i++) {
            bubble_rbs[i] = bubble_rbs[i].GetComponent<Rigidbody2D>();
        }
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            newScale += scaleChange;
        }
        else
        {
            newScale -= scaleChange * 0.5f;
            newScale = Mathf.Max(1, newScale);
        }

        for (int i = 0; i < bubble_rbs.Length; i++)
        {
            // Scale
            bubble_rbs[i].transform.localScale = new Vector2(newScale, newScale);

            // Force
            bubble_rbs[i].AddForce(0.5f * newScale * bubble_rbs[i].transform.up);
        }
    }
}