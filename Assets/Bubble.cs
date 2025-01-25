using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Example : MonoBehaviour
{
    [SerializeField] Rigidbody2D[] bubble_bones;
    [SerializeField] GameObject bubble;
    [SerializeField] float maxScale = 0.3f;     // Max size for the bubble, original scale 0.13f
    [SerializeField] float scaleChange = 0.01f; // Amount to increase per update

    private Joint[] _joints;
    private readonly Vector2[][] _connectedAnchor;
    private readonly Vector2[][] _anchor;

    private void Start()
    {
        // Get and store connectedAnchors and anchors
        for (int i = 0; i < bubble_bones.Length; i++)
        {
            _joints = bubble_bones[i].GetComponents<Joint>();
            for (int j = 0; j < _joints.Length; j++)
            {
                _connectedAnchor[i][j] = _joints[j].connectedAnchor;
                _anchor[i][j] = _joints[j].anchor;
            }
        }

    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            IncreaseBubbleSize();
            AddUpwardsForceToJoints();
        }

        for (int i = 0; i < bubble_bones.Length; i++)
        {
            // Reset the joints
            _joints = bubble_bones[i].GetComponents<Joint>();

            for (int j = 0; j < _joints.Length; j++)
            {
                _joints[j].connectedAnchor = _connectedAnchor[i][j];
                _joints[j].anchor = _anchor[i][j];
            }
        }
    }

    void IncreaseBubbleSize() {
        Vector3 newScale = bubble.transform.localScale + new Vector3(scaleChange, scaleChange, scaleChange);

        if (newScale.x < maxScale) {
            bubble.transform.localScale = newScale;
        }
    }

    void AddUpwardsForceToJoints() {
        if(bubble.transform.localScale.x < maxScale) {
            for (int i = 0; i < bubble_bones.Length; i++) {
                bubble_bones[i].AddForce(1.5f * Vector2.up);
            }
        }
    }
}