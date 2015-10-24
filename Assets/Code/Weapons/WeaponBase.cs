using UnityEngine;

public abstract class WeaponBase : MonoBehaviour
{
    public int ammo;
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
        if (ammo > 0 && cooldownRemaining <= 0)
        {
            cooldownRemaining = ReloadTime;
            ammo -= 1;

            RealShoot();
        }
    }
}
