using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.ThirdPerson;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(ThirdPersonCharacter))]
public abstract class ChasingBase : MonoBehaviour
{
    public NavMeshAgent agent { get; private set; } // the navmesh agent required for the path finding
    public ThirdPersonCharacter character { get; private set; } // the character we are controlling

    public float sightRange = 100;
    public bool hasSightLimitation;

    private void Start()
    {
        // get the components on the object we need ( should not be null due to require component so no need to check )
        agent = GetComponentInChildren<NavMeshAgent>();
        character = GetComponent<ThirdPersonCharacter>();
        agent.updateRotation = false;
        agent.updatePosition = true;
    }

    bool CanSeePlayer(Vector3 target)
    {
        return (!hasSightLimitation || Vector3.Distance(target, gameObject.transform.position) < sightRange);
    }

    public GameObject GetPlayer()
    {
        var playerObjs = GameObject.FindGameObjectsWithTag("Player");
        if (playerObjs.Length == 0) { return null; }
        return playerObjs[0];
    }

    private void Update()
    {
        var player = GetPlayer();
        if (player == null) { return; }

        var target = player.transform.position;
        if (target != null && CanSeePlayer(target))
        {
            RealUpdate(player);
        }
    }

    protected abstract void RealUpdate(GameObject player);
}
