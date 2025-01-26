using UnityEngine;
using UnityEngine.Events;

public class Goal : MonoBehaviour
{
    [SerializeField] GameStopwatch stopwatch;

    public UnityEvent LevelStarted;
    public UnityEvent LevelCompleted;

    bool hasStarted = false;

    private void Update()
    {
        if (!hasStarted && Input.GetKeyDown(KeyCode.Space))
        {
            hasStarted = true;
            LevelStarted?.Invoke();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Level Completed");
            LevelCompleted?.Invoke();
        }
    }
}
