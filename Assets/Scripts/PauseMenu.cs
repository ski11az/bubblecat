using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
public class PauseMenu : MonoBehaviour
{
    [Header("PauseMenu")]
    public CanvasGroup pauseMenuCanvasGroup;
    public RectTransform pauseMenuWindow;
    public float animationDuration = 0.5f;
    public Ease easeType = Ease.OutBack;
    private Vector2 originalSize;

    [Header("Buttons")]
    public Transform button;
    private Vector3 buttonOriginalSize;
    private AudioManager audioManager;

    public bool isPause;
    public GameObject[] menusToCloseOnExit;
    public GameObject menuObject;
    void Awake()
    {
        audioManager = AudioManager.Instance;
        if(isPause)
        originalSize = pauseMenuWindow.sizeDelta;
    }
    private void OnEnable()
    {
        if (isPause)
        {
            AudioManager.Instance.musicSource.Pause();
            AudioManager.Instance.monsterSource.Pause();
            foreach (GameObject menu in menusToCloseOnExit)
            {
                menu.SetActive(false);
            }
            menuObject.SetActive(true);
            Debug.Log("Pause Menu Enabled");
            // Reset the pause menu size to zero and alpha to 0
            pauseMenuWindow.sizeDelta = Vector2.zero;

            audioManager.PlayOneShot(audioManager.sfxSource, audioManager.meowShort[5], 0.5f);
            // Animate the pause menu to its original size and fade in
            pauseMenuWindow.DOSizeDelta(originalSize, animationDuration)
                           .SetEase(easeType).SetUpdate(true);
            Time.timeScale = 0;
        }

    }
    public void CloseMenu()
    {
        AudioManager.Instance.musicSource.Play();
        AudioManager.Instance.monsterSource.Play();
        audioManager.PlayOneShot(audioManager.sfxSource, audioManager.meowShort[4], 0.5f);
        pauseMenuWindow.DOSizeDelta(Vector2.zero, animationDuration)
                       .SetEase(easeType).SetUpdate(true).OnComplete(() =>
                       {
                           Time.timeScale = 1;
                           gameObject.SetActive(false);
                       }); ;
      
    }

    public void ResetGame()
    {
        SceneManager.LoadScene(0);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    public void OnObjectEnabled()
    {
        if (button != null)
        {
            // Kill any existing tweens on the button
            button.DOKill();

            // Immediately reset the button's scale to its original size
            button.localScale = buttonOriginalSize;

            // Clear the button reference
            button = null;
        }
    }
    public void ChangeButtonSize(BaseEventData eventData)
    {
        PointerEventData pointerEventData = eventData as PointerEventData;

        if (pointerEventData != null)
        {
            GameObject hoveredButton = pointerEventData.pointerEnter;

            if (hoveredButton != null)
            {
                button = hoveredButton.transform;
                buttonOriginalSize = button.localScale;

                // Kill any existing tweens on the button
                button.DOKill();

                // Immediately reset the button's scale to its original size
                button.localScale = buttonOriginalSize;
                int random = Random.Range(0, audioManager.pop.Length);
                audioManager.PlayOneShot(audioManager.sfxSource, audioManager.pop[random], 0.5f);
                button.DOScale(buttonOriginalSize * 1.2f, 0.2f).SetEase(Ease.OutBack).SetUpdate(true);

            }
        }
    }

    public void ResetButtonSize(BaseEventData eventData)
    {
        PointerEventData pointerEventData = eventData as PointerEventData;

        if (pointerEventData != null)
        {
            GameObject exitedButton = pointerEventData.pointerEnter;

            if (exitedButton != null && button != null)
            {
                // Kill any existing tweens on the button
                button.DOKill();

                // Immediately reset the button's scale to its original size
                button.localScale = buttonOriginalSize;
                button.DOScale(buttonOriginalSize, 0.1f).SetEase(Ease.InOutQuad).SetUpdate(true);
            }
        }
    }
}
