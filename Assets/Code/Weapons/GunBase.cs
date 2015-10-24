using UnityEngine;

public abstract class GunBase : WeaponBase
{
    public float inaccuracy = 0.05f;

    protected sealed override void RealShoot()
    {
        var camTransform = Camera.main.transform;
        var direction = (camTransform.forward + Random.insideUnitSphere * inaccuracy).normalized;
        var gunPosition = gameObject.GetComponent<Collider>().transform.TransformPoint(new Vector3(0, 0, 0));
        var startPoint = camTransform.position + camTransform.forward * 0.1f;
        var ray = new Ray(startPoint, direction);

        SuperrealShot(ray, gunPosition);
    }

    protected abstract void SuperrealShot(Ray ray, Vector3 gunPosition);
}
