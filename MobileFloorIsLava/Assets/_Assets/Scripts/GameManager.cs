using System;
using System.Collections;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] private GameObject prefabPlatParticle;
    [SerializeField] private GameObject prefabPlatNoParticle;

    [SerializeField] private TextMeshProUGUI scoreUI;
    [SerializeField] private TextMeshProUGUI highScoreUI;
    [SerializeField] private TextMeshPro pathUI;


    private int platformCount = 150;
    
    // Start is called before the first frame update
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {

        StartCoroutine(Delayer());
        Vector3 spawnPositionPart = new Vector3();
        for (int i = 0; i < platformCount; i++)
        {
            spawnPositionPart.y += Random.Range(.5f, 1f);
            spawnPositionPart.x = Random.Range(-3.5f, 3.5f);
            Instantiate(prefabPlatParticle, spawnPositionPart, Quaternion.identity);
        }
        Vector3 spawnPositionNoPart = new Vector3();
        for (int i = 0; i < platformCount; i++)
        {
            spawnPositionNoPart.y += 1;
            spawnPositionNoPart.x = Random.Range(-4f, 4f);
            Instantiate(prefabPlatNoParticle, spawnPositionNoPart, Quaternion.identity);
        }
    }
    public IEnumerator Delayer()
    {
        yield return new WaitForSeconds(0.6f);
        pathUI.text = $"{UserManager.Instance.FilePath}";
        highScoreUI.text = $"High Score: {UserManager.Instance.stats.HighScore}";
    }

    private void Update()
    {
        scoreUI.text = $"Score: {UserManager.Instance.Score()}";
    }
}


