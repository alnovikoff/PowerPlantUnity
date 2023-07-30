using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static BuildingManager;

public class CoalStorage : AbstractBuilding
{
    public int[] volume;
    public int occupancy;
    public int quality;

    public override void OnBuildingEvent()
    {
        base.OnBuildingEvent();
        DataManager.gameData.coalStorageLevel = level;
        DataManager.gameData.coalStorageState = (int)currentBuildingState;
        SaveBuildingData();
    }

    public override void SwitchState(BuildingState buildingState)
    {
        base.SwitchState(buildingState);
        DataManager.gameData.coalStorageState = (int)currentBuildingState;
        SaveBuildingData();
    }

    public override void OnManagerSet(int managerId)
    {
        base.OnManagerSet(managerId);
        DataManager.gameData.coalStorageManager = managerID;
        SaveBuildingData();
    }
}
