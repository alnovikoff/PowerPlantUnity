using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomEvents : MonoBehaviour
{
    [SerializeField] private JsonReader reader;
    [SerializeField] private GameObject gameEventTab;
    public void OnGameEventPopUp()
    {
        gameEventTab.SetActive(true);
        // text and so on make appear in gameevent tab, buttons yes or no and call from somwhere
    }
}

public class GameEventsHolder
{
    public GameEvents[] gameEvents;
}

public class GameEvents
{
    public string question;
    public string message;
    public int[] yes;
    public int[] no;
}
