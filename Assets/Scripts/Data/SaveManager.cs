using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.Playables;

public class SaveSystem
{
    private readonly static string encryptionCodeWord = "word";
    public static void Save(GameData data)
    {
        string dataToStore = JsonUtility.ToJson(data, true);

        //dataToStore = EncryptDecrypt(dataToStore);

        using (FileStream stream = new FileStream(GetPath(), FileMode.Create))
        {
            using (StreamWriter writer = new StreamWriter(stream))
            {
                writer.Write(dataToStore);
            }
        }
    }

    public static GameData Load()
    {
        if (!File.Exists(GetPath()))
        {
            GameData emptyData = new GameData();
            Save(emptyData);
            return emptyData;
        }
        GameData loadedData = null;
        string dataToLoad = "";
        using (FileStream stream = new FileStream(GetPath(), FileMode.Open))
        {
            using (StreamReader reader = new StreamReader(stream))
            {
                dataToLoad = reader.ReadToEnd();
            }
            //dataToLoad = EncryptDecrypt(dataToLoad);
            loadedData = JsonUtility.FromJson<GameData>(dataToLoad);

            return loadedData;
        }
    }

    private static string GetPath()
    {
        return Application.persistentDataPath + "/data.json";
    }

    private static string EncryptDecrypt(string data)
    {
        string modifiedData = "";
        for (int i = 0; i < data.Length; i++)
        {
            modifiedData += (char)(data[i] ^ encryptionCodeWord[i % encryptionCodeWord.Length]);
        }
        return modifiedData;
    }
}