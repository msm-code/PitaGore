using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
    public int damage = 10;
    float time = 0;

	// Use this for initialization
	void Start () {
	    
	}

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            time += Time.deltaTime;
            if (time > 0.5)
            {
                collision.gameObject.GetComponent<HasHealth>().ReceiveDamage(this.damage);
                time = 0;
            }
        }
    }

    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            time += Time.deltaTime;
            if (time > 0.5)
            {
                collision.gameObject.GetComponent<HasHealth>().ReceiveDamage(this.damage);
                time = 0;
            }
        }
    }

    // Update is called once per frame
    void Update () {
	
	}
}
