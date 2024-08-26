using Agava.YandexGames;
using UnityEngine;
using UnityEngine.UI;

public class LeaderBoard : MonoBehaviour
{
    private const string LeaderBoardName = "LeaderBoard";

    [SerializeField] private Button _button;

    private void OnEnable()
    {
        _button.onClick.AddListener(OnGetLeaderboardEntriesButtonClick);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnGetLeaderboardEntriesButtonClick);
    }

    public void OnGetLeaderboardEntriesButtonClick()
    {
        Leaderboard.GetEntries("LeaderBoard", (result) =>
        {
            Debug.Log($"My rank = {result.userRank}");
            foreach (var entry in result.entries)
            {
                string name = entry.player.publicName;
                if (string.IsNullOrEmpty(name))
                    name = "Anonymous";
                Debug.Log(name + " " + entry.score);
            }
        });
    }
}
