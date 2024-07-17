using System.Collections;
using UnityEngine;

public class PlayerDamage
{
    private const string _keyDamage = "playerDamage";

    private bool _isActiveAddDamageForTime;

    public int Damage => PlayerPrefs.GetInt(_keyDamage);

   public PlayerDamage(int damage)
    {
        if (Damage < damage)
            PlayerPrefs.SetInt(_keyDamage, damage);
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
                PlayerPrefs.SetInt(_keyDamage, damagePercent);
                runnigTime += Time.deltaTime;
                yield return null;
            }

            PlayerPrefs.SetInt(_keyDamage, startDamage);
            _isActiveAddDamageForTime = false;
            runnigTime = 0;
        }
    }   
}
