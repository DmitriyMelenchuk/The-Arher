using System;
using UnityEngine;

public class HealthPotion : MonoBehaviour
{
    [SerializeField] private Player _player;

    public int Value { get; private set; }
    public int Count { get; private set; }

    public void Use()
    {
        _player.AddHealth(2);
    }
}
