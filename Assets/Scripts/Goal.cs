using Cinemachine;
using UnityEngine;
using UnityEngine.Events;

public class Goal : MonoBehaviour
{
    [SerializeField] GameStopwatch stopwatch;
    [SerializeField] GameObject GameStateManager;
    [SerializeField] GameObject winPanel;
    [SerializeField] CinemachineVirtualCamera cam;
    public UnityEvent LevelStarted;
    public UnityEvent LevelCompleted;

    bool hasStarted = false;

    private GameStateManager gsm;

    private void Start()
    {
        gsm = GameStateManager.GetComponent<GameStateManager>();
    }

    private void Update()
    {
        if (!hasStarted && Input.GetKeyDown(KeyCode.Space) && gsm.IsIntroFinished())
        {
            hasStarted = true;
            LevelStarted?.Invoke();
            
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            cam.enabled = false;
            Debug.Log("Level Completed");
            LevelCompleted?.Invoke();
        }
    }

    public void PlayWinAudio()
    {
        winPanel.SetActive(true);
        AudioManager.Instance.PlaySound(
            AudioManager.Instance.musicSource,
            AudioManager.Instance.winSource);
    }
}
