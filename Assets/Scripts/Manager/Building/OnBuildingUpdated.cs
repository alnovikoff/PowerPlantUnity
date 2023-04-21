using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OnBuildingUpdated : MonoBehaviour
{
    public BuildingManager buildingManager;
    public PlayerLevelManager playerLevelManager;
    public BuilderManager builderManager;

    public void OnBuildingUpdate(GameObject gameObject)
    {
        switch (gameObject.name)
        {
            case "Block1":
                buildingManager.blockOne.OnBuildingEvent();
                break;
            case "Block2":
                buildingManager.blockTwo.OnBuildingEvent();
                break;
            case "Block3":
                buildingManager.blockThree.OnBuildingEvent();
                break;
            case "Block4":
                buildingManager.blockFour.OnBuildingEvent();
                break;
            case "PumpStation":
                buildingManager.pumpStation.OnBuildingEvent();
                break;
            case "BoatDock":
                buildingManager.boatDock.OnBuildingEvent();
                break;
            case "CoalStorage":
                buildingManager.coalStorage.OnBuildingEvent();
                break;
            case "FuelStorage":
                buildingManager.fuelStorage.OnBuildingEvent();
                break;
            case "TrainDock":
                buildingManager.trainDock.OnBuildingEvent();
                break;
            case "ElectricalSubstation":
                buildingManager.electricalSubstation.OnBuildingEvent();
                break;
            case "WaterTreatment":
                buildingManager.waterTreatment.OnBuildingEvent();
                break;
        }
        builderManager.SetcurrentFreeBuilder(builderManager.GetCurrentFreeBuilder() + 1);
        GameManager.instance.onBuilder?.Invoke();
        GameManager.instance.onChangeElectricity?.Invoke();
    }
}
