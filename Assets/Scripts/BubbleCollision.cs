using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleCollision : MonoBehaviour
{
    [SerializeField] GameObject bubble;
    [SerializeField] Rigidbody2D[] bubble_bones;
    [SerializeField] GameObject pop;
    [SerializeField] float scaleChange = 0.01f; // Amount to increase per update

    private void OnCollisionEnter2D(Collision2D collision)
    {
        PopBubble();
    }

    void PopBubble() {
        Instantiate(pop, this.transform.position, Quaternion.identity);
        StartCoroutine(ShrinkBubble());
    }

    IEnumerator ShrinkBubble()
    {
        while (bubble.transform.localScale.x > 0)
        {
            Vector3 newScale = bubble.transform.localScale - new Vector3(scaleChange, scaleChange, scaleChange) * Time.deltaTime;
            bubble.GetComponent<Bubble>().SetBubbleScale(newScale);

            yield return null;
        }

        bubble.GetComponent<Bubble>().SetBubbleScale(new Vector3(0.01f, 0.01f, 0.01f));
        bubble.SetActive(false);
    }
}