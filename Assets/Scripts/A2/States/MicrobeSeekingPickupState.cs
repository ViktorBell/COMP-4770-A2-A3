using A2.Pickups;
using A2.Sensors;
using EasyAI;
using UnityEngine;

namespace A2.States
{
    /// <summary>
    /// State for microbes that are seeking a pickup.
    /// </summary>
    [CreateAssetMenu(menuName = "A2/States/Microbe Seeking Pickup State", fileName = "Microbe Seeking Pickup State")]
    public class MicrobeSeekingPickupState : State
    {


        public override void Enter(Agent agent)
        {
            // TODO - Assignment 2 - Complete this state. Have microbes look for pickups.
            agent.Log("Heading for a PickUp!");
        }
        
        // Find nearest pickup and make a B-Line straight for it
        public override void Execute(Agent agent)
        {
            // TODO - Assignment 2 - Complete this state. Have microbes look for pickups.
            MicrobeBasePickup pickup = agent.Sense<NearestPickupSensor, MicrobeBasePickup>();

            if (pickup != null) {

                agent.Log("Actively on Route to PickUp!");

                agent.GetComponent<Microbe>().SetPickup(pickup);
                agent.Move(pickup.transform.position);


            }

            


        }
        
        public override void Exit(Agent agent)
        {
            // TODO - Assignment 2 - Complete this state. Have microbes look for pickups.
            agent.Log("No more time for PickUp Seeking.");
        }
    }
}