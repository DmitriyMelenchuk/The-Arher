using System;

public interface IPotion
{
    public void Use();

    public event Action<int> ValueChanged;
}
