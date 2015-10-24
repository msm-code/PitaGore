using UnityEngine;
using System.Collections;
using System;

public class WeaponRotator : Rotator {

    public GameObject weaponPrefab;

    public override void Collision(Collider collider)
    {
        var currentWeapon = collider.gameObject.GetComponent<WeaponBase>();
        Destroy(currentWeapon);

        var newWeapon = weaponPrefab.GetComponent<WeaponBase>();
        collider.gameObject.AddExistingComponent(newWeapon);
    }
}
