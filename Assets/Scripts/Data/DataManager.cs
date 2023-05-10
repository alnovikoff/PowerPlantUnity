using System.Collections;
using System.Collections.Generic;
using UnityEngine;


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
    private void Awake()
    {
        gameData = SaveSystem.Load();
    }

    private void Start()
    {
        InitializeBuilders();
        LoadBuildingState();
        LoadBuildingLevel();
        InitializeBuildingUI();
        InitializePumps();
        controlScheme.InitializeControlScheme();
        InitializeMoneyValues();
        InitializeLevelValues();
        InitializeManagmentPan();
        AssignedRegions();
        LoadManagers();
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
    }

    private void InitializeLevelValues()
    {
        //playerLevelManager.level = gameData.level;
        //playerLevelManager.currentXp = gameData.xp;
        //playerLevelManager.InitializeLevel();
    }
}
