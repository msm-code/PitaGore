using System;
using UnityEngine;

namespace UnityStandardAssets.Characters.ThirdPerson
{
    [RequireComponent(typeof(NavMeshAgent))]
    [RequireComponent(typeof(ThirdPersonCharacter))]
    public class SmallBiterChase : ChasingBase
    {
        float time = 0;
        private NavMeshAgent ch;

        // Use this for initialization
        private void Start()
        {
            // get the components on the object we need ( should not be null due to require component so no need to check )
            ch = gameObject.GetComponent<NavMeshAgent>();
            base.Start();
        }



        // Update is called once per frame
        protected override void RealUpdate(GameObject player)
        {
            Transform target = player.transform;
            if (target != null)
            {
                time += Time.deltaTime;
                if (time > 4.9)
                {
                    ch.speed = 110;
                    ch.acceleration = 160;
                }
                if (time > 5.0)
                {
                    ch.acceleration = 16;
                    ch.speed = 11;
                    time = 0;
                }
                agent.SetDestination(target.position);
                character.Move(agent.desiredVelocity, false, false);
            }

        }
    }
}