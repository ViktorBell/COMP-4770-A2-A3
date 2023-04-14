using EasyAI;
using UnityEngine;


namespace A2.States
{
    /// <summary>
    /// Roaming state for the microbe, doesn't have any actions and only logs messages.
    /// </summary>
    [CreateAssetMenu(menuName = "A2/States/Microbe Roaming State", fileName = "Microbe Roaming State")]
    public class MicrobeRoamingState : State
    {

        [SerializeField] private float randomRoamingDistance = 10.0f;
        [SerializeField] private float roamingUpdateInterval = 2.0f;
        private float roamingTimer;

        public override void Enter(Agent agent)
        {
            // TODO - Assignment 2 - Complete this state. Have microbes randomly roam around.
            agent.Log("Beginning to Roam Around");


            Microbe roamingMicrobe = agent.GetComponent<Microbe>();
            // TODO - Assignment 2 - Complete this state. Have microbes randomly roam around.
            agent.Log("Roaming");

           // Sets a point for the agent to roam to
            Vector3 currentPosition = roamingMicrobe.transform.position;
            float roamingPositionX = UnityEngine.Random.Range(currentPosition.x - randomRoamingDistance, currentPosition.x + randomRoamingDistance);
            float roamingPositionZ = UnityEngine.Random.Range(currentPosition.z - randomRoamingDistance, currentPosition.z + randomRoamingDistance);

            Vector3 roamingPoint = new Vector3(roamingPositionX, 0, roamingPositionZ);

            agent.Move(roamingPoint);

            return;

        }

        public override void Execute(Agent agent)
        {

            //return;

            agent.Log("Just Roaming Around");

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
        
        public override void Exit(Agent agent)
        {
            // TODO - Assignment 2 - Complete this state. Have microbes randomly roam around.
            agent.Log("Done Roaming, I have better things to do with my life than mozy around all day.");
        }
    }
}