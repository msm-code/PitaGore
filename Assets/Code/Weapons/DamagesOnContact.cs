
using UnityEngine;

[RequireComponent(typeof(Motor))]
public class DamagesOnContact : MonoBehaviour
{
    Motor motor;
    public int damageOnHit;

    private void Start()
    {
        motor = GetComponent<Motor>();
    }

    void FixedUpdate()
    {
        var ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Time.deltaTime * motor.motorSpeed + 1f))
        {
            var hp = hit.collider.gameObject.GetComponent<HasHealth>();
            if (hp != null)
            {
                hp.ReceiveDamage(damageOnHit);
                Destroy(gameObject);
            }
        }
    }
}
