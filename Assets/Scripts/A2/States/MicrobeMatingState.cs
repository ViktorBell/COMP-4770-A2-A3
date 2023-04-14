using A2.Actions;
using A2.Sensors;
using EasyAI;
using UnityEngine;

namespace A2.States
{
    /// <summary>
    /// State for microbes that are seeking a mate.
    /// </summary>
    [CreateAssetMenu(menuName = "A2/States/Microbe Mating State", fileName = "Microbe Mating State")]
    public class MicrobeMatingState : State
    {
        [SerializeField] private float randomRoamingDistance = 10.0f;
        [SerializeField] private float roamingUpdateInterval = 2.0f;
        private float roamingTimer;
        public override void Enter(Agent agent)
        {
            // TODO - Assignment 2 - Complete this state. Have microbes look for mates and reproduce.
            agent.Log("Beginning Search for Mate");
            roamingTimer = roamingUpdateInterval; // Initialize the timer to update roaming point immediately
        }

        public override void Execute(Agent agent)
        {
            // TODO - Assignment 2 - Complete this state. Have microbes look for mates and reproduce.
            Microbe potentialMateMicrobe = agent.Sense<NearestMateSensor, Microbe>();

            // If a potential mate was sensed perform the 'Mate' action
            if (potentialMateMicrobe != null)
            {
                // Sets a mating pair of microbes
                agent.GetComponent<Microbe>().AttractMate(potentialMateMicrobe);
                //agent.Move(potentialMateMicrobe.transform.position);
                agent.Move(potentialMateMicrobe.transform, EasyAI.Navigation.Steering.Behaviour.Pursue);
                agent.Act(new MateAction(agent.GetComponent<Microbe>(), potentialMateMicrobe));

            }
            else
            {
                agent.Log("Roaming around to hopefully encoutner a mate");

                roamingTimer -= Time.deltaTime; // Decrease the timer by elapsed time

                if (roamingTimer <= 0)
                {
                    roamingTimer = roamingUpdateInterval; // Reset the timer

                    Vector3 currentPosition = agent.transform.position;
                    float roamingPositionX = UnityEngine.Random.Range(currentPosition.x - randomRoamingDistance, currentPosition.x + randomRoamingDistance);
                    float roamingPositionZ = UnityEngine.Random.Range(currentPosition.z - randomRoamingDistance, currentPosition.z + randomRoamingDistance);

                    Vector3 roamingPoint = new Vector3(roamingPositionX, 0, roamingPositionZ);
                    agent.Move(roamingPoint);
                }
            }
            
        }

        public override void Exit(Agent agent)
        {
            // TODO - Assignment 2 - Complete this state. Have microbes look for mates and reproduce.
            agent.Log("Mating Completed");
        }
    }
}