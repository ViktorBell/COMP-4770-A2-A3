using A2.Actions;
using EasyAI;
using T2.Actions;
using UnityEngine;

namespace A2.Actuators
{
    /// <summary>
    /// Actuator to make a Microbe hunt its prey. Move to target microbe position and then eat if possible.
    /// </summary>
    [DisallowMultipleComponent]
    public class HuntingActuator : Actuator
    {
        /// <summary>
        /// Move to target microbe position and then eat if possible.
        /// </summary>
        /// <param name="agentAction">The action to perform.</param>
        /// <returns>Always true as this is done instantly and can never fail.</returns>
        public override bool Act(object agentAction)
        {

            // If the Microbe is hunting prey because it is hungry the following will set the target microbe appropriately and commence the hunt
            if (agentAction is HuntPreyAction){ 

                HuntPreyAction hunterMicrobe = (HuntPreyAction)agentAction;

                //hunterMicrobe.HunterMicrobe.StartHunting(hunterMicrobe.TargetMicrobe);

                if (hunterMicrobe.HunterMicrobe.HasTarget) {

                    //hunterMicrobe.HunterMicrobe.Move(hunterMicrobe.TargetMicrobe.transform.position);
                    
                    hunterMicrobe.HunterMicrobe.Eat();
                    

                
                }
                


            }

            return true;
        }
    }
}