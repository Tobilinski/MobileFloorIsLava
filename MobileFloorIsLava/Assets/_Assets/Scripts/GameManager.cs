using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;
using Sirenix.OdinInspector;

[System.Serializable]
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    
    [Title("Platforms", "Platforms prefabs used to spawn in", TitleAlignments.Centered)]
    [SerializeField]  private List<GameObject> platforms;
    public List<GameObject> Platforms { get => platforms; set => platforms = value; }
    public Vector3 HighestPlatformPos { get => highestPlatformPos; set => highestPlatformPos = value; }

    [SerializeField] private GameObject[] prefabPlat;
    [SerializeField] private TextMeshProUGUI scoreUI;
    [SerializeField] private TextMeshProUGUI highScoreUI;
    [SerializeField] private TextMeshPro pathUI;
    private GameObject newPlatform;
    
    [ReadOnly]
    [SerializeField] private Vector3 highestPlatformPos;

    [SerializeField] private GameObject platformParent;
    [SerializeField] private int platformCount;
    private ColliderEventTrigger resetTrigger;
    private ColliderEventTrigger gameManagerTrigger;
    [SerializeField] private PlayerController player;
   
    
    // Start is called before the first frame update
    void Awake()
    {
        if (Instance is not null)
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
        resetTrigger = GameObject.Find("$$Reset$$").GetComponent<ColliderEventTrigger>();
        gameManagerTrigger = GetComponent<ColliderEventTrigger>();
        resetTrigger.OnEnter.AddListener(ResetGame);
        resetTrigger.gameObject.SetActive(false);
        StartCoroutine(Delayer());
        gameManagerTrigger.OnTriggerEnterPlatform.AddListener((gameObject) => SpawnPlatforms(gameObject));
        
        
        //Debug.Log("Objects Placed");
    }
    private void SpawnPlatforms(GameObject triggeringObject)
    {
        newPlatform = Instantiate(prefabPlat[Random.Range(0, prefabPlat.Length)], new Vector2(Random.Range(-2.5f, 2.5f), 
                                    player.transform.position.y + (1 + Random.Range(1f,1.5f))),Quaternion.identity);
        Destroy(triggeringObject);
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


