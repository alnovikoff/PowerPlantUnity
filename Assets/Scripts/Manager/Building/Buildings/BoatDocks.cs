using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static BuildingManager;

public class BoatDocks : AbstractBuilding
{
    public int[] boatAmount;
    public int[] efficiency;
    public int available;

    public override void OnBuildingEvent()
    {
        base.OnBuildingEvent();
        DataManager.gameData.boatDockLevel = level;
        DataManager.gameData.boatDockState = (int)currentBuildingState;
        SaveBuildingData();
    }

    public override void SwitchState(BuildingState buildingState)
    {
        base.SwitchState(buildingState);
        DataManager.gameData.boatDockState = (int)currentBuildingState;
        SaveBuildingData();
    }

    public override void OnManagerSet(int managerId)
    {
        base.OnManagerSet(managerId);
        DataManager.gameData.boatDockManager = managerID;
        SaveBuildingData();
    }
}
