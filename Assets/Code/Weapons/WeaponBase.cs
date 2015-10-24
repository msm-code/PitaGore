using UnityEngine;

public abstract class WeaponBase : MonoBehaviour {

    public int damage;
    public int range;
    public float reload;
    public int ammo;
    float cooldownRemaining;

    protected abstract void RealShoot();

    public void Shoot()
    {
        cooldownRemaining -= Time.deltaTime;
        if (ammo > 0 && cooldownRemaining <= 0)
        {
            cooldownRemaining += reload;
            ammo -= 1;

            RealShoot();
        }
    }
}
