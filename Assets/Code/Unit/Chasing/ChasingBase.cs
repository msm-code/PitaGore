using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(ThirdPersonCharacter))]
public abstract class ChasingBase : MonoBehaviour
{
    protected NavMeshAgent agent { get; private set; } // the navmesh agent required for the path finding
    protected ThirdPersonCharacter character { get; private set; } // the character we are controlling

    public float sightRange = 100;
    public bool hasSightLimitation;

    protected void Start()
    {
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
        if (player.transform != null && CanSeePlayer(target))
        {
            RealUpdate(player);
        }
    }

    protected abstract void RealUpdate(GameObject player);
}
