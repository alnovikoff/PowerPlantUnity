using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System.IO;

public class JsonReader : MonoBehaviour
{
    public TextAsset textJson;
    public TextAsset eventsTextJson;
    public Emplyees emplyees;
    public GameEventsHolder gameEvents;

    void Start()
    {
        LoadEmployees();
        LoadGameEvents();
    }

    public void LoadGameEvents()
    {
        gameEvents = JsonConvert.DeserializeObject<GameEventsHolder>(eventsTextJson.ToString());
    }

    public void LoadEmployees()
    {
        emplyees = JsonConvert.DeserializeObject<Emplyees>(textJson.ToString());
        //for (int i = 1; i < emplyees.candidate.Count; i++)
        foreach (KeyValuePair<int, Candidate> entry in emplyees.candidate)
        {
            entry.Value.employeePhoto = Resources.Load<Sprite>(entry.Value.photoUrl);
        }
        foreach (KeyValuePair<int, Worker> entry in emplyees.worker)
        {
            entry.Value.employeePhoto = Resources.Load<Sprite>(entry.Value.photoUrl);
        }
    }

    public void SaveToFile()
    {

        //string assetPath = Resources.Load("employee").ToString();//AssetDatabase.GetAssetPath(textJson);
        //string filePath = Application.dataPath + "/" + assetPath.Replace("Assets/", "");
        string filePath = "MyGame_Data/Resources/employee.json";
        string json = JsonConvert.SerializeObject(emplyees, Formatting.Indented);
        // filepath
        File.WriteAllText(filePath, json);
    }
}

public class Emplyees
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