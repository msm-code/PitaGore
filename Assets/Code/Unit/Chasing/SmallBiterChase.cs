using System;
using UnityEngine;

namespace UnityStandardAssets.Characters.ThirdPerson
{
    [RequireComponent(typeof(NavMeshAgent))]
    [RequireComponent(typeof(ThirdPersonCharacter))]
    public class SmallBiterChase : ChasingBase
    {
        float time = 0;
        public NavMeshAgent ch;

        // Use this for initialization
        private void Start()
        {
            // get the components on the object we need ( should not be null due to require component so no need to check )
            ch = gameObject.GetComponent<NavMeshAgent>();
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