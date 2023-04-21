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
    public ElectricPowerTransmission electricPowerTransmission;
    public BoatDocks boatDock;
    public FuelStorage fuelStorage;
    public PumpStation pumpStation;
    public TrainDocks trainDock;
    public Transformer transformer;
    public WaterTreatment waterTreatment;

    public enum BuildingState
    {
        notbuild,
        build,
        notwork,
        work
    }
}
