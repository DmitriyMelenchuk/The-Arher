using TMPro;
using UnityEngine;

public class DamageTextView : MonoBehaviour
{
    [SerializeField] private DamageTextSpawner _damageTextSpawner;
    [SerializeField] private TMP_Text _value;
    [SerializeField] private Creature _creature;

    private void OnEnable()
    {
        _creature.TakedDamage += OnTakedDamage;
    }

    private void OnTakedDamage(int damage)
    {
        _value.text = $"-{damage}";
    }

    private void ChangeAlpha()
    { 
        _value.color = new Color32(((byte)_value.color.a), ((byte)_value.color.b), ((byte)_value.color.g), 100);
    }

    private void OnDisable()
    {
        _creature.TakedDamage -= OnTakedDamage;
        _value.text = string.Empty;
    }
}
