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
    public int TimeToSeconds(int hours, int minutes, int seconds)
    {
        return (hours * 3600) + (minutes * 60) + seconds;
    }
    public int CalculateHiddenScore(int hours, int minutes, int seconds)
    {
        int maxTimeInSeconds = TimeToSeconds(100, 100, 100); // Worst time
        int playerTimeInSeconds = TimeToSeconds(hours, minutes, seconds); // Player's time

        // Score = Max Time - Player's Time
        int score = maxTimeInSeconds - playerTimeInSeconds;

        return score;
    }
}
