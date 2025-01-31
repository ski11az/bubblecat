using System.Collections;
using System.Collections.Generic;
using TMPro;

using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using DG.Tweening;

public class Settings : MonoBehaviour
{
    [Header("Audio")]
    public Slider masterSlider;
    public Slider musicSlider;
    public Slider sfxSlider;
    public AudioMixer _audio;
    [Header("Video")]
    public Toggle vsyncTog;
    public Toggle fullscreenTog;
    public TMP_Dropdown resolution;

    [Header("Other")]
    public RectTransform _transform;
    public CanvasGroup _cG;
    public CanvasGroup _cGMain;
    public PauseMenu pauseMenu;

    public Toggle transparentToggle;
    public Bubble regularBubble;
    public Bubble transparentBubble;
    public DangleCat cat;

    private AudioManager audioManager;
    public IEnumerator stopSound;
    private float animationDuration = 0.5f;

    private Vector2 originalSize;
    [SerializeField]private Vector2 mainSize;
    public bool isControls;
    void Awake()
    {

        mainSize = new Vector2(25,25);
        originalSize = _transform.localScale;
        
        if (!isControls)
        {
            fullscreenTog.isOn = Screen.fullScreen;

            if (QualitySettings.vSyncCount == 0)
            {
                vsyncTog.isOn = false;
            }
            else
            {
                vsyncTog.isOn = true;
            }
        }
   


    }

    private void OnEnable()
    {
        pauseMenu.OnObjectEnabled();
        _cGMain.blocksRaycasts = false;
        _cG.alpha = 1;
        _transform.localScale = mainSize;
        AudioManager.Instance.PlayOneShot(AudioManager.Instance.sfxSource, AudioManager.Instance.horror[1], 0.5f);
        _cG.DOFade(0, animationDuration).SetEase(Ease.InOutQuad);
        _transform.DOScale(originalSize, animationDuration)
                       .SetEase(Ease.InBack).SetUpdate(true).OnComplete(() =>
                       {
                           _cGMain.blocksRaycasts = true;
                           AudioManager.Instance.PlayOneShot(AudioManager.Instance.sfxSource, AudioManager.Instance.hit[1], 4);
                       }); ;

    }
    public void ToggleTransparentBubble()
    {
        if (transparentToggle.isOn)
            cat.bubblePrefab = transparentBubble;
        else
            cat.bubblePrefab = regularBubble;
    }
    public void CloseSettings()
    {
        if (gameObject.activeInHierarchy)
        {
            _cGMain.blocksRaycasts = false;
            pauseMenu.OnObjectEnabled();
            AudioManager.Instance.PlayOneShot(AudioManager.Instance.sfxSource, AudioManager.Instance.squeak[1], 0.2f);
            _cG.DOFade(1, animationDuration).SetEase(Ease.InOutQuad);
            _transform.DOScale(mainSize, animationDuration)
                           .SetEase(Ease.OutBack).SetUpdate(true).OnComplete(() =>
                           {
                               _cGMain.blocksRaycasts = true;
                               gameObject.SetActive(false);
                           }); ;
        }

    }
    public void ChangeMasterVolume()
    {
        _audio.SetFloat("VolumeMaster", masterSlider.value);
    }

    public void ChangeMusicVolume()
    {
        _audio.SetFloat("VolumeMusic", musicSlider.value);
    }

    public void ChangeSFXVolume()
    {
        _audio.SetFloat("VolumeSFX", sfxSlider.value);
    }
    public void PlayExample(bool music)
    {
        if (!music)
        {
            AudioManager.Instance.musicExample.Play();
            StartCoroutine(StopSoundAfterDelay(2)); 
        }
        else
        {
            AudioManager.Instance.PlayOneShot(AudioManager.Instance.sfxSource, AudioManager.Instance.meowShort[1], 1);
        }
    }

    private IEnumerator StopSoundAfterDelay(float delay)
    {
        yield return new WaitForSecondsRealtime(delay);
        AudioManager.Instance.musicExample.Stop();
    }

 
    public void ApplySettings()
    {
        Screen.fullScreen = fullscreenTog.isOn;
        if (fullscreenTog.isOn)
        {
            Screen.fullScreenMode = FullScreenMode.ExclusiveFullScreen;
            Screen.SetResolution(1920, 1080, true);
        }
        else
        {
            Screen.fullScreenMode = FullScreenMode.Windowed;
            Screen.SetResolution(1600, 900, false);
        }
        if (vsyncTog.isOn)
        {
            QualitySettings.vSyncCount = 1;
        }
        else
        {
            QualitySettings.vSyncCount = 0;
        }

        switch(resolution.value)
{
            default:
                Screen.SetResolution(1920, 1080, fullscreenTog.isOn);
                break;
            case 0:
                Screen.SetResolution(1920, 1080, fullscreenTog.isOn);
                break;
            case 1:
                Screen.SetResolution(1600, 900, fullscreenTog.isOn);
                break;
            case 2:
                Screen.SetResolution(1280, 720, fullscreenTog.isOn);
                break;
            case 3:
                Screen.SetResolution(640, 360, fullscreenTog.isOn);
                break;


        }
    }

}
