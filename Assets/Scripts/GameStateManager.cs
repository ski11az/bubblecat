using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    private bool isFinished;

    // Start is called before the first frame update
    void Start()
    {
        isFinished = false;
    }

    public void SetIntroFinishedTrue()
    {
        isFinished = true;
    }

    public bool IsIntroFinished()
    {
        return isFinished;
    }
}
