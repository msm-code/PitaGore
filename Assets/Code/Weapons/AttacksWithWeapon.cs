using UnityEngine;
using System.Collections;

public class AttacksWithWeapon : MonoBehaviour {
    public int mouseButton;

    void FixedUpdate() {
        var weapon = gameObject.GetComponent<WeaponBase>();
		if (Input.GetMouseButton(mouseButton) && weapon != null) {
            weapon.Shoot();
		}
	}
}
