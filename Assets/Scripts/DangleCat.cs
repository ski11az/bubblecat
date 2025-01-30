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

    private void OnEnable()
    {

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

        sittingCat.transform.position = transform.position;
        sittingCat.SetActive(true);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        col.enabled = false;
        gameObject.SetActive(false);
    }
}
