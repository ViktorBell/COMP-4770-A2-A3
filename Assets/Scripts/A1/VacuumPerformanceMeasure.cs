using A1;
using EasyAI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[DisallowMultipleComponent]
public class VacuumPerformanceMeasure : PerformanceMeasure
{
        /* filthinessOfEnvironment is the Performance Measure for the Vacuum Cleaner Agent
     * The closer to 0 the better the performance,where 0 indicates a completely clean floor (perfect performance = no dirt)
     * 
     * Points per Tile:
     * Squeaky Clean (Shiny White) = 0 pts
     * Normal Clean (Gray) = 1 pt
     * Dirty (Light Brown)  = 2 pts
     * Very Dirty (Medium Brown) = 3 pts
     * Extremely Dirty (Dark Brown) = 4 pts
     * 
     * Worst Case = numTiles * 4
     */

        public override float CalculatePerformance()
        {

            float filthinessOfEnvironment = 0;

            foreach (Floor tile in CleanerManager.Floors)
            {

                //If Floor tile is clean but is not 'squeaky' clean then 1 pt is added to the filth score
                if (tile.State == Floor.DirtLevel.Clean && !tile.LikelyToGetDirty)
                {

                    filthinessOfEnvironment++;
                }
                else if (tile.State > Floor.DirtLevel.Clean)
                {

                    //Increases the filth score appropriately according to the DirtLevel of the floor tile
                    switch (tile.State)
                    {

                        case Floor.DirtLevel.Dirty:
                            filthinessOfEnvironment += 2;
                            break;

                        case Floor.DirtLevel.VeryDirty:
                            filthinessOfEnvironment += 3;
                            break;

                        case Floor.DirtLevel.ExtremelyDirty:
                            filthinessOfEnvironment += 4;
                            break;

                    }

                }


            }



            return 100 - filthinessOfEnvironment;
        }

}
