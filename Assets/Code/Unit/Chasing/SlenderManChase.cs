using System;
using UnityEngine;

namespace UnityStandardAssets.Characters.ThirdPerson
{
    [RequireComponent(typeof(NavMeshAgent))]
    [RequireComponent(typeof(ThirdPersonCharacter))]
    public class SlenderManChase : ChasingBase
    {
        float radius = 2;
        float time = 0;

        private void Teleport()
        {
            Transform player = GetPlayer().transform;
            Vector3 spawnPos = new Vector3(UnityEngine.Random.Range(player.position .x - 20.0F, player.position.x + 20.0F), player.position.y+2, UnityEngine.Random.Range(player.position.z - 20.0F, player.position.z + 20.0F));
            if (Physics.CheckSphere(spawnPos, radius))
            {

            }
            else
            {
                transform.position = spawnPos;
                time = 0;
            }
        }

        // Update is called once per frame
        protected override void RealUpdate(GameObject player)
        {
            Transform target = player.transform;

            if (target != null)
            {
                time += Time.deltaTime;
                if (time > 5)
                {
                    Teleport();
                }
                agent.SetDestination(target.position);
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