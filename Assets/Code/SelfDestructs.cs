using UnityEngine;
using System.Collections;

public class SelfDestructs : MonoBehaviour {
	public float duration = 1f;

	void Update () {
		duration -= Time.deltaTime;
		if (duration <= 0) {
			Destroy(gameObject);
		}
	}
}
