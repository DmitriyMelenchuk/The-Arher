using Agava.YandexGames;
using System;
using UnityEngine;
using PlayerPrefs = Agava.YandexGames.Utility.PlayerPrefs;

public class MoneyWallet : MonoBehaviour
{
    [SerializeField] private CloudData _cloudData;

    public event Action<int> MoneyChanged;

    private void Start()
    {
        _cloudData.Load(OnDataLoaded);
    }

    public void Add(int value)
    {
        if (value > 0)
        {
            _cloudData.UpdateSaveData(saveData =>
            {
                saveData.Money += value;
                MoneyChanged?.Invoke(saveData.Money);
            });
        }
    }

    public bool TryRemove(int value)
    {
        bool result = false;
        _cloudData.UpdateSaveData(saveData =>
        {
            if (value > 0 && saveData.Money >= value)
            {
                saveData.Money -= value;
                MoneyChanged?.Invoke(saveData.Money);
                result = true;
            }
        });
        return result;
    }

    private void OnDataLoaded(SaveData saveData)
    {
        MoneyChanged?.Invoke(saveData.Money);
    }



    //private const string MoneyKey = "money";

    //private int _money;


    //private void Start()
    //{
    //    //_money = PlayerPrefs.GetInt(MoneyKey);
    //    //MoneyChanged?.Invoke(PlayerPrefs.GetInt(MoneyKey));
    //}


    //public void Add(int value)
    //{
    //    if (value > 0)
    //    {
    //        _money += value;
    //        PlayerPrefs.SetInt(MoneyKey, _money);
    //        PlayerPrefs.Save();
    //        MoneyChanged?.Invoke(PlayerPrefs.GetInt(MoneyKey));
    //    }  
    //}

    //public bool TryRemove(int value)
    //{
    //    if (_money >= value)
    //    {
    //        if (value > 0)
    //        {
    //            _money -= value;
    //            PlayerPrefs.SetInt(MoneyKey, _money);
    //            //PlayerPrefs.Save();
    //            MoneyChanged?.Invoke(_money);
    //            return true;
    //        }
    //    }

    //    return false;
    //}

}
