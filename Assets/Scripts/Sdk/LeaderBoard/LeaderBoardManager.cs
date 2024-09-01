using Agava.YandexGames;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaderBoardManager : MonoBehaviour
{
    private const string leaderboardId = "LeaderBoard";

    public void SubmitScore(int score)
    {
        if (YandexGamesSdk.IsInitialized)
        {
            Leaderboard.SetScore(leaderboardId, score, OnScoreSubmitted);
        }
        else
        {
            Debug.LogError("Yandex Games SDK is not initialized.");
        }
    }

    private void OnScoreSubmitted()
    {
        Debug.Log("Score submitted successfully.");
    }
}
