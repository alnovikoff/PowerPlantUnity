using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[System.Serializable]
public class GameData
{
    public bool isFirstRun;
    public int money, donate, level, builderAmount;
    public float xp;
    // state
    public int block1State, block2State, block3State, block4State, pumpStationState, boatDockState, coalStorageState, fuelStorageState, trainDockState, electricalSubstationState, waterTreatmentState, coolingTowerState, securityState;

    //level
    public int block1Level, block2Level, block3Level, block4Level, pumpStationLevel, boatDockLevel, coalStorageLevel, fuelStorageLevel, trainDockLevel, electricalSubstationLevel, waterTreatmentLevel, coolingTowerLevel, securityLevel;

    // Condition
    public int block1Condition, block2Condition, block3Condition, block4Condition, pumpStationCondition, boatDockCondition, coalStorageCondition, fuelStorageCondition, trainDockCondition, electricalSubstationCondition, waterTreatmentCondition, coolingTowerCondition, securityCondition;

    // managers
    public int block1Manager, block2Manager, block3Manager, block4Manager, pumpStationManager, boatDockManager, coalStorageManager, fuelStorageManager, trainDockManager, electricalSubstationManager, waterTreatmentManager, coolingTowerManager, securityManager;

    public string startDate, endDate;

    public int block1Slider1, block1Slider1_2, block2Slider1, block2Slider1_2, block3Slider1, block3Slider1_2, block4Slider1, block4Slider1_2;

    public bool[] assignedRegions;

    public bool[] workPumps;

    //public string[] delivertyStart;
    //public string[] delivertyEnd;

    public List<Order> order;

    public int coalStorageQuality;
    public int fuelStorageQuality;
    public int coalStorageOccupancy;
    public int fuelStorageOccupancy;
    public GameData()
    {
        this.isFirstRun = new bool();

        this.money = new int();
        this.donate = new int();
        this.level = new int();
        this.xp = new float();
        this.builderAmount = new int();

        this.block1State = new int();
        this.block2State = new int();
        this.block3State = new int();
        this.block4State = new int();
        this.pumpStationState = new int();
        this.boatDockState = new int();
        this.coalStorageState = new int();           
        this.fuelStorageState = new int();
        this.trainDockState = new int();
        this.waterTreatmentState = new int();
        this.coolingTowerState = new int();
        this.securityState = new int();

        this.block1Level = new int();
        this.block2Level = new int();
        this.block3Level = new int();
        this.block4Level = new int();
        this.pumpStationLevel = new int();
        this.boatDockLevel = new int();
        this.coalStorageLevel = new int();
        this.fuelStorageLevel = new int();
        this.trainDockLevel = new int();
        this.waterTreatmentLevel = new int();
        this.coolingTowerLevel = new int();
        this.securityState = new int();

        this.block1Condition = new int();
        this.block2Condition = new int();
        this.block3Condition = new int();
        this.block4Condition = new int();
        this.pumpStationCondition = new int();
        this.boatDockCondition = new int();
        this.coalStorageCondition = new int();
        this.fuelStorageCondition = new int();
        this.trainDockCondition = new int();
        this.waterTreatmentCondition = new int();
        this.coolingTowerCondition = new int();
        this.securityCondition = new int();
        this.electricalSubstationCondition = new int();

        this.startDate = new string("");
        this.endDate = new string("");

        this.block1Slider1 = new int();
        this.block1Slider1_2 = new int();
        this.block2Slider1 = new int();
        this.block2Slider1_2 = new int();
        this.block3Slider1 = new int();
        this.block3Slider1_2 = new int();
        this.block4Slider1 = new int();
        this.block4Slider1_2 = new int();

        this.assignedRegions = new bool[6];

        this.workPumps = new bool[4];

        this.block1Manager = new int();

        this.coalStorageQuality = new int();
        this.fuelStorageQuality = new int();
        this.coalStorageOccupancy = new int();
        this.fuelStorageOccupancy = new int();

        this.order = new List<Order>();

        isFirstRun = true;

        money = 50000;
        donate = 5;
        level = 1;
        xp = 0.0f;
        builderAmount = 1;

        // Buildings state
        // 0 - notbuild, 1 build, 2 - notwork, 3 - work
        block1State = 3;
        block2State = 0;
        block3State = 0;
        block4State = 0;
        pumpStationState = 3;
        boatDockState = 3;
        coalStorageState = 3;
        fuelStorageState = 3;
        trainDockState = 3;
        electricalSubstationState = 3;
        waterTreatmentState = 3;
        coolingTowerState = 3;
        securityState = 3;


        // Building level
        block1Level = 1;
        block2Level = 0;
        block3Level = 0;
        block4Level = 0;
        pumpStationLevel = 1;
        boatDockLevel = 1;
        coalStorageLevel = 1;
        fuelStorageLevel = 1;
        trainDockLevel = 1;
        electricalSubstationLevel = 1;
        waterTreatmentLevel = 1;
        coolingTowerLevel = 1;
        securityLevel = 1;

        // Condition
        this.block1Condition = 100;
        this.block2Condition = 100;
        this.block3Condition = 100;
        this.block4Condition = 100;
        this.pumpStationCondition = 100;
        this.boatDockCondition = 100;
        this.coalStorageCondition = 100;
        this.fuelStorageCondition = 100;
        this.trainDockCondition = 100;
        this.waterTreatmentCondition = 100;
        this.coolingTowerCondition = 100;
        this.securityCondition = 100;
        this.electricalSubstationCondition = 100;

        startDate = "";
        endDate = "";

        // sliders 
        this.block1Slider1 = 1;
        this.block1Slider1_2 = 1;
        this.block2Slider1 = 1;
        this.block2Slider1_2 = 1;
        this.block3Slider1 = 1;
        this.block3Slider1_2 = 1;
        this.block4Slider1 = 1;
        this.block4Slider1_2 = 1;

        workPumps[0] = true;
        workPumps[1] = false;
        workPumps[2] = false;
        workPumps[3] = false;  

        assignedRegions[0] = false;
        assignedRegions[1] = false;  
        assignedRegions[2] = false;  
        assignedRegions[3] = false;  
        assignedRegions[4] = false; 
        assignedRegions[5] = false;

        this.block1Manager = 0;

        coalStorageQuality = 0;
        coalStorageOccupancy = 0;
        fuelStorageQuality = 0;
        fuelStorageOccupancy = 0;

    }
}