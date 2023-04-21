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
                            onTapAction.MakeAction(buildingManager.blockOne, raycastHit.collider.gameObject);
                            break;
                        case "Block2":
                            onTapAction.MakeAction(buildingManager.blockTwo, raycastHit.collider.gameObject);
                            break;
                        case "Block3":
                            onTapAction.MakeAction(buildingManager.blockThree, raycastHit.collider.gameObject);
                            break;
                        case "Block4":
                            onTapAction.MakeAction(buildingManager.blockFour, raycastHit.collider.gameObject);
                            break;
                        case "PumpStation":
                            onTapAction.MakeAction(buildingManager.pumpStation, raycastHit.collider.gameObject);
                            break;
                        case "BoatDock":
                            onTapAction.MakeAction(buildingManager.boatDock, raycastHit.collider.gameObject);
                            break;
                        case "CoalStorage":
                            onTapAction.MakeAction(buildingManager.coalStorage, raycastHit.collider.gameObject);
                            break;
                        case "FuelStorage":
                            onTapAction.MakeAction(buildingManager.fuelStorage, raycastHit.collider.gameObject);
                            break;
                        case "TrainDock":
                            onTapAction.MakeAction(buildingManager.trainDock, raycastHit.collider.gameObject);
                            break;
                        case "ElectricalSubstation":
                            onTapAction.MakeAction(buildingManager.electricalSubstation, raycastHit.collider.gameObject);
                            break;
                        case "WaterTreatment":
                            onTapAction.MakeAction(buildingManager.waterTreatment, raycastHit.collider.gameObject);
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
