using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterConsumption : MonoBehaviour
{
    [SerializeField] private BuildingManager buildingManager;
    public float WaterConsumptionFunc(float generatorPower, float pumpPower)
    {
        if (buildingManager.pumpStation.currentBuildingState == BuildingManager.BuildingState.work)
        {
            Debug.Log(((pumpPower * buildingManager.pumpStation.GetActivePump()) * buildingManager.pumpStation.pumpAmount[buildingManager.pumpStation.level]) * generatorPower);
            return ((pumpPower * buildingManager.pumpStation.GetActivePump()) * buildingManager.pumpStation.pumpAmount[buildingManager.pumpStation.level]) * generatorPower;
        }
        else if (buildingManager.pumpStation.currentBuildingState == BuildingManager.BuildingState.build)
        {
            return (((pumpPower * buildingManager.pumpStation.GetActivePump()) * buildingManager.pumpStation.pumpAmount[buildingManager.pumpStation.level]) * generatorPower) / 2;
        }
        return 0;
    }
}
