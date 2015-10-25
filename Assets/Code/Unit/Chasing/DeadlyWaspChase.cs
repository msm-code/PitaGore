using System;
using UnityEngine;

namespace UnityStandardAssets.Characters.ThirdPerson
{
    [RequireComponent(typeof(NavMeshAgent))]
    [RequireComponent(typeof(ThirdPersonCharacter))]
    public class DeadlyWaspChase : ChasingBase
    {
        public ShootsAtPlayer EvilMagic;

        protected override void RealUpdate(GameObject player)
        {
            Transform target = player.transform;

            if (target != null)
            {
                EvilMagic.CastTheGreatestEverSeenGodDamnFireball();
                agent.SetDestination(target.position);
                character.Move(agent.desiredVelocity, false, false);
            }
        }
    }
}