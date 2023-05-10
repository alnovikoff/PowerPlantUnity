using System;
using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class BuildTime : MonoBehaviour
{
    private bool inProgress;
    private DateTime timerStart;
    private DateTime timerEnd;

    [SerializeField] private GameObject timelineBar;
    private TMP_Text txt;
    private Image img;

    private Coroutine lastTimer;
    private Coroutine lastDisplay;

    public NotBuildMode notBuildMode;
    [SerializeField] private OnBuildingUpdated onBuildingUpdated;

    private TimeSpan timeLeft;
    public void OnGameStart(GameObject gameObj, string startTime, string endTime)
    {
        timerStart = DateTime.Parse(startTime);
        timerEnd = DateTime.Parse(endTime);

        lastTimer = StartCoroutine(Timer());
        lastDisplay= StartCoroutine(DisplayTimer(gameObj));
        inProgress = true;

    }

    public void StartTimer(BuildUpdateTime values, GameObject gameObj)
    {
        timerStart = DateTime.Now;
        TimeSpan time = new TimeSpan(values.days, values.hours, values.minutes, values.seconds);
        timerEnd = timerStart.Add(time);
        inProgress = true;

        DataManager.gameData.startDate = timerStart.ToString();
        DataManager.gameData.endDate = timerEnd.ToString();
        SaveSystem.Save(DataManager.gameData);

        lastTimer = StartCoroutine(Timer());
        lastDisplay = StartCoroutine(DisplayTimer(gameObj));
    }

    public IEnumerator Timer()
    {
        DateTime start = DateTime.Now;
        double secondsToFinished = (timerEnd - start).TotalSeconds;
        yield return new WaitForSeconds(Convert.ToSingle(secondsToFinished));

        inProgress = false;
    }

    public IEnumerator DisplayTimer(GameObject gameObj)
    {
        timelineBar.SetActive(true);
        timelineBar.transform.parent = gameObj.transform;
        timelineBar.transform.localPosition = new Vector3(0, 4, 0);

        DateTime start = DateTime.Now;
        timeLeft = timerEnd - start;
        double totalSecondsLeft = timeLeft.TotalSeconds;
        double totalSeconds = (timerEnd - timerStart).TotalSeconds;
        string text;

        txt = timelineBar.transform.GetChild(0).GetComponent<TMP_Text>();
        img = timelineBar.transform.GetChild(2).GetComponent<Image>();

        while (timelineBar.activeSelf)
        {
            text = "";
            img.fillAmount = 1 - Convert.ToSingle((timerEnd - DateTime.Now).TotalSeconds / totalSeconds);

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
                    onBuildingUpdated.OnBuildingUpdate(gameObj);
                    timelineBar.SetActive(false);
                    break;
                }
            }
            else
            {
                onBuildingUpdated.OnBuildingUpdate(gameObj);
                timelineBar.SetActive(false);
                inProgress = false;
                break;
            }
        }
        yield return null;
    }

    public void SkipTime(BuildUpdateTime values, GameObject gameObj)
    {
        timerEnd = DateTime.Now;
        inProgress = false;
        StopCoroutine(lastTimer);
        StopCoroutine(lastDisplay);

        timerStart = DateTime.Now;

        TimeSpan time = new TimeSpan(timeLeft.Days, timeLeft.Hours, timeLeft.Minutes - 20, timeLeft.Seconds);

        timerEnd = timerStart.Add(time);
        inProgress = true;

        DataManager.gameData.startDate = timerStart.ToString();
        DataManager.gameData.endDate = timerEnd.ToString();
        SaveSystem.Save(DataManager.gameData);

        lastTimer = StartCoroutine(Timer());
        lastDisplay = StartCoroutine(DisplayTimer(gameObj));
    }

    public void SkipFullTime()
    {
        inProgress = false;
    }
}
