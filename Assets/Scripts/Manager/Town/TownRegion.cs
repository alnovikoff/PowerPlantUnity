using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TownRegion : MonoBehaviour
{
    public int agriculture; // 2%
    public int manufacturing; //14%
    public int publicService; //10%
    public int transportnAndCommunication; //9%
    public int construction; //4%
    public int other; // 20%
    
    //todo: algorithm based on level we should increase electricity procduction simulate of town growth
    public int RequiredElectricity()
    {
        return 0;
    }
}
