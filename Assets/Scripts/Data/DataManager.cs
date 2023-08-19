using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;


public class DataManager : MonoBehaviour
{
    public static GameData gameData = null;

    [SerializeField] private BuildingManager buildingManager;
    [SerializeField] private BuildTime buildTime;
    [SerializeField] private ControlScheme controlScheme;
    [SerializeField] private Money money;
    [SerializeField] private PlayerLevelManager playerLevelManager;
    [SerializeField] private BuilderManager builderManager;
    [SerializeField] private ControlSlidersManager controlSlidersManager;
    [SerializeField] private TownMapManager townMapManager;
    [SerializeField] private ResourceTime resourceTime;
    [SerializeField] private ResourceDeliveries resourceDeliveries;

    private void Awake()
    {
        gameData = SaveSystem.Load();
    }

    private void Start()
    {
        InitializeBuilders();
        LoadBuildingState();
        LoadBuildingLevel();
        StorageLoad();
        LoadBuildingCondition();
        InitializeBuildingUI();
        InitializePumps();
        controlScheme.InitializeControlScheme();
        InitializeMoneyValues();
        InitializeLevelValues();
        InitializeManagmentPan();
        AssignedRegions();
        LoadManagers();
        InitializeDeliviries();
    }

    private void InitializeBuilders()
    {
        builderManager.SetBuilderAmount(gameData.builderAmount);
        builderManager.InitializeBuilders();
    }

    private void LoadBuildingState()
    {
        buildingManager.blockOne.currentBuildingState = (BuildingManager.BuildingState)gameData.block1State;
        buildingManager.blockTwo.currentBuildingState = (BuildingManager.BuildingState)gameData.block2State;
        buildingManager.blockThree.currentBuildingState = (BuildingManager.BuildingState)gameData.block3State;
        buildingManager.blockFour.currentBuildingState = (BuildingManager.BuildingState)gameData.block4State;
        buildingManager.pumpStation.currentBuildingState = (BuildingManager.BuildingState)gameData.pumpStationState;
        buildingManager.boatDock.currentBuildingState = (BuildingManager.BuildingState)gameData.boatDockState;
        buildingManager.coalStorage.currentBuildingState = (BuildingManager.BuildingState)gameData.coalStorageState;
        buildingManager.fuelStorage.currentBuildingState = (BuildingManager.BuildingState)gameData.fuelStorageState;
        buildingManager.trainDock.currentBuildingState = (BuildingManager.BuildingState)gameData.trainDockState;
        buildingManager.electricalSubstation.currentBuildingState = (BuildingManager.BuildingState)gameData.electricalSubstationState;
        buildingManager.waterTreatment.currentBuildingState = (BuildingManager.BuildingState)gameData.waterTreatmentState;
        buildingManager.coolingTower.currentBuildingState = (BuildingManager.BuildingState)gameData.coolingTowerState;
        buildingManager.security.currentBuildingState = (BuildingManager.BuildingState)gameData.securityState;
    }

    private void LoadBuildingLevel()
    {
        buildingManager.blockOne.level = gameData.block1Level;
        buildingManager.blockTwo.level = gameData.block2Level;
        buildingManager.blockThree.level = gameData.block3Level;
        buildingManager.blockFour.level = gameData.block4Level;
        buildingManager.pumpStation.level = gameData.pumpStationLevel;
        buildingManager.boatDock.level = gameData.boatDockLevel;
        buildingManager.coalStorage.level = gameData.coalStorageLevel;
        buildingManager.fuelStorage.level = gameData.fuelStorageLevel;
        buildingManager.trainDock.level = gameData.trainDockLevel;
        buildingManager.electricalSubstation.level = gameData.electricalSubstationLevel;
        buildingManager.waterTreatment.level = gameData.waterTreatmentLevel;
        buildingManager.coolingTower.level = gameData.coolingTowerLevel;
        buildingManager.security.level = gameData.securityLevel;
    }

