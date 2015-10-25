using System;
using UnityEngine;

public class LaserGun : GunBase
{
    public GameObject debrisPrefab;
    public GameObject bulletTracePrefab;
    public GameObject hitPrefab;

    public float damage = 20;

    protected override void SuperrealShot(Ray ray)
    {
        Vector3 hitPoint;
        RaycastHit info;
        if (Physics.Raycast(ray, out info))
        {
            hitPoint = info.point;
            ray = new Ray(ray.origin, hitPoint - ray.origin);
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
                    if (debrisPrefab != null)
                    {
                        Instantiate(debrisPrefab, hitPoint, Quaternion.identity);
                    }
                }
            }
            else { return; }
        }
        else { return; }

        if (bulletTracePrefab != null)
        {
            var bulletTrace = (GameObject)Instantiate(bulletTracePrefab);
            var lineComponent = bulletTrace.GetComponent<LineRenderer>();
            lineComponent.SetVertexCount(2);
            lineComponent.SetPosition(0, ray.origin);
            lineComponent.SetPosition(1, hitPoint);
        }
    }
}
