using UnityEngine;
using System.Collections;

public abstract class Rotator : MonoBehaviour {

	void Start () {
        foreach (Collider c in GetComponents<Collider>())
        {
            c.enabled = true;
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            Collision(collider);
        }
    }

    public abstract void Collision(Collider collider);

    // Update is called once per frame
    void Update () {
	    transform.Rotate(Vector3.forward * Time.deltaTime * 100);
    }
}
