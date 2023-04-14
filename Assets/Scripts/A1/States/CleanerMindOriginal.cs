using EasyAI;
using System.Collections.Generic;
using UnityEngine;

namespace A1.States
{
    /// <summary>
    /// The global state which the cleaner is always in.
    /// </summary>
    [CreateAssetMenu(menuName = "A1/States/Cleaner Mind", fileName = "Cleaner Mind")]
    public class CleanerMindOriginal : State
    {

        private int fourSqFilthScore;
        private int currentFilthScore;
        private FloorListWrapper dirtiest4SqSection;

        private bool dirtiestAreaDetermined;

        //A list containing the current tiles that comprise the floor environment
        private List<Floor> currentFloorEnvironment;


        public override void Execute(Agent agent)
        {
            // TODO - Assignment 1 - Complete the mind of this agent along with any sensors and actuators you need.

            //Uses the DirtLevelSensor of the agent to populate a list of the current floor tiles that compose the 'Environment'
            currentFloorEnvironment = agent.Sense<DirtLevelSensor, FloorListWrapper>().floorTileList;

            Vector3 dirtyAreaToClean = DetermineDirtiestArea();

            if (dirtiestAreaDetermined)
            {
                agent.Move(dirtyAreaToClean);
                agent.Act(dirtiest4SqSection);
            }


        }


        /* Analyzes the currentFloorEnvironment to determine which 4 square area is the dirtiest; Worse Case 4 square Filth Score = 16 pts
         * Returns the position of the dirtiest area of the floor 
         */ 

        private Vector3 DetermineDirtiestArea()
        {
            fourSqFilthScore = 0;

            Floor dirtiest4sqArea = currentFloorEnvironment[0];

            Vector2 floorDimensions = FindObjectOfType<CleanerManager>().GetFloorSize();

            dirtiestAreaDetermined = false;

            for (int floorX = 0; floorX <= (floorDimensions.x*floorDimensions.y - floorDimensions.x*2); floorX += 5)
            {

                for (int floorY = 0; floorY < floorDimensions.y - 1; floorY++)
                {

                    int currentTileIndex = floorX + floorY;

                    List<Floor> fourSqFloorSection = new List<Floor>();
                    fourSqFloorSection.Add(currentFloorEnvironment[currentTileIndex]); //Adds the initial tile of the 4 sq space to be analyzed
                    fourSqFloorSection.Add(currentFloorEnvironment[currentTileIndex + 1]); //Adds the upward adjacent tile
                    fourSqFloorSection.Add(currentFloorEnvironment[currentTileIndex + 5]); //Adds the right adjacent tile
                    fourSqFloorSection.Add(currentFloorEnvironment[currentTileIndex + 6]); //Adds the right diagonal tile

                    currentFilthScore = 0; //Resets current filth score

                    //Tallies up the total filth score for the 4sq area currently being analyzed
                    foreach (Floor floorTile in fourSqFloorSection) {
                        
                        CalcTileFilthScore(floorTile);

                        
                    }
                    //Sets the origin tile of the dirtiest 4 sq area if the filth score just calculated is greater than the fourSqFilthScore
                    if (currentFilthScore > fourSqFilthScore) {

                        dirtiest4sqArea = fourSqFloorSection[0];

                        //Creates a new FloorListWrapper and populates its floor list witht the dirtest section discovered thus far. This value is eventually passed to the cleaning actuator to be dealt with
                        dirtiest4SqSection = new FloorListWrapper();
                        dirtiest4SqSection.setDirtiestAreaList(fourSqFloorSection);
                    
                    }
                    fourSqFloorSection.Clear();


                }

            }
            dirtiestAreaDetermined = true;
            return dirtiest4sqArea.transform.position;

        }



        //Calculates the filth score for an individual floor tile based on it's dirty level and whether it is likely to get dirty
        private void CalcTileFilthScore(Floor currentTile)
        {
            

            if (currentTile.State == Floor.DirtLevel.Clean && !currentTile.LikelyToGetDirty)
            {
                currentFilthScore++;
            }
            else if (currentTile.State > Floor.DirtLevel.Clean)
            {

                //Increases the filth score appropriately according to the DirtLevel of the floor tile
                switch (currentTile.State)
                {

                    case Floor.DirtLevel.Dirty:
                        currentFilthScore += 2;
                        break;

                    case Floor.DirtLevel.VeryDirty:
                        currentFilthScore += 3;
                        break;

                    case Floor.DirtLevel.ExtremelyDirty:
                        currentFilthScore += 4;
                        break;

                }




            }
        }

        //Calcualtes the 'Filth Score' of a 4 square area based on the current floor tile. Worse Case Filth Score = 16 pts
        private void Calc4SqDirtLevel(Floor currentTile)
        {



        }






    }
}