    private void LoadBuildingCondition()
    {
        buildingManager.blockOne.condition = gameData.block1Condition;
        buildingManager.blockTwo.condition = gameData.block2Condition;
        buildingManager.blockThree.condition = gameData.block3Condition;
        buildingManager.blockFour.condition = gameData.block4Condition;
        buildingManager.pumpStation.condition = gameData.pumpStationCondition;
        buildingManager.boatDock.condition = gameData.boatDockCondition;
        buildingManager.coalStorage.condition = gameData.coalStorageCondition;
        buildingManager.fuelStorage.condition = gameData.fuelStorageCondition;
        buildingManager.trainDock.condition = gameData.trainDockCondition;
        buildingManager.electricalSubstation.condition = gameData.electricalSubstationCondition;
        buildingManager.waterTreatment.condition = gameData.waterTreatmentCondition;
        buildingManager.coolingTower.condition = gameData.coolingTowerCondition;
        buildingManager.security.condition = gameData.securityCondition;
    }

    private void InitializeBuildingUI()
    {
        if (buildingManager.blockOne.currentBuildingState == BuildingManager.BuildingState.build)
        {
            buildTime.OnGameStart(buildingManager.blockOne.GetGameObject(), gameData.startDate, gameData.endDate);
            builderManager.SetcurrentFreeBuilder(builderManager.GetCurrentFreeBuilder() - 1);
        }
        else if (buildingManager.blockTwo.currentBuildingState == BuildingManager.BuildingState.build)
        {
            buildTime.OnGameStart(buildingManager.blockTwo.GetGameObject(), gameData.startDate, gameData.endDate);
            builderManager.SetcurrentFreeBuilder(builderManager.GetCurrentFreeBuilder() - 1);
        }
        else if (buildingManager.blockThree.currentBuildingState == BuildingManager.BuildingState.build)
        {
            buildTime.OnGameStart(buildingManager.blockThree.GetGameObject(), gameData.startDate, gameData.endDate);
            builderManager.SetcurrentFreeBuilder(builderManager.GetCurrentFreeBuilder() - 1);
        }
        if (buildingManager.blockFour.currentBuildingState == BuildingManager.BuildingState.build)
        {
            buildTime.OnGameStart(buildingManager.blockFour.GetGameObject(), gameData.startDate, gameData.endDate);
            builderManager.SetcurrentFreeBuilder(builderManager.GetCurrentFreeBuilder() - 1);
        }
        else if (buildingManager.boatDock.currentBuildingState == BuildingManager.BuildingState.build)
        {
            buildTime.OnGameStart(buildingManager.boatDock.GetGameObject(), gameData.startDate, gameData.endDate);
            builderManager.SetcurrentFreeBuilder(builderManager.GetCurrentFreeBuilder() - 1);
        }
        else if (buildingManager.coalStorage.currentBuildingState == BuildingManager.BuildingState.build)
        {
            buildTime.OnGameStart(buildingManager.coalStorage.GetGameObject(), gameData.startDate, gameData.endDate);
            builderManager.SetcurrentFreeBuilder(builderManager.GetCurrentFreeBuilder() - 1);
        }
        else if (buildingManager.coolingTower.currentBuildingState == BuildingManager.BuildingState.build)
        {
            buildTime.OnGameStart(buildingManager.coolingTower.GetGameObject(), gameData.startDate, gameData.endDate);
            builderManager.SetcurrentFreeBuilder(builderManager.GetCurrentFreeBuilder() - 1);
        }
        else if (buildingManager.electricalSubstation.currentBuildingState == BuildingManager.BuildingState.build)
        {
            buildTime.OnGameStart(buildingManager.electricalSubstation.GetGameObject(), gameData.startDate, gameData.endDate);
            builderManager.SetcurrentFreeBuilder(builderManager.GetCurrentFreeBuilder() - 1);
        }
        if (buildingManager.fuelStorage.currentBuildingState == BuildingManager.BuildingState.build)
        {
            buildTime.OnGameStart(buildingManager.fuelStorage.GetGameObject(), gameData.startDate, gameData.endDate);
            builderManager.SetcurrentFreeBuilder(builderManager.GetCurrentFreeBuilder() - 1);
        }
        else if (buildingManager.pumpStation.currentBuildingState == BuildingManager.BuildingState.build)
        {
            buildTime.OnGameStart(buildingManager.pumpStation.GetGameObject(), gameData.startDate, gameData.endDate);
            builderManager.SetcurrentFreeBuilder(builderManager.GetCurrentFreeBuilder() - 1);
        }
        else if (buildingManager.security.currentBuildingState == BuildingManager.BuildingState.build)
        {
            buildTime.OnGameStart(buildingManager.security.GetGameObject(), gameData.startDate, gameData.endDate);
            builderManager.SetcurrentFreeBuilder(builderManager.GetCurrentFreeBuilder() - 1);
        }
        else if (buildingManager.trainDock.currentBuildingState == BuildingManager.BuildingState.build)
        {
            buildTime.OnGameStart(buildingManager.trainDock.GetGameObject(), gameData.startDate, gameData.endDate);
            builderManager.SetcurrentFreeBuilder(builderManager.GetCurrentFreeBuilder() - 1);
        }
        else if (buildingManager.waterTreatment.currentBuildingState == BuildingManager.BuildingState.build)
        {
            buildTime.OnGameStart(buildingManager.waterTreatment.GetGameObject(), gameData.startDate, gameData.endDate);
            builderManager.SetcurrentFreeBuilder(builderManager.GetCurrentFreeBuilder() - 1);
        }

    }

