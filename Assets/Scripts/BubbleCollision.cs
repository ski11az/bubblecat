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
    AudioManager audioManager;
    private void Start()
    {
        audioManager = AudioManager.Instance;
        dangleCat = FindObjectOfType<DangleCat>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(!collision.gameObject.CompareTag("Cave"))
        PopBubble();
    }

    public void PopBubble() {
        Debug.Log("Bubble popped");
        int random = Random.Range(0, audioManager.pop.Length);
        audioManager.PlaySound(audioManager.sfxSource, audioManager.pop[random]);
        audioManager.PlayOneShot(audioManager.sfxSource, audioManager.meowFall[0],1);
        popAnimation = Instantiate(pop, this.transform.position, Quaternion.identity);
        popAnimation.transform.localScale = bubble.transform.localScale;
        BubblePopped.Invoke();

        dangleCat.gameObject.GetComponent<PlayerTransformFollow>().enabled = false;
        dangleCat.gameObject.GetComponent<HingeJoint2D>().enabled = false;
        Rigidbody2D catRb = dangleCat.gameObject.GetComponent<Rigidbody2D>();
        catRb.velocity = new Vector2(0.0f, 0.0f);
        dangleCat.GetComponent<CircleCollider2D>().enabled = true;

        Destroy(bubble);
    }
}