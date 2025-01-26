using UnityEngine;
using UnityEngine.Events;

public class Monster : MonoBehaviour
{
    public UnityEvent LevelFailed;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Level Failed!");
            LevelFailed?.Invoke();
        }
    }

    public void StopMonster() {
        gameObject.GetComponent<MoveInDirection>().enabled = false;
    }
}