    private void InitializeDeliviries()
    {
        if (gameData.order.Count > 1)
        {
            for (int i = 0; i < gameData.order.Count; i++)
            {
                //if (gameData.order[i].amount > 0)
                    resourceDeliveries.order.Add(gameData.order[i]);
            }
        }
    }

    private void InitializeMoneyValues()
    {
        money.SetMoney(gameData.money);
        money.SetDonate(gameData.donate);
        money.InitializeMoney();
    }

    private void InitializeManagmentPan()
    {
        controlSlidersManager.block1Generator.value = gameData.block1Slider1;
        controlSlidersManager.block1Owen.value = gameData.block1Slider1_2;
        controlSlidersManager.block2Generator.value = gameData.block2Slider1;
        controlSlidersManager.block2Owen.value = gameData.block2Slider1_2;
        controlSlidersManager.block3Generator.value = gameData.block3Slider1;
        controlSlidersManager.block3Owen.value = gameData.block3Slider1_2;
        controlSlidersManager.block4Generator.value = gameData.block4Slider1;
        controlSlidersManager.block4Owen.value = gameData.block4Slider1_2;
    }

    private void InitializePumps()
    {
        buildingManager.pumpStation.pumpWork[0] = gameData.workPumps[0];
        buildingManager.pumpStation.pumpWork[1] = gameData.workPumps[1];
        buildingManager.pumpStation.pumpWork[2] = gameData.workPumps[2];
        buildingManager.pumpStation.pumpWork[3] = gameData.workPumps[3];
    }

    public void AssignedRegions()
    {
        townMapManager.assignedRegions = new bool[6];
        for(int i = 0; i < townMapManager.assignedRegions.Length; i++)
        {
            townMapManager.assignedRegions[i] = gameData.assignedRegions[i];
        }
    }

    public void LoadManagers()
    {
        buildingManager.blockOne.managerID = gameData.block1Manager;
        buildingManager.blockTwo.managerID = gameData.block2Manager;
        buildingManager.blockThree.managerID = gameData.block3Manager;
        buildingManager.blockFour.managerID = gameData.block4Manager;
        buildingManager.pumpStation.managerID = gameData.pumpStationManager;
        buildingManager.boatDock.managerID = gameData.boatDockManager;
        buildingManager.coalStorage.managerID = gameData.coalStorageManager;
        buildingManager.trainDock.managerID = gameData.trainDockManager;
        buildingManager.electricalSubstation.managerID = gameData.electricalSubstationManager;
        buildingManager.waterTreatment.managerID = gameData.waterTreatmentManager;
        buildingManager.coolingTower.managerID = gameData.coolingTowerManager;
        buildingManager.security.managerID = gameData.securityManager;
    }

    private void InitializeLevelValues()
    {
        //playerLevelManager.level = gameData.level;
        //playerLevelManager.currentXp = gameData.xp;
        //playerLevelManager.InitializeLevel();
    }

    private void StorageLoad()
    {
        buildingManager.coalStorage.quality = gameData.coalStorageQuality;
        buildingManager.coalStorage.occupancy = gameData.coalStorageOccupancy;
        buildingManager.fuelStorage.quality = gameData.fuelStorageQuality;
        buildingManager.fuelStorage.occupancy = gameData.fuelStorageOccupancy;
    }
}
