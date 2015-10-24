using UnityEngine;

public class WeaponRotator : Rotator
{

    public GameObject weaponPrefab;

    public override void Collision(Collider collider)
    {   

        var currentWeapon = collider.gameObject.GetComponent<WeaponBase>();
        Destroy(currentWeapon);

        var newWeapon = weaponPrefab.GetComponent<WeaponBase>();
        collider.gameObject.AddExistingComponent(newWeapon);

        //<hackaton mode=on>
        if (newWeapon is BulletGun)
        {
            BulletGun bullet = newWeapon as BulletGun;
            collider.gameObject.GetComponent<BulletGun>().bulletPrefab = (weaponPrefab.GetComponent<BulletGun>()).bulletPrefab;
        }
        //</hackaton>
    }
}
