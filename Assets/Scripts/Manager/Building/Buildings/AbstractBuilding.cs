using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static BuildingManager;
using static UnityEngine.Rendering.DebugUI;

public abstract class AbstractBuilding : MonoBehaviour
{
    [Header("Prefabs")]
    public GameObject constructionPref;
    public GameObject level1Pref;

    [Header("Building Properties")]
    [SerializeField] public BuildingState currentBuildingState;
    [SerializeField] public int level;
    [SerializeField] public int condition;
    [SerializeField] public string buildingName;
    

    [Header("Building Requirements")]
    [SerializeField] public BuildUpdateTime[] buildUpdateTime;
    [SerializeField] public Reward[] reward;
    [SerializeField] public BuildingCost[] updateCost;

    private void Start()
    {
        GameObjectInitialization();
    }

    public GameObject GetGameObject() 
    {
        return this.gameObject;
    }

    public void GameObjectInitialization()
    {
        if (currentBuildingState == BuildingState.notbuild || currentBuildingState == BuildingState.build)
        {
            constructionPref.SetActive(true);
            level1Pref.SetActive(false);
        }
        else if (currentBuildingState == BuildingState.work || currentBuildingState == BuildingState.notwork)
        {
            constructionPref.SetActive(false);
            level1Pref.SetActive(true);
        }
    }

    public virtual void OnBuildingEvent()
    {
        currentBuildingState = BuildingState.work;
        switch (level)
        {
            case 0:
                level = 1;
                GiveReward(0);
                constructionPref.SetActive(false);
                level1Pref.SetActive(true);
                break;
            case 1:
                GiveReward(1);
                level = 2;
                break;
        }
    }

    public virtual void SwitchState(BuildingState buildingState)
    {
        currentBuildingState = buildingState;
    }

    private void GiveReward(int index)
    {
        //GameManager.instance.playerLevelManager.GainExperienceFlatRate(reward[index].xp);
        //GameManager.instance.playerLevelManager.UpdateUI(reward[index].xp);
        GameManager.instance.money.AddValue(reward[index].money);
        GameManager.instance.money.AddDonateValue(reward[index].donate);
    }
}

[Serializable]
public class BuildUpdateTime
{
    public int days;
    public int hours;
    public int minutes;
    public int seconds;
}

[Serializable]
public class Reward
{
    public int money;
    public int donate;
    public int xp;
}

[Serializable]
public class BuildingCost
{
    public int moneyCost;
    public int donateCost;
}


