using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static BuildingManager;

public class TrainDocks : AbstractBuilding
{
    public int[] trainAmount;
    public int[] efficiency;
    public int available;

    public override void OnBuildingEvent()
    {
        base.OnBuildingEvent();
        DataManager.gameData.trainDockLevel = level;
        DataManager.gameData.trainDockState = (int)currentBuildingState;
        SaveBuildingData();
    }

    public override void SwitchState(BuildingState buildingState)
    {
        base.SwitchState(buildingState);
        DataManager.gameData.trainDockState = (int)currentBuildingState;
        SaveBuildingData();
    }

    public override void OnManagerSet(int managerId)
    {
        base.OnManagerSet(managerId);
        DataManager.gameData.trainDockManager = managerID;
        SaveBuildingData();
    }
}
