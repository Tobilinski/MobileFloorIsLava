using System.IO;
using UnityEngine;

public class UserManager : MonoBehaviour
{
    public static UserManager Instance;
    [SerializeField] public SaveableStats stats = new SaveableStats();
    [SerializeField] private string filePath;
    private int score;
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
    public int Score()
    {
        return score;
    }


    public void SaveToJson()
    {
        if (score > stats.HighScore)
        {
            stats.HighScore = score;
        }
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
        score += 1;
    }
}

[System.Serializable]
public class SaveableStats
{
    [SerializeField] private int goldCoins;
    [SerializeField] private int highScore;

    public int GoldCoins { get => goldCoins; set => goldCoins = value; }
    public int HighScore { get => highScore; set => highScore = value; }
}

