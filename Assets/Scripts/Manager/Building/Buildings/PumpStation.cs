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
        return pumpWork.Where(c => c).Count();
    }
}
