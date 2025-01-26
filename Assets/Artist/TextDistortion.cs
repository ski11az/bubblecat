using UnityEngine;
using TMPro;
using DG.Tweening;

public class TextDistortion : MonoBehaviour
{
    public TextMeshProUGUI textElement;
    public float waveFrequency = 2f;
    public float waveAmplitude = 5f;
    public float distortionStrength = 2f;
    public float distortionDuration = 0.1f;

    private Tween distortionTween;

    private void OnEnable()
    {
        ApplyTextDistortion();
    }

    private void OnDisable()
    {
        distortionTween?.Kill();
    }

    private void ApplyTextDistortion()
    {
        distortionTween = DOTween.To(() => 0f, x => DistortText(), 1f, distortionDuration)
            .SetLoops(-1, LoopType.Restart)
            .SetEase(Ease.Linear);
    }

    private void DistortText()
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
                float waveOffset = Mathf.Sin(Time.time * waveFrequency + vertices[vertexIndex + j].x * 0.1f) * waveAmplitude;

                vertices[vertexIndex + j] += new Vector3(
                    Random.Range(-distortionStrength, distortionStrength) * 0.5f,
                    waveOffset + Random.Range(-distortionStrength, distortionStrength) * 0.5f,
                    0);
            }
        }

        textElement.UpdateVertexData(TMP_VertexDataUpdateFlags.Vertices);
    }
}
