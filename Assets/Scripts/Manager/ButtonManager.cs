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

    [SerializeField] private ControlScheme controlScheme;



    private void Start()
    {
        shopPan.SetActive(false);
        managmentPan.SetActive(false);
        townPan.SetActive(false);
        materialShopPan.SetActive(false);
    }
    public void OnShopPanButton()
    {
        if(!shopPan.activeSelf)
        {
            shopPan.SetActive(true);
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

}
