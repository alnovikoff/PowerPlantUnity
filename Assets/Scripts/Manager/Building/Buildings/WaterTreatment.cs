using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static BuildingManager;

public class WaterTreatment : AbstractBuilding
{
    public int[] throughput;
    public int[] efficiency;

    public override void OnBuildingEvent()
    {
        base.OnBuildingEvent();
        DataManager.gameData.waterTreatmentLevel = level;
        DataManager.gameData.block1State = (int)currentBuildingState;
        SaveBuildingData();
    }

    public override void SwitchState(BuildingState buildingState)
    {
        base.SwitchState(buildingState);
        DataManager.gameData.waterTreatmentState = (int)currentBuildingState;
        SaveBuildingData();
    }

    public override void OnManagerSet(int managerId)
    {
        base.OnManagerSet(managerId);
        DataManager.gameData.waterTreatmentManager = managerID;
        SaveBuildingData();
    }
}
