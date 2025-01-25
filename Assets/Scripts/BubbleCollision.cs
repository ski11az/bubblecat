using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleCollision : MonoBehaviour
{
    [SerializeField] GameObject bubble;
    [SerializeField] GameObject pop;
    [SerializeField] float scaleChange = 0.01f; // Amount to increase per update

    GameObject popAnimation;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        PopBubble();
    }

    void PopBubble() {
        popAnimation = Instantiate(pop, this.transform.position, Quaternion.identity);
        popAnimation.transform.localScale = bubble.transform.localScale;
        Destroy(bubble);
    }
}