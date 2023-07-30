using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using static BuildingManager;
using TMPro;
using Unity.VisualScripting;
using System.Runtime.CompilerServices;

public class OnTapAction : MonoBehaviour
{
    [Header("UI modes")]
    [SerializeField] private GeneralOnTapAction generalOnTapAction;

    [SerializeField] private NotBuildMode notBuildMode;
    [SerializeField] private BuildMode buildMode;
    [SerializeField] private NotWorkMode notWorkMode;
    [SerializeField] private WorkMode workMode;

    [SerializeField] private Money money;
    [SerializeField] private BuildingManager buildingManager;
    [SerializeField] private BuilderManager builderManager;

    [SerializeField] private Button updateButton;
    [SerializeField] private Button updateButtonDonate;
    [SerializeField] private Button repairButton;

    [SerializeField] public TMP_Text costTxt;
    [SerializeField] public TMP_Text levelTxt;
    [SerializeField] public TMP_Text nameTxt;
    [SerializeField] public TMP_Text costDonateTxt;
    [SerializeField] public TMP_Text repairPrice;

    [SerializeField] private Image workerImage;
    [SerializeField] private TMP_Text workerName;
    [SerializeField] private JsonReader jsonReader;

    [SerializeField] private TMP_Text info1Name;
    [SerializeField] private TMP_Text info1Txt;
    [SerializeField] private TMP_Text info2Name;
    [SerializeField] private TMP_Text info2Txt;

    [SerializeField] private TMP_Text upgrade1;
    [SerializeField] private TMP_Text upgrade2;

    [SerializeField] private Image noPhoto;

