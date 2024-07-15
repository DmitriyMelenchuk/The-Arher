using UnityEngine;

public class HealthPotion : MonoBehaviour, IPotion
{
    [SerializeField] private Player _player;
    [SerializeField] private float _percentAddHealth;

    public void Use()
    {
        _player.AddHealth(_percentAddHealth);
    }
}
