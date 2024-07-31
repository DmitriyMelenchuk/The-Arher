using System;

public interface IWeapon
{
    public void Shot(float forceShot);

    public event Action Shoot;
}
