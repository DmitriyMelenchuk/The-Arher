using Agava.YandexGames;
using TMPro;
using UnityEngine;

public class LeaderBoardView : MonoBehaviour
{
    private const string leaderboardId = "YOUR_LEADERBOARD_ID";

    private void Start()
    {
        GetLeaderboardEntries();
    }

    private void GetLeaderboardEntries()
    {
        if (YandexGamesSdk.IsInitialized)
        {
            // Параметры метода могут отличаться
            //Leaderboard.GetEntries(leaderboardId, OnLeaderboardEntriesReceived);
        }
        else
        {
            Debug.LogError("Yandex Games SDK is not initialized.");
        }
    }

    // Проверьте правильный тип результата в документации SDK
    //private void OnLeaderboardEntriesReceived(LeaderboardEntriesResult result)
    //{
    //    if (result.IsSuccess)
    //    {
    //        Debug.Log($"My rank = {result.userRank}");
    //        foreach (var entry in result.entries)
    //        {
    //            string name = entry.player.publicName;
    //            if (string.IsNullOrEmpty(name))
    //                name = "Anonymous";
    //            Debug.Log(name + " " + entry.score);
    //        }
    //    }
    //    else
    //    {
    //        Debug.LogError("Failed to get leaderboard entries: " + result.Error);
    //    }
    //}
}
