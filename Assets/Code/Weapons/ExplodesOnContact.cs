using UnityEngine;

[RequireComponent(typeof(Motor))]
public class ExplodesOnContact : MonoBehaviour
{
    public GameObject explosionPrefab;
    Motor motor;
    public int maxDamageOnHit;
    public float explosionRange;

    private void Start()
    {
        motor = GetComponent<Motor>();
    }

    void FixedUpdate()
    {
        var ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Time.deltaTime * motor.motorSpeed + 2f))
        {   
            Explode(hit.point);
        }
    }

    void Explode(Vector3 point)
    {
        Instantiate(explosionPrefab, point, Quaternion.identity);

        var colliders = Physics.OverlapSphere(transform.position, explosionRange);
        foreach (var collider in colliders)
        {
            var hp = collider.GetComponent<HasHealth>();
            if (hp != null)
            {
                var factor = 1 - (Vector3.Distance(transform.position, collider.transform.position) / explosionRange);
                hp.ReceiveDamage(factor * maxDamageOnHit);
            }
        }

        Destroy(gameObject);
    }
}
