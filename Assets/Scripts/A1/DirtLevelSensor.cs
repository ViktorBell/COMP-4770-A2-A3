using A1;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace EasyAI
{


    public class DirtLevelSensor : Sensor
    {


        private int highest4SqFilthScore;
        private int currentFilthScore;

        FloorListWrapper filthiest4SqArea;

        private bool dirtiestAreaDetermined;

        //
        public override object Sense()
        {

            filthiest4SqArea = new FloorListWrapper();
            filthiest4SqArea.setFloorTileList();

            foreach (Floor tile in filthiest4SqArea.floorTileList) { Debug.Log("Sensor List Tiles: " + tile); } //The list appears to be correctly and completely populated at this point

            filthiest4SqArea = DetermineDirtiestArea();
            

            return filthiest4SqArea;
        }




        /* Analyzes the entire Floor to determine which 4 square area is the dirtiest; Worse Case 4 square Filth Score = 16 pts
        * Returns a FloorListWrapper with it's filthiestFloorSection List & targetDirtyFloorSection Transform populated with the dirtiest section found 
        */

        private FloorListWrapper DetermineDirtiestArea()
        {

            highest4SqFilthScore = 0; //Resets highest filth score

            Floor dirtiest4sqArea = filthiest4SqArea.floorTileList[0];

            Vector2 floorDimensions = FindObjectOfType<CleanerManager>().GetFloorSize();

            Debug.Log("Floor Size: " + floorDimensions);//Has the correct size of floor

            dirtiestAreaDetermined = false;

            for (int floorX = 0; floorX <= (floorDimensions.x * floorDimensions.y - floorDimensions.x * 2); floorX += 5)
            {
                Debug.Log("Floor Size X: " + floorDimensions.x);
                

                for (int floorY = 0; floorY < floorDimensions.y - 1; floorY++)
                {
                    Debug.Log("Floor Size Y: " + floorDimensions.y);
                    /* This should be incrementing the current index so that the floor analysis can progress from the 1st tile to the search end point but I think there isn't enough time for the algorithm to finish 
                     * determining the dirtiest area before another scan request comes in and interrupts the current one
                     * 
                     */ 
                    int currentTileIndex = floorX + floorY; 

                    Debug.Log("floorX & floorY: " + floorX + ", " + floorY);

                    Debug.Log("Current Tile Index: " + currentTileIndex);

                    //This check is essentially useless was just using it to try and troubleshoot Index out of Range Error
                    if (filthiest4SqArea.floorTileList == null)
                    {
                        return null;
                    }
                    else
                    {
                        Debug.Log("Filthiest 4 Sq Area list: " + filthiest4SqArea.floorTileList); //The floor is correctly here at this point

                        List<Floor> fourSqFloorSection = new List<Floor>();
                        fourSqFloorSection.Add(filthiest4SqArea.floorTileList[currentTileIndex]); //Adds the initial tile of the 4 sq space to be analyzed
                        fourSqFloorSection.Add(filthiest4SqArea.floorTileList[currentTileIndex + 1]); //Adds the upward adjacent tile
                        fourSqFloorSection.Add(filthiest4SqArea.floorTileList[currentTileIndex + 5]); //Adds the right adjacent tile
                        fourSqFloorSection.Add(filthiest4SqArea.floorTileList[currentTileIndex + 6]); //Adds the right diagonal tile

                        currentFilthScore = 0; //Resets current filth score

                        //Tallies up the total filth score for the 4sq area currently being analyzed
                        foreach (Floor floorTile in fourSqFloorSection)
                        {

                            CalcTileFilthScore(floorTile); //Updates the currentFilthScore for the square of tiles being analyzed


                        }
                        //Sets the origin tile of the dirtiest 4 sq area if the filth score just calculated is greater than the fourSqFilthScore
                        if (currentFilthScore > highest4SqFilthScore)
                        {

                            highest4SqFilthScore = currentFilthScore;

                            //Creates a new FloorListWrapper and populates its floor list witht the dirtest section discovered thus far. This value is eventually passed to the cleaning actuator to be dealt with
                            filthiest4SqArea = new FloorListWrapper();

                            filthiest4SqArea.setDirtiestAreaList(fourSqFloorSection);

                            filthiest4SqArea.setLocationToBeCleaned();

                        }
                        fourSqFloorSection.Clear();
                    }


                }

            }
            dirtiestAreaDetermined = true;
            return filthiest4SqArea;

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







    }//End of Class

    



}

