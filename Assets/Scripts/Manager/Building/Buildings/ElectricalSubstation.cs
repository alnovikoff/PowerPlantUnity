using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static BuildingManager;

public class ElectricalSubstation : AbstractBuilding
{
    public int[] loss;
    public int[] load;

    public override void OnBuildingEvent()
    {
        base.OnBuildingEvent();
        DataManager.gameData.electricalSubstationLevel = level;
        DataManager.gameData.electricalSubstationState = (int)currentBuildingState;
        SaveBuildingData();
    }

    public override void SwitchState(BuildingState buildingState)
    {
        base.SwitchState(buildingState);
        DataManager.gameData.electricalSubstationState = (int)currentBuildingState;
        SaveBuildingData();
    }

    public override void OnManagerSet(int managerId)
    {
        base.OnManagerSet(managerId);
        DataManager.gameData.electricalSubstationManager = managerID;
        SaveBuildingData();
    }
}
