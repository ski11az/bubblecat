using UnityEngine;

public class MoveInDirection : MonoBehaviour
{
    [SerializeField] AnimationCurve moveSpeed;
    [SerializeField] Vector2 targetDirection = Vector2.up;
    [SerializeField] Transform camTransform;
    Rigidbody2D rb;
    private float spawnTime;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnEnable()
    {
        spawnTime = Time.time;
        transform.position= new Vector3(transform.position.x, camTransform.position.y - 20, transform.position.z);

    }
    // Update is called once per frame
    void FixedUpdate()
    {
        float elapsedTime = Time.time - spawnTime;
        Vector2 moveDelta = Time.deltaTime * moveSpeed.Evaluate(elapsedTime) * targetDirection;
        rb.MovePosition(transform.position + (Vector3)moveDelta);
    }
}
