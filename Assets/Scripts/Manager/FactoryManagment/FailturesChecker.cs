using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FailturesChecker : MonoBehaviour
{
    [SerializeField] private BuildingManager buildingManager;
    [SerializeField] private ControlScheme controlScheme;
    [SerializeField] private ControlButtonsManager controlButtonsManager;

    public bool isPumpOff;

    private void Start()
    {
        PumpsOff();
        controlButtonsManager.SetBlocksButtons();
    }

    public void PumpsOff()
    {
        if(buildingManager.pumpStation.GetActivePump() == 0)
        {
            isPumpOff = true;
            controlButtonsManager.SetBlocksButtons();
            if (buildingManager.blockOne.currentBuildingState == BuildingManager.BuildingState.work)
            {
                buildingManager.blockOne.currentBuildingState = BuildingManager.BuildingState.notwork;
                controlScheme.ChangeBlock1Color();
                DataManager.gameData.block1State = (int)controlScheme.buildingManager.blockOne.currentBuildingState;
            }
            if (buildingManager.blockTwo.currentBuildingState == BuildingManager.BuildingState.work)
            {
                buildingManager.blockTwo.currentBuildingState = BuildingManager.BuildingState.notwork;
                controlScheme.ChangeBlock2Color();
                DataManager.gameData.block2State = (int)controlScheme.buildingManager.blockTwo.currentBuildingState;
            }
            if (buildingManager.blockThree.currentBuildingState == BuildingManager.BuildingState.work)
            {
                buildingManager.blockThree.currentBuildingState = BuildingManager.BuildingState.notwork;
                controlScheme.ChangeBlock3Color();
                DataManager.gameData.block3State = (int)controlScheme.buildingManager.blockThree.currentBuildingState;
            }
            if (buildingManager.blockFour.currentBuildingState == BuildingManager.BuildingState.work)
            {
                buildingManager.blockFour.currentBuildingState = BuildingManager.BuildingState.notwork;
                controlScheme.ChangeBlock4Color();
                DataManager.gameData.block4State = (int)controlScheme.buildingManager.blockFour.currentBuildingState;
            }
            GameManager.instance.onChangeElectricity?.Invoke();
            SaveSystem.Save(DataManager.gameData);
        }
    }
}
