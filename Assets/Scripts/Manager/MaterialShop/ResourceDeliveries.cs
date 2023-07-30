using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ResourceDeliveries : MonoBehaviour
{
    [SerializeField] private BuildingManager buildingManager;

    [SerializeField] public ResourceTime resourceTime;


    public List<Order> order;

    [SerializeField] public GameObject deliveryPref;
    [SerializeField] private GameObject basePref;

    [SerializeField] private TMP_Text nameTxt;
    [SerializeField] private TMP_Text amountTxt;
    [SerializeField] public TMP_Text timeTxt;
    [SerializeField] public Image fillImg;

    [SerializeField] private Button endBtn;
    [SerializeField] private Button leftBtn;
    [SerializeField] private Button rightBtn;

    DateTime timerStart;

    public int currentIndex = 0;

    private void Start()
    {
        if (order.Count != 0)
        {
            DateTime start = WorldTimeAPI.Instance.GetCurrentDateTime();
            foreach (var ord in order.ToArray())
            {
                DateTime timerMinEnd = timerStart.Add(TimeSpan.Parse(ord.endTime));
                TimeSpan timeLeft = timerMinEnd - start;
                if (timeLeft.TotalSeconds > 0)
                {
                    
                }
                else
                {
                    Debug.Log("Fill tank with: " + ord);
                    FillTank(ord.type, ord.quality, ord.amount);
                    DataManager.gameData.order.Remove(ord);
                    SaveSystem.Save(DataManager.gameData);
                    order.Remove(ord);
                }
            }
        }
    }

    public void InitializeDeliveryData(Order orderId)
    {
        if (!deliveryPref.activeSelf)
        {
            deliveryPref.SetActive(true);
            basePref.SetActive(false);
        }
        currentIndex = order.Count - 1;
        nameTxt.text = orderId.name;
        amountTxt.text = orderId.amount.ToString();
        resourceTime.StartTimer(orderId, orderId.startTime, order[currentIndex].endTime, fillImg, timeTxt);
        ScrollOrders();
        
    }

    public void CheckDeliveries()
    {
        if (order.Count == 0)
        {
            deliveryPref.SetActive(false);
            basePref.SetActive(true);
            resourceTime.inProgress = false;
        }
        else
        {
            //if (order[currentIndex] != null)
            //{
            //    nameTxt.text = order[currentIndex].name;
            //    amountTxt.text = order[currentIndex].amount.ToString();
            //    resourceTime.StartTimer(order[currentIndex], order[currentIndex].startTime, order[currentIndex].endTime, fillImg, timeTxt); 
            //}
            //else
            //{
                nameTxt.text = order[0].name;
                amountTxt.text = order[0].amount.ToString();
                resourceTime.StartTimer(order[0], order[0].startTime, order[0].endTime, fillImg, timeTxt);
            //}
            ScrollOrders();
        }
    }

    private void ScrollOrders()
    {
        if (order.Count > 1)
        {
            leftBtn.interactable = false;
            leftBtn.gameObject.SetActive(true);
            rightBtn.gameObject.SetActive(true);
        }
        else
        {
            leftBtn.gameObject.SetActive(false);
            rightBtn.gameObject.SetActive(false);
        }
    }

    public void OnLeftButton()
    {
        if (currentIndex < order.Count - 1)
        {
            currentIndex++;
            nameTxt.text = order[currentIndex].name;
            amountTxt.text = order[currentIndex].amount.ToString();
            resourceTime.StartTimer(order[currentIndex], order[currentIndex].startTime, order[currentIndex].endTime, fillImg, timeTxt);

            if (currentIndex == order.Count - 1) leftBtn.interactable = false;
            if (!rightBtn.interactable) rightBtn.interactable = true;
        }
    }

    public void OnRightButton()
    {
        if (currentIndex > 0)
        {
            currentIndex--;
            nameTxt.text = order[currentIndex].name;
            amountTxt.text = order[currentIndex].amount.ToString();
            resourceTime.StartTimer(order[currentIndex], order[currentIndex].startTime, order[currentIndex].endTime, fillImg, timeTxt);

            if (!leftBtn.interactable) leftBtn.interactable = true;
            if (currentIndex == 0) rightBtn.interactable = false;
        }
    }

    public void FillTank(int type, int quality, int amount)
    {
        switch(type)
        {
            case 0:
                buildingManager.coalStorage.quality = quality;
                buildingManager.coalStorage.occupancy += amount;
                DataManager.gameData.coalStorageQuality = buildingManager.coalStorage.quality;
                DataManager.gameData.coalStorageOccupancy = buildingManager.coalStorage.occupancy;
                break;
            case 1:
                buildingManager.fuelStorage.quality = quality;
                buildingManager.fuelStorage.occupancy += amount;
                DataManager.gameData.fuelStorageQuality = buildingManager.fuelStorage.quality;
                DataManager.gameData.fuelStorageOccupancy = buildingManager.fuelStorage.occupancy;
                break;
        }
        SaveSystem.Save(DataManager.gameData);
        GameManager.instance.onChangeElectricity();
    }
}


[Serializable]
public class Order
{
    public int type;
    public int quality;
    public string name;
    public string startTime;
    public string endTime;
    public int amount;

    public Order(int type, int quality, string name, string startTime, string endTime, int amount)
    {
        this.type = type;
        this.quality = quality;
        this.name = name;
        this.startTime = startTime;
        this.endTime = endTime;
        this.amount = amount;
    }
}

