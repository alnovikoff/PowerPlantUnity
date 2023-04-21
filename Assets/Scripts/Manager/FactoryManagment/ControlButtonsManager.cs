using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ControlButtonsManager : MonoBehaviour
{
    [SerializeField] private ControlScheme controlScheme;
    [SerializeField] private BuildingManager buildingManager;
    [SerializeField] private FailturesChecker failturesChecker;

    [SerializeField] private Button block1Btn;
    [SerializeField] private Button block2Btn;
    [SerializeField] private Button block3Btn;
    [SerializeField] private Button block4Btn;

    public void SetBlocksButtons()
    {
        if(failturesChecker.isPumpOff)
        {
            block1Btn.enabled = false;
            block2Btn.enabled = false;
            block3Btn.enabled = false;
            block4Btn.enabled = false;
        }
        else
        {
            block1Btn.enabled = true;
            block2Btn.enabled = true;
            block3Btn.enabled = true;
            block4Btn.enabled = true;
        }
    }

    public void OnBlock1Button()
    {
        if(controlScheme.buildingManager.blockOne.currentBuildingState == BuildingManager.BuildingState.work)
        {
            controlScheme.buildingManager.blockOne.currentBuildingState = BuildingManager.BuildingState.notwork;
        }
        else if(controlScheme.buildingManager.blockOne.currentBuildingState == BuildingManager.BuildingState.notwork && !failturesChecker.isPumpOff)
        {
            controlScheme.buildingManager.blockOne.currentBuildingState = BuildingManager.BuildingState.work;
        }
        controlScheme.ChangeBlock1Color();
        DataManager.gameData.block1State = (int)controlScheme.buildingManager.blockOne.currentBuildingState;
        SaveSystem.Save(DataManager.gameData);
        GameManager.instance.onChangeElectricity?.Invoke();
    }

    public void OnBlock2Button()
    {
        if (controlScheme.buildingManager.blockTwo.currentBuildingState == BuildingManager.BuildingState.work)
        {
            controlScheme.buildingManager.blockTwo.currentBuildingState = BuildingManager.BuildingState.notwork;
        }
        else if (controlScheme.buildingManager.blockTwo.currentBuildingState == BuildingManager.BuildingState.notwork && !failturesChecker.isPumpOff)
        {
            controlScheme.buildingManager.blockTwo.currentBuildingState = BuildingManager.BuildingState.work;
        }
        controlScheme.ChangeBlock2Color();
        DataManager.gameData.block2State = (int)controlScheme.buildingManager.blockTwo.currentBuildingState;
        SaveSystem.Save(DataManager.gameData);
        GameManager.instance.onChangeElectricity?.Invoke();
    }

    public void OnBlock3Button()
    {
        if (controlScheme.buildingManager.blockThree.currentBuildingState == BuildingManager.BuildingState.work)
        {
            controlScheme.buildingManager.blockThree.currentBuildingState = BuildingManager.BuildingState.notwork;
        }
        else if (controlScheme.buildingManager.blockThree.currentBuildingState == BuildingManager.BuildingState.notwork && !failturesChecker.isPumpOff)
        {
            controlScheme.buildingManager.blockThree.currentBuildingState = BuildingManager.BuildingState.work;
        }
        controlScheme.ChangeBlock3Color();
        DataManager.gameData.block3State = (int)controlScheme.buildingManager.blockThree.currentBuildingState;
        SaveSystem.Save(DataManager.gameData);
        GameManager.instance.onChangeElectricity?.Invoke();
    }

    public void OnBlock4Button()
    {
        if (controlScheme.buildingManager.blockFour.currentBuildingState == BuildingManager.BuildingState.work)
        {
            controlScheme.buildingManager.blockFour.currentBuildingState = BuildingManager.BuildingState.notwork;
        }
        else if (controlScheme.buildingManager.blockFour.currentBuildingState == BuildingManager.BuildingState.notwork && !failturesChecker.isPumpOff)
        {
            controlScheme.buildingManager.blockFour.currentBuildingState = BuildingManager.BuildingState.work;
        }
        controlScheme.ChangeBlock4Color();
        DataManager.gameData.block4State = (int)controlScheme.buildingManager.blockFour.currentBuildingState;
        SaveSystem.Save(DataManager.gameData);
        GameManager.instance.onChangeElectricity?.Invoke();
    }

    public void OnPumpOne()
    {
        if (!buildingManager.pumpStation.pumpWork[0])
        {
            buildingManager.pumpStation.pumpWork[0] = true;
            if (failturesChecker.isPumpOff)
            {
                failturesChecker.isPumpOff = false;
                SetBlocksButtons();
            }
        }
        else
        {
            buildingManager.pumpStation.pumpWork[0] = false;
        }
        controlScheme.ChangePumpOneColor();
        GameManager.instance.onFailture?.Invoke();
        GameManager.instance.onChangeElectricity?.Invoke();
        DataManager.gameData.workPumps[0] = buildingManager.pumpStation.pumpWork[0];
        SaveSystem.Save(DataManager.gameData);
    }

    public void OnPumpTwo()
    {
        if (!buildingManager.pumpStation.pumpWork[1])
        {
            buildingManager.pumpStation.pumpWork[1] = true;
            if (failturesChecker.isPumpOff)
            {
                failturesChecker.isPumpOff = false;
                SetBlocksButtons();
            }
        }
        else
        {
            buildingManager.pumpStation.pumpWork[1] = false;
        }
        controlScheme.ChangePumpTwoColor();
        GameManager.instance.onFailture?.Invoke();
        GameManager.instance.onChangeElectricity?.Invoke();
        DataManager.gameData.workPumps[1] = buildingManager.pumpStation.pumpWork[1];
        SaveSystem.Save(DataManager.gameData);
    }

    public void OnPumpThree()
    {
        if (!buildingManager.pumpStation.pumpWork[2])
        {
            buildingManager.pumpStation.pumpWork[2] = true;
            if (failturesChecker.isPumpOff)
            {
                failturesChecker.isPumpOff = false;
                SetBlocksButtons();
            }
        }
        else
        {
            buildingManager.pumpStation.pumpWork[2] = false;
        }
        controlScheme.ChangePumpThreeColor();
        GameManager.instance.onFailture?.Invoke();
        GameManager.instance.onChangeElectricity?.Invoke();
        DataManager.gameData.workPumps[2] = buildingManager.pumpStation.pumpWork[2];
        SaveSystem.Save(DataManager.gameData);
    }
    public void OnPumpFour()
    {
        if (!buildingManager.pumpStation.pumpWork[3])
        {
            buildingManager.pumpStation.pumpWork[3] = true;
            if (failturesChecker.isPumpOff)
            {
                failturesChecker.isPumpOff = false;
                SetBlocksButtons();
            }
        }
        else
        {
            buildingManager.pumpStation.pumpWork[3] = false;
        }
        controlScheme.ChangePumpFourColor();
        GameManager.instance.onFailture?.Invoke();
        GameManager.instance.onChangeElectricity?.Invoke();
        DataManager.gameData.workPumps[3] = buildingManager.pumpStation.pumpWork[3];
        SaveSystem.Save(DataManager.gameData);
    }
    


}
