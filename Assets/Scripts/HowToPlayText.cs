using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HowToPlayText : MonoBehaviour
{
    [SerializeField] GameObject howToPlay;
    [SerializeField] float textFadeOutSeconds;

    private TMP_Text[] _texts;

    private void Start()
    {
        _texts = howToPlay.GetComponentsInChildren<TMP_Text>();
    }

    public void ShowText()
    {
        howToPlay.SetActive(true);
        foreach(TMP_Text text in _texts)
        {
            StartCoroutine(FadeTextToZeroAlpha(textFadeOutSeconds, text));
        }
    }

    // Bara f�r debug purposes
    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Debug.Log("Hej!");
            ShowText();
        }
    }
    
    public IEnumerator FadeTextToZeroAlpha(float time, TMP_Text text)
    {
        text.color = new Color(text.color.r, text.color.g, text.color.b, 1);
        while (text.color.a > 0.0f)
        {
            text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a - (Time.deltaTime / time));
            yield return null;
        }
    }
}
