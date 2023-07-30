using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static BuildingManager;

public class CoolingTower : AbstractBuilding
{
    public int[] throughput;
    public int[] efficiency;

    public override void OnBuildingEvent()
    {
        base.OnBuildingEvent();
        DataManager.gameData.coolingTowerLevel = level;
        DataManager.gameData.coolingTowerState = (int)currentBuildingState;
        SaveBuildingData();
    }

    public override void SwitchState(BuildingState buildingState)
    {
        base.SwitchState(buildingState);
        DataManager.gameData.coolingTowerState = (int)currentBuildingState;
        SaveBuildingData();
    }

    public override void OnManagerSet(int managerId)
    {
        base.OnManagerSet(managerId);
        DataManager.gameData.coolingTowerManager = managerID;
        SaveBuildingData();
    }
}
