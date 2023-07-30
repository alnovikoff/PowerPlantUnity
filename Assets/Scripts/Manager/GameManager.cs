using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using Unity.VisualScripting;

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
    [SerializeField] public OnTapAction onTapAction;
    [SerializeField] public HRManagment hrManagment;
    [SerializeField] private RandomEvents randomEvents;

    [Header("Manager UI")]
    [SerializeField] private TMP_Text coalConsumptionTxt;
    [SerializeField] private TMP_Text waterConsumptionTxt;

    [SerializeField] private RectTransform arrow;
    [SerializeField] private float minArrow;
    [SerializeField] private float maxArrow;

    public static GameManager instance;

    public Action onChangeElectricity;
    public Action onChangeRequredElectricity;
    public Action onChangeLevel;
    public Action onBuilder;
    public Action onFailture;
    public Action onGameEvent;

    public Action<AbstractBuilding, GameObject> OnBuildingTapAction;
    public Action<AbstractBuilding> OnHRAction;

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
        OnBuildingTapAction += onTapAction.MakeAction;
        onBuilder += UpdateBuilders;
        onChangeElectricity += UpdateElectricityProduction;
        onChangeRequredElectricity += UpdateRequiredElecticity;
        onChangeLevel += LevelUpdate;
        onBuildingCondition += workMode.DisplayCondition;
        onFailture += failturesChecker.PumpsOff;
        //onGameEvent += randomEvents.OnGameEventPopUp;
        //onChangeElectricity?.Invoke();
        onChangeRequredElectricity?.Invoke();
        onBuilder?.Invoke();
    }

    private void Update()
    {
        timeManager.Clock();
        //UpdateMonometer();
    }

    //TODO monometer
    public void UpdateMonometer()
    {
        if (arrow != null)
        {
            arrow.localEulerAngles = new Vector3(0, 0, Mathf.Lerp(minArrow, maxArrow, buildingManager.pumpStation.currentPressure / buildingManager.pumpStation.maxPressure));
        }
    }

    public void UpdateElectricityProduction()
    {
        electricityTxt.text = (mainAlgorithm.BlockOneProducedElectricity(buildingManager.coalStorage.quality, buildingManager.blockOne.disckAmount[buildingManager.blockOne.level - 1], controlSlidersManager.OnBlock1OwenSlider(), controlSlidersManager.OnBlock1GeneratorSlider()) 
                            + mainAlgorithm.BlockTwoProducedElectricity(buildingManager.coalStorage.quality, buildingManager.blockTwo.disckAmount[buildingManager.blockTwo.level], controlSlidersManager.OnBlock2OwenSlider(), controlSlidersManager.OnBlock2GeneratorSlider())
                            + mainAlgorithm.BlockThreeProducedElectricity(buildingManager.coalStorage.quality, buildingManager.blockThree.disckAmount[buildingManager.blockThree.level], controlSlidersManager.OnBlock3OwenSlider(), controlSlidersManager.OnBlock3GeneratorSlider())
                            + mainAlgorithm.BlockFourProducedElectricity(buildingManager.coalStorage.quality, buildingManager.blockFour.disckAmount[buildingManager.blockFour.level], controlSlidersManager.OnBlock4OwenSlider(), controlSlidersManager.OnBlock4GeneratorSlider())).ToString();

        coalConsumptionTxt.text = (coalConsumption.Owen1CoalConsumption(controlSlidersManager.OnBlock1OwenSlider(), buildingManager.blockOne.eco[buildingManager.blockOne.level - 1]) 
            + coalConsumption.Owen2CoalConsumption(controlSlidersManager.OnBlock2OwenSlider(), buildingManager.blockTwo.eco[buildingManager.blockTwo.level])
            + coalConsumption.Owen3CoalConsumption(controlSlidersManager.OnBlock3OwenSlider(), buildingManager.blockThree.eco[buildingManager.blockThree.level])
            + coalConsumption.Owen4CoalConsumption(controlSlidersManager.OnBlock4OwenSlider(), buildingManager.blockFour.eco[buildingManager.blockFour.level])).ToString();

        waterConsumptionTxt.text = (waterConsumption.WaterConsumptionFunc((controlSlidersManager.OnBlock1GeneratorSlider() 
                                                                            + controlSlidersManager.OnBlock2GeneratorSlider() 
                                                                            + controlSlidersManager.OnBlock3GeneratorSlider() 
                                                                            + controlSlidersManager.OnBlock4GeneratorSlider()), buildingManager.pumpStation.pumpPower[buildingManager.pumpStation.level - 1]).ToString());
    }

    public void UpdateRequiredElecticity()
    {
        currentRequiredElectricity.text = (townMapManager.regonOne.RequiredElectricityToCount(0) + townMapManager.regonTwo.RequiredElectricityToCount(1)+ townMapManager.regonThree.RequiredElectricityToCount(2)
                                        + townMapManager.regonFour.RequiredElectricityToCount(3) + townMapManager.regonFive.RequiredElectricityToCount(4) + townMapManager.regonSix.RequiredElectricityToCount(5)).ToString();
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
