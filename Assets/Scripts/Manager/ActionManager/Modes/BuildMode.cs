using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class BuildMode : MonoBehaviour
{
    [SerializeField] GeneralOnTapAction action;
    [SerializeField] private BuildTime buildTime;
    [SerializeField] public Button skipButton;
    public void OnSkipButtonClick(GameObject gameObj, BuildUpdateTime buildUpdateTimes)
    {
        buildTime.SkipTime(buildUpdateTimes, gameObj);
        action.AutoClose();
    }
}
