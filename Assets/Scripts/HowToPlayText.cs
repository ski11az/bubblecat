using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HowToPlayText : MonoBehaviour
{
    [SerializeField] GameObject howToPlayPanel;
    [SerializeField] TMP_Text howToPlayText;
    [SerializeField] float textFadeOutSeconds;

    public void ShowText()
    {
        howToPlayPanel.SetActive(true);
        StartCoroutine(FadeTextToZeroAlpha(textFadeOutSeconds, howToPlayText));
    }
    
    public IEnumerator FadeTextToZeroAlpha(float time, TMP_Text text)
    {
        text.color = new Color(text.color.r, text.color.g, text.color.b, 1);
        while (text.color.a > 0.0f)
        {
            text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a - (Time.deltaTime / time));
            yield return null;
            Debug.Log(text.color.a);
        }
        Debug.Log("Finished coroutine");
        howToPlayPanel.SetActive(false);
    }
}
