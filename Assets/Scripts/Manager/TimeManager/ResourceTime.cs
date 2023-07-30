using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class ResourceTime : MonoBehaviour
{
    [SerializeField] ResourceDeliveries resourceDeliveries;

    public bool inProgress;
    private DateTime timerStart;
    private DateTime timerEnd;

    private Coroutine lastTimer;
    private Coroutine lastDisplay;

    private TimeSpan timeLeft;

    [SerializeField] private GameObject window;

    public void StartTimer(Order order, string startDate,string timeSpan, Image img, TMP_Text txt)
    {
        timerStart = DateTime.Parse(startDate);
        TimeSpan time = TimeSpan.Parse(timeSpan);
        timerEnd = timerStart.Add(time);
        inProgress = true;

        lastTimer = StartCoroutine(Timer(timerStart));
        lastDisplay = StartCoroutine(DisplayTimer(order, img, txt));
    }

    public IEnumerator Timer(DateTime startDate)
    {
        DateTime start = startDate;
        double secondsToFinished = (timerEnd - start).TotalSeconds;
        yield return new WaitForSeconds(Convert.ToSingle(secondsToFinished));

        inProgress = false;
    }

    public IEnumerator DisplayTimer(Order order, Image img, TMP_Text txt)
    {
        DateTime start = WorldTimeAPI.Instance.GetCurrentDateTime();
        timeLeft = timerEnd - start;
        double totalSecondsLeft = timeLeft.TotalSeconds;
        double totalSeconds = (timerEnd - timerStart).TotalSeconds;
        string text;

        //Debug.Log("ORDER TIME: " + listOfTime[order.id] + "------ MINIMAL: " + listOfTime.Min());
        //if (listOfTime[order.id] > listOfTime.Min())
        //{
        //    Debug.Log("RUN THE SMALLEST");
        //    foreach (var ord in resourceDeliveries.order)
        //    {
        //        if (listOfTime[ord.id] == listOfTime.Min())
        //        {
        //            minimalTimer = StartCoroutine(FollowSmallestTime(ord));
        //        }
        //    }
        //}
        

        while (resourceDeliveries.deliveryPref.activeSelf && window.activeSelf && DateTime.Parse(order.startTime) == timerStart)
        {
            text = "";
            img.fillAmount = 1 - Convert.ToSingle((timerEnd - WorldTimeAPI.Instance.GetCurrentDateTime()).TotalSeconds / totalSeconds);

            if (totalSecondsLeft > 0)
            {
                if (inProgress)
                {
                    if (timeLeft.Days != 0)
                    {
                        text += timeLeft.Days + "d";
                        text += timeLeft.Hours + "h";
                        yield return new WaitForSeconds(timeLeft.Minutes * 60);
                    }
                    else if (timeLeft.Hours != 0)
                    {
                        text += timeLeft.Hours + "h";
                        text += timeLeft.Minutes + "m";
                        yield return new WaitForSeconds(timeLeft.Seconds);
                    }
                    else if (timeLeft.Minutes != 0)
                    {
                        TimeSpan ts = TimeSpan.FromSeconds(totalSecondsLeft);
                        text += ts.Minutes + "m";
                        text += ts.Seconds + "s";
                    }
                    else
                    {
                        text += Mathf.FloorToInt((float)totalSecondsLeft) + "s";
                    }
                    txt.text = text;
                    totalSecondsLeft -= Time.deltaTime;
                    yield return null;
                }
                else
                {
                    resourceDeliveries.CheckDeliveries();
                    break;
                }
            }
            else
            {
                resourceDeliveries.FillTank(order.type, order.quality, order.amount);
                resourceDeliveries.order.Remove(order);
                resourceDeliveries.CheckDeliveries();
                DataManager.gameData.order.Remove(order);
                SaveSystem.Save(DataManager.gameData);
                if (resourceDeliveries.order.Count == 0) {
                    inProgress = false;
                }
                break;
            }
        }
        yield return null;
    }
    //public IEnumerator FollowSmallestTime(Order order)
    //{
    //    while (listOfTime[order.id] == listOfTime.Min())
    //    {
    //        if (listOfTime[order.id] > 0)
    //        {
    //            listOfTime[order.id] -= Time.deltaTime;
    //            Debug.Log(listOfTime[order.id]);
    //            yield return null;
    //        }
    //        else
    //        {
    //            resourceDeliveries.FillTank(order.type, order.quality, order.amount);
    //            resourceDeliveries.order.Remove(order);
    //            resourceDeliveries.CheckDeliveries();
    //            DataManager.gameData.order.Remove(order);
    //            SaveSystem.Save(DataManager.gameData);
    //            if (resourceDeliveries.order.Count == 0)
    //            {
    //                inProgress = false;
    //            }
    //            break;
    //        }
    //    }
    //}

    public void SkipTime()
    {
        timerEnd = WorldTimeAPI.Instance.GetCurrentDateTime();
        inProgress = false;
        StopCoroutine(lastTimer);
        StopCoroutine(lastDisplay);

        timerStart = WorldTimeAPI.Instance.GetCurrentDateTime();

        TimeSpan time = new TimeSpan(timeLeft.Days, timeLeft.Hours, timeLeft.Minutes - 20, timeLeft.Seconds);

        timerEnd = timerStart.Add(time);
        inProgress = true;

        //DataManager.gameData.startDate = timerStart.ToString();
        //DataManager.gameData.endDate = timerEnd.ToString();
        //SaveSystem.Save(DataManager.gameData);

        //lastTimer = StartCoroutine(Timer());
        //lastDisplay = StartCoroutine(DisplayTimer());
    }
}






