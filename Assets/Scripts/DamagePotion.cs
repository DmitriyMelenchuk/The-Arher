using UnityEngine;

public class DamagePotion : MonoBehaviour, IPotion
{
    [SerializeField] private Player _player;
    [SerializeField] private float _durationTime;
    [SerializeField] private float _percentAdvanceDamage; 

    public void Use()
    {
        StartCoroutine(_player.PlayerDamage.AddDamageForTime(_durationTime, _percentAdvanceDamage));
    }
}
