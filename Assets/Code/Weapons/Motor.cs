using UnityEngine;

public class Motor : MonoBehaviour
{
    public float motorSpeed;
    public float gravityStrength;
    public float yVelocity;

    void FixedUpdate()
    {
        gameObject.transform.position += gameObject.transform.rotation * Vector3.forward * Time.deltaTime * motorSpeed;
        gameObject.transform.position += yVelocity * -Vector3.up * Time.deltaTime;
        yVelocity += Time.deltaTime * gravityStrength;
    }
}
