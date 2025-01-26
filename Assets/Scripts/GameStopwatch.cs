using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using TMPro;
using System;

public class GameStopwatch : MonoBehaviour
{
    [SerializeField] private TMP_Text _stopwatchText;

    private TimeSpan _elapsedTime;
    private Stopwatch _timer;

    // Start is called before the first frame update
    void Start()
    {
        _timer = new Stopwatch();
    }

    public void StartStopwatch()
    {
        _stopwatchText.text = ""; // Reset stopwatch text
        _timer.Start();
    }

    public void StopStopwatch()
    {
        _timer.Stop();
        _elapsedTime = _timer.Elapsed;
        _stopwatchText.text = _elapsedTime.Minutes.ToString() + ":" + _elapsedTime.Seconds.ToString() + ":" + _elapsedTime.Milliseconds.ToString();
        _timer.Reset();
    }
}
