using A2.Actions;
using A2.Sensors;
using EasyAI;
using EasyAI.Navigation;
using UnityEngine;

namespace A2.States
{
    /// <summary>
    /// State for microbes that are being hunted.
    /// </summary>
    [CreateAssetMenu(menuName = "A2/States/Microbe Hunted State", fileName = "Microbe Hunted State")]
    public class MicrobeHuntedState : State
    {
        public override void Enter(Agent agent)
        {
            // TODO - Assignment 3 - Complete this state. Add the ability for microbes to evade hunters.
            agent.Log("I'm being hunted!");
        }

        public override void Execute(Agent agent)
        {

            agent.Log("They're After Me!!! RUN AWAY!");

            Microbe huntedMicrobe = (Microbe)agent;

            // If a microbe has been targeted by a hunter evade to get away otherwise their pursuer will eat this microbe
            if (huntedMicrobe.BeingHunted)
            {
                agent.Move(huntedMicrobe.Hunter.transform, Steering.Behaviour.Evade);

            }
   


        }



        public override void Exit(Agent agent)
        {
            // TODO - Assignment 3 - Complete this state. Add the ability for microbes to evade hunters.

            if (!agent.GetComponent<Microbe>().BeingHunted) {
                agent.Log("No longer being hunted.");
            }
           
        }
    }
}