//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Linq;
//using TMPro;
//using Unity.Mathematics;
//using UnityEngine;
//using UnityEngine.Rendering;
//using UnityEngine.Rendering.Universal;
//using UnityEngine.UI;

//public class ResourceTime : MonoBehaviour
//{
//    [SerializeField] ResourceDeliveries resourceDeliveries;

//    public bool inProgress;
//    private DateTime timerStart;
//    private DateTime timerEnd;

//    private Coroutine lastTimer;
//    private Coroutine lastDisplay;

//    private TimeSpan timeLeft;

//    private DateTime timerMinEnd;
//    List<DateTime> timerEndTimes = new List<DateTime>();
//    [SerializeField] private GameObject window;
//    bool isSmallestTimeTab;

//    public void OnGameStart(Order order, string startTime, string endTime, Image img, TMP_Text txt)
//    {
//        timerStart = DateTime.Parse(startTime);
//        TimeSpan time = TimeSpan.Parse(endTime);
//        timerEnd = timerStart.Add(time);
//        inProgress = true;

//        timerEndTimes.Add(timerEnd);

//        RunSmallestTIme(order);
//    }

//    public void StartTimer(Order order, string startDate, string timeSpan, Image img, TMP_Text txt)
//    {
//        timerStart = DateTime.Parse(startDate);
//        TimeSpan time = TimeSpan.Parse(timeSpan);
//        Debug.Log(time);
//        timerEnd = timerStart.Add(time);
//        inProgress = true;


//        DataManager.gameData.order[order.id].startTime = timerStart.ToString();
//        DataManager.gameData.order[order.id].endTime = order.endTime;
//        SaveSystem.Save(DataManager.gameData);

//        lastTimer = StartCoroutine(Timer(timerStart));
//        lastDisplay = StartCoroutine(DisplayTimer(order, img, txt));
//    }

//    public IEnumerator Timer(DateTime startDate)
//    {
//        DateTime start = startDate;
//        double secondsToFinished = (timerEnd - start).TotalSeconds;
//        yield return new WaitForSeconds(Convert.ToSingle(secondsToFinished));

//        inProgress = false;
//    }

//    public IEnumerator DisplayTimer(Order order, Image img, TMP_Text txt)
//    {
//        DateTime start = WorldTimeAPI.Instance.GetCurrentDateTime();
//        timeLeft = timerEnd - start;
//        double totalSecondsLeft = timeLeft.TotalSeconds;
//        double totalSeconds = (timerEnd - timerStart).TotalSeconds;
//        string text;

//        timerEndTimes.Add(timerEnd);

//        RunSmallestTIme(order);

