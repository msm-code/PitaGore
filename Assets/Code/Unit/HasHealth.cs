using UnityEngine;
using System.Collections;

public class HasHealth : MonoBehaviour {
	public float maxHealth = 100;
	public float currentHp = 100;
	public GameObject bloodPrefab;

	public void ReceiveDamage(float amount) {
		currentHp -= amount;
		if (bloodPrefab != null) {
			Instantiate (bloodPrefab, transform.position, Quaternion.identity);
		}
		if (currentHp <= 0) {
			Die();
		}
	}

    public void ReceiveHealing(float amount) {
        currentHp += amount;
        if (currentHp > maxHealth)
        {
            currentHp = maxHealth;
        }
    }


    void Die() {
		Destroy(gameObject);
	}
}