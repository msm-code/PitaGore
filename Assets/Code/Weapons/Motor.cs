using UnityEngine;

public class Motor : MonoBehaviour
{
    public float motorSpeed;

    void FixedUpdate()
    {
        gameObject.transform.position += gameObject.transform.rotation * Vector3.forward * Time.deltaTime * motorSpeed;
    }
}
