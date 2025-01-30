using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangleCat : MonoBehaviour
{
    [SerializeField] Bubble bubblePrefab;
    [SerializeField] HingeJoint2D hinge;
    [SerializeField] PlayerTransformFollow follow;
    [SerializeField] CircleCollider2D col;
   
    [SerializeField] GameObject sittingCat;
    [SerializeField] CinemachineVirtualCamera cinemachine;
    private Vector3 startRotation;
    private void Start()
    {
        startRotation = new Vector3(transform.rotation.x,transform.rotation.y,transform.rotation.z);
    }
    private void OnEnable()
    {
        transform.eulerAngles = new Vector3(startRotation.x, startRotation.y, startRotation.z);
        Bubble bubble = Instantiate(bubblePrefab, transform.position, Quaternion.identity);

        follow.enabled = true;
        follow.SetTarget(bubble.pivot);

        hinge.enabled = true;
        hinge.connectedBody = bubble.pivot.GetComponent<Rigidbody2D>();

        cinemachine.Follow = transform;
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CalculateDistance>().SetTarget(2, this.gameObject);
    }

    private void OnDisable()
    {
        if (sittingCat != null)
        {
            sittingCat.transform.position = transform.position;

            sittingCat.SetActive(true);
        }
           
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        col.enabled = false;
        gameObject.SetActive(false);
    }
}
