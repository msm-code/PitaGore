using UnityEngine;

public class BulletGun : GunBase
{
    public GameObject bulletPrefab;

    public override int MaxAmmo { get { return 1000; } }

    public override float ReloadTime { get { return 0.1f; } }

    protected override void SuperrealShot(Ray ray)
    {
        Instantiate(bulletPrefab, ray.origin, Quaternion.LookRotation(ray.direction));
    }   
}
