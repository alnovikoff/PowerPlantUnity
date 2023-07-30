using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using static BuildingManager;

public class BlockOne : AbstractBuilding
{
    public int[] disckAmount;
    public int[] eco;


    public override void OnBuildingEvent()
    {
        base.OnBuildingEvent();
        DataManager.gameData.block1Level = level;
        DataManager.gameData.block1State = (int)currentBuildingState;
        SaveBuildingData();
    }

    public override void SwitchState(BuildingState buildingState)
    {
        base.SwitchState(buildingState);
        DataManager.gameData.block1State = (int)currentBuildingState;
        SaveBuildingData();
    }

    public override  void OnManagerSet(int managerId)
    {
        base.OnManagerSet(managerId);
        DataManager.gameData.block1Manager = managerID;
        SaveBuildingData();
    }
}
