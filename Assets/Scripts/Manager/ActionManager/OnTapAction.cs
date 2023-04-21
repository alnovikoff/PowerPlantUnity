using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using static BuildingManager;
using TMPro;
using Unity.VisualScripting;

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

    [SerializeField] public TMP_Text costTxt;
    [SerializeField] public TMP_Text levelTxt;
    [SerializeField] public TMP_Text nameTxt;
    [SerializeField] public TMP_Text costDonateTxt;
    

    

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
                            abstractBuilding.currentBuildingState = BuildingState.build;
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
                GameManager.instance.onBuildingCondition?.Invoke(abstractBuilding);
                if (money.GetMoney() >= abstractBuilding.updateCost[abstractBuilding.level].moneyCost)
                {
                    updateButton.interactable = true;
                    updateButton.onClick.RemoveAllListeners();
                    updateButton.onClick.AddListener(delegate
                    {
                        notBuildMode.OnBuildButtonClick(gameObject, abstractBuilding.buildUpdateTime[abstractBuilding.level]);
                        abstractBuilding.currentBuildingState = BuildingState.build;
                        //abstractBuilding.GameObjectInitialization(); need to change way of updateing prefab change state to update or change prefab initialization???
                        //ChangeState(abstractBuilding);
                        money.SubstractValue(abstractBuilding.updateCost[abstractBuilding.level].moneyCost);
                    });
                }
                else
                {
                    updateButton.interactable = false;
                }
                if (money.GetDonate() >= abstractBuilding.updateCost[abstractBuilding.level].donateCost)
                {
                    updateButtonDonate.interactable = true;
                    updateButtonDonate.onClick.RemoveAllListeners();
                    updateButtonDonate.onClick.AddListener(delegate
                    {
                        notBuildMode.OnBuildButtonClick(gameObject, abstractBuilding.buildUpdateTime[abstractBuilding.level]);
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
                break;
            case BuildingState.notwork:
                generalOnTapAction.NotWorkTab();
                break;
        }
    }

    public void ShowCost(AbstractBuilding abstractBuilding)
    {
        Debug.Log(abstractBuilding.name);
        costTxt.gameObject.SetActive(true);
        costDonateTxt.gameObject.SetActive(true);
        costTxt.text = abstractBuilding.updateCost[abstractBuilding.level].moneyCost.ToString();
        costDonateTxt.text = abstractBuilding.updateCost[abstractBuilding.level].donateCost.ToString();
    }
}
