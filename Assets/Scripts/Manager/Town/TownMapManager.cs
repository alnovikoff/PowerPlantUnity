using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class TownMapManager : MonoBehaviour
{
    [Header("GameObjects")]
    [SerializeField] private GameObject TownMapPan;
    [SerializeField] private GameObject TownManagerPan;

    [Header("Regions")]
    [SerializeField] public TownRegion regonOne;
    [SerializeField] public TownRegion regonTwo;
    [SerializeField] public TownRegion regonThree;
    [SerializeField] public TownRegion regonFour;
    [SerializeField] public TownRegion regonFive;
    [SerializeField] public TownRegion regonSix;

    [Header("TownMapUI")]
    [SerializeField] private TMP_Text townMapHeaderTxt;

    [Header("TownManagmentPan")]
    [SerializeField] private TMP_Text TownManagmentHeaderTxt;
    [SerializeField] private TMP_Text requestedElectricityTxt;
    [SerializeField] public bool[] assignedRegions;
    int token;


    private void Start()
    {
        token = 0;
        TownManagerPan.SetActive(false);
        TownMapPan.SetActive(true);
    }
    public void OnRegion1()
    {
        TownMapPan.SetActive(false);
        TownManagerPan.SetActive(true);
        TownManagmentHeaderTxt.text = "Region One";
        requestedElectricityTxt.text = regonOne.RequiredElectricity().ToString();
        token = 0;
    }

    public void OnRegion2()
    {
        TownMapPan.SetActive(false);
        TownManagerPan.SetActive(true);
        TownManagmentHeaderTxt.text = "Region Two";
        requestedElectricityTxt.text = regonTwo.RequiredElectricity().ToString();
        token = 1;
    }

    public void OnRegion3() 
    {
        TownMapPan.SetActive(false);
        TownManagerPan.SetActive(true);
        TownManagmentHeaderTxt.text = "Region Three";
        requestedElectricityTxt.text = regonThree.RequiredElectricity().ToString();
        token = 2;
    }

    public void OnRegion4()
    {
        TownMapPan.SetActive(false);
        TownManagerPan.SetActive(true);
        TownManagmentHeaderTxt.text = "Region Four";
        requestedElectricityTxt.text = regonFour.RequiredElectricity().ToString();
        token = 3;
    }

    public void OnRegion5()
    {
        TownMapPan.SetActive(false);
        TownManagerPan.SetActive(true);
        TownManagmentHeaderTxt.text = "Region Five";
        requestedElectricityTxt.text = regonFive.RequiredElectricity().ToString();
        token = 4;
    }

    public void OnRegion6()
    {
        TownMapPan.SetActive(false);
        TownManagerPan.SetActive(true);
        TownManagmentHeaderTxt.text = "Region Six";
        requestedElectricityTxt.text = regonSix.RequiredElectricity().ToString();
        token = 5;
    }

    public void BackToMap()
    {
        TownManagerPan.SetActive(false);
        TownMapPan.SetActive(true);
    }

    public void AssignArea()
    {
        switch(token)
        {
            case 0:
                if(!assignedRegions[0])
                {
                    assignedRegions[0] = true;
                }
                else 
                {
                    assignedRegions[0] = false;
                }
                DataManager.gameData.assignedRegions[0] = assignedRegions[0];
                break;
            case 1:
                if(!assignedRegions[1])
                {
                    assignedRegions[1] = true;
                }
                else 
                {
                    assignedRegions[1] = false;
                }
                DataManager.gameData.assignedRegions[1] = assignedRegions[1];
                break;
            case 2:
                if(!assignedRegions[2])
                {
                    assignedRegions[2] = true;
                }
                else 
                {
                    assignedRegions[2] = false;
                }
                DataManager.gameData.assignedRegions[2] = assignedRegions[2];
                break;
            case 3:
                if(!assignedRegions[3])
                {
                    assignedRegions[3] = true;
                }
                else 
                {
                    assignedRegions[3] = false;
                }
                DataManager.gameData.assignedRegions[3] = assignedRegions[3];
                break;
            case 4:
                if(!assignedRegions[4])
                {
                    assignedRegions[4] = true;
                }
                else 
                {
                    assignedRegions[4] = false;
                }
                DataManager.gameData.assignedRegions[4] = assignedRegions[4];
                break;
            case 5:
                if(!assignedRegions[5])
                {
                    assignedRegions[5] = true;
                }
                else 
                {
                    assignedRegions[5] = false;
                }
                DataManager.gameData.assignedRegions[5] = assignedRegions[5];
                break;
        }
        GameManager.instance.onChangeRequredElectricity?.Invoke();
        SaveSystem.Save(DataManager.gameData);
    }

    public void DeassignArea()
    {
        switch (token)
        {
            case 0:
                if (!assignedRegions[0])
                {
                    assignedRegions[0] = true;
                }
                else
                {
                    assignedRegions[0] = false;
                }
                DataManager.gameData.assignedRegions[0] = assignedRegions[0];
                break;
            case 1:
                if (!assignedRegions[1])
                {
                    assignedRegions[1] = true;
                }
                else
                {
                    assignedRegions[1] = false;
                }
                DataManager.gameData.assignedRegions[1] = assignedRegions[1];
                break;
            case 2:
                if (!assignedRegions[2])
                {
                    assignedRegions[2] = true;
                }
                else
                {
                    assignedRegions[2] = false;
                }
                DataManager.gameData.assignedRegions[2] = assignedRegions[2];
                break;
            case 3:
                if (!assignedRegions[3])
                {
                    assignedRegions[3] = true;
                }
                else
                {
                    assignedRegions[3] = false;
                }
                DataManager.gameData.assignedRegions[3] = assignedRegions[3];
                break;
            case 4:
                if (!assignedRegions[4])
                {
                    assignedRegions[4] = true;
                }
                else
                {
                    assignedRegions[4] = false;
                }
                DataManager.gameData.assignedRegions[4] = assignedRegions[4];
                break;
            case 5:
                if (!assignedRegions[5])
                {
                    assignedRegions[5] = true;
                }
                else
                {
                    assignedRegions[5] = false;
                }
                DataManager.gameData.assignedRegions[5] = assignedRegions[5];
                break;
        }
        GameManager.instance.onChangeRequredElectricity?.Invoke();
        SaveSystem.Save(DataManager.gameData);
    }
}
