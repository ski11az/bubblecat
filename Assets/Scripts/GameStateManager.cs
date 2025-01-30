using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    private bool isFinished;
    public PauseMenu pauseMenuScript;
    public GameObject pauseMenu;
    // Start is called before the first frame update
    void Start()
    {
        isFinished = false;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
    }
    public void SetIntroFinishedTrue()
    {
        isFinished = true;
    }

    public bool IsIntroFinished()
    {
        return isFinished;
    }

    public void PauseGame()
    {
        if (!pauseMenu.gameObject.activeInHierarchy)
            pauseMenu.gameObject.SetActive(true);
        else
            pauseMenuScript.CloseMenu();
        
    }
}
