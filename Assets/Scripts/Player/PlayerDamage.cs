using System.Collections;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    private const string _damageKey = "damage";
    
    [SerializeField] private int _startDamage;

    private bool _isActiveAddDamageForTime;

    public int Damage => PlayerPrefs.GetInt(_damageKey);

    private void Start()
    {
        if (Damage < _startDamage)
            PlayerPrefs.SetInt(_damageKey, _startDamage);
    }

    public void SetMaxDamage(int value)
    {
        if (value > 0)
            PlayerPrefs.SetInt("damage", Damage + value);
    }

    public IEnumerator AddDamageForTime(float time, float value)
    {
        if (_isActiveAddDamageForTime == false)
        {
            int damagePercent = Damage + (int)(Damage * value);
            int startDamage = Damage;
            float runnigTime = 0;

            while (runnigTime < time)
            {
                _isActiveAddDamageForTime = true;
                PlayerPrefs.SetInt(_damageKey, damagePercent);
                runnigTime += Time.deltaTime;
                yield return null;
            }

            PlayerPrefs.SetInt(_damageKey, startDamage);
            _isActiveAddDamageForTime = false;
            runnigTime = 0;
        }
    }   
}
