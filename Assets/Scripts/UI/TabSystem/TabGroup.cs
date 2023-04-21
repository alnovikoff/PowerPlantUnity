using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TabGroup : MonoBehaviour
{
    public List<TabBtn> tabButtons;

    public Sprite tabIdle;
    public Sprite tabHover;
    public Sprite tabActive;

    public TabBtn selectedTab;

    public List<GameObject> objToSwap;
    public void Subscribe(TabBtn btn)
    {
        if(tabButtons == null)
        {
            tabButtons = new List<TabBtn>();
        }
        tabButtons.Add(btn);
    }

    //public void OnTabEnter(TabBtn btn)
    //{
    //    ResetTabs();
    //    btn.background.sprite = tabHover;
    //}

    public void OnTabExit(TabBtn btn)
    {
        ResetTabs();
    }

    public void OnTabSelected(TabBtn btn)
    {
        selectedTab = btn;
        ResetTabs();
        btn.background.sprite = tabActive;
        int index = btn.transform.GetSiblingIndex();
        for(int i = 0; i < objToSwap.Count; i++) 
        {
            if(i == index)
            {
                objToSwap[i].SetActive(true);
            }
            else
            {
                objToSwap[i].SetActive(false);
            }
        }
    }

    public void ResetTabs()
    {
        foreach(TabBtn btn in tabButtons) 
        {
            if (selectedTab != null && btn == selectedTab) { continue; }
            btn.background.sprite = tabIdle;
        }
    }
}
