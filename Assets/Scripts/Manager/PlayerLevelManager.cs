using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;



public class PlayerLevelManager : MonoBehaviour
{
    public int level;
    public float maxLevel;
    public float currentXp;
    public int nextLevelXp = 100;
    [Header("Multipliers")]
    [Range(1f, 300f)]
    public float additionMultiplier;
    [Range(2f, 4f)]
    public float powerMultiplier = 20f;
    [Range(7f, 14f)]
    public float divisionMultiplier = 7f;
    public GameObject levelUpEffect;

    [Header("UI")]
    public Image frontXpBar;
    public TextMeshProUGUI levelText;
    public TextMeshProUGUI XpText;

    //Audio  
    [Header("Audio")]
    public AudioClip levelUpSound;
    private AudioSource source;
    //Timers
    public float lerpTimer;
    public float delayTimer;

    [SerializeField] private Button p50;
    [SerializeField] private Button p150;
    [SerializeField] private Button p200;

    public void addExp(int val)
    {
        GameManager.instance.playerLevelManager.GainExperienceFlatRate(val);
        GameManager.instance.playerLevelManager.UpdateXpUI();
    }

    void Start()
    {
        levelText.text = level.ToString();
        level = 1;
        XpText.text = Mathf.Round(currentXp) + "/" + Mathf.Round(nextLevelXp);
        frontXpBar.fillAmount = currentXp / nextLevelXp;
        nextLevelXp = CalculateNextLevelXp();
        source = GetComponent<AudioSource>();
    }

    void Update()
    {
        UpdateXpUI();
        if (level != maxLevel)
        {
            if (currentXp >= nextLevelXp)
            {
                if(frontXpBar.fillAmount == 1)
                    LevelUp();
            }
        }
        else
        {
            currentXp = nextLevelXp;
            XpText.text = "MAX";
            frontXpBar.fillAmount = currentXp / nextLevelXp;
        }
    }
    public void UpdateXpUI()
    {
        float xpFraction = currentXp / nextLevelXp;
        float fXP = frontXpBar.fillAmount;
        //lerpTimer = 0;
        if (fXP < xpFraction)
        {
            frontXpBar.fillAmount = Mathf.Lerp(fXP, xpFraction, 5f * Time.deltaTime);
        }
        DataManager.gameData.level = level;
        DataManager.gameData.xp = currentXp;
        SaveSystem.Save(DataManager.gameData);
    }

    public void GainExperienceFlatRate(float xpGained)
    {
        currentXp += xpGained;

    }
    public void GainExperienceScalable(float xpGained, int passedLevel)
    {
        if (passedLevel < level)
        {
            float multiplier = 1 + (level - passedLevel) * 0.1f;
            currentXp += Mathf.Round(xpGained * multiplier);

        }
        else
        {
            currentXp += xpGained;

        }

        lerpTimer = 0f;
        delayTimer = 0f;

    }
    public void LevelUp()
    {
        level += 1;
        frontXpBar.fillAmount = 0f;
        currentXp = Mathf.Round(currentXp - nextLevelXp);

        nextLevelXp = CalculateNextLevelXp();
        level = Mathf.Clamp(level, 0, 50);

        XpText.text = Mathf.Round(currentXp) + "/" + nextLevelXp;
        levelText.text = level.ToString();
    }

    private int CalculateNextLevelXp()
    {
        int solveForRequiredXp = 0;
        for (int levelCycle = 1; levelCycle <= level; levelCycle++)
        {
            solveForRequiredXp += (int)Mathf.Floor(levelCycle + additionMultiplier * Mathf.Pow(powerMultiplier, levelCycle / divisionMultiplier));
        }
        return solveForRequiredXp / 4;
    }
}
