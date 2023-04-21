using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NotBuildMode : MonoBehaviour
{
    [SerializeField] GeneralOnTapAction action;
    [SerializeField] private BuildTime buildTime;
    [SerializeField] public Button buildButton;
    [SerializeField] public Button buildDonateButton;

    public void OnBuildButtonClick(GameObject gameObj, BuildUpdateTime buildUpdateTimes)
    {
        buildTime.StartTimer(buildUpdateTimes, gameObj);
        action.AutoClose();
    }
}
