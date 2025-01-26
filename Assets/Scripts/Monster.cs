using UnityEngine;
using UnityEngine.Events;

public class Monster : MonoBehaviour
{
    public UnityEvent LevelFailed;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Level Failed!");
        LevelFailed?.Invoke();
    }
}
