using System;
using UnityEngine;

namespace UnityStandardAssets.Characters.ThirdPerson
{
    [RequireComponent(typeof(NavMeshAgent))]
    [RequireComponent(typeof(ThirdPersonCharacter))]
    public class GoliathChase : ChasingBase
    {
        public HasHealth hp;

        // Use this for initialization
        private void Start()
        {
            hp = gameObject.GetComponent<HasHealth>();
            base.Start();
        }


        // Update is called once per frame
        protected override void RealUpdate(GameObject player)
        {
            Transform target = player.transform;

            if (target != null)
            {
                if (hp.currentHp < hp.maxHealth)
                {
                    hp.currentHp += 0.2f;
                }
                agent.SetDestination(target.position);
                character.Move(agent.desiredVelocity, false, false);
            }
        }
    }
}