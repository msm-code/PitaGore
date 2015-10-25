using UnityEngine;

public class BulletGun : GunBase
{
    public GameObject bulletPrefab;

    protected override void SuperrealShot(Ray ray)
    {
        Instantiate(bulletPrefab, ray.origin, Quaternion.LookRotation(ray.direction));
    }   
}
