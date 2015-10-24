using UnityEngine;

public abstract class GunBase : WeaponBase
{
    public float inaccuracy = 0.05f;

    protected sealed override void RealShoot()
    {
        var camTransform = Camera.main.transform;
        var direction = (camTransform.forward + Random.insideUnitSphere * inaccuracy).normalized;
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
        SuperrealShot(ray);
    }

    protected abstract void SuperrealShot(Ray ray);
}
