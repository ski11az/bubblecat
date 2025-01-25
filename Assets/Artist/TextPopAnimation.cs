using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using DG.Tweening;

public class TextPopAnimation : MonoBehaviour
{
    [Header("Cute Pop Effect")]
    public List<TextMeshProUGUI> textElements;  // Assign TMP elements in Inspector
    public float popDuration = 0.3f;            // How long the pop effect lasts
    public float delayBetweenPops = 0.15f;      // Time delay between each pop
    public float popScale = 1.3f;               // How much it scales up when popping

    [Header("Distorted Horror Effect")]
    public TextMeshProUGUI horrorTextElement;   // Assign the horror text in Inspector
    public TextMeshProUGUI secondHorrorTextElement;  // Second horror text with fade only
    public float fadeDuration = 1.5f;           // Time to fade in horror text
    public float distortionDuration = 0.05f;    // Speed of distortion flicker
    public float distortionStrength = 8f;       // Intensity of distortion
    public float waveFrequency = 10f;           // Speed of sine wave effect
    public float waveAmplitude = 3f;            // Amplitude of sine wave distortion
    public float delayBeforeSecondText = 1.0f;  // Delay before showing second text

    private void Start()
    {
        // Ensure horror texts start fully transparent (alpha = 0)
        Color initialColor = horrorTextElement.color;
        horrorTextElement.color = new Color(initialColor.r, initialColor.g, initialColor.b, 0);

        Color secondColor = secondHorrorTextElement.color;
        secondHorrorTextElement.color = new Color(secondColor.r, secondColor.g, secondColor.b, 0);

        // Start the animation sequence
        StartCoroutine(SequenceEffects());
    }

    IEnumerator SequenceEffects()
    {
        // Step 1: Play the cute pop effect
        yield return StartCoroutine(PopTextSequence());

        // Step 2: Start fading in the first horror text with distortion
        yield return StartCoroutine(FadeInHorrorText(horrorTextElement, true));

        // Step 3: After a delay, fade in the second horror text with no animation
        yield return new WaitForSeconds(delayBeforeSecondText);
        FadeInSecondHorrorText();
    }

    IEnumerator PopTextSequence()
    {
        foreach (TextMeshProUGUI text in textElements)
        {
            text.gameObject.SetActive(true);  // Ensure the text is visible

            // Start with no scale
            text.transform.localScale = Vector3.zero;

            // Pop-in effect: Scale up and then return to normal size
            yield return text.transform.DOScale(popScale, popDuration)
                .SetEase(Ease.OutBack)  // Smooth pop effect
                .OnComplete(() => text.transform.DOScale(1f, 0.1f))
                .WaitForCompletion();

            yield return new WaitForSeconds(delayBetweenPops);
        }
    }

    IEnumerator FadeInHorrorText(TextMeshProUGUI textElement, bool applyDistortion)
    {
        textElement.DOFade(1f, fadeDuration)
            .SetEase(Ease.InOutQuad)
            .OnComplete(() =>
            {
                if (applyDistortion)
                    StartCoroutine(ApplyTextDistortion(textElement));
            });

        yield return new WaitForSeconds(fadeDuration);
    }

    void FadeInSecondHorrorText()
    {
        secondHorrorTextElement.DOFade(1f, fadeDuration)
            .SetEase(Ease.InOutQuad);
    }

    IEnumerator ApplyTextDistortion(TextMeshProUGUI textElement)
    {
        while (true)
        {
            textElement.ForceMeshUpdate();
            TMP_TextInfo textInfo = textElement.textInfo;

            for (int i = 0; i < textInfo.characterCount; i++)
            {
                if (!textInfo.characterInfo[i].isVisible) continue;

                int vertexIndex = textInfo.characterInfo[i].vertexIndex;
                Vector3[] vertices = textInfo.meshInfo[textInfo.characterInfo[i].materialReferenceIndex].vertices;

                for (int j = 0; j < 4; j++)
                {
                    // Add sine wave distortion for organic movement
                    float waveOffset = Mathf.Sin(Time.time * waveFrequency + vertices[vertexIndex + j].x * 0.1f) * waveAmplitude;

                    // Apply random movement and sine wave effects to each vertex
                    vertices[vertexIndex + j] += new Vector3(
                        Random.Range(-distortionStrength, distortionStrength) * 0.5f,
                        waveOffset + Random.Range(-distortionStrength, distortionStrength) * 0.5f,
                        0);
                }
            }

            textElement.UpdateVertexData(TMP_VertexDataUpdateFlags.Vertices);

            yield return new WaitForSeconds(distortionDuration);
        }
    }
}