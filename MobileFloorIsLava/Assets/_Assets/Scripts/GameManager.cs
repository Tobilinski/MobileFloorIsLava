using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

[System.Serializable]
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    
    public List<GameObject> Platforms { get => platforms; set => platforms = value; }
    public Vector3 HighestPlatformPos { get => highestPlatformPos; set => highestPlatformPos = value; }

    [SerializeField] private GameObject[] prefabPlat;
    

    [SerializeField] private TextMeshProUGUI scoreUI;
    [SerializeField] private TextMeshProUGUI highScoreUI;
    [SerializeField] private TextMeshPro pathUI;
    private Vector3 spawnPositionPart = new Vector3();
    private Vector3 spawnPositionNoPart = new Vector3();
    [SerializeField] private Vector3 highestPlatformPos;

    [SerializeField] private GameObject platformParent;
    [SerializeField] private int platformCount;
    private ColliderEventTrigger resetEvent;
    [SerializeField]  private List<GameObject> platforms;
    
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
        resetEvent = GameObject.Find("$$Reset$$").GetComponent<ColliderEventTrigger>();
        resetEvent.OnEnter.AddListener(ResetGame);
        resetEvent.gameObject.SetActive(false);
        StartCoroutine(Delayer());
        
        SpawnPlatforms();
        
        //Debug.Log("Objects Placed");
    }
    private void SpawnPlatforms()
    {
        for (int i = 0; i < platformCount; i++)
        {
            spawnPositionPart.y += Random.Range(.5f, 1f);
            spawnPositionPart.x = Random.Range(-3.5f, 3.5f);

            GameObject obj = prefabPlat[Random.Range(0, prefabPlat.Length)];
            GameObject newObj = Instantiate(obj, spawnPositionPart, Quaternion.identity);
            newObj.transform.SetParent(platformParent.transform);
            Platforms.Add(obj);
            
        }
        highestPlatformPos = Platforms[platforms.Count -1].transform.position;
    }
    
    public void ResetGame(GameObject gameOb)
    {
        SceneManager.LoadScene("Game");
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


