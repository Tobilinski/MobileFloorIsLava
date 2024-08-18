using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] private GameObject prefabPlatParticle;
    [SerializeField] private GameObject prefabPlatNoParticle;
    
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

       
        Vector3 spawnPositionPart = new Vector3();
        for (int i = 0; i < platformCount; i++)
        {
            spawnPositionPart.y += Random.Range(.5f, 1f);
            spawnPositionPart.x = Random.Range(-2.5f, 2.5f);
            Instantiate(prefabPlatParticle, spawnPositionPart, Quaternion.identity);
        }
        Vector3 spawnPositionNoPart = new Vector3();
        for (int i = 0; i < platformCount; i++)
        {
            spawnPositionNoPart.y += 1;
            spawnPositionNoPart.x = Random.Range(-2f, 2f);
            Instantiate(prefabPlatNoParticle, spawnPositionNoPart, Quaternion.identity);
        }
    }

    
}


