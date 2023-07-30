using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BuildingManager : MonoBehaviour
{
    [Header("Building classes")]
    public BlockOne blockOne;
    public BlockTwo blockTwo;
    public BlockThree blockThree;
    public BlockFour blockFour;
    public CoalStorage coalStorage;
    public ElectricalSubstation electricalSubstation;
    public BoatDocks boatDock;
    public FuelStorage fuelStorage;
    public PumpStation pumpStation;
    public TrainDocks trainDock;
    public WaterTreatment waterTreatment;
    public CoolingTower coolingTower;
    public Security security;

    public enum BuildingState
    {
        notbuild,
        build,
        notwork,
        work
    }
}
