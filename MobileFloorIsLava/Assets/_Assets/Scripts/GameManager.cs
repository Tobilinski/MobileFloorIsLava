using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] private GameObject[] tiles;
    [SerializeField] private Transform spawnPoint;
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

        StartCoroutine(Spawn());

        //TileSpawn();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void TileSpawn()
    {
        int Index = Random.Range(0, tiles.Length);


    }
    IEnumerator Spawn()
    {
        for (int i = 0; i < tiles.Length; i++)
        {
            Instantiate(tiles[i], spawnPoint);
            yield return new WaitForSeconds(3f);
        }
        
        

    }
}
