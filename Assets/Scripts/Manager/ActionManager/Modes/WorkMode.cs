using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class WorkMode : MonoBehaviour
{
    [SerializeField] private TMP_Text buildingConditionTxt;
    [SerializeField] private Image buildingConditionImg;



    public void DisplayCondition(AbstractBuilding abstractBuilding)
    {
        buildingConditionTxt.text = abstractBuilding.condition.ToString();
        buildingConditionImg.fillAmount = (float)(abstractBuilding.condition / 100f);
    }
}
