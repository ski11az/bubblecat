using UnityEngine;

public class MoveInDirection : MonoBehaviour
{
    [SerializeField] AnimationCurve moveSpeed;
    [SerializeField] Vector2 targetDirection = Vector2.up;

    Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 moveDelta = Time.deltaTime * moveSpeed.Evaluate(Time.time) * targetDirection;
        rb.MovePosition(transform.position + (Vector3)moveDelta);
    }
}
