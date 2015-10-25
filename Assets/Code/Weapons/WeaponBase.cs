using UnityEngine;

public abstract class WeaponBase : MonoBehaviour
{
    float cooldownRemaining;
    public int ShotsAtOnce = 1;
    public float ReloadTime = 0.05f;

    protected abstract void RealShoot();

    public void Shoot()
    {
        cooldownRemaining -= Time.deltaTime;
        if (cooldownRemaining <= 0)
        {
            cooldownRemaining = ReloadTime;

            for (int i = 0; i < ShotsAtOnce; i++)
            {
                RealShoot();
            }
        }
    }
}
