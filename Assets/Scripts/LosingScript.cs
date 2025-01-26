using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LosingScript : MonoBehaviour
{
    [SerializeField] GameObject loseCanvas;

    public void EnableLosingScreen()
    {
        loseCanvas.SetActive(true);
    }

    public void DisableLosingScreen()
    {
        loseCanvas.SetActive(false);
    }
}