    public void MakeAction(AbstractBuilding abstractBuilding, GameObject gameObject)
    {
        generalOnTapAction.OpenPan();
        nameTxt.text = abstractBuilding.name;
        switch (abstractBuilding.currentBuildingState)
        {
            case BuildingState.notbuild:
                generalOnTapAction.NotBuildTab();
                ShowCost(abstractBuilding);
                if (builderManager.GetCurrentFreeBuilder() > 0)
                {
                    // Build with money
                    if (money.GetMoney() >= abstractBuilding.updateCost[abstractBuilding.level].moneyCost)
                    {
                        notBuildMode.buildButton.interactable = true;
                        notBuildMode.buildButton.onClick.RemoveAllListeners();
                        notBuildMode.buildButton.onClick.AddListener(delegate
                        {
                            notBuildMode.OnBuildButtonClick(gameObject, abstractBuilding.buildUpdateTime[abstractBuilding.level]);
                            //abstractBuilding.currentBuildingState = BuildingState.build;
                            // !!!!!!!!!!!!!!! PROBLEM DOESNT SAVE BUILDING STATE WHEN SWITCH IT
                            abstractBuilding.SwitchState(BuildingState.build);
                            money.SubstractValue(abstractBuilding.updateCost[abstractBuilding.level].moneyCost);
                            builderManager.SetcurrentFreeBuilder(builderManager.GetCurrentFreeBuilder() - 1);
                            GameManager.instance.onBuilder?.Invoke();
                        });
                    }
                    else
                    {
                        notBuildMode.buildButton.interactable = false;
                    }
                    // Build with donate
                    if (money.GetDonate() >= abstractBuilding.updateCost[abstractBuilding.level].donateCost)
                    {
                        notBuildMode.buildDonateButton.interactable = true;
                        notBuildMode.buildDonateButton.onClick.RemoveAllListeners();
                        notBuildMode.buildDonateButton.onClick.AddListener(delegate
                        {
                            notBuildMode.OnBuildButtonClick(gameObject, abstractBuilding.buildUpdateTime[abstractBuilding.level]);
                            abstractBuilding.currentBuildingState = BuildingState.build;
                            abstractBuilding.SwitchState(BuildingState.build);
                            money.SubstractDonateValue(abstractBuilding.updateCost[abstractBuilding.level].donateCost);
                            builderManager.SetcurrentFreeBuilder(builderManager.GetCurrentFreeBuilder() - 1);
                            GameManager.instance.onBuilder?.Invoke();
                        });
                    }
                    else
                    {
                        notBuildMode.buildDonateButton.interactable = false;
                    }
                }
                else 
                {
                    notBuildMode.buildDonateButton.interactable = false;
                    notBuildMode.buildButton.interactable = false;
                }
                break;
            case BuildingState.build:
                // TODO: building build time bu
                generalOnTapAction.BuildTab();
                //workerObj.SetActive(false);
                buildMode.skipButton.onClick.RemoveAllListeners();
                buildMode.skipButton.onClick.AddListener(delegate
                {
                    buildMode.OnSkipButtonClick(gameObject, abstractBuilding.buildUpdateTime[abstractBuilding.level]);
                });
                break;
            case BuildingState.work:
                generalOnTapAction.WorkTab();
                levelTxt.text = abstractBuilding.level.ToString();
                ShowCost(abstractBuilding);
                DisplayBuildingInfo(abstractBuilding);
                //workerObj.SetActive(true);
                // MANAGER
                if (abstractBuilding.managerID != 0)
                {
                    workerImage.gameObject.SetActive(true);
                    noPhoto.gameObject.SetActive(false);
                    workerName.text = jsonReader.employee.worker[abstractBuilding.managerID].name;
                    workerImage.sprite = jsonReader.employee.worker[abstractBuilding.managerID].employeePhoto;
                }
                else
                {
                    workerImage.gameObject.SetActive(false);
                    noPhoto.gameObject.SetActive(true);
                    workerName.text = "No woerker";
                    workerImage.sprite = noPhoto.sprite;
                }
                // REPAIR
                if (abstractBuilding.condition < 100)
                {
                    repairButton.interactable = true;
                    repairPrice.gameObject.SetActive(true);
                    //repairPrice.text = // todo count price for repair
                    repairButton.onClick.RemoveAllListeners();
                    repairButton.onClick.AddListener(delegate
                    {
                        // repair for counted price
                    });
                }
                else
                {
                    repairButton.interactable = false;
                    repairPrice.gameObject.SetActive(false);
                }
                // UPDATE STUFF
                GameManager.instance.onBuildingCondition?.Invoke(abstractBuilding);
                if (abstractBuilding.level <= abstractBuilding.maxLevel)
                {
                    updateButton.gameObject.SetActive(true);
                    updateButtonDonate.gameObject.SetActive(true);
                    costTxt.gameObject.SetActive(true);
                    costDonateTxt.gameObject.SetActive(true);
                    if (money.GetMoney() >= abstractBuilding.updateCost[abstractBuilding.level - 1].moneyCost)
                    {
                        updateButton.interactable = true;
                        updateButton.onClick.RemoveAllListeners();
                        updateButton.onClick.AddListener(delegate
                        {
                            notBuildMode.OnBuildButtonClick(gameObject, abstractBuilding.buildUpdateTime[abstractBuilding.level - 1]);
                            abstractBuilding.SwitchState(BuildingState.build);
                            money.SubstractValue(abstractBuilding.updateCost[abstractBuilding.level - 1].moneyCost);
                        });
                    }
                    else
                    {
                        updateButton.interactable = false;
                    }
                    if (money.GetDonate() >= abstractBuilding.updateCost[abstractBuilding.level - 1].donateCost)
                    {
                        updateButtonDonate.interactable = true;
                        updateButtonDonate.onClick.RemoveAllListeners();
                        updateButtonDonate.onClick.AddListener(delegate
                        {
                            notBuildMode.OnBuildButtonClick(gameObject, abstractBuilding.buildUpdateTime[abstractBuilding.level - 1]);
                            abstractBuilding.currentBuildingState = BuildingState.build;
                            //abstractBuilding.GameObjectInitialization();
                            //ChangeState(abstractBuilding);
                            money.SubstractDonateValue(abstractBuilding.updateCost[abstractBuilding.level].donateCost);
                        });
                    }
                    else
                    {
                        updateButtonDonate.interactable = false;
                    }
                }
                else
                {
                    updateButton.gameObject.SetActive(false);
                    updateButtonDonate.gameObject.SetActive(false);
                    costTxt.gameObject.SetActive(false);
                    costDonateTxt.gameObject.SetActive(false);
                }
                break;
            case BuildingState.notwork:
                generalOnTapAction.NotWorkTab();
                break;
        }
    }


