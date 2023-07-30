using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static BuildingManager;

public class BlockThree: AbstractBuilding
{
    public int[] disckAmount;
    public int[] eco;

    public override void OnBuildingEvent()
    {
        base.OnBuildingEvent();
        DataManager.gameData.block3Level = level;
        DataManager.gameData.block3State = (int)currentBuildingState;
        SaveBuildingData();
    }

    public override void SwitchState(BuildingState buildingState)
    {
        base.SwitchState(buildingState);
        DataManager.gameData.block3State = (int)currentBuildingState;
        SaveBuildingData();
    }

    public override void OnManagerSet(int managerId)
    {
        base.OnManagerSet(managerId);
        DataManager.gameData.block3Manager = managerID;
        SaveBuildingData();
    }
}
