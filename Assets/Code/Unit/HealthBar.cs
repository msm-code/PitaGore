using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {
    public GameObject tracedObject;

	void Update () {
		var bar = gameObject.GetComponent<Text> ();
		var hp = tracedObject.GetComponent<HasHealth> ();
		var info = hp.currentHp < hp.maxHealth / 2 ? "nie jest dobrze :/" : "";
		bar.text = string.Format ("{0}/{1} hp {2}", hp.currentHp, hp.maxHealth, info);
	}
}
