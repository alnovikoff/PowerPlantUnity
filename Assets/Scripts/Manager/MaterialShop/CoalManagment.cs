using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoalManagment : MonoBehaviour
{
    [SerializeField] private BuildingManager buildingManager;
    [SerializeField] private int currentCoal;
    [SerializeField] private TMP_Text maxCoalTxt;
    [SerializeField] private TMP_Text currentCoalTxt;

    public void ShowCoal()
    {
        currentCoalTxt.text = currentCoal.ToString();
        maxCoalTxt.text = buildingManager.coalStorage.volume.ToString();
    }
}
