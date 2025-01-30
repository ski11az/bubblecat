using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    [SerializeField] Rigidbody2D[] bubble_bones;
    [SerializeField] GameObject bubble;
    [SerializeField] float maxScale = 0.3f;     // Max size for the bubble, original scale 0.13f
    [SerializeField] float scaleChange = 0.01f; // Amount to increase per update
    [SerializeField] float riseStrength = 1.5f;
    [SerializeField] float riseVelocity = 10.0f;
    [SerializeField] float steerStrength = 2.0f;

    [SerializeField] Rigidbody2D coreBone;
    [SerializeField] public Transform pivot;

    private Joint[] _joints;
    private readonly Vector2[][] _connectedAnchor;
    private readonly Vector2[][] _anchor;
    private AudioManager audioManager;
    private bool playingBlowSound;
    private void Start()
    {

        audioManager = AudioManager.Instance;
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

    private void Update()
    {
       

        if (Input.GetKey(KeyCode.Space))
        {
            IncreaseBubbleSize();
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            playingBlowSound = false;
            int random = Random.Range(0, audioManager.breathe.Length);
            Invoke("StopBlowSound", 0.1f);
            audioManager.PlayOneShot(audioManager.sfxSource, audioManager.breathe[random], 0.1f);
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
    void StopBlowSound()
    {
        audioManager.sfxSource2.Stop();
    }
    void FixedUpdate()
    {
        float targetVelocity = bubble.transform.localScale.x * riseVelocity;
        float velocityDelta = targetVelocity - coreBone.velocity.y;
        AddForceToJoints(riseStrength * velocityDelta * Vector2.up);

        float horizontalMove = Input.GetAxisRaw("Horizontal");
        AddForceToJoints(steerStrength * horizontalMove * Vector2.right);
    }

    void IncreaseBubbleSize() {
        if (!playingBlowSound)
        {
            playingBlowSound = true;
            audioManager.PlaySound(audioManager.sfxSource2, audioManager.blow);
        }
       
        Vector3 newScale = bubble.transform.localScale + Time.deltaTime * new Vector3(scaleChange, scaleChange, scaleChange);

        if (newScale.x < maxScale)
        {
            SetBubbleScale(newScale);
            coreBone.GetComponent<CircleCollider2D>().radius += Time.deltaTime * scaleChange;
        }
        else
        {
            playingBlowSound = false;
            GetComponentInChildren<BubbleCollision>().PopBubble();
        }
    }

    public void SetBubbleScale(Vector3 newScale)
    {
        float scaleFactor = newScale.x / bubble.transform.localScale.x;
        Vector3 offset = pivot.position - bubble.transform.position;

        bubble.transform.localScale = newScale;

        // Counter translation caused by scaling
        for (int i = 0; i < bubble_bones.Length; i++)
        {
            bubble_bones[i].transform.position = bubble_bones[i].transform.position - (scaleFactor - 1.0f) * offset;
        }
    }

    void AddUpwardsForceToJoints() {
        if(bubble.transform.localScale.x < maxScale) {
            AddForceToJoints(riseStrength * Vector2.up);
        }
    }

    void AddForceToJoints(Vector2 force)
    {
        for (int i = 0; i < bubble_bones.Length; i++)
        {
            bubble_bones[i].AddForce(force);
        }
    }
}