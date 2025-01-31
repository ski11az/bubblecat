using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BubbleRoomButton : MonoBehaviour
{
    [SerializeField] BubbleRoom bubbleRoom;
    [SerializeField] BubbleNames bubble;
    [SerializeField] Button[] buttons;
    public void ChooseBubble()
    {
        AudioManager.Instance.PlayOneShot(AudioManager.Instance.sfxSource, AudioManager.Instance.hit[1], 1);
        bubbleRoom.SwitchBubble(bubble);
        foreach (Button button in buttons)
        {
            button.interactable = true;
        }
        
    }
}
 