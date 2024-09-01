using Newtonsoft.Json;
using System;
using UnityEngine;
using Agava.YandexGames;

public class CloudData : MonoBehaviour
{
    private SaveData _saveData = new SaveData();

    public void Save()
    {
#if !UNITY_WEBGL || UNITY_EDITOR
        return;
#endif
        string data = JsonConvert.SerializeObject(_saveData);
        PlayerAccount.SetCloudSaveData(data);
    }

    public void Load(Action<SaveData> onLoaded)
    {
#if !UNITY_WEBGL || UNITY_EDITOR
        return;
#endif
        PlayerAccount.GetCloudSaveData(data =>
        {
            if (!string.IsNullOrEmpty(data))
            {
                _saveData = JsonConvert.DeserializeObject<SaveData>(data);
            }

            onLoaded?.Invoke(_saveData);
        });
    }

    public SaveData GetSaveData()
    {
        return _saveData;
    }

    public void UpdateSaveData(Action<SaveData> updateAction)
    {
        updateAction?.Invoke(_saveData);
        Save();
    }
}
