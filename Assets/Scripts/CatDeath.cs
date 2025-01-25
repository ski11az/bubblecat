using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CatDeath : MonoBehaviour
{
    public UnityEvent CatDied;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Monster"))
        {
            CatDied.Invoke();
        }
    }

    public void AnnounceDeath()
    {
        Debug.Log("Cat died.");
    }
}
