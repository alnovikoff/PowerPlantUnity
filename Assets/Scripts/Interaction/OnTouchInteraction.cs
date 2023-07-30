using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;


public class OnTouchInteraction : MonoBehaviour
{
    public OnTapAction onTapAction;
    public BuildingManager buildingManager;
    public HRManagment hRManagment;

    void Update()
    {
        if ((Input.touchCount > 0) && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            if(!EventSystem.current.IsPointerOverGameObject())
            {
                Ray raycast = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
                RaycastHit raycastHit;
                if (Physics.Raycast(raycast, out raycastHit))
                {
                    switch (raycastHit.collider.gameObject.name)
                    {
                        case "Block1":
                            if(!hRManagment.isManager)
                                GameManager.instance.OnBuildingTapAction?.Invoke(buildingManager.blockOne, raycastHit.collider.gameObject);
                            GameManager.instance.OnHRAction?.Invoke(buildingManager.blockOne);
                            break;
                        case "Block2":
                            if(!hRManagment.isManager)
                                GameManager.instance.OnBuildingTapAction?.Invoke(buildingManager.blockTwo, raycastHit.collider.gameObject);
                            GameManager.instance.OnHRAction?.Invoke(buildingManager.blockTwo);
                            break;
                        case "Block3":
                            if (!hRManagment.isManager)
                                GameManager.instance.OnBuildingTapAction?.Invoke(buildingManager.blockThree, raycastHit.collider.gameObject);
                            GameManager.instance.OnHRAction?.Invoke(buildingManager.blockThree);
                            break;
                        case "Block4":
                            if (!hRManagment.isManager)
                                GameManager.instance.OnBuildingTapAction?.Invoke(buildingManager.blockFour, raycastHit.collider.gameObject);
                            GameManager.instance.OnHRAction?.Invoke(buildingManager.blockFour);
                            break;
                        case "PumpStation":
                            if (!hRManagment.isManager)
                                GameManager.instance.OnBuildingTapAction?.Invoke(buildingManager.pumpStation, raycastHit.collider.gameObject);
                            GameManager.instance.OnHRAction?.Invoke(buildingManager.pumpStation);
                            break;
                        case "BoatDock":
                            if (!hRManagment.isManager)
                                GameManager.instance.OnBuildingTapAction?.Invoke(buildingManager.boatDock, raycastHit.collider.gameObject);
                            GameManager.instance.OnHRAction?.Invoke(buildingManager.boatDock);
                            break;
                        case "CoalStorage":
                            if (!hRManagment.isManager)
                                GameManager.instance.OnBuildingTapAction?.Invoke(buildingManager.coalStorage, raycastHit.collider.gameObject);
                            GameManager.instance.OnHRAction?.Invoke(buildingManager.coalStorage);
                            break;
                        case "FuelStorage":
                            if (!hRManagment.isManager)
                                GameManager.instance.OnBuildingTapAction?.Invoke(buildingManager.fuelStorage, raycastHit.collider.gameObject);
                            GameManager.instance.OnHRAction?.Invoke(buildingManager.fuelStorage);
                            break;
                        case "TrainDock":
                            if (!hRManagment.isManager)
                                GameManager.instance.OnBuildingTapAction?.Invoke(buildingManager.trainDock, raycastHit.collider.gameObject);
                            GameManager.instance.OnHRAction?.Invoke(buildingManager.trainDock);
                            break;
                        case "ElectricalSubstation":
                            if (!hRManagment.isManager)
                                GameManager.instance.OnBuildingTapAction?.Invoke(buildingManager.electricalSubstation, raycastHit.collider.gameObject);
                            GameManager.instance.OnHRAction?.Invoke(buildingManager.electricalSubstation);
                            break;
                        case "WaterTreatment":
                            if (!hRManagment.isManager)
                                GameManager.instance.OnBuildingTapAction?.Invoke(buildingManager.waterTreatment, raycastHit.collider.gameObject);
                            GameManager.instance.OnHRAction?.Invoke(buildingManager.waterTreatment);
                            break;
                        case "Security":
                            if (!hRManagment.isManager)
                                GameManager.instance.OnBuildingTapAction?.Invoke(buildingManager.security, raycastHit.collider.gameObject);
                            GameManager.instance.OnHRAction?.Invoke(buildingManager.security);
                            break;
                        case "CoolingTower":
                            if (!hRManagment.isManager)
                                GameManager.instance.OnBuildingTapAction?.Invoke(buildingManager.coolingTower, raycastHit.collider.gameObject);
                            GameManager.instance.OnHRAction?.Invoke(buildingManager.coolingTower);
                            break;
                    }
                }
            }
        }
    }
}
