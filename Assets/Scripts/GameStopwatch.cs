using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using TMPro;
using System;

public class GameStopwatch : MonoBehaviour
{
    [SerializeField] public TMP_Text _stopwatchText;

    private TimeSpan _elapsedTime;
    private Stopwatch _timer;
    public int finalScore;
    // Start is called before the first frame update
    void Start()
    {
        _timer = new Stopwatch();
    }

    public void StartStopwatch()
    {
        _stopwatchText.text = "hej"; // Reset stopwatch text
        _timer.Start();
    }

    public void StopStopwatch()
    {
        _timer.Stop();
        _elapsedTime = _timer.Elapsed;
        finalScore = CalculateHiddenScore(_elapsedTime.Minutes, _elapsedTime.Seconds, _elapsedTime.Milliseconds);
        _stopwatchText.text = _elapsedTime.Minutes.ToString() + ":" + _elapsedTime.Seconds.ToString() + ":" + _elapsedTime.Milliseconds.ToString();
        _timer.Reset();
     
    }
    public int TimeToMilliseconds(int minutes, int seconds, int milliseconds)
    {
        return (minutes * 60000) + (seconds * 1000) + milliseconds;
    }

    public int CalculateHiddenScore(int minutes, int seconds, int milliseconds)
    {
        int maxTimeInMilliseconds = TimeToMilliseconds(10, 0, 0); // Worst case: 10 minutes
        int playerTimeInMilliseconds = TimeToMilliseconds(minutes, seconds, milliseconds);

        // Flip the scoring: Faster time = higher score
        int maxScore = 1_000_000; // Set an arbitrary max score for best performance
        int score = maxScore - playerTimeInMilliseconds;

        return Mathf.Max(0, score); // Prevent negative scores

    }
}
