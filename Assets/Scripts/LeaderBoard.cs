using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dan.Main;
using TMPro;
using System.Threading;

public class LeaderBoard : MonoBehaviour
{
    [SerializeField] private List<TextMeshProUGUI> names;
    [SerializeField] private List<TextMeshProUGUI> scores;
    [SerializeField] private List<TextMeshProUGUI> levels;
    [SerializeField] private TMP_InputField nameInput;
    [SerializeField] private GameStopwatch timerScript;
    [SerializeField] private GameObject[] closeIfSuccessful;
    [SerializeField] private GameObject[] openIfSuccessful;
    [SerializeField] private GameObject[] openIfFailed;
    private string publicLeaderboardKey = "d81ecffd5cc493514f490d4589d416d84cf08787629105574383a22ee12ca6d7";
    // Start is called before the first frame update

    public void SubmitScore()
    {
        SetLeaderboardEntry(nameInput.text, timerScript.finalScore, timerScript._stopwatchText.text);
    }
    public void GetLeaderboard()
    {
        LeaderboardCreator.GetLeaderboard(publicLeaderboardKey, ((msg) =>
        {
            int loopLength = (msg.Length < names.Count) ? msg.Length : names.Count;

            for (int i = 0; i < loopLength; i++)
            {
                names[i].text = msg[i].Username;
                levels[i].text = "1";
                scores[i].text = msg[i].Extra;

            }
        }));

    }
    public void SetLeaderboardEntry(string username, int level, string time)
    {
        LeaderboardCreator.UploadNewEntry(publicLeaderboardKey, username, level, time, isSuccessful =>
        {
            if (isSuccessful)
            {
                foreach (GameObject go in closeIfSuccessful)
                {
                    go.SetActive(false);
                }
                foreach (GameObject go in openIfSuccessful)
                {
                    go.SetActive(true);
                }
                GetLeaderboard();
            }
            else
            {
                foreach (GameObject go in closeIfSuccessful)
                {
                    go.SetActive(false);
                }
                foreach (GameObject go in openIfFailed)
                {
                    go.SetActive(true);
                }
            }
            
        });
    }
}
