using UnityEngine;
using System.Collections;

public class AttacksWithWeapon : MonoBehaviour {
    public int mouseButton;

    void FixedUpdate() {
        var hasWeapon = gameObject.GetComponent<HasWeapon>();
        if (hasWeapon != null)
        {
            var weapon = hasWeapon.GetWeapon();
            if (Input.GetMouseButton(mouseButton) && weapon != null)
            {
                weapon.Shoot();
            }
        }
	}
}