    private void DisplayBuildingInfo(AbstractBuilding abstractBuilding)
    {
        switch(abstractBuilding)
        {
            case BlockOne:
                info1Name.text = "Disk Amount";
                info1Txt.text = buildingManager.blockOne.disckAmount[buildingManager.blockOne.level - 1].ToString();
                info2Name.text = "Eco";
                info2Txt.text = buildingManager.blockOne.eco[buildingManager.blockOne.level - 1].ToString();
                if (abstractBuilding.level <= abstractBuilding.maxLevel)
                {
                    upgrade1.gameObject.SetActive(true);
                    upgrade2.gameObject.SetActive(true);
                    upgrade1.text = buildingManager.blockOne.disckAmount[buildingManager.blockOne.level].ToString();
                    upgrade2.text = buildingManager.blockOne.disckAmount[buildingManager.blockOne.level].ToString();
                }
                else
                {
                    upgrade1.gameObject.SetActive(false);
                    upgrade2.gameObject.SetActive(false);
                }
                break;
            case BlockTwo:
                info1Name.text = "Disk Amount";
                info1Txt.text = buildingManager.blockTwo.disckAmount[buildingManager.blockTwo.level - 1].ToString();
                info2Name.text = "Eco";
                info2Txt.text = buildingManager.blockTwo.eco[buildingManager.blockTwo.level - 1].ToString();
                if (abstractBuilding.level <= abstractBuilding.maxLevel)
                {
                    upgrade1.gameObject.SetActive(true);
                    upgrade2.gameObject.SetActive(true);
                    upgrade1.text = buildingManager.blockTwo.disckAmount[buildingManager.blockTwo.level].ToString();
                    upgrade2.text = buildingManager.blockTwo.disckAmount[buildingManager.blockTwo.level].ToString();
                }
                else
                {
                    upgrade1.gameObject.SetActive(false);
                    upgrade2.gameObject.SetActive(false);
                }
                break;
            case BlockThree:
                info1Name.text = "Disk Amount";
                info1Txt.text = buildingManager.blockThree.disckAmount[buildingManager.blockThree.level - 1].ToString();
                info2Name.text = "Eco";
                info2Txt.text = buildingManager.blockThree.eco[buildingManager.blockThree.level - 1].ToString();
                if (abstractBuilding.level <= abstractBuilding.maxLevel)
                {
                    upgrade1.gameObject.SetActive(true);
                    upgrade2.gameObject.SetActive(true);
                    upgrade1.text = buildingManager.blockThree.disckAmount[buildingManager.blockThree.level].ToString();
                    upgrade2.text = buildingManager.blockThree.disckAmount[buildingManager.blockThree.level].ToString();
                }
                else
                {
                    upgrade1.gameObject.SetActive(false);
                    upgrade2.gameObject.SetActive(false);
                }
                break;
            case BlockFour:
                info1Name.text = "Disk Amount";
                info1Txt.text = buildingManager.blockFour.disckAmount[buildingManager.blockFour.level - 1].ToString();
                info2Name.text = "Eco";
                info2Txt.text = buildingManager.blockFour.eco[buildingManager.blockFour.level - 1].ToString();
                if (abstractBuilding.level <= abstractBuilding.maxLevel)
                {
                    upgrade1.gameObject.SetActive(true);
                    upgrade2.gameObject.SetActive(true);
                    upgrade1.text = buildingManager.blockFour.disckAmount[buildingManager.blockFour.level].ToString();
                    upgrade2.text = buildingManager.blockFour.disckAmount[buildingManager.blockFour.level].ToString();
                }
                else
                {
                    upgrade1.gameObject.SetActive(false);
                    upgrade2.gameObject.SetActive(false);
                }
                break;
            case CoalStorage:
                info1Name.text = "Volume";
                info1Txt.text = buildingManager.coalStorage.volume[buildingManager.coalStorage.level - 1].ToString();
                info2Name.text = "Occupancy";
                info2Txt.text = buildingManager.coalStorage.occupancy.ToString();
                if (abstractBuilding.level <= abstractBuilding.maxLevel)
                {
                    upgrade1.gameObject.SetActive(true);
                    upgrade2.gameObject.SetActive(false);
                    upgrade1.text = buildingManager.coalStorage.volume[buildingManager.coalStorage.level].ToString();
                }
                else
                {
                    upgrade1.gameObject.SetActive(false);
                }
                break;
            case ElectricalSubstation:
                info1Name.text = "Current loss";
                info1Txt.text = buildingManager.electricalSubstation.loss[buildingManager.electricalSubstation.level - 1].ToString();
                info2Name.text = "Load";
                info2Txt.text = buildingManager.electricalSubstation.load[buildingManager.electricalSubstation.level - 1].ToString();
                if (abstractBuilding.level <= abstractBuilding.maxLevel)
                {
                    upgrade1.gameObject.SetActive(true);
                    upgrade2.gameObject.SetActive(true);
                    upgrade1.text = buildingManager.electricalSubstation.loss[buildingManager.electricalSubstation.level].ToString();
                    upgrade2.text = buildingManager.electricalSubstation.load[buildingManager.electricalSubstation.level].ToString();
                }
                else
                {
                    upgrade1.gameObject.SetActive(false);
                    upgrade2.gameObject.SetActive(false);
                }
                break;
            case BoatDocks:
                info1Name.text = "Amount";
                info1Txt.text = buildingManager.boatDock.boatAmount[buildingManager.boatDock.level - 1].ToString();
                info2Name.text = "Efficiency";
                info2Txt.text = buildingManager.boatDock.efficiency[buildingManager.boatDock.level - 1].ToString();
                if (abstractBuilding.level <= abstractBuilding.maxLevel)
                {
                    upgrade1.gameObject.SetActive(true);
                    upgrade2.gameObject.SetActive(true);
                    upgrade1.text = buildingManager.boatDock.boatAmount[buildingManager.boatDock.level].ToString();
                    upgrade2.text = buildingManager.boatDock.efficiency[buildingManager.boatDock.level].ToString();
                }
                else
                {
                    upgrade1.gameObject.SetActive(false);
                    upgrade2.gameObject.SetActive(false);
                }
                break;
            case FuelStorage:
                info1Name.text = "Volume";
                info1Txt.text = buildingManager.fuelStorage.volume[buildingManager.fuelStorage.level - 1].ToString();
                info2Name.text = "Occupancy";
                info2Txt.text = buildingManager.fuelStorage.occupancy.ToString();
                if (abstractBuilding.level <= abstractBuilding.maxLevel)
                {
                    upgrade1.gameObject.SetActive(true);
                    upgrade2.gameObject.SetActive(false);
                    upgrade1.text = buildingManager.fuelStorage.volume[buildingManager.fuelStorage.level].ToString();
                }
                else
                {
                    upgrade1.gameObject.SetActive(false);
                }
                break;
            case PumpStation:
                info1Name.text = "Pump amount";
                info1Txt.text = buildingManager.pumpStation.pumpAmount[buildingManager.pumpStation.level - 1].ToString();
                info2Name.text = "Pump power";
                info2Txt.text = buildingManager.pumpStation.pumpPower[buildingManager.pumpStation.level - 1].ToString();
                if (abstractBuilding.level <= abstractBuilding.maxLevel)
                {
                    upgrade1.gameObject.SetActive(true);
                    upgrade2.gameObject.SetActive(true);
                    upgrade1.text = buildingManager.pumpStation.pumpAmount[buildingManager.pumpStation.level].ToString();
                    upgrade2.text = buildingManager.pumpStation.pumpPower[buildingManager.pumpStation.level].ToString();
                }
                else
                {
                    upgrade1.gameObject.SetActive(false);
                    upgrade2.gameObject.SetActive(false);
                }
                break;
            case TrainDocks:
                info1Name.text = "Train amount";
                info1Txt.text = buildingManager.trainDock.trainAmount[buildingManager.trainDock.level - 1].ToString();
                info2Name.text = "Efficiency";
                info2Txt.text = buildingManager.trainDock.efficiency[buildingManager.trainDock.level - 1].ToString();
                if (abstractBuilding.level <= abstractBuilding.maxLevel)
                {
                    upgrade1.gameObject.SetActive(true);
                    upgrade2.gameObject.SetActive(true);
                    upgrade1.text = buildingManager.trainDock.trainAmount[buildingManager.trainDock.level].ToString();
                    upgrade2.text = buildingManager.trainDock.efficiency[buildingManager.trainDock.level].ToString();
                }
                else
                {
                    upgrade1.gameObject.SetActive(false);
                    upgrade2.gameObject.SetActive(false);
                }
                break;
            case WaterTreatment:
                info1Name.text = "Throughput";
                info1Txt.text = buildingManager.waterTreatment.throughput[buildingManager.waterTreatment.level - 1].ToString();
                info2Name.text = "Efficiency";
                info2Txt.text = buildingManager.waterTreatment.efficiency[buildingManager.waterTreatment.level - 1].ToString();
                if (abstractBuilding.level <= abstractBuilding.maxLevel)
                {
                    upgrade1.gameObject.SetActive(true);
                    upgrade2.gameObject.SetActive(true);
                    upgrade1.text = buildingManager.waterTreatment.throughput[buildingManager.waterTreatment.level].ToString();
                    upgrade2.text = buildingManager.waterTreatment.efficiency[buildingManager.waterTreatment.level].ToString();
                }
                else
                {
                    upgrade1.gameObject.SetActive(false);
                    upgrade2.gameObject.SetActive(false);
                }
                break;
            case CoolingTower:
                info1Name.text = "Throughput";
                info1Txt.text = buildingManager.coolingTower.throughput[buildingManager.coolingTower.level - 1].ToString();
                info2Name.text = "Efficiency";
                info2Txt.text = buildingManager.coolingTower.efficiency[buildingManager.coolingTower.level - 1].ToString();
                if (abstractBuilding.level <= abstractBuilding.maxLevel)
                {
                    upgrade1.gameObject.SetActive(true);
                    upgrade2.gameObject.SetActive(true);
                    upgrade1.text = buildingManager.coolingTower.throughput[buildingManager.coolingTower.level].ToString();
                    upgrade2.text = buildingManager.coolingTower.efficiency[buildingManager.coolingTower.level].ToString();
                }
                else
                {
                    upgrade1.gameObject.SetActive(false);
                    upgrade2.gameObject.SetActive(false);
                }
                break;
            case Security:
                info1Name.text = "Efficiency";
                info1Txt.text = buildingManager.security.efficiency[buildingManager.security.level - 1].ToString();
                info2Name.text = "Efficiency";
                info2Txt.text = buildingManager.security.security[buildingManager.security.level - 1].ToString();
                if (abstractBuilding.level <= abstractBuilding.maxLevel)
                {
                    upgrade1.gameObject.SetActive(true);
                    upgrade2.gameObject.SetActive(true);
                    upgrade1.text = buildingManager.security.efficiency[buildingManager.security.level].ToString();
                    upgrade2.text = buildingManager.security.security[buildingManager.security.level].ToString();
                }
                else
                {
                    upgrade1.gameObject.SetActive(false);
                    upgrade2.gameObject.SetActive(false);
                }
                break;
        }
    }

    public void ShowCost(AbstractBuilding abstractBuilding)
    {
        costTxt.gameObject.SetActive(true);
        costDonateTxt.gameObject.SetActive(true);
        costTxt.text = abstractBuilding.updateCost[abstractBuilding.level].moneyCost.ToString();
        costDonateTxt.text = abstractBuilding.updateCost[abstractBuilding.level].donateCost.ToString();
    }
}
