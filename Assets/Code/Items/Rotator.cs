using UnityEngine;
using System.Collections;

public abstract class Rotator : MonoBehaviour {

	// Use this for initialization
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
            Collision();
        }
    }

    public abstract void Collision();

    // Update is called once per frame
    void Update () {
	    transform.Rotate(Vector3.forward * Time.deltaTime * 100);
    }
}
