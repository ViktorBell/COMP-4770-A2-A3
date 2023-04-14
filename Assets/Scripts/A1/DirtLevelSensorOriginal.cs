using A1;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace EasyAI 
{
    public class DirtLevelSensorOriginal : Sensor
    {
        //
        public override object Sense()
        {

            FloorListWrapper currentFloorEnvironment = new FloorListWrapper();
            currentFloorEnvironment.setFloorTileList();

            return currentFloorEnvironment;
        }
    }




}

