using UnityEngine;
using System.Collections;

public class ExplodesNearEnemyUnits : MonoBehaviour {
	public float explosionRadius;
	public float explosionInitDistance;
	public float damage;
	public GameObject explosionPrefab;

	void FixedUpdate () {
		var player = GetPlayer();
		if (player == null) { return; }

		var eyePos = gameObject.transform.position;
		var playerPos = player.transform.position;
		var rayDir = (playerPos - eyePos).normalized;
		RaycastHit hitInfo;
		if (Physics.Raycast (eyePos, rayDir, out hitInfo)) {
			if (hitInfo.collider == player.GetComponent<Collider>()) {
				if (Vector3.Distance(playerPos, eyePos) < explosionInitDistance) {
					Explode();
				}
			}
		}
	}

	void Explode() {
		if (explosionPrefab != null) {
			Instantiate (explosionPrefab, transform.position, Quaternion.identity);
		}

		Destroy(gameObject);

		var explosionPoint = transform.position;
		var colliders = Physics.OverlapSphere(explosionPoint, explosionRadius);
		foreach (var collider in colliders) {
			var hp = collider.GetComponent<HasHealth>();
			if (hp != null) {
				var distance = Vector3.Distance(explosionPoint, collider.transform.position);
				var damageRatio = 1 - (distance / explosionRadius);
				hp.ReceiveDamage(damage * damageRatio);
			}
		}
	}

	GameObject GetPlayer() {
		var playerObjs = GameObject.FindGameObjectsWithTag("Player");
		if (playerObjs.Length == 0) { return null; }
		return playerObjs[0];
	}
}
