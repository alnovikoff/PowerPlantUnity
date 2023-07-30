using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class ResourceShopManagment : MonoBehaviour
{
    [SerializeField] private BuildingManager buildingManager;

    [SerializeField] private GameObject holder;

    [SerializeField] private UnityEngine.UI.Button coal1Btn;
    [SerializeField] private UnityEngine.UI.Button coal2Btn;
    [SerializeField] private UnityEngine.UI.Button coal3Btn;

    [SerializeField] private UnityEngine.UI.Button fuel1Btn;
    [SerializeField] private UnityEngine.UI.Button fuel2Btn;
    [SerializeField] private UnityEngine.UI.Button fuel3Btn;

    [SerializeField] private TMP_Text nameOfProduct;
    [SerializeField] private TMP_Text efficiency;
    [SerializeField] private TMP_Text storageVolume;
    [SerializeField] private TMP_Text amountOfBuy;
    [SerializeField] private TMP_Text cost;
    [SerializeField] private TMP_Text donateCost;
    [SerializeField] private TMP_Text currenlyAvailableTrainsTxt;

    [SerializeField] private UnityEngine.UI.Slider amountSlider;

    [SerializeField] private UnityEngine.UI.Button buyButton;
    [SerializeField] private UnityEngine.UI.Button buyDonateButton;

    [SerializeField] private ResourceDeliveries resourceDeliveries;

    private void Start()
    {
        holder.SetActive(false);
    }

    public void OnCoal1Button()
    {
        holder.SetActive(true);
        buyButton.interactable = false;
        nameOfProduct.text = coal1Btn.transform.GetChild(0).GetComponent<TMP_Text>().text;
        efficiency.text = string.Empty;
        amountOfBuy.text = 0.ToString();
        storageVolume.text = buildingManager.coalStorage.occupancy + " / " + buildingManager.coalStorage.volume[buildingManager.coalStorage.level];

        buildingManager.trainDock.available = buildingManager.trainDock.trainAmount[buildingManager.trainDock.level - 1];

        cost.text = string.Empty;  // count cost
        donateCost.text = string.Empty;

        amountSlider.maxValue = (buildingManager.coalStorage.volume[buildingManager.coalStorage.level] - buildingManager.coalStorage.occupancy);
        amountSlider.onValueChanged.RemoveAllListeners();
        amountSlider.onValueChanged.AddListener(delegate
        {
            DisplaySliderValue(0.5f, 0.05f);
            if(amountSlider.value > 0 && buildingManager.trainDock.available > 0)
            {
                buyButton.interactable = true;
            }
            else
            {
                buyButton.interactable = false;
            }
        });

        buyButton.onClick.RemoveAllListeners();
        buyButton.onClick.AddListener(delegate
        {
            buildingManager.trainDock.available -= 1;
            Order order = new Order(0, 23, coal1Btn.transform.GetChild(0).GetComponent<TMP_Text>().text, WorldTimeAPI.Instance.GetCurrentDateTime().ToString(), "00:00:00:30", (int)amountSlider.value);
            AddOrder(order);
            
            resourceDeliveries.InitializeDeliveryData(order);
            
        });
    }

    public void OnFuel1Button()
    {
        holder.SetActive(true);
        buyButton.interactable = false;
        nameOfProduct.text = fuel1Btn.transform.GetChild(0).GetComponent<TMP_Text>().text;
        efficiency.text = string.Empty;
        amountOfBuy.text = 0.ToString();
        storageVolume.text = buildingManager.fuelStorage.occupancy + " / " + buildingManager.fuelStorage.volume[buildingManager.fuelStorage.level];

        buildingManager.trainDock.available = buildingManager.trainDock.trainAmount[buildingManager.trainDock.level - 1];

        cost.text = string.Empty;  // count cost
        donateCost.text = string.Empty;

        amountSlider.maxValue = (buildingManager.fuelStorage.volume[buildingManager.fuelStorage.level] - buildingManager.fuelStorage.occupancy);
        amountSlider.onValueChanged.RemoveAllListeners();
        amountSlider.onValueChanged.AddListener(delegate
        {
            DisplaySliderValue(0.5f, 0.05f);
            if (amountSlider.value > 0 && buildingManager.trainDock.available > 0)
            {
                buyButton.interactable = true;
            }
            else
            {
                buyButton.interactable = false;
            }
        });

        buyButton.onClick.RemoveAllListeners();
        buyButton.onClick.AddListener(delegate
        {
            buildingManager.trainDock.available -= 1;
            Order order = new Order(1, 23, fuel1Btn.transform.GetChild(0).GetComponent<TMP_Text>().text, WorldTimeAPI.Instance.GetCurrentDateTime().ToString(), "00:00:00:40", (int)amountSlider.value);
            AddOrder(order);

            resourceDeliveries.InitializeDeliveryData(order);

        });
    }

    private void AddOrder(Order newOrder)
    {
        //newOrder.id = resourceDeliveries.order.Count > 0 ? resourceDeliveries.order.Max(x => x.id) + 1 : 0;
        resourceDeliveries.order.Add(newOrder);
        //if(DataManager.gameData.order == null)
        //{
        //    DataManager.gameData.order = new Order[1];
        //}
        DataManager.gameData.order.Add(newOrder);
        SaveSystem.Save(DataManager.gameData);
    }

    public void DisplaySliderValue(float index1, float index2)
    {
        amountOfBuy.text = amountSlider.value.ToString();
        cost.text = (amountSlider.value * index1).ToString("0");
        donateCost.text = (amountSlider.value * index2).ToString("0");
    }
}
