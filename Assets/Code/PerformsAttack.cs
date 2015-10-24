using UnityEngine;
using System.Collections;

public class PerformsAttack : MonoBehaviour {
	public GameObject debrisPrefab;
	public GameObject bulletTracePrefab;
	public GameObject hitPrefab;
	public float damage = 15;
	public float cooldown = 0.2f;
	public float inaccuracy = 0.05f;
	public Vector3 gunOffset;
	public int mouseButton;
	float cooldownRemaining = 0;

	void FixedUpdate() {
		cooldownRemaining -= Time.deltaTime;

		if (Input.GetMouseButton(mouseButton) && cooldownRemaining <= 0) {
			cooldownRemaining = cooldown;
		
			var camTransform = Camera.main.transform;
			var direction = (camTransform.forward + Random.insideUnitSphere * inaccuracy).normalized;
			var gunPosition = gameObject.GetComponent<Collider>().transform.TransformPoint(gunOffset);
			var startPoint = camTransform.position + camTransform.forward * 0.1f;
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
				if (hitPrefab != null) {
					Instantiate (hitPrefab, hitPoint, Quaternion.identity);
				}
				if (hp != null) {
					hp.ReceiveDamage (this.damage);
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
}
