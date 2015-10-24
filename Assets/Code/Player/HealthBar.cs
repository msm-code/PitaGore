using UnityEngine;
using System.Collections;

public class HealthBar : MonoBehaviour {
	void Update () {
		var bar = gameObject.GetComponent<GUIText> ();
		var player = GetPlayer ();
		if (player == null) { return; }
		var hp = player.GetComponent<HasHealth> ();
		var info = hp.currentHp < hp.maxHealth / 2 ? "zaraz nie bedziesz miał życia jak tomek :/" : "";
		bar.text = string.Format ("{0}/{1} hp {2}", hp.currentHp, hp.maxHealth, info);
	}

	GameObject GetPlayer() {
		var playerObjs = GameObject.FindGameObjectsWithTag("Player");
		if (playerObjs.Length == 0) { return null; }
		return playerObjs[0];
	}
}
