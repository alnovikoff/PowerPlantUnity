using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static BuildingManager;

public class BlockTwo : AbstractBuilding
{
    public int[] disckAmount;
    public int[] eco;

    public override void OnBuildingEvent()
    {
        base.OnBuildingEvent();
        DataManager.gameData.block2Level = level;
        DataManager.gameData.block2State = (int)currentBuildingState;
        SaveBuildingData();
    }

    public override void SwitchState(BuildingState buildingState)
    {
        base.SwitchState(buildingState);
        DataManager.gameData.block2State = (int)currentBuildingState;
        SaveBuildingData();
    }

    public override void OnManagerSet(int managerId)
    {
        base.OnManagerSet(managerId);
        DataManager.gameData.block2Manager = managerID;
        SaveBuildingData();
    }
}
