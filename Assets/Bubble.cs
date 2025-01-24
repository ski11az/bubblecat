using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Example : MonoBehaviour
{
    [SerializeField] Rigidbody2D[] bubble_bones;
    [SerializeField] GameObject bubble;
    [SerializeField] float scaleChange = 0.01f;

    private Joint[] joints;
    private Vector2[][] _connectedAnchor;
    private Vector2[][] _anchor;
    private float newScale;

    private void Start()
    {
        for (int i = 0; i < bubble_bones.Length; i++)
        {
            joints = bubble_bones[i].GetComponents<Joint>();
            for (int j = 0; j < joints.Length; j++)
            {
                _connectedAnchor[i][j] = joints[j].connectedAnchor;
                _anchor[i][j] = joints[j].anchor;
            }
        }

    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            newScale += scaleChange;

            for (int i = 0; i < bubble_bones.Length; i++)
            {
                // Force
                bubble_bones[i].AddForce(1.5f * Vector2.up);
            }
        }
        else
        {
            newScale -= scaleChange * 0.5f;
            newScale = Mathf.Max(0.13f, newScale);

            for (int i = 0; i < bubble_bones.Length; i++)
            {
                //bubble_bones[i].velocity = new Vector2(0, 0);
            }
        }

        bubble.transform.localScale = new Vector2(newScale, newScale);

        for (int i = 0; i < bubble_bones.Length; i++)
        {
            // Scale the bone
            //bubble_bones[i].transform.localScale = new Vector2(newScale, newScale);

            // Reset the joints
            joints = bubble_bones[i].GetComponents<Joint>();

            for (int j = 0; j < joints.Length; j++)
            {
                joints[j].connectedAnchor = _connectedAnchor[i][j];
                joints[j].anchor = _anchor[i][j];
            }
        }

        //bubble.GetComponent<Rigidbody2D>().AddForce(0.8f * Vector2.up);
    }
}