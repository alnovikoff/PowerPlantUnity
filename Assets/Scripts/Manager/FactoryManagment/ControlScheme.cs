using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlScheme : MonoBehaviour
{
    public BuildingManager buildingManager;

    [SerializeField] private Image block1;
    [SerializeField] private Image block2;
    [SerializeField] private Image block3;
    [SerializeField] private Image block4;
    [SerializeField] private Image pump1;
    [SerializeField] private Image pump2;
    [SerializeField] private Image pump3;
    [SerializeField] private Image pump4;

    [SerializeField] private Image block2Control;
    [SerializeField] private Image block3Control;
    [SerializeField] private Image block4Control;

    private Color workColor = new Color32(0, 255, 6, 255);
    private Color notWorkColor = new Color32(255, 0, 6, 255);

    public void InitializeControlScheme()
    {
        ChangeBlock1Color();
        ChangeBlock2Color();
        ChangeBlock3Color();
        ChangeBlock4Color();
        ChangePumpOneColor();
        ChangePumpTwoColor();
        ChangePumpThreeColor();
        ChangePumpFourColor();
    }

    public void ChangeBlock1Color()
    {
        if (buildingManager.blockOne.currentBuildingState == BuildingManager.BuildingState.work)
        {
            block1.color = workColor;
        }
        else
        {
            block1.color = notWorkColor;
        }
    }

    public void ChangeBlock2Color()
    {
        if (buildingManager.blockTwo.currentBuildingState == BuildingManager.BuildingState.work)
        {
            block2Control.gameObject.SetActive(false);
            block2.color = workColor;
        }
        else if(buildingManager.blockTwo.currentBuildingState == BuildingManager.BuildingState.notwork)
        {
            block2Control.gameObject.SetActive(false);
            block2.color = notWorkColor;
        }
        else
        {
            block2Control.gameObject.SetActive(true);
        }
    }

    public void ChangeBlock3Color()
    {
        if (buildingManager.blockThree.currentBuildingState == BuildingManager.BuildingState.work)
        {
            block3Control.gameObject.SetActive(false);
            block3.color = workColor;
        }
        else if (buildingManager.blockThree.currentBuildingState == BuildingManager.BuildingState.notwork)
        {
            block3Control.gameObject.SetActive(false);
            block3.color = notWorkColor;
        }
        else
        {
            block3Control.gameObject.SetActive(true);
        }
    }

    public void ChangeBlock4Color()
    {
        if (buildingManager.blockFour.currentBuildingState == BuildingManager.BuildingState.work)
        {
            block4Control.gameObject.SetActive(false);
            block4.color = workColor;
        }
        else if (buildingManager.blockFour.currentBuildingState == BuildingManager.BuildingState.notwork)
        {
            block4Control.gameObject.SetActive(false);
            block4.color = notWorkColor;
        }
        else
        {
            block4Control.gameObject.SetActive(true);
        }
    }

    public void ChangePumpOneColor()
    {
        if (buildingManager.pumpStation.pumpWork[0])
            pump1.color = workColor;
        else
            pump1.color = notWorkColor;
    }

    public void ChangePumpTwoColor()
    {
        if (buildingManager.pumpStation.pumpWork[1])
            pump2.color = workColor;
        else
            pump2.color = notWorkColor;
    }

    public void ChangePumpThreeColor()
    {
        if (buildingManager.pumpStation.pumpWork[2])
            pump3.color = workColor;
        else
            pump3.color = notWorkColor;
    }
    public void ChangePumpFourColor()
    {
        if (buildingManager.pumpStation.pumpWork[3])
            pump4.color = workColor;
        else
            pump4.color = notWorkColor;
    }
}
