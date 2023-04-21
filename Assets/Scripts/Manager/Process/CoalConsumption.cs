using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoalConsumption : MonoBehaviour
{
    [SerializeField] private BuildingManager buildingManager;
    public float Owen1CoalConsumption(float owenPower, int ece) // ece - kpd 
    {
        if (buildingManager.blockOne.currentBuildingState == BuildingManager.BuildingState.work)
            return (owenPower * ece) * 0.5f;
        return 0;
    }

    public float Owen2CoalConsumption(float owenPower, int ece) // ece - kpd 
    {
        if (buildingManager.blockTwo.currentBuildingState == BuildingManager.BuildingState.work)
            return (owenPower * ece) * 0.5f;
        return 0;
    }

    public float Owen3CoalConsumption(float owenPower, int ece) // ece - kpd 
    {
        if (buildingManager.blockThree.currentBuildingState == BuildingManager.BuildingState.work)
            return (owenPower * ece) * 0.5f;
        return 0;
    }

    public float Owen4CoalConsumption(float owenPower, int ece) // ece - kpd 
    {
        if (buildingManager.blockFour.currentBuildingState == BuildingManager.BuildingState.work)
            return (owenPower * ece) * 0.5f;
        return 0;
    }
}