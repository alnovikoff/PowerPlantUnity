using System;
using System.Collections;
using System.Diagnostics.Contracts;
using TMPro;
using UnityEngine;

public class Money : MonoBehaviour
{
    private float money;
    public TextMeshProUGUI moneyTxt;
    private float donate;
    public TMP_Text donateTxt;
    public string NumberFormat = "N0";

    public int timer;
    private Coroutine moneyCounting, donateCounting;

    private void Start()
    {
        //StopCoroutine(moneyCounting);
        //StopCoroutine(donateCounting);
    }
    public void InitializeMoney()
    {
        moneyTxt.text = money.ToString();
        donateTxt.text = donate.ToString();
    }

    public void AddValue(int value)
    {
        if(moneyCounting != null)
        {
            StopCoroutine(moneyCounting);
        }
        float targetValue = money + value;
        moneyCounting = StartCoroutine(MoneyCoroutine(targetValue));
    }

    public void SubstractValue(int value) 
    {
        if (moneyCounting != null)
        {
            StopCoroutine(moneyCounting);
        }
        float targetValue = money - value;
        moneyCounting = StartCoroutine(MoneyCoroutine(targetValue));
    }

    private IEnumerator MoneyCoroutine(float targetValue) 
    {
        var rate = Mathf.Abs(targetValue - money) / timer;
        while(money != targetValue)
        {
            money = Mathf.MoveTowards(money, targetValue, rate * Time.deltaTime);
            moneyTxt.SetText(money.ToString(NumberFormat));
            yield return null;
        }
        DataManager.gameData.money = (int)money;
        SaveSystem.Save(DataManager.gameData);
    }

    public void AddDonateValue(int value)
    {
        if (donateCounting != null)
        {
            StopCoroutine(donateCounting);
        }
        float targetValue = donate + value;
        donateCounting = StartCoroutine(DonateCoroutine(targetValue));
    }

    public void SubstractDonateValue(int value)
    {
        if (donateCounting != null)
        {
            StopCoroutine(donateCounting);
        }
        float targetValue = donate - value;
        donateCounting = StartCoroutine(DonateCoroutine(targetValue));
    }

    private IEnumerator DonateCoroutine(float targetValue)
    {
        var rate = Mathf.Abs(targetValue - donate) / timer;
        while (donate != targetValue)
        {
            donate = Mathf.MoveTowards(donate, targetValue, rate * Time.deltaTime);
            donateTxt.SetText(donate.ToString(NumberFormat));
            yield return null;
        }
        DataManager.gameData.donate = (int)donate;
        SaveSystem.Save(DataManager.gameData);
        //StopCoroutine(moneyCounting);
        //StopCoroutine(donateCounting);
    }

    public float GetMoney() { return money; }
    public float GetDonate() { return donate; }

    public void SetMoney(float value)
    {
        money = value;
    }

    public void SetDonate(float value)
    {
        donate  = value;
    }
}
