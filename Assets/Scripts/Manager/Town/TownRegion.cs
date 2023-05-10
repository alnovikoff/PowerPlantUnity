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

    public int[] impactToElectricity = {20, 70, 25, 15, 25, 15};
    [SerializeField] private PlayerLevelManager playerLevelManager;
    [SerializeField] private TownMapManager townMapManager;
    
    //todo: algorithm based on level we should increase electricity procduction simulate of town growth
    public int RequiredElectricity()
    {
        return (int)((playerLevelManager.level / 0.5f) * ((impactToElectricity[0] * agriculture) + (impactToElectricity[1] * manufacturing) + (impactToElectricity[2] * publicService) 
                + (impactToElectricity[3] * transportnAndCommunication) + (impactToElectricity[4] * construction) + (impactToElectricity[5] * other)) / 100);
    }

    public int RequiredElectricityToCount(int token)
    {
        if(townMapManager.assignedRegions[token])
        {
            return (int)((playerLevelManager.level / 0.5f) * ((impactToElectricity[0] * agriculture) + (impactToElectricity[1] * manufacturing) + (impactToElectricity[2] * publicService) 
                    + (impactToElectricity[3] * transportnAndCommunication) + (impactToElectricity[4] * construction) + (impactToElectricity[5] * other)) / 100);
        }
        return 0;
    }
}
