using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BubbleCollision : MonoBehaviour
{
    [SerializeField] GameObject bubble;
    [SerializeField] GameObject pop;

    GameObject popAnimation;

    public UnityEvent BubblePopped;

    DangleCat dangleCat;

    private void Start()
    {
        dangleCat = FindObjectOfType<DangleCat>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        PopBubble();
    }

    void PopBubble() {
        popAnimation = Instantiate(pop, this.transform.position, Quaternion.identity);
        popAnimation.transform.localScale = bubble.transform.localScale;
        BubblePopped.Invoke();

        dangleCat.gameObject.GetComponent<PlayerTransformFollow>().enabled = false;
        dangleCat.gameObject.GetComponent<HingeJoint2D>().enabled = false;
        Rigidbody2D catRb = dangleCat.gameObject.GetComponent<Rigidbody2D>();
        catRb.velocity = new Vector2(catRb.velocity.x, 0.0f);
        dangleCat.GetComponent<CircleCollider2D>().enabled = true;

        Destroy(bubble);
    }
}