using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseCanvas : MonoBehaviour
{
    [SerializeField] GameStopwatch timer;
    public Canvas targetCanvas;  // Assign the UI Canvas in the Inspector
    public MoveInDirection moveInDirection;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && targetCanvas.enabled)
        {
            HideCanvas();
            AudioManager.Instance.musicSource.Play();
            AudioManager.Instance.monsterSource.Play();
            AudioManager.Instance.animator.enabled = true;
            timer.StartStopwatch();
        }
    }

    void HideCanvas()
    {
        if (targetCanvas != null && targetCanvas.enabled)
        {
            targetCanvas.enabled = false;
        }
        else if (targetCanvas == null)
        {
            Debug.LogWarning("No canvas assigned to CloseCanvasOnSpace script!");
        }
    }


}