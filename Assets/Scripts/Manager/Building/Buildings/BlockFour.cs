using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static BuildingManager;

public class BlockFour: AbstractBuilding
{
    public int[] disckAmount;
    public int[] eco;

    public override void OnBuildingEvent()
    {
        base.OnBuildingEvent();
        DataManager.gameData.block4Level = level;
        DataManager.gameData.block4State = (int)currentBuildingState;
        SaveBuildingData();
    }

    public override void SwitchState(BuildingState buildingState)
    {
        base.SwitchState(buildingState);
        DataManager.gameData.block4State = (int)currentBuildingState;
        SaveBuildingData();
    }

    public override void OnManagerSet(int managerId)
    {
        base.OnManagerSet(managerId);
        DataManager.gameData.block4Manager = managerID;
        SaveBuildingData();
    }
}
