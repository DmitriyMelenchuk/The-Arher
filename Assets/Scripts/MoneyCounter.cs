using System;
using UnityEngine;

public class MoneyCounter : MonoBehaviour
{
    private int _money;

    public event Action<int> MoneyChanged;

    public void Add(int value)
    {
        if (value > 0)
        {
            _money += value;
            MoneyChanged?.Invoke(_money);
        }  
    }

    public void Remove(int value)
    {
        if (value > 0)
        {
            _money -= value;
            MoneyChanged?.Invoke(_money);
        }
    }
}
