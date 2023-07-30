using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static BuildingManager;

public class FuelStorage : AbstractBuilding
{
    public int[] volume;
    public int occupancy;
    public int quality;

    public override void OnBuildingEvent()
    {
        base.OnBuildingEvent();
        DataManager.gameData.fuelStorageLevel = level;
        DataManager.gameData.fuelStorageState = (int)currentBuildingState;
        SaveBuildingData();
    }

    public override void SwitchState(BuildingState buildingState)
    {
        base.SwitchState(buildingState);
        DataManager.gameData.fuelStorageState = (int)currentBuildingState;
        SaveBuildingData();
    }

    public override void OnManagerSet(int managerId)
    {
        base.OnManagerSet(managerId);
        DataManager.gameData.fuelStorageManager = managerID;
        SaveBuildingData();
    }
}
