using UnityEngine;
using System.Collections;

public class ShootsToEnemyUnits : MonoBehaviour {
	public GameObject bulletTracePrefab;
	public GameObject debrisPrefab;
	public float damage = 15;
	public float cooldown = 0.2f;
	public float inaccuracy = 0.3f;
	public Vector3 gunOffset;
	public float maxShootDistance = 100;
	float cooldownRemaining = 0;

	void FixedUpdate() {
		cooldownRemaining -= Time.deltaTime;

		var player = GetPlayer();
		if (player == null) { return; }

		var canShoot = false;
		var eyePos = gameObject.transform.position;
		var playerPos = player.transform.position;
		var rayDir = (playerPos - eyePos).normalized;
		RaycastHit hitInfo;
		if (Physics.Raycast (eyePos, rayDir, out hitInfo)) {
			if (hitInfo.collider == player.GetComponent<Collider>()) {
				if (Vector3.Distance(playerPos, eyePos) < maxShootDistance) {
					canShoot = true;
				}
			}
		}

		if (canShoot && cooldownRemaining <= 0) {
			cooldownRemaining = cooldown;

			var direction = (rayDir + Random.insideUnitSphere * inaccuracy).normalized;
			var gunPosition = gameObject.GetComponent<Collider>().transform.TransformPoint(gunOffset);
			var startPoint = gunPosition + rayDir * 0.1f;
			var ray = new Ray(startPoint, direction);
			
			Shoot(ray, gunPosition);
		}
	}

	void Shoot(Ray ray, Vector3 gunPosition) {
		Vector3 hitPoint;
		RaycastHit info;
		if (Physics.Raycast (ray, out info)) {
			hitPoint = info.point;
			ray = new Ray (gunPosition, hitPoint - gunPosition);
			if (Physics.Raycast (ray, out info)) {
				if (info.collider == null) { return; }
				GameObject obj = info.collider.gameObject;
				hitPoint = info.point;
				
				var hp = obj.GetComponent<HasHealth> ();

                if (hp != null) {
					if (info.collider.tag == "Player") {
						hp.ReceiveDamage (this.damage);
					}
				} else {
					if (debrisPrefab != null) {
						Instantiate (debrisPrefab, hitPoint, Quaternion.identity);
					}
				}
			} else { return; }
		} else { return; }
		
		if (bulletTracePrefab != null) {
			var bulletTrace = (GameObject)Instantiate(bulletTracePrefab);
			var lineComponent = bulletTrace.GetComponent<LineRenderer>();
			lineComponent.SetVertexCount(2);
			lineComponent.SetPosition(0, gunPosition);
			lineComponent.SetPosition(1, hitPoint);
		}
	}

	GameObject GetPlayer() {
		var playerObjs = GameObject.FindGameObjectsWithTag("Player");
		if (playerObjs.Length == 0) { return null; }
		return playerObjs[0];
	}
}
