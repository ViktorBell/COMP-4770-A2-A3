using EasyAI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;
using static UnityEngine.UIElements.UxmlAttributeDescription;

namespace A1.States
{
    /// <summary>
    /// The global state which the cleaner is always in.
    /// </summary>
    [CreateAssetMenu(menuName = "A1/States/Cleaner Mind", fileName = "Cleaner Mind")]
    public class CleanerMind : State
    {

        
        private FloorListWrapper dirtiest4SqSection = new FloorListWrapper();



        public override void Execute(Agent agent)
        {
            // TODO - Assignment 1 - Complete the mind of this agent along with any sensors and actuators you need.

            //dirtiest4SqSection = new FloorListWrapper();

            //Should simply return if the agent already has a FloorListWrapper action
            if (agent.HasAction<FloorListWrapper>()) { 
                return;
            }
            //If there has not been a transform set in the dirtiest4SqSection FloorListWrapper then the agent should execute the floor scan co-routine
            if (dirtiest4SqSection.targetDirtyFloorSection == null)
            {

                PerformFloorScan(agent);



            }
            else {

                agent.Move(dirtiest4SqSection.targetDirtyFloorSection.position);

            }
            
            agent.Act(dirtiest4SqSection);


            /*
            else
            {
                agent.Move(dirtiest4SqSection.targetDirtyFloorSection.position);
                agent.Act(dirtiest4SqSection);
            }
            */




            /*
            if (dirtiest4SqSection.targetDirtyFloorSection == null) {

                dirtiest4SqSection = agent.Sense<DirtLevelSensor, FloorListWrapper>();
            }
            else
            {
                agent.Move(dirtiest4SqSection.targetDirtyFloorSection.position);
                agent.Act(dirtiest4SqSection);
            }
            */
        }

        //A Coroutine which will trigger the vacuum agents Sense function utilizing the DirtLevel Sensor and returning a Floor
        IEnumerator PerformFloorScan(Agent vacuumAgent) {

            dirtiest4SqSection = vacuumAgent.Sense<DirtLevelSensor, FloorListWrapper>();

            yield return new WaitForSeconds(3.0f);
        }



            


    }
}
