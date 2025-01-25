using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseCanvas : MonoBehaviour
{
    public Canvas targetCanvas;  // Assign the UI Canvas in the Inspector

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            HideCanvas();
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