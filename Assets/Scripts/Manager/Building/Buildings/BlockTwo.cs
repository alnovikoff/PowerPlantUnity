using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static BuildingManager;

public class BlockTwo : AbstractBuilding
{
    public float[] totalBlockPower;
    public float[] maxBlockPower;
    public float[] totalOwenPower;
    public float[] maxOwenPower;
    public int[] disckAmount;
    public int[] eco;

    public override void OnBuildingEvent()
    {
        base.OnBuildingEvent();
        DataManager.gameData.block2Level = level;
        DataManager.gameData.block2State = (int)currentBuildingState;
        SaveSystem.Save(DataManager.gameData);
    }

    public override void SwitchState(BuildingState buildingState)
    {
        base.SwitchState(buildingState);
        DataManager.gameData.block2State = (int)currentBuildingState;
        SaveSystem.Save(DataManager.gameData);
    }
}
