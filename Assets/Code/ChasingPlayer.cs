using System;
using UnityEngine;

namespace UnityStandardAssets.Characters.ThirdPerson
{
    [RequireComponent(typeof(NavMeshAgent))]
    [RequireComponent(typeof(ThirdPersonCharacter))]
    public class ChasingPlayer : MonoBehaviour
    {
        public NavMeshAgent agent { get; private set; } // the navmesh agent required for the path finding
        public ThirdPersonCharacter character { get; private set; } // the character we are controlling
        public Vector3 target; // target to aim for
        public Transform player;

        // Use this for initialization
        private void Start()
        {
            // get the components on the object we need ( should not be null due to require component so no need to check )
            agent = GetComponentInChildren<NavMeshAgent>();
            character = GetComponent<ThirdPersonCharacter>();
            agent.updateRotation = false;
            agent.updatePosition = true;
        }


        // Update is called once per frame
        private void Update()
        {
            target = player.position;
            if (target != null)
            {
                agent.SetDestination(target);
                // use the values to move the character
                character.Move(agent.desiredVelocity, false, false);
            }

        }
  
        

        //private enum GirlStates { Waits, RunAway, Covers }; //gdyby to bylo cos wiekszego to byloby jeszcze None
        //i druga funkcja: przejdz do stanu w ktorej bylyby rzeczy ktore robi tylko raz przy przejsciu do stanu

        //GirlStates currentState = GirlStates.Waits;

        /*void ChooseTarget()
        {
            switch (currentState)
            {
                case GirlStates.Waits:
                    target = transform.position;
                    if (Vector3.Distance(transform.position, player.position) < 10) currentState = GirlStates.RunAway;
                    break;
                case GirlStates.RunAway:
                    if (Vector3.Distance(transform.position, player.position) > 15) currentState = GirlStates.Waits;
                    target = badGuy.position;
                    break;
            }
        }
        */

    }
}