using Newtonsoft.Json;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.ComponentModel;
using System.Collections;

public class JsonReader : MonoBehaviour
{
    public TextAsset eventsTextJson;
    public Employee employee = null;
    public GameEventsHolder gameEvents;

    public string path = null;
    public string pathGameData;

    [SerializeField] Container container;

    public void Awake()
    {
        if (DataManager.gameData.isFirstRun)
        {
            ReadFromStreamingAssets();
            employee = LoadEmployees();
            foreach (KeyValuePair<int, Candidate> entry in employee.candidate)
            {
                entry.Value.employeePhoto = Resources.Load<Sprite>(entry.Value.photoUrl);
            }
            foreach (KeyValuePair<int, Worker> entry in employee.worker)
            {
                entry.Value.employeePhoto = Resources.Load<Sprite>(entry.Value.photoUrl);
            }
            DataManager.gameData.isFirstRun = false;
            SaveSystem.Save(DataManager.gameData);
        }
        else
        {
            employee = LoadEmployees();
            foreach (KeyValuePair<int, Candidate> entry in employee.candidate)
            {
                entry.Value.employeePhoto = Resources.Load<Sprite>(entry.Value.photoUrl);
            }
            foreach (KeyValuePair<int, Worker> entry in employee.worker)
            {
                entry.Value.employeePhoto = Resources.Load<Sprite>(entry.Value.photoUrl);
            }
        }
    }

    void ReadFromStreamingAssets()
    {
        string json;
        path = Application.streamingAssetsPath + "/employee.json";
#if UNITY_EDITOR
        path = Path.Combine(Application.streamingAssetsPath, "employee.json");
#endif
        if (Application.platform == RuntimePlatform.Android)
        {
            WWW reader = new WWW(path);
            while (!reader.isDone) { }

            var streamReader = reader.text;
            employee = JsonConvert.DeserializeObject<Employee>(streamReader);
        }
        else
        {
            json = File.ReadAllText(path);
            employee = JsonConvert.DeserializeObject<Employee>(json);
            Debug.Log("We use editor");
        }

        //employee = JsonConvert.DeserializeObject<Employee>(result);
        SaveEmployees(employee);
    }

    public Employee LoadEmployees()
    {
        if (!File.Exists(GetPath()))
        {
            Employee emptyData = new Employee();
            SaveEmployees(emptyData);
            return emptyData;
        }
        Employee loadedData = null;
        string dataToLoad = "";
        using (FileStream stream = new FileStream(GetPath(), FileMode.Open))
        {
            using (StreamReader reader = new StreamReader(stream))
            {
                dataToLoad = reader.ReadToEnd();
            }
            //dataToLoad = EncryptDecrypt(dataToLoad);
            //loadedData = JsonUtility.FromJson<Employee>(dataToLoad);

            loadedData = JsonConvert.DeserializeObject<Employee>(dataToLoad);
            return loadedData;
        }
    }

    public void SaveEmployees(Employee empl)
    {
        string dataToStore = JsonConvert.SerializeObject(empl); ;

        //dataToStore = EncryptDecrypt(dataToStore);

        using (FileStream stream = new FileStream(GetPath(), FileMode.Create))
        {
            using (StreamWriter writer = new StreamWriter(stream))
            {
                writer.Write(dataToStore);
            }
        }
    }

    private static string GetPath()
    {
        return Application.persistentDataPath + "/employee.json";
    }

//    public void SerializeGameData()
//    {
//        string json = JsonUtility.ToJson(employees);
//        File.WriteAllText(pathGameData, json);
//    }
//    public void DeserializeQuestions()
//    {
//        string json;
//        path = Application.streamingAssetsPath + "/employee.json";
//#if UNITY_EDITOR
//        path = Path.Combine(Application.streamingAssetsPath, "employee.json");
//#endif
//        if (Application.platform == RuntimePlatform.Android)
//        {
//            WWW reader = new WWW(path);
//            while (!reader.isDone) { }

//            var streamReader = reader.text;
//            employees = JsonConvert.DeserializeObject<Employees>(streamReader);
//        }
//        else
//        {
//            json = File.ReadAllText(path);
//            employees = JsonConvert.DeserializeObject<Employees>(json);
//            Debug.Log("We use editor");
//        }

//        //employees = JsonConvert.DeserializeObject<Employees>(streamReader);

//        //foreach (KeyValuePair<int, Candidate> entry in employees.candidate)
//        //{
//        //    entry.Value.employeePhoto = Resources.Load<Sprite>(entry.Value.photoUrl);
//        //}
//        //foreach (KeyValuePair<int, Worker> entry in employees.worker)
//        //{
//        //    entry.Value.employeePhoto = Resources.Load<Sprite>(entry.Value.photoUrl);
//        //}
//    }
}

public class Employee
{
    public Dictionary<int, Candidate> candidate;
    public Dictionary<int, Worker> worker;
}

[System.Serializable]
public class Candidate
{
    public string name;
    public string photoUrl;
    [JsonIgnore]
    public Sprite employeePhoto;
    public string bio;
    //public int skill1;
    // public int skill2;
    //public int skill3;
}


[System.Serializable]
public class Worker
{
    public string name;
    public string photoUrl;
    [JsonIgnore]
    public Sprite employeePhoto;
    public string bio;
    //public int skill1;
    // public int skill2;
    //public int skill3;
}