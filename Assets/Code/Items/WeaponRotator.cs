using UnityEngine;

public class WeaponRotator : Rotator
{

    public GameObject weaponPrefab;

    public override void Collision(Collider collider)
    {
        var currentWeapon = collider.gameObject.GetComponent<HasWeapon>();

        if (currentWeapon != null)
        {
            currentWeapon.SetCurrentWeapon(weaponPrefab);
        }
    }
}
