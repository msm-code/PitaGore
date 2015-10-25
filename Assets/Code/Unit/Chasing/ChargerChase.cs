using System;
using UnityEngine;

namespace UnityStandardAssets.Characters.ThirdPerson
{
    [RequireComponent(typeof(NavMeshAgent))]
    [RequireComponent(typeof(ThirdPersonCharacter))]
    public class ChargerChase : ChasingBase
    {
        public NavMeshAgent agent { get; private set; } // the navmesh agent required for the path finding
        public ThirdPersonCharacter character { get; private set; } // the character we are controlling

        // Use this for initialization
        private void Start()
        {
            // get the components on the object we need ( should not be null due to require component so no need to check )
            agent = GetComponentInChildren<NavMeshAgent>();
            character = GetComponent<ThirdPersonCharacter>();
            agent.updateRotation = false;
            agent.updatePosition = true;
        }

        private void OnCollisionEnter(Collision col)
        {
            if (col.gameObject.tag == "Player")
            {
                var player = GetPlayer();
                Vector3 direction = player.transform.position - transform.position;
                direction.y = 0;
                direction.Normalize();
                player.GetComponent<Rigidbody>().AddForce(direction*50, ForceMode.Impulse);
            }
        }

        protected override void RealUpdate(GameObject player)
        {
            Transform target = player.transform;

            agent.SetDestination(player.transform.position);
            character.Move(agent.desiredVelocity, false, false);
        }
    }
}