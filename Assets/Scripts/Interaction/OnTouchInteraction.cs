using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;
using static HRManagment;


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
                            else
                                GameManager.instance.OnHRAction?.Invoke(buildingManager.blockOne);
                            break;
                        case "Block2":
                            GameManager.instance.OnBuildingTapAction?.Invoke(buildingManager.blockTwo, raycastHit.collider.gameObject);
                            GameManager.instance.OnHRAction?.Invoke(buildingManager.blockTwo);
                            break;
                        case "Block3":
                            GameManager.instance.OnBuildingTapAction?.Invoke(buildingManager.blockThree, raycastHit.collider.gameObject);
                            break;
                        case "Block4":
                            GameManager.instance.OnBuildingTapAction?.Invoke(buildingManager.blockFour, raycastHit.collider.gameObject);
                            //onTapAction.MakeAction(buildingManager.blockFour, raycastHit.collider.gameObject);
                            break;
                        case "PumpStation":
                            GameManager.instance.OnBuildingTapAction?.Invoke(buildingManager.pumpStation, raycastHit.collider.gameObject);
                            // onTapAction.MakeAction(buildingManager.pumpStation, raycastHit.collider.gameObject);
                            break;
                        case "BoatDock":
                            GameManager.instance.OnBuildingTapAction?.Invoke(buildingManager.boatDock, raycastHit.collider.gameObject);
                            //onTapAction.MakeAction(buildingManager.boatDock, raycastHit.collider.gameObject);
                            break;
                        case "CoalStorage":
                            GameManager.instance.OnBuildingTapAction?.Invoke(buildingManager.coalStorage, raycastHit.collider.gameObject);
                            //onTapAction.MakeAction(buildingManager.coalStorage, raycastHit.collider.gameObject);
                            break;
                        case "FuelStorage":
                            GameManager.instance.OnBuildingTapAction?.Invoke(buildingManager.fuelStorage, raycastHit.collider.gameObject);
                            //onTapAction.MakeAction(buildingManager.fuelStorage, raycastHit.collider.gameObject);
                            break;
                        case "TrainDock":
                            GameManager.instance.OnBuildingTapAction?.Invoke(buildingManager.trainDock, raycastHit.collider.gameObject);
                            //onTapAction.MakeAction(buildingManager.trainDock, raycastHit.collider.gameObject);
                            break;
                        case "ElectricalSubstation":
                            GameManager.instance.OnBuildingTapAction?.Invoke(buildingManager.electricalSubstation, raycastHit.collider.gameObject);
                            //onTapAction.MakeAction(buildingManager.electricalSubstation, raycastHit.collider.gameObject);
                            break;
                        case "WaterTreatment":
                            GameManager.instance.OnBuildingTapAction?.Invoke(buildingManager.waterTreatment, raycastHit.collider.gameObject);
                            //onTapAction.MakeAction(buildingManager.waterTreatment, raycastHit.collider.gameObject);
                            break;
                        //case "Security":
                        //    onTapAction.BlockTwoPan(raycastHit.collider.gameObject);
                        //    break;
                    }
                }
            }
        }
    }
}
