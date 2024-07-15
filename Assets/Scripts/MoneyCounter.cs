using System;
using UnityEngine;

public class MoneyCounter : MonoBehaviour
{
    private const string MoneyKey = "money";

    public int Money => PlayerPrefs.GetInt(MoneyKey);

    public event Action<int> MoneyChanged;

    public void Add(int value)
    {
        if (value > 0)
        {
            PlayerPrefs.SetInt(MoneyKey,Money + value);
            MoneyChanged?.Invoke(Money);
        }  
    }

    public void Remove(int value)
    {
        if (value > 0)
        {
            PlayerPrefs.SetInt(MoneyKey, Money - value);
            MoneyChanged?.Invoke(Money);
        }
    }
}
