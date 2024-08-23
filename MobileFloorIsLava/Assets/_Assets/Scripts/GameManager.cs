using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

[System.Serializable]
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    
    public Vector3 SpawnPositionPart { get => spawnPositionPart; set => spawnPositionPart = value; }

    [SerializeField] private GameObject prefabPlatParticle;
    [SerializeField] private GameObject prefabPlatNoParticle;

    [SerializeField] private TextMeshProUGUI scoreUI;
    [SerializeField] private TextMeshProUGUI highScoreUI;
    [SerializeField] private TextMeshPro pathUI;
    [SerializeField] private Vector3 spawnPositionPart = new Vector3();
    [SerializeField] private Vector3 spawnPositionNoPart = new Vector3();

    [SerializeField] private GameObject platformParent;
    [SerializeField] private int platformCount;
    [SerializeField] private ColliderEventTrigger resetEvent;
    
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
        resetEvent = GameObject.Find("Reset").GetComponent<ColliderEventTrigger>();
        resetEvent.OnEnter.AddListener(ResetGame);
        resetEvent.gameObject.SetActive(false);
        StartCoroutine(Delayer());
        
        SpawnPlatforms();
        Debug.Log("Objects Placed");
    }
    private void SpawnPlatforms()
    {
        for (int i = 0; i < platformCount; i++)
        {
            spawnPositionPart.y += Random.Range(.5f, 1f);
            spawnPositionPart.x = Random.Range(-3.5f, 3.5f);
            GameObject obj = Instantiate(prefabPlatParticle, spawnPositionPart, Quaternion.identity);
            obj.transform.SetParent(platformParent.transform);
        }

        for (int i = 0; i < platformCount; i++)
        {
            spawnPositionNoPart.y += 1;
            spawnPositionNoPart.x = Random.Range(-4f, 4f);
            GameObject obj = Instantiate(prefabPlatNoParticle, spawnPositionNoPart, Quaternion.identity);
            obj.transform.SetParent(platformParent.transform);
        }
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


