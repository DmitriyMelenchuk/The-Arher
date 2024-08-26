using System;
using UnityEngine;
using PlayerPrefs = Agava.YandexGames.Utility.PlayerPrefs;

public class MoneyWallet : MonoBehaviour
{
    private const string MoneyKey = "money";

    private int _money;

    public event Action<int> MoneyChanged;

    private void Start()
    {
        _money = PlayerPrefs.GetInt(MoneyKey);
        MoneyChanged?.Invoke(PlayerPrefs.GetInt(MoneyKey));
    }

    public void Add(int value)
    {
        if (value > 0)
        {
            _money += value;
            PlayerPrefs.SetInt(MoneyKey, _money);
            MoneyChanged?.Invoke(PlayerPrefs.GetInt(MoneyKey));
        }  
    }

    public bool TryRemove(int value)
    {
        if (_money >= value)
        {
            if (value > 0)
            {
                _money -= value;
                PlayerPrefs.SetInt(MoneyKey, _money);
                MoneyChanged?.Invoke(_money);
                return true;
            }
        }

        return false;
    }
}
