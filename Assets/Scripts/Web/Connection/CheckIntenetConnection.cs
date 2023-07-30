using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckIntenetConnection : MonoBehaviour
{
    public bool CheckConnection()
    {
        if(Application.internetReachability == NetworkReachability.ReachableViaLocalAreaNetwork)
        {
            return true;
        }
        return false;
    }
}
