using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static BuildingManager;

public class Security : AbstractBuilding
{
    public int[] efficiency;
    public int[] security;

    public override void OnBuildingEvent()
    {
        base.OnBuildingEvent();
        DataManager.gameData.securityLevel = level;
        DataManager.gameData.securityState = (int)currentBuildingState;
        SaveBuildingData();
    }

    public override void SwitchState(BuildingState buildingState)
    {
        base.SwitchState(buildingState);
        DataManager.gameData.securityState = (int)currentBuildingState;
        SaveBuildingData();
    }

    public override void OnManagerSet(int managerId)
    {
        base.OnManagerSet(managerId);
        DataManager.gameData.securityManager = managerID;
        SaveBuildingData();
    }
}
