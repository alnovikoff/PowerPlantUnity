using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading;
using UnityEngine;
using static BuildingManager;

public class PumpStation : AbstractBuilding
{
    public int[] pumpAmount;
    public int[] pumpPower;
    public bool[] pumpWork;

    public float v;                     // speed m/sec    2, 4, 6
    public float p = 2;                     // plotnost kg/m3

    public float maxPressure;           // 2, 4, 6
    public float currentPressure;

    public int GetActivePump()
    {
        return pumpWork.Where(c => c).Count();
    }

    public float CountPressure()
    {
        return (0.5f * p * (float)Math.Pow(v, 2));
    }

    public override void OnBuildingEvent()
    {
        base.OnBuildingEvent();
        DataManager.gameData.pumpStationLevel = level;
        DataManager.gameData.pumpStationState = (int)currentBuildingState;
        SaveBuildingData();
    }

    public override void SwitchState(BuildingState buildingState)
    {
        base.SwitchState(buildingState);
        DataManager.gameData.pumpStationState = (int)currentBuildingState;
        SaveBuildingData();
    }

    public override void OnManagerSet(int managerId)
    {
        base.OnManagerSet(managerId);
        DataManager.gameData.pumpStationManager = managerID;
        SaveBuildingData();
    }
}
