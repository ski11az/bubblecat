using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeScript : MonoBehaviour
{
    [SerializeField] Image uiImage;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] float fadeDuration;
    [SerializeField] bool spriterenderer;
    [SerializeField] bool onStart;
    [SerializeField] bool fadeIn;
    // Start is called before the first frame update
    void Start()
    {
        
        if (onStart)
        {
            if (spriterenderer)
            {
                spriteRenderer.enabled = true;
                FadeSpriteRenderer();
            }
            else
            {
                uiImage.enabled = true;
                FadeUiImage();
            }
        }

    }
    private void OnEnable()
    {
        if (spriterenderer)
        {
            spriteRenderer.enabled = true;
            FadeSpriteRenderer();
        }
        else
        {
            uiImage.enabled = true;
            FadeUiImage();
        }

    }
    
    void FadeUiImage()
    {
        if (fadeIn)
        {

            uiImage.DOFade(1, fadeDuration)
    .SetEase(Ease.InOutQuad)
    .SetUpdate(true);
        }
        else
        {
          
            uiImage.DOFade(0, fadeDuration)
    .SetEase(Ease.InOutQuad)
    .SetUpdate(true);
        }

    }
    void FadeSpriteRenderer()
    {
        if (fadeIn)
        {
            spriteRenderer.DOFade(1, fadeDuration)
.SetEase(Ease.InOutQuad)
.SetUpdate(true);
        }
        else
        {

            spriteRenderer.DOFade(0, fadeDuration)
    .SetEase(Ease.InOutQuad)
    .SetUpdate(true);
        }

    }
}
