using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuilderManager : MonoBehaviour
{
    private int currentBuilderAmount;
    private int currentFreeBuilder;
    
    public void InitializeBuilders()
    {
        currentFreeBuilder = currentBuilderAmount;
    }

    public void SetBuilderAmount(int amount)
    {
        currentBuilderAmount = amount; 
    }

    public int GetBuidlderAmount()
    {
        return currentBuilderAmount;
    }

    public void SetcurrentFreeBuilder(int amount)
    {
        currentFreeBuilder = amount;
    }

    public int GetCurrentFreeBuilder()
    {
        return currentFreeBuilder;
    }


}
