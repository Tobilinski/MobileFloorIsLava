using System.IO;
using UnityEngine;

public class UserManager : MonoBehaviour
{
    public static UserManager Instance;
    [SerializeField] private SaveableStats stats = new SaveableStats();
    [SerializeField] private string filePath;
    public void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
        filePath = Application.persistentDataPath + "/userData.json";
    }
    public void Start()
    {
        LoadData();
    }
    public void OnApplicationQuit()
    {
        SaveToJson();
    }


    public void SaveToJson()
    {
        string data = JsonUtility.ToJson(stats);
        File.WriteAllText(filePath, data);
        print("Saving data");
    }
    public void LoadData()
    {
        if (File.Exists(filePath))
        {
            string data = File.ReadAllText(filePath);
            stats = JsonUtility.FromJson<SaveableStats>(data);
        }
        else
        {
            string data = JsonUtility.ToJson(stats);
            File.WriteAllText(filePath, data);
            print("File Created ready for load");
        }
    }

    public void AddScoreToData()
    {
        stats.GoldCoins += 1;
        stats.PlatsformsReached += 1;
    }
}

[System.Serializable]
public class SaveableStats
{
    [SerializeField] private int goldCoins;
    [SerializeField] private int platsformsReached;

    public int GoldCoins { get => goldCoins; set => goldCoins = value; }
    public int PlatsformsReached { get => platsformsReached; set => platsformsReached = value; }
}
