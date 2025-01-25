using System.Collections;
using TMPro;
using UnityEngine;
using DG.Tweening;
using System.Collections.Generic;

public class CuteTextPop : MonoBehaviour

{
    public List<TextMeshProUGUI> textElements;  // Assign TMP elements in inspector
    public float popDuration = 0.3f;            // Duration for each pop effect
    public float delayBetweenPops = 0.2f;       // Delay between pops
    public float bounceScale = 1.3f;            // Scale effect for pop
    public float bounceHeight = 20f;            // Bounce height effect

    private void Start()
    {
        StartCoroutine(PopTextSequence());
    }

    IEnumerator PopTextSequence()
    {
        foreach (TextMeshProUGUI text in textElements)
        {
            text.gameObject.SetActive(true);  // Ensure the text is visible

            // Scale pop effect
            text.transform.localScale = Vector3.zero;
            text.transform.DOScale(bounceScale, popDuration)
                .SetEase(Ease.OutBack)
                .OnComplete(() => text.transform.DOScale(1f, 0.2f));

            // Bounce effect
            Vector3 originalPos = text.transform.localPosition;
            text.transform.DOLocalMoveY(originalPos.y + bounceHeight, popDuration)
                .SetEase(Ease.OutQuad)
                .SetLoops(2, LoopType.Yoyo);

            yield return new WaitForSeconds(delayBetweenPops);
        }
    }
}

