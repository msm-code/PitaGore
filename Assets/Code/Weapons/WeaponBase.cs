using UnityEngine;

public abstract class WeaponBase : MonoBehaviour
{
    protected int ammo;
    float cooldownRemaining;

    public abstract int MaxAmmo { get; }
    public abstract float ReloadTime { get; }

    void Start()
    {
        this.ammo = MaxAmmo;
    }

    protected abstract void RealShoot();

    public void Shoot()
    {
        cooldownRemaining -= Time.deltaTime;
        if (cooldownRemaining <= 0)
        {
            cooldownRemaining = ReloadTime;

            RealShoot();
        }
    }
}
