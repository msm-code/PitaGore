using UnityEngine;
using System.Collections;

public class SeeksEnemyUnits : MonoBehaviour {
	public float walkSpeed = 3f;

	int i;
	void FixedUpdate () {
		var player = GetPlayer();
		if (player == null) { return; }

		var agent = gameObject.GetComponent<NavMeshAgent>();
		agent.destination = player.transform.position;
	}

	GameObject GetPlayer() {
		var playerObjs = GameObject.FindGameObjectsWithTag("Player");
		if (playerObjs.Length == 0) { return null; }
		return playerObjs[0];
	}
}
