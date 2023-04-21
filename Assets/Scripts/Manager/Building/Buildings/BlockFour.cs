using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static BuildingManager;

public class BlockFour: AbstractBuilding
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
        DataManager.gameData.block4Level = level;
        DataManager.gameData.block4State = (int)currentBuildingState;
        SaveSystem.Save(DataManager.gameData);
    }

    public override void SwitchState(BuildingState buildingState)
    {
        base.SwitchState(buildingState);
        DataManager.gameData.block4State = (int)currentBuildingState;
        SaveSystem.Save(DataManager.gameData);
    }
}
