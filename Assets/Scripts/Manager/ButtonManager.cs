using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
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

    [SerializeField] private ControlScheme controlScheme;
    [SerializeField] private HRManagment hRManagment;

    [SerializeField] private TabGroup emplyeeTab;
    [SerializeField] private TabBtn emplyeeBtn;
    //[SerializeField] private TabGroup donateTab;
    //[SerializeField] private TabBtn donateBtn;



    private void Start()
    {
        employeeHiretap.SetActive(false);
        shopPan.SetActive(false);
        managmentPan.SetActive(false);
        townPan.SetActive(false);
        materialShopPan.SetActive(false);
        hrManagmentPan.SetActive(false);
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

}
