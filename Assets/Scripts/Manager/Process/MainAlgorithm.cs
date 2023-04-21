using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainAlgorithm : MonoBehaviour
{
    [SerializeField] private BuildingManager buildingManager;

    private int blockOneElectircity;
    private int blockTwoElectircity;
    private int blockThreeElectircity;
    private int blockFourElectircity;

    [SerializeField] private TMP_Text block1electicityTxt;
    [SerializeField] private TMP_Text block2electicityTxt;
    [SerializeField] private TMP_Text block3electicityTxt;
    [SerializeField] private TMP_Text block4electicityTxt;



    public int BlockOneProducedElectricity(float coalQuality, float diskAmount, float owenPower, float generatorPower)
    {
        if (buildingManager.blockOne.currentBuildingState == BuildingManager.BuildingState.work)
        {
            blockOneElectircity = (int)((coalQuality * owenPower) * (diskAmount * generatorPower)) / 10;
            block1electicityTxt.text = blockOneElectircity.ToString();
            return blockOneElectircity;
        }
        else if (buildingManager.blockOne.currentBuildingState == BuildingManager.BuildingState.notwork)
        {
            blockOneElectircity = 0;
            block1electicityTxt.text = blockOneElectircity.ToString();
        }
        return blockOneElectircity;
    }

    public int BlockTwoProducedElectricity(float coalQuality, float diskAmount, float owenPower, float generatorPower)
    {
        if (buildingManager.blockTwo.currentBuildingState == BuildingManager.BuildingState.work)
        {
            blockTwoElectircity = (int)((coalQuality * owenPower) * (diskAmount * generatorPower)) / 10;
            block2electicityTxt.text = blockTwoElectircity.ToString();
            Debug.Log("WORK " + blockTwoElectircity);
            return blockTwoElectircity;
        }
        else if (buildingManager.blockTwo.currentBuildingState == BuildingManager.BuildingState.notwork)
        {
            blockTwoElectircity = 0;
            block2electicityTxt.text = blockTwoElectircity.ToString();
            Debug.Log("NOT WORK " + blockTwoElectircity);
        }
        else
        {
            blockTwoElectircity = 0;
            Debug.Log("BUILD OR NOT BUILD " + blockTwoElectircity);
        }
        return blockTwoElectircity;
    }

    public int BlockThreeProducedElectricity(float coalQuality, float diskAmount, float owenPower, float generatorPower)
    {
        if (buildingManager.blockThree.currentBuildingState == BuildingManager.BuildingState.work)
        {
            blockThreeElectircity = (int)((coalQuality * owenPower) * (diskAmount * generatorPower)) / 10;
            block3electicityTxt.text = blockThreeElectircity.ToString();
            return blockThreeElectircity;
        }
        else if (buildingManager.blockThree.currentBuildingState == BuildingManager.BuildingState.notwork)
        {
            blockThreeElectircity = 0;
            block3electicityTxt.text = blockThreeElectircity.ToString();
        }
        else
        {
            blockThreeElectircity = 0;
        }
        return blockThreeElectircity;
    }

    public int BlockFourProducedElectricity(float coalQuality, float diskAmount, float owenPower, float generatorPower)
    {
        if (buildingManager.blockFour.currentBuildingState == BuildingManager.BuildingState.work)
        {
            blockFourElectircity = (int)((coalQuality * owenPower) * (diskAmount * generatorPower)) / 10;
            block4electicityTxt.text = blockFourElectircity.ToString();
            return blockFourElectircity;
        }
        else if (buildingManager.blockFour.currentBuildingState == BuildingManager.BuildingState.notwork)
        {
            blockFourElectircity = 0;
            block4electicityTxt.text = blockFourElectircity.ToString();
        }
        else
        {
            blockFourElectircity = 0;
        }
        return blockFourElectircity;
    }
}
