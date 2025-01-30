using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseCanvas : MonoBehaviour
{
    [SerializeField] GameStopwatch timer;
    [SerializeField] GameObject GameStateManager;
    public HowToPlayText howToPlayText;
    public Canvas targetCanvas;  // Assign the UI Canvas in the Inspector
    public MoveInDirection moveInDirection;

    private GameStateManager gsm;

    private void Start()
    {
        gsm = GameStateManager.GetComponent<GameStateManager>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && targetCanvas.enabled && gsm.IsIntroFinished())
        {
            HideCanvas();
            howToPlayText.ShowText();
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