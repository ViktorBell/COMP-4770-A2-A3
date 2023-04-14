using EasyAI;
using System.ComponentModel.Composition;
using UnityEngine;

namespace A2.States
{
    /// <summary>
    /// The global state which microbes are always in.
    /// </summary>
    [CreateAssetMenu(menuName = "A2/States/Microbe Mind", fileName = "Microbe Mind")]
    public class MicrobeMind : State
    {
        public override void Execute(Agent agent)
        {
            // TODO - Assignment 2 - Complete the mind of the microbes.

            // Get the microbe component of the agent 
            Microbe microbe = agent.GetComponent<Microbe>();
            

            // Do nothing if not a microbe
            if (microbe == null)
            {
                return;
            }
            // Causes Microbes to prioritize pickups
            /*
            if (!microbe.HasPickup)
            {
                agent.SetState<MicrobeSeekingPickupState>();
            }
            */
            // Survival is always the most primary concern so if an agent is being hunted then it should drop everything and RUN!
            if (microbe.BeingHunted)
            {
                agent.SetState<MicrobeHuntedState>();
                return;
            }
            // If the microbe is not pursuing a pick it should try and find the nearest one and take it as it is likely to provide a significant advantage
            
            else if (!microbe.HasPickup)
            {
                agent.SetState<MicrobeSeekingPickupState>();
            }
           

            // If Hunger level is above hunger threshold switch into the MicrobeHungryState and find prey to eat
            else if (microbe.IsHungry)
            {
                agent.SetState<MicrobeHungryState>();
                return;
            }

            // If the Microbe has not mated yet and is an adult then switch into the MicrobeMatingState
            else if (!microbe.DidMate && microbe.IsAdult)
            {

                agent.SetState<MicrobeMatingState>();
                return;


            }
            // If the Microbe has no other priorities at present then go into the RoamingState and roam around randomly until a goal/priority based State is triggered
            else {
                //agent.SetState<MicrobeSeekingPickupState>(); //When this line is active and replaces the RoamingState default below then all microbes constantly go after pickups when not being hunted or trying to mate
                agent.SetState<MicrobeRoamingState>();
            }
          


        }
    }
}