//        while (resourceDeliveries.deliveryPref.activeSelf && window.activeSelf && DateTime.Parse(order.startTime) == timerStart)
//        {
//            text = "";
//            img.fillAmount = 1 - Convert.ToSingle((timerEnd - WorldTimeAPI.Instance.GetCurrentDateTime()).TotalSeconds / totalSeconds);

//            if (totalSecondsLeft > 0)
//            {
//                if (inProgress)
//                {
//                    if (timeLeft.Days != 0)
//                    {
//                        text += timeLeft.Days + "d";
//                        text += timeLeft.Hours + "h";
//                        yield return new WaitForSeconds(timeLeft.Minutes * 60);
//                    }
//                    else if (timeLeft.Hours != 0)
//                    {
//                        text += timeLeft.Hours + "h";
//                        text += timeLeft.Minutes + "m";
//                        yield return new WaitForSeconds(timeLeft.Seconds);
//                    }
//                    else if (timeLeft.Minutes != 0)
//                    {
//                        TimeSpan ts = TimeSpan.FromSeconds(totalSecondsLeft);
//                        text += ts.Minutes + "m";
//                        text += ts.Seconds + "s";
//                    }
//                    else
//                    {
//                        text += Mathf.FloorToInt((float)totalSecondsLeft) + "s";
//                    }
//                    txt.text = text;
//                    totalSecondsLeft -= Time.deltaTime;
//                    yield return null;
//                }
//                else
//                {
//                    resourceDeliveries.CheckDeliveries();
//                    break;
//                }
//            }
//            else
//            {
//                resourceDeliveries.FillTank(order.type, order.quality, order.amount);
//                DataManager.gameData.order[order.id] = null;
//                SaveSystem.Save(DataManager.gameData);
//                resourceDeliveries.order.Remove(order);
//                resourceDeliveries.CheckDeliveries();
//                inProgress = false;
//                break;
//            }
//        }
//        yield return null;
//    }

//    public void RunSmallestTIme(Order order)
//    {
//        isSmallestTimeTab = (timerEndTimes.Min() != timerEnd);

//        if (isSmallestTimeTab)
//        {
//            if (resourceDeliveries.order.Count > 1)
//            {
//                foreach (var ord in resourceDeliveries.order)
//                {
//                    if (order.startTime != ord.startTime)
//                    {
//                        StopCoroutine(MinCountdown(ord));
//                        StartCoroutine(MinCountdown(ord));
//                    }
//                }
//            }
//        }
//    }

//    public IEnumerator MinCountdown(Order order)
//    {
//        DateTime start = WorldTimeAPI.Instance.GetCurrentDateTime();
//        timerMinEnd = timerStart.Add(TimeSpan.Parse(order.endTime));
//        TimeSpan timeLeft = timerMinEnd - start;
//        double totalSecondsLeft = timeLeft.TotalSeconds;

//        while (totalSecondsLeft > 0)
//        {
//            if (totalSecondsLeft > 0)
//            {
//                Debug.Log(totalSecondsLeft);
//                totalSecondsLeft -= Time.deltaTime;

//                yield return null;
//            }
//            else
//            {
//                resourceDeliveries.FillTank(order.type, order.quality, order.amount);
//                resourceDeliveries.order.Remove(order);
//                resourceDeliveries.CheckDeliveries();
//                DataManager.gameData.order[order.id] = null;
//                SaveSystem.Save(DataManager.gameData);
//                break;
//            }
//        }
//        RunSmallestTIme(order);
//    }

//    public void SkipTime()
//    {
//        timerEnd = WorldTimeAPI.Instance.GetCurrentDateTime();
//        inProgress = false;
//        StopCoroutine(lastTimer);
//        StopCoroutine(lastDisplay);

//        timerStart = WorldTimeAPI.Instance.GetCurrentDateTime();

//        TimeSpan time = new TimeSpan(timeLeft.Days, timeLeft.Hours, timeLeft.Minutes - 20, timeLeft.Seconds);

//        timerEnd = timerStart.Add(time);
//        inProgress = true;

//        //DataManager.gameData.startDate = timerStart.ToString();
//        //DataManager.gameData.endDate = timerEnd.ToString();
//        //SaveSystem.Save(DataManager.gameData);

//        //lastTimer = StartCoroutine(Timer());
//        //lastDisplay = StartCoroutine(DisplayTimer());
//    }
//}
