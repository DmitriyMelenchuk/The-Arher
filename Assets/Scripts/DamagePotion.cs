using UnityEngine;

public class DamagePotion : MonoBehaviour, IPotion
{
    [SerializeField] private PlayerDamage _damageStats;
    [SerializeField] private float _durationTime;
    [SerializeField] private float _percentAdvanceDamage; 

    public void Use()
    {
        _damageStats.StartCoroutine(_damageStats.AddDamageForTime(_durationTime, _percentAdvanceDamage));
    }
}
