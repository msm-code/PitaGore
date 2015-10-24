/* using UnityEngine;
using System.Collections;
using Edelweiss.DecalSystem;
using System.Collections.Generic;

public class GetBloodStains : MonoBehaviour {
	ParticleSystem.CollisionEvent[] collisionEvents = new ParticleSystem.CollisionEvent[32];

	[SerializeField] private DS_Decals stainPrefab = null;
	[SerializeField] private DecalsMesh decalsMesh;

	List<DecalProjector> decalProjectors = new List <DecalProjector> ();
	DS_Decals decalsInstance;
	DecalsMeshCutter decalsMeshCutter;
	
	[SerializeField] private Vector3 decalProjectorScale = new Vector3 (0.2f, 0.5f, 0.5f);
	[SerializeField] private float cullingAngle = 80.0f;
	[SerializeField] private float meshOffset = 0.0f;

	void OnParticleCollision(GameObject other) {
		var particleSystem = other.GetComponent<ParticleSystem>();

		EnsureSafeSize(particleSystem.safeCollisionEventSize);
		
		int numCollisionEvents = particleSystem.GetCollisionEvents(gameObject, collisionEvents);
		for (int i = 0; i < numCollisionEvents; i++) {
			PutStain(collisionEvents[i]);
		}
	}

	void EnsureSafeSize(int safeLength) {
		if (collisionEvents.Length < safeLength) {
			collisionEvents = new ParticleSystem.CollisionEvent[safeLength];
		}
	}

	void Start () {
		decalsInstance = Instantiate (stainPrefab) as DS_Decals;

		if (decalsInstance == null) {
				Debug.LogError ("The decals prefab does not contain a DS_Decals instance!");
		} else {
			decalsMesh = new DecalsMesh (decalsInstance);
			decalsMeshCutter = new DecalsMeshCutter ();
		}
	}

	void PutStain(ParticleSystem.CollisionEvent evt) {
		// Instantiate(stainPrefab, collisionEvents[i].intersection, Quaternion.identity);

		Vector3 projectorPosition = evt.intersection;
		Quaternion projectorRotation = ProjectorRotationUtility.ProjectorRotation(-evt.normal.normalized, Vector3.up);

		MeshCollider meshCollider = evt.collider.GetComponent <MeshCollider> ();

		if (meshCollider != null) {
			Mesh mesh = meshCollider.sharedMesh;
			DecalProjector decalProjector = new DecalProjector(
				projectorPosition,
				projectorRotation,
				decalProjectorScale,
				cullingAngle,
				meshOffset,
				0, 0);
								
			// Add the projector to our list and the decals mesh, such that both are
			// synchronized. All the mesh data that is now added to the decals mesh
			// will belong to this projector.
			decalProjectors.Add(decalProjector);
			decalsMesh.AddProjector(decalProjector);
			
			// Get the required matrices.
			var worldToMeshMatrix = evt.collider.renderer.transform.worldToLocalMatrix;
			var meshToWorldMatrix = evt.collider.renderer.transform.localToWorldMatrix;
			
			// Add the mesh data to the decals mesh, cut and offset it.
			decalsMesh.Add(mesh, worldToMeshMatrix, meshToWorldMatrix);						
			decalsMeshCutter.CutDecalsPlanes(decalsMesh);
			decalsMesh.OffsetActiveProjectorVertices();

			// The changes are only present in the decals mesh at the moment. We have
			// to pass them to the decals instance to visualize them.
			decalsInstance.UpdateDecalsMeshes(decalsMesh);
		}
	}
}
*/