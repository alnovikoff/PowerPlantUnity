using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[System.Serializable]
public class GameData
{
    public int money, donate, level, xp, builderAmount;
    // state
    public int block1State, block2State, block3State, block4State, pumpStationState, boatDockState, coalStorageState, fuelStorageState, trainDockState, electricalSubstationState, waterTreatmentState;

    //level
    public int block1Level, block2Level, block3Level, block4Level, pumpStationLevel, boatDockLevel, coalStorageLevel, fuelStorageLevel, trainDockLevel, electricalSubstationLevel, waterTreatmentLevel;

    public string startDate, endDate;

    public int block1Slider1, block1Slider1_2, block2Slider1, block2Slider1_2, block3Slider1, block3Slider1_2, block4Slider1, block4Slider1_2;

    public bool[] workPumps;
    public GameData()
    {
        this.money = new int();
        this.donate = new int();
        this.level = new int();
        this.xp = new int();
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

        this.workPumps = new bool[4];


        money = 50000;
        donate = 5;
        level = 1;
        xp = 0;
        builderAmount = 1;

        // Buildings state
        // 0 - notbuild, 1 build, 2 - notwork, 3 - work
        block1State = 3;
        block2State = 0;
        block3State = 0;
        block4State = 0;
        pumpStationState = 3;
        boatDockState = 0;
        coalStorageState = 3;
        fuelStorageState = 3;
        trainDockState = 3;
        electricalSubstationState = 0;
        waterTreatmentState = 3;

        // Building level
        block1Level = 1;
        block2Level = 0;
        block3Level = 0;
        block4Level = 0;
        pumpStationLevel = 1;
        boatDockLevel = 0;
        coalStorageLevel = 1;
        fuelStorageLevel = 1;
        trainDockLevel = 1;
        electricalSubstationLevel = 0;
        waterTreatmentLevel = 1;

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
    }
}