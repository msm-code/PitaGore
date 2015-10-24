using UnityEngine;

public class HasWeapon : MonoBehaviour
{
    public GameObject weaponObject;

    public WeaponBase GetWeapon()
    {
        if (weaponObject == null)
        {
            return null;
        }
        return weaponObject.GetComponent<WeaponBase>();
    }

    public void SetCurrentWeapon(GameObject weapon)
    {
        if (weaponObject != null)
        {
            Destroy(weaponObject);
        }

        weaponObject = Instantiate(weapon);
        weaponObject.transform.parent = gameObject.transform;
    }
}