using System;
using UnityEngine;

public class BouncingLaserGun : GunBase
{
    public GameObject debrisPrefab;
    public GameObject bulletTracePrefab;
    public GameObject hitPrefab;

    private float damage = 20;

    public override int MaxAmmo { get { return 1000; } }

    public override float ReloadTime { get { return 0.1f; } }

    const int MAX_BOUNCES = 4;

    void SendBouncingRay(Ray ray, int maxBounces)
    {
        if (maxBounces < 0)
        {
            return;
        }

        RaycastHit info;
        Vector3 hitPoint;
        Vector3 destPoint;
        if (Physics.Raycast(ray, out info))
        {

            if (info.collider == null) { return; }
            GameObject obj = info.collider.gameObject;
            hitPoint = info.point;


            var hp = obj.GetComponent<HasHealth>();
            if (hitPrefab != null)
            {
                Instantiate(hitPrefab, hitPoint, Quaternion.identity);
            }
            if (hp != null)
            {
                hp.ReceiveDamage(this.damage);
            }
            else
            {
                var newDirection = Vector3.Reflect(ray.direction, info.normal);
                var newRay = new Ray(info.point, newDirection);
                newRay.origin += newDirection * 0.1f;
                SendBouncingRay(newRay, maxBounces - 1);

                if (debrisPrefab != null)
                {
                    Instantiate(debrisPrefab, hitPoint, Quaternion.identity);
                }
            }
            destPoint = hitPoint;
        }
        else
        {
            destPoint = ray.origin + ray.direction * 1000;
        }
        ShowBulletTrace(ray.origin, destPoint);
    }

    void ShowBulletTrace(Vector3 from, Vector3 to)
    {
        if (bulletTracePrefab != null)
        {
            var bulletTrace = (GameObject)Instantiate(bulletTracePrefab);
            var lineComponent = bulletTrace.GetComponent<LineRenderer>();
            lineComponent.SetVertexCount(2);
            lineComponent.SetPosition(0, from);
            lineComponent.SetPosition(1, to);
        }
    }

    protected override void SuperrealShot(Ray ray, Vector3 gunPosition)
    {
        Vector3 hitPoint;
        RaycastHit info;
        if (Physics.Raycast(ray, out info))
        {
            hitPoint = info.point;
            ray = new Ray(gunPosition, hitPoint - gunPosition);
            SendBouncingRay(ray, MAX_BOUNCES);
        }
        else { ShowBulletTrace(gunPosition, ray.origin + ray.direction * 10000); }
    }
}
