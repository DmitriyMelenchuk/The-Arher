using UnityEngine;

public class HealthPotion : MonoBehaviour, IPotion
{
    [SerializeField] private Player _player;
    [SerializeField] private float _percentAddHealth;

    public void Use()
    {
        if (_player._damageable is PlayerHealth playerHealth)
            playerHealth.HealHealth(_percentAddHealth);
    }
}
