using UnityEngine;

public class MoveToPosition : MonoBehaviour
{
    [SerializeField]
    Transform target;

    [SerializeField, Tooltip("Should have values in the range [0,1]")]
    AnimationCurve movement;

    [SerializeField]
    float speed = 1;
    
    Vector3 startPosition;
    Vector3 targetPosition;
    Vector3 moveVector;

    Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        startPosition = transform.position;
        targetPosition = target.position;
        moveVector = targetPosition - startPosition;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 newPosition = startPosition + moveVector * movement.Evaluate(Time.time * speed);
        rb.MovePosition(newPosition);
    }
}
