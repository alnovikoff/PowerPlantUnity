using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class GameManager : MonoBehaviour
{
    [Header("UI Text")]
    [SerializeField] private TMP_Text electricityTxt;
    [SerializeField] private TMP_Text happinessTxt;
    [SerializeField] private TMP_Text moneyTxt;
    [SerializeField] private TMP_Text donateTxt;
    [SerializeField] private TMP_Text currentRequiredElectricity;
    [SerializeField] private TMP_Text currentFreeBuildersTxt;


    [Header("Class Objects")]
    [SerializeField] private MainAlgorithm mainAlgorithm;
    [SerializeField] private CoalConsumption coalConsumption;
    [SerializeField] private WaterConsumption waterConsumption;
    [SerializeField] public Money money;
    [SerializeField] private ControlSlidersManager controlSlidersManager;
    [SerializeField] private TimeManager timeManager;
    [SerializeField] public PlayerLevelManager playerLevelManager;
    [SerializeField] private WorkMode workMode;
    [SerializeField] private TownMapManager townMapManager;
    [SerializeField] private BuilderManager builderManager;
    [SerializeField] private BuildingManager buildingManager;
    [SerializeField] private FailturesChecker failturesChecker;

    [Header("Manager UI")]
    [SerializeField] private TMP_Text coalConsumptionTxt;
    [SerializeField] private TMP_Text waterConsumptionTxt;
    

    public static GameManager instance;

    public Action onChangeElectricity;
    public Action onChangeRequredElectricity;
    public Action onChangeLevel;
    public Action onBuilder;
    public Action onFailture;

    public Action<AbstractBuilding> onBuildingCondition;
    private void Awake()
    {
        if(instance == null) 
        {
            instance = this;
        }
    }

    private void Start()
    {
        onBuilder += UpdateBuilders;
        onChangeElectricity += UpdateElectricityProduction;
        onChangeRequredElectricity += UpdateRequiredElecticity;
        onChangeLevel += LevelUpdate;
        onBuildingCondition += workMode.DisplayCondition;
        onFailture += failturesChecker.PumpsOff; 
        //onChangeElectricity?.Invoke();
        onChangeRequredElectricity?.Invoke();
        onBuilder?.Invoke();
    }

    private void Update()
    {
        timeManager.Clock();
    }


    public void UpdateElectricityProduction()
    {
        electricityTxt.text = (mainAlgorithm.BlockOneProducedElectricity(23, buildingManager.blockOne.disckAmount[buildingManager.blockOne.level], controlSlidersManager.OnBlock1OwenSlider(), controlSlidersManager.OnBlock1GeneratorSlider()) 
                            + mainAlgorithm.BlockTwoProducedElectricity(23, buildingManager.blockTwo.disckAmount[buildingManager.blockTwo.level], controlSlidersManager.OnBlock2OwenSlider(), controlSlidersManager.OnBlock2GeneratorSlider())
                            + mainAlgorithm.BlockThreeProducedElectricity(23, buildingManager.blockThree.disckAmount[buildingManager.blockThree.level], controlSlidersManager.OnBlock3OwenSlider(), controlSlidersManager.OnBlock3GeneratorSlider())
                            + mainAlgorithm.BlockFourProducedElectricity(23, buildingManager.blockFour.disckAmount[buildingManager.blockFour.level], controlSlidersManager.OnBlock4OwenSlider(), controlSlidersManager.OnBlock4GeneratorSlider())).ToString();

        coalConsumptionTxt.text = (coalConsumption.Owen1CoalConsumption(controlSlidersManager.OnBlock1OwenSlider(), buildingManager.blockOne.eco[buildingManager.blockOne.level]) 
            + coalConsumption.Owen2CoalConsumption(controlSlidersManager.OnBlock2OwenSlider(), buildingManager.blockTwo.eco[buildingManager.blockTwo.level])
            + coalConsumption.Owen3CoalConsumption(controlSlidersManager.OnBlock3OwenSlider(), buildingManager.blockThree.eco[buildingManager.blockThree.level])
            + coalConsumption.Owen4CoalConsumption(controlSlidersManager.OnBlock4OwenSlider(), buildingManager.blockFour.eco[buildingManager.blockFour.level])).ToString();

        waterConsumptionTxt.text = (waterConsumption.WaterConsumptionFunc((controlSlidersManager.OnBlock1GeneratorSlider() 
                                                                            + controlSlidersManager.OnBlock2GeneratorSlider() 
                                                                            + controlSlidersManager.OnBlock3GeneratorSlider() 
                                                                            + controlSlidersManager.OnBlock4GeneratorSlider()), buildingManager.pumpStation.pumpPower[buildingManager.pumpStation.level]).ToString());
    }

    public void UpdateRequiredElecticity()
    {
        currentRequiredElectricity.text = (townMapManager.regonOne.RequiredElectricity() + townMapManager.regonTwo.RequiredElectricity() + townMapManager.regonThree.RequiredElectricity()
                                        + townMapManager.regonFour.RequiredElectricity() + townMapManager.regonFive.RequiredElectricity() + townMapManager.regonSix.RequiredElectricity()).ToString();
    }

    public void UpdateBuilders()
    {
        currentFreeBuildersTxt.text = builderManager.GetBuidlderAmount() + " / " + builderManager.GetCurrentFreeBuilder();
    }

    public void LevelUpdate()
    {
        //playerLevelManager.UpdateXpUI();
        //playerLevelManager.UpdateLevel();
    }
}
