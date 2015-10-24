using UnityEngine;

public class BulletGun : GunBase
{
    public GameObject bulletPrefab;

    protected override void SuperrealShot(Ray ray, Vector3 gunPosition)
    {
        Instantiate(bulletPrefab, gunPosition, Quaternion.LookRotation(ray.direction));
    }   
}
