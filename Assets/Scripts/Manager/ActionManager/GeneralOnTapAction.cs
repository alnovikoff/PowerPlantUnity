using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GeneralOnTapAction : MonoBehaviour
{
    public BuildingManager buildingManager;
    public OnTapAction onTapAction;
    [Header("UI elements")]
    [SerializeField] private GameObject pan;
    [SerializeField] private TMP_Text headerTxt;
    [SerializeField] public GameObject notBuild, build, work, notWork;

    public void OpenPan()
    {
        pan.SetActive(true);
    }

    public void ClosePan()
    {
        if (EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
        {
            pan.SetActive(false);
            notBuild.SetActive(false);
            build.SetActive(false);
            work.SetActive(false);
            notWork.SetActive(false);
            onTapAction.costTxt.gameObject.SetActive(false);
            onTapAction.costDonateTxt.gameObject.SetActive(false);
        }
    }

    public void AutoClose()
    {
        pan.SetActive(false);
        notBuild.SetActive(false);
        build.SetActive(false);
        work.SetActive(false);
        notWork.SetActive(false);
        onTapAction.costTxt.gameObject.SetActive(false);
        onTapAction.costDonateTxt.gameObject.SetActive(false);
    }

    public void NotBuildTab()
    {
        notBuild.SetActive(true);
        headerTxt.text = "Not build";
    }

    public void BuildTab()
    {
        build.SetActive(true);
        headerTxt.text = "Building";
    }

    public void WorkTab()
    {
        work.SetActive(true);
        headerTxt.text = "Working";
    }

    public void NotWorkTab()
    {
        notWork.SetActive(true);
        headerTxt.text = "Not work";
    }
}
