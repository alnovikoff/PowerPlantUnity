using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PumpStation : AbstractBuilding
{
    public int[] pumpAmount;
    public int[] pumpPower;
    public bool[] pumpWork;

    public int GetActivePump()
    {
        Debug.Log(pumpWork.Where(c => c).Count());
        return pumpWork.Where(c => c).Count();
    }
}
