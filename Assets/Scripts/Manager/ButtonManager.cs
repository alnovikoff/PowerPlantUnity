using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;
using System.Threading;
using TMPro;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    [Header("GameObjects")]
    [SerializeField] private GameObject shopPan;
    [SerializeField] private GameObject managmentPan;
    [SerializeField] private GameObject townPan;
    [SerializeField] private GameObject materialShopPan;
    [SerializeField] private GameObject hrManagmentPan;
    [SerializeField] private GameObject employeeHiretap;
    [SerializeField] private GameObject researchInstitutePan;

    [SerializeField] private CameraController cameraController;
    [SerializeField] private ControlScheme controlScheme;
    [SerializeField] private HRManagment hRManagment;
    [SerializeField] private ResourceShopManagment resourceShopManagment;

    [SerializeField] private TabGroup emplyeeTab;
    [SerializeField] private TabBtn emplyeeBtn;

    [SerializeField] private GameObject shopHolder;
    [SerializeField] private ResourceDeliveries resourceDeliveries;
    //[SerializeField] private TabGroup donateTab;
    //[SerializeField] private TabBtn donateBtn;

    [SerializeField] private GameObject UI1not;
    [SerializeField] private GameObject UI2not;
    [SerializeField] private GameObject UI3buildMode;
    [SerializeField] private GameObject grid;



    private void Start()
    {
        grid.SetActive(false);
        employeeHiretap.SetActive(false);
        shopPan.SetActive(false);
        managmentPan.SetActive(false);
        townPan.SetActive(false);
        materialShopPan.SetActive(false);
        hrManagmentPan.SetActive(false);
        UI1not.SetActive(true);
        UI2not.SetActive(true);
        UI3buildMode.SetActive(false);
    }
    public void OnShopPanButton()
    {
        if(!shopPan.activeSelf)
        {
            shopPan.SetActive(true);
            //donateTab.OnTabSelected(donateBtn);
        }
        else
        {
            shopPan.SetActive(false);
        }
    }

    public void OnManagmentPanButton()
    {
        if(!managmentPan.activeSelf)
        {
            managmentPan.SetActive(true);
            controlScheme.InitializeControlScheme();
        }
    }

    public void OnManagmentPanButtonClose()
    {
        if (managmentPan.activeSelf)
        {
            managmentPan.SetActive(false);
        }
    }

    public void OnTownPanButtonOpen()
    {
        if (!townPan.activeSelf)
        {
            townPan.SetActive(true);
        }
    }

    public void OnTownPanButtonClose()
    {
        if (townPan.activeSelf)
        {
            townPan.SetActive(false);
        }
    }

    public void OnMaterialShopPanOpen()
    {
        if(!materialShopPan.activeSelf)
        {
            materialShopPan.SetActive(true);
            shopHolder.SetActive(false);
            if(resourceDeliveries.resourceTime.inProgress)
                resourceDeliveries.InitializeDeliveryData(resourceDeliveries.order[resourceDeliveries.currentIndex]);
            //resourceDeliveries.resourceTime.StartTimer(resourceDeliveries.order[resourceDeliveries.currentIndex], resourceDeliveries.order[resourceDeliveries.currentIndex].startTime, resourceDeliveries.order[resourceDeliveries.currentIndex].endTime, resourceDeliveries.fillImg, resourceDeliveries.timeTxt);
        }
    }

    public void OnMaterialShopPanClose()
    {
        if (materialShopPan.activeSelf)
        {
            materialShopPan.SetActive(false);
        }
    }

    public void OnHRManagmentPanOpen()
    {
        if(!hrManagmentPan.activeSelf)
        {
            hrManagmentPan.SetActive(true);
            
            emplyeeTab.OnTabSelected(emplyeeBtn);
            hRManagment.InitializeOnOpen();
        }
    }

    public void OnHRManagmentPanClose()
    {
        if (hrManagmentPan.activeSelf)
        {
            hrManagmentPan.SetActive(false);
        }
    }

    public void CloseEmployeeHirePan()
    {
        if(employeeHiretap.activeSelf)
        {
            employeeHiretap.SetActive(false);
        }
    }

    public void ResearchInstituteOpen()
    {
        if(!researchInstitutePan.activeSelf)
        {
            researchInstitutePan.SetActive(true);
        }
    }

    public void ResearchInstituteClose()
    {
        if (researchInstitutePan.activeSelf)
        {
            researchInstitutePan.SetActive(false);
        }
    }

    public void OnBuildMode()
    {
        grid.SetActive(true);
        UI1not.SetActive(false);
        UI2not.SetActive(false);
        UI3buildMode.SetActive(true);
        StartCoroutine(cameraController.OnBuildModeEnter());
    }

    public void ExitBuildMode()
    {
        grid.SetActive(false);
        StartCoroutine(cameraController.OnBuildModeExit());
        UI1not.SetActive(true);
        UI2not.SetActive(true);
        UI3buildMode.SetActive(false);
    }
}
