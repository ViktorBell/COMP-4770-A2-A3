using EasyAI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace A1
{
    public class WormHoleVacuumActuator : Actuator
    {
        private FloorListWrapper areaToBeCleaned;
        private float cleanDistance = 20; //Should be the length of the vacuum's actuator 'tentacles' such that the cleaning will only occur once the worm hole is aligned at the center of the area it is going to clean
        public override bool Act(object agentAction)
        {
            //Didn't seem to do anything
            if (agentAction == null) { 
                return false;
            }


            if (agentAction is not FloorListWrapper)
            {
                return false;
            }
            else
            {
                //agentAction = agentAction as FloorListWrapper;
                areaToBeCleaned = (FloorListWrapper)agentAction;

                /*
                if (Vector3.Distance(Agent.transform.position, areaToBeCleaned.targetDirtyFloorSection.position) > cleanDistance)
                {
                    Log("Not close enough to clean this section of floor");
                    return false;
                }
                */

                Log("Successfully cleaned the floor section: " + areaToBeCleaned.floorTileList);
                foreach (Floor dirtyFloorTile in areaToBeCleaned.filthiestFloorSection)
                {

                    dirtyFloorTile.WormHoleClean();


                }



            }



            return true;
        }
    }
}
