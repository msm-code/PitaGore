using UnityEngine;
using System.Collections;

public class ShootsAtPlayer : MonoBehaviour {
    public GameObject bulletPrefab;

    public void CastTheGreatestEverSeenGodDamnFireball()
    {
        var camTransform = gameObject.transform;
        var direction = (camTransform.forward + Random.insideUnitSphere * 0.3f).normalized;
        var startPoint = camTransform.position + camTransform.forward * 0.1f;
        var ray = new Ray(startPoint, direction);

        Vector3 hitPoint;
        RaycastHit info;
        if (Physics.Raycast(ray, out info))
        {
            hitPoint = info.point;
            ray = new Ray(ray.origin + Vector3.up * -0.5f, hitPoint - ray.origin);
        }
        else
        {
            ray = new Ray(ray.origin + Vector3.up * -0.5f, ray.direction);
        }

        ray.origin = ray.origin + ray.direction * 0.5f;
        Instantiate(bulletPrefab, ray.origin, Quaternion.LookRotation(ray.direction));
    }
}
