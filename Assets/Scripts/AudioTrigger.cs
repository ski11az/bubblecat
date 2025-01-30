using UnityEngine;
using System.Collections;

public class AudioTrigger : MonoBehaviour
{
    public AudioSource audioSource; // Assign your AudioSource in the Inspector
    public MoveInDirection objectToActivate; // Assign the object to activate in the Inspector
    public float triggerTime = 9f; // Time in seconds to activate the object

    private void Start()
    {
       
    }
    public void StartWaitForTrigger()
    {
        StartCoroutine(WaitForTriggerTime());
    }
    private IEnumerator WaitForTriggerTime()
    {
        // Wait until the audio time reaches the trigger time
        while (audioSource.time < triggerTime)
        {
            yield return null;
        }

        // Activate the object
        objectToActivate.enabled = true;
    }
}