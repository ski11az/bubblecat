using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

using UnityEngine.UI;

public class BubbleRoom : MonoBehaviour
{
    public List<BubbleChoice> choices = new List<BubbleChoice>();
    [SerializeField] DangleCat cat;
    [SerializeField] Toggle transparentToggle;
    [SerializeField] BubbleNames bubble;
    [SerializeField] TextMeshProUGUI changedBubble;
    private Tween fadeTween;
    public float fadeDuration;

    public void SwitchBubble(BubbleNames bubble)
    {
        Debug.Log("SwitchBubble");
        foreach (BubbleChoice b in choices)
        {
            if (b.name == bubble)
            {
                StartCoroutine("ShowChangedBubbleText", bubble);
                if(!transparentToggle.isOn)
                cat.bubblePrefab = b.prefab;
                else
                cat.bubblePrefab = b.transparentPrefab;
            }
        }
    }
    private void OnDisable()
    {
        changedBubble.text = " ";
    }
    public void SwitchTransparency()
    {
        foreach (BubbleChoice b in choices)
        {
            if (b.prefab == cat.bubblePrefab)
            {
                if (!transparentToggle.isOn)
                    cat.bubblePrefab = b.prefab;
                else
                    cat.bubblePrefab = b.transparentPrefab;
            }
        }
    }



    IEnumerator ShowChangedBubbleText(BubbleNames bubble)
    {
        changedBubble.text = "Switched bubble to " + bubble.ToString();
        yield return new WaitForSecondsRealtime(2);
        changedBubble.text = " ";
    }
}


[System.Serializable]

public class BubbleChoice
{
    public Bubble prefab;
    public Bubble transparentPrefab;
    public BubbleNames name;
}
[System.Serializable]

public enum BubbleNames
{
    Regular,
    Golden,
    Electric,
}
