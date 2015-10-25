using System;
using UnityEngine;

namespace UnityStandardAssets.Characters.ThirdPerson
{
    [RequireComponent(typeof(NavMeshAgent))]
    [RequireComponent(typeof(ThirdPersonCharacter))]
    public class ChargerChase : ChasingBase
    {
        protected new void Start()
        {
            base.Start();
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