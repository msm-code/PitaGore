using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Motor))]
public class Ricochets : MonoBehaviour
{
    Motor motor;

    private void Start()
    {
        motor = GetComponent<Motor>();
    }

    void FixedUpdate()
    {
        var ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Time.deltaTime * motor.motorSpeed + 0.01f))
        {
            var newDirection = Vector3.Reflect(ray.direction, hit.normal);
            transform.rotation = Quaternion.LookRotation(newDirection);
        }
    }
}
