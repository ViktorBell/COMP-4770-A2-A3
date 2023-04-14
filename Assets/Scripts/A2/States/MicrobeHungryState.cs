using A2.Sensors;
using EasyAI;
using UnityEngine;
using A2.Actions;
using EasyAI.Navigation;

namespace A2.States
{
    /// <summary>
    /// State for microbes that are hungry and wanting to seek food.
    /// </summary>
    [CreateAssetMenu(menuName = "A2/States/Microbe Hungry State", fileName = "Microbe Hungry State")]
    public class MicrobeHungryState : State
    {
        [SerializeField] private float randomRoamingDistance = 10.0f;
        [SerializeField] private float roamingUpdateInterval = 2.0f;
        private float roamingTimer;

        public override void Enter(Agent agent)
        {
            agent.Log("Beginning Search for Prey to Eat");
            roamingTimer = roamingUpdateInterval; // Initialize the timer to update roaming point immediately
        }

        public override void Execute(Agent agent)
        {
            // TODO - Assignment 2 - Complete this state. Have microbes search for other microbes to eat.
            Microbe targetMicrobe = agent.Sense<NearestPreySensor, Microbe>();

            // If a target microbe was sensed perform the 'HuntPrey' action
            if (targetMicrobe != null)
            {
                agent.GetComponent<Microbe>().StartHunting(targetMicrobe);
                //agent.Move(targetMicrobe.transform.position);
                agent.Move(targetMicrobe.transform, Steering.Behaviour.Pursue);
                agent.Act(new HuntPreyAction(agent.GetComponent<Microbe>(), targetMicrobe));

            }
            else
            {
                agent.Log("Roaming around to find food");

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
            // TODO - Assignment 2 - Complete this state. Have microbes search for other microbes to eat.
            agent.Log("Completed The Hunt");
        }
    }
}