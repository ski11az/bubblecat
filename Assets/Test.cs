using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.VisualScripting.Metadata;

public class Test : MonoBehaviour
{
    Transform[] children;
    [SerializeField] private Vector3[] _connectedAnchor;
    [SerializeField]  private Vector3[] _anchor;
    [SerializeField] private SpringJoint2D[] _springJoints;
    SpringJoint2D[] springjoints;

    [SerializeField] Rigidbody2D[] rbs;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       
        if (Input.GetKey(KeyCode.Space))
        {
           
            foreach (Rigidbody2D rb in rbs)
            {
                rb.AddForce(Vector2.up);
            }
        }


    }
}
