using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextFallInEffect : MonoBehaviour
{
    private float animationDuration = 0.5f;
    private Vector3 mainSize;
    private Vector3 originalSize;
    public RectTransform _transform;
    // Start is called before the first frame update
    void Start()
    {
        mainSize = new Vector2(200, 200);
        originalSize = _transform.localScale;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnEnable()
    {
        mainSize = new Vector2(55, 55);
        originalSize = _transform.localScale;
        TextAppear();
    }
    public void TextAppear()
    {

        _transform.localScale = mainSize;
       // AudioManager.Instance.PlayOneShot(AudioManager.Instance.sfxSource, AudioManager.Instance.squeak[1], 0.5f);
        _transform.DOScale(originalSize, animationDuration)
                       .SetEase(Ease.InBack).SetUpdate(true).OnComplete(() =>
                       {
                           AudioManager.Instance.PlayOneShot(AudioManager.Instance.sfxSource, AudioManager.Instance.hit[1], 4);
                       }); ;
    }
    public void TextDissapear()
    {
        AudioManager.Instance.PlayOneShot(AudioManager.Instance.sfxSource, AudioManager.Instance.squeak[1], 0.2f);

        _transform.DOScale(mainSize, animationDuration)
                       .SetEase(Ease.OutBack).SetUpdate(true).OnComplete(() =>
                       {

                           gameObject.SetActive(false);
                       }); ;
    }
}
