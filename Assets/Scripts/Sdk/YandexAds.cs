using UnityEngine;
using Agava.YandexGames;

public class YandexAds : MonoBehaviour
{
    private const int Reward = 10;

    [SerializeField] private MoneyWallet _moneyWallet;

    public void OnShowWithReward() =>
        Agava.YandexGames.VideoAd.Show(OnOpenCallback, OnRewardCallback, OnCloseCallback);

    public void Show()=> 
        Agava.YandexGames.InterstitialAd.Show(OnOpenCallback, OnCloseCallback, null);

    private void OnOpenCallback()
    {
        Time.timeScale = 0;
        AudioListener.volume = 0f;
    }

    private void OnRewardCallback()
    {
        _moneyWallet.Add(Reward);
    }

    private void OnCloseCallback()
    {
        Time.timeScale = 1;
        AudioListener.volume = 1f;
    }

    private void OnCloseCallback(bool result)
    {
        Time.timeScale = 1;
        AudioListener.volume = 1f;
    }
}
