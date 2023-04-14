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
    public class MatingActuator : Actuator
    {
        /// <summary>
        /// Move to target microbe position and then eat if possible.
        /// </summary>
        /// <param name="agentAction">The action to perform.</param>
        /// <returns>Always true as this is done instantly and can never fail.</returns>
        public override bool Act(object agentAction)
        {

            // If the Microbe is searching for a mate because it is has not yet mated and is of reproductive age the following will set the target microbe to an appropriate potential mate and attempt to reproduce
            if (agentAction is MateAction)
            {

                MateAction interestedMicrobe = (MateAction)agentAction;


                if (interestedMicrobe.InterestedMicrobe.HasTarget)
                {



                    interestedMicrobe.InterestedMicrobe.Mate();


                }



            }

            return true;
        }
    }
}