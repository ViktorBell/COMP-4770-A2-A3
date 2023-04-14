using A1;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class FloorListWrapper
{
    public List<Floor> floorTileList; //stores a list of floor tiles that comprise the entire floor environment
    public List<Floor> filthiestFloorSection; //This will be an array of 4 floor tiles that will be set based on the dirtiest 4 tiles of the whole floor; this is the list that will be cleaned by the wormhole vacuum actuator
    public Transform targetDirtyFloorSection; //The position of the dirtiest 4 tiles which the vacuum should move to

    public FloorListWrapper() {
        floorTileList = new List<Floor>();
        filthiestFloorSection = new List<Floor>();
        targetDirtyFloorSection = null;
    }

    //Sets the floorList of this object to the entire floor that makes up the 'Environment'
    public void setFloorTileList() {

        floorTileList = CleanerManager.Floors;
    
    }

    //Sets the filthiestFloorSection List to the dirtiest section of the floor (the input list is calculated in the dirt sensor and then set with this function)
    public void setDirtiestAreaList(List<Floor> dirtiestFloorSection) { 
        
        filthiestFloorSection = dirtiestFloorSection;
    
    }

    //Sets the transform that will be used to move the agent to the dirtiest area which needs to be cleaned
    public void setLocationToBeCleaned() { 
        
        targetDirtyFloorSection = filthiestFloorSection[0].transform;// Should be set to the center of the 4 square area but currently just goes to the 1st sqaure in the area
    
    }

    
 
}
