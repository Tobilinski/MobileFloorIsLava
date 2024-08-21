using System.Collections;
using System.IO;
using UnityEngine;

public class UserManager : MonoBehaviour
{
    public static UserManager Instance;
    [SerializeField] public SaveableStats stats = new SaveableStats();
    [SerializeField] private string filePath;
    private int score;

    public string FilePath { get => filePath; set => filePath = value; }

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
        FilePath = Application.persistentDataPath + "/userData.json";
    }
    public void Start()
    {
        StartCoroutine(Delayer());
       
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
        File.WriteAllText(FilePath, data);
        print("Saving data");
    }
    public void LoadData()
    {
        string data = File.ReadAllText(FilePath);
        stats = JsonUtility.FromJson<SaveableStats>(data);
    }

    public void AddScoreToData()
    {
        stats.GoldCoins += 1;
        score += 1;
    }
    public IEnumerator Delayer()
    {
        yield return new WaitForSeconds(0.5f);
        LoadData();
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

