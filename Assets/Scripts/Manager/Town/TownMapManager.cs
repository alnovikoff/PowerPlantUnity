using System.Collections;
using System.Collections.Generic;
using TMPro;
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

    [Header("Variables")]
    [SerializeField] private int token;

    private void Start()
    {
        TownManagerPan.SetActive(false);
        TownMapPan.SetActive(true);
    }
    public void OnRegion1()
    {
        TownMapPan.SetActive(false);
        TownManagerPan.SetActive(true);
        TownManagmentHeaderTxt.text = "Region One";
        requestedElectricityTxt.text = regonOne.RequiredElectricity().ToString();
        token = 1;
    }

    public void OnRegion2()
    {
        TownMapPan.SetActive(false);
        TownManagerPan.SetActive(true);
        TownManagmentHeaderTxt.text = "Region Two";
        requestedElectricityTxt.text = regonTwo.RequiredElectricity().ToString();
        token = 2;
    }

    public void OnRegion3() 
    {
        TownMapPan.SetActive(false);
        TownManagerPan.SetActive(true);
        TownManagmentHeaderTxt.text = "Region Three";
        requestedElectricityTxt.text = regonThree.RequiredElectricity().ToString();
        token = 3;
    }

    public void OnRegion4()
    {
        TownMapPan.SetActive(false);
        TownManagerPan.SetActive(true);
        TownManagmentHeaderTxt.text = "Region Four";
        requestedElectricityTxt.text = regonFour.RequiredElectricity().ToString();
        token = 4;
    }

    public void OnRegion5()
    {
        TownMapPan.SetActive(false);
        TownManagerPan.SetActive(true);
        TownManagmentHeaderTxt.text = "Region Five";
        requestedElectricityTxt.text = regonFive.RequiredElectricity().ToString();
        token = 5;
    }

    public void OnRegion6()
    {
        TownMapPan.SetActive(false);
        TownManagerPan.SetActive(true);
        TownManagmentHeaderTxt.text = "Region Six";
        requestedElectricityTxt.text = regonSix.RequiredElectricity().ToString();
        token = 6;
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
                return;
            case 1:
                break;
            case 2:
                break;
            case 3:
                break;
            case 4:
                break;
            case 5:
                break;
            case 6:
                break;
        }
        GameManager.instance.onChangeRequredElectricity?.Invoke();
    }

    public void DeassignArea()
    {
        GameManager.instance.onChangeRequredElectricity?.Invoke();
    }
}
