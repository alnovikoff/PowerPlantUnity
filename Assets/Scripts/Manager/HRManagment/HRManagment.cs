using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HRManagment : MonoBehaviour
{
    [SerializeField] private GameObject[] hrEmployeesTabs;
    [SerializeField] private GameObject teamplate;
    [SerializeField] private GameObject hrChoisePan;

    [SerializeField] private TabGroup emplyeeTab;
    [SerializeField] private TabBtn emplyeeBtn;
    [SerializeField] private GameObject employeeTab;
    [SerializeField] private Candidate[] employees;

    [SerializeField] private HireEmployee hireEmployee;
    private List<int> candidateKeys = new List<int>();
    public JsonReader jsonReader;

    public int employeeID = 0;
    private int lastNumber;

    public bool isManager = false;
    public void InitializeOnOpen()
    {
        candidateKeys.Clear();
        candidateKeys = jsonReader.employee.candidate.Keys.ToList();
        DictionaryUtils.Shuffle(candidateKeys);
        int lastKey = 0;
        for (int i = 0; i < 6; i++)
        {
            //int index = GetRandom(jsonReader.emplyees.candidate.Keys.First(), jsonReader.emplyees.candidate.Keys.Last());
            int randomIndex = UnityEngine.Random.Range(0, candidateKeys.Count);
            int randomKey = candidateKeys[randomIndex];
            int id = randomKey;
            hrEmployeesTabs[i].SetActive(true);
            hrEmployeesTabs[i].transform.position = teamplate.transform.position;
            hrEmployeesTabs[i].transform.GetChild(0).GetComponent<TMP_Text>().text = jsonReader.employee.candidate[randomKey].name.ToString();//jsonReader.emplyeeDictionary[i].name.ToString();
            hrEmployeesTabs[i].transform.GetChild(1).GetComponent<TMP_Text>().text = jsonReader.employee.candidate[randomKey].bio.ToString() + " id: " + id;
            hrEmployeesTabs[i].transform.GetChild(2).GetComponent<Image>().sprite = jsonReader.employee.candidate[randomKey].employeePhoto;
            //hrEmployeesTabs[i].transform.GetChild(3).transform.GetChild(0).GetComponent<TMP_Text>().text = hireEmployee.jsonReader.employeeList.employees[i].skill1.ToString();
            //hrEmployeesTabs[i].transform.GetChild(4).transform.GetChild(0).GetComponent<TMP_Text>().text = hireEmployee.jsonReader.employeeList.employees[i].skill2.ToString();
            //hrEmployeesTabs[i].transform.GetChild(5).transform.GetChild(0).GetComponent<TMP_Text>().text = hireEmployee.jsonReader.employeeList.employees[i].skill3.ToString();

            hrEmployeesTabs[i].transform.GetChild(6).GetComponent<Button>().onClick.RemoveAllListeners();
            hrEmployeesTabs[i].transform.GetChild(6).GetComponent<Button>().onClick.AddListener(delegate ()
            {
                isManager = true;
                OnEmployeeClick(id);
            });
            lastKey = randomKey;
        }

    }

    public int GetRandom(int min, int max)
    {
        lastNumber = 0;
        int rand = UnityEngine.Random.Range(min, max);
        while(rand == lastNumber)
            rand = UnityEngine.Random.Range(min, max);

        lastNumber = rand;

        return rand;
    }

    public void OnEmployeeClick(int id)
    {
        employeeID = id;
        GameManager.instance.OnHRAction += EmployeeSelection;
        GameManager.instance.OnBuildingTapAction -= GameManager.instance.onTapAction.MakeAction;
        employeeTab.SetActive(false);
    }

    public void EmployeeSelection(AbstractBuilding abstractBuilding)
    {
        if (abstractBuilding.currentBuildingState != BuildingManager.BuildingState.notbuild && abstractBuilding.currentBuildingState != BuildingManager.BuildingState.build)
        {
            hrChoisePan.SetActive(true);
            GameManager.instance.OnHRAction -= EmployeeSelection;
            GameManager.instance.OnBuildingTapAction += GameManager.instance.onTapAction.MakeAction;
        }
        hireEmployee.EmployeeHiring(abstractBuilding);
    }